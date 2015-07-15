using Accounts;
using BankOfKurtovoKonare.Enums;
using BankOfKurtovoKonare.Interfaces;

namespace _02.BankOfKurtovoKonare.Accounts
{

    class Mortgage : Account, IDepositable
    {
        public Mortgage(Customer customer, decimal balance, double rate)
            : base(customer, balance, rate)
        {
        }

        public void DepositeMoney(decimal money)
        {
            this.Balance += money;
        }

        public override decimal InterestForGivenPeriod(int months)
        {
            if (months <= 12 && this.Customer == Customer.Company)
            {
                return (this.Balance * (1 + (decimal)(this.MonthlyRate / 2) * months));
            }
            else if (months <= 6 && this.Customer == Customer.Individual)
            {
                return 0;
            }

            return this.Balance * (1 + (decimal)this.MonthlyRate * months);
        }
    }
}
