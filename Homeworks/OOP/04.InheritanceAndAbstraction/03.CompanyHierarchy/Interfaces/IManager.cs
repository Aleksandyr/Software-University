namespace CompanyHierarchy.Interfaces
{
    using CompanyHierarchy;
    using System.Collections.Generic;

    interface IManager
    {
        ICollection<Employee> Employees { get; set; }
    }
}
