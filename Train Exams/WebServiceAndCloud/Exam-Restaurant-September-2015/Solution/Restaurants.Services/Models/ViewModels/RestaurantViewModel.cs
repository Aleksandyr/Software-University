using System;
using System.Linq;
using System.Linq.Expressions;
using Restaurants.Models;

namespace Restaurants.Services.Models.ViewModels
{
    public class RestaurantViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Rating { get; set; }
        public TownViewModel Town { get; set; }

        public static Expression<Func<Restaurant, RestaurantViewModel>> Create
        {
            get
            {
                return r => new RestaurantViewModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Rating = (r.Ratings.Any()) ? r.Ratings.Average(rat => rat.Stars) : (double?)null,
                    Town = new TownViewModel()
                    {
                        Id = r.TownId,
                        Name = r.Town.Name
                    }
                };
            }
        } 
    }
}