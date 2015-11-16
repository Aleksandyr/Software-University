namespace LaptopShops
{
    using System;
    using Microsoft.Build.Framework;
    using System.Text;

    class Laptop
    {
        private string model;
        private string manufacturer;
        private string processor;
        private int? ram;
        private string graphicsCard;
        private string hdd;
        private string screen;
        private Battery battery;
        private float batteryLife;
        private decimal price;

        public Laptop(string model, decimal price)
        {
            this.Model = model;
            this.Price = price;
        }

        public Laptop(string model, decimal price, string manufacturer = null, 
            string processor = null, int? ram = null, string graphicsCard = null, 
            string hdd = null,  Battery battery = null, string screen = null)
            : this(model, price)
        {
            this.Manufacturer = manufacturer;
            this.Processor = processor;
            this.Ram = ram;
            this.GraphicsCard = graphicsCard;
            this.Hdd = hdd;
            this.screen = screen;
            this.Battery = battery;
        }

        [Required]
        public string Model 
        { 
            get 
            {
                return this.model;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this.manufacturer = value;
            }
        }

        public string Processor
        {
            get
            {
                return this.processor;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this.processor = value;
            }
        }

        public int? Ram
        {
            get
            {
                return this.ram;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Ram cannot be negative!");
                }

                this.ram = value;
            }
        }

        public string GraphicsCard
        {
            get
            {
                return this.graphicsCard;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this.graphicsCard = value;
            }
        }

        public string Hdd
        {
            get
            {
                return this.hdd;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this.hdd = value;
            }
        }

        public string Screen
        {
            get
            {
                return this.screen;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this.screen = value;
            }
        }

        public Battery Battery
        {
            get
            {
                return this.battery;
            }
            set
            {
                this.battery = value;
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
                    throw new InvalidOperationException("Price cannot be negative!");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("model: " + this.Model);
            
            if (this.Manufacturer != null)
	        {
		        sb.AppendLine("manufacturer: " + this.Manufacturer);
	        }

            if (this.Processor != null)
            {
                sb.AppendLine("processor: " + this.Processor);
            }

            if (this.Ram != null)
            {
                sb.AppendLine("ram: " + this.Ram + "GB");
            }

            if (this.GraphicsCard != null)
            {
                sb.AppendLine("graphics card: " + this.GraphicsCard);
            }

            if (this.Hdd != null)
            {
                sb.AppendLine("hdd: " + this.Hdd);
            }

            if (this.Screen != null)
            {
                sb.AppendLine("screen: " + this.Screen);
            }

            if (this.Battery != null)
            {
                sb.AppendLine(this.Battery.ToString());
            }

            sb.AppendLine("price: " + this.Price + "lv.");

            return sb.ToString();
        }
    }
}
