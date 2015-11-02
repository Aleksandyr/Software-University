using System;

class MelonsAndWatermelons
{
    static void Main()
    {
        int dayOfWeak = int.Parse(Console.ReadLine());
        int howDayContinue = int.Parse(Console.ReadLine());

        int watermelons = 0;
        int melons = 0;

        for (int i = 0; i < howDayContinue; i++)
        {
            if (dayOfWeak == 1)
            {
                watermelons += 1;
                dayOfWeak++;
            }
            else if (dayOfWeak == 2)
            {
                melons += 2;
                dayOfWeak++;
            }
            else if (dayOfWeak == 3)
            {
                watermelons += 1;
                melons += 1;
                dayOfWeak++;
            }
            else if (dayOfWeak == 4)
            {
                watermelons += 2;
                dayOfWeak++;
            }
            else if (dayOfWeak == 5)
            {
                watermelons += 2;
                melons += 2;
                dayOfWeak++;
            }
            else if (dayOfWeak == 6)
            {
                watermelons += 1;
                melons += 2;
                dayOfWeak++;
            }
            else if (dayOfWeak == 7)
            {
                dayOfWeak = 1;
            }
        }

        if (watermelons > melons)
        {
            Console.WriteLine("{0} more watermelons", watermelons - melons);
        }
        else if(melons > watermelons)
        {
            Console.WriteLine("{0} more melons", melons - watermelons);
        }
        else
        {
            Console.WriteLine("Equal amount: {0}", melons);
        }
    }
}

