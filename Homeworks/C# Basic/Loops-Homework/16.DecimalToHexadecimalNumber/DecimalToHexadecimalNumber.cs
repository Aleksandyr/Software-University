using System;

class DecimalToHexadecimalNumber
{
    static void Main()
    {
        long decimalNumber = long.Parse(Console.ReadLine());

        string result = string.Empty;
        while (decimalNumber > 0)
        {
            long reminder = decimalNumber % 16;
            if (reminder % 16 > 9)
            {
                result = (char)((decimalNumber % 16) + 55) + result;
            }
            else
            {
                result = reminder + result;
            }

            decimalNumber /= 16;
        }
        Console.WriteLine(result);
    }
}

