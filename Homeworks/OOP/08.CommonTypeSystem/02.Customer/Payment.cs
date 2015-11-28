namespace Customer
{
    using System;

    public class Payment
    {
        public Payment(string productName, decimal price)
        {
            this.ProductName = productName;
            this.Price = price;
        }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return String.Format("(Product name: {0}, Price: {1})", this.ProductName, this.Price);
        }
    }
}
