namespace Shapes
{
    using System;

    public class Triangle : BasicShape
    {
        private double c;

        public Triangle(double a, double b, double c)
            : base(a, b)
        {
            this.C = c;
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
                    throw new ArgumentNullException("Third side cannot be negative!");
                }

                this.c = value;
            }
        }

        public override double CalculateArea()
        {
            double p = this.CalculatePerimeter() / 2;
            double area = Math.Sqrt(p * (p - this.Height) * (p - this.Width) * (p - this.C));

            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = this.Width + this.Height + this.C;

            return perimeter;
        }
    }
}
