using System;

class NewHouse
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("{0}*{0}", new string('-', n / 2));

        int dash = n / 2 - 1;
        int stars = 3;
        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.WriteLine("{0}{1}{0}", new string('-', dash), new string('*', stars));
            dash--;
            stars += 2;
        }

        Console.WriteLine("{0}", new string('*', n));

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("{0}{1}{0}", new string('|', 1), new string('*', n - 2));
        }
    }
}

