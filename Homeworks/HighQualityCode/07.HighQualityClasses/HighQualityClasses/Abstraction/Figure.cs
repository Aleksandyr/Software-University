namespace Abstraction
{
    using Abstraction.Interfaces;

    public abstract class Figure : ICalculatePerimeter, ICalculateSurface
    {
        public abstract double CalcPerimeter();

        public abstract double CalcSurface();
    }
}
