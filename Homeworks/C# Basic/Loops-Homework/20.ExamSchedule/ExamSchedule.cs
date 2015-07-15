using System;

class ExamSchedule
{
    static void Main()
    {
        int startingHour = int.Parse(Console.ReadLine());
        int startingMinute = int.Parse(Console.ReadLine());
        string partOfDay = Console.ReadLine().ToUpper();
        int darutionHour = int.Parse(Console.ReadLine());
        int darutionMinute = int.Parse(Console.ReadLine());

        int endHour = startingHour + darutionHour;
        int endMinute = startingMinute + darutionMinute;

        if (endHour > 12)
        {
            endHour -= 12;

            if (partOfDay == "AM")
            {
                partOfDay = "PM";
            }
            else if (partOfDay == "PM")
            {
                partOfDay = "AM";
            }
        }
        if (endMinute > 59)
        {
            endMinute -= 60;
            endHour += 1;
            if (endHour >= 12)
            {
                if (partOfDay == "AM")
                {
                    partOfDay = "PM";
                }
                else if (partOfDay == "PM")
                {
                    partOfDay = "AM";
                }
            }
        }
        Console.WriteLine("{0:d2}:{1:d2}:{2}", endHour, endMinute, partOfDay);
    }
}

