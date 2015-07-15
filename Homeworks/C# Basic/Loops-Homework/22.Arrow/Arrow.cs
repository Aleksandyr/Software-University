using System;

class Arrow
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("{0}{1}{0}", new string('.', n / 2), new string('#', n));
        for (int i = 0; i < n - 2; i++)
        {
            Console.WriteLine("{0}#{1}#{0}", new string('.', n / 2), new string('.', n - 2));
        }

        Console.WriteLine("{0}{1}{0}", new string('#', n / 2 + 1), new string('.', n - 2));

        int dots = 1;
        int middleDots = n * 2 - 5;
        for (int i = 0; i < n - 2; i++)
        {
            Console.WriteLine("{0}#{1}#{0}", new string('.', dots), new string('.', middleDots));
            dots++;
            middleDots -= 2;
        }

        Console.WriteLine("{0}#{0}", new string('.', n - 1));
    }
}

