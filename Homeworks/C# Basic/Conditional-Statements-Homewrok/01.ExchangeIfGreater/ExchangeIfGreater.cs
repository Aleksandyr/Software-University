using System;

class ExchangeIfGreater
{
    static void Main()
    {
        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());

        if (firstNumber > secondNumber)
        {
            double changeNumber = firstNumber;
            firstNumber = secondNumber;
            secondNumber = changeNumber;
        }

        Console.WriteLine(firstNumber + " " + secondNumber);
    }
}

