using System;

class InsideTheBuilding
{
    static void Main()
    {
        int h = int.Parse(Console.ReadLine());
        for (int i = 0; i < 5; i++)
        {
            float x = float.Parse(Console.ReadLine());
            float y = float.Parse(Console.ReadLine());

            bool isInBottomBuilding = (x >= 0) && (x <= 3 * h) && (y >= 0) && (y <= h);
            bool isInTopBuilding = (x >= h) && (x <= 2 * h) && (y >= h) && (y <= 4 * h);
            if (isInBottomBuilding || isInTopBuilding)
            {
                Console.WriteLine("inside");
            }
            else
            {
                Console.WriteLine("outside");
            }
        }
    }
}

