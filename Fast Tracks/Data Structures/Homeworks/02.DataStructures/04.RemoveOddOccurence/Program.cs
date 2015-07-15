using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.RemoveOddOccurence
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            List<int> nums = input.Split(' ').Select(Int32.Parse).ToList();
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int i = 0; i < nums.Count; i++)
            {
                if (!numbers.ContainsKey(nums[i]))
                {
                    numbers.Add(nums[i], 1);
                }
                else
                {
                    numbers[nums[i]]++;
                }
            }

            foreach (var number in numbers)
            {
                if (number.Value % 2 != 0)
                {
                    if (nums.Contains(number.Key))
                    {
                        for (int i = 0; i < nums.Count + 2; i++)
                        {
                            nums.Remove(number.Key);
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
