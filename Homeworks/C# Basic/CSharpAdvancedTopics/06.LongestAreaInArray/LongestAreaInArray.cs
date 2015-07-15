using System;
using System.Collections.Generic;

class LongestAreaInArray
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<string> sequenceOfStrings = new List<string>();
        for (int i = 0; i < n; i++)
        {
            string words = Console.ReadLine();
            sequenceOfStrings.Add(words);
        }

        int counter = 0;
        int max = int.MinValue;
        List<string> result = new List<string>();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (sequenceOfStrings[i].Length == sequenceOfStrings[j].Length)
                {
                    if (sequenceOfStrings[i] == sequenceOfStrings[j])
                    {
                        counter++;
                    }
                }
            }
            if (counter > max)
            {
                max = counter;
                result = new List<string>();
                for (int k = 0; k < counter; k++)
                {
                    result.Add(sequenceOfStrings[i]);
                }
            }
            counter = 0;
        }

        Console.WriteLine(result.Count);
        foreach (var word in result)
        {
            Console.WriteLine(word);
        }
    }
}

