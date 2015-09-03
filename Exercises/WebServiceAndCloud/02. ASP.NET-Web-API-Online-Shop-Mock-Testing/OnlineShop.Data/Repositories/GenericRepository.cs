using System.Linq;
using System.Data.Entity;

namespace OnlineShop.Data
{
    public class GenericRepository<T> : IRepository<T>
        where T : class
    {
        protected DbContext context;
        private DbSet<T> set;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public IQueryable<T> All()
        {
            return this.set.AsQueryable();
        }

        public void Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public T Fing(object id)
        {
            return this.set.Find(id);
        }

        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }
    }
}
