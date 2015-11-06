using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Snippets.Data.Migrations;
using Snippets.Models;

namespace Snippets.Data
{
    public class SnippetsDbContext : IdentityDbContext<User>, ISnippetsDbContext
    {
        public SnippetsDbContext()
            : base("Snippets", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SnippetsDbContext, Configuration>());
        }

        public virtual IDbSet<Snippet> Snippets { get; set; }

        public virtual IDbSet<Language> Languages { get; set; }

        public virtual IDbSet<Label> Labels { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public static SnippetsDbContext Create()
        {
            return new SnippetsDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.Snippets)
                .WithRequired(x => x.User)
                .WillCascadeOnDelete(false);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
