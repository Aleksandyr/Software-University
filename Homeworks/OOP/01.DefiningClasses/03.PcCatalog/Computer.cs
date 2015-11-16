namespace PcCatalog
{
    using Microsoft.Build.Framework;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Computer
    {
        private string name;
        private List<Component> components;
        private decimal price;

        public Computer(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
            this.Components = new List<Component>();
        }

        public Computer(string name, decimal price, List<Component> components)
            : this(name, price)
        {
            this.Components = components;
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

        public List<Component> Components
        {
            get
            {
                return this.components;
            }
            set
            {
                this.components = value;
            }
        }

        private decimal calcAllPrice()
        {
            decimal sum = this.Price;
            foreach (var component in this.Components)
            {
                sum += component.Price;
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("Name: " + this.Name);
            sb.AppendLine("Price: " + this.Price);

            if (this.Components.Count > 0)
            {
                foreach (var component in this.Components)
                {
                    sb.AppendLine(component.Name + ": " + component.Price);
                }
            }

            sb.AppendLine("All price: " + this.calcAllPrice() + "lv.");

            return sb.ToString();
        }
    }
}
