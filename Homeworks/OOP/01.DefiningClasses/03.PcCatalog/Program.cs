namespace PcCatalog
{
    using System;
    using System.Linq;
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

            List<Computer> computer = new List<Computer>()
            {
                new Computer("pc1", (decimal)699.00, components),
                new Computer("pc2", (decimal)1000.00),
                new Computer("pc3", (decimal)500.00),
            };

            var sortedComputer = computer.OrderBy(x => x.AllPrice);

            foreach (var comp in sortedComputer)
	        {
		        Console.WriteLine(comp);
	        }
        }
    }
}
