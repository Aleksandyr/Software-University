using System.Linq;

namespace OnlineShop.Data
{
    public interface IRepository<T>
    {
        IQueryable<T> All();

        T Fing(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
