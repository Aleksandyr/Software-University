using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.EntityFrameworkExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //problem1
            //var context = new SoftUniEntities();
            //var employeeNames = context.Employees.Where(e => e.Salary > 50000).Select(e => e.FirstName);
            //foreach (var employeeName in employeeNames)
            //{
            //    Console.WriteLine(employeeName);
            //}


            //problem2
            //var context = new SoftUniEntities();
            //var employees =
            //    context.Employees.Where(e => e.Department.Name == "Research and Development")
            //    .OrderBy(e => e.Salary).ThenByDescending(e => e.FirstName);
            //foreach (var employee in employees)
            //{
            //    Console.WriteLine("{0} {1} from {2} - ${3:F2}", 
            //        employee.FirstName, 
            //        employee.LastName, 
            //        employee.Department.Name, 
            //        employee.Salary);
            //}



            //Problem 3
            //var context = new SoftUniEntities();

            //var address = new Address()
            //{
            //    AddressText = "Vitoshka 15",
            //    TownID = 4
            //};

            //var empNakov = context.Employees.First(e => e.LastName == "Nakov");
            //empNakov.Address = address;

            //context.Addresses.Add(address);
            //Console.WriteLine(empNakov.Address.AddressText);
            //context.SaveChanges();


            //problem 4
            //var db = new SoftUniEntities();

            //var project = db.Projects.Find(2);

            //db.Projects.Remove(project);

            //foreach (var employee in db.Employees)
            //{
            //    employee.Projects.Remove(project);
            //}

            //db.SaveChanges();
        }
    }
}
