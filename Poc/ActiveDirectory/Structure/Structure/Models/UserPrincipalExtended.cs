using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.DirectoryServices.AccountManagement;

namespace Structure.Models
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