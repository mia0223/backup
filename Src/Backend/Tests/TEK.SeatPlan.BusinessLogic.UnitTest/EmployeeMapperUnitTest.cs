using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TEK.SeatPlan.BusinessLogic.Mappers;
using TEK.SeatPlan.Tests.Shared;

namespace TEK.SeatPlan.BusinessLogic.UnitTest
{
    [TestClass]
    public class EmployeeMapperUnitTest
    {
        private Entity.Employee employeeEntity;
        private Dto.Employee employeeDto;

        [TestInitialize]
        public void Initialize()
        {
            employeeEntity = CreateEntities.CreateNewEmployeeEntity();
            employeeDto = CreateDtos.CreateNewEmployeeDto();
        }

        [TestClass]
        public class ToDtoTests : EmployeeMapperUnitTest
        {
            [TestMethod]
            public void When_EmployeeMapper_ToDto_AndInputListOfEntities_Then_Mapper_Should_Return_ListOfDtos_OfSameSizeAsInput()
            {
                var listOfEntities = new List<Entity.Employee>();
                listOfEntities.Add(CreateEntities.CreateNewEmployeeEntity());
                var mappedEmployeeDtoList = listOfEntities.ToDto();
                Assert.IsInstanceOfType(mappedEmployeeDtoList, typeof(ICollection<Dto.Employee>));
                Assert.AreEqual(mappedEmployeeDtoList.Count, listOfEntities.Count);
            }

            [TestMethod]
            public void When_EmployeeMapper_ToDto_AndInputListOfEntities_Then_Mapper_Should_Return_CorrectListOfDtos_InProperSequence()
            {
                var listOfEntities = new List<Entity.Employee>();
                listOfEntities.Add(CreateEntities.CreateNewEmployeeEntity(firstName: "first"));
                listOfEntities.Add(CreateEntities.CreateNewEmployeeEntity(firstName: "second"));
                var mappedEmployeeDtoList = listOfEntities.ToDto();
                Assert.AreEqual(mappedEmployeeDtoList.ElementAt(0).FirstName, listOfEntities.ElementAt(0).FirstName);
                Assert.AreEqual(mappedEmployeeDtoList.ElementAt(1).FirstName, listOfEntities.ElementAt(1).FirstName);
            }

            [TestMethod]
            public void When_EmployeeMapper_ToDto_And_InputNullEntity_Then_Mapper_Should_Return_Null()
            {
                Entity.Employee nullEntity = null;
                var mappedEmployeeDto = nullEntity.ToDto();
                Assert.IsNull(mappedEmployeeDto);
            }

            [TestMethod]
            public void When_EmployeeMapper_ToDto_Then_Mapper_Should_ReturnDtoWithCorrectProperties()
            {
                var mappedEmployeeDto = employeeEntity.ToDto();
                Assert.IsInstanceOfType(mappedEmployeeDto, typeof(Dto.Employee));
                Assert.AreEqual(mappedEmployeeDto.Description, employeeEntity.Description);
                Assert.AreEqual(mappedEmployeeDto.Email, employeeEntity.Email);
                Assert.AreEqual(mappedEmployeeDto.FirstName, employeeEntity.FirstName);
                Assert.AreEqual(mappedEmployeeDto.LastName, employeeEntity.LastName);
                Assert.AreEqual(mappedEmployeeDto.Id, employeeEntity.Id);
            }
        }

        [TestClass]
        public class ToEntityTests : EmployeeMapperUnitTest
        {
            [TestMethod]
            public void When_EmployeeMapper_ToEntity_And_InputNullDto_Then_Mapper_Should_Return_Null()
            {
                Dto.Employee nullDto = null;
                var mappedEmployeeDto = nullDto.ToEntity(null);
                Assert.IsNull(mappedEmployeeDto);
            }

            [TestMethod]
            public void When_EmployeeMapper_ToEntity_WithNullEntityAsInput_Then_Mapper_Should_ReturnDtoWithCorrectProperties()
            {
                var mappedEmployeeEntity = employeeDto.ToEntity(null);

                Assert.IsInstanceOfType(mappedEmployeeEntity, typeof(Entity.Employee));
                Assert.AreEqual(mappedEmployeeEntity.Description, employeeDto.Description);
                Assert.AreEqual(mappedEmployeeEntity.Email, employeeDto.Email);
                Assert.AreEqual(mappedEmployeeEntity.FirstName, employeeDto.FirstName);
                Assert.AreEqual(mappedEmployeeEntity.LastName, employeeDto.LastName);
            }

            [TestMethod]
            public void When_EmployeeMapper_ToEntity_WithExistingEntityAsInput_Then_Mapper_Should_ReturnDtoWithCorrectProperties()
            {
                var existingEmployeeEntity = CreateEntities.CreateNewEmployeeEntity();
                var mappedEmployeeEntity = employeeDto.ToEntity(existingEmployeeEntity);

                Assert.IsInstanceOfType(mappedEmployeeEntity, typeof(Entity.Employee));
                Assert.AreEqual(mappedEmployeeEntity.Description, employeeDto.Description);
                Assert.AreEqual(mappedEmployeeEntity.Email, employeeDto.Email);
                Assert.AreEqual(mappedEmployeeEntity.FirstName, employeeDto.FirstName);
                Assert.AreEqual(mappedEmployeeEntity.LastName, employeeDto.LastName);
                Assert.AreEqual(mappedEmployeeEntity.Id, employeeDto.Id);
            }
        }
    }
}
