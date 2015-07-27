using System;
using System.Collections.Generic;
using System.Xml;

namespace _02.ExtractAlbumNames
{
    class Program
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../Catalog.xml");

            SortedSet<string> result = new SortedSet<string>();
            var root = doc.DocumentElement;
            foreach (XmlElement node in root.ChildNodes)
            {
                var xmlElem = node["name"];
                if (xmlElem != null)
                {
                    result.Add(xmlElem.InnerText);
                }
            }

            Console.WriteLine(string.Join("\n", result));
        }
    }
}
