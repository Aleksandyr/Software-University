namespace HumanStudentAndWorker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            Student pesho = new Student("pesho", "petrov", "20144567");
            Student gosho = new Student("gosho", "georgiev", "20141730");
            Student misho = new Student("misho", "mishev", "20142589");
            Student ganka = new Student("ganka", "gancheva", "20146547");
            Student sanya = new Student("sanya", "mincheva", "20145285");
            Student ivan = new Student("ivan", "ivanov", "20145687");
            Student dimitar = new Student("dimitar", "dimitrov", "20143698");
            Student damyan = new Student("damyan", "damyanov", "20149634");
            Student mihail = new Student("mihail", "petrov", "20147415");
            Student doncho = new Student("doncho", "donchev", "20145612");

            List<Student> students = new List<Student>()
            {
                pesho,
                gosho,
                misho,
                ganka,
                sanya,
                ivan,
                dimitar, 
                damyan,
                mihail,
                doncho
            };

            Worker kosta = new Worker("kosta", "kostadinov", 282m, 8);
            Worker sancho = new Worker("sancho", "pansa", 382m, 6);
            Worker penka = new Worker("penka", "kostadinova", 243m, 4);
            Worker dimitrichka = new Worker("dimitrichka", "doynova", 152m, 2);
            Worker darina = new Worker("darina", "stamatova", 182m, 5);
            Worker zlatomir = new Worker("zlatomir", "zlatev", 242m, 7);
            Worker petar = new Worker("petar", "donchev", 482m, 6);
            Worker pencho = new Worker("pencho", "kubadinski", 578m, 9);
            Worker marko = new Worker("marko", "totev", 439m, 8);
            Worker kostadin = new Worker("kostadin", "haralambov", 658m, 9);

            List<Worker> workers = new List<Worker>()
            {
                kosta,
                sancho,
                penka,
                dimitrichka,
                darina,
                zlatomir,
                petar,
                pencho,
                marko,
                kostadin
            };

            Console.WriteLine("Sorted students");
            var sortedStudents = students.OrderBy(s => s.FacultyNumber);
            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
            Console.WriteLine();

            Console.WriteLine("Sorted workers");
            var sortedWorkers = workers.OrderByDescending(w => w.MoneyPerHour(Worker.WorkDays));
            foreach (var worker in workers)
            {
                Console.WriteLine(worker);
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
            Console.WriteLine();

            Console.WriteLine("Sorted humans");
            List<Human> humans = new List<Human>();
            humans.AddRange(students);
            humans.AddRange(workers);
            var sortedHumans = humans
                .OrderBy(h => h.FirstName)
                .ThenBy(h => h.LastName);

            foreach (var human in sortedHumans)
            {
                Console.WriteLine(human);
            }
        }
    }
}
