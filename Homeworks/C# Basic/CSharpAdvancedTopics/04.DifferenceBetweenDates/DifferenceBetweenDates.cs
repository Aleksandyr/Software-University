using System;

class DifferenceBetweenDates
{
    static void Main()
    {
        DateTime startDateTime = DateTime.Parse(Console.ReadLine());
        DateTime endDateTime = DateTime.Parse(Console.ReadLine());

        double days = (endDateTime - startDateTime).TotalDays;
        Console.WriteLine(days);
    }
}

