using System;

class NumbersFrom1ToN
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        Console.WriteLine("This is the numbers from 1 to size: ");
        for (int i = 1; i <= size; i++)
        {
            Console.WriteLine(i);
        }
    }
}

