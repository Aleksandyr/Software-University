namespace ManagerInfo
{
    using EmployeeInfo;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Manager : Employee
    {
        private List<Employee> employeeControl;
        public Manager(string firstName, string lastName, int id, decimal salary, string department,
            List<Employee> employeesControl)
            : base(firstName, lastName, id, salary, department)
        {
            this.EmployeeControl = employeesControl;
        }

        public List<Employee> EmployeeControl 
        { 
            get
            {
                return this.employeeControl;
            }
            set
            {
                this.employeeControl = value;
            }
        }

        public override string ToString()
        {
            string emloyeesControl = string.Join("\n", this.EmployeeControl);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("First name: " + this.FirstName);
            sb.AppendLine("Last name: " + this.LastName);
            sb.AppendLine("ID: " + this.Id);
            sb.AppendLine("Salary: " + this.Salary);
            sb.AppendLine("Department: " + this.Department);
            sb.AppendLine("Employees: \n" + emloyeesControl);

            return sb.ToString();
        }
    }
}
