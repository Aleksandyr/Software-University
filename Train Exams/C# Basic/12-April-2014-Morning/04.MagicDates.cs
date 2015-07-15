using System;
using System.Text;

class Program
{
    static void Main()
    {
        string[] numbers = new string[8];
        for (int i = 0; i < 8; i++)
        {
            int number = int.Parse(Console.ReadLine());
            numbers[i] = Convert.ToString(number, 2).PadLeft(32, '0');
        }

        int xCounter = 0;
        for (int i = 0; i < numbers.Length - 2; i++)
        {
            for (int j = 0; j < 32 - 2; j++)
            {
                if (numbers[i].Substring(j, 3) == "101")
                {
                    if (numbers[i + 1].Substring(j, 3) == "010")
                    {
                        if (numbers[i + 2].Substring(j, 3) == "101")
                        {
                            xCounter++;
                        }
                    }
                }
            }
        }
        Console.WriteLine(xCounter);
    }
}

