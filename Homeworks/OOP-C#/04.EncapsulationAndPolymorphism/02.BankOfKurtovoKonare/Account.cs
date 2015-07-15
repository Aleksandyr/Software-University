using System.CodeDom;

namespace Accounts
{
    using BankOfKurtovoKonare.Enums;
    using System;


    public abstract class Account
    {
        private Customer customer;
        private decimal balance;
        private double monthlyRate;

        protected Account(Customer customer, decimal balance, double rate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.MonthlyRate = rate;
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
                    throw new ArgumentOutOfRangeException("Balance can not be negative!");
                }

                this.balance = value;
            }
        }

        public double MonthlyRate
        {
            get
            {
                return this.monthlyRate;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Monthly rate can not be negative!");
                }

                this.monthlyRate = value;
            }
        }

        public abstract decimal InterestForGivenPeriod(int months);
    }
}
