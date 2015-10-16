namespace Twitter.Data.UnitOfWork
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Twitter.Data.Repository;
    using Twitter.Models;

    public interface ITwitterData
    {
        IRepository<User> Users { get; }

        IRepository<Tweet> Tweets { get; }

        int SaveChanges();
    }
}
