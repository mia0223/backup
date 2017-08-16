using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{

    // for retrieving the list of users we used active directory integration.
    // we have chosen to NOT use Office 365 built-in request mechanism because of security issue. Office 365 app has to be installed on the account that would need ask for users.
    [AdminAuthorize]
    public class ADUserController : ApiController
   {
       //private const string Department = "00739";
       private readonly IUserFilter _filter;

        public ADUserController()
       {
           _filter = new UserFilter();
       }
        
      // GET: api/ADUser
      public IEnumerable<UserInfo> Get(string department)
      { 
         return _filter.ByDepartment(department);
        // return _filter.GetUserList(userPrincipal);
      }

      // GET: api/ADUser/partialName
      public IEnumerable<UserInfo> Get(string department, string partialName)
      {
          return _filter.ByDepartmentAndPartialName(department, partialName);
          //return _filter.GetUserList(userPrincipal);
      }

      // POST: api/ADUser
      public void Post([FromBody]string value)
      {
      }

      // PUT: api/ADUser/5
      public void Put(int id, [FromBody]string value)
      {
      }

      // DELETE: api/ADUser/5
      public void Delete(int id)
      {
      }
   }

    public class AdminAuthorize : AuthorizeAttribute
    {
        public AdminAuthorize()
        {
            //Authorize multiple groups at the same time
//            var allRoles = ConfigurationManager.AppSettings["adminAccess"].Split(',');
//            this.Roles = string.Join(",", allRoles);
            this.Roles = ConfigurationManager.AppSettings["adminAccess"];
        }
    }
}
