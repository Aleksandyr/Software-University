using System;
using System.Collections.Generic;

namespace BidSystem.Data.Models
{
    public class Offer
    {
        public Offer()
        {
            this.Bids = new HashSet<Bid>();
        }
        
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public virtual User Saller { get; set; }

        public DateTime DatePublished { get; set; }

        public decimal InitialPrice { get; set; }

        public DateTime ExpirationDateTime { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }
    }
}
