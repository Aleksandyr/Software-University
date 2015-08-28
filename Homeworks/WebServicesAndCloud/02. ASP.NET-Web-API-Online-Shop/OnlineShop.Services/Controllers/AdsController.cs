using System;
using System.Collections.Generic;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.Services.Models.BindingModels;
using OnlineShop.Services.Models.ViewModels;
using WebGrease.Css.Extensions;

namespace OnlineShop.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    [RoutePrefix("api/ads")]
    public class AdsController : BaseApiController
    {
        [HttpGet]
        public IHttpActionResult GetAds()
        {
            var ads = this.Data.Ads
                .Where(a => !a.ClosedOn.HasValue)
                .OrderByDescending(a => a.Type.Name)
                .ThenBy(a => a.PostedOn)
                .Select(AdViewModel.Create);

            return this.Ok(ads);
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult CreateAd(CreateAdBindingModel model)
        {
            var userId = this.User.Identity.GetUserId();
            if (userId == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var categories = new HashSet<Category>();
            var allCategories = this.Data.Categories;
            foreach (var category in model.Categories)
            {
                var categoryData = allCategories.FirstOrDefault(c => c.Id == category);
                if (categoryData == null)
                {
                    return this.BadRequest("Invalid category");
                }

                categories.Add(categoryData);
            }

            var ad = new Ad()
            {
                Name = model.Name,
                Description = model.Description,
                PostedOn = DateTime.Now,
                TypeId = model.TypeId,
                Price = model.Price,
                OwnerId = userId,
                Categories = categories
            };

            this.Data.Ads.Add(ad);
            this.Data.SaveChanges();

            var result = this.Data.Ads
                .Where(a => a.Id == ad.Id)
                .Select(AdViewModel.Create)
                .FirstOrDefault();

            return this.Ok(result);
        }

        [Authorize]
        [HttpPut]
        [Route("{id}/close")]
        public IHttpActionResult ClosedAd(int id)
        {
            var ad = this.Data.Ads.Find(id);
            if (ad == null)
            {
                return this.NotFound();
            }

            var userId = this.User.Identity.GetUserId();
            if (userId == null)
            {
                return this.BadRequest();
            }

            if (ad.OwnerId != userId)
            {
                return this.BadRequest("User is not owner of the ad!");
            }

            ad.Status = AdStatus.Closed;
            ad.ClosedOn = DateTime.Now;

            this.Data.SaveChanges();

            var result = this.Data.Ads
                .Where(a => a.Id == ad.Id)
                .Select(AdViewModel.Create)
                .FirstOrDefault();

            return this.Ok(result);
        }
    }
}