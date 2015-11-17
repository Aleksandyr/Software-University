namespace HTMLDispatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            ElementBuilder div = new ElementBuilder("div");
            div.AddAttribute("id", "page");
            div.AddAttribute("class", "big");
            div.AddContent("<p>Hello</p>");

            System.Console.WriteLine(div * 2);

            string img = HTMLDispatcher.CreateImage("smiley.jpg", "Smiley Face", "Title");
            System.Console.WriteLine(img);

            string url = HTMLDispatcher.CreateURL("www.google.bg", "google", "GOOGLE");
            System.Console.WriteLine(url);

            string input = HTMLDispatcher.CreateInput("button", "hi", "HELLO");
            System.Console.WriteLine(input);
        }
    }
}
