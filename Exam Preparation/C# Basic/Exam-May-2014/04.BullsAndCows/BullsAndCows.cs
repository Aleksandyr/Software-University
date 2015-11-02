using System;

class BullsAndCows
{
    static void Main()
    {
        string guessNum = Console.ReadLine();
        int targetBulls = int.Parse(Console.ReadLine());
        int targetCows = int.Parse(Console.ReadLine());

        bool found = false;
        for (int candidate = 1; candidate <= 9999; candidate++)
        {
            char[] digit = candidate.ToString().ToCharArray();
            if (digit.Length == 4 && digit[0] >= '1' && digit[1] >= '1' && digit[2] >= '1' && digit[3] >= '1')
            {
                char[] guess = guessNum.ToCharArray();
                int bulls = 0;
                int cows = 0;

                for (int i = 0; i < guess.Length; i++)
                {
                    if (guess[i] == digit[i])
                    {
                        bulls++;
                        guess[i] = '*';
                        digit[i] = '@';
                    }
                }

                for (int guessIndex = 0; guessIndex < guess.Length; guessIndex++)
                {
                    for (int digitIndex = 0; digitIndex < digit.Length; digitIndex++)
                    {
                        if (guess[guessIndex] == digit[digitIndex])
                        {
                            cows++;
                            guess[guessIndex] = '*';
                            digit[digitIndex] = '@';
                        }
                    }
                }
                if (bulls == targetBulls && cows == targetCows)
                {
                    if (found)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(candidate);
                    found = true;
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("No");
        }
    }
}

