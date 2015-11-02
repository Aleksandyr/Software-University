using Messages.Data.Models;
using Messages.Data.Repositories;
using Microsoft.AspNet.Identity;

namespace Messages.Data.UnitOfWork
{
    public interface IMessagesData 
    {
        IRepository<User> Users { get; }

        IRepository<Channel> Channels { get; }

        IRepository<ChannelMessage> ChannelMessages { get; }

        IRepository<UserMessage> UserMessages { get; }

        IUserStore<User> UserStore { get; }

        void SaveChanges();
    }
}
