namespace BigMani.Models
{
    using System;

    using BigMani.Exceptions;
    using BigMani.Infrastructure;

    public class CarAirConditioners : AirConditionar
    {
        private int volumeCovered;

        public CarAirConditioners(string manufacturer, string model, int volumeCovered) 
            : base(manufacturer, model)
        {
            this.VolumeCovered = volumeCovered;
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

        public override int Test()
        {
            double sqrtVolume = Math.Sqrt(this.volumeCovered);
            if (sqrtVolume < 3)
            {
                return 0;
            }

            return 1;
        }

        public override string ToString()
        {
            string print = base.ToString();

            print += "Volume Covered: " + this.VolumeCovered + "\r\n";
            
            print += "====================";

            return print.ToString();
        }
    }
}