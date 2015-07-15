using System;

class TicTacToePower
{
    static void Main()
    {
        int x = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());
        int number = int.Parse(Console.ReadLine());

        //int possition = x + 1; // 1 2 3
        //if (y == 1)
        //{
        //    possition = x + 4; // 4 5 6
        //}
        //if (y == 2)
        //{
        //    possition = x + 7; // 7 8 9
        //}
        
        //firstValue += possition - 1;
        //long sum = (long)Math.Pow(firstValue, possition);
        //Console.WriteLine(sum);

        int pow = 1;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                number++;
                if (i == y && j == x)
                {
                    Console.WriteLine((long)Math.Pow(number - 1, pow));
                    return;
                }
                pow++;
            }
        }
    }
}

