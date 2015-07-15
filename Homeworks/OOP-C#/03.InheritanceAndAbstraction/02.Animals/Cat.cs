using AnimalInfo;
using System;

namespace CatInfo
{
    public class Cat : Animal
    {
        public Cat(string name, int age, string gander)
            :base(name, age, gander)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Mayyy!");
        }
    }
}
