using System;

class ThirdDigitIs7
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        int digit = 0;
        bool isSeven = false;

        for (int i = 0; i < 3; i++)
        {
            digit = number % 10;
            number /= 10;
        }

        if (digit == 7)
        {
            isSeven = true;
            Console.WriteLine(isSeven);
        }
        else
        {
            Console.WriteLine(isSeven);
        }
    }
}

