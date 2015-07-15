using System;

class WorkHouse
{
    static void Main()
    {
        int hours = int.Parse(Console.ReadLine());
        int days = int.Parse(Console.ReadLine());
        int percent = int.Parse(Console.ReadLine());

        double workDays = (days - (days * 0.10)) * 12;
        double productivity = Math.Floor(workDays * ((double)percent / 100));
        int diff = (int)productivity - hours;
        if (diff < 0)
        {
            Console.WriteLine("No");
            Console.WriteLine(diff);
        }
        else
        {
            Console.WriteLine("Yes");
            Console.WriteLine(diff);
        }
    }
}

