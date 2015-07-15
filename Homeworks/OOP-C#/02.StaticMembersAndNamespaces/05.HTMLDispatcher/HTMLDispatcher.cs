using ElementBuilderInfo;
using System;

namespace HTMLDispatcherInfo
{
    public static class HTMLDispatcher
    {
        public static string CreateImage(string source, string alt, string title)
        {
            ElementBuilder img = new ElementBuilder("img");
            img.AddAtribute("src", source);
            img.AddAtribute("alt", alt);
            img.AddAtribute("title", title);
            return img.ToString();
        }

        public static string CreateURL(string url, string title, string text)
        {
            ElementBuilder urlElem = new ElementBuilder("a");
            urlElem.AddAtribute("url", url);
            urlElem.AddAtribute("title", title);
            urlElem.AddContent(text);
            return urlElem.ToString();
        }

        public static string CreateInput(string type, string name, string value)
        {
            ElementBuilder input = new ElementBuilder("input");
            input.AddAtribute("type", type);
            input.AddAtribute("name", name);
            input.AddContent(value);
            return input.ToString();
        }
    }
}
