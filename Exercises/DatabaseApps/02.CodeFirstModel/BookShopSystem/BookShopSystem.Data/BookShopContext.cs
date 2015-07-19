namespace BookShopSystem.Data
{
    using BookShopSystem.Data.Migrations;
    using BookShopSystem.Model;
    using System.Data.Entity;

    public class BookShopContext : DbContext
    {
        public BookShopContext()
            : base("BookShopContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookShopContext, Configuration>());
        }

        public IDbSet<Book> Books { get; set; }
        public IDbSet<Author> Authors { get; set; }
        public IDbSet<Category> Categories { get; set; }
    }
}