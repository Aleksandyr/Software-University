using System;

class TheBiggestOf3Numbers
{
    static void Main()
    {
        double biggest = double.MinValue;
        for (int i = 0; i < 3; i++)
        {
            int number = int.Parse(Console.ReadLine());
            if (number > biggest)
            {
                biggest = number;
            }
        }
        Console.WriteLine(biggest);
    }
}

