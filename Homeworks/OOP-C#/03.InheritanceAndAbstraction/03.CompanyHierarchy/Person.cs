namespace PersonInfo
{
    using Interfaces;
    using System;

    public abstract class Person : IPerson
    {
        private string firstName;
        private string lastName;
        private int id;

        protected Person(string firstName, string lastName, int id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
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
                    throw new ArgumentNullException("First name can not be null or empty!");
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
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Last name can not be null or empty!");
                }

                this.lastName = value;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Id can not be negative!");
                }

                this.id = value;
            }
        }
    }
}
