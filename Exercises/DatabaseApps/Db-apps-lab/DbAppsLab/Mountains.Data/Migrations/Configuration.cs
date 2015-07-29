namespace Mountains.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Mountains.Data.MountainsEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Mountains.Data.MountainsEntities";
        }

        protected override void Seed(Mountains.Data.MountainsEntities context)
        {
           
        }
    }
}
