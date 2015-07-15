using System;

class DecimalToBinaryNumber
{
    static void Main()
    {
        long decimalNumber = long.Parse(Console.ReadLine());

        string result = string.Empty;
        while (decimalNumber > 0)
        {
            result = decimalNumber % 2 + result;
            decimalNumber /= 2;
        }

        Console.WriteLine(result);
    }
}

