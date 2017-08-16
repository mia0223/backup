using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TEK.SeatPlan.BusinessLogic.Contract;
using TEK.SeatPlan.BusinessLogic.DataComponents;
using TEK.SeatPlan.Dto;
using TEK.SeatPlan.Entity;
using TEK.SeatPlan.ResourceAccess.Contract;
using Employee = TEK.SeatPlan.Entity.Employee;
using Project = TEK.SeatPlan.Entity.Project;

namespace TEK.SeatPlan.BusinessLogic.UnitTest
{
    [TestClass]
    public class ProjectComponentUnitTest
    {
        private ProjectComponent sut;
        private Mock<IRepository<Entity.Project>> projectRepository;
        private Mock<IRepository<Entity.Employee>> employeeRepository;
        private Mock<IColorPickingComponent> colorPickingComponent;

        [TestInitialize]
        public void TestInitialize()
        {
            projectRepository = new Mock<IRepository<Project>>();
            employeeRepository = new Mock<IRepository<Employee>>();
            colorPickingComponent = new Mock<IColorPickingComponent>();

            sut = new ProjectComponent(projectRepository.Object, employeeRepository.Object, colorPickingComponent.Object);
        }

        [TestClass]
        public class CreateProject : ProjectComponentUnitTest
        {
            [TestMethod]
            public void When_CreateProject_Then_PickNextAvailableColorForProject()
            {
                //Arange
                var projectDto = new Dto.Project();
                var colorPair = new ProjectColorPair() { ForegroundColor = "#B57A26", BackgroundColor = "#FFDDAB" };
                projectRepository.Setup(r => r.Add(It.IsAny<Entity.Project>()))
                    .Returns(new Entity.Project());
                projectRepository.Setup(r => r.SaveChanges())
                    .Returns(1);
                colorPickingComponent.Setup(cp => cp.GetNextAvailableColorForProject())
                    .Returns(colorPair);

                //Act
                var result = sut.CreateProject(projectDto);

                //Assert
                projectRepository.Verify(r => r.Add(It.IsAny<Entity.Project>()), Times.Once);
                projectRepository.Verify(r => r.SaveChanges(), Times.Once);
                colorPickingComponent.Verify(cp => cp.GetNextAvailableColorForProject(), Times.Once);
            }
        }
    }
}
