using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShopWebApp.Models.ViewModels
{
    public class PurchaseViewModel
    {
        public string User { get; set; }

        public double Price { get; set; }

        public string BookName { get; set; }
    }
}