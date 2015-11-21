namespace CompanyHierarchy
{
    using System;

    using CompanyHierarchy.Interfaces;
    using CompanyHierarchy.Enums;

    public class Customer : Person, ICustomer
    {
        private decimal netPurchaseAmount;

        protected Customer(int id, string firstName, string lastName, decimal netPurchaseAmount)
            : base (id, firstName, lastName)
        {
            this.NetPurchaseAmount = netPurchaseAmount;
        }

        public decimal NetPurchaseAmount
        {
            get
            {
                return this.netPurchaseAmount;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Amount cannot be negative!");
                }

                this.netPurchaseAmount = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("\nNet purchase amount: " + this.NetPurchaseAmount);
        }
    }
}
