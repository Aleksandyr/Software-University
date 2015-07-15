using System;

class BinaryToDecimalNumber
{
    static void Main()
    {
        string binNumber = Console.ReadLine();

        long decimalNum = 0;
        for (int i = 0; i < binNumber.Length; i++)
        {
            if (binNumber[binNumber.Length - i - 1] == '0')
            {
                continue;
            }

            decimalNum += (long)Math.Pow(2, i);
        }
        Console.WriteLine(decimalNum);
    }
}

