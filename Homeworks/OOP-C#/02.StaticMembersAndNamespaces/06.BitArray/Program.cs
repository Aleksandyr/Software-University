namespace Program
{
    using BitArrayInfo;
    using System;


    class Program
    {
        static void Main()
        {
            BitArray bitArr = new BitArray(7);
            bitArr[1] = 1;
            Console.WriteLine(bitArr);
        }
    }
}
