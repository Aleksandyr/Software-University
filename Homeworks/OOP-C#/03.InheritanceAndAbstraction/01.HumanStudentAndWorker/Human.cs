using System;

namespace HumanInfo
{
    public abstract class Human
    {
        private string firstName;
        private string lastName;

        protected Human(string firstName, string lastName)
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
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException("First name can not be empty or null!");
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
                    throw new ArgumentOutOfRangeException("First name can not be empty or null!");
                }

                this.lastName = value;
            }
        }
    }
}
