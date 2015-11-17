namespace SoftwareUniversityLearningSystem
{
    using System;
    using System.Text;

    public abstract class CurrentStudent : Student
    {
        private string currentCourse;

        protected CurrentStudent(string firstName, string lastName, int age, string studentNumber, float avgGrade, string currentCourse)
            : base(firstName, lastName, age, studentNumber, avgGrade)
        {
            this.CurrentCourse = currentCourse;
        }

        protected string CurrentCourse
        {
            get
            {
                return this.currentCourse;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this.currentCourse = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("First name: {0}", this.FirstName));
            sb.AppendLine(string.Format("Last name: {0}", this.LastName));
            sb.AppendLine(string.Format("Age: {0}", this.Age));
            sb.AppendLine(string.Format("Student number: {0}", this.StudentNumber));
            sb.AppendLine(string.Format("Average grade: {0}", this.AvgGrade));
            sb.AppendLine(string.Format("Current course: {0}", this.CurrentCourse));
            
            return sb.ToString();
        }
    }
}
