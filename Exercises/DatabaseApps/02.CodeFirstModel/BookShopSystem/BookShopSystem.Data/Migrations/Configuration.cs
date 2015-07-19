namespace BookShopSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookShopSystem.Data.BookShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
            ContextKey = "BookShopSystem.Data.BookShopContext";
        }

        protected override void Seed(BookShopSystem.Data.BookShopContext context)
        {
            
        }
    }
}
