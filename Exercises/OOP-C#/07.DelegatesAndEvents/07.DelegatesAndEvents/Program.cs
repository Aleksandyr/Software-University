using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.DelegatesAndEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> collection = new List<int>() { 1, 2, 3, 4, 5 };
            Console.WriteLine(collection.FirstOrDefault(x => x > 3));

            List<int> collection2 = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            Console.WriteLine(string.Join(", ", collection2.TakeWhile(x => x > 2)));
        }

        public static T FirstOrDefault<T>(IEnumerable<T> collection, Predicate<T> condition)
        {
            foreach (var elem in collection)
            {
                if (condition(elem))
                {
                    return elem;
                }
            }

            return default(T);
        }

        public static IEnumerable<T> TakeWhile<T>(IEnumerable<T> collection, Func<T, bool> predicate)
        {
            var list = new List<T>();

            foreach (var elem in collection)
            {
                if (predicate(elem))
                {
                    list.Add(elem);
                }
            }

            return list;
        }
    }
}
