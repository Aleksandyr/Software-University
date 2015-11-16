namespace Persons
{
    using System;
    using Microsoft.Build.Framework;

    class Person
    {
        private string name;
        private int age;
        private string email;

        public Person(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }

        public Person(string name, int age)
            : this(name, age, "")
        {
        }

        [Required]
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
                    throw new ArgumentNullException("Name should be not null or empty!");
                }

                this.name = value;
            }
        }

        [Required]
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
                    throw new ArgumentOutOfRangeException("Age should be between [1...100]");
                }

                this.age = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && !value.Contains("@"))
                {
                    throw new ArgumentNullException("Email should be either empty or valid!");
                }

                this.email = value;
            }
        }

        public override string ToString()
        {
            string person = "Name: " + this.Name + "\nAge: " + this.Age;
            
            if (!string.IsNullOrEmpty(this.Email))
            {
                person += "\nEmail: " + this.Email + "\n";
            }

            return person;
        }
    }
}
