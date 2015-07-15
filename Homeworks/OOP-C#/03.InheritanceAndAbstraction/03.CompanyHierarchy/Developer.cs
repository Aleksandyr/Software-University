namespace DeveloperInfo
{
    using ProjectInfo;
    using RegularEmployeeInfo;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Developer : RegularEmployee
    {
        private List<Project> projects;

        public Developer(string firstName, string lastName, int id, decimal salary, string department, List<Project> projects)
            : base(firstName, lastName, id, salary, department)
        {
            this.Projects = projects;
        }

        public List<Project> Projects 
        { 
            get
            {
                return this.projects;
            }
            set
            {
                this.projects = value;
            }
        }

        public override string ToString()
        {
            string projects = string.Join("\n", this.Projects);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("First name: " + this.FirstName);
            sb.AppendLine("Last name: " + this.LastName);
            sb.AppendLine("ID: " + this.Id);
            sb.AppendLine("Salary: " + this.Salary);
            sb.AppendLine("Department: " + this.Department);
            sb.AppendLine("Projects: \n" + projects);

            return sb.ToString();
        }
    }
}
