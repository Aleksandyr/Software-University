using System;
using System.IO;
using Composite;

namespace DOMBuilder
{
    public class Program
    {
        static void Main()
        {
            Element html =
            new Element("html",
                new Element("head"),
                new Element("body",
                    new Element("section",
                        new Element("h2"),
                        new Element("p"),
                        new Element("span")),
                    new Element("footer")));
            //html.Display(1);

            File.WriteAllText("index.html", html.Display(1));

        }
    }
}
