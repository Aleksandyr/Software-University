namespace CompanyHierarchy
{
    using System;

    using CompanyHierarchy.Interfaces;
    using System.Collections.Generic;
    using CompanyHierarchy.Enums;
    using System.Text;

    public class Developer : RegularEmployee, IDeveloper
    {
        private ICollection<Project> projects;

        public Developer(int id, string firstName, string lastName, decimal salary, Department department, HashSet<Project> projects)
            : base(id ,firstName, lastName, salary, department)
        {
            this.Projects = projects;
        }

        public ICollection<Project> Projects
        {
            get
            {
                return this.projects;
            }
            set
            {
                if (value == null)
	            {
                    throw new ArgumentNullException("Project collection cannot be null!");
	            }

                this.projects = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Project list: ");
            foreach (var project in this.Projects)
            {
                sb.AppendLine(project.ToString());
            }

            return base.ToString() + sb.ToString();
        }
    }
}
