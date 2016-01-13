namespace _02.CompareAdvancedMathOper
{
    using System;
    using System.Diagnostics;

    public class Program
    {
        public static void Main()
        {
            int length = 100000000;

            Console.WriteLine("==Square root==");
            DisplayExecutionTime(() =>
            {
                double a = 0;

                for (int i = 0; i < length; i++)
                {
                    a = (double)Math.Sqrt(length);
                }

                Console.WriteLine("double: ");
            });

            DisplayExecutionTime(() =>
            {
                decimal a = 0;

                for (int i = 0; i < length; i++)
                {
                    a = (decimal)Math.Sqrt(length);
                }

                Console.WriteLine("decimal: ");
            });

            Console.WriteLine("\n == Natural logarithm == ");
            DisplayExecutionTime(() =>
            {
                double a = 0;

                for (int i = 0; i < length; i++)
                {
                    a = (double)Math.Log(length);
                }

                Console.WriteLine("double: ");
            });

            DisplayExecutionTime(() =>
            {
                decimal a = 0;

                for (int i = 0; i < length; i++)
                {
                    a = (decimal)Math.Log(length);
                }

                Console.WriteLine("decimal: ");
            });

            Console.WriteLine("\n == sinus == ");
            DisplayExecutionTime(() =>
            {
                double a = 0;

                for (int i = 0; i < length; i++)
                {
                    a = (double)Math.Sin(length);
                }

                Console.WriteLine("double: ");
            });

            DisplayExecutionTime(() =>
            {
                decimal a = 0;

                for (int i = 0; i < length; i++)
                {
                    a = (decimal)Math.Sin(length);
                }

                Console.WriteLine("decimal: ");
            });
        }

        public static void DisplayExecutionTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}
