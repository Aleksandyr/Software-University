using HumanInfo;
using System;
using System.Text;

namespace StudentInfo
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber) 
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber 
        { 
            get
            {
                return this.facultyNumber;
            }
            private set
            {
                if(value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentOutOfRangeException("Faculty number must be between 5-10 characters");
                }

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("First Name: " + this.FirstName);
            sb.AppendLine("Last Name: " + this.LastName);
            sb.AppendLine("Faculty Number: " + this.FacultyNumber);

            return sb.ToString();
        }
    }
}
