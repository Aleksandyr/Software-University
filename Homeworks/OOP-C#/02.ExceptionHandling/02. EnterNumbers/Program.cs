using System;

class Program
{
    static void Main()
    {
        int start = 1;
        int end = 100;
        for (int i = 1; i <= 10; i++)
        {
            start = ReadNumber(start, end);
        }
    }

    public static int ReadNumber(int start, int end)
    {
        int number = 0;

        try
        {
            Console.Write("Entered number:{0} < Your number < {1} : ", start, end);
            number = int.Parse(Console.ReadLine());
            if (!(start < number && number < end))
            {
                while (!(start < number && number < end))
                {
                    Console.WriteLine("Your number is not in range {0}-{1}", start, end);
                    Console.Write("Entered number:{0} < Your number < {1} : ", start, end);
                    number = int.Parse(Console.ReadLine());
                }
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number!");
        }

        return number;
    }
}

