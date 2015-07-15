using System;

class MinMaxSumAndAverageOfNNumbers
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        int max = int.MinValue;
        int min = int.MaxValue;
        int sum = 0;
        for (int i = 0; i < size; i++)
        {
            int number = int.Parse(Console.ReadLine());
            if (number > max)
            {
                max = number;
            }
            if (number < min)
            {
                min = number;
            }

            sum += number;
        }

        Console.WriteLine("min = " + min);
        Console.WriteLine("max = " + max);
        Console.WriteLine("sum = " + sum);
        Console.WriteLine("avg = {0:0.00}", (double)sum / (double)size);
    }
}

