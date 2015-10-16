namespace Twitter.Data
{
    using System.Data.Entity;
    using Twitter.Data.Migrations;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Twitter.Models;


    public class TwitterContext : IdentityDbContext<User>, ITwitterContext
    {
        public TwitterContext()
            : base("Twitter", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TwitterContext, Configuration>());
        }

        public virtual IDbSet<Tweet> Tweets { get; set; }

        public static TwitterContext Create()
        {
            return new TwitterContext();
        }
    }
}
