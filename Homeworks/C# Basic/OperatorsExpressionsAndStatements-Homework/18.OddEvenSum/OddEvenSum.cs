using System;

class OddEvenSum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int oddSum = 0;
        int evenSum = 0;
        for (int i = 1; i <= 2 * n; i++)
        {
            int digit = int.Parse(Console.ReadLine());

            if (i % 2 == 0)
            {
                evenSum += digit;
            }
            else
            {
                oddSum += digit;
            }
        }

        if (oddSum == evenSum)
        {
            Console.WriteLine("Yes, sum=" + evenSum);
        }
        else
        {
            Console.WriteLine("No, diff=" + Math.Abs(oddSum - evenSum));
        }
    }
}

