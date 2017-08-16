using System;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Diagnostics.CodeAnalysis;

using TEK.SeatPlan.Common;

namespace TEK.SeatPlan.WebApi
{
   [ExcludeFromCodeCoverage]
    public class DefaultExceptionHandler : ExceptionHandler
    {
        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            return true;
        }

        public override void Handle(ExceptionHandlerContext context)
        {
            Requires.ArgumentNotNull(context, nameof(context));

            var requestContext = context.RequestContext;
            var config = requestContext.Configuration;

            context.Result = new CustomErrorMessage(
				context.Exception,
                true,
                config.Services.GetContentNegotiator(),
                context.Request,
                config.Formatters);
        }
    }
}