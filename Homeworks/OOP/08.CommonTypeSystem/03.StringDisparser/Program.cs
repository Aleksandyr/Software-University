using System;
namespace StringDisparser
{
    public class Program
    {
        static void Main()
        {
            StringDisperserCs firstStringDisperser = new StringDisperserCs("hello", "beautifull", "World!");
            StringDisperserCs secondStringDisperser = new StringDisperserCs("gosho", "pesho", "tanio");
            StringDisperserCs thirdStringDisperser = (StringDisperserCs)firstStringDisperser.Clone();

            Console.WriteLine(firstStringDisperser + "\n");

            Console.WriteLine(firstStringDisperser.Equals(secondStringDisperser));
            Console.WriteLine(firstStringDisperser.Equals(thirdStringDisperser) + "\n");

            foreach (string character in secondStringDisperser)
            {
                Console.Write(character);
            }

            Console.WriteLine();
        }
    }
}
