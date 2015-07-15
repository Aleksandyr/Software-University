using System;
using System.Collections.Generic;

class CountOfNames
{
    static void Main()
    {
        List<string> names = new List<string>(Console.ReadLine().Split(' '));

        names.Sort();
        int counter = 1;
        for (int i = 1; i < names.Count; i++)
        {
            if (names[i] == names[i - 1])
            {
                counter++;
            }
            else
            {
                Console.WriteLine(names[i - 1] + " -> " + counter);
                counter = 1;
            }

            if (i == names.Count - 1)
            {
               Console.WriteLine(names[i] + " -> " + counter); 
            }
        }
    }
}

