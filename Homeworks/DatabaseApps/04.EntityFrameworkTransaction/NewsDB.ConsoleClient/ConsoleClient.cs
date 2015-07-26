using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using NewsDB.Data;
using NewsDB.Model;

namespace NewsDB.ConsoleClient
{
    class ConsoleClient
    {
        static void Main()
        {
            var contextFirst = new NewsDBContext();
            var lastNewFirstUer =
                contextFirst.News.OrderByDescending(n => n.Id).First();

            var contextSecondUser = new NewsDBContext();
            var lastNewSecondUser =
                contextSecondUser.News.OrderByDescending(n => n.Id).First();

            Console.WriteLine("Application started.");

            Console.WriteLine();
            
            Console.WriteLine("First User.");
            Console.WriteLine("Text from DB: " + lastNewFirstUer.ContentNews);
            Console.Write("Enter the corrected text: ");
            
            string firstUserInput = Console.ReadLine();
            lastNewFirstUer.ContentNews = firstUserInput;

            contextFirst.SaveChanges();
            Console.WriteLine("Changes successfully saved in the DB.");

            Console.WriteLine("Second User.");
            Console.WriteLine("Text from DB: " + lastNewFirstUer.ContentNews);
            Console.Write("Enter the corrected text: ");

            string secondUserInput = Console.ReadLine();
            lastNewSecondUser.ContentNews = secondUserInput;

            try
            {
                contextSecondUser.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine("Conflict! Text from DB: " + lastNewFirstUer.ContentNews);
                Console.WriteLine("Enter the corrected text: ");

                string textAfterConflict = Console.ReadLine();

                var newContext = new NewsDBContext();
                var currNew =
                contextSecondUser.News.OrderByDescending(n => n.Id).First();
                currNew.ContentNews = textAfterConflict;
            }
            Console.WriteLine("Changes successfully saved in the DB.");
               
        }

        public static void FirstWins()
        {
            
        }
    }
}
