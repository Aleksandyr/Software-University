namespace Empires.IO
{
    using System;

    using Empires.Interfaces;
    
    class ConsoleReader : IInputReader
    {
        public string ReadLine()
        {
            var input = Console.ReadLine();

            return input;
        }
    }
}
