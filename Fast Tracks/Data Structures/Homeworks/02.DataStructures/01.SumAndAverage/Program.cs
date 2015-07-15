using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SumAndAverage
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            if (input == String.Empty)
            {
                Console.WriteLine("sum=0, Average=0");
            }
            else
            {
                List<int> nums = input.Split(' ').Select(Int32.Parse).ToList();

                int sum = 0;
                for (int i = 0; i < nums.Count; i++)
                {
                    sum += nums[i];
                }

                Console.WriteLine("sum={0}, Average={1}", sum, ((double)sum / nums.Count));
            }
        }
    }
}
