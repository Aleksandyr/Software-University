using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShopWebApp.Models.ViewModels
{
    public class AuthorViewModel
    {
        public class AuthorBookViewModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public IEnumerable<string> BookTitles { get; set; }
        }

        public class AuthorInfoViewModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}