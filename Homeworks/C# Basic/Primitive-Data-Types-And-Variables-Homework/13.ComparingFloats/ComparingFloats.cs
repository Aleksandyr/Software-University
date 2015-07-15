using System;

class ComparingFloats
{
    static void Main()
    {
        Console.Write("First number: ");
        decimal firstNumber = decimal.Parse(Console.ReadLine());

        Console.Write("Second number: ");
        decimal secondNumber = decimal.Parse(Console.ReadLine());

        decimal eps = 0.000001m;

        bool areEqual = Math.Abs(firstNumber - secondNumber) < eps;

        Console.WriteLine(areEqual);
    }
}

