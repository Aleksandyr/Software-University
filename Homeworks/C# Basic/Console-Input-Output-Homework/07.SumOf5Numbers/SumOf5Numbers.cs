using System;

class SumOf5Numbers
{
    static void Main()
    {
        string[] numbers = new string[5];
        do
        {
            Console.WriteLine("Your input should be exactly 5 numbers!");
            string input = Console.ReadLine();
            numbers = input.Split(' ');   
        } 
        while (numbers.Length > 5 || numbers.Length < 5);

        double sum = 0;
        for (int i = 0; i < 5; i++)
        {
            sum += Convert.ToDouble(numbers[i]);
        }
        Console.WriteLine("The sum is: " + sum);
    }
}

