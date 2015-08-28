using System.ComponentModel.DataAnnotations;

namespace BookShopWebApp.Models.BindingModels
{
    public class BookPutBindingModel : BookBindingModel
    {
        [Required(ErrorMessage = "Author Id is required!")]
        public int AuthorId { get; set; }
    }
}