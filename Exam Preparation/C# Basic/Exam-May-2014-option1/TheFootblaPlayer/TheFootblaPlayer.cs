using System;


class TheFootblaPlayer
{
    static void Main()
    {
        string isLeap = Console.ReadLine();
        int holidays = int.Parse(Console.ReadLine());
        int inHometown = int.Parse(Console.ReadLine());

        int weeksInAYear = 52;
        int howWeeksWeHave = weeksInAYear - inHometown;
        double inHolidayGames = 0.5 * (double)holidays;

        double allGamesInTheYear = 0;

        if (isLeap == "t")
        {
            allGamesInTheYear = (howWeeksWeHave * 2) / 3 + inHolidayGames + 3 + inHometown; 
        }
        else
        {
            allGamesInTheYear = (howWeeksWeHave * 2) / 3 + inHolidayGames + inHometown;
        }

        Console.WriteLine(Math.Floor(allGamesInTheYear));
    }
}

