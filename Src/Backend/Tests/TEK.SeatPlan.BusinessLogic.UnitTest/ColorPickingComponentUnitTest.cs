using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TEK.SeatPlan.BusinessLogic.Contract;
using TEK.SeatPlan.Entity;
using TEK.SeatPlan.ResourceAccess.Contract;

namespace TEK.SeatPlan.BusinessLogic.UnitTest
{

    [TestClass]
    public class ColorPickingComponentUnitTest
    {
        private ColorPickingComponent sut;
        private Mock<IRepository<Entity.Project>> projectRepository;
        private Mock<IProjectColorPairComponent> projectColorPairComponent;
        private Mock<IRandomizer> randomizer;

        [TestInitialize]
        public void Initialize()
        {
            projectRepository = new Mock<IRepository<Project>>();
            projectColorPairComponent = new Mock<IProjectColorPairComponent>();
            randomizer = new Mock<IRandomizer>();

            projectColorPairComponent.Setup(pcpc => pcpc.Get()).Returns(new List<ProjectColorPair>()
            {
                new ProjectColorPair() {ForegroundColor = "#B57A26", BackgroundColor = "#FFDDAB"},
                new ProjectColorPair() {ForegroundColor = "#41713D", BackgroundColor = "#BDE6B8"},
                new ProjectColorPair() {ForegroundColor = "#276E7B", BackgroundColor = "#B8DFE6"}
            });

            sut = new ColorPickingComponent(
                projectRepository.Object,
                projectColorPairComponent.Object,
                randomizer.Object);
        }

        [TestClass]
        public class GetNextAvailableColorForProjectTests : ColorPickingComponentUnitTest
        {
            [TestMethod]
            public void When_GetNextAvailableColorForProject_AndColorPairAreNotUse_Then_RandomlyPickOneAvailable()
            {
                IEnumerable<Project> returnEntities = new List<Project>()
                {
                    new Project(){Active = true, ForegroundColor = "#B57A26", BackgroundColor = "#FFDDAB"},
                    new Project(){Active = false, ForegroundColor = "#41713D", BackgroundColor = "#BDE6B8"},
                    new Project(){Active = false, ForegroundColor = "#276E7B", BackgroundColor = "#B8DFE6"},
                };

                projectRepository.Setup(pr => pr.Find(It.IsAny<Expression<Func<Project, bool>>>(), It.IsAny<Func<IQueryable<Project>, IOrderedQueryable<Project>>>()))
                    .Returns(returnEntities);
                randomizer.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>()))
                    .Returns(1);

                var result = sut.GetNextAvailableColorForProject();

                Assert.AreEqual("#276E7B", result.ForegroundColor);
                Assert.AreEqual("#B8DFE6", result.BackgroundColor);
                randomizer.Verify(r => r.Next(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
                projectRepository.Verify(pr => pr.Find(It.IsAny<Expression<Func<Project, bool>>>(), It.IsAny<Func<IQueryable<Project>, IOrderedQueryable<Project>>>()), Times.Once);
            }

            [TestMethod]
            public void When_GetNextAvailableColorForProject_AndColorPairAreAllUse_Then_RandomlyPickInColorLibrary()
            {
                IEnumerable<Project> returnEntities = new List<Project>()
                {
                    new Project(){Active = true, ForegroundColor = "#B57A26", BackgroundColor = "#FFDDAB"},
                    new Project(){Active = true, ForegroundColor = "#41713D", BackgroundColor = "#BDE6B8"},
                    new Project(){Active = true, ForegroundColor = "#276E7B", BackgroundColor = "#B8DFE6"},
                };

                projectRepository.Setup(pr => pr.Find(It.IsAny<Expression<Func<Project, bool>>>(), It.IsAny<Func<IQueryable<Project>, IOrderedQueryable<Project>>>()))
                    .Returns(returnEntities);
                randomizer.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>()))
                    .Returns(0);

                var result = sut.GetNextAvailableColorForProject();

                Assert.AreEqual("#B57A26", result.ForegroundColor);
                Assert.AreEqual("#FFDDAB", result.BackgroundColor);
                randomizer.Verify(r => r.Next(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
                projectRepository.Verify(pr => pr.Find(It.IsAny<Expression<Func<Project, bool>>>(), It.IsAny<Func<IQueryable<Project>, IOrderedQueryable<Project>>>()), Times.Once);
            }
        }
    }
}
