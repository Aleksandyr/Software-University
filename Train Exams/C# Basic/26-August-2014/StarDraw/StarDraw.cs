using System;

class StarDraw
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int dots = n;
        int dotsMiddle = 1;

        Console.WriteLine("{0}*{0}", new string('.', dots));

        for (int i = 0; i < n / 2 - 1; i++)
        {
            dots--;
            Console.WriteLine("{0}*{1}*{0}", new string('.', dots), new string('.', dotsMiddle));
            dotsMiddle += 2;
        }

        Console.WriteLine("{0}{1}{0}",new string('*', n / 2 + 1), new string('.', n - 1));

        dots = 1;
        dotsMiddle = n * 2 - 3;
        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('.', dots), new string('.', dotsMiddle));
            dots++;
            dotsMiddle -= 2;
        }

        dots = n / 2;
        dotsMiddle = n / 2 - 1;
        Console.WriteLine("{0}*{1}*{1}*{0}", new string('.', dots), new string('.', dotsMiddle));

        dots = n / 2 - 1;
        dotsMiddle = n / 2 - 1;
        int dotsbetweenmiddle = 1;
        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.WriteLine("{0}*{1}*{2}*{1}*{0}",new string('.', dots), new string('.', dotsMiddle), new string('.', dotsbetweenmiddle));
            dots--;
            dotsbetweenmiddle += 2;
        }

        Console.WriteLine("{0}{1}{0}", new string('*', n / 2 + 1), new string('.', n - 1));
    }
}

