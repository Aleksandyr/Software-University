namespace SoftwareUniversityLearningSystem
{
    using System;
    using System.Text;

    public class DropoutStudent : Student
    {
        private string dropoutReason;

        public DropoutStudent(string firstName, string lastName, int age, string studentNumber, float avgAge, string dropoutReason)
            : base(firstName, lastName, age, studentNumber, avgAge)
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
                    throw new ArgumentNullException();
                }

                this.dropoutReason = value;
            }
        }

        public void Reapply()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("First Name: " + this.FirstName);
            sb.AppendLine("Last Name: " + this.LastName);
            sb.AppendLine("Age: " + this.Age);
            sb.AppendLine("Studnet number: " + this.StudentNumber);
            sb.AppendLine("Average grade: " + this.AvgGrade);
            sb.AppendLine("Dropout information: " + this.dropoutReason);

            Console.WriteLine(sb.ToString());
        }
    }
}
