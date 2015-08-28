using System.ComponentModel.DataAnnotations;

namespace BookShopWebApp.Models.BindingModels
{
    public class CategoryBindingModel
    {
        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Cateory name")]
        public string Name { get; set; }
    }
}