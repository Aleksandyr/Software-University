namespace PcCatalog
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            List<Component> components = new List<Component>()
            {
                new Component("processor", (decimal)150),
                new Component("graphic card", (decimal)250),
            };

            Computer comp = new Computer("pc", (decimal)699.00, components);
            Console.WriteLine(comp);
        }
    }
}
