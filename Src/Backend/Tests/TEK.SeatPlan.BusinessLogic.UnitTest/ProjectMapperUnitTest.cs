using System.Linq;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TEK.SeatPlan.BusinessLogic.Mappers;
using TEK.SeatPlan.Tests.Shared;

namespace TEK.SeatPlan.BusinessLogic.UnitTest
{
    [TestClass]
    public class ProjectMapperUnitTest
    {
        private Entity.Project projectEntity;
        private Dto.Project projectDto;

        [TestInitialize]
        public void Initialize()
        {
            projectEntity = CreateEntities.CreateNewProjectEntity();
            projectDto = CreateDtos.CreateNewProjectDto();
        }
        
        [TestClass]
        public class ToDtoTests : ProjectMapperUnitTest
        {
            [TestMethod]
            public void When_ProjectMapper_ToDto_AndInputListOfEntities_Then_Mapper_Should_Return_ListOfDtos_OfSameSizeAsInput()
            {
                var listOfEntities = new List<Entity.Project>();
                for (var i = 0; i < 5; i++)
                listOfEntities.Add(CreateEntities.CreateNewProjectEntity());
                var mappedProjectDtoList = listOfEntities.ToDto();
                Assert.IsInstanceOfType(mappedProjectDtoList, typeof(ICollection<Dto.Project>));
                Assert.AreEqual(mappedProjectDtoList.Count, listOfEntities.Count);
            }

            [TestMethod]
            public void When_ProjectMapper_ToDto_AndInputListOfEntities_Then_Mapper_Should_Return_CorrectListOfDtos_InProperSequence()
            {
                var listOfEntities = new List<Entity.Project>();
                listOfEntities.Add(CreateEntities.CreateNewProjectEntity(name:"first project"));
                listOfEntities.Add(CreateEntities.CreateNewProjectEntity(name: "second project"));
                var mappedProjectDtoList = listOfEntities.ToDto();
                Assert.AreEqual(mappedProjectDtoList.ElementAt(0).Name, listOfEntities.ElementAt(0).Name);
                Assert.AreEqual(mappedProjectDtoList.ElementAt(1).Name, listOfEntities.ElementAt(1).Name);
            }

            [TestMethod]
            public void When_ProjectMapper_ToDto_And_InputNullEntity_Then_Mapper_Should_Return_Null()
            {
                Entity.Project nullEntity = null;
                var mappedProjectDto = nullEntity.ToDto();
                Assert.IsNull(mappedProjectDto);
            }

            [TestMethod]
            public void When_ProjectMapper_ToDto_Then_Mapper_Should_ReturnDtoWithCorrectProperties()
            {
                var mappedProjectDto = projectEntity.ToDto();
                Assert.IsInstanceOfType(mappedProjectDto, typeof(Dto.Project));
                Assert.AreEqual(mappedProjectDto.Active, projectEntity.Active);
                Assert.AreEqual(mappedProjectDto.Description, projectEntity.Description);
                Assert.AreEqual(mappedProjectDto.BackgroundColor, projectEntity.BackgroundColor);
                Assert.AreEqual(mappedProjectDto.Internal, projectEntity.Internal);
                Assert.AreEqual(mappedProjectDto.Id, projectEntity.Id);
                Assert.AreEqual(mappedProjectDto.Name, projectEntity.Name);
            }

        }

        [TestClass]
        public class ToEntityTests : ProjectMapperUnitTest
        {
            [TestMethod]
            public void When_ProjectMapper_ToEntity_And_InputNullDto_Then_Mapper_Should_Return_Null()
            {
                Dto.Project nullDto = null;
                var mappedProjectDto = nullDto.ToEntity(null);
                Assert.IsNull(mappedProjectDto);
            }

            [TestMethod]
            public void When_ProjectMapper_ToEntity_WithNullEntityAsInput_Then_Mapper_Should_ReturnDtoWithCorrectProperties()
            {
                var mappedProjectEntity = projectDto.ToEntity(null);
                Assert.IsInstanceOfType(mappedProjectEntity, typeof(Entity.Project));
                Assert.AreEqual(mappedProjectEntity.Active, projectDto.Active);
                Assert.AreEqual(mappedProjectEntity.Description, projectDto.Description);
                Assert.AreEqual(mappedProjectEntity.BackgroundColor, projectDto.BackgroundColor);
                Assert.AreEqual(mappedProjectEntity.Internal, projectDto.Internal);
                Assert.AreEqual(mappedProjectEntity.Id, projectDto.Id);
                Assert.AreEqual(mappedProjectEntity.Name, projectDto.Name);
            }

            [TestMethod]
            public void When_ProjectMapper_ToEntity_WithExistingEntityAsInput_Then_Mapper_Should_ReturnDtoWithCorrectProperties()
            {
                var existingProjectEntity = CreateEntities.CreateNewProjectEntity();
                var mappedProjectEntity = projectDto.ToEntity(existingProjectEntity);
                Assert.IsInstanceOfType(mappedProjectEntity, typeof(Entity.Project));
                Assert.AreEqual(mappedProjectEntity.Active, projectDto.Active);
                Assert.AreEqual(mappedProjectEntity.Description, projectDto.Description);
                Assert.AreEqual(mappedProjectEntity.BackgroundColor, projectDto.BackgroundColor);
                Assert.AreEqual(mappedProjectEntity.Internal, projectDto.Internal);
                Assert.AreEqual(mappedProjectEntity.Id, projectDto.Id);
                Assert.AreEqual(mappedProjectEntity.Name, projectDto.Name);
            }
        }
    }
}