using System;
using System.Numerics;

class CatalanNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        BigInteger nMultiTwoFactorial = 1;
        BigInteger nFactorial = 1;
        BigInteger nPlus1Factorial = 1;

        for (int i = 1; i <= n * 2; i++)
        {
            nMultiTwoFactorial *= i;
        }
        for (int i = 1; i <= n; i++)
        {
            nFactorial *= i;
            nPlus1Factorial *= i + 1;
        }

        BigInteger result = nMultiTwoFactorial / (nPlus1Factorial * nFactorial);
        Console.WriteLine(result);
    }
}

