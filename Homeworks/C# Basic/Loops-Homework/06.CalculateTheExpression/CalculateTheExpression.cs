using System;
using System.Numerics;

class CalculateTheExpression
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        if (k > 1 && n > k && n < 100)
        {
            BigInteger result = 1;
            for (int i = n; i > k; i--)
            {
                result *= i;
            }
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Invalid input!");
        }
    }
}

