using System;

class OddAndEvenElements
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] numbers = input.Split(' ');

        double oddSum = 0;
        double oddMax = double.MinValue;
        double oddMin = double.MaxValue;
        double evenSum = 0;
        double evenMax = double.MinValue;
        double evenMin = double.MaxValue;

        if (input == "")
        {
            numbers = new string[0];
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            double number = double.Parse(numbers[i]);

            if ((i + 1) % 2 == 0)
            {
                evenSum += number;

                if (number > evenMax)
                {
                    evenMax = number;
                }
                
                if (number < evenMin)
                {
                    evenMin = number;
                }
            }
            else
            {
                oddSum += number;

                if (number > oddMax)
                {
                    oddMax = number;
                }

                if (number < oddMin)
                {
                    oddMin = number;
                }
            }
        }
        if (numbers.Length == 0)
        {
            Console.WriteLine("OddSum=No, OddMin=No, OddMax=No, EvenSum=No, EvenMin=No, EvenMax=No");
        }
        else if (numbers.Length == 1)
        {
            Console.WriteLine("OddSum={0}, OddMin={1}, OddMax={2}, EvenSum=No, EvenMin=No, EvenMax=No", 
                oddSum, 
                oddMin, 
                oddMax);
        }
        else
        {
            Console.WriteLine("OddSum={0}, OddMin={1}, OddMax={2}, EvenSum={3}, EvenMin={4}, EvenMax={5}", 
                oddSum, 
                oddMin, 
                oddMax, 
                evenSum, 
                evenMin, 
                evenMax);
        }
    }
}

