namespace StudentInfo
{
    using PersonInfo;
    using System;

    class Student : Person
    {
        private int studentNumer;
        private double avgGrade;

        public Student(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }

        public Student(string firstName, string lastName, int studentNum, double avgGrade)
            : base(firstName, lastName)
        {
            this.StudentNumber = studentNumer;
            this.AvgGrade = avgGrade;
        }

        public int StudentNumber 
        { 
            get
            {
                return this.studentNumer;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("Student number can not be negative");
                }

                this.studentNumer = value;
            }
        }

        public double AvgGrade
        {
            get
            {
                return this.avgGrade;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Average grade can not be negative");
                }

                this.avgGrade = value;
            }
        }

        public void CourseCreated(string course)
        {
            Console.WriteLine("Course {0} created", course);
        }
    }
}
