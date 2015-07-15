using System;

class PrimeChecker
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        Console.WriteLine(IsPrime(n));
    }

    private static bool IsPrime(long n)
    {
        return n % 2 == 0;
    }
}

