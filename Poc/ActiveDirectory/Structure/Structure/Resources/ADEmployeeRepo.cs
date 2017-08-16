using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using Structure.Models;

namespace Structure.Resources
{
    public class ADEmployeeRepo : IADEmployeeRepo
    {
        private const string DomainName = "CORPORATE";
        public List<EmployeeInfo> ByDepartment(string department)
        {
            using (var context = new PrincipalContext(ContextType.Domain, DomainName))
            {
                using (var userPrincipal =
                    new UserPrincipalExtended(context) { Department = department} )
                {
                    return GetUserList(userPrincipal);
                }
            }
        }



        public List<EmployeeInfo> ByDepartmentAndPartialName(string department, string partialName)
        {
            using (var context = new PrincipalContext(ContextType.Domain, DomainName))
            {
                using (var userPrincipal =
                    new UserPrincipalExtended(context) { Department = department, DisplayName = $"*{partialName}*" })
                {
                    return GetUserList(userPrincipal);
                }
            }
        }

        private List<EmployeeInfo> GetUserList(UserPrincipalExtended userPrincipal)
        {
            List<EmployeeInfo> userList = new List<EmployeeInfo>();
            using (var searcher = new PrincipalSearcher(userPrincipal))
            {
                userList.AddRange(searcher.FindAll()
                    .OfType<UserPrincipalExtended>()
                    .Select(upe => new EmployeeInfo()
                    {
                        Departement = upe.Department,
                        DisplayName = upe.DisplayName,
                        UserPrincipalName = upe.UserPrincipalName
                    }));
            }

            return userList;
        }
    }
}