using System;

class BitsUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());

        string wholeNum = "";
        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            string currNum = "";
            for (int j = 0; j < 8; j++)
            {
                int lastDigit = (number & (1 << j)) >> j;
                currNum = lastDigit + currNum;
            }
            wholeNum += currNum;
        }

        char[] numbers = wholeNum.ToCharArray();
        for (int i = 0; i < numbers.Length; i++)
        {
            int possitio = 1 + i * step;
            if (possitio > numbers.Length - 1)
            {
                break;
            }
            numbers[possitio] = '1';

        }

        string num = "";
        for (int i = 0; i < wholeNum.Length; i++)
        {
            num += numbers[i];
            if ((i + 1) % 8 == 0)
            {
                int result = Convert.ToInt32(num, 2);
                Console.WriteLine(result);
                num = "";
            }
        }

        //int n = int.Parse(Console.ReadLine());
        //int step = int.Parse(Console.ReadLine());
        //int index = 0;
        //for (int i = 0; i < n; i++)
        //{
        //    int num = int.Parse(Console.ReadLine());
        //    for (int bit = 7; bit >= 0; bit--)
        //    {
        //        if ((index % step == 1) || (step == 1 && index > 0))
        //        {
        //            num = num | (1 << bit);
        //        }
        //        index++;
        //    }
        //    Console.WriteLine(num);
        //}

    }
}
