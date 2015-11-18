namespace HumanStudentAndWorker
{
    using System;
    using System.Text;

    public class Worker : Human
    {
        public const int WorkDays = 5;

        private decimal weekSalary;
        private int workHoursPerDay;

        public Worker(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }

        public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay)
            : this(firstName, lastName)
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
                if (value < 0)
                {
                    throw new ArgumentException("Salary can not be negative!");
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
                    throw new ArgumentException("Hours can not be negative!");
                }

                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour(int daysPerWeek)
        {
            decimal hoursePerWeek = this.WorkHoursPerDay * daysPerWeek;
            return this.WeekSalary / hoursePerWeek;
        }

        public override string ToString()
        {         
            return base.ToString() + string.Format("Money per hour: " + this.MoneyPerHour(Worker.WorkDays));
        }
    }
}
