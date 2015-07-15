using System;

class ModifyABitAtGivenPosition
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int value = int.Parse(Console.ReadLine());
        int position = int.Parse(Console.ReadLine());

        if (value == 1)
        {
            int mask = 1 << position;
            int result = number | mask;
            Console.WriteLine(result);
        }
        else
        {
            int mask = ~(1 << position);
            int result = number & mask;
            Console.WriteLine(result);
        }
    }
}

