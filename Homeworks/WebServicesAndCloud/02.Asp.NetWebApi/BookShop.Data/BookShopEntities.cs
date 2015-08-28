using BookShop.Data.Migrations;
using BookShop.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookShop.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BookShopEntities : IdentityDbContext<ApplicationUser>
    {
       
        public BookShopEntities()
            : base("BookShopEntities")
        {
            Database.SetInitializer(new DBInitializer());
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }

        public static BookShopEntities Create()
        {
            return new BookShopEntities();
        }
    }
}