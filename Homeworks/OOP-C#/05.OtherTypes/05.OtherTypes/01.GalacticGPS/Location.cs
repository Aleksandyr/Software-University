using System;

namespace _01.GalacticGPS
{
    public struct Location
    {
        private double latiude;
        private double longitude;
        private Planet planet;

        public Location(double latitude, double longitude, Planet planet)
            : this()
        {
            this.Latiude = latitude;
            this.Longitude = longitude;
            this.Planet = Planet;
        }

        public double Latiude
        {
            get
            {
                return this.latiude;
            }
            set
            {
                if (value < -90 || value > 90)
                {
                    throw new ArgumentOutOfRangeException("Latiude must be between -90..90 degrees!");
                }
                this.latiude = value;
            }


        }

        public double Longitude
        {
            get
            {
                return this.longitude;
            }
            set
            {
                if (value < -180 || value > 180)
                {
                    throw new ArgumentOutOfRangeException("Longitude must be between -180..180 degrees!");
                }
                this.longitude = value;
            }

        }

        public Planet Planet
        {
            get
            {
                return this.planet;
            }
            set
            {
                this.planet = value;
            }

        }

        public override string ToString()
        {
            string result = string.Format("{0}, {1} - {2}", this.Latiude, this.Longitude, this.Planet);
            return result;
        }
    }
}
