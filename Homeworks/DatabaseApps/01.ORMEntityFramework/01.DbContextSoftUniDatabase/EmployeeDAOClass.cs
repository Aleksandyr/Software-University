using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace _01.DbContextSoftUniDatabase
{
    public class EmployeeDAOClass
    {
        public static void InsertEmployee(string firstName, string lastName, string jobTitle, string department,
            DateTime hireDate, int salary)
        {
            var db = new SoftUniDb();

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
            var db = new SoftUniDb();

            var employee = db.Employees.Find(id);
            employee.FirstName = firstName;

            db.SaveChanges();
        }

        public static void DeleteEmployeeFromId(int id)
        {
            var db = new SoftUniDb();
            var employee = db.Employees.Find(2);
            db.Employees.Remove(employee);
            db.SaveChanges();
        }
    }
}
