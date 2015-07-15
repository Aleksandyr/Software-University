using System.Runtime.CompilerServices;
using Accounts;
using BankOfKurtovoKonare.Interfaces;
using BankOfKurtovoKonare.Enums;

namespace _02.BankOfKurtovoKonare.Accounts
{
    using System;


    class Loan : Account, IDepositable
    {
        public Loan(Customer customer, decimal balance, double rate)
            : base(customer, balance, rate)
        {
        }

        public void DepositeMoney(decimal money)
        {
            this.Balance += money;
        }

        public override decimal InterestForGivenPeriod(int months)
        {
            if ((months <= 3 && this.Customer == Customer.Individual) ||
                (months <= 2 && this.Customer == Customer.Company))
            {
                return 0; 
            }
            return (this.Balance * (1 + (decimal)this.MonthlyRate * months));
        }
    }
}
