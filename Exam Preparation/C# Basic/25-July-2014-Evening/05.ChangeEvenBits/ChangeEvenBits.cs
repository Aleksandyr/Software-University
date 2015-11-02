using System;

class ChangeEvenBits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        ulong l = ulong.Parse(Console.ReadLine());

        ulong one = 1;
        ulong result = 0;
        int changeBitsCount = 0;
        for (int i = 0; i < n; i++)
        {

            string number = Convert.ToString(numbers[i], 2);
            for (int j = 0; j < number.Length * 2; j += 2)
            {
                ulong mask = one << j;
                result |= mask | l;
            }
        }

        string resLength = Convert.ToString((int)result, 2);
        for (int i = 0; i < resLength.Length; i++)
        {
            if (((result >> i) & 1) != ((l >> i) & 1))
            {
                changeBitsCount++;
            }
        }

        Console.WriteLine(result);
        Console.WriteLine(changeBitsCount);

        //second variant

        //int n = int.Parse(Console.ReadLine());
        //int[] nums = new int[n];
        //for (int i = 0; i < nums.Length; i++)
        //{
        //    nums[i] = int.Parse(Console.ReadLine());
        //}
        //ulong lastInput = ulong.Parse(Console.ReadLine());
        //const ulong one = 1;
        //int changedBits = 0;

        //for (int i = 0; i < nums.Length; i++)
        //{
        //    int num = nums[i];
        //    int len = 0;
        //    do
        //    {
        //        num = num / 2;
        //        len++;
        //    } while (num > 0);

        //    int bitPosition = 0;
        //    while (len > 0)
        //    {
        //        ulong mask = one << bitPosition;
        //        if ((lastInput & mask) == 0)
        //        {
        //            changedBits++;
        //        }
        //        lastInput |= mask;
        //        bitPosition += 2;
        //        len--;
        //    }
        //}

        //Console.WriteLine(lastInput);
        //Console.WriteLine(changedBits);
    }
}