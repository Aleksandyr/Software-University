using System;
using System.Linq;
using _04.ATMDatabase;

namespace _06.ATMTransactionHistory
{
    class Program
    {
        static void Main()
        {
            WithdrawMoney("7894789512", "1234", 500);
        }
        public static void WithdrawMoney(string cardNumber, string cardPin, int money)
        {
            var db = new ATMEntities();
            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                var currCard = db.CardAccounts.FirstOrDefault(c => c.CardNumber == cardNumber && c.CardPIN == cardPin);

                if (currCard == null)
                {
                    dbContextTransaction.Rollback();
                    throw new ArgumentException("There are no card in database");
                }

                if (currCard.CardCash < money)
                {
                    dbContextTransaction.Rollback();
                    throw new InvalidOperationException("You don't have enough monye!");
                }

                currCard.CardCash -= money;

                db.TransactionHistories.Add(new TransactionHistory()
                {
                    CardName = cardNumber,
                    Amount = money,
                    TransactionDate = DateTime.Now
                });

                db.SaveChanges();
                dbContextTransaction.Commit();

                Console.WriteLine("Transaction completed.");
            }
        }
    }
}
