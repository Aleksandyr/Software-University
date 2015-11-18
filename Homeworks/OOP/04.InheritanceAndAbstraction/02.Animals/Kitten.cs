namespace Animals
{
    using Animals.Enums;
    using Animals.Interfaces;
    using System;

    public class Kitten : Cat
    {
        public Kitten(string name, int age)
            : base(name, age, Gender.Female)
        {
        }

        public override string ProduceSound()
        {
            return "mqu";
        }

        public override string ToString()
        {
            return String.Format("I'm a kitten ") + base.ToString();
        }

       
    }
}
