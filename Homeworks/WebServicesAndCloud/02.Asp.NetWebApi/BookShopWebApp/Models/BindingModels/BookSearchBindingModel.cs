using System.ComponentModel.DataAnnotations;

namespace BookShopWebApp.Models.BindingModels
{
    public class BookSearchBindingModel
    {
        [Required]
        public string Search { get; set; }
    }
}