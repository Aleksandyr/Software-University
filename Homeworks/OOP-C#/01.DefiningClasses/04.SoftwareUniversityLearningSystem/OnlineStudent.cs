using CurrentStudentInfo;
using System;

namespace OnlineStudentInfo
{
    class OnlineStudent : CurrentStudent
    {
        public OnlineStudent(string firstName, string lastName, int studentNum, double avgGrade, string currCourse)
            : base(firstName, lastName, studentNum, avgGrade, currCourse)
        {
        }
    }
}
