namespace CustomLINQExtensionMethods
{
    using System.Collections.Generic;

    public class Program
    {
        static void Main()
        {
            var elements = new List<int>()
            {
                 40, 51, 60, 5, 10, 20, 30,
            };

            var getOddNums = elements.WhereNot(x => x % 2 == 0);
            foreach (var num in getOddNums)
            {
                System.Console.WriteLine(num);
            }
        }
    }
}
