using System;
using System.Collections.Generic;

class CountingAWordInAText
{
    static void Main()
    {
        string word = Console.ReadLine().ToUpper();
        List<string> text = new List<string>(Console.ReadLine().ToUpper().Split(' ', '.', ',', '"', '@', '!', '?', '/', '\\', ':', ';', '(', ')'));

        int counter = 0;
        for (int i = 0; i < text.Count; i++)
        {
            if (string.Equals(text[i], word))
            {
                counter++;
            }
        }
        Console.WriteLine(counter);
    }
}

