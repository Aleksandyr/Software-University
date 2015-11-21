namespace CompanyHierarchy.Interfaces
{
    using System.Collections.Generic;

    public interface IDeveloper
    {
        ICollection<Project> Projects { get; set; }
    }
}
