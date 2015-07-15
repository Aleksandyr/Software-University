using System;

class Triangle
{
    static void Main()
    {
        int aX = int.Parse(Console.ReadLine());
        int aY = int.Parse(Console.ReadLine());
        int bX = int.Parse(Console.ReadLine());
        int bY = int.Parse(Console.ReadLine());
        int cX = int.Parse(Console.ReadLine());
        int cY = int.Parse(Console.ReadLine());

        double a = Math.Sqrt(Math.Pow(aX - cX, 2) + Math.Pow(aY - cY, 2));
        double b = Math.Sqrt(Math.Pow(bX - aX, 2) + Math.Pow(bY - aY, 2));
        double c = Math.Sqrt(Math.Pow(bX - cX, 2) + Math.Pow(bY - cY, 2));

        double p = (a + b + c) / 2;
        double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        if ((a + b > c) && (b + c > a) && (a + c > b))
        {
            Console.WriteLine("Yes");
            Console.WriteLine("{0:0.00}", area);
        }
        else
        {
            Console.WriteLine("No");
            Console.WriteLine("{0:0.00}", p);
        }
    }
}

