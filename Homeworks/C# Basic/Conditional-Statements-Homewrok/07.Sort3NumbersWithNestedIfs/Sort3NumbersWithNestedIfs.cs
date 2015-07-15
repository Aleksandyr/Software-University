using System;

class Sort3NumbersWithNestedIfs
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        if (a > b && a > c)
        {
            Console.Write(a + " ");
            if (b > c)
            {
                Console.Write(b + " " + c);
            }
            else
            {
                Console.Write(c + " " + b);
            }
        }
        else if (b > c && b > a)
        {
            Console.Write(b + " ");
            if (a > c)
            {
                Console.Write(a + " " + c);
            }
            else
            {
                Console.Write(c + " " + a);
            }
        }
        else
        {
            Console.Write(c + " ");
            if (b > a)
            {
                Console.Write(b + " " + a);
            }
            else
            {
                Console.Write(a + " " + b);
            }
        }
        Console.WriteLine();
    }
}

