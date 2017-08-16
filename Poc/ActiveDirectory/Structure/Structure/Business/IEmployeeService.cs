using System.Collections.Generic;
using Structure.Models;

namespace Structure.Business
{
    interface IEmployeeService
    {
        List<EmployeeInfo> GetEmployees(string department, string partialName);
    }
}
