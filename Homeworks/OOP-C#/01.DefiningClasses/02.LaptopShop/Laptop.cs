using System;
using BatteryInfo;
using System.Text;

namespace LaptopInfo
{
    class Laptop
    {
        private string model;
        private string manufacturer;
        private string processor;
        private int ram;
        private string graphicsCard;
        private int hdd;
        private string screen;
        private double price;
        private Battery battery;

        public Laptop(string model,double price, int ram, int hdd, Battery battery = null, string manufacturer = null, string processor = null, string graphicCard = null,
            string screen = null) : this(model, price)
        {
            this.Manufacturer = manufacturer;
            this.Processor = processor;
            this.Ram = ram;
            this.GraphicsCard = graphicCard;
            this.Hdd = hdd;
            this.Screen = screen;
            this.Battery = battery;
        }

        public Laptop(string model, double price)
        {
            this.Model = model;
            this.Price = price;
        }

        public Laptop()
        {

        }

        public string  Model
        { 
            get
            {
                return this.model;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Model is null or empty");
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
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Model is null or empty");
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
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Model is null or empty");
                }

                this.processor = value;
            }
        }

        public int Ram
        {
            get
            {
                return this.ram;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Ram can not be negative!");
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
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Graphic card can not be empty or null!");
                }

                this.graphicsCard = value;
            }
        }

        public int Hdd
        {
            get
            {
                return this.hdd;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hdd can not be negative!");
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
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Graphic card can not be empty or null!");
                }

                this.screen = value;
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
                    throw new ArgumentException("Price can not be negative!");
                }

                this.price = value;
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Modle: " + model);

            if (this.Manufacturer != null)
            {
                sb.AppendLine("Manufacturer: " + this.Manufacturer);
            }
            if (this.Processor != null)
            {
                sb.AppendLine("Processor : " + this.Processor);
            }
     
            sb.AppendLine("Ram: " + this.Ram);
            sb.AppendLine("Hdd: " + this.Hdd);
            
            if (this.Screen != null)
            {
                sb.AppendLine("Screen: " + this.Screen);
            }
            if (this.Battery != null)
            {
                sb.Append(this.Battery.ToString());
            }
            
            sb.AppendLine("Price: " + this.Price);

            return sb.ToString();
        }

    }
}
