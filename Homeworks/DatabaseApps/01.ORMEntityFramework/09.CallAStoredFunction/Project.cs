//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _09.CallAStoredFunction
{
    using System;
    using System.Collections.Generic;
    
    public partial class Project
    {
        public Project()
        {
            this.Employees = new HashSet<Employee>();
        }
    
        public int ProjectID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
