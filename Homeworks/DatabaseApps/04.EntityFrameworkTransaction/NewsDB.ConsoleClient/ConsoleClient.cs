using System;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using NewsDB.Data;
using NewsDB.Model;

namespace NewsDB.ConsoleClient
{
    class ConsoleClient
    {
        private const string SQL_CONNECTION_STRING = @"Server=(localdb)\v11.0; " +
        "Database=NewsDB; Integrated Security=true";
        static void Main()
        {
            var db = new NewsDBContext();
            var currNew = db.News.First(n => n.Id == 2);
            SqlConnection dbCon = new SqlConnection(SQL_CONNECTION_STRING);
            using (dbCon)
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    dbCon.Open();
                    try
                    {
                        Console.WriteLine("Application startde.");
                        Console.WriteLine("Text from DB: " + currNew.ContentNews);
                        Console.WriteLine("Enter the corrected text: ");
                        
                        string text = Console.ReadLine();
                        
                        SqlCommand cmd = dbCon.CreateCommand();
                        cmd.CommandText = "UPDATE News SET ContentNews = '" + text + "' WHERE Id = 2";
                        cmd.ExecuteNonQuery();

                        transaction.Complete();
                        Console.WriteLine("Changes successfully saved in the DB.");

                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("Exception occurred: {0}", e.Message);
                        Console.WriteLine("Transaction cancelled.");
                    }
                }
            }
        }
    }
}
