using Microsoft.VisualStudio.TestTools.UnitTesting;
using TEK.SeatPlan.Ioc;
using Castle.Windsor;

namespace TEK.SeatPlan.IntegrationTest
{
    [TestClass]
    public abstract class IntegrationTestBase
    {
        private IWindsorContainer container = default(IWindsorContainer);
        [TestInitialize]
        public virtual void TestInitialize()
        {
            this.container = new WindsorContainer();
            BootStrapper.Configure(this.container);
        }

        [TestCleanup]
        public virtual void TestCleanup()
        {
            this.container?.Dispose();
        }
    }
}
