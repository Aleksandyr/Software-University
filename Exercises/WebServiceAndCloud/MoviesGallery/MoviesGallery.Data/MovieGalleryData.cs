using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using MoviesGallery.Data.Repositories;
using MoviesGallery.Models;
using WebServices.Models;

namespace MoviesGallery.Data
{
    public class MovieGalleryData : IMovieGalleryData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public MovieGalleryData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> User
        {
            get { return this.GetRepository<ApplicationUser>(); }
        }

        public IRepository<Movie> Moveis
        {
            get { return this.GetRepository<Movie>(); }
        }

        public IRepository<Genere> Geners
        {
            get { return this.GetRepository<Genere>(); }
        }

        public IRepository<Actor> Actors
        {
            get { return this.GetRepository<Actor>(); }
        }

        public IRepository<Review> Reviews
        {
            get { return this.GetRepository<Review>(); }
        }
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }


        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof (T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof (GenericRepository<T>);
                var repository = Activator.CreateInstance(typeOfRepository, this.context);

                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
