using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Twitter.Data.UnitOfWork;
using Twitter.Models;
using Twitter.Web.Models.TweetModels;
using Twitter.Web.Models.UserModels;

namespace Twitter.Web.Controllers
{
    public class UserController : BaseController
    {
        public UserController(ITwitterData data)
            : base(data)
        {
        }

        [Authorize]
        public ActionResult UserProfile()
        {
            var user = this.TwitterData.Users.Find(this.User.Identity.GetUserId());
            var viewModel = new UserViewModel()
            {
                UserName = user.UserName
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTweet(TweetBindingModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid Data");
            }

            var tweet = new Tweet()
            {
                Message = model.Message,
                TimeStamp = DateTime.Now,
                User = this.TwitterData.Users.Find(this.User.Identity.GetUserId())
            };

            this.TwitterData.Tweets.Add(tweet);
            this.TwitterData.SaveChanges();

            return this.RedirectToAction("Index", "Home");
        }
    }
}