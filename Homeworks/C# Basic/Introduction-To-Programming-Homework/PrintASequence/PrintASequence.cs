using System;

class PrintASequence
{
    static void Main()
    {
        for (int i = 2; i < 12; i++)
        {
            if (i % 2 != 0)
            {
                if (i == 11)
                {
                    Console.Write("{0}", -i);
                    break;
                }
                Console.Write("{0}, ", -i);
            }
            else
            {
                Console.Write("{0}, ", i);
            }  
        }
        Console.WriteLine();
    }
}

