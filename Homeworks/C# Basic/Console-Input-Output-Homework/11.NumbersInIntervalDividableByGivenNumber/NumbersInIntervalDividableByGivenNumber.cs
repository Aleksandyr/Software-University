using System;

class NumbersInIntervalDividableByGivenNumber
{
    static void Main()
    {
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());

        if (start > end)
        {
            Console.WriteLine("Start must be smaller than end!");
            return;
        }

        int counter = 0;
        for (int i = start; i <= end; i++)
        {
            if (i % 5 == 0)
            {
                counter++;
            }
        }
        Console.WriteLine("{0} numbers that are divisible by 5", counter);
    }
}

