namespace CompanyHierarchy.Interfaces
{
    using System.Collections.Generic;

    public interface ISalesEmployee : IRegularEmployee
    {
        ICollection<Sale> Sales { get; set; }
    }
}
