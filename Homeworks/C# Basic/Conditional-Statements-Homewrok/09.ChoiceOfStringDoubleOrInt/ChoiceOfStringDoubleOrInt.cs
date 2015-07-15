using System;

class ChoiceOfStringDoubleOrInt
{
    static void Main()
    {
        Console.WriteLine("Please choose a type:");
        Console.WriteLine("1 --> int");
        Console.WriteLine("2 --> double");
        Console.WriteLine("3 --> string");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.Write("Please enter a int: ");
                int intDigit = int.Parse(Console.ReadLine());
                Console.WriteLine(intDigit + 1);
                break;
            case 2:
                Console.Write("Please enter a double: ");
                double doubleDigit = double.Parse(Console.ReadLine());
                Console.WriteLine(doubleDigit + 1);
                break;
            case 3:
                Console.Write("Please enter a int: ");
                string str = Console.ReadLine();
                Console.WriteLine(str + "*");
                break;

            default: Console.WriteLine("Incorrect input!");
                break;
        }
    }
}

