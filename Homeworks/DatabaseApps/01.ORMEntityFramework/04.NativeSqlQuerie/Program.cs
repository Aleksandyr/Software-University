using System.Diagnostics;
using System.IO;

namespace _04.NativeSqlQuerie
{
    using _01.DBContextSoftuni;
    using System;
    using System.Linq;


    class Program
    {
        static void Main()
        {
            var sw = new Stopwatch();
            sw.Start();
            PrintNameWithNativeQuery(2002);
            Console.WriteLine("Native: " + sw.Elapsed);

            sw.Restart();

            PrintNameWithLinqQuery(2002);
            Console.WriteLine("Linq: " + sw.Elapsed);
        }

        public static void PrintNameWithNativeQuery(int projectStartDateYear)
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
        }

        public static void PrintNameWithLinqQuery(int projectStartDateYear)
        {
            var db = new SoftUniEntities();

            var employees = db.Employees.Where(e => e.Projects.Any(p => p.StartDate.Year.ToString() == "2002")).Select(e => e.FirstName);
        }
    }
}
