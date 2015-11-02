using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurants.Services.Models.BindingModels
{
    public class ExistingMealBindingModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int TypeId { get; set; }
    }
}