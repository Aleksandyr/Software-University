namespace Animals
{
    using Animals.Enums;

    public abstract class Cat : Animal
    {
        public Cat(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }
    }
}
