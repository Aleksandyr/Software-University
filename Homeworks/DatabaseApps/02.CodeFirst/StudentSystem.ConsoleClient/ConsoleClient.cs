using System;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using StudentSyste.Data;
using StudentSystem.Model;

namespace StudentSystem.ConsoleClient
{
    class ConsoleClient
    {
        static void Main()
        {
            Console.WriteLine("Students info: ");
            var db = new StudentSystemEntities();
            var studentHomeworks = db.Students.Select(s => new
            {
                Name = s.Name,
                Homewroks = s.Courses.Select(c => c.Homewroks.Select(h => new
                {
                   h.Content,
                   h.ContentType
                }))
            }).ToList();

            foreach (var studentHomework in studentHomeworks)
            {
                Console.WriteLine(studentHomework.Name);
                foreach (var homework in studentHomework.Homewroks)
                {
                    homework.ToList().ForEach(h => Console.WriteLine("{0}-{1}", h.Content, h.ContentType));
                }
            }

            Console.WriteLine("Course Info:");

            var courses = db.Courses.Include(r => r.Resources)
                .OrderBy(c => c.StartDate)
                .ThenByDescending(c => c.EndDate)
                .Select(c => new
                {
                    c.Name,
                    c.Description,
                    c.Resources
                });
            
            foreach (var course in courses)
            {
                Console.WriteLine(course.Name + "\nDescription: " + course.Description);
                foreach (var resource in course.Resources)
                {
                    Console.WriteLine("Resouces: " + resource.Name + "\nType: " + resource.TypeOfResource + "\nURL:" + resource.URL);
                }
            }

            Console.WriteLine("All courses with more than 5 resources:");

            var coursesWith5OrMoreResources = db.Courses
                .Where(c => c.Resources.Count > 5)
                .OrderByDescending(c => c.Resources.Count)
                .ThenByDescending(c => c.StartDate)
                .Select(c => new
                {
                    c.Name,
                    c.Resources.Count
                });
            foreach (var course in coursesWith5OrMoreResources)
            {
                Console.WriteLine(course);
            }

            
            var date = DateTime.Now;
            var coursesActiveOnAGivenDate = db.Courses
                .Where(c => c.StartDate < date && c.EndDate >= date)
                .ToList()
                .OrderByDescending(c => c.Students.Count)
                .ThenByDescending(c => (c.EndDate - c.StartDate).TotalDays)
                .Select(c => new
                {
                    c.Name,
                    c.StartDate,
                    c.EndDate,
                    CountStudetns = c.Students.Count,
                    CourseDarution = (c.EndDate - c.StartDate).TotalDays,
                }).ToList();
            foreach (var course in coursesActiveOnAGivenDate)
            {
                Console.WriteLine("Coures Name: {0}, Start Date: {1:dd-MM-yyyy}, End Date: {2:dd-MM-yyyy}, Days: {3}, Students: {4}",
                    course.Name, course.StartDate, course.EndDate, course.CourseDarution, course.CountStudetns);
            }

            var allStudentsWithPrice = db.Students
                .OrderByDescending(s => s.Courses.Sum(c => c.Price))
                .ThenByDescending(s => s.Courses.Count)
                .ThenBy(s => s.Name)
                .Select(s => new
                {
                    s.Name,
                    NumberOfCourses = s.Courses.Count,
                    TotalPrice = s.Courses.Sum(c => c.Price),
                    AvgPrice = s.Courses.Average(c => c.Price)
                }).ToList();

            foreach (var student in allStudentsWithPrice)
            {
                Console.WriteLine("Name: {0}, {1} courses, totalPrice: {2}, AvgPrice: {3}", student.Name, student.NumberOfCourses, student.TotalPrice, student.AvgPrice);
            }
        }
    }
}
