using Microsoft.AspNet.Identity.EntityFramework;
using News.Data.Migrations;
using News.Models;

namespace News.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class NewsContext : IdentityDbContext<ApplicationUser>

    {
        public NewsContext()
            : base("NewsContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsContext, Configuration>());
        }
        
        public virtual DbSet<Models.News> News { get; set; }

        public static NewsContext Create()
        {
            return new NewsContext();
        }
    }
}