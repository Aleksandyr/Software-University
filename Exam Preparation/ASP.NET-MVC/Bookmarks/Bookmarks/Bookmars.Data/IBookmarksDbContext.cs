namespace Bookmars.Data
{
    using Bookmarks.Models;
    using System.Data.Entity;

    public interface IBookmarksDbContext
    {
        IDbSet<Bookmark> Bookmarks { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Vote> Votes { get; set; }

        int SaveChanges();
    }
}
