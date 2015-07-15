using System;
using System.Collections.Generic;

class SortingNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<int> numbers = new List<int>();

        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            numbers.Add(number);
        }

        numbers.Sort();

        Console.WriteLine("Sort numbers: ");
        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}

