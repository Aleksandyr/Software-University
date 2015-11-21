namespace CompanyHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CompanyHierarchy.Enums;
    using CompanyHierarchy.Interfaces;

    public class Manager : Employee, IManager
    {
        private ICollection<Employee> employees;

        public Manager(int id, string firstName, string lastName, decimal salary, Department department, HashSet<Employee> employees)
            : base (id, firstName, lastName, salary, department)
        {
            this.Employees = employees;
        }

        public virtual ICollection<Employee> Employees
        {
            get
            {
                return this.employees;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Employees collection cannot be null!");
                }

                this.employees = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Emplyees under command!");
            foreach (var employee in this.Employees)
            {
                sb.AppendLine(employee.ToString());
            }

            return base.ToString() + "\n" +sb.ToString();
        }
    }
}
