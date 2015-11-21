namespace CompanyHierarchy
{
    using CompanyHierarchy.Enums;
    using CompanyHierarchy.Interfaces;

    public abstract class RegularEmployee : Employee, IRegularEmployee
    {
        protected RegularEmployee(int id, string firstName, string lastName, decimal salary, Department department)
            : base(id ,firstName, lastName, salary, department)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
