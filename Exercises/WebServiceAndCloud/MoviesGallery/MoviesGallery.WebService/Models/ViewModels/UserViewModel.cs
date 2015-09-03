using System;
using System.Linq.Expressions;
using Microsoft.Ajax.Utilities;
using WebServices.Models;

namespace MoviesGallery.WebService.Models.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public DateTime BirthData { get; set; }

        public string PerosnalPage { get; set; }

        public static Expression<Func<ApplicationUser, UserViewModel>> Create
        {
            get
            {
                return u => new UserViewModel()
                {
                    Id = u.Id,
                    Username = u.UserName,
                    BirthData = (DateTime) u.BirthDate,
                    PerosnalPage = u.PersonalPage,
                };
            }
        }
    }
}