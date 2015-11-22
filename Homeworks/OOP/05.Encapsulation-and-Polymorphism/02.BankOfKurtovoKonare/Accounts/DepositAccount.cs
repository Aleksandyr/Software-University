namespace BankOfKurtovoKonare.Accounts
{
    using System;

    using BankOfKurtovoKonare.Enums;
    using BankOfKurtovoKonare.Interfaces;

    public class DepositAccount : BankAccount, IDepositable, IWithdrawable
    {
        public DepositAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public void WithdrawMoney(decimal money)
        {
            if (this.Balance < money)
            {
                throw new InvalidOperationException("I dont have enought money!");
            }

            this.Balance -= money;
        }

        public void DepositeMoney(decimal money)
        {
            this.Balance += money;
        }

        public override decimal CalculateInterestForGivenMonth(int months)
        {
            if (this.Balance < 1000)
            {
                return 0;
            }

            decimal interestForPeriod = this.Balance * (1 + this.InterestRate * months);

            return interestForPeriod;
        }
    }
}
