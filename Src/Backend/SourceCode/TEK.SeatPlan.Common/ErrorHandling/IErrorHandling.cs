using System;

namespace TEK.SeatPlan.Common.ErrorHandling
{
    public interface IErrorHandling
    {
        void CatchAndLog(string className, string methodName,Action actionToHandle);
        TResult CatchAndLog<TResult>(string className, string methodName, Func<TResult> functionToHandle);
    }
}
