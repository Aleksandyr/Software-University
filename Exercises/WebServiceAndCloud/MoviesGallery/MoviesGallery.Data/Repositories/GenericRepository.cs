using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MoviesGallery.Data.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class 
    {
        public GenericRepository(MoviesGalleryContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected MoviesGalleryContext Context { get; set; }

        protected IDbSet<T> DbSet { get; set; } 
        
        public IQueryable<T> All()
        {
            return this.DbSet.AsQueryable();
        }

        public T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public void Add(T entity)
        { 
            this.ChangeState(entity, EntityState.Added);
            //this.DbSet.Add(entity);
            //return entity;
        }

        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
            //this.DbSet.AddOrUpdate(entity);
            //return entity;
        }

        public void Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
            //this.DbSet.Remove(entity);
            //return entity;
        }

        public T Delete(object id)
        {
            var entity = this.GetById(id);
            this.Delete(entity);
            return entity;
        }  


        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        public void ChangeState(T entity, EntityState state)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = state;
        }
    }
}
