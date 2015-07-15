using System;

class DrawFigure
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int star = n;
        int dot = 0;
        while (true)
        {
            DrawFig(star, dot);
            star -= 2;
            dot++;
            if (star == -1)
            {
                break;
            }
            Console.WriteLine();
        }

        Console.WriteLine();

        star = 3;
        dot = (n - star) / 2;
        while (true)
        {
            DrawFigBack(star, dot);
            star += 2;
            dot--;
            Console.WriteLine();
            if (dot == -1)
            {
                break;
            }
        }

        Console.WriteLine();
    }

    private static void DrawFig(int star, int dot)
    {
        for (int i = 0; i < dot; i++)
        {
            Console.Write(".");
        }
        for (int i = 0; i < star; i++)
        {
            Console.Write("*");
        }
        for (int i = 0; i < dot; i++)
        {
            Console.Write(".");
        }
    }

    private static void DrawFigBack(int star, int dot)
    {
        for (int i = 0; i < dot; i++)
        {
            Console.Write(".");
        }
        for (int i = 0; i < star; i++)
        {
            Console.Write("*");
        }
        for (int i = 0; i < dot; i++)
        {
            Console.Write(".");
        }
    }

}

