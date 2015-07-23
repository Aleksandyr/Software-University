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
            
            //var currNew = db.News.First(n => n.Id == 2);
            //SqlConnection dbCon = new SqlConnection(SQL_CONNECTION_STRING);
            //using (dbCon)
            //{
            //    using (TransactionScope transaction = new TransactionScope())
            //    {
            //        dbCon.Open();
            //        try
            //        {
            //            Console.WriteLine("Application startde.");
            //            Console.WriteLine("Text from DB: " + currNew.ContentNews);
            //            Console.WriteLine("Enter the corrected text: ");
                        
            //            string text = Console.ReadLine();
                        
            //            SqlCommand cmd = dbCon.CreateCommand();
            //            cmd.CommandText = "UPDATE News SET ContentNews = '" + text + "' WHERE Id = 2";
            //            cmd.ExecuteNonQuery();

            //            transaction.Complete();
            //            Console.WriteLine("Changes successfully saved in the DB.");

            //        }
            //        catch (SqlException e)
            //        {
            //            Console.WriteLine("Exception occurred: {0}", e.Message);
            //            Console.WriteLine("Transaction cancelled.");
            //        }
            //    }
            
            FirstWins();

           
        }

        public static void FirstWins()
        {
            var contextFirst = new NewsDBContext();
            var lastNewFirstUer =
                contextFirst.News.OrderByDescending(n => n.Id).First();
            lastNewFirstUer.ContentNews = "Changed by the First User";

            // The second user changes the same record
            var contextSecondUser = new NewsDBContext();
            var lastNewSecondUser =
                contextSecondUser.News.OrderByDescending(n => n.Id).First();
            lastNewSecondUser.ContentNews = "Changed by the Second User";

            // Conflicting changes: first wins; second gets an exception
            contextFirst.SaveChanges();
            try
            {
                contextSecondUser.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine("Error: concurrent change occurred.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
