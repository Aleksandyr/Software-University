namespace Animals
{
    using Animals.Enums;
    using System;

    public class Frog : Animal
    {
        public Frog(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "kvak";
        }

        public override string ToString()
        {
            return String.Format("I'm a frog ") + base.ToString();
        }
    }
}
