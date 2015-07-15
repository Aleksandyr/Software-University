using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.CallAStoredFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new SoftUniEntities();
            var projects = db.usp_AllProjectsForGivenEmployee("Pesho", "Gilbert");

            foreach (var project in projects)
            {
                Console.WriteLine(project);
            }
        }
    }
}
