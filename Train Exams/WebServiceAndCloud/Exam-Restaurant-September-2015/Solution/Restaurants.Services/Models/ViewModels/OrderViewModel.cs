using System;
using System.Linq.Expressions;
using Restaurants.Models;

namespace Restaurants.Services.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public MealViewModel Meal { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }

        public static Expression<Func<Order, OrderViewModel>> Create
        {
            get
            {
                return o => new OrderViewModel()
                {
                    Id = o.Id,
                    Meal = new MealViewModel()
                    {
                        Id = o.MealId,
                        Name = o.Meal.Name,
                        Price = o.Meal.Price,
                        Type = o.Meal.Type.Name
                    },
                    Quantity = o.Quantity,
                    Status = (int) o.OrderStatus,
                    CreatedOn = o.CreatedOn
                };
            }
        } 
    }
}