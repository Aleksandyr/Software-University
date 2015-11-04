namespace Bookmars.Data
{
    using Bookmarks.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using Bookmars.Data.Migrations;

    public class BookmarksDbContext : IdentityDbContext<User>, IBookmarksDbContext
    {
        public BookmarksDbContext()
            : base("Bookmarks", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookmarksDbContext, Configuration>());
        }

        public virtual IDbSet<Category> Categories { get; set; }
        
        public virtual IDbSet<Bookmark> Bookmarks { get; set; }
        
        public virtual IDbSet<Comment> Comments { get; set; }
        
        public virtual IDbSet<Vote> Votes { get; set; }


        public static BookmarksDbContext Create()
        {
            return new BookmarksDbContext();
        }
    }
}
