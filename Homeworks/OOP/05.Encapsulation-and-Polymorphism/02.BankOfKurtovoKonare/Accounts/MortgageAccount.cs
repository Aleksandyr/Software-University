namespace BankOfKurtovoKonare.Accounts
{
    using System;

    using BankOfKurtovoKonare.Enums;
    using BankOfKurtovoKonare.Interfaces;

    public class MortgageAccount : BankAccount, IDepositable
    {
        public MortgageAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        
        public void DepositeMoney(decimal money)
        {
            this.Balance += money;
        }

        public override decimal CalculateInterestForGivenMonth(int months)
        {
            int halfInterestMonths = 0;

            switch (this.Customer)
            {
                case Customer.Individual:
                    halfInterestMonths = 6;
                    break;
                case Customer.Companie:
                    halfInterestMonths = 12;
                    break;
                default:
                    throw new NotImplementedException("There is no such case!");
            }

            var fullInterestMonths = months - halfInterestMonths;
            decimal interestForPeriod = 0;

            if (fullInterestMonths <= 0)
            {
                interestForPeriod = (this.Balance * (1 + this.InterestRate * halfInterestMonths)) / 2;
            }
            else
            {
                interestForPeriod += this.Balance * (1 + this.InterestRate * fullInterestMonths);
            }

            return interestForPeriod;
        }
    }
}
