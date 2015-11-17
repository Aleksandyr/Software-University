using System;
namespace SoftwareUniversityLearningSystem
{
    public class OnsiteStudent : CurrentStudent
    {
        private int numberOfVisits;

        public OnsiteStudent(string firstName, string lastName, int age, string studentNumber, float avgGrade, string currentCourse, int numberOfVisits)
            : base(firstName, lastName, age, studentNumber, avgGrade, currentCourse)
        {
            this.NumberOfVisits = numberOfVisits;
        }

        public OnsiteStudent(string firstName, string lastName, int age, string studentNumber, float avgGrade, string currentCourse)
            : base(firstName, lastName, age, studentNumber, avgGrade, currentCourse)
        {
            this.NumberOfVisits = 0;
        }

        public int NumberOfVisits
        {
            get
            {
                return this.numberOfVisits;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Number of visits can not be negative!");
                }

                this.numberOfVisits = value;
            }
        }
    }
}
