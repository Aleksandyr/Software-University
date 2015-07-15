using System;

namespace PersonInfo
{
    public abstract class Person
    {
        private string firstName;
        private string lastName;

        protected Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
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
                    throw new ArgumentNullException("First name can no be null or empty!");
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
                    throw new ArgumentNullException("Last name can no be null or empty!");
                }

                this.lastName = value;
            }
        }
    }
}
