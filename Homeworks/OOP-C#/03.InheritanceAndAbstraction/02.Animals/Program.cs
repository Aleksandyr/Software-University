using AnimalInfo;
using CatInfo;
using DogInfo;
using FrogInfo;
using KittenInfo;
using System;
using System.Collections.Generic;
using TomCatInfo;
using System.Linq;

namespace Animals
{
    class Program
    {
        static void Main()
        {
            List<Dog> dogs = new List<Dog>()
            {
                new Dog("Rex", 13, "Male"),
                new Dog("Jessica", 6, "Female"),
                new Dog("Milo", 17, "Male"),
                new Dog("Jade", 1, "Female")
            };

            List<Kitten> kittens = new List<Kitten>()
            {
                new Kitten("Kat", 6),
                new Kitten("Sweety", 0),
                new Kitten("Sandy", 4),
                new Kitten("Catherine", 3)
            };

            List<TomCat> tomcats = new List<TomCat>()
            {
                new TomCat("Zorro", 7),
                new TomCat("Lucky", 7),
                new TomCat("Tom", 7),
                new TomCat("Sage", 4)
            };

            List<Frog> frogs = new List<Frog>()
            {
                new Frog("Randy", 3, "Male"),
                new Frog("Bob", 6, "Male"),
                new Frog("Steward", 2, "Male"),
                new Frog("Queen", 4, "Female")
            };

            Console.WriteLine("dogs average age is: " + dogs.Average(x => x.Age));
            Console.WriteLine("kittens average age is: " + kittens.Average(x => x.Age));
            Console.WriteLine("tomcats average age is: " + tomcats.Average(x => x.Age));
            Console.WriteLine("frogs average age is: " + frogs.Average(x => x.Age));
        }
    }
}
