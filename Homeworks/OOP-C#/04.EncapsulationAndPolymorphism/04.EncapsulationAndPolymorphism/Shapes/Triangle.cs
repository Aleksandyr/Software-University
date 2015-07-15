using System.Data;

namespace EncapsulationAndPolymorphism.Shapes
{
    using BasicShapes;
    using System;

    class Triangle : BasicShape
    {
        private double a;
        private double b;
        private double c;

        public Triangle(double a, double b, double c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
        }

        public double A
        {
            get
            {
                return this.a;

            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("A can not be negative!");
                }

                this.a = value;
            }
        }

        public double B
        {
            get
            {
                return this.b;

            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("B can not be negative!");
                }

                this.b = value;
            }
        }

        public double C
        {
            get
            {
                return this.c;

            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("C can not be negative!");
                }

                this.c = value;
            }
        }

        public double S
        {
            get
            {
                return this.CalculatePerimeter() / 2;

            }
        }

        public override double CalculateArea()
        {
            return Math.Sqrt(this.S * (this.S - this.A) * (this.S - this.B) * (this.S - this.C));
        }

        public override double CalculatePerimeter()
        {
            if (this.A + this.B > this.C)
            {
                return this.A + this.B + this.C;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return "Area: " + this.CalculateArea() + " Perimeter: " + this.CalculatePerimeter();
        }
    }
}
