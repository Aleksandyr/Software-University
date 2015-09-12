using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Restaurants.Models;

namespace Restaurants.Services.Models.ViewModels
{
    public class TownViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static Expression<Func<Town, TownViewModel>> Create
        {
            get
            {
                return r => new TownViewModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                };
            }
        }
    }
}