using System;

class TheExplorer
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("{0}*{0}", new string('-', n / 2));

        int dash = n / 2 - 1;
        int dashMiddle = 1;
        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('-', dash), new string('-', dashMiddle));
            dash--;
            dashMiddle += 2;
        }

        Console.WriteLine("*{0}*", new string('-', n - 2));

        dash = 1;
        dashMiddle = n - 4;
        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('-', dash), new string('-', dashMiddle));
            dash++;
            dashMiddle -= 2;
        }

        Console.WriteLine("{0}*{0}", new string('-', n / 2));
    }
}

