using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Book")]
        public int BookId { get; set; }

        public virtual Book Book  { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Price")]
        public double Price { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public DateTime? DateOfPurchase { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "is-recalled")]
        public bool IsRecalled { get; set; }
    }
}
