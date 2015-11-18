namespace SquareRoot
{
    using System;

    public class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Enter your number: ");
                int number = int.Parse(Console.ReadLine());

                if (number < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Invalid number!");
                }

                Console.WriteLine("Square root: " + Math.Sqrt(number));
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid number!");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Good bye!");
            }
        }
    }
}
