using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
    public class OrdersController : ApiController
    {
        private readonly IRestaurantData db;

        public OrdersController() : this(new RestaurantData())
        {
        }

        public OrdersController(IRestaurantData data)
        {
            this.db = data;
        }

        // GET api/orders?startPage={start-page}&limit={page-size}&mealId={mealId}
        [ResponseType(typeof (Order))]
        [Authorize]
        public IHttpActionResult GetPendingOrders([FromUri] FilterOrdersBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Missing order data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = this.User.Identity.GetUserId();
            var user = this.db.Users.Find(userId);

            if (user == null)
            {
                return this.Unauthorized();
            }

            var orders = this.db.Orders.All()
                .Where(o => o.UserId == userId && o.OrderStatus == OrderStatus.Pending)
                .AsQueryable();

            var meal = this.db.Meals.Find(model.MealId);

            if (meal != null)
            {
                orders = orders.Where(o => o.MealId == model.MealId);
            }

            var data = orders
                .OrderBy(o => o.CreatedOn)
                .Skip(model.StartPage*model.Limit)
                .Take(model.Limit)
                .Select(o => new OrderViewModel()
                {
                    Id = o.Id,
                    Meal = new MealViewModel()
                    {
                        Id = o.Meal.Id,
                        Name = o.Meal.Name,
                        Price = o.Meal.Price,
                        Type = o.Meal.Type.Name
                    },
                    Quantity = o.Quantity,
                    Status = (int) o.OrderStatus,
                    CreatedOn = o.CreatedOn
                });

            return this.Ok(data);
        }
    }
}
