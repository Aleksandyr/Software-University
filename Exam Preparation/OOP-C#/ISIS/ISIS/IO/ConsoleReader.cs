namespace ISIS.IO
{
    using System;

    using ISIS.Interfaces;

    public class ConsoleReader : IInputReader
    {
        public string ReadLine()
        {
            var input = Console.ReadLine();

            return input;
        }
    }
}
