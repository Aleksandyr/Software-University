using System;

class SumOfElements
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] numbers = input.Split(' ');

        int max = int.MinValue;
        int sum = 0;
        int element = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            element = int.Parse(numbers[i]);
            if (element > max)
            {
                max = element;
            }
           
            sum += element;

        }

        sum -= max;
        if (sum == max)
        {
            Console.WriteLine("Yes, sum=" + sum);
        }
        else
        {
            Console.WriteLine("No, diff=" + Math.Abs(sum - max));
        }
    }
}

