using System;
using System.Collections.Generic;

namespace CommonTypeSystem
{
    class Country : ICloneable, IComparable<Country>
    {

        private string name;
        private long population;
        private double area;
        private List<string> cities;

        public Country(string name, long population, double area, params string[] cities)
        {
            this.Name = name;
            this.Population = population;
            this.Area = area;
            this.Cities = new List<string>(cities);
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
                    throw new ArgumentNullException("Name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public long Population
        {
            get
            {
                return this.population;

            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("Population cannot be negative");
                }

                this.population = value;
            }
        }

        public double Area
        {
            get
            {
                return this.area;

            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("Area cannot be negative");
                }

                this.area = value;
            }
        }

        public List<string> Cities
        {
            get
            {
                return this.cities;

            }
            set
            {
                this.cities = value;
            }
        }

        public int CompareTo(Country other)
        {
            if (other.Area > this.Area)
            {
                return (int)(other.Area - this.Area);
            }
            if (other.Area < this.Area)
            {
                return (int)(other.Area - this.Area);
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            var otherCountry = obj as Country;

            if (this.Name == otherCountry.Name)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Population.GetHashCode() ^ this.Area.GetHashCode();
        }

        public static bool operator ==(Country a, Country b)
        {
            if (a.Name == b.Name)
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(Country a, Country b)
        {
            if (!(a.Name == b.Name))
            {
                return true;
            }

            return false;
        }

        public virtual object Clone()
        {
            Country obj = new Country(this.Name, this.Population, this.Area, this.Cities.ToArray());

            return obj;
        }
    }
}
