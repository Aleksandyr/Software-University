namespace Shapes
{
    using BasicShapes;
    using System;
    using System.Collections.Generic;
    using EncapsulationAndPolymorphism.Interfaces;
    using EncapsulationAndPolymorphism.Shapes;

    class Program
    {
        static void Main()
        {
            List<IShape> shapes = new List<IShape>
            {
                new Rectangle(2.3, 3.5),
                new Triangle(3, 4, 5),
                new Circle(5)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine("Name: {0}, Area: {1}, Perimeter: {2}", shape.GetType().Name, shape.CalculateArea(), shape.CalculatePerimeter());
            }
        }
    }
}
