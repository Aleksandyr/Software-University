namespace CompanyHierarchy
{
    using System;

    using CompanyHierarchy.Interfaces;
    using System.Text;

    public class Sale : ISale
    {
        private string productName;
        private DateTime date;
        private decimal price;

        public Sale(string productName, DateTime date, decimal price)
        {
            this.ProductName = productName;
            this.Date = date;
            this.Price = price;
        }

        public string ProductName
        {
            get
            {
                return this.productName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Product cannot be null or empty!");
                }

                this.productName = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Date cannot be null");
                }

                this.date = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative!");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("Product name: " + this.ProductName);
            sb.AppendLine("Date: " + this.Date);
            sb.AppendLine("Price: " + this.Price);
            
            return sb.ToString();
        }
    }
}
