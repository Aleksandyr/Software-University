using _01.DBContextSoftuni;
using System;
using System.Linq;


namespace _03.DatabaseSearchQueries
{
    class Program
    {
        static void Main()
        {
            AllEmpWithProjects(2002);
        }

        public static void AllEmpWithProjects(int year)
        {
            var db = new SoftUniEntities();

            var employees = db.Employees.Where(e => e.Projects.Any(p => p.StartDate.Year == year));

            foreach (var employee in employees)
            {
                Console.WriteLine("FirstName: " + employee.FirstName);
                foreach (var project in employee.Projects)
                {
                    Console.WriteLine("project name: {0}, date: {1}", project.Name,
                        project.StartDate.ToString("dd-MM-yyyy"));
                }
                Console.WriteLine();
            }
        }
    }
}
