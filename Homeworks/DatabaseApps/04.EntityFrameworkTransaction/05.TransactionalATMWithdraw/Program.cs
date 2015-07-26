using System;
using System.Linq;
using _04.ATMDatabase;

namespace _05.TransactionalATMWithdraw
{
    class Program
    {
        static void Main()
        {
            WithdrawMoney("7894789512", "1234", 500);

            //incorrect card Number
            //WithdrawMoney("123", "1234", 500);
            
            //More money than acc have
            //WithdrawMoney("7894787426", "1111", 500);
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
                db.SaveChanges();
                dbContextTransaction.Commit();

                Console.WriteLine("Transaction completed.");
            }
        }
    }
}
