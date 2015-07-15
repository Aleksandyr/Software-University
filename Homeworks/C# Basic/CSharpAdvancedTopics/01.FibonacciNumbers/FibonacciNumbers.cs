using System;

class FibonacciNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Fib(n);
    }

    private static void Fib(long n)
    {
        long firstNum = 0;
        long secondNum = 1;
        long temp = 0;
        for (int i = 0; i < n; i++)
        {
            temp = secondNum + firstNum;
            firstNum = secondNum;
            secondNum = temp;
        }
        Console.WriteLine(temp);
    }
}

