using System;

class XBits
{
    static void Main()
    {
        int[] numbers = new int[8];

        for (int i = 0; i < 8; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int xCounter = 0;
        for (int i = 0; i < numbers.Length - 2; i++)
        {
            for (int j = 0; j < 32; j++)
            {
                bool upX = ((numbers[i] >> j) & 7) == 5;
                bool middleX = ((numbers[i + 1] >> j) & 7) == 2;
                bool downX = ((numbers[i + 2] >> j) & 7) == 5;

                if (upX && middleX && downX)
                {
                    xCounter++;
                }
            }
        }

        Console.WriteLine(xCounter);


        //Other decision
        //string[] numbers = new string[8];
        //for (int i = 0; i < 8; i++)
        //{
        //    int number = int.Parse(Console.ReadLine());
        //    numbers[i] = Convert.ToString(number, 2).PadLeft(32, '0');
        //}

        //int xCounter = 0;
        //for (int i = 0; i < numbers.Length - 2; i++)
        //{
        //    for (int j = 0; j < 32 - 2; j++)
        //    {
        //        if (numbers[i].Substring(j, 3) == "101")
        //        {
        //            if (numbers[i + 1].Substring(j, 3) == "010")
        //            {
        //                if (numbers[i + 2].Substring(j, 3) == "101")
        //                {
        //                    xCounter++;
        //                }
        //            }
        //        }
        //    }
        //}
        //Console.WriteLine(xCounter);
    }
}