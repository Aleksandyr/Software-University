using NewsDB.Data.Migrations;
using NewsDB.Model;

namespace NewsDB.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class NewsDBContext : DbContext
    {
        public NewsDBContext()
            : base("name=NewsDBContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsDBContext, Configuration>());
        }

        public IDbSet<New> News { get; set; }
    }
}