using System;

class FormattingNumbers
{
    static void Main()
    {
        int firstNumber;
        do
        {
            Console.Write("First number should be between [0...500]: ");
            firstNumber = int.Parse(Console.ReadLine());    
        } 
        while (firstNumber < 0 || firstNumber > 500);

        Console.Write("Second number: ");
        float secondNumber = float.Parse(Console.ReadLine());
        Console.Write("Third number: ");
        float thirdNumber = float.Parse(Console.ReadLine());

        Console.Write("|{0}|{1}|",
            Convert.ToString(firstNumber, 16).ToUpper().PadRight(10),
            Convert.ToString(firstNumber, 2).PadLeft(10, '0'));

        if (Convert.ToString(secondNumber).IndexOf(".") > 0)
        {
            Console.Write("{0,10:F2}|", secondNumber);
        }
        else
        {
            Console.Write("{0,10}|", secondNumber);
        }

        if (Convert.ToString(thirdNumber).IndexOf(".") > 0)
        {
            Console.Write("{0,-10:F3}|", thirdNumber);
        }
        else
        {
            Console.Write("{0,-10}|", thirdNumber);
        }

        Console.WriteLine();
    }
}

