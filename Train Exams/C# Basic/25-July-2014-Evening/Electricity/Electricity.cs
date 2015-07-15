using System;

class Electricity
{
    static void Main()
    {
        int floors = int.Parse(Console.ReadLine());
        int flats = int.Parse(Console.ReadLine());
        DateTime time = DateTime.Parse(Console.ReadLine());


        double totalPowerOfWatts;
        if (time.Hour >= 14 && time.Hour < 19)
        {
            totalPowerOfWatts = (flats * (100.53 * 2 + 125.90 * 2)) * floors;      
        }

        else if (time.Hour >= 19 && time.Hour <= 23)
        {
            totalPowerOfWatts = (flats * (100.53 * 7 + 125.90 * 6)) * floors;
        }

        else if (time.Hour >= 00 && time.Hour < 9)
        {
            totalPowerOfWatts = (flats * (100.53 * 1 + 125.90 * 8)) * floors;
        }
        
        else
        {
            totalPowerOfWatts = 0;
        }

        Console.WriteLine("{0} Watts", Math.Floor(totalPowerOfWatts));
    }
}

