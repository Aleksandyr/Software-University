using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BookShopWebApp.Models.ViewModels
{
    public class UsersPurchasesViewModel
    {
        public string Username { get; set; }

        public string BookTitle { get; set; }

        public decimal Price { get; set; }

        public DateTime? DateOfPurchase { get; set; }

        public bool IsRecalled { get; set; }
    }
}