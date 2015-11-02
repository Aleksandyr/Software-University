using System;
using System.Collections.Generic;

class MagicStrings
{
    static void Main()
    {
        int diff = int.Parse(Console.ReadLine());
        string[] letters = { "s", "n", "k", "p" };
        int[] digits = { 3, 4, 1, 5 };

        List<string> resultList = new List<string>();
        int resultsCount = 0;
        for (int d1 = 0; d1 < letters.Length; d1++)
        {
            for (int d2 = 0; d2 < letters.Length; d2++)
            {
                for (int d3 = 0; d3 < letters.Length; d3++)
                {
                    for (int d4 = 0; d4 < letters.Length; d4++)
                    {
                        for (int d5 = 0; d5 < letters.Length; d5++)
                        {
                            for (int d6 = 0; d6 < letters.Length; d6++)
                            {
                                for (int d7 = 0; d7 < letters.Length; d7++)
                                {
                                    for (int d8 = 0; d8 < letters.Length; d8++)
                                    {
                                        int leftSum = digits[d1] + digits[d2] + digits[d3] + digits[d4];
                                        int rightSum = digits[d5] + digits[d6] + digits[d7] + digits[d8];
                                        if (Math.Abs(leftSum - rightSum) == diff)
                                        {
                                            string sequence =
                                                letters[d1] +
                                                letters[d2] +
                                                letters[d3] +
                                                letters[d4] +
                                                letters[d5] +
                                                letters[d6] +
                                                letters[d7] +
                                                letters[d8];
                                            resultList.Add(sequence);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        if (resultList.Count == 0)
        {
            Console.WriteLine("No");
        }
        else
        {
            resultList.Sort();
            foreach (var item in resultList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
