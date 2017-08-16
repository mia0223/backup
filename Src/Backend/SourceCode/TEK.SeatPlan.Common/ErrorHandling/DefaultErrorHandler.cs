using System;

namespace TEK.SeatPlan.Common.ErrorHandling
{
    public class DefaultErrorHandler : IErrorHandling
    {
        //private readonly ILogger _logger;

        //public DefaultErrorHandler(ILogger logger)
        //{
        //    _logger = logger;
        //}

        public void CatchAndLog(string className, string methodName, Action actionToHandle)
        {
            Requires.ArgumentNotNull(actionToHandle, nameof(actionToHandle));
            try
            {
                actionToHandle();
            }
            catch (Exception e)
            {
                Console.WriteLine(e + className + methodName);
                throw;
            }
        }

        public TResult CatchAndLog<TResult>(string className, string methodName, Func<TResult> functionToHandle)
        {
            Requires.ArgumentNotNull(functionToHandle, nameof(functionToHandle));
            try
            {
                return functionToHandle();
            }
            catch (Exception e)
            {
                Console.WriteLine(e + className + methodName);
                throw;
            }
        }
    }
}