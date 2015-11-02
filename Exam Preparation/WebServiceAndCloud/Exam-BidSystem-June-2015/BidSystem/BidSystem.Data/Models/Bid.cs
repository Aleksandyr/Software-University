using System;
using System.ComponentModel.DataAnnotations;

namespace BidSystem.Data.Models
{
    public class Bid
    {
        public int Id { get; set; }

        public DateTime DateCreate { get; set; }

        [Required]
        public string BidderId { get; set; }
        
        public User Bidder { get; set; }

        public decimal OfferedPrice { get; set; }

        public string Comment { get; set; }

        [Required]
        public int OfferId { get; set; }

        public virtual Offer Offer { get; set; }
    }
}
