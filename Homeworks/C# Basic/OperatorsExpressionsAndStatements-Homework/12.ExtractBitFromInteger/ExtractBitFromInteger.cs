using System;

class ExtractBitFromInteger
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        int nRigthP = n >> p;
        int bit = nRigthP & 1;
        Console.WriteLine("bit @ p: " + bit);
    }
}

