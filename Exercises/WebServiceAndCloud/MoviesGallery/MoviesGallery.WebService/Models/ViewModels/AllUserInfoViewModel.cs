using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MoviesGallery.Models;
using WebServices.Models;

namespace MoviesGallery.WebService.Models.ViewModels
{
    public class AllUserInfoViewModel
    {
        public string Id { get; set; }

        public string PersonalPage { get; set; }

        public string Username { get; set; }

        public Gender Gender { get; set; }

        public DateTime? BirthDate { get; set; }

        public virtual ICollection<Movie> FavouMovies { get; set; }

        public virtual ICollection<Actor> FavouActor { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public static Expression<Func<ApplicationUser, AllUserInfoViewModel>> Create
        {
            get
            {
                return u => new AllUserInfoViewModel()
                {
                    
                    Id = u.Id,
                    Username = u.UserName,
                    BirthDate = (DateTime)u.BirthDate,
                    PersonalPage = u.PersonalPage,
                    Gender = u.Gender,
                    FavouMovies = u.FavouMovies,
                    FavouActor = u.FavouActor,
                    Reviews = u.Reviews
                };
            }
        }
    }
}