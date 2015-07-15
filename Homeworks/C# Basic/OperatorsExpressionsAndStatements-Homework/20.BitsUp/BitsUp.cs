using System;

class BitsUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());

        string currSequence = string.Empty;
        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            for (int j = 7; j >= 0; j--)
            {
                int numberInBin = (number >> j) & 1;
                currSequence += numberInBin;
            }
        }

        char[] sequence = currSequence.ToCharArray();
        for (int i = 0; i < currSequence.Length; i++)
        {
            int possition = 1 + i * step;
            if (possition > sequence.Length - 1)
            {
                break;
            }
            sequence[possition] = '1';
        }

        string result = string.Empty;
        int numberInDec = 0;
        for (int j = 0; j < sequence.Length; j++)
        {
            result += sequence[j];
            if ((j + 1) % 8 == 0)
            {
                numberInDec = Convert.ToInt32(result, 2);
                Console.WriteLine(numberInDec);
                result = string.Empty;
                numberInDec = 0;
            }
        }
    }
}