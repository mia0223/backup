using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    interface IUserFilter
    {
        List<UserInfo> ByDepartment(string department);
        List<UserInfo> ByDepartmentAndPartialName(string department, string partialName);
    }
}
