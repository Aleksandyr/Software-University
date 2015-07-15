using System;

class WinningNumbers
{
    static void Main()
    {
        //My decision
        string s = Console.ReadLine().ToLower();

        int sum = 0;
        for (int i = 0; i < s.Length; i++)
        {
            sum += (char)s[i] - 96;
        }

        bool haveWinnigNumber = false;
        for (int i = 111; i < 999; i++)
        {
            for (int j = 111; j < 999; j++)
            {
                if ((i % 10) * ((i / 10) % 10) * ((i / 100) % 10) == sum &&
                    (j % 10) * ((j / 10) % 10) * ((j / 100) % 10) == sum)
                {
                    Console.WriteLine(i + "-" + j);
                    haveWinnigNumber = true;
                }
            }
        }

        if (!haveWinnigNumber)
        {
            Console.WriteLine("No");
        }




    //    string letters = Console.ReadLine().ToUpper();

    //    int letSum = SumOfLetter(letters);

    //    int sum1 = 1;
    //    int sum2 = 1;
    //    int count = 0;
    //    for (int i1 = 0; i1 < 999; i1++)
    //    {
    //        sum1 = (i1 % 10) * ((i1 / 10) % 10) * ((i1 / 100) % 10);
    //        for (int i2 = 0; i2 < 999; i2++)
    //        {
    //            sum2 = (i2 % 10) * ((i2 / 10) % 10) * ((i2 / 100) % 10);
    //            if (sum1 == letSum && sum2 == letSum)
    //            {
    //                Console.WriteLine(i1 + "-" + i2);
    //                count++;
    //            }
    //        }
    //    }
    //    if (count == 0)
    //    {
    //        Console.WriteLine("No");
    //    }
    //}


    //private static int SumOfLetter(string str)
    //{
    //    int sum = 0;
    //    foreach (var chr in str)
    //    {
    //        sum += (int)chr - 64;
    //    }
    //    return sum;
    //}
}

