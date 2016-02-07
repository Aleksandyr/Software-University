namespace BigMani.Models
{
    using System;

    using BigMani.Exceptions;
    using BigMani.Infrastructure;

    public class StationaryAirConditioners : AirConditionar
    {
        private int powerUsage;

        public StationaryAirConditioners(string manufacturer, string model, string energyRating, int powerUsage)
            : base(manufacturer, model)
        {
            this.EnergyRating = this.CheckEnergyEfficiency(energyRating);
            this.PowerUsage = powerUsage;
        }

        public int PowerUsage
        {
            get
            {
                return this.powerUsage;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ValidationConstants.NONPOSITIVE, "Power Usage"));
                }

                this.powerUsage = value;
            }
        }

        public override int Test()
        {
            if (this.PowerUsage / 100 <= this.EnergyRating)
            {
                return 1;
            }

            return 0;
        }

        public int CheckEnergyEfficiency(string ennergyEfficiencyRating)
        {
            switch (ennergyEfficiencyRating)
            {
                case "A":
                    return 10;

                case "B":
                    return 12;

                case "C":
                    return 15;

                case "D":
                    return 20;

                case "E":
                    return 90;
                default:
                    throw new ArgumentException("Energy efficiency rating must be between \"A\" and \"E\".");
            }
        }

        public override string ToString()
        {
            string print = base.ToString();

            print += "Required energy efficiency rating: " + this.EnergyRating;

            print += "Power Usage(KW / h): " + this.PowerUsage;

            print += "====================";

            return print.ToString();
        }
    }
}
