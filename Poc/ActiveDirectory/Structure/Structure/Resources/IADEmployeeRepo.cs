using System.Collections.Generic;
using Structure.Models;

namespace Structure.Resources
{
    interface IADEmployeeRepo
    {
        List<EmployeeInfo> ByDepartment(string department);
        List<EmployeeInfo> ByDepartmentAndPartialName(string department, string partialName);
    }
}
