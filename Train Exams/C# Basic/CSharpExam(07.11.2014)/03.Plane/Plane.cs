using System;

class Plane
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("{0}*{0}", new string('.', (n * 3) / 2));

        int dots = (n * 3) / 2 - 1;
        int dotsMiddle = 1;
        for (int i = 0; i < n - (n / 2 - 1); i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('.', dots), new string('.', dotsMiddle));
            dots--;
            dotsMiddle += 2;
        }

        dots--;
        dotsMiddle += 2;
        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('.', dots), new string('.', dotsMiddle));
            dots -= 2;
            dotsMiddle += 4; 
        }

        dots = n - 2;
        dotsMiddle = n;
        int checkDots = 1;
        int checkIfBiggerThanFive = 0;
        for (int i = 0; i < (n / 2) - 1; i++)
        {         
            if (checkIfBiggerThanFive > 0)
            {
                dots -= 2;
                Console.WriteLine("*{0}*{1}*{2}*{1}*{0}*", new string('.', dots), new string('.', checkDots),new string('.', dotsMiddle));
                checkDots += 2;
            }
            else
            {
                Console.WriteLine("*{0}*{1}*{0}*", new string('.', dots), new string('.', dotsMiddle));
            }
            checkIfBiggerThanFive++;
        }

        dots = 1;
        //checkDots = n / 2 - 1;
        dotsMiddle = n;
        Console.WriteLine("*{0}*{1}*{2}*{1}*{0}*", new string('.', dots), new string('.', checkDots), new string('.', dotsMiddle));

        dots = n - 1;
        dotsMiddle = n;
        for (int i = 0; i < n - 1; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('.', dots), new string('.', dotsMiddle));
            dots--;
            dotsMiddle += 2;
        }

        Console.WriteLine("{0}", new string('*', 3 * n));
    }
}

