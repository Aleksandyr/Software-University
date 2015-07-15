using ElementBuilderInfo;
using HTMLDispatcherInfo;
using System;
namespace Program
{
    class Program
    {
        static void Main()
        {
            ElementBuilder div = new ElementBuilder("div");
            div.AddAtribute("id", "table");
            div.AddAtribute("class", "asd");
            div.AddContent("I'm the best");
            Console.WriteLine(div * 2);

            Console.WriteLine(HTMLDispatcher.CreateImage("asd", "sda", "good"));
            Console.WriteLine(HTMLDispatcher.CreateInput("button", "button", "Submit"));
            Console.WriteLine(HTMLDispatcher.CreateURL("https://softuni.bg", "softuni", "softUni"));
        }
    }
}
