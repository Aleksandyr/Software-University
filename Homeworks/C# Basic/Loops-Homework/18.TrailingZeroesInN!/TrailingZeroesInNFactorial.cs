using System;
using System.Numerics;

class TrailingZeroesInNFactorial
{
    static void Main()
    {
        int n = 20;

        int traillingZeros = 0;
        int five = 5;
        while (n > five)
        {
            traillingZeros += n / five;
            five *= 5;
        }
        Console.WriteLine(traillingZeros);
    }
}

