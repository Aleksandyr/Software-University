using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaptopShops
{
    public class Battery
    {
        private string type;
        private float hoursLife;

        public Battery(string type)
        {
            this.Type = type;
        }

        public Battery(string type, float hoursLife)
            : this(type)
        {
            this.HoursLife = hoursLife;
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this.type = value;
            }
        }

        public float HoursLife
        {
            get
            {
                return this.hoursLife;
            }
            set
            {
                if (this.hoursLife < 0)
                {
                    throw new InvalidOperationException("Hours life cannot be negative!");
                }

                this.hoursLife = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("Type: " + type);

            if (this.HoursLife > 0)
            {
                sb.AppendLine("Hours: " + this.HoursLife + " hours");
            }

            return sb.ToString();
        }
    }
}
