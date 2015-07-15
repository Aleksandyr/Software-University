using System;

class CirclePerimeterAndArea
{
    static void Main()
    {
        Console.Write("r: ");
        double radius = double.Parse(Console.ReadLine());

        Console.WriteLine("Perimeter: {0:0.00}", 2 * Math.PI * radius);
        Console.WriteLine("Area: {0:0.00}", Math.PI * radius * radius);
    }
}

