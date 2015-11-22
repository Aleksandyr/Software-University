namespace BankOfKurtovoKonare.Accounts
{
    using System;

    using BankOfKurtovoKonare.Enums;
    using BankOfKurtovoKonare.Interfaces;

    public abstract class BankAccount : IBankAccount
    {
        private Customer customer;
        private decimal balance;
        private decimal interestRate;

        protected BankAccount(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public Customer Customer
        {
            get
            {
                return this.customer;
            }
            set
            {
                this.customer = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Balance cannot be negative!");
                }

                this.balance = value;
            }
        }

        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Interest rate cannot be negative!");
                }

                this.interestRate = value;
            }
        }

        public abstract decimal CalculateInterestForGivenMonth(int months);
    }
}
