namespace SoftwareUniversityLearningSystem
{
    using System;

    public class SeniorTrainer : Trainer
    {
        public SeniorTrainer(string firstName, string lastName, byte age)
        : base(firstName, lastName, age)
        {
        }

        public void DeleteCourse(string courseName)
        {
            Console.WriteLine(string.Format("{0} {1} you deleted the {2} course!", this.FirstName, this.LastName, courseName));
        }
    }
}
