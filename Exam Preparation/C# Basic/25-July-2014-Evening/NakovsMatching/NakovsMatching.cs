using System;

class NakovsMatching
{
    static void Main()
    {
        string firstString = Console.ReadLine();
        string secondString = Console.ReadLine();
        int maxDiff = int.Parse(Console.ReadLine());

        bool found = false;
        for (int firstIndex = 1; firstIndex <= firstString.Length - 1; firstIndex++)
        {
            string leftFirstStr = firstString.Substring(0, firstIndex);
            string rightFirstStr = firstString.Substring(firstIndex);
            int leftFirstSum = SumChars(leftFirstStr);
            int rightFirstSum = SumChars(rightFirstStr);

            for (int secondIndex = 1; secondIndex <= secondString.Length - 1; secondIndex++)
            {
                string leftSecondStr = secondString.Substring(0, secondIndex);
                string rightSecondStr = secondString.Substring(secondIndex);
                int leftSecondSum = SumChars(leftSecondStr);
                int rightSeconSum = SumChars(rightSecondStr);

                int diff = Math.Abs((leftFirstSum * rightSeconSum) - (rightFirstSum * leftSecondSum));

                if (diff <= maxDiff)
                {
                    Console.WriteLine("({0}|{1}) matches ({2}|{3}) by {4} nakovs", leftFirstStr, rightFirstStr, leftSecondStr, rightSecondStr, diff);
                    found = true;
                }
            }
        }

        if (found == false)
        {
            Console.WriteLine("No");
        }
    }

    private static int SumChars(string str)
    {
        int sum = 0;
        foreach (var chr in str)
        {
            sum += (char)chr;
        }
        return sum;
    }
}

