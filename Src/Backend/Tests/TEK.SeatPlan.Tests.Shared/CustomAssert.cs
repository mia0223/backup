using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TEK.SeatPlan.Tests.Shared
{
    public static class CustomAssert
    {
        public static Exception ExpectedExceptionRaised(Action actionThatThrowException, Type exceptionType)
        {
            Exception ex = null;
            try
            {
                actionThatThrowException();
            }
            catch (Exception exception)
            {
                ex = exception;
            }
            Assert.IsNotNull(ex);
            Assert.IsInstanceOfType(ex, exceptionType);
            return ex;
        }
    }
}
