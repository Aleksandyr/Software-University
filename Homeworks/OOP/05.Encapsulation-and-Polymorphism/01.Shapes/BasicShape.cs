namespace Shapes
{
    using Shapes.Interfaces;

    public abstract class BasicShape : IShape
    {
        private double width;
        private double height;

        protected BasicShape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        protected double Width 
        { 
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }

        protected double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }

        public abstract double CalculateArea();

        public abstract double CalculatePerimeter();
    }
}
