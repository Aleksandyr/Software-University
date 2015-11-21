namespace CompanyHierarchy.Interfaces
{
    using CompanyHierarchy.Enums;

    public interface IEmployee
    {
        decimal Salary { get; set; }

        Department Department { get; set; }
    }
}
