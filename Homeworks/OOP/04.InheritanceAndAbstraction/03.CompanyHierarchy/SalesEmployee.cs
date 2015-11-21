namespace CompanyHierarchy
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using CompanyHierarchy.Enums;
    using CompanyHierarchy.Interfaces;

    public class SalesEmployee : RegularEmployee, ISalesEmployee
    {
        private ICollection<Sale> sales;

        public SalesEmployee(int id, string firstName, string lastName, decimal salary, Department department, HashSet<Sale> sales)
            : base(id ,firstName, lastName, salary, department)
        {
            this.Sales = sales;
        }

        public ICollection<Sale> Sales
        {
            get
            {
                return this.sales;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Sales collection cannot be null!");
                }

                this.sales = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Sales list: ");
            foreach (var sale in this.Sales)
            {
                sb.AppendLine(sale.ToString());
            }

            return base.ToString() + "\n" + sb.ToString();
        }
    }
}
