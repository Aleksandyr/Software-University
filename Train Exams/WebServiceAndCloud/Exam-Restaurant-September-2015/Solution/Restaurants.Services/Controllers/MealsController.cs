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
    public class MealsController : ApiController
    {
        private readonly IRestaurantData db;

        public MealsController()
            : this(new RestaurantData())
        {
        }

        public MealsController(IRestaurantData data)
        {
            this.db = data;
        }

      
        // PUT: api/Meals/5
        [ResponseType(typeof(void))]
        [HttpPut]
        [Authorize]
        public IHttpActionResult EditExistingMeal(int id, ExistingMealBindingModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var meal = this.db.Meals.All().FirstOrDefault(m => m.Id == id);
            if (meal == null)
            {
                return NotFound();
            }

            var currUserId = User.Identity.GetUserId();
            if (meal.Restaurant.OwnerId != currUserId)
            {
                return Unauthorized();
            }

            var currType = this.db.MealTypes.All().FirstOrDefault(t => t.Id == model.TypeId);
            meal.Name = model.Name;
            meal.Price = model.Price;
            meal.Type = currType;

            this.db.Meals.Update(meal);
            this.db.SaveChanges();

            var mealViewModel = new MealViewModel()
            {
                Id = meal.Id,
                Name = meal.Name,
                Price = meal.Price,
                Type = meal.Type.Name
            };

            return this.Created("http://localhost:1337/api/meals/" + meal.Id, mealViewModel);
        }

        // POST: api/Meals
        [ResponseType(typeof(Meal))]
        public IHttpActionResult PostMeal(MealBindingModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currRestaurant = this.db.Restaurants.All().FirstOrDefault(r => r.Id == model.RestaurantId);
            var currMealType = this.db.MealTypes.All().FirstOrDefault(m => m.Id == model.TypeId);

            var meal = new Meal()
            {
                Name = model.Name,
                Price = model.Price,
                Restaurant = currRestaurant,
                Type = currMealType
            };

           
            db.Meals.Add(meal);
            db.SaveChanges();

            var mealViewModel = new MealViewModel()
            {
                Id = meal.Id,
                Name = meal.Name,
                Price = meal.Price,
                Type = meal.Type.Name
            };

            return this.Created("http://localhost:1337/api/meals/" + meal.Id, mealViewModel);
        }

        //Post api/meals/{id}/order
        [Route("api/meals/{id}/order")]
        [Authorize]
        [HttpPost]
        public IHttpActionResult CreateOrder(int id, OrderBindingModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var meal = this.db.Meals.All().FirstOrDefault(m => m.Id == id);
            if (meal == null)
            {
                return NotFound();
            }

            var currUserId = User.Identity.GetUserId();
            var currUser = this.db.Users.Find(currUserId);

            var order = new Order()
            {
                Meal = meal,
                Quantity = model.Quantity,
                User = currUser,
                CreatedOn = DateTime.Now,
                OrderStatus = OrderStatus.Pending
            };
            
            db.Orders.Add(order);
            db.SaveChanges();

            return Ok();
        }

        // DELETE: api/Meals/5
        [ResponseType(typeof(Meal))]
        [Authorize]
        public IHttpActionResult DeleteMeal(int id)
        {
            var meal = this.db.Meals.All().FirstOrDefault(m => m.Id == id);
            if (meal == null)
            {
                return NotFound();
            }

            var currUserId = User.Identity.GetUserId();
            if (meal.Restaurant.OwnerId != currUserId)
            {
                return Unauthorized();
            }

            db.Meals.Remove(meal);
            db.SaveChanges();

            return Ok(new
            {
                Message = "Meal #" + meal.Id + " deleted."
            });
        }
    }
}