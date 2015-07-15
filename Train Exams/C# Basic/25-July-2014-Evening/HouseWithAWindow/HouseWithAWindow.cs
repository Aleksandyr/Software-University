using System;

class HouseWithAWindow
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int starsBefore = n - 1;
        int starsMiddle = 1;

        Console.WriteLine("{0}*{0}", new string('.', starsBefore));
        for (int i = 0; i < n - 1; i++)
        {
            starsBefore -= 1;
            Console.WriteLine("{0}*{1}*{0}", new string('.', starsBefore), new string('.', starsMiddle));
            starsMiddle += 2;
        }

        int dotsBetweenWindow = n / 2;
        int windowStars = n - 3;

        Console.WriteLine("{0}", new string('*', 2 * n - 1));
        for (int i = 0; i < n / 4; i++)
        {
            Console.WriteLine("*{0}*", new string('.', 2 * n - 3));
        }
        
        for (int i = 0; i < n / 2; i++)
        {
            Console.WriteLine("*{0}{1}{0}*", new string('.', dotsBetweenWindow), new string('*', windowStars));
        }

        for (int i = 0; i < n / 4; i++)
        {
            Console.WriteLine("*{0}*", new string('.', 2 * n - 3));
        }
        Console.WriteLine("{0}", new string('*', 2 * n - 1));
    }
}

