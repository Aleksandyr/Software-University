using System;
using System.Linq;

namespace _01.MappingsDatabase
{
    class ContinetNames
    {
        static void Main()
        {
            var db = new GeographyEntities();
            var continentNames = db.Continents.Select(c => c.ContinentName).ToList();
            foreach (var continentName in continentNames)
            {
                Console.WriteLine(continentName);
            }
        }
    }
}
