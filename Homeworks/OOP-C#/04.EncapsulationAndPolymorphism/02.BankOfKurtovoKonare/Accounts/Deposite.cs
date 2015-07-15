using Accounts;
using BankOfKurtovoKonare.Interfaces;
using _02.BankOfKurtovoKonare.Accounts;

namespace BankOfKurtovoKonare.Accounts
{
    using System;
    using BankOfKurtovoKonare.Enums;


    class Deposite : Account, IDepositable, IWithdrawable
    {
        public Deposite(Customer customer, decimal balance, double rate)
            : base(customer, balance, rate)
        {
        }

        public void DepositeMoney(decimal money)
        {
            this.Balance += money;
        }

        public void WithdrawMoney(decimal money)
        {
            if (!(this.Balance > money))
            {
                throw new ArgumentException("You dont have enough money!");
            }

            this.Balance -= money;
        }

        public override decimal InterestForGivenPeriod(int months)
        {
            if (this.Balance < 1000)
            {
                return 0;
            }

            return this.Balance * (1 + (decimal)this.MonthlyRate * months);
        }
    }
}
