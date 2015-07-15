namespace RegularEmployeeInfo
{
    using EmployeeInfo;
    using System;


    public class RegularEmployee : Employee
    {
        public RegularEmployee(string firstName, string lastName, int id, decimal salary, string department)
            : base(firstName, lastName, id, salary, department)
        {
        }
    }
}
