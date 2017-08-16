using System;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Controllers;
using System.Web.Http.ExceptionHandling;
using System.Diagnostics.CodeAnalysis;

using Castle.Windsor;
using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;

using TEK.SeatPlan.Ioc;

namespace TEK.SeatPlan.WebApi
{
	[ExcludeFromCodeCoverage]
	public class WebApiApplication : HttpApplication
	{
		private readonly IWindsorContainer container;

		public WebApiApplication() : base()
		{
			this.container = new WindsorContainer();
			BootStrapper.Configure(this.container);

			this.container.AddFacility<LoggingFacility>(f => f.LogUsing(LoggerImplementation.NLog).WithConfig("NLog.config"));
			this.container.Register(Classes.FromThisAssembly().BasedOn<IHttpController>().LifestylePerWebRequest());
		}

		protected void Application_Start()
		{
			GlobalConfiguration.Configure(WebApiConfig.Register);

			GlobalConfiguration.Configuration.Services.Replace(
				typeof(IHttpControllerActivator),
				new WebApiControllerActivator(this.container));

			GlobalConfiguration.Configuration.Services.Replace(typeof(IExceptionHandler),
				new DefaultExceptionHandler());

			var logger = container.Resolve<Castle.Core.Logging.ILogger>();

			GlobalConfiguration.Configuration.Services.Add(typeof(IExceptionLogger),
				new DefaultExceptionLogger(logger));
		}

		public sealed override void Dispose()
		{
			this.container?.Dispose();
			base.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}