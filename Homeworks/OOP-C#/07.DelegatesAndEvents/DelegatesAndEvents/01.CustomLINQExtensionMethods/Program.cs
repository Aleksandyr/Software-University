using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace _01.CustomLINQExtensionMethods
{
    public static class Program
    {
        static void Main()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            var filteredCollection = list.WhereNot(x => x % 2 == 0);
            Console.WriteLine(string.Join(", ", filteredCollection));

            List<Student> students = new List<Student>()
            {
                new Student("Pesho", 6),
                new Student("Ivo", 4),
                new Student("Aleksandar", 7)
            };

            Console.WriteLine(students.Max(st => st.Grade));
        }

        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            var newList = new List<T>();
            foreach (var elem in collection)
            {
                if (!predicate(elem))
                {
                    newList.Add(elem);
                }
            }

            return newList;
        }

        public static TSelector Max<TSource, TSelector>(this IEnumerable<TSource> collection, Func<TSource, TSelector> predicate) 
            where TSelector : IComparable
        {
            TSelector max = predicate(collection.First());
            foreach (var elem in collection)
            {
                if (max.CompareTo(predicate(elem)) < 0)
                {
                    max = predicate(elem);
                }
            }

            return max;
        }
    }
}
