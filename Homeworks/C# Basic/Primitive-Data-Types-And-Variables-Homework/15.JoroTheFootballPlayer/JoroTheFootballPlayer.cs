using System;

class JoroTheFootballPlayer
{
    static void Main()
    {
        string isLeap = Console.ReadLine();
        int p = int.Parse(Console.ReadLine());
        int h = int.Parse(Console.ReadLine());

        float normalWeekends = (float)(52 - h) * 2 / 3;
        float holiday = (float)p / 2;

        float totalPlays = normalWeekends + holiday + h;
        if (isLeap == "t")
        {
            totalPlays += 3;
        }
        Console.WriteLine(Math.Floor(totalPlays));
        
    }
}

