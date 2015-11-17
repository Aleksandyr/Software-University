namespace SoftwareUniversityLearningSystem
{
    using System;

    public abstract class Student : Person
    {
        private string studentNumber;
        private float avgGrade;

        protected Student(string firstName, string lastName, int age, string studentNumber, float avgGrade)
            : base(firstName, lastName, age)
        {
            this.StudentNumber = studentNumber;
            this.AvgGrade = avgGrade;
        }

        protected string StudentNumber
        {
            get
            {
                return this.studentNumber;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this.studentNumber = value;
            }
        }

        public float AvgGrade
        {
            get
            {
                return this.avgGrade;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Number can not be negative!");
                }

                this.avgGrade = value;
            }
        }
    }
}
