namespace BitArray
{
    public class Program
    {
        static void Main()
        {
            BitArray bits = new BitArray(8);
            bits[0] = 1;
            bits[7] = 1;
            System.Console.WriteLine(bits);
        }
    }
}
