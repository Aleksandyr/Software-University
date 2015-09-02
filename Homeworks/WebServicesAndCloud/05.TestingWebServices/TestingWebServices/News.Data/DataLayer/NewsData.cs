using System;
using System.Collections;
using System.Collections.Generic;
using News.Data.Repositories;
using News.Models;

namespace News.Data.DataLayer
{
    public class NewsData : INewsData
    {
        private readonly IDictionary<Type, object> repositories;

        public NewsData(NewsContext context)
        {
            this.Context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public NewsContext Context { get; set; }

        public IRepository<ApplicationUser> ApplicationUser
        {
            get { return this.GetRepository<ApplicationUser>(); }
        }

        public IRepository<Models.News> News
        {
            get { return this.GetRepository<Models.News>(); }
        }


        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class

        {
            var modelType = typeof (T);
            if (!this.repositories.ContainsKey(modelType))
            {
                var repositoryType = typeof (Repository<T>);
                this.repositories.Add(modelType, Activator.CreateInstance(repositoryType));
            }

            return (IRepository<T>) this.repositories[modelType];
        }
    }
}
