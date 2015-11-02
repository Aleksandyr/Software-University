using System;
using System.Linq;

namespace _01.DiabloDatabaseFirst
{
    class Program
    {
        static void Main()
        {
            var db = new DiabloEntities();
            var characters = db.Characters.Select(c => c.Name).ToList();
            foreach (var character in characters)
            {
                Console.WriteLine(character);
            }
        }
    }
}
