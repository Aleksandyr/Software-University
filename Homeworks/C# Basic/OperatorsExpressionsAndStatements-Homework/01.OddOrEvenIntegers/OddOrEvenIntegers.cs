using System;

class OddOrEvenIntegers
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        bool isOdd = true;
        if (number % 2 == 0)
        {
            isOdd = false;
            Console.WriteLine(isOdd);
        }
        else
        {
            Console.WriteLine(isOdd);
        }
    }
}

