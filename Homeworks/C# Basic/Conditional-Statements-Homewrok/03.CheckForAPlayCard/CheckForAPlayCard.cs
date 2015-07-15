using System;

class CheckForAPlayCard
{
    static void Main()
    {
        string[] cards = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        string inputCard = Console.ReadLine();

        bool isFound = false;
        foreach (var card in cards)
        {
            if (inputCard == card)
            {
                isFound = true;
            }
        }

        if (isFound == true)
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}

