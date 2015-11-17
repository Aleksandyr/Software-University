namespace SoftwareUniversityLearningSystem
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class SULS
    {
        private List<Person> softUniPersons;

        public SULS(List<Person> softUniPersons)
        {
            this.SoftUniPersons = softUniPersons;
        }

        public List<Person> SoftUniPersons 
        {
            get
            {
                return this.softUniPersons;
            }
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentNullException("Softuni persons can not be null or empty!", "SoftUniPersons");
                }

                this.softUniPersons = value;
            }
        }

        public void ExtractCurrentStudents()
        {
            IEnumerable<CurrentStudent> currentStudents = this.SoftUniPersons.Where(x => x is CurrentStudent).Cast<CurrentStudent>().Select(x => x);
            currentStudents = currentStudents.OrderByDescending(s => s.AvgGrade);
            int count = 0;
            foreach (var student in currentStudents)
            {
                Console.WriteLine(++count + ": " + student);
            }
        }
    }
}
