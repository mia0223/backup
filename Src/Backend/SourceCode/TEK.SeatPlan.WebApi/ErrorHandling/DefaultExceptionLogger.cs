using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using System.Web.Http.ExceptionHandling;
using Castle.Core.Logging;

using TEK.SeatPlan.Common;

namespace TEK.SeatPlan.WebApi
{
    [ExcludeFromCodeCoverage]
    public class DefaultExceptionLogger : ExceptionLogger
    {
        private readonly ILogger logger;

        public DefaultExceptionLogger(ILogger logger)
        {
            Requires.ArgumentNotNull(logger, nameof(logger));
            this.logger = logger;
        }

        public override Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
        {
            Requires.ArgumentNotNull(context, nameof(context));

            return Task.Run(() =>
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    logger.Info("Http Request has been cancelled by the client");
                }

				context.Exception.HelpLink = Guid.NewGuid().GetHashCode().ToString("x").ToUpper();

				logger.FatalFormat(context.Exception, "{0} | {1}: {2}", context.Exception.HelpLink, context.Exception.GetType(), context.Exception);
            });
        }
    }
}