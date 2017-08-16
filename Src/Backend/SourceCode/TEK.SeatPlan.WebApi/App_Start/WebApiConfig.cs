using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Net.Http.Headers;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;

using Newtonsoft.Json.Serialization;

namespace TEK.SeatPlan.WebApi
{
	[ExcludeFromCodeCoverage]
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			if (config == null)
			{
				throw new ArgumentNullException(nameof(config));
			}

			config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
			config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

			var corsOrigin = ConfigurationManager.AppSettings["corsOrigin"];

			if (!string.IsNullOrEmpty(corsOrigin))
			{
				config.EnableCors(new EnableCorsAttribute(origins: corsOrigin, headers: "*", methods: "*")
				{
					SupportsCredentials = true
				});
			}

			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}