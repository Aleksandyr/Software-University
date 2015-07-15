using AnimalInfo;
using System;

namespace DogInfo
{
    public class Dog : Animal
    {
        public Dog(string name, int age, string gander)
            :base(name, age, gander)
        {
        }


        public override void ProduceSound()
        {
            Console.WriteLine("Bark!");
        }
    }
}
