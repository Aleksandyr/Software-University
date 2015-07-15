using System;

class Rectangles
{
    static void Main()
    {
        float width = float.Parse(Console.ReadLine());
        float height = float.Parse(Console.ReadLine());

        Console.WriteLine("perimeter: {0}", 2 * width + 2 * height);
        Console.WriteLine("area: {0}", width * height);
    }
}

