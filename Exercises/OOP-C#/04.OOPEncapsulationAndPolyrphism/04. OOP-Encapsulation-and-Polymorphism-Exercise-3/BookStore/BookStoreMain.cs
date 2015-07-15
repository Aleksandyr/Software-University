using System;
using BookStore.UI;

namespace BookStore
{
    using Engine;
    using BookStore.Books;

    public class BookStoreMain
    {
        public static void Main()
        {
            ConsoleRenderer render = new ConsoleRenderer();
            ConsoleInputHandler inputHandler = new ConsoleInputHandler();

            BookStoreEngine engine = new BookStoreEngine(render, inputHandler);

            engine.Run();
        }
    }
}
