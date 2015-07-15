using System;
namespace Battleships.Ships
{
    public abstract class Ship
    {
        private string name;
        private double lengthInMeters;
        private double volume;

        protected Ship(string name, double lengthInMeters, double volume)
        {
            this.Name = name;
            this.LengthInMeters = lengthInMeters;
            this.Volume = volume;
        }

        public string Name
        {
            get
            {
                return this.name;

            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name can not be null or empty!");
                }

                this.name = value;
            }
        }

        public double LengthInMeters
        {
            get
            {
                return this.lengthInMeters;

            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Length in meters can not be negative!");
                }

                this.lengthInMeters = value;
            }
        }

        public double Volume
        {
            get
            {
                return this.volume;

            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Length in meters can not be negative!");
                }

                this.volume = value;
            }
        }

        public bool IsBattleship { get; set; }

        public bool IsDestroyed { get; set; }
    }
}
