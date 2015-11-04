namespace Bookmars.Data
{
    using Bookmarks.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BookmarksDbContext : IdentityDbContext<User>
    {
        public BookmarksDbContext()
            : base("Bookmarks", throwIfV1Schema: false)
        {
        }

        public static BookmarksDbContext Create()
        {
            return new BookmarksDbContext();
        }
    }
}
