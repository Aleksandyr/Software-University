using BookStore.Interfaces;
using System;
namespace BookStore.UI
{
    class ConsoleRenderer : IRenderer
    {

        public void WriteLine(string message, params string[] parameters)
        {
            Console.WriteLine(message, parameters);
        }
    }
}
