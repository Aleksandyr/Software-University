using System;
using System.Collections.Generic;

class PrimesInGivenRange
{
    static void Main()
    {
        int startNum = int.Parse(Console.ReadLine());
        int endNum = int.Parse(Console.ReadLine());
        
        if (startNum < endNum)
        {
            PrintList(FindPrimesInRange(startNum, endNum));
        }
        else
        {
            Console.WriteLine("(empty list)");
        }
    }

    private static List<int> FindPrimesInRange(int startNum, int endNum)
    {
        List<int> primeNumbers = new List<int>();
        for (int number = startNum; number <= endNum; number++)
        {
            if (IsPrime(number))
            {
                primeNumbers.Add(number);
            }
        }
        
        return primeNumbers;
    }

    public static bool IsPrime(int number)
    {
        int counter = 0;
        bool isPrime = true;
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

        return isPrime;
    }
    private static void PrintList(List<int> numbers)
    {
        Console.WriteLine(string.Join(", ", numbers));
    }
}

