using System;

class Volleyball
{
    static void Main()
    {
        string leapOrNormalYear = Console.ReadLine();
        int holidays = int.Parse(Console.ReadLine());
        int hometown = int.Parse(Console.ReadLine());

        float holidaysPlays = ((float)holidays * 2) / 3;
        float normalWeekends = 48 - hometown;
        
        float normalWeekendsPlays = 
            (normalWeekends * 3) / 4 + 
            holidaysPlays + 
            hometown;

        float additional = normalWeekendsPlays * 0.15f;
        float totalPlays = additional + normalWeekendsPlays;
        if (leapOrNormalYear != "leap")
        {
            totalPlays -= additional;
        }
        Console.WriteLine(Math.Floor(totalPlays));
    }
}

