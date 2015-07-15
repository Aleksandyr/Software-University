using System;
using System.Collections.Generic;
using System.Numerics;

class Halfum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<int> number1 = new List<int>(n);
        List<int> number2 = new List<int>(n);

        int counter = 0;
        long sum1 = 0;
        long sum2 = 0;
        for (int i = 0; i < 2 * n; i++)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            number1.Add(inputNumber);

            if (i > n - 1)
            {
                number2.Add(inputNumber);
            }
        }

        for (int i = 0; i < n; i++)
        {
            sum1 += number1[i];
            sum2 += number2[i];
            
            if (number1[i] != number2[i])
            {
                counter++;
            }
        }
        if (sum1 == sum2)
        {
            Console.WriteLine("Yes, sum=" + sum1); ;
        }
        else
        {
            Console.WriteLine("No, diff=" + Math.Abs(sum1 - sum2));
        }
    }
}

