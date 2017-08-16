using System.DirectoryServices.AccountManagement;
using System.Linq;

namespace WebApplication1.Models
{
   [DirectoryObjectClass("user")]
   [DirectoryRdnPrefix("CN")]

   public class UserPrincipalExtended : UserPrincipal
   {
      public UserPrincipalExtended(PrincipalContext context) : base(context)
      {
      }

      [DirectoryProperty("department")]
      public string Department
      {
         get { return ExtensionGet("department").SingleOrDefault() as string; }
         set { ExtensionSet("department", value); }
      }
   }
}
