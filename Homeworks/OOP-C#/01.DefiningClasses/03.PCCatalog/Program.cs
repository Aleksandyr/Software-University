using PC;
using System;
using System.Collections.Generic;
using ComponentsInfo;

namespace PCCatalog
{
    class Program
    {
        static void Main()
        {
            Component processor = new Component("processor", 200, "asdfaesfsd");
            Component ram = new Component("ram", 100, "1GB");
            Component graphicCard = new Component("graphic Card", 300, "NVIDIA");
            Component hdd = new Component("HDD", 200);
            Component screen = new Component("screen", 100);
            List<Computer> comps = new List<Computer>
            {
                new Computer("Alex", processor, ram, graphicCard, hdd),
                new Computer("Tosho", processor, ram),  
                new Computer("Gosho", processor, ram, graphicCard, hdd, screen),
                new Computer("Ivo", processor, ram, graphicCard),
                new Computer("Pesho", processor),
            };

            comps.Sort((x, y) => x.Price.CompareTo(y.Price));

            foreach (var pc in comps)
            {
                Console.WriteLine(pc);
            }
        }
    }
}
