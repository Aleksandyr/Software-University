using System;

class SumOfNNumbers
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        double sum = 0;
        for (int i = 0; i < size; i++)
        {
            double number = double.Parse(Console.ReadLine());
            sum += number;
        }
        Console.WriteLine("Sum: " + sum);
    }
}

