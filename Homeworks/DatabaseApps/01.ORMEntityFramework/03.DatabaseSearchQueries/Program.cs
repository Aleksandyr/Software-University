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
            AllDepartmentsWithMoreThan5Employee();
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

            var addresses = db.Addresses.OrderByDescending(a => a.Employees.Count).ThenBy(a => a.Town.Name).Select(e => new
            {
                Address = e.AddressText,
                TownName = e.Town.Name,
                EmployeeCount = e.Employees.Count
            }).Take(10)
            .ToList();
            foreach (var address in addresses)
            {
                Console.WriteLine("{0}, {1} - {2} employees", address.Address, address.TownName, address.EmployeeCount);
            }
        }

        public static void GetAnEmployeeById(int id)
        {
            var db = new SoftUniEntities();
            var employeeById = db.Employees.Find(id);
            var empProjects = employeeById.Projects.OrderBy(p => p.Name).Select(p => p.Name);

            Console.WriteLine("Employee: {0} {1}, Job Title: {2}, Projects: {3}",
                employeeById.FirstName,
                employeeById.LastName,
                employeeById.JobTitle,
                string.Join(", ", empProjects));
        }

        public static void AllDepartmentsWithMoreThan5Employee()
        {
            var db = new SoftUniEntities();
            var departments =
                db.Departments.Where(d => d.Employees.Count > 5).OrderBy(d => d.Employees.Count).Select(d => new
                {
                    DepartmentName = d.Name,
                    MName = d.Employee.Employee1.FirstName + " " + d.Employee.Employee1.LastName,
                    Employees = d.Employees.Select(e => new
                        {
                            e.FirstName,
                            e.LastName,
                            e.HireDate,
                            e.JobTitle
                        })
                        .ToList()
                })
                .ToList();

            foreach (var department in departments)
            {
                Console.WriteLine("---{0} - Manager: {1}, Employees: {2}",
                    department.DepartmentName, department.MName, department.Employees.Count);
            }
        }
    }
}
