using System;
using BookStore.Interfaces;

namespace BookStore.UI
{
    class ConsoleInputHandler : IInputHandler
    {

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
