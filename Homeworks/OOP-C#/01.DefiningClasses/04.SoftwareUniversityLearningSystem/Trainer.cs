using PersonInfo;
using System;

namespace TrainerInfo
{
    class Trainer : Person
    {
        public Trainer(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }

        public void CourseCreated(string course)
        {
            Console.WriteLine("Course {0} created", course);
        }
    }
}
