using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CountOfOccurences
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            List<int> nums = input.Split(' ').Select(Int32.Parse).ToList();
            Dictionary<int, int> occurences = new Dictionary<int, int>();

            for (int i = 0; i < nums.Count; i++)
            {
                if (!occurences.ContainsKey(nums[i]))
                {
                    occurences.Add(nums[i], 1);
                }
                else
                {
                    occurences[nums[i]]++;
                }
            }

            var result = occurences.OrderBy(k => k.Key);

            foreach (var occurence in result)
            {
                Console.WriteLine(occurence.Key + " -> " + occurence.Value + " times");
            }
        }
    }
}
