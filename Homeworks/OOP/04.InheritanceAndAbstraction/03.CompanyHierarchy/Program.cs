namespace CompanyHierarchy
{
    using CompanyHierarchy;
    using CompanyHierarchy.Enums;
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main()
        {
            Sale dairy = new Sale("Milk", new DateTime(2014, 10, 1), 2.50m);
            Sale chocolate = new Sale("Chocolate", new DateTime(2014, 10, 1), 1.80m);
            Sale meat = new Sale("Meat", new DateTime(2014, 10, 1), 4.80m);
            Sale vegitables = new Sale("Vegitables", new DateTime(2014, 10, 1), 3.80m);
            Sale books = new Sale("C# Programming", new DateTime(2014, 10, 2), 9.90m);
            Sale laptop = new Sale("Toshiba Satelite", new DateTime(2014, 10, 2), 999.90m);
            Sale beer = new Sale("Stolichno tymno", new DateTime(2014, 10, 3), 1.75m);
            Sale whiskey = new Sale("Jameson", new DateTime(2014, 10, 3), 29.50m);

            var foodSales = new HashSet<Sale>();
            foodSales.Add(dairy);
            foodSales.Add(chocolate);
            foodSales.Add(meat);
            foodSales.Add(vegitables);

            var otherSales = new HashSet<Sale>();
            otherSales.Add(books);
            otherSales.Add(laptop);
            otherSales.Add(beer);
            otherSales.Add(whiskey);

            Project CSharp = new Project("Accounting system", new DateTime(2014, 9, 15), "N/A");
            Project Java = new Project("Booking system", new DateTime(2014, 5, 13), "N/A");
            Project PHP = new Project("Database Center", new DateTime(2014, 8, 20), "N/A");
            Project JavaScript = new Project("On-line games", new DateTime(2014, 7, 28), "N/A");
            Project HTML_CSS = new Project("A fancy web-site", new DateTime(2014, 8, 8), "N/A");

            var webPoejcts = new HashSet<Project>();
            webPoejcts.Add(HTML_CSS);
            webPoejcts.Add(JavaScript);
            webPoejcts.Add(Java);

            var otherProjects = new HashSet<Project>();
            otherProjects.Add(CSharp);
            otherProjects.Add(PHP);

            RegularEmployee foodSalesEmployee = new SalesEmployee(100, "Ivan", "Ivanov", 1000, Department.Sales, foodSales);
            RegularEmployee othersSalesEmployee = new SalesEmployee(97, "Dragan", "Peshev", 1400, Department.Sales, otherSales);

            RegularEmployee webDeveloper = new Developer(333, "Maria", "Mainova", 1800, Department.Marketing, webPoejcts);
            RegularEmployee appDevelooper = new Developer(666, "Gosho", "Topciev", 2800, Department.Production, otherProjects);

            var otherEmployees = new HashSet<Employee>();
            otherEmployees.Add(foodSalesEmployee);
            otherEmployees.Add(othersSalesEmployee);

            var programmerEmployees = new HashSet<Employee>();
            programmerEmployees.Add(webDeveloper);
            programmerEmployees.Add(appDevelooper);

            Employee programmingManager = new Manager(1, "Muncho", "Gunchev", 5000, Department.Sales, programmerEmployees);
            Employee accountingManager = new Manager(2, "Iskra", "Gringo", 4000, Department.Accounting, otherEmployees);

            var managers = new List<Person>();
            managers.Add(programmingManager);
            managers.Add(accountingManager);

            foreach (var manager in managers)
            {
                Console.WriteLine(manager);
            }
        }
    }
}
