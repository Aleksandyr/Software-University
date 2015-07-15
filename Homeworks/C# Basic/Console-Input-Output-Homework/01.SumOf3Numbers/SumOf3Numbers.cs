using System;

class SumOf3Numbers
{
    static void Main()
    {
        Console.WriteLine("Enter 3 numbers:");

        double sum = 0;
        for (int i = 0; i < 3; i++)
        {
            double number = double.Parse(Console.ReadLine());
            sum += number;
        }
        Console.WriteLine("Sum: " + sum);
    }
}

