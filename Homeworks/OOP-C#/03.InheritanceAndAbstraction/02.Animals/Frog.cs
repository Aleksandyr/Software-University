using AnimalInfo;
using System;

namespace FrogInfo
{
    public class Frog : Animal
    {
        public Frog(string name, int age, string gander)
            :base(name, age, gander)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Krak!");
        }
    }
}
