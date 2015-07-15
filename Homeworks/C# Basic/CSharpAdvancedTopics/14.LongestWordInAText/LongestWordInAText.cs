using System;
using System.Collections.Generic;

class LongestWordInAText
{
    static void Main()
    {
        List<string> text = new List<string>(Console.ReadLine().Split(' ', ',', '.', ':', '!', '?'));
        
        int max = int.MinValue;
        string longestWord = string.Empty;
        for (int i = 0; i < text.Count - 1; i++)
        {
            if (text[i].Length > max)
            {
                max = text[i].Length;
                longestWord = text[i];
            }
        }
        Console.WriteLine(longestWord);
    }
}

