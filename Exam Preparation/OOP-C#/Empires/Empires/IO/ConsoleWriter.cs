namespace Empires.IO
{
    using System;

    using Empires.Interfaces;

    public class ConsoleWriter : IOuptupWriter
    {
        public void Print(string message)
        {
 	        Console.WriteLine(message);
        }
    }
}
