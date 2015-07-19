using System.Data.Entity;

namespace BookShopSystem.ConsoleClient
{
    using System.Linq;
    using BookShopSystem.Data;

    class ConsoleClient
    {
        static void Main()
        {
            
            var db = new BookShopContext();

            var bookCount = db.Books.Count();
        }
    }
}
