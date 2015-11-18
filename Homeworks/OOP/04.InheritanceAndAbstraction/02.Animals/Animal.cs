namespace Animals
{
    using System;

    using Animals.Enums;

    public abstract class Animal
    {
        private string name;
        private int age;
        private Gender gender;

        public Animal(string name, int age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name 
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name can not be null!");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentException("Age should be between [1...100]");
                }

                this.age = value;
            }
        }

        public Gender Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                this.gender = value;
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return String.Format("my name is {0}, I'm {1} years old, I'm {2} and I can {3}",
                 this.name, this.age, this.gender, this.ProduceSound());
        }
    }
}
