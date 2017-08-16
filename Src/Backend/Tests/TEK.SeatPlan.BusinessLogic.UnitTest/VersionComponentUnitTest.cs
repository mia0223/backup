using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TEK.SeatPlan.BusinessLogic.Contract;
using TEK.SeatPlan.Common.AssemblyInfo;

namespace TEK.SeatPlan.BusinessLogic.UnitTest
{
    [TestClass]
    public class VersionComponentUnitTest
    {
        private VersionComponent sut;
        private Mock<IAssemblyInfoProvider> assemblyInfoProvider;

        [TestInitialize]
        public void Initialize()
        {
            assemblyInfoProvider = new Mock<IAssemblyInfoProvider>();
            sut = new VersionComponent(assemblyInfoProvider.Object);
        }

        [TestClass]
        public class GetVersion : VersionComponentUnitTest
        {
            [TestMethod]
            public void AndExecutingAssemblyHasLocation_Then_ShouldReturnProductVersion()
            {
                assemblyInfoProvider.Setup(x => x.GetExecutingAssemblyLocation()).Returns("Location");
                assemblyInfoProvider.Setup(x => x.GetProductVersion(It.IsAny<string>())).Returns("1.0.0-ci.525");
                assemblyInfoProvider.Setup(x => x.GetExecutingAssemblyVersion()).Returns(new Version(1, 0, 0, 0));

                var result = sut.GetVersion();

                Assert.IsNotNull(result);
                Assert.AreEqual("1.0.0-ci.525", result);
                assemblyInfoProvider.Verify(x => x.GetExecutingAssemblyLocation(), Times.Once);
                assemblyInfoProvider.Verify(x => x.GetProductVersion(It.IsAny<string>()), Times.Once);
                assemblyInfoProvider.Verify(x => x.GetExecutingAssemblyVersion(), Times.Never);
            }

            [TestMethod]
            public void AndExecutingAssemblyHasNoLocation_Then_ShouldReturnVersion()
            {
                assemblyInfoProvider.Setup(x => x.GetExecutingAssemblyLocation()).Returns(string.Empty);
                assemblyInfoProvider.Setup(x => x.GetProductVersion(It.IsAny<string>())).Returns("1.0.0-ci.525");
                assemblyInfoProvider.Setup(x => x.GetExecutingAssemblyVersion()).Returns(new Version(1, 0, 0, 0));

                var result = sut.GetVersion();

                Assert.IsNotNull(result);
                Assert.AreEqual("1.0.0.0", result);
                assemblyInfoProvider.Verify(x => x.GetExecutingAssemblyLocation(), Times.Once);
                assemblyInfoProvider.Verify(x => x.GetProductVersion(It.IsAny<string>()), Times.Never);
                assemblyInfoProvider.Verify(x => x.GetExecutingAssemblyVersion(), Times.Once);
            }
        }


    }
}
