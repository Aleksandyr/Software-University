using System;
namespace Snippets.Data
{
    using Snippets.Data.Repositories;
    using Snippets.Models;

    public interface ISnippetsData
    {
        IRepository<User> Users { get; }

        IRepository<Snippet> Snippets { get; }

        IRepository<Language> Languages { get; }

        IRepository<Label> Labels { get; }

        IRepository<Comment> Comments { get; }

        int SaveChanges();
    }
}
