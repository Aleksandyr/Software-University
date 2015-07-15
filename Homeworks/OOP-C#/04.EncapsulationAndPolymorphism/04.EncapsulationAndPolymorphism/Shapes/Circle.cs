namespace EncapsulationAndPolymorphism.Shapes
{
    using System;
    using EncapsulationAndPolymorphism.Interfaces;


    class Circle : IShape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;

            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Width can not be negative!");
                }

                this.radius = value;
            }
        }

        public double CalculateArea()
        {
            return Math.PI * this.Radius;
        }

        public double CalculatePerimeter()
        {
            return 2 * Math.PI * this.Radius;
        }
    }
}
