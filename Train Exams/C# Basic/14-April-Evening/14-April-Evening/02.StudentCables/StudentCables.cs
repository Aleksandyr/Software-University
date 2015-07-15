using System;

class StudentCables
{
    static void Main()
    {
        int numberOfCables = int.Parse(Console.ReadLine());

        int totalLength = 0;
        int joins = 0;
        for (int i = 0; i < numberOfCables; i++)
        {
            int cableLength = int.Parse(Console.ReadLine());
            string measure = Console.ReadLine();
            if (measure == "meters")
            {
                cableLength *= 100;
            }
            if (cableLength >= 20)
            {
                totalLength += cableLength;
                joins++;
            }
        }

        totalLength -= 3 * (joins - 1);
        int cableCount = totalLength / 504;
        int remainder = totalLength % 504;

        Console.WriteLine(cableCount);
        Console.WriteLine(remainder);
    }
}

