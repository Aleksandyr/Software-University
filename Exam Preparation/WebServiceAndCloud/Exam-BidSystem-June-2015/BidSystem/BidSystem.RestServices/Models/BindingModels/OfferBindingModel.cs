using System;
using System.ComponentModel.DataAnnotations;

namespace BidSystem.RestServices.Models
{
    public class OfferBindingModel
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
       
        [Required]
        public decimal InitialPrice { get; set; }
        
        [Required]
        public DateTime ExpirationDateTime { get; set; }
    }
}