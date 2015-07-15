using System;

class DivideBy7And5
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        bool isDevide = false;
        if (number == 0)
        {
            isDevide = false;
            Console.WriteLine(isDevide);
        }
        else if (number % 7 == 0 && number % 5 == 0)
        {
            isDevide = true;
            Console.WriteLine(isDevide);
        }
        else
        {
            Console.WriteLine(isDevide);
        }
    }
}

