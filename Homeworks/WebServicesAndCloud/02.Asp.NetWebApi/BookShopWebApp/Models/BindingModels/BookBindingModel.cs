using System.ComponentModel.DataAnnotations;
using BookShop.Models;

namespace BookShopWebApp.Models.BindingModels
{
    public class BookBindingModel
    {
        [MinLength(1, ErrorMessage = "Title must be least 1 symbol long")]
        [MaxLength(50, ErrorMessage = "Title must be longer than 50 symbol")]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        
        [MaxLength(1000, ErrorMessage = "Description must not be longer than 1000 symbols")]
        public string Description { get; set; }
        
        public EditinType EditinType { get; set; }
        
        [Required(ErrorMessage = "Price is required!")]
        public double Price { get; set; }

        public int Copies { get; set; }

        [Required(ErrorMessage = "Age Restriction is required!")]
        public AgeRestriction AgeRestriction { get; set; }
    }
}