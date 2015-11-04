namespace Bookmars.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Bookmars.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<BookmarksDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
            ContextKey = "BookmarksDbContext";
        }

        protected override void Seed(Bookmars.Data.BookmarksDbContext context)
        {
           
        }
    }
}
