using System;
using BangaloreUniversityLearningSystem.Utilities;

namespace BangaloreUniversityLearningSystem.Models
{
    public class Lecture
    {
        private string name;

        public Lecture(string name)
        {
            //BUG FIXED: property is autoset to him
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < ValidationConstants.MinLectureNameLength)
                {
                    throw new ArgumentException(string.Format("The lecture name must be at least {0} symbols long.", 
                        ValidationConstants.MinLectureNameLength));
                }

                this.name = value;
            }
        }
    }
}
