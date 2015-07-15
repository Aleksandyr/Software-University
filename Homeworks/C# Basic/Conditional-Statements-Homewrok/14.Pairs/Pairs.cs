using System;

class Pairs
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] strNumbers = input.Split(' ');

        int[] numbers = new int[strNumbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(strNumbers[i]);
        }

        if (numbers.Length == 2)
        {
            int sum = numbers[0] + numbers[1];
            Console.WriteLine("Yes, value=" + sum);
            return;
        }

        int value = 0;
        int max = 0;
        for (int i = 0; i < numbers.Length - 2; i += 2)
        {
            int sum1 = numbers[i] + numbers[i + 1];
            int sum2 = numbers[i + 2] + numbers[i + 3];
            if (sum1 == sum2)
            {
                value = sum1;
            }
            else
            {
                if (Math.Abs(sum1 - sum2) > max)
                {
                    max = Math.Abs(sum1 - sum2);
                }
            }
        }
        if (max == 0)
        {
            Console.WriteLine("Yes, value=" + value);
        }
        else
        {
            Console.WriteLine("No, maxdiff=" + max);
        }
    }
}

