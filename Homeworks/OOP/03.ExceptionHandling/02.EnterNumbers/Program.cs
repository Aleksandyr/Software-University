namespace EnterNumbers
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main()
        {
            int start = 1;
            int end = 100;
            int num = 0;

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    num = ReadNumber(start, end);
                    start = num;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Invalid number!");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static int ReadNumber(int start, int end)
        {
            Console.WriteLine("Enter number between {0} and {1}", start, end);
            int number = int.Parse(Console.ReadLine());

            if (number <= start || number >= end)
            {
                throw new ArgumentOutOfRangeException("value", "Number should be greater than: " + start);
            }

            return number;
        }
    }
}
