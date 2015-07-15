using System;

class PrimeNumberCheck
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        bool isPrime = true;
        int counter = 0;
        if (number <= 0 || number == 1)
        {
            isPrime = false;
        }
        else
        {
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    counter++;
                }
            }
        }
        if (counter > 2)
        {
            isPrime = false;
        }
        Console.WriteLine(isPrime);
    }
}

