namespace CompanyHierarchy
{
    using System;

    using CompanyHierarchy.Enums;
    using CompanyHierarchy.Interfaces;
    using System.Text;

    public class Project : IProject
    {
        private string projectName;
        private DateTime projectStart;
        private DateTime date;
        private string detals;
        private State state;

        public Project(string projectName, DateTime startDate, string details)
        {
            this.ProjcetName = projectName;
            this.ProjectStart = startDate;
            this.Details = details;
        }

        public string ProjcetName
        {
            get
            {
                return this.projectName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Project name cannot be null!");
                }

                this.projectName = value;
            }
        }

        public DateTime ProjectStart
        {
            get
            {
                return this.projectStart;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Project start date cannot be null!");
                }

                this.projectStart = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Project date cannot be null!");
                }

                this.date = value;
            }
        }

        public string Details
        {
            get
            {
                return this.detals;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Project detals cannot be null!");
                }

                this.detals = value;
            }
        }

        public State State
        {
            get
            {
                return this.state;
            }
            set
            {
                this.state = State.Open;
            }
        }

        public void CloseProject()
        {
            if (this.State == State.Open)
            {
                this.State = State.Closed;
            }
            else
            {
                Console.WriteLine("The project is already closed!");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Project name: " + this.ProjcetName);
            sb.AppendLine("Details: " + this.Details);
            sb.AppendLine("State: " + this.State);

            return sb.ToString();
        }
    }
}
