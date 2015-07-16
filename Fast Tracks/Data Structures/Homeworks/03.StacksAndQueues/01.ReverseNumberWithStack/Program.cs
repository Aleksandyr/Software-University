using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ReverseNumberWithStack
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Stack<int> nums = new Stack<int>(input.Split(' ').Select(x => int.Parse(x)));

            if (nums.Count == 0)
            {
                Console.WriteLine("");
            }

            foreach (var num in nums)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine();
        }
    }
}
