namespace EnvironmentSystem.Core
{
    using System;
    using EnvironmentSystem.Interfaces;

    class KeyboardController : IController
    {
        public event EventHandler Pause;

        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                var pressedKey = Console.ReadKey();
                if (pressedKey.Key == ConsoleKey.Spacebar)
                {
                    if (this.Pause != null)
                    {
                        this.Pause(this, new EventArgs());
                    }
                }
            }
        }
    }
}
