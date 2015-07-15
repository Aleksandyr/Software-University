using System;
namespace ProjectInfo
{
    using System;
    using System.Text;

    public enum State
    {
        Open,
        Closed
    }

    public class Project
    {
        private string projectName;
        private DateTime projectStartDate;
        private State state;

        public Project(string projectName, DateTime projectStartDate, State state)
        {
            this.ProjcetName = projectName;
            this.ProjectStartDate = projectStartDate;
            this.State = state;
        }

        public string ProjcetName 
        { 
            get
            {
                return this.projectName;
            }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Project name can not be null or empty!");
                }

                this.projectName = value;
            }
        }

        public DateTime ProjectStartDate 
        { 
            get
            {
                return this.projectStartDate;
            }
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException("Project start date name can not be null!");
                }

                this.projectStartDate = value;
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
                this.state = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Project name: " + this.ProjcetName);
            sb.AppendLine("Project start: " + this.ProjectStartDate);
            sb.AppendLine("State: " + this.State);

            return sb.ToString();
        }
    }
}
