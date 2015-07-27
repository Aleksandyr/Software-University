using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace _05.XPathArtistsAndAlbums
{
    class Program
    {
        static void Main()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load("../../../Catalog.xml");

            Dictionary<string, int> artistsAndAlbums = new Dictionary<string, int>();
            var artists =
                (from XmlElement artist in xdoc.SelectNodes("catalog/album/artist") select artist.InnerText).ToList();
            artists.ForEach(a =>
            {
                if (!artistsAndAlbums.ContainsKey(a))
                {
                    artistsAndAlbums.Add(a, 0);
                }
                else
                {
                    artistsAndAlbums[a]++;
                }
            });

            foreach (var artistAndAlbums in artistsAndAlbums)
            {
                Console.WriteLine("artist: {0} albums: {1}", artistAndAlbums.Key, artistAndAlbums.Value);
            }
        }
    }
}
