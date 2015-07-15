using EmployeeInfo;
using System.Collections.Generic;
namespace Interfaces
{
    interface IManager
    {
        List<Employee> EmployeeControl { get; set; } 
    }
}
