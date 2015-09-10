using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using BidSystem.Data.Models;

namespace BidSystem.RestServices.Models.ViewModels
{
    public class BidsViewModel
    {
        public int Id { get; set; }

        public DateTime DateCreate { get; set; }

        public string Bidder { get; set; }

        public decimal OfferedPrice { get; set; }

        public string Comment { get; set; }

        public int OfferId { get; set; }

        public static Expression<Func<Bid, BidsViewModel>> Create
        {
            get
            {
                return b => new BidsViewModel()
                {
                    Id = b.Id,
                    OfferId = b.OfferId,
                    DateCreate = b.DateCreate,
                    Bidder = b.Bidder.UserName,
                    OfferedPrice = b.OfferedPrice,
                    Comment = b.Comment
                };
            }
        }
    }
}