namespace BankOfKurtovoKonare.Accounts
{
    using System;

    using BankOfKurtovoKonare.Enums;
    using BankOfKurtovoKonare.Interfaces;

    public class LoanAccount : BankAccount, IDepositable
    {
        public LoanAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public void DepositeMoney(decimal money)
        {
            this.Balance += money;
        }

        public override decimal CalculateInterestForGivenMonth(int months)
        {
            int monthsInterestFree = 0;

            switch (this.Customer)
            {
                case Customer.Individual:
                    monthsInterestFree = 3;
                    break;
                case Customer.Companie:
                    monthsInterestFree = 2;
                    break;
                default:
                    throw new NotImplementedException("There is no such case!");
            }

            if (months <= monthsInterestFree)
            {
                return 0;
            }

            months -= monthsInterestFree;
            decimal interestForPeriod = this.Balance * (1 + this.InterestRate * months);

            return interestForPeriod;
        } 
    }
}
