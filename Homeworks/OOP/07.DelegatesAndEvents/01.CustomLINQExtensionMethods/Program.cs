namespace CustomLINQExtensionMethods
{
    using System;
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
                Console.WriteLine(num);
            }

            var students = new List<Student>
            {
                new Student("Pesho", 3),
                new Student("Gosho", 2),
                new Student("Mariika", 7),
                new Student("Stamat", 5),
            };

            Console.WriteLine(students.Max(st => st.Age));
        }
    }
}
