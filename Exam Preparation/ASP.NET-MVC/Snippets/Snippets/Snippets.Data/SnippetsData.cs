using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snippets.Data.Repositories;
using Snippets.Models;

namespace Snippets.Data
{
    public class SnippetsData : ISnippetsData
    {
        private ISnippetsDbContext context;
        private IDictionary<Type, object> repositories;

        public SnippetsData(ISnippetsDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Snippet> Snippets
        {
            get { return this.GetRepository<Snippet>(); }
        }

        public IRepository<Language> Languages
        {
            get { return this.GetRepository<Language>(); }
        }


        public IRepository<Label> Labels
        {
            get { return this.GetRepository<Label>(); }
        }

        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }


        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);

                var repository = Activator.CreateInstance(typeOfRepository, this.context);
                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
