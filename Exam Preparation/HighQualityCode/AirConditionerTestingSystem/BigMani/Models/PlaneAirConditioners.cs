namespace BigMani.Models
{
    using System;

    using BigMani.Exceptions;
    using BigMani.Infrastructure;

    public class PlaneAirConditioners : AirConditionar
    {
        private int volumeCovered;

        private int electricityUsed;

        public PlaneAirConditioners(string manufacturer, string model, int volumeCovered, int electricityUsed) 
            : base(manufacturer, model)
        {
            this.VolumeCovered = volumeCovered;
            this.ElectricityUsed = electricityUsed;
        }

        public int VolumeCovered
        {
            get
            {
                return this.volumeCovered;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ValidationConstants.NONPOSITIVE, "Volume Covered"));
                }

                this.volumeCovered = value;
            }
        }

        public int ElectricityUsed
        {
            get
            {
                return this.electricityUsed;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ValidationConstants.NONPOSITIVE, "Electricity Used"));
                }

                this.electricityUsed = value;
            }
        }

        public override int Test()
        {
            double sqrtVolume = Math.Sqrt(this.VolumeCovered);
            if (this.ElectricityUsed / sqrtVolume < ValidationConstants.MinPlaneElectricity)
            {
                return 1;
            }

            return 0;
        }

        public override string ToString()
        {
            string print = base.ToString();

            print += "Volume Covered: " + this.VolumeCovered + "\r\n";

            print += "Electricity Used: " + this.ElectricityUsed + "\r\n";

            print += "====================";

            return print.ToString();
        }
    }
}
