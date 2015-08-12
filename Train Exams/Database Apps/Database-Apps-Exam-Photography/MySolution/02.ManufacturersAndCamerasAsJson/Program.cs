using System;
using System.Linq;
using System.Web.Script.Serialization;
using _01.PhotographyDatabaseFirst;
using System.IO;

namespace _02.ManufacturersAndCamerasAsJson
{
    class Program
    {
        static void Main()
        {
            var db = new PhotographySystemEntities();
            var manufacturerAndCamera = db.Manufacturers.Select(m => new
            {
                name = m.Name,
                camera = m.Cameras.Select(c => new
                {
                    c.Model,
                    c.Price
                })
                .OrderBy(c => c.Model)
            })
            .OrderBy(m => m.name)
            .ToList();

            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(manufacturerAndCamera);
            File.WriteAllText("../../manufactureres-and-cameras.json", json);
        }
    }
}
