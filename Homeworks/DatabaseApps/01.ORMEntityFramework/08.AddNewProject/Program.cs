using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.AddNewProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new SoftUniEntities();
            var employees = new List<Employee>()
            {
                db.Employees.FirstOrDefault(e => e.FirstName == "Roberto"),
                db.Employees.FirstOrDefault(e => e.FirstName == "Pesho"),
                db.Employees.FirstOrDefault(e => e.FirstName == "Misho")
            };

            var project = new Project()
            {
                Name = "Test project",
                StartDate = new DateTime(2014, 11, 25),
                EndDate = new DateTime(2015, 05, 25),
                Employees = employees
            };
          
            if (project != null)
            {
                Console.WriteLine("Project successfull added!");
            }

            db.Projects.Add(project);
            db.SaveChanges();
            
        }
    }
}
