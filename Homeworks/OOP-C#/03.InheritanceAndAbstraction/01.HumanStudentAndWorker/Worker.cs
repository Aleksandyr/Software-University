using HumanInfo;
using System;
using System.Text;

namespace WorkerInfo
{
    public class Worker : Human
    {
        private const int workDaysPerWeek = 5; 

        private decimal weekSalary;
        private int workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay) 
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary 
        { 
            get
            {
                return this.weekSalary;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("Week salary can not be negative!");
                }

                this.weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Work hours can not be negative!");
                }

                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            return ((this.WeekSalary) / (this.WorkHoursPerDay * workDaysPerWeek));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("First Name: " + this.FirstName);
            sb.AppendLine("Last Name: " + this.LastName);
            sb.AppendLine("Week Salary: " + this.WeekSalary);
            sb.AppendLine("Work hours per day: " + this.workHoursPerDay);
            sb.AppendLine("Money per hour: " + this.MoneyPerHour());

            return sb.ToString();
        }
    }
}
