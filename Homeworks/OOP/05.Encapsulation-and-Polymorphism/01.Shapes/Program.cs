namespace Shapes
{
    using Shapes.Interfaces;
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main()
        {
            List<IShape> shapes = new List<IShape>()
            {
                new Triangle(2, 3, 3),
                new Rectangle(5, 5),
                new Circle(5)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine("Shape name: " + shape.GetType().Name);
                Console.WriteLine("Area: " + shape.CalculateArea());
                Console.WriteLine("Perimeter: " + shape.CalculatePerimeter());
                Console.WriteLine();
            }
        }
    }
}
