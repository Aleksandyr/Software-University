using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;

namespace MoviesGallery.Data.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> All();

        T GetById(T id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void ChangeState(T entity, EntityState state);

        int SaveChanges();
    }
}
