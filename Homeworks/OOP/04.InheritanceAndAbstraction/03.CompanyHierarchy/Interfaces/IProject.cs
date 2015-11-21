namespace CompanyHierarchy.Interfaces
{
    using CompanyHierarchy.Enums;
    using System;

    public interface IProject
    {
        string ProjcetName { get; set; }

        DateTime ProjectStart { get; set; }

        DateTime Date { get; set; }

        string Details { get; set; }

        State State { get; set; }

        void CloseProject();
    }
}
