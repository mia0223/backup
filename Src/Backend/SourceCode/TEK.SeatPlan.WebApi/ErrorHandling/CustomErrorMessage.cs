using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace TEK.SeatPlan.WebApi
{
   [ExcludeFromCodeCoverage]
   public class CustomErrorMessage : ExceptionResult
   {
      public CustomErrorMessage(
		  Exception exception, bool includeErrorDetail, IContentNegotiator contentNegotiator,
		  HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters) :
          base(exception, includeErrorDetail, contentNegotiator, request, formatters) { }

      public CustomErrorMessage(Exception exception, ApiController controller) :
          base(exception, controller)
      {
      }

      public override Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
      {
         return Task.Run(() =>
			Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"{Exception.HelpLink}: {Exception.Message}"),
            cancellationToken);
      }
   }
}