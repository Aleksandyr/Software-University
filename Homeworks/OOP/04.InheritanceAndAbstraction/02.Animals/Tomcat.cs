namespace Animals
{
    using System;

    using Animals.Enums;

    public class Tomcat : Cat
    {
        public Tomcat(string name, int age)
            : base(name, age, Gender.Male)
        {
        }

        public override string ProduceSound()
        {
            return "mquwww";
        }

        public override string ToString()
        {
            return String.Format("I'm a Tomcat ") + base.ToString();
        }

    }
}
