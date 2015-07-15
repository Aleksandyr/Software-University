using System;

class OddOrEvenCounter
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        string s = Console.ReadLine();
        string[] ordinal = { "First", "Second", "Third", "Fourth", "Sixth", "Seventh", "Eighth", "Ninth", "Tenth"};

        int countI = 0;
        int oddCounter = 0;
        int evenCounter = 0;
        int indexOfOrdinal = 0;
        int max = 0;
        if (s == "odd")
        {
            for (int i = 0; i < n; i++)
            {
                oddCounter = 0;
                for (int j = 0; j < c; j++)
                {
                    int number = int.Parse(Console.ReadLine());

                    if (number % 2 != 0)
                    {
                        oddCounter++;
                    }
                }
                if (oddCounter > max)
                {
                    max = oddCounter;
                    indexOfOrdinal = countI;
                }
                countI++;
            }

            if (max == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine("{0} set has the most {1} numbers: {2}", ordinal[indexOfOrdinal], s, max);
            }
        }
        else 
        {
            for (int i = 0; i < n; i++)
            {
                evenCounter = 0;
                for (int j = 0; j < c; j++)
                {
                    int number = int.Parse(Console.ReadLine());

                    if (number % 2 == 0 && number > 0)
                    {
                        evenCounter++;
                    }
                }
                if (evenCounter > max)
                {
                    max = evenCounter;
                    indexOfOrdinal = countI;
                }
                countI++;
            }

            if (max == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine("{0} set has the most {1} numbers: {2}", ordinal[indexOfOrdinal], s, max);
            }
        }
        
    }
}

