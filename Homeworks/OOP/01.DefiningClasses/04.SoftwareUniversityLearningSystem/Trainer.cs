namespace SoftwareUniversityLearningSystem
{
    using System;

    public abstract class Trainer : Person
    {
        protected Trainer(string firstName, string lastName, byte age)
            : base(firstName, lastName, age)
        {
        }

        public void CreateCourse(string courseName)
        {
            Console.WriteLine(string.Format("{0} {1} you created the {2} course!", this.FirstName, this.LastName, courseName));
        }
    }
}
