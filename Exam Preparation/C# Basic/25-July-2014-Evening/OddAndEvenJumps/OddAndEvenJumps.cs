using System;

class OddAndEvenJumps
{
    static void Main()
    {
        string inputString = Console.ReadLine().ToLower().Replace(" ", "");
        int oddJump = int.Parse(Console.ReadLine());
        int evenJump = int.Parse(Console.ReadLine());

        ulong oddSum = 0;
        int oddCounter = 0;
        
        ulong evenSum = 0;
        int evenCounter = 0;
        
        inputString.ToCharArray();

        for (int i = 0; i < inputString.Length; i++)
        {
            if (i % 2 == 0)
            {
                oddCounter++;

                if (oddCounter % oddJump == 0)
                {
                    oddSum *= inputString[i];
                }
                else
                {
                    oddSum += inputString[i];
                }
            }
            else
            {
                evenCounter++;

                if (evenCounter % evenJump == 0)
                {
                    evenSum *= inputString[i];
                }
                else
                {
                    evenSum += inputString[i];
                }
            }
        }

        Console.WriteLine("Odd: {0:X}", oddSum);
        Console.WriteLine("Even: {0:X}", evenSum);

    }
}

