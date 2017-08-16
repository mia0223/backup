using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

using Castle.Core.Logging;

namespace TEK.SeatPlan.WebApi.Controllers
{
    [TEKAuthorizeAttribute("adminGroupAccess")]
    public abstract class BaseController : ApiController
	{
		public ILogger Logger { get; set; }

		protected BaseController()
		{
			this.Logger = NullLogger.Instance;
		}

		public override Task<HttpResponseMessage> ExecuteAsync(
			HttpControllerContext controllerContext, CancellationToken cancellationToken)
		{
			if (controllerContext?.Request != null)
			{
				NLog.LogManager.GetLogger("HeaderLogger").Debug(string.Empty);

				this.Logger.Debug
					($"{controllerContext.Request.Method}" +
				    $":{controllerContext.Request.RequestUri.AbsoluteUri}");
			}

			return base.ExecuteAsync(controllerContext, cancellationToken);
		}
	}
}