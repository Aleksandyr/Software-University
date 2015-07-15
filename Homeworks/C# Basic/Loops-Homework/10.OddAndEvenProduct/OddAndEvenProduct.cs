using System;

class OddAndEvenProduct
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] numbers = input.Split(' ');

        int oddSum = 1;
        int evenSum = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            int number = int.Parse(numbers[i]);

            if (i % 2 == 0)
            {
                evenSum *= number;
            }
            else
            {
                oddSum *= number;
            }
        }

        if (evenSum == oddSum)
        {
            Console.WriteLine("yes");
            Console.WriteLine("product = " + evenSum);
        }
        else
        {
            Console.WriteLine("no");
            Console.WriteLine("odd_product = " + oddSum);
            Console.WriteLine("even_product = " + evenSum);
        }
    }
}

