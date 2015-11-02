using System.ComponentModel.DataAnnotations;

namespace Restaurants.Services.Models.BindingModels
{
    public class RateBindingModel
    {
        [Range(1, 10)]
        public int Stars { get; set; }
    }
}