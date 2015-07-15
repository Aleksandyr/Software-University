using System;

class PrintADeckOf52Cards
{
    static void Main()
    {
        string[] cards = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q" , "K", "A"};
        char[] suits = { (char)5, (char)4, (char)3, (char)6 };

        for (int card = 0; card < cards.Length; card++)
        {
            for (int suit = 0; suit < suits.Length; suit++)
            {
                switch (card)
                {
                    case 0: Console.Write(cards[card] + "" + suits[suit] + " "); break;
                    case 1: Console.Write(cards[card] + "" + suits[suit] + " "); break;
                    case 2: Console.Write(cards[card] + "" + suits[suit] + " "); break;
                    case 3: Console.Write(cards[card] + "" + suits[suit] + " "); break;
                    case 4: Console.Write(cards[card] + "" + suits[suit] + " "); break;
                    case 5: Console.Write(cards[card] + "" + suits[suit] + " "); break;
                    case 6: Console.Write(cards[card] + "" + suits[suit]+ " "); break;
                    case 7: Console.Write(cards[card] + "" + suits[suit]+ " "); break;
                    case 8: Console.Write(cards[card] + "" + suits[suit]+ " "); break;
                    case 9: Console.Write(cards[card] + "" + suits[suit]+ " "); break;
                    case 10: Console.Write(cards[card] + "" + suits[suit]+ " "); break;
                    case 11: Console.Write(cards[card] + "" + suits[suit]+ " "); break;
                    case 12: Console.Write(cards[card] + "" + suits[suit]+ " "); break;
                    
                    default: Console.WriteLine("This card does not exist!"); break;
                }
            }
            Console.WriteLine();
        }
    }
}

