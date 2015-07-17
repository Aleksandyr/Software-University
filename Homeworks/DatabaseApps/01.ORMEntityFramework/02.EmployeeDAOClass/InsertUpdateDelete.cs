using System;
using System.Linq;
using _01.DBContextSoftuni;

namespace _02.EmployeeDAOClass
{
    class InsertUpdateDelete
    {
        public static void InsertEmployee(string firstName, string lastName, string jobTitle, string department,
            DateTime hireDate, int salary)
        {
            var db = new SoftUniEntities();

            var depName = db.Departments.First(d => d.Name == department.ToString());

            var employee = new Employee()
            {
                FirstName = firstName,
                LastName = lastName,
                JobTitle = jobTitle,
                DepartmentID = depName.DepartmentID,
                HireDate = hireDate,
                Salary = salary
            };

            db.Employees.Add(employee);
            db.SaveChanges();
        }

        public static void UpdateFirstNameOfEmployee(int id, string firstName)
        {
            var db = new SoftUniEntities();

            var employee = db.Employees.Find(id);
            employee.FirstName = firstName;

            db.SaveChanges();
        }

        public static void DeleteEmployeeFromId(int id)
        {
            var db = new SoftUniEntities();
            var employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
        }
    }
}
