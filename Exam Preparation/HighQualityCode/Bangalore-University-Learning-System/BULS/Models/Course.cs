namespace BangaloreUniversityLearningSystem.Models
{
    using System;
    using System.Collections.Generic;

    using BangaloreUniversityLearningSystem.Utilities;

    public class Course
    {
        private string name;

        public Course(string name)
        {
            this.Name = name;
            this.Lectures = new HashSet<Lecture>();
            this.Students = new HashSet<User>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < ValidationConstants.MinCourseNameLength)
                {
                    string message = string.Format("The course name must be at least {0} symbols long.", ValidationConstants.MinCourseNameLength);

                    throw new ArgumentException(message);
                }

                this.name = value;
            }
        }

        public ISet<Lecture> Lectures { get; set; }

        public ISet<User> Students { get; set; }

        public void AddLecture(Lecture lecture)
        {
            this.Lectures.Add(lecture);
        }

        public void AddStudent(User student)
        {
            this.Students.Add(student);
        }
    }
}