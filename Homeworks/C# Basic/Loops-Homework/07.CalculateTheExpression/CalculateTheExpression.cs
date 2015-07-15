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

            BigInteger factorialNToK = 1;
            BigInteger factorial = 1;

            for (int i = k + 1; i <= n; i++)
            {
                factorialNToK *= i;
            }
            for (int i = 2; i <= (n - k); i++)
            {
                factorial *= i;
            }

            BigInteger result = factorialNToK / factorial;
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Invalid input");
        }
    }
}

