using System;

class ExtractBitPosition3
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int nRigthP = n >> 3;
        int bit = nRigthP & 1;
        Console.WriteLine("bit #3 is: " + bit);
    }
}

