﻿namespace Twitter.Data.Repository
{
    using System.Data.Entity;
    using System.Linq;

    public class EfRepository<T> : IRepository<T>
        where T : class
    {
        private readonly DbContext context;
        private readonly IDbSet<T> set;

        public EfRepository()
            : this(new TwitterContext())
        {
        }

        public EfRepository(DbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public IQueryable<T> All()
        {
            return this.set;
        }

        public T Find(object id)
        {
            return this.set.Find(id);
        }

        public void Add(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Deleted);
        }

        public T Delete(object id)
        {
            var entity = this.Find(id);
            this.Delete(entity);
            return entity;
        }

        private void ChangeEntityState(T entity, EntityState state)
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
