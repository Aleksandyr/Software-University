using System;

class WeirdCombinations
{
    static void Main()
    {
        string input = Console.ReadLine();
        int n = int.Parse(Console.ReadLine());

        string currSeq = string.Empty;
        int sum = 0;
        int counter = 0;
        for (int i1 = 0; i1 < input.Length; i1++)
        {
            for (int i2 = 0; i2 < input.Length; i2++)
            {
                for (int i3 = 0; i3 < input.Length; i3++)
                {
                    for (int i4 = 0; i4 < input.Length; i4++)
                    {
                        for (int i5 = 0; i5 < input.Length; i5++)
                        {
                            if (counter == n)
                            {
                                currSeq ="" +
                                    input[i1] +
                                    input[i2] +
                                    input[i3] +
                                    input[i4] +
                                    input[i5];
                                Console.WriteLine(currSeq);
                                return;
                            }
                            counter++;
                        }
                        sum = 0;
                    }
                }
            }
        }
        if (currSeq.Length == 0)
        {
            Console.WriteLine("No");
        }
    }
}

