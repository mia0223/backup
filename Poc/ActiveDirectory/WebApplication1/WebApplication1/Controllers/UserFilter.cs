using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserFilter : IUserFilter
    {
        private const string DomainName = "CORPORATE"; 
        public List<UserInfo> ByDepartmentAndPartialName(string department, string partialName)
        {
            using (var context = new PrincipalContext(ContextType.Domain, DomainName))
            {
                using (var userPrincipal =
                    new UserPrincipalExtended(context) {Department = department, DisplayName = $"*{partialName}*"})
                {
                    return GetUserList(userPrincipal);
                }
            }
        }

        public List<UserInfo> ByDepartment(string depFilter)
        {
            using (var context = new PrincipalContext(ContextType.Domain, DomainName))
            {
                using (var userPrincipal = new UserPrincipalExtended(context) {Department = depFilter})
                {
                    return GetUserList(userPrincipal);
                }
            }
        }


        private List<UserInfo> GetUserList(UserPrincipalExtended userPrincipal)
        {
            List<UserInfo> userList = new List<UserInfo>();
            using (var searcher = new PrincipalSearcher(userPrincipal))
            {
                userList.AddRange(searcher.FindAll()
                    .OfType<UserPrincipalExtended>()
                    .Select(upe => new UserInfo
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