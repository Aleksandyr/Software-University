using EncapsulationAndPolymorphism.Interfaces;

namespace BasicShapes
{
    using System;

    public abstract class BasicShape : IShape
    {
        private double width;
        private double height;

        public double Width
        {
            get
            {
                return this.width;
                
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Width can not be negative!");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;

            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Width can not be negative!");
                }

                this.height = value;
            }
        }

        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
    }
}
