using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using TEK.SeatPlan.BusinessLogic.Contract;
using TEK.SeatPlan.Entity;
using TEK.SeatPlan.Tests.Shared;
using TEK.SeatPlan.WebApi.Controllers;

namespace TEK.SeatPlan.WebApi.UnitTest.Controllers
{
    [TestClass]
    public class ProjectControllerUnitTest
    {
        private ProjectController sut;
        private Mock<IProjectComponent> projectComponent;

        [TestInitialize]
        public void Initialize()
        {
            projectComponent = new Mock<IProjectComponent>();
            sut = new ProjectController(projectComponent.Object);
        }

        [TestClass]
        public class WhenGet : ProjectControllerUnitTest
        {
            [TestMethod]
            public void AndBusinessReturnsNull_ShouldReturnNull()
            {
                projectComponent.Setup(ds => ds.GetProject(It.IsAny<int>())).Returns<Location>(null);

                var result = sut.Get(1);

                Assert.IsNull(result);
                projectComponent.Verify(ds => ds.GetProject(It.IsAny<int>()), Times.Once);
            }

            [TestMethod]
            public void AndBusinessReturnsEntity_ShouldReturnCorrespondingDto()
            {
                var mockEntity = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Dto.Project>();
                projectComponent.Setup(ds => ds.GetProject(It.IsAny<int>())).Returns(mockEntity);

                var result = sut.Get(1);

                Assert.IsNotNull(result);
                projectComponent.Verify(ds => ds.GetProject(It.IsAny<int>()), Times.Once);
                Assert.IsTrue(DtoGenericUtils.IsEqual(mockEntity, result));
            }
        }
    }
}
