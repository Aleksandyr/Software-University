namespace _03.CompanyHierarchy
{
    using PersonInfo;
    using System;


    class Customer : Person
    {
        private decimal netPurchesAmount;
        
        protected Customer(string firstName, string lastName, int id)
            : base(firstName, lastName, id)
        {
        }

        public decimal NetPurchesAmount 
        { 
            get
            {
                return this.netPurchesAmount;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Amount can not be negative!");
                }

                this.netPurchesAmount = value;
            }
        }
    }
}
