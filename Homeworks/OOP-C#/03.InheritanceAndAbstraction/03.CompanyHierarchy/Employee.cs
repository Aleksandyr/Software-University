namespace EmployeeInfo
{
    using Interfaces;
    using PersonInfo;
    using System;

    public enum Department
    {
        Production, 
        Accounting, 
        Sales,
        Marketing
    }

    public abstract class Employee : Person, IEmployee
    {
        private decimal salary;
        private string department;

        protected Employee(string firstName, string lastName, int id, decimal salary, string department)
            : base(firstName, lastName, id)
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
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("Salary can not be negative!");
                }

                this.salary = value;
            }
        }

        public string Department 
        { 
            get
            {
                return this.department;
            }
            set
            {
                if (!(value.Contains("Production") || value.Contains("Accounting") || 
                    value.Contains("Sales") || value.Contains("Marketing")))
                {
                    throw new ArgumentException("Department can be only Production, Accounting, Sales or Marketing!");
                }

                this.department = value;
            }
        }
    }
}
