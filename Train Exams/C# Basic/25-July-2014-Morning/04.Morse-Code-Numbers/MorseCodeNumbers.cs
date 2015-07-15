using System;

class MorseCodeNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int nSum = 0;
        while (n > 0)
        {
            nSum += n % 10;
            n /= 10;
        }

        string[] morseCode = { "-----", ".----", "..---", "...--", "....-", "....." };
        bool foundAnswer = false;

        for (int i0 = 0; i0 <= 5; i0++)
        {
            for (int i1 = 0; i1 <= 5; i1++)
            {
                for (int i2 = 0; i2 <= 5; i2++)
                {
                    for (int i3 = 0; i3 <= 5; i3++)
                    {
                        for (int i4 = 0; i4 <= 5; i4++)
                        {
                            for (int i5 = 0; i5 <= 5; i5++)
                            {
                                int morseProduct = i0 * i1 * i2 * i3 * i4 * i5;
                                if (morseProduct == nSum)
                                {
                                    string morseNumber =
                                        morseCode[i0] + "|" +
                                        morseCode[i1] + "|" +
                                        morseCode[i2] + "|" +
                                        morseCode[i3] + "|" +
                                        morseCode[i4] + "|" +
                                        morseCode[i5] + "|";

                                    foundAnswer = true;
                                    Console.WriteLine(morseNumber);
                                }
                            }
                        }
                    }
                }
            }
        }

        if (foundAnswer == false)
        {
            Console.WriteLine("No");
        }
    }
}

