using System;
using System.Linq;
using _01.DBContextSoftuni;

namespace _05.DatabaseChangesWithEF
{
    class Program
    {
        static void Main()
        {
            EmployeeByDepartmentAndManager("Tool Designer", "Ovidiu", "Cracium");
        }

        public static void EmployeeByDepartmentAndManager(string departmentName, string managerFirstName,
           string managerLastName)
        {
            var db = new SoftUniEntities();
            var manager = db.Employees.FirstOrDefault(e => e.FirstName == managerFirstName && e.LastName == managerLastName);

            var employeeByDepartmentAndManager =
                db.Employees.FirstOrDefault(e => e.Department.Name == departmentName || e.ManagerID == manager.EmployeeID);

            Console.WriteLine(employeeByDepartmentAndManager.FirstName + " " + employeeByDepartmentAndManager.LastName);
        }
    }
}
