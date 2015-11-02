using System;

class Program
{
    static void Main()
    {
        int money = int.Parse(Console.ReadLine());
        int weekDays = int.Parse(Console.ReadLine());
        int hometown = int.Parse(Console.ReadLine());

        int normWeekends = (4 - hometown) * 2;
        int totalLost = normWeekends * 20;
        int otherMoney = weekDays * 10;
        double weekDayGoingOut = weekDays * (Math.Floor(0.03 * money));
        int normalWeekExper = (22 - weekDays) * 10;
        double sum = totalLost + otherMoney + weekDayGoingOut + normalWeekExper + 150;

        if (sum < money)
        {
            Console.WriteLine("Yes, leftover {0}.", money - sum);
        }
        else if (sum > money)
        {
            Console.WriteLine("No, not enough {0}.", sum - money);
        }
        else
        {
            Console.WriteLine("Exact Budget.");
        }
    }
}

