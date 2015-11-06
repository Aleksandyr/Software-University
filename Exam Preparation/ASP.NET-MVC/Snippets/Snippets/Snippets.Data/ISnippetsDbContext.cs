using System.Data.Entity;
using Snippets.Models;

namespace Snippets.Data
{
    public interface ISnippetsDbContext
    {
        IDbSet<Snippet> Snippets { get; set; }

        IDbSet<Language> Languages { get; set; }

        IDbSet<Label> Labels { get; set; }

        IDbSet<Comment> Comments { get; set; }

        int SaveChanges();
    }
}
