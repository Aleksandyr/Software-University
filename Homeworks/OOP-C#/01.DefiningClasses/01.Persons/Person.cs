using System;

namespace Persons
{
    class Person
    {
        private string name;
        private int age;
        private string email;

        public Person(string name, int age, string email) : this(name, age)
        {
            this.Email = email;
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name 
        {
            get 
            {
                return this.name;
            } 
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("Name is null or empty!");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                if (value < 1 || value > 100)
                {
                    throw new Exception("Invalid age!");
                }
                else
                {
                    this.age = value;
                }
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
                if (!String.IsNullOrEmpty(value))
                {
                    if (value.Contains("@"))
                    {
                        this.email = value;
                    }
                    else
                    {
                        throw new Exception("This is not email!");
                    }
                }
            }
        }

        public override string ToString()
        {
            return String.Format("Name:{0} \nAge:{1} \nEmail:{2} ", this.Name, this.Age, this.email ?? "no email");
        }
    }
}
