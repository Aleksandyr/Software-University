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
using MoviesGallery.Data;
using MoviesGallery.Models;
using MoviesGallery.WebService.Models.BindingModels;
using MoviesGallery.WebService.Models.ViewModels;
using WebServices.Models;

namespace MoviesGallery.WebService.Controllers
{
    public class UsersController : BaseApiController
    {
        // GET: api/Users
        public IHttpActionResult GetAllUsers()
        {
            var users = this.Data.User.All()
                .Select(UserViewModel.Create);

            return this.Ok(users);
        }

        // GET: api/Users/5
        [ResponseType(typeof(ApplicationUser))]
        public IHttpActionResult GetApplicationUser(string id)
        {
            var user = this.Data.User.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            var userView = new AllUserInfoViewModel()
            {
                Id = user.Id,
                Username = user.UserName,
                BirthDate = user.BirthDate,
                PersonalPage = user.PersonalPage,
                FavouMovies = user.FavouMovies,
                FavouActor = user.FavouActor,
                Reviews = user.Reviews,
            };

            return Ok(userView);
        }

        // GET: api/Users/male
        [Route("api/Users/{gender}/gender")]
        public IHttpActionResult GetUsersByGender(int gender)
        {
            var users = this.Data.User.All().Where(u => u.Gender == (Gender)gender)
                .Select(UserViewModel.Create);

            return this.Ok(users);
        }
    }
}