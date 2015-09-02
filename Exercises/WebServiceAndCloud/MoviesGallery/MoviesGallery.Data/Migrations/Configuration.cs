namespace MoviesGallery.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MoviesGallery.Data.MoviesGalleryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
            ContextKey = "MoviesGallery.Data.MoviesGalleryContext";
        }

        protected override void Seed(MoviesGallery.Data.MoviesGalleryContext context)
        {

        }
    }
}
