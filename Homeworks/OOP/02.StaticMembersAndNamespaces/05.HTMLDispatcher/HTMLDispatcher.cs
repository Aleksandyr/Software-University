namespace HTMLDispatcher
{
    public static class HTMLDispatcher
    {
        public static string CreateImage(string imageSource, string alt, string title)
        {
            ElementBuilder img = new ElementBuilder("img");
            img.AddAttribute("src", imageSource);
            img.AddAttribute("alt", alt);
            img.AddAttribute("title", title);
            img.CloseSelf(true);

            return img.ToString();
        }

        public static string CreateURL(string url, string title, string text)
        {
            ElementBuilder a = new ElementBuilder("a");
            a.AddAttribute("href", url);
            a.AddAttribute("title", title);
            a.AddContent(text);

            return a.ToString();
        }

        public static string CreateInput(string type, string name, string value)
        {
            ElementBuilder input = new ElementBuilder("input");
            input.AddAttribute("type", type);
            input.AddAttribute("name", name);
            input.AddAttribute("value", value);
            input.CloseSelf(true);

            return input.ToString();
        }
    }
}
