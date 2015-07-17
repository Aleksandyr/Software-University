using System;

namespace _06.CallAStoredProcedure
{
    class Program
    {
        static void Main()
        {
            var db = new SoftUniEntities();
            var projects = db.usp_AllProjectsForGivenEmployee("Pesho", "Gilbert");

            foreach (var project in projects)
            {
                Console.WriteLine(project.Name + ", " + project.Description + ", " + project.StartDate);   
            }
        }
    }
}
