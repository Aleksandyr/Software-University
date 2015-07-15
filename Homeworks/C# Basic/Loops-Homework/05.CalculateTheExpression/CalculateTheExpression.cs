using System;

class CalculateTheExpression
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int x = int.Parse(Console.ReadLine());

        double result = 1;
        int factorial = 1;
        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
            result += factorial / Math.Pow(x, i);
        }

        Console.WriteLine("{0:0.00000}", result);
    }
}

