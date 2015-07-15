using System;

class MultiplicationSign
{
    static void Main()
    {
        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());
        double thirdNumber = double.Parse(Console.ReadLine());

        if (firstNumber == 0 || secondNumber == 0 || thirdNumber == 0)
        {
            Console.WriteLine("0");
        }
        else if (firstNumber > 0)
        {
            if (secondNumber > 0 && thirdNumber > 0)
            {
                Console.WriteLine("+");
            }
            else if (secondNumber < 0 && thirdNumber < 0)
            {
                Console.WriteLine("+");
            }
            else
            {
                Console.WriteLine("-");
            }
        }
        else
        {
            if (secondNumber > 0 && thirdNumber > 0)
            {
                Console.WriteLine("-");
            }
            else if (secondNumber < 0 && thirdNumber < 0)
            {
                Console.WriteLine("-");
            }
            else
            {
                Console.WriteLine("+");
            }
        }
    }
}


