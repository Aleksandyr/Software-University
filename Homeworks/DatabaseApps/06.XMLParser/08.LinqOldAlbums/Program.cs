using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.Xml.XPath;

namespace _08.LinqOldAlbums
{
    class Program
    {
        static void Main()
        {
            var doc = XDocument.Load("../../../Catalog.xml");
            var currYear = DateTime.Now.Year - 5;

            var linqCatalog = doc.XPathSelectElements("catalog/album")
                .Where(c =>
                {
                    var year = c.Element("year");
                    return year != null && int.Parse(year.Value) <= currYear;
                })
                .Select(c => new
                {
                    Title = c.Element("name"),
                    Price = c.Element("price")
                })
                .ToList();

            foreach (var album in linqCatalog)
            {
                Console.WriteLine("{0} - {1}", album.Title.Value, album.Price.Value);
            }
        }
    }
}
