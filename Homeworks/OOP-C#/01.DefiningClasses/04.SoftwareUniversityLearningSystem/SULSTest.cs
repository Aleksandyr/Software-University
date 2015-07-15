namespace SoftwareUniversityLearningSystem
{
    using CurrentStudentInfo;
    using DropoutStudentInfo;
    using GraduateStudentInfo;
    using JuniorTrainerInfo;
    using OnlineStudentInfo;
    using OnsiteStudentInfo;
    using PersonInfo;
    using SeniorTrainerInfo;
    using StudentInfo;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TrainerInfo;


    class SULSTest
    {
        static void Main()
        {
            Trainer nikbank = new JuniorTrainer("Nikolay", "Bankin");
            Trainer vGeorg = new SeniorTrainer("Vlado", "Geogiev");
            Trainer nakov = new SeniorTrainer("Svetlin", "Nakov");
            Trainer aRus = new JuniorTrainer("Atanas", "Rusenov");

            Student toi = new GraduateStudent("Zavyrshil", "Student", 80002341, (float)5.46);
            Student blagoi = new GraduateStudent("Blago", "Peshev", 80002145, (float)5.22);
            Student misho = new GraduateStudent("Misho", "Mishev", 80004587, (float)5.96);

            Student pesho = new DropoutStudent("Pesho", "Peshev", "low result");
            Student katya = new DropoutStudent("Katya", "Ivanova", "family reasons");

            CurrentStudent valyo = new OnlineStudent("Valentin", "Petrov", 50006541, (float)3.45, "C#");
            CurrentStudent geca = new OnlineStudent("Georgi", "Petrov", 50002389, (float)4.45, "Java");
            CurrentStudent batkata = new OnsiteStudent("Botyo", "Botev", 50009841, (float)5.85, "Java", 20);

            List<Person> persons = new List<Person>() { nikbank,vGeorg,nakov,aRus,toi, blagoi,misho,
                pesho, katya,valyo,geca,batkata};

            persons.Where(p => p is CurrentStudent).OrderBy(p => ((Student)p).AvgGrade).ToList().ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
