using System;

class BitSifting
{
    static void Main()
    {
        ulong bits = ulong.Parse(Console.ReadLine());
        int sieves = int.Parse(Console.ReadLine());

        for (int i = 0; i < sieves; ++i)
        {
            ulong sieve = ulong.Parse(Console.ReadLine());
            bits = bits & (~sieve);
        }

        // Now count the bits
        ulong bitsCount = 0;
        while (bits > 0)
        {
            bitsCount += (bits & 1);
            bits = bits >> 1;
        }

        Console.WriteLine(bitsCount);

        //ulong startNumber = ulong.Parse(Console.ReadLine());
        //int numberToSeave = int.Parse(Console.ReadLine());
        //int counter = 0;
        //ulong one = 1;

        //for (int i = 0; i < numberToSeave; i++)
        //{
        //    ulong readNumber = ulong.Parse(Console.ReadLine());

        //    for (int j = 0; j < 64; j++)
        //    {
        //        ulong mask = one << j;
        //        ulong res = readNumber & mask;

        //        if (res > 0)
        //        {
        //            startNumber &= ~mask;
        //        }
        //    }
        //}

        //for (int i = 0; i < 64; i++)
        //{
        //    if ((startNumber & (one << i)) > 0)
        //    {
        //        counter++;
        //    }
        //}
        //Console.WriteLine(counter);
    }
}