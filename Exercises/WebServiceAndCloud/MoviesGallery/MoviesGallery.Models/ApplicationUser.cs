using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MoviesGallery.Models;

namespace WebServices.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string PersonalPage { get; set; }

        public string Gender { get; set; }

        public DateTime? BirthDate { get; set; }

        public virtual ICollection<Movie> FavouMovies { get; set; }

        public virtual ICollection<Actor> FavouActor { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            return userIdentity;
        }
    }
}