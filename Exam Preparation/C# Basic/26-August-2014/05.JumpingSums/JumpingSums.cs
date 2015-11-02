using System;
using System.Linq;

class JumpingSums
{
    static void Main()
    {
        string s = Console.ReadLine();
        int[] numbers = s.Split(' ').Select(int.Parse).ToArray();
        int jump = int.Parse(Console.ReadLine());

        int sum = 0;
        int max = int.MinValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            int postition = i;
            for (int j = 0; j <= jump; j++)
            {
                sum += numbers[postition];
                postition += numbers[postition];
                if (postition > numbers.Length - 1)
                {
                    postition = postition % numbers.Length;
                }
            }
            if (sum > max)
            {
                max = sum;
            }
            sum = 0;
        }

        Console.WriteLine("max sum = " + max);
    }
}

