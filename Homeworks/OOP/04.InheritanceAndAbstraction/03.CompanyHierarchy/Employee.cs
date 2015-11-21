namespace CompanyHierarchy
{
    using System;

    using CompanyHierarchy.Enums;
    using CompanyHierarchy.Interfaces;

    public abstract class Employee : Person, IEmployee
    {
        private decimal salary;
        private Department department;

        protected Employee(int id, string firstName, string lastName, decimal salary, Department department)
            : base (id, firstName, lastName)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Salary can not be negative !");
                }

                this.salary = value;
            }
        }

        public Department Department 
        { 
            get
            {
                return this.department;
            }
            set
            {
                this.department = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("\nSalary: " + this.Salary + "\nDepartment: " + this.Department);
        }
    }
}
