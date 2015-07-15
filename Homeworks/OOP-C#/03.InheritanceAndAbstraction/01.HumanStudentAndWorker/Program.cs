using StudentInfo;
using System;
using System.Collections.Generic;
using WorkerInfo;
using System.Linq;

namespace HumanStudentAndWorker
{
    class Program
    {
        static void Main()
        {
            List<Student> students = new List<Student>
            {
                new Student("Alex", "Alexov", "asdf234"),
                new Student("Pesho", "Alexov", "psdf234"),
                new Student("Sasho", "Alexov", "ssdf234"),
                new Student("Tosho", "Alexov", "tsdf234"),
                new Student("Gosho", "Alexov", "gsdf234"),
            };

            students.OrderBy(x => x.FacultyNumber).ToList().ForEach(x => Console.WriteLine(x));

            List<Worker> workers = new List<Worker>
            {
                new Worker("Alex", "Alexov", 4000, 8),
                new Worker("Pesho", "Alexov", 250, 6),
                new Worker("Sasho", "Alexov", 1000, 10),
                new Worker("Tosho", "Alexov", 2000, 8),
                new Worker("Gosho", "Alexov", 100, 8),
            };

            workers.OrderByDescending(x => x.MoneyPerHour()).ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
