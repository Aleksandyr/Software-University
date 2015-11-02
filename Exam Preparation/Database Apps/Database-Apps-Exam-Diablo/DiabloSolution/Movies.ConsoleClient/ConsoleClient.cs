using System;
using System.Linq;
using Movies.Data;

namespace Movies.ConsoleClient
{
    class ConsoleClient
    {
        static void Main()
        {
            var db = new MoviesEntities();
            Console.WriteLine(db.Users.Count());
        }
    }
}
