using System.Runtime.InteropServices;
using BankOfKurtovoKonare.Accounts;
using BankOfKurtovoKonare.Enums;

namespace BankOfKurtovoKonare
{
    using _02.BankOfKurtovoKonare.Accounts;
    using System;


    class Program
    {
        static void Main()
        {
            Loan loanAcc = new Loan(Customer.Individual, 200, 0.1);
            Console.WriteLine(loanAcc.InterestForGivenPeriod(4));

            Deposite depAcc = new Deposite(Customer.Company, 200, 0.1);
            depAcc.WithdrawMoney(100);
            Console.WriteLine(depAcc.InterestForGivenPeriod(1));
            Console.WriteLine(depAcc.Balance);

            Mortgage mortgageAcc = new Mortgage(Customer.Individual, 200, 0.1);
            Console.WriteLine(mortgageAcc.InterestForGivenPeriod(7));
        }
    }
}
