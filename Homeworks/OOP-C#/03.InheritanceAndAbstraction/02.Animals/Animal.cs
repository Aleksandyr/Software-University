using ISound;
using System;

namespace AnimalInfo
{
    public abstract class Animal : ISoundProducible
    {
        private string name;
        private int age;
        private string gander;

        protected Animal(string name, int age, string gander)
        {
            this.Name = name;
            this.age = age;
            this.Gander = gander;
        }

        public string Name 
        { 
            get
            {
                return this.name;
            }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name can not be null or empty!");
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
                    throw new ArgumentOutOfRangeException("Age must be between 1-100");
                }

                this.age = value;
            }
        }

        public string Gander
        {
            get
            {
                return this.gander;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Gander can not be null or empty!");
                }

                this.gander = value;
            }
        }

        public abstract void ProduceSound();
    }
}
