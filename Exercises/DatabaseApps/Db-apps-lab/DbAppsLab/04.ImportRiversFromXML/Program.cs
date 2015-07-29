using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using _01.MappingsDatabase;

namespace _04.ImportRiversFromXML
{
    class Program
    {
        static void Main()
        {
            var db = new GeographyEntities();

            var xmlDoc = XDocument.Load("../../rivers.xml");
            var elements = xmlDoc.XPathSelectElements("rivers/river");
            foreach (var element in elements)
            {
                string riverName = element.Element("name").Value;
                int length = Convert.ToInt32(element.Element("length").Value);
                string outflow = element.Element("outflow").Value;
                
                int? drainAgeArea = null;
                if (element.Element("drainage-area") != null)
                {
                    drainAgeArea = Convert.ToInt32(element.Element("drainage-area").Value);
                }

                int? averageDischarge = null;
                if (element.Element("average-discharge") != null)
                {
                    drainAgeArea = Convert.ToInt32(element.Element("average-discharge").Value);
                }

                Console.WriteLine("{0} - {1} - {2} - {3} - {4}", riverName, length, outflow, drainAgeArea, averageDischarge);
                
                var river = new River()
                {
                    RiverName = riverName,
                    Length = length,
                    Outflow = outflow,
                    AverageDischarge = averageDischarge,
                    DrainageArea = drainAgeArea
                };

                db.Rivers.Add(river);

                var countryNodes = element.XPathSelectElements("countries/country");
                var countryRiverNames = countryNodes.Select(c => c.Value);
                foreach (var countryName in countryRiverNames)
                {
                    var country = db.Countries.FirstOrDefault(c => c.CountryName == countryName);
                    river.Countries.Add(country);
                }

                db.SaveChanges();
            }
        }
    }
}
