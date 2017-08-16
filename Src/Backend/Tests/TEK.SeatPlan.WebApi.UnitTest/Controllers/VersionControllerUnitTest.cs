using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TEK.SeatPlan.BusinessLogic.Contract;
using TEK.SeatPlan.Entity;
using TEK.SeatPlan.WebApi.Controllers;

namespace TEK.SeatPlan.WebApi.UnitTest.Controllers
{
    [TestClass]
    public class VersionControllerUnitTest
    {
        private VersionController sut;
        private Mock<IVersionComponent> versionComponent;

        [TestInitialize]
        public void Initialize()
        {
            versionComponent = new Mock<IVersionComponent>();
            sut = new VersionController(versionComponent.Object);
        }

        [TestClass]
        public class WhenGet : VersionControllerUnitTest
        {
            [TestMethod]
            public void AndExecutingAssemblyHasLocation_Then_ShouldReturnProductVersion()
            {
                versionComponent
                    .Setup(x => x.GetVersion())
                    .Returns(new Version(1, 0, 0, 0).ToString);

                var result = sut.Get();

                Assert.IsNotNull(result);
                Assert.AreEqual("1.0.0.0", result);
                versionComponent.Verify(x => x.GetVersion(), Times.Once);
            }
        }
    }
}
