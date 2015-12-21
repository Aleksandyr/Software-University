namespace ISIS.IO
{
    using System;

    using ISIS.Interfaces;

    public class ConsoleWriter : IOutputWriter
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
