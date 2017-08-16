using System;
using System.Web.Http;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace TEK.SeatPlan.WebApi
{
	[AttributeUsage(AttributeTargets.All)]
	public sealed class TEKAuthorizeAttribute : AuthorizeAttribute
	{
		public TEKAuthorizeAttribute(string groups)
		{
			this.Roles = ConfigurationManager.AppSettings[groups];
		}
	}
}