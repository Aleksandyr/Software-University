using Movies.Data.Migrations;
using Movies.Models;

namespace Movies.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Movies.Data.Migrations;

    public class MoviesEntities : DbContext
    {
        public MoviesEntities()
            : base("name=MoviesEntities")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MoviesEntities, Configuration>());
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Rating>().HasMany(r => r.Users).WithRequired(u => u.)
            //.Map(m =>
            //{
            //    m.MapKey("UserId");
            //});

            //modelBuilder.Entity<Rating>().HasMany(r => r.Movies)
            //  .WithOptional(p => p.Rating)
            //  .Map(m =>
            //  {
            //      m.MapKey("MovieId");
            //  });

            base.OnModelCreating(modelBuilder);
        }
    }
}