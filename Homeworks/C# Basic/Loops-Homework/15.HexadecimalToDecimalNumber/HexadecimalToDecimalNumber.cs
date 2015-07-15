using System;

class HexadecimalToDecimalNumber
{
    static void Main()
    {
        string hexNum = Console.ReadLine().ToUpper();

        long result = 0;
        for (int i = 0; i < hexNum.Length; i++)
        {
            int charNum = (char)hexNum[i];
            if (charNum <= 70 && charNum >= 65)
            {
                result += (charNum - 55) * (long)Math.Pow(16, hexNum.Length - i - 1);
            }
            else
            {
                result += (charNum - 48) * (long)Math.Pow(16, hexNum.Length - i - 1);
            }
        }
        Console.WriteLine(result);
    }
}

