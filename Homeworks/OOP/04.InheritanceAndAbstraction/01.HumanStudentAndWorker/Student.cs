namespace HumanStudentAndWorker
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName)
        : base(firstName, lastName)
        {
        }

        public Student(string firstName, string lastName, string facultyNumber)
            : this(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        [MinLength(5)]
        [MaxLength(10)]
        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Faculty number: " + this.FacultyNumber);
        }
    }
}
