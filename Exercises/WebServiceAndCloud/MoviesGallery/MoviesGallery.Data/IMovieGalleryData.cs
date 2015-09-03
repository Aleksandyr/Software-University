using MoviesGallery.Data.Repositories;
using MoviesGallery.Models;
using WebServices.Models;

namespace MoviesGallery.Data
{
    public interface IMovieGalleryData
    {
        IRepository<ApplicationUser> User { get; }

        IRepository<Movie> Moveis { get; }

        IRepository<Genre> Geners { get; }

        IRepository<Actor> Actors { get; }

        IRepository<Review> Reviews { get; }

        int SaveChanges();
    }
}
