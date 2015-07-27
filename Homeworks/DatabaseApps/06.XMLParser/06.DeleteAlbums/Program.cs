using System.Xml;
using System.Xml.Linq;

namespace _06.DeleteAlbums
{
    class Program
    {
        static void Main()
        {
            XDocument doc = XDocument.Load("../../../Catalog.xml");

            var result = new XDocument();
            var root = new XElement("category");
            result.Add(root);

            var catalog = doc.Root.Elements();
            foreach (XElement album in catalog)
            {
                var price = album.Element("price");
                if (price != null)
                {
                    if (double.Parse(price.Value) < 20)
                    {
                        root.Add(album);
                    }
                }
            }

            result.Save("../../../cheap-albums-catalog.xml");
        }
    }
}
