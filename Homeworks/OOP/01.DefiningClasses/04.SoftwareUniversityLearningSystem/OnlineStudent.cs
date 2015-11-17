namespace SoftwareUniversityLearningSystem
{
    using System;

    public class OnlineStudent : CurrentStudent
    {
        public OnlineStudent(string firstName, string lastName, int age, string studentNumber, float avgGrade, string currentCourse)
            : base(firstName, lastName, age, studentNumber, avgGrade, currentCourse)
        {   
        }
       
    }
}
