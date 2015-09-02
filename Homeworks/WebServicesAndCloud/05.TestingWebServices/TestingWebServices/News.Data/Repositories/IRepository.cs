using System;
using System.Linq;
using System.Linq.Expressions;

namespace News.Data.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> All();

        IQueryable<T> Find(Expression<Func<T, bool>> expression);

        T GetById(object id);

        T Add(T entity);

        T Update(T entity);

        void Delete(T entity);

        void SaveChanges();
    }
}
