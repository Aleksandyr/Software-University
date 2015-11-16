namespace PcCatalog
{
    using Microsoft.Build.Framework;
    using System;

    public class Component
    {
        private string name;
        private string details;
        private decimal price;

         public Component(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

         public Component(string name, decimal price, string details = null)
            : this(name, price)
        {
            this.Details = details;
        }

        [Required]
        public string Name 
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this.name = value;
            }
        }

        [Required]
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

        public string Details
        {
            get
            {
                return this.details;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this.details = value;
            }
        }
    }
}
