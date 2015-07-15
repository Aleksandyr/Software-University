using System;
using System.Collections.Generic;

class RemoveNames
{
    static void Main()
    {
        List<string> firstNameList = new List<string>(Console.ReadLine().Split(' '));
        List<string> secondNameList = new List<string>(Console.ReadLine().Split(' '));

        for (int i = 0; i < secondNameList.Count; i++)
        {
            for (int j = 0; j < firstNameList.Count; j++)
            {
                if (secondNameList[i] == firstNameList[j])
                {
                    firstNameList.RemoveAt(j);
                    j--;
                }
            }
        }


        Console.Write(string.Join(" ", firstNameList));
        Console.WriteLine();
    }
}

