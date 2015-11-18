namespace Animals
{
    using Animals.Enums;
    using Animals.Interfaces;
    using System;

    public class Dog : Animal, ISoundProducible
    {
        public Dog(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "bau";
        }

        public override string ToString()
        {
            return String.Format("I'm a dog ") + base.ToString();
        }
    }
}
