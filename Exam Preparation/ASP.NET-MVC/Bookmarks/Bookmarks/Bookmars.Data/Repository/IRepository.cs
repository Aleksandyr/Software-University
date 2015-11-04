namespace Bookmars.Data.Repository
{
    using System.Linq;

    public interface IRepository<T>
    {
        IQueryable<T> All();

        T Find(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        T Delete(object id);
    }
}
