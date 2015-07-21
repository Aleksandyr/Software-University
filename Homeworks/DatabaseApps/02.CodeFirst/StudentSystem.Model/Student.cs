using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Model
{
    public class Student
    {
        private ICollection<Course> courses;

        public Student()
        {
            this.courses = new HashSet<Course>();
        }

        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? Birthaday { get; set; }

        public virtual ICollection<Course> Courses
        {
             get { return this.courses; } 
            set { this.courses = value; }
        }
    }
}
