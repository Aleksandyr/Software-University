using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter your number: ");
            int number = int.Parse(Console.ReadLine());

            if(number < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Console.WriteLine("Number: {0} Square root: {1}", Math.Sqrt(number), number);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number!");
        }
        catch(ArgumentOutOfRangeException)
        {
            Console.WriteLine("Number must be positive!");
        }
        finally
        {
            Console.WriteLine("Good bye.");
        }
    }
}

