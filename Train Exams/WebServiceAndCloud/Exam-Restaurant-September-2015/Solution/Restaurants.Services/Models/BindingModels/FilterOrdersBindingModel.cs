using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurants.Services.Models.BindingModels
{
    public class FilterOrdersBindingModel
    {
        [Required]
        public int StartPage { get; set; }

        [Required]
        [Range(0, 10)]
        public int Limit { get; set; }

        [Required]
        public int MealId { get; set; }
    }
}