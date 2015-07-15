using System;

class Program
{
    static void Main()
    {
        long sumOfBundlesLegs = 0;
        for (int i = 0; i < 4; i++)
        {
            long bundle = long.Parse(Console.ReadLine());

            sumOfBundlesLegs += bundle * (i + 1);
        }

        long tableTops = long.Parse(Console.ReadLine());
        long tablesToBeMade = long.Parse(Console.ReadLine());

        if (tablesToBeMade < tableTops)
        {
            Console.WriteLine("more: {0}", tableTops - tablesToBeMade);
            Console.WriteLine("tops left: {0}, legs left: {1}", tableTops - tablesToBeMade, sumOfBundlesLegs - 4 * tablesToBeMade);
        }
        else if (tablesToBeMade > tableTops)
        {
            long legs = 0;
            long tops = 0;
            Console.WriteLine("less: {0}", tableTops - tablesToBeMade);
            if (sumOfBundlesLegs <= 4 * tablesToBeMade)
            {
                legs = 4 * tablesToBeMade - sumOfBundlesLegs;
            }
            if (tablesToBeMade >= tableTops)
            {
                tops = tablesToBeMade - tableTops;
            }
            Console.WriteLine("tops needed: {0}, legs needed: {1}", tops, legs);
        }
        else
        {
            Console.WriteLine("Just enough tables made: {0}", tablesToBeMade);
        }
    }
}