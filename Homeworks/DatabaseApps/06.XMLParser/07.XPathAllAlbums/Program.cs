using System;
using System.Xml.Linq;
using System.Xml.XPath;

namespace _07.XPathAllAlbums
{
    class Program
    {
        static void Main()
        {
            var doc = XDocument.Load("../../../Catalog.xml");
            var catalog = doc.XPathSelectElements("catalog/album");
            var currYear = DateTime.Now.Year - 5;

            foreach (XElement album in catalog)
            {
                var year = album.Element("year");
                if (year != null)
                {
                    if (int.Parse(year.Value) <= currYear)
                    {
                        Console.WriteLine("{0} - {1}", album.Element("name").Value, decimal.Parse(album.Element("price").Value));
                    }
                }
            }

        }
    }
}
