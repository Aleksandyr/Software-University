using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BidSystem.Data.Models;

namespace BidSystem.RestServices.Models.ViewModels
{
    public class OfferViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Saller { get; set; }

        public DateTime DatePublished { get; set; }

        public decimal InitialPrice { get; set; }

        public DateTime ExpirationDateTime { get; set; }

        public bool IsExpired { get; set; }

        public int BidsCount { get; set; }

        public string BidWinner { get; set; }

        public static Expression<Func<Offer, OfferViewModel>> Create
        {
            get
            {
                return o => new OfferViewModel()
                {
                    Id = o.Id,
                    Title = o.Title,
                    Description = o.Description,
                    Saller = o.Saller != null ? o.Saller.UserName : null,
                    DatePublished = o.DatePublished,
                    InitialPrice = o.InitialPrice,
                    ExpirationDateTime = o.ExpirationDateTime,
                    IsExpired = o.ExpirationDateTime <= DateTime.Now,
                    BidsCount = o.Bids.Count,
                    BidWinner = o.ExpirationDateTime <= DateTime.Now && o.Bids.Count > 0 ? 
                                o.Bids.OrderByDescending(b => b.OfferedPrice).FirstOrDefault().Bidder.UserName : 
                                null
                };
            }
        } 
    }

    public class OfferWithBidsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Saller { get; set; }

        public DateTime DatePublished { get; set; }

        public decimal InitialPrice { get; set; }

        public DateTime ExpirationDateTime { get; set; }

        public bool IsExpired { get; set; }

        public string BidWinner { get; set; }
        public IEnumerable<BidsViewModel> Bids{ get; set; }

        public static Expression<Func<Offer, OfferWithBidsViewModel>> Create
        {
            get
            {
                return o => new OfferWithBidsViewModel()
                {
                    Id = o.Id,
                    Title = o.Title,
                    Description = o.Description,
                    Saller = o.Saller != null ? o.Saller.UserName : null,
                    DatePublished = o.DatePublished,
                    InitialPrice = o.InitialPrice,
                    ExpirationDateTime = o.ExpirationDateTime,
                    IsExpired = o.ExpirationDateTime <= DateTime.Now,
                    BidWinner = o.ExpirationDateTime <= DateTime.Now && o.Bids.Count > 0 ?
                                o.Bids.OrderByDescending(b => b.OfferedPrice).FirstOrDefault().Bidder.UserName :
                                null,
                    Bids = o.Bids.Select(b => new BidsViewModel()
                    {
                        Id = b.Id,
                        Bidder = b.Bidder.UserName,
                        Comment = b.Comment,
                        OfferedPrice = b.OfferedPrice,
                        OfferId = b.OfferId,
                        DateCreate = b.DateCreate
                    })
                    .OrderByDescending(b => b.DateCreate)
                };
            }
        }
    }
}