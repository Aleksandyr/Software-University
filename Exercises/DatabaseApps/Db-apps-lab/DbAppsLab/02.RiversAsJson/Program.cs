using System;
using System.Linq;
using _01.MappingsDatabase;
using System.Web.Script.Serialization;
using System.IO;

namespace _02.RiversAsJson
{
    class Program
    {
        static void Main()
        {
            var db = new GeographyEntities();
            var rivers = db.Rivers
            .OrderByDescending(r => r.Length)
            .Select(r => new
            {
                riverName = r.RiverName,
                riverlength = r.Length,
                countries = r.Countries.OrderBy(c => c.CountryName).Select(c => c.CountryName)
            }).ToList();

            var json = new JavaScriptSerializer().Serialize(rivers);
            File.WriteAllText("../../rivers.json", json);
        }
    }
}
