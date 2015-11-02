using System;
using System.Linq;
using System.Xml.Linq;
using _01.PhotographyDatabaseFirst;
using System.IO;

namespace _03.ExportPhotographsAsXML
{
    class Program
    {
        static void Main()
        {
            var db = new PhotographySystemEntities();

            var photographs = db.Photographs.Select(p => new
            {
                title = p.Title,
                categoryName = p.Category.Name,
                link = p.Link,
                megaPixel = p.Equipment.Camera.Megapixels,
                equipmentName = p.Equipment.Camera.Manufacturer.Name + " " + p.Equipment.Camera.Model,
                lensPrice = p.Equipment.Lens.Price,
                lensName = p.Equipment.Camera.Manufacturer.Name + " " + p.Equipment.Lens.Model

            })
            .OrderBy(p => p.title)
            .ToList();

            var root = new XElement("photographs");
            foreach (var photograph in photographs)
            {
                var photographXml = new XElement("photograph");
                photographXml.Add(new XAttribute("title", photograph.title));
                photographXml.Add(new XElement("category", photograph.categoryName));
                photographXml.Add(new XElement("link", photograph.link));
                var equipmentXml = new XElement("equipment");
                equipmentXml.Add(new XElement("camera", photograph.equipmentName, new XAttribute("megapixels", photograph.megaPixel)));
                if (photograph.lensPrice.HasValue)
                {
                    equipmentXml.Add(new XElement("lens", photograph.lensName, new XAttribute("price", photograph.lensPrice)));
                }
                else
                {
                    equipmentXml.Add(new XElement("lens", photograph.lensName));
                }

                photographXml.Add(equipmentXml);
                root.Add(photographXml);
            }

            var xmlDoc = new XDocument(root);
            xmlDoc.Save("../../photographs.xml");
        }
    }
}
