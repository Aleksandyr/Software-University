using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTracker.Data.Models;
using BugTracker.Data.Repository;
using Microsoft.AspNet.Identity;

namespace BugTracker.Data.UnitOfWork
{
    public interface IBugTrackerData
    {
        IRepository<User> Users { get; }

        IRepository<Bug> Bugs { get; }

        IRepository<Comment> Comments { get; }

        IUserStore<User> UserStore { get; }

        void SaveChanges();
    }
}
