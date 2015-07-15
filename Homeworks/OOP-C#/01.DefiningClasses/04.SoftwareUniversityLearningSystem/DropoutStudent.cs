using StudentInfo;
using System;
using System.Text;

namespace DropoutStudentInfo
{
    class DropoutStudent : Student
    {
        private string dropoutReason;

        public DropoutStudent(string firstName, string lastName, string dropoutReason)
            : base(firstName, lastName)
        {
            this.DropoutReason = dropoutReason;
        }

        public string DropoutReason
        {
            get
            {
                return this.dropoutReason;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Course can not be null or empty!");
                }

                this.dropoutReason = value;
            }
        }

        public string Reaply() 
        {
            string result = "First name: " + this.FirstName + "\nLast name: " + this.LastName + "\nDropout Reason: " + this.DropoutReason;
            return result;
        }
    }
}
