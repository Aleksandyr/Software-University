using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BidSystem.Data;
using BidSystem.Data.Models;
using BidSystem.RestServices.Models;
using BidSystem.RestServices.Models.ViewModels;
using Microsoft.AspNet.Identity;

namespace BidSystem.RestServices.Controllers
{
    [RoutePrefix("api/offers")]
    public class OffersController : ApiController
    {
        private BidSystemDbContext db = new BidSystemDbContext();

        [Route("all")]
        // GET: api/offers/all
        public IQueryable<OfferViewModel> GetAllOffers()
        {
            var offers = db.Offers
                .OrderByDescending(o => o.DatePublished)
                .Select(OfferViewModel.Create);
            
            return offers;
        }

        // GET: api/offers/active
        [Route("active")]
        [ResponseType(typeof(Offer))]
        public IQueryable<OfferViewModel> GetActiveOffers()
        {
            var offers = db.Offers
                .Where(o => o.ExpirationDateTime > DateTime.Now)
                .Select(OfferViewModel.Create);


            return offers;
        }

        // GET: api/offers/expired
        [Route("expired")]
        [ResponseType(typeof(Offer))]
        public IQueryable<OfferViewModel> GetExpiredeOffers()
        {
            var offers = db.Offers
                .Where(o => o.ExpirationDateTime <= DateTime.Now)
                .Select(OfferViewModel.Create);


            return offers;
        }

        // GET: api/offers/details/{id}
        [Route("details/{id}")]
        [ResponseType(typeof(Offer))]
        public IHttpActionResult GetOffersById(int id)
        {
            var offer = db.Offers
                .Select(OfferWithBidsViewModel.Create)
                .FirstOrDefault(o => o.Id == id);

            if (offer == null)
            {
                return NotFound();
            }

            return Ok(offer);
        }

        // GET: api/offers/my
        [Route("my")]
        [Authorize]
        public IQueryable<OfferViewModel> GetUserOffers()
        {
            var currUserId = User.Identity.GetUserId();
            var offers = db.Offers
                .Where(o => o.Saller.Id == currUserId)
                .OrderByDescending(o => o.DatePublished)
                .Select(OfferViewModel.Create);

            return offers;
        }

        // PUT: api/Offers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOffer(int id, Offer offer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != offer.Id)
            {
                return BadRequest();
            }

            

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Offers
        [ResponseType(typeof(Offer))]
        [Authorize]
        public IHttpActionResult PostOffer(OfferBindingModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currUserId = User.Identity.GetUserId();
            var currUser = db.Users.Find(currUserId);

            var offer = new Offer()
            {
                Title = model.Title,
                Description = model.Description,
                InitialPrice = model.InitialPrice,
                ExpirationDateTime = model.ExpirationDateTime,
                DatePublished = DateTime.Now,
                Saller = currUser
            };

            db.Offers.Add(offer);
            db.SaveChanges();


            return this.Created("http://localhost:8888/api/offers/" + offer.Id, new
            {
                offer.Id,
                Saller = offer.Saller.UserName,
                Message = "Offer created."
            });
        }

        // DELETE: api/Offers/5
        [ResponseType(typeof(Offer))]
        public IHttpActionResult DeleteOffer(int id)
        {
            Offer offer = db.Offers.Find(id);
            if (offer == null)
            {
                return NotFound();
            }

            db.Offers.Remove(offer);
            db.SaveChanges();

            return Ok(offer);
        }
    }
}