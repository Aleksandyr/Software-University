using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LongestSubsequence
{
    class Program
    {
        static void Main()
        {

            string input = Console.ReadLine();
            List<int> nums = input.Split(' ').Select(Int32.Parse).ToList();
            List<int> result = new List<int>();

            int counter = 0;
            int end = 0;
            int start = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                for (int j = 0; j < nums.Count; j++)
                {
                    if (nums[i] == nums[j])
                    {
                        counter++;
                    }
                }

                if (counter > end)
                {
                    start = i;
                    end = counter;
                }
                counter = 0;
            }

            List<int> maxSeqArr = nums.GetRange(start, end);

            maxSeqArr.ForEach(m => Console.Write(m + " "));
            Console.WriteLine();
            
        }
    }
}
