using System;
using System.Linq;

namespace _01.PhotographyDatabaseFirst
{
    class Program
    {
        static void Main()
        {
            var context = new PhotographySystemEntities();
            var cameras = context.Cameras.Select(c => new
            {
                manufacturerName = c.Manufacturer.Name,
                model = c.Model
            })
            .OrderBy(c => c.manufacturerName)
            .ThenBy(c => c.model)
            .ToList();

            foreach (var camera in cameras)
            {
                Console.WriteLine(camera.manufacturerName + " " + camera.model);
            }
        }
    }
}
