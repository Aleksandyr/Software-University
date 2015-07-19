using _01.DBContextSoftuni;
using System;
using System.IO;
using System.Linq;


namespace _03.DatabaseSearchQueries
{
    class Program
    {
        static void Main()
        {
            AllAddresses();
        }

        public static void AllEmpWithProjects(int year)
        {
            var db = new SoftUniEntities();

            var employees = db.Employees.Where(e => e.Projects.Any(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003));

            foreach (var employee in employees)
            {
                Console.WriteLine("Manager name: " + employee.Employee1.FirstName + " " + employee.Employee1.LastName);
                foreach (var project in employee.Projects)
                {
                    Console.WriteLine("project name: {0}, start date: {1}, end date: {2}", project.Name,
                        project.StartDate.ToString("dd-MM-yyyy"), project.EndDate.ToString());
                }
                Console.WriteLine();
            }
        }

        public static void AllAddresses()
        {
            var db = new SoftUniEntities();

            var addresses = db.Addresses.Where(a => a.Employees.Any()).OrderByDescending(a => a.Employees.Count).ThenBy(a => a.Town.Name).Take(10);
            foreach (var address in addresses)
            {
                Console.WriteLine("{0}, {1} - {2} employees", address.AddressText, address.Town.Name, address.Employees.Count);
            }
        }
    }
}
