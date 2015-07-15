using System;

class HalfSum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int sum1 = 0;
        int sum2 = 0;
        
        for (int i = 0; i < 2 * n; i++)
        {
            int digit = int.Parse(Console.ReadLine());
            if (i < n)
            {
                sum1 += digit;
            }
            else
            {
                sum2 += digit;
            }
        }

        if (sum1 == sum2)
        {
            Console.WriteLine("Yes, sum=" + sum1);
        }
        else
        {
            Console.WriteLine("No, diff=" + Math.Abs(sum1 - sum2));
        }
    }
}

