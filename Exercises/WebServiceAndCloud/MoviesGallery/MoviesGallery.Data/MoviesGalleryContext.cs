using Microsoft.AspNet.Identity.EntityFramework;
using MoviesGallery.Data.Migrations;
using MoviesGallery.Models;
using WebServices.Models;

namespace MoviesGallery.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MoviesGalleryContext : IdentityDbContext<ApplicationUser>
    {
        public MoviesGalleryContext()
            : base("MoviesGalleryContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MoviesGalleryContext, Configuration>());
        }

        public virtual DbSet<Actor> Actors{ get; set; }

        public virtual DbSet<Genere> Generes{ get; set; }

        public virtual DbSet<Movie> Movies{ get; set; }

        public virtual DbSet<Review> Reviews{ get; set; }

        public static MoviesGalleryContext Create()
        {
            return new MoviesGalleryContext();
        }
    }
}