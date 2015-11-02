using System;
using System.Numerics;

class SimpleLoop
{
    static void Main()
    {
        BigInteger t1 = BigInteger.Parse(Console.ReadLine());
        BigInteger t2 = BigInteger.Parse(Console.ReadLine());
        BigInteger t3 = BigInteger.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        if (n == 1)
        {
            Console.WriteLine(t1);
        }

        else if (n == 2)
        {
            Console.WriteLine(t2);
        }

        else if (n == 3)
        {
            Console.WriteLine(t3);
        }

        else
        {
            BigInteger sum = 0;
            for (int i = 4; i <= n; i++)
            {
                sum = t1 + t2 + t3;
                BigInteger tn = sum;
                t1 = t2;
                t2 = t3;
                t3 = tn;
            }

            Console.WriteLine(sum);
        }
    }
}
