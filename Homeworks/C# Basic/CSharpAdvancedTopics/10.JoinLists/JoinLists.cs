using System;
using System.Collections.Generic;

class JoinLists
{
    static void Main()
    {
        List<string> firstNumberList = new List<string>(Console.ReadLine().Split(' '));
        List<string> secondNumberList = new List<string>(Console.ReadLine().Split(' '));

        firstNumberList.AddRange(secondNumberList);
        for (int i = 0; i < firstNumberList.Count; i++)
        {
            for (int j = i + 1; j < firstNumberList.Count; j++)
            {
                if (firstNumberList[i] == firstNumberList[j])
                {
                    firstNumberList.RemoveAt(j);
                }
            }
        }

        firstNumberList.Sort();
        Console.WriteLine(string.Join(" ", firstNumberList));
        Console.WriteLine();
    }
}

