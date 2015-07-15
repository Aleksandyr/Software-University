using System.Linq;

namespace _06.TwoDifferentDataChanges
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstContext = new SoftUniEntities();
            var secondContext = new SoftUniEntities();

            var firstEmployee = firstContext.Employees.FirstOrDefault(e => e.FirstName == "Rob");
            var secondEmployee = secondContext.Employees.FirstOrDefault(e => e.FirstName == "Rob");

            firstEmployee.FirstName = "Ico";
            secondEmployee.FirstName = "Misho";

            firstContext.SaveChanges();
            secondContext.SaveChanges();
        }
    }
}
