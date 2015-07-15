using System;

class DoubleDowns
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        int leftCounter = 0;
        int rightCounter = 0;
        int verticalCounter = 0;
        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            numbers[i] = number;
        }

        for (int i = 0; i < n - 1; i++)
        {
            int number1 = numbers[i];
            int number2 = numbers[i + 1];
            for (int j = 0; j < 32; j++)
            {
                bool right = ((number1 >> j + 1 & 1) & (number2 >> j & 1)) == 1;
                bool left = ((number1 >> j & 1) & (number2 >> j + 1 & 1)) == 1;
                bool vertical = ((number1 >> j & 1) & (number2 >> j & 1)) == 1;
                if (right)
                {
                    rightCounter++;
                }
                if (left)
                {
                    leftCounter++;
                }
                if (vertical)
                {
                    verticalCounter++;
                }
            }
        }
        Console.WriteLine(rightCounter);
        Console.WriteLine(leftCounter);
        Console.WriteLine(verticalCounter);
    }
}

