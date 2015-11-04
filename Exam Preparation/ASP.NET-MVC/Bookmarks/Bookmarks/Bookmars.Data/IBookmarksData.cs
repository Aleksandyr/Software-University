namespace Bookmars.Data
{
    using Bookmarks.Models;
    using Bookmars.Data.Repository;

    public interface IBookmarksData
    {
        IRepository<User> Users { get; }

        IRepository<Category> Categories { get; }

        IRepository<Bookmark> Bookmarks { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Vote> Votes { get; }

        int SaveChanges();
    }
}
