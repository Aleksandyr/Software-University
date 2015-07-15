using System;

class StringsAndObjects
{
    static void Main()
    {
        string hello = "Hello";
        string world = "World";
        object result = hello + " " + world;
        string greeting = (string)result;
        Console.WriteLine(greeting);

    }
}

