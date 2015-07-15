using System;
using System.Collections.Generic;

class MagicStrings
{
    static void Main()
    {
        int diff = int.Parse(Console.ReadLine());
        string[] letters = { "s", "n", "k", "p" };
        int[] digits = { 3, 4, 1, 5 };

        List<string> sequences = new List<string>();
        for (int i1 = 0; i1 < letters.Length; i1++)
        {
            for (int i2 = 0; i2 < letters.Length; i2++)
            {
                for (int i3 = 0; i3 < letters.Length; i3++)
                {
                    for (int i4 = 0; i4 < letters.Length; i4++)
                    {
                        for (int i5 = 0; i5 < letters.Length; i5++)
                        {
                            for (int i6 = 0; i6 < letters.Length; i6++)
                            {
                                for (int i7 = 0; i7 < letters.Length; i7++)
                                {
                                    for (int i8 = 0; i8 < letters.Length; i8++)
                                    {
                                        int leftSum = digits[i1] + digits[i2] + digits[i3] + digits[i4];
                                        int rightSum = digits[i5] + digits[i6] + digits[i7] + digits[i8];

                                        if (Math.Abs(leftSum - rightSum) == diff)
                                        {
                                            string currentSequence =
                                                letters[i1] +
                                                letters[i2] +
                                                letters[i3] +
                                                letters[i4] +
                                                letters[i5] +
                                                letters[i6] +
                                                letters[i7] +
                                                letters[i8];

                                            sequences.Add(currentSequence);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        if (sequences.Count == 0)
        {
            Console.WriteLine("No");
        }
        else
        {
            sequences.Sort();
            foreach (var sequence in sequences)
            {
                Console.WriteLine(sequence);
            }
        }
    }
}

