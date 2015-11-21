namespace CompanyHierarchy
{
    using System;

    using CompanyHierarchy.Interfaces;

    public abstract class Person : IPerson
    {
        private int id;
        private string firstName;
        private string lastName;

        protected Person(int id, string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id can not be negative !");
                }

                this.id = value;
            }
        }

        public string FirstName 
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First name cannot be null or empty!");
                }

                this.firstName = value;
            }
        }

        public string LastName 
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last name cannot be null or empty!");
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Full name: {0} {1}", this.FirstName, this.LastName);
        }
    }
}
