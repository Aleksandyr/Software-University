using System;
using System.Collections.Generic;

class CountOfLetters
{
    static void Main()
    {
        List<string> letters = new List<string>(Console.ReadLine().Split(' '));

        letters.Sort();
        int counter = 1;
        for (int i = 1; i < letters.Count; i++)
        {
            if (letters[i] == letters[i - 1])
            {
                counter++;
            }
            else
            {
                Console.WriteLine(letters[i - 1] + " -> " + counter);
                counter = 1;
            }
            if (i == letters.Count - 1)
            {
                Console.WriteLine(letters[i] + " -> " + counter);
            }
        }
    }
}

