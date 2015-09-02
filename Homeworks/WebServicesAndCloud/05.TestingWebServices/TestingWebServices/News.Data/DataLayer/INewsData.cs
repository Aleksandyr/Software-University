using News.Data.Repositories;
using News.Models;

namespace News.Data.DataLayer
{
    public interface INewsData
    {
        IRepository<ApplicationUser> ApplicationUser { get; }

        IRepository<Models.News> News { get; }

        int SaveChanges();
    }
}
