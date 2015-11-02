using System;
using System.Collections.Generic;

class SumOfElements
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] numbers = input.Split(' ');

        long max = long.MinValue;
        long sum = 0;
        
        for (int i = 0; i < numbers.Length; i++)
        {
            long element = long.Parse(numbers[i]);
            if (element > max)
            {
                max = element;
            }

            sum += element;
        }
        
        long finalSUm = sum -= max;
        if (finalSUm == max)
        {
            Console.WriteLine("Yes, sum={0}", finalSUm);
        }
        else
        {
            Console.WriteLine("No, diff={0}", Math.Abs(finalSUm - max));
        }
    }
}

