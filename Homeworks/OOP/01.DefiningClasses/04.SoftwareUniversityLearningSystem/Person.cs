namespace SoftwareUniversityLearningSystem
{
    using System;

    public abstract class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        protected Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        protected string FirstName 
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this.firstName = value;
            }
        }

        protected string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this.lastName = value;
            }
        }

        protected int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentException("Age should be between [1...100]!");
                }

                this.age = value;
            }
        }
    }
}
