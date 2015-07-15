using CurrentStudentInfo;
using System;

namespace OnsiteStudentInfo
{
    class OnsiteStudent : CurrentStudent
    {
        private int numberOfVisits;

        public OnsiteStudent(string firstName, string lastName, int studentNum, double avgGrade, string currCourse, int numberOfVisits)
            : base(firstName, lastName, studentNum, avgGrade, currCourse)
        {
            this.NumberOfVisits = numberOfVisits;
        }

        public int NumberOfVisits 
        { 
            get
            {
                return this.numberOfVisits;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("Visits can not be negative!");
                }

                this.numberOfVisits = value;
            }
        }
    }
}
