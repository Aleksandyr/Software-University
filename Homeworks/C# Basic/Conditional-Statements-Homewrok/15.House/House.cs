using System;

class House
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("{0}*{0}", new string('.', n / 2));

        int dots = n / 2 - 1;
        int middleDots = 1;
        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('.', dots), new string('.', middleDots));
            dots--;
            middleDots += 2;
        }

        Console.WriteLine("{0}", new string('*', n));

        int wallDistance = n / 4;
        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('.', wallDistance), new string('.', n - 2 * wallDistance - 2));
        }

        Console.WriteLine("{0}{1}{0}", new string('.', wallDistance), new string('*', n - 2 * wallDistance));
    }
}

