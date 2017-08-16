﻿using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApplication1
{
   public static class WebApiConfig
   {
      public static void Register(HttpConfiguration config)
      {
         // Web API configuration and services
         config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
         config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

          var cors = new EnableCorsAttribute("*", "*", "*");
          config.EnableCors(cors);
            // Web API routes
            config.MapHttpAttributeRoutes();

         config.Routes.MapHttpRoute(
             name: "DefaultApi",
             routeTemplate: "api/{controller}/{id}",
             defaults: new { id = RouteParameter.Optional }
         );
      }
   }
}
