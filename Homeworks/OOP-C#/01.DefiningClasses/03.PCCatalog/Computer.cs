using System;
using ComponentsInfo;

namespace PC
{
    class Computer
    {
        private string name;
        private double price;

        public Computer(string name, Component processor = null, Component ram = null,
            Component graphicCard = null, Component hdd = null, Component screen = null, double price = 0)
        {
            this.Name = name;
            this.Processor = processor;
            this.Ram = ram;
            this.GraphicCard = graphicCard;
            this.Hdd = hdd;
            this.Screen = screen;
            this.Price = price;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Model is null or empty");
                }

                this.name = value;
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
                double totalPrice = 0;
                if(this.Processor != null)
                    totalPrice += this.Processor.Price;
                if (this.Ram != null)
                    totalPrice += this.Processor.Price;
                if (this.GraphicCard != null)
                    totalPrice += this.GraphicCard.Price;
                if (this.Hdd != null)
                    totalPrice += this.Hdd.Price;
                if (this.Screen != null)
                    totalPrice += this.Screen.Price;
                if (this.price > 0)
                    totalPrice += this.price;

                this.price = totalPrice;
            }
        }

        public Component Processor { get; set; }

        public Component Ram { get; set; }

        public Component GraphicCard { get; set; }

        public Component Hdd { get; set; }

        public Component Screen { get; set; }

        public override string ToString()
        {
            string output = "";
            output += "Name: " + this.Name;
            
            if (this.Processor != null)
                output += "\nProcessor: \n" + this.Processor;
            if (this.Ram != null)
                output += "\nRam: \n" + this.Ram;
            if (this.GraphicCard != null)
                output += "\nGraphic Card: \n" + this.GraphicCard;
            if (this.Hdd != null)
                output += "\nHDD: \n" + this.Hdd;
            if (this.Screen != null)
                output += "\nScreen: \n" + this.Screen;

            output += "\nTotal Price: " + this.Price;
            Console.WriteLine();
            return output;
        }


    }
}
