using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.EmployeesWithProjectAfter2002;

namespace _03.EmployeesWithProjectAfter2002
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            FindEmployeesWithProjects(2002);
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

        public static void FindEmployeesWithProjects(int projectStartDateYear)
        {
            var softUniEntities = new SoftUniEntities();
            var query = "SELECT [e].[FirstName]" +
                        "FROM Employees [e]" +
                        "JOIN EmployeesProjects [ep]" +
                        "ON [ep].[EmployeeID] = [e].[EmployeeID]" +
                        "JOIN Projects [p]" +
                        "ON [p].[ProjectID] = [ep].[ProjectID]" +
                        "WHERE YEAR([p].[StartDate]) = '{0}'" +
                        "GROUP BY [e].[FirstName]" +
                        "ORDER BY [e].[FirstName]";

            var employeeFirstNames = softUniEntities.Database.SqlQuery<string>(String.Format(query, projectStartDateYear)).ToList();

            foreach (var employeeFirstName in employeeFirstNames)
            {
                Console.WriteLine(employeeFirstName);
            }
        }
    }
}
