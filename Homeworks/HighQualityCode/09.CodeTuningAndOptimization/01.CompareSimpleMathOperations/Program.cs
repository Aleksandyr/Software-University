namespace CompareSimpleMathOperations
{
    using System;
    using System.Diagnostics;
    public class Program
    {
        static void Main()
        {
            int length = 100000000;

            Console.WriteLine("==Adding==");
            DisplayExecutionTime(() =>
            {
                int a = 0;

                for (int i = 0; i < length; i++)
                {
                    a += i;
                }

                Console.WriteLine("int: ");
            });

            DisplayExecutionTime(() =>
            {
                long a = 0L;

                for (int i = 0; i < length; i++)
                {
                    a += i;
                }

                Console.WriteLine("long: ");
            });

            DisplayExecutionTime(() =>
            {
                double a = 0d;

                for (int i = 0; i < length; i++)
                {
                    a += i;
                }

                Console.WriteLine("double: ");
            });

            DisplayExecutionTime(() =>
            {
                decimal a = 0;

                for (int i = 0; i < length; i++)
                {
                    a += i;
                }

                Console.WriteLine("decimal: ");
            });

            Console.WriteLine("==Subtracting==");

            DisplayExecutionTime(() =>
            {
                int a = 0;

                for (int i = 0; i < length; i++)
                {
                    a -= i;
                }

                Console.WriteLine("int: ");
            });

            DisplayExecutionTime(() =>
            {
                long a = 0l;

                for (int i = 0; i < length; i++)
                {
                    a -= i;
                }

                Console.WriteLine("long: ");
            });

            DisplayExecutionTime(() =>
            {
                double a = 0;

                for (int i = 0; i < length; i++)
                {
                    a -= i;
                }

                Console.WriteLine("double: ");
            });

            DisplayExecutionTime(() =>
            {
                decimal a = 0;

                for (int i = 0; i < length; i++)
                {
                    a += i;
                }

                Console.WriteLine("decimal: ");
            });

            Console.WriteLine("==Incrementing prefix==");

            DisplayExecutionTime(() =>
            {
                int a = 0;

                for (int i = 0; i < length; i++)
                {
                    a++;
                }

                Console.WriteLine("int: ");
            });

            DisplayExecutionTime(() =>
            {
                long a = 0;

                for (int i = 0; i < length; i++)
                {
                    a++;
                }

                Console.WriteLine("long: ");
            });

            DisplayExecutionTime(() =>
            {
                double a = 0;

                for (int i = 0; i < length; i++)
                {
                    a++;
                }

                Console.WriteLine("double: ");
            });

            DisplayExecutionTime(() =>
            {
                decimal a = 0;

                for (int i = 0; i < length; i++)
                {
                    a++;
                }

                Console.WriteLine("decimal: ");
            });

            Console.WriteLine("==Incrementing postfix==");

            DisplayExecutionTime(() =>
            {
                int a = 0;

                for (int i = 0; i < length; i++)
                {
                    ++a;
                }

                Console.WriteLine("int: ");
            });

            DisplayExecutionTime(() =>
            {
                long a = 0;

                for (int i = 0; i < length; i++)
                {
                    ++a;
                }

                Console.WriteLine("long: ");
            });

            DisplayExecutionTime(() =>
            {
                double a = 0;

                for (int i = 0; i < length; i++)
                {
                    ++a;
                }

                Console.WriteLine("double: ");
            });

            DisplayExecutionTime(() =>
            {
                decimal a = 0;

                for (int i = 0; i < length; i++)
                {
                    ++a;
                }

                Console.WriteLine("decimal: ");
            });

            Console.WriteLine("==Incrementing with 1==");

            DisplayExecutionTime(() =>
            {
                int a = 0;

                for (int i = 0; i < length; i++)
                {
                    a += 1;
                }

                Console.WriteLine("int: ");
            });

            DisplayExecutionTime(() =>
            {
                long a = 0;

                for (int i = 0; i < length; i++)
                {
                    a += 1;
                }

                Console.WriteLine("long: ");
            });

            DisplayExecutionTime(() =>
            {
                double a = 0;

                for (int i = 0; i < length; i++)
                {
                    a += 1;
                }

                Console.WriteLine("double: ");
            });

            DisplayExecutionTime(() =>
            {
                decimal a = 0;

                for (int i = 0; i < length; i++)
                {
                    a += 1;
                }

                Console.WriteLine("decimal: ");
            });

            Console.WriteLine("==Multiplying==");

            DisplayExecutionTime(() =>
            {
                int a = 1;

                for (int i = 0; i < length; i++)
                {
                    a *= 1;
                }

                Console.WriteLine("int: ");
            });

            DisplayExecutionTime(() =>
            {
                long a = 1;

                for (int i = 0; i < length; i++)
                {
                    a *= 1;
                }

                Console.WriteLine("long: ");
            });

            DisplayExecutionTime(() =>
            {
                double a = 1;

                for (int i = 0; i < length; i++)
                {
                    a *= 1;
                }

                Console.WriteLine("double: ");
            });

            DisplayExecutionTime(() =>
            {
                decimal a = 1;

                for (int i = 0; i < length; i++)
                {
                    a *= 1;
                }

                Console.WriteLine("decimal: ");
            });

            Console.WriteLine("==Dividing==");

            DisplayExecutionTime(() =>
            {
                int a = 1;

                for (int i = 0; i < length; i++)
                {
                    a /= 1;
                }

                Console.WriteLine("int: ");
            });

            DisplayExecutionTime(() =>
            {
                long a = 1;

                for (int i = 0; i < length; i++)
                {
                    a /= 1;
                }

                Console.WriteLine("long: ");
            });

            DisplayExecutionTime(() =>
            {
                double a = 1;

                for (int i = 0; i < length; i++)
                {
                    a /= 1;
                }

                Console.WriteLine("double: ");
            });

            DisplayExecutionTime(() =>
            {
                decimal a = 1;

                for (int i = 0; i < length; i++)
                {
                    a /= 1;
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
