using System;

namespace Methods
{
    class Student
    {
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string otherInfo;

        public Student(string firstName, string lastName, DateTime dateOfBirth, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.OtherInfo = otherInfo;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("First name can not be null or empty!", "value"); 
                }

                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.otherInfo;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Last name can not be null or empty!", "value");
                }

                this.lastName = value;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }
            set
            {
                this.dateOfBirth = value;
            }
        }

        public string OtherInfo
        {
            get
            {
                return this.otherInfo;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Other info can not be null or empty!", "value");
                }

                this.otherInfo = value;
            }
        }

        public bool IsOlderThan(Student other)
        {
            bool isOlder = this.DateOfBirth < other.DateOfBirth;

            return isOlder;
        }
    }
}
