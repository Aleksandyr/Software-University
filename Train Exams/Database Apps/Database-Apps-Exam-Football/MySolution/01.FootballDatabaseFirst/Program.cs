using System;
using System.Linq;

namespace _01.FootballDatabaseFirst
{
    class Program
    {
        static void Main()
        {
            var db = new FootballEntities();
            var temNames = db.Teams.Select(t => t.TeamName).ToList();
            foreach (var temName in temNames)
            {
                Console.WriteLine(temName);
            }
        }
    }
}
