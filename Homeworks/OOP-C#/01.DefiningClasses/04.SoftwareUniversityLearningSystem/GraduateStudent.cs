using StudentInfo;
using System;

namespace GraduateStudentInfo
{
    class GraduateStudent : Student
    {
        public GraduateStudent(string firstName, string lastName, int studentNum, double avgGrade)
            : base(firstName, lastName, studentNum, avgGrade)
        {
        }
    }
}
