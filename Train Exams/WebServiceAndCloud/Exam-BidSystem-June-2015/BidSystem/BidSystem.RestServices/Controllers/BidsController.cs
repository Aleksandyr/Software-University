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
using BidSystem.RestServices.Models.BindingModels;
using Microsoft.AspNet.Identity;

namespace BidSystem.RestServices.Models.ViewModels
{
    [RoutePrefix("api")]
    public class BitsController : ApiController
    {
        private BidSystemDbContext db = new BidSystemDbContext();

        // GET: api/offers/my
        [Route("bids/my")]
        [Authorize]
        public IQueryable<BidsViewModel> ListUsersBids()
        {
            var currUserId = User.Identity.GetUserId();
            var bids = db.Bids
                .Where(b => b.BidderId == currUserId)
                .OrderByDescending(b => b.DateCreate)
                .Select(BidsViewModel.Create);

            return bids;
        }

        [Route("bids/won")]
        [Authorize]
        [HttpGet]
        public IQueryable<BidsViewModel> ListUsersWonBids()
        {
            var currUserId = User.Identity.GetUserId();
            var bids = db.Bids
                .Where(b => b.BidderId == currUserId)
                .Where(b => b.OfferedPrice == b.Offer.Bids.Max(bid => bid.OfferedPrice))
                .OrderBy(b => b.DateCreate)
                .Select(BidsViewModel.Create);

            return bids;
        }



        // POST: api/offers/117/bid
        [ResponseType(typeof(User))]
        [HttpPost]
        [Route("offers/{id}/bid")]
        [Authorize]
        public IHttpActionResult CreateNewBidForExistingOffer([FromUri] int id, [FromBody] BidBindingModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var offer = db.Offers.Find(id);
            if (offer == null)
            {
                return NotFound();
            }

            if (offer.ExpirationDateTime < DateTime.Now)
            {
                return BadRequest("Offer has expired.");
            }

            var maxBidPrice = offer.InitialPrice;
            if (offer.Bids.Any())
            {
                maxBidPrice = offer.Bids.Max(b => b.OfferedPrice);
            }

            if (model.BidPrice <= maxBidPrice)
            {
                return BadRequest("Your bid should be > " + maxBidPrice);
            }

            var currUserId = User.Identity.GetUserId();
            var bid = new Bid()
            {
                OfferedPrice = model.BidPrice,
                Comment = model.Comment,
                DateCreate = DateTime.Now,
                OfferId = offer.Id,
                BidderId = currUserId
            };


            db.Bids.Add(bid);
            db.SaveChanges();
            

            return Ok(new
            {
                bid.Id,
                Bidder = bid.Bidder.UserName,
                Message = "Bid created."
            });
        }

    }
}