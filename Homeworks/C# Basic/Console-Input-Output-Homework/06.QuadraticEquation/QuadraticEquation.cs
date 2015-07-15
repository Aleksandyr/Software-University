using System;

class QuadraticEquation
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        double descriminant = b * b - 4 * a * c;

        if (descriminant < 0)
        {
            Console.WriteLine("No real roots!");
        }
        else if (descriminant == 0)
        {
            Console.WriteLine("There is one real root: ");
            Console.WriteLine("x1=x2=" + (-b) / (2 * a));
        }
        else
        {
            Console.WriteLine("There is two real roots:");
            Console.WriteLine("x1=" + (-b - Math.Sqrt(descriminant)) / (2 * a) );
            Console.WriteLine("x2=" + (-b + Math.Sqrt(descriminant)) / (2 * a));
        }
    }
}

