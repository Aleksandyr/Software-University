using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShopWebApp.Models.BindingModels
{
    public class BookPostBindingModel : BookBindingModel
    {
        public string Categories { get; set; }
    }
}