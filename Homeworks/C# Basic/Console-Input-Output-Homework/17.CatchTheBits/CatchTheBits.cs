using System;

class CatchTheBits
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
        string sequenceWithCurrentStep = "";
        for (int i = 0; i < currSequence.Length; i++)
        {
            int possition = 1 + i * step;
            if (possition > sequence.Length - 1)
            {
                break;
            }
            sequenceWithCurrentStep += sequence[possition].ToString();
        }

        if (sequenceWithCurrentStep.Length < 8)
        {
            string sequencePadWithZeros = sequenceWithCurrentStep.PadRight(8, '0');
            int result = Convert.ToInt32(sequencePadWithZeros, 2);
            Console.WriteLine(result);
        }
        else
        {
            string numberPadWithZeros = sequenceWithCurrentStep.PadRight(Math.Abs(sequenceWithCurrentStep.Length - (sequence.Length)) + 4, '0');
            string resultas = string.Empty;
            int numberInDec = 0;
            char[] arrSequence = numberPadWithZeros.ToCharArray();
            for (int j = 0; j < arrSequence.Length; j++)
            {
                resultas += arrSequence[j];
                if ((j + 1) % 8 == 0)
                {
                    numberInDec = Convert.ToInt32(resultas, 2);
                    Console.WriteLine(numberInDec);
                    resultas = string.Empty;
                    numberInDec = 0;
                }
            }
        }
    }
}