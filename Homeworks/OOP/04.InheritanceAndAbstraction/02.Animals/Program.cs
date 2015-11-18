namespace Animals
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Animals.Enums;

    public class Program
    {
        static void Main()
        {
            Dog dog = new Dog("Sharo", 5, Gender.Male);
            Console.WriteLine(dog);

            Console.WriteLine();

            Frog frog = new Frog("Kermit", 33, Gender.Male);
            Console.WriteLine(frog);

            Console.WriteLine();

            Kitten kitty = new Kitten("Kitty", 1);
            Console.WriteLine(kitty);

            Console.WriteLine();

            Tomcat tomcat = new Tomcat("Tom", 12);
            Console.WriteLine(tomcat);

            Console.WriteLine();


            List<Animal> animals = new List<Animal>()
            {
                new Dog("Rex",3, Gender.Male),
                new Frog("Kekerica", 1, Gender.Female),
                new Kitten("Pisi", 1),
                new Tomcat("Tom",2),
                new Dog("Erik", 4, Gender.Male),
                new Frog("Penka", 1, Gender.Female),
                new Kitten("Jasmin", 2),
                new Tomcat("Kolio",6),
                new Dog("Bender",2, Gender.Male),
                new Frog("Ginka", 6, Gender.Female),
                new Kitten("Tedy", 1),
                new Tomcat("Muncho",4),
            };

            var avgGradeForCurrentAnimal = animals
                .GroupBy(x => x.GetType().Name)
                .Select(a => new
                {
                    Name = a.Key,
                    AvgAge = a.Average(g => g.Age)
                });

            foreach (var currAnimal in avgGradeForCurrentAnimal)
            {
                Console.WriteLine(currAnimal);
            }
        }
    }
}
