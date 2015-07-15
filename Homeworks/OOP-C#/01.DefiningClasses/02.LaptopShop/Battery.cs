using System;
using System.Text;

namespace BatteryInfo
{
    class Battery
    {
        private string batteryModel;
        private double batteryLife;

        public Battery(string batteryModel)
        {
            this.BatteryModel = batteryModel;
        }

        public Battery(string batteryModel, double batteryLife) : this(batteryModel)
        {
            this.BatteryLife = batteryLife;
        }

        public string BatteryModel
        { 
            get
            {
                return this.batteryModel;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Battery model can't be empty or null!");
                }

                this.batteryModel = value;
            }
        }

        public double BatteryLife
        {
            get
            {
                return this.batteryLife;
            } 
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Battery life musn't be negative!");
                }

                this.batteryLife = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Battery model: " + this.BatteryModel);
            sb.AppendLine("Battery life: " + this.BatteryLife + "hours");
            return sb.ToString();
        }
    }
}
