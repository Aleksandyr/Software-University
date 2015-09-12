using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using Restaurants.Data;
using Restaurants.Data.UnitOfWork;
using Restaurants.Models;
using Restaurants.Services.Models.BindingModels;
using Restaurants.Services.Models.ViewModels;

namespace Restaurants.Services.Controllers
{
    [RoutePrefix("api/restaurants")]
    public class RestaurantsController : ApiController
    {
        private readonly IRestaurantData db;

        public RestaurantsController() : this(new RestaurantData())
        {
        }

        public RestaurantsController(IRestaurantData data)
        {
            this.db = data;
        }

        // GET: api/Restaurants
        public IHttpActionResult GetRestaurantsByTown([FromUri] int townId)
        {
            var restaurants =
                db.Restaurants.All().Where(r => r.TownId == townId)
                    .OrderBy(r => r.Ratings.Average(rat => rat.Stars))
                    .ThenBy(r => r.Name)
                    .Select(RestaurantViewModel.Create);
            return this.Ok(restaurants);
        }

        // GET: api/Restaurants/5/meals
        [ResponseType(typeof(Restaurant))]
        [Route("{id}/meals")]
        public IHttpActionResult GetRestaurantMeals(int id)
        {
            var restaurant = this.db.Restaurants.All().FirstOrDefault(r => r.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            var meals = db.Meals.All().Where(m => m.RestaurantId == id)
                .OrderBy(m => m.Type.Name)
                .ThenBy(m => m.Name)
                .Select(MealViewModel.Create);

            return Ok(meals);
        }

        // POST: api/Restaurants
        [ResponseType(typeof (Restaurant))]
        [HttpPost]
        [Authorize]
        public IHttpActionResult CreateRestaurant(RestaurantBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currUserId = User.Identity.GetUserId();
            var currUser = db.Users.Find(currUserId);
            var town = db.Towns.All().FirstOrDefault(t => t.Id == model.TownId);

            var restaurant = new Restaurant()
            {
                Name = model.Name,
                Town = town,
                Owner = currUser
            };

            var restaurantViewModel = new RestaurantViewModel()
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Rating = (restaurant.Ratings.Any()) ? restaurant.Ratings.Average(r => r.Stars) : (double?) null,
                Town = new TownViewModel()
                {
                    Id = town.Id,
                    Name = town.Name
                }
            };

            db.Restaurants.Add(restaurant);
            db.SaveChanges();

            return this.Created("http://localhost:1337/api/restaurants/" + restaurant.Id, restaurantViewModel);
        }

        [HttpPost]
        [Route("{id}/rate")]
        [Authorize]
        public IHttpActionResult RateExistingRestaurant([FromUri] int id, [FromBody] RateBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restaurant = this.db.Restaurants.All().FirstOrDefault(r => r.Id == id);
            if (restaurant == null)
            {
                return this.NotFound();
            }

            var currUserId = User.Identity.GetUserId();
            var currUser = db.Users.Find(currUserId);

            var rating = this.db.Ratings.All().FirstOrDefault(rat => rat.RestaurantId == restaurant.Id && rat.UserId == currUserId);

            
            if (rating == null)
            {
                rating = new Rating()
                {
                    Stars = model.Stars,
                    Restaurant = restaurant,
                    User = currUser ?? null
                };
            }
            else
            {
                rating.Stars = model.Stars;
            }
          

            this.db.Ratings.Update(rating);
            this.db.SaveChanges();

            return this.Ok();
        }
    }
}