using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using _01.MappingsDatabase;

namespace _03.MonasteriesByCountryAsXML
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new GeographyEntities();
            var countries = db.Countries
            .OrderBy(c => c.CountryName)
            .Select(c => new
            {
                coutryName = c.CountryName,
                monasteries = c.Monasteries.OrderBy(m => m.Name).Select(m => m.Name)
            }).ToList();

            XElement root = new XElement("monasteries");
            foreach (var country in countries)
            {
                if (country.monasteries.Count() != 0)
                {
                    var xmlCountry = new XElement("country");
                    xmlCountry.Add(new XAttribute("name", country.coutryName));
                    foreach (var xmlMonasteries in country.monasteries)
                    {
                        xmlCountry.Add(new XElement("monastery", xmlMonasteries));
                    }
                    root.Add(xmlCountry);   
                }
            }

            var xmlDoc = new XDocument(root);
            xmlDoc.Save("../../monasteries.xml");
        }
    }
}
