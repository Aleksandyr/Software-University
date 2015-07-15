﻿using System;

class DrawSungalsses
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("{0}{1}{0}", new string('*', 2 * n), new string(' ', n));

        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.WriteLine("*{0}*{1}*{0}*", new string('/', 2 * n - 2), new string(' ', n));
        }

        Console.WriteLine("*{0}*{1}*{0}*", new string('/', 2 * n - 2), new string('|', n));

        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.WriteLine("*{0}*{1}*{0}*", new string('/', 2 * n - 2), new string(' ', n));
        }

        Console.WriteLine("{0}{1}{0}", new string('*', 2 * n), new string(' ', n));
    }
}

