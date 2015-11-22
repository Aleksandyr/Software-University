namespace BankOfKurtovoKonare
{
    using System;

    using BankOfKurtovoKonare.Accounts;
    using BankOfKurtovoKonare.Enums;

    public class Program
    {
        static void Main()
        {
            BankAccount Ivan = new DepositAccount(Customer.Individual, 975.34m, 5.3m);
            Console.WriteLine(Ivan.CalculateInterestForGivenMonth(12).ToString("f2"));
            Console.WriteLine();

            BankAccount Peter = new DepositAccount(Customer.Individual, 1637.94m, 1.3m);
            Console.WriteLine(Peter.CalculateInterestForGivenMonth(12).ToString("f2"));
            Console.WriteLine();

            BankAccount Misho = new MortgageAccount(Customer.Individual, 4457.23m, 7.3m);
            Console.WriteLine(Misho.CalculateInterestForGivenMonth(12).ToString("f2"));
            Console.WriteLine();
        }
    }
}
