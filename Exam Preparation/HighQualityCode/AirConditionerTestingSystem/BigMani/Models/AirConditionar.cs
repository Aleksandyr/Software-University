namespace BigMani.Exceptions
{
    using System;

    using BigMani.Infrastructure;

    public abstract class AirConditionar
    {
        private string manufacturer;

        private string model;

        protected AirConditionar(string manufacturer, string model)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
        }

        public int EnergyRating { get; set; }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < ValidationConstants.ModelMinLength)
                {
                    throw new ArgumentException(string.Format(ValidationConstants.INCORRECTPROPERTYLENGTH, "Model", ValidationConstants.ModelMinLength));
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

            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < ValidationConstants.ManufacturerMinLength)
                {
                    throw new ArgumentException(string.Format(ValidationConstants.INCORRECTPROPERTYLENGTH, "Manufacturer", ValidationConstants.ManufacturerMinLength));
                }

                this.manufacturer = value;
            }
        }

        public abstract int Test();

        public override string ToString()
        {
            string print = "Air Conditioner" + "\r\n" + "====================" + "\r\n" + "Manufacturer: " +
                           this.Manufacturer + "\r\n" + "Model: " + this.Model + "\r\n";

            return print.ToString();
        }
    }
}
