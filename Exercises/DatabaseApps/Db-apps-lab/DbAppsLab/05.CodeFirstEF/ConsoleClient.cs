using System;
using System.Data.Entity;
using System.Linq;
using Mountains.Data;

namespace _05.CodeFirstEF
{
    class ConsoleClient
    {
        static void Main()
        {
            //Database.SetInitializer(new MountainsMigrationsStrategy());

            var db = new MountainsEntities();
            Console.WriteLine(db.Peaks.Count());

            var Countries = db.Countries
            .OrderBy(c => c.ContryName)
            .Select(c => new
            {
                countriesName = c.ContryName,
                mountains = c.Mountains.Select(m => new
                {
                    mountainName = m.MountainName,
                    peaks = m.Peakses.Select(p => new
                    {
                        peakName = p.Name,
                        elevation = p.Elevation
                    })
                })
            }).ToList();

            foreach (var contry in Countries)
            {
                Console.WriteLine("Contry: " + contry.countriesName);
                foreach (var mountain in contry.mountains)
                {
                    Console.WriteLine(" Mountain: " + mountain.mountainName);
                    foreach (var peak in mountain.peaks)
                    {
                        Console.WriteLine("     Peaks: {0} ({1}) ",peak.peakName, peak.elevation);
                    }
                }
            }
        }
    }
}
