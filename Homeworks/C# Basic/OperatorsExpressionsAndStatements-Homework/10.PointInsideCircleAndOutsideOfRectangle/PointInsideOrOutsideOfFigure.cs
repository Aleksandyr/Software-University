using System;

class PointInsideOrOutsideOfFigure
{
    static void Main()
    {
        float x = float.Parse(Console.ReadLine());
        float y = float.Parse(Console.ReadLine());

        bool isInsideCircle = Math.Pow((x - 1), 2) + Math.Pow((y - 1), 2) <= 1.5 * 1.5;
        bool isInsideRectangle = x > 2 || x < 6 && y > -1 || y < 2;

        if (x == 0 || y == 0)
        {
            Console.WriteLine("no");
        }
        else if (isInsideCircle == true && isInsideRectangle == true)
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}

