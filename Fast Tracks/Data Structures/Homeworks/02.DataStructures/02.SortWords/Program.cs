using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SortWords
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            List<string> words = input.Split(' ').ToList();
            //words.Sort();
            for (int i = 0; i < words.Count - 1; i++)
            {
                for (int j = 0; j < words.Count - 1; j++)
                {
                    if (words[j].CompareTo(words[j + 1]) > 0)
                    {
                        string change = words[j];
                        words[j] = words[j + 1];
                        words[j + 1] = change;
                    }
                }
            }

            words.ForEach(w => Console.Write(w + ' '));
            Console.WriteLine();
        }
    }
}
