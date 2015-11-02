using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using _01.PhotographyDatabaseFirst;

namespace _04.ManufacturerAndLensesFromXml
{
    class Program
    {
        static void Main()
        {
            var xmlDoc = XDocument.Load("../../manufacturers-and-lenses.xml");
            var xManufacturers = xmlDoc.XPathSelectElements("manufacturers-and-lenses/manufacturer");
            var contex = new PhotographySystemEntities();
            int processing = 1;
            foreach (var manufacturerXml in xManufacturers)
            {
                Console.WriteLine("Processing manufacturer #{0} ...", processing++);
                var manufacturer = new Manufacturer();
                var manufacturerName = manufacturerXml.Element("manufacturer-name");
                if (manufacturerName != null)
                {
                    if (!contex.Manufacturers.Any(m => m.Name == manufacturerName.Value))
                    {
                        contex.Manufacturers.Add(new Manufacturer()
                        {
                            Name = manufacturerName.Value
                        });
                        contex.SaveChanges();
                        Console.WriteLine("Created manufacturer: {0}", manufacturerName.Value);
                    }
                    else
                    {
                        Console.WriteLine("Existing manufacturer: {0}", manufacturerName.Value);
                        manufacturer = contex.Manufacturers.FirstOrDefault(m => m.Name == manufacturerName.Value);
                    }
                }
                var xLenses = manufacturerXml.XPathSelectElements("lenses/lens");
                foreach (var lensXml in xLenses)
                {
                    var model = lensXml.Attribute("model");
                    var type = lensXml.Attribute("type");
                    var price = lensXml.Attribute("price");
                    var lens = contex.Lenses.FirstOrDefault(l => l.Model == model.Value);
                    if (lens != null)
                    {
                        Console.WriteLine("Existing lens: {0}", model.Value);
                    }
                    else
                    {
                        contex.Lenses.Add(new Lens()
                        {
                            Model = model.Value,
                            Type = type.Value,
                            Price = (price != null) ? decimal.Parse(price.Value) : default(decimal?),
                            ManufacturerId = manufacturer.Id
                        });
                        contex.SaveChanges();
                        Console.WriteLine("Created lens: {0}", model.Value);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
