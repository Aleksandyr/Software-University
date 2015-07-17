using _01.DBContextSoftuni;
using System;
using System.Linq;


namespace _04.NativeSqlQuerie
{
    class Program
    {
        static void Main(string[] args)
        {
            FindEmployeesWithProjects(2002);
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
