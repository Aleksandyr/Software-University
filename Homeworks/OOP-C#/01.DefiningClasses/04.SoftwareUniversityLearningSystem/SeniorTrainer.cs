namespace SeniorTrainerInfo
{
    using System;
    using TrainerInfo;
    class SeniorTrainer : Trainer
    {
        public SeniorTrainer(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }

        public void CourseDeleted(string course)
        {
            Console.WriteLine("Course {0} deleted", course);
        }
    }
}
