using System.Data.Entity;
using Twitter.Models;

namespace Twitter.Data
{
    public interface ITwitterContext
    {
        IDbSet<Tweet> Tweets { get; set; }

        int SaveChanges();
    }
}
