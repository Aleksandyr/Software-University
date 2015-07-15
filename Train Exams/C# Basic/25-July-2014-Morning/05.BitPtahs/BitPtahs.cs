using System;
using System.Linq;

class BitPtahs
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] board = new int[8];
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            int[] currentPath = input.Split(',').Select(int.Parse).ToArray();

            int position = 3 - currentPath[0];
            for (int j = 0; j < currentPath.Length; j++)
            {
                board[j] = board[j] ^ (1 << position);
                if (j == 7)
                {
                    break;
                }
                position -= currentPath[j + 1];
            }
        }

        int sum = board.Sum();
        Console.WriteLine(Convert.ToString(sum, 2));
        Console.WriteLine("{0:X}", sum);
    }
}

