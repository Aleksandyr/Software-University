using System;

class ExchangeVariableValues
{
    static void Main()
    {
        int a = 5;
        int b = 10;
        Console.WriteLine("a: " + a);
        Console.WriteLine("b: " + b);

        int change = a;
        a = b;
        b = change;

        Console.WriteLine("After exchange!");
        Console.WriteLine("a: " + a);
        Console.WriteLine("b: " + b);
    }
}

