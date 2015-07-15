namespace SalesEmployeeInfo
{
    using SaleInfo;
    using RegularEmployeeInfo;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class SalesEmployee : RegularEmployee
    {
        private List<Sale> sales;
        public SalesEmployee(string firstName, string lastName, int id, decimal salary, string department, List<Sale> sales)
            : base(firstName, lastName, id, salary, department)
        {
            this.Sales = sales;
        }

        public List<Sale> Sales 
        { 
            get
            {
                return this.sales;
            }
            set
            {
                this.sales = value;
            }
        }

        public override string ToString()
        {
            string sales = string.Join("\n", this.Sales);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("First name: " + this.FirstName);
            sb.AppendLine("Last name: " + this.LastName);
            sb.AppendLine("ID: " + this.Id);
            sb.AppendLine("Salary: " + this.Salary);
            sb.AppendLine("Department: " + this.Department);
            sb.AppendLine("Sales: \n" + sales);

            return sb.ToString();
        }
    }
}
