using System;

class FibonacciNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        ulong firstNum = 0;
        ulong secondNum = 1;
        Console.WriteLine("Fibonacci numbers: ");
        if (n == 1)
        {
            Console.WriteLine(firstNum);
        }
        else
        {
            Console.WriteLine(firstNum);
            Console.WriteLine(secondNum);
            for (int i = 0; i < n - 2; i++)
            {
                ulong thirdNumber = firstNum;
                firstNum = secondNum;
                secondNum = thirdNumber + firstNum;
                Console.WriteLine(secondNum);
            }
        }
    }
}

