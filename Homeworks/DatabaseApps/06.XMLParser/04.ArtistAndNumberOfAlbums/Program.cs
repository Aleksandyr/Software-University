using System;
using System.Collections.Generic;
using System.Xml;

namespace _04.ArtistAndNumberOfAlbums
{
    class Program
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../Catalog.xml");

            Dictionary<string, int> artistsAndAlbums = new Dictionary<string, int>();
            var catalog = doc.DocumentElement;
            foreach (XmlElement node in catalog)
            {
                var xmlEle = node["artist"];
                if (xmlEle != null)
                {
                    if (!artistsAndAlbums.ContainsKey(xmlEle.InnerText))
                    {
                        artistsAndAlbums.Add(xmlEle.InnerText, 0);
                    }
                    else
                    {
                        artistsAndAlbums[xmlEle.InnerText]++;
                    }
                }
            }

            foreach (var artistAndAlbums in artistsAndAlbums)
            {
                Console.WriteLine("artist: {0} albums: {1}", artistAndAlbums.Key, artistAndAlbums.Value);
            }
        }
    }
}
