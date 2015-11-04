using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarks.Models
{
    public class User : IdentityUser
    {
        private ICollection<Bookmark> bookmarks;

        public User()
        {
            this.bookmarks = new HashSet<Bookmark>();
        }

        public virtual ICollection<Bookmark> Bookmarks 
        { 
            get
            {
                return this.bookmarks;
            }
            set
            {
                this.bookmarks = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
