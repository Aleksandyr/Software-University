using System;
using System.Collections.Generic;
using System.Xml;

namespace _03.AllArtistAlphabetically
{
    class Program
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../Catalog.xml");

            SortedSet<string> resutlt = new SortedSet<string>();
            var rootNode = doc.DocumentElement;
            foreach (XmlElement node in rootNode.ChildNodes)
            {
                var xmlElemt = node["artist"];
                if (xmlElemt != null)
                {
                    resutlt.Add(xmlElemt.InnerText);
                }
            }

            Console.WriteLine(string.Join("\n", resutlt));
        }
    }
}
