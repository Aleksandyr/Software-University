using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Restauranteur.Models;
using Restaurants.Data.Repository;
using Restaurants.Models;

namespace Restaurants.Data.UnitOfWork
{
    public interface IRestaurantData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Meal> Meals { get; }

        IRepository<MealType> MealTypes { get; }

        IRepository<Order> Orders { get; }

        IRepository<Rating> Ratings { get; }

        IRepository<Restaurant> Restaurants { get; }

        IRepository<Town> Towns { get; }

        IUserStore<ApplicationUser> UserStore { get; }

        void SaveChanges();
    }
}
