using StudentInfo;
using System;
using System.Text;


namespace CurrentStudentInfo
{
    class CurrentStudent : Student
    {
        private string currCourse;

        public CurrentStudent(string firstName, string lastName, int studentNum, double avgGrade, string currCourse)
            : base(firstName, lastName, studentNum, avgGrade)
        {
            this.CurrCourse = currCourse;
        }

        public string CurrCourse 
        { 
            get
            {
                return this.currCourse;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Course can not be null or empty!");
                }

                this.currCourse = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("First Name: " + this.FirstName);
            sb.AppendLine("Last Name: " + this.LastName);
            sb.AppendLine("Student Number: " + this.StudentNumber);
            sb.AppendLine("Average Grade: " + this.AvgGrade);
            sb.AppendLine("Current Course: " + this.CurrCourse);

            return sb.ToString();
        }
    }
}
