using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Twitter.Data.Repository;
using Twitter.Models;

namespace Twitter.Data.UnitOfWork
{
    public class TwitterData : ITwitterData
    {
        private readonly ITwitterContext context;

        private readonly IDictionary<Type, object> repositories;

        public TwitterData()
            :this(new TwitterContext())
        {
            
        }

        public TwitterData(ITwitterContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }
        public IRepository<Tweet> Tweets
        {
            get
            {
                return this.GetRepository<Tweet>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(EfRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
