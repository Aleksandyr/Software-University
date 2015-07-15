using System;

namespace ComponentsInfo
{
    class Component
    {
        private string name;
        private string details;
        private double price;

        public Component(string name, double price, string details = null)
        {
            this.Name = name;
            this.Details = details;
            this.Price = price;
        }

        public string  Name 
        { 
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name can not be null or empty!");
                }

                this.name = value;
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
                this.details = value;
            }
        }

        public double Price 
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price can not be negative!");
                }

                this.price = value;
            } 
        }

        public override string ToString()
        {
            return String.Format("Component Name:{0} \nComponent Details: {1} \nComponent Price:{2}", this.Name, this.Details ?? "No details",
                this.Price);
        }
    }
}
