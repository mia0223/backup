using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TEK.SeatPlan.BusinessLogic.Mappers;
using TEK.SeatPlan.Tests.Shared;

namespace TEK.SeatPlan.BusinessLogic.UnitTest
{
    [TestClass]
    public class LocationMapperUnitTest
    {
        private Entity.Location locationEntity;
        private Dto.Location locationDto;

        [TestInitialize]
        public void Initialize()
        {
            locationEntity = CreateEntities.CreateNewLocationEntity();
            locationDto = CreateDtos.CreateNewLocationDto();
        }

        [TestClass]
        public class ToDtoTests : LocationMapperUnitTest
        {
            [TestMethod]
            public void When_LocationMapper_ToDto_AndInputListOfEntities_Then_Mapper_Should_Return_ListOfDtos_OfSameSizeAsInput()
            {
                var listOfEntities = new List<Entity.Location>();
                listOfEntities.Add(CreateEntities.CreateNewLocationEntity());
                var mappedLocationDtoList = listOfEntities.ToDto();
                Assert.IsInstanceOfType(mappedLocationDtoList, typeof(ICollection<Dto.Location>));
                Assert.AreEqual(mappedLocationDtoList.Count, listOfEntities.Count);
            }

            [TestMethod]
            public void When_LocationMapper_ToDto_AndInputListOfEntities_Then_Mapper_Should_Return_CorrectListOfDtos_InProperSequence()
            {
                var listOfEntities = new List<Entity.Location>();
                listOfEntities.Add(CreateEntities.CreateNewLocationEntity(rows:25));
                listOfEntities.Add(CreateEntities.CreateNewLocationEntity(rows:50));
                var mappedLocationDtoList = listOfEntities.ToDto();
                Assert.AreEqual(mappedLocationDtoList.ElementAt(0).Rows, listOfEntities.ElementAt(0).Rows);
                Assert.AreEqual(mappedLocationDtoList.ElementAt(1).Rows, listOfEntities.ElementAt(1).Rows);
            }

            [TestMethod]
            public void When_LocationMapper_ToDto_And_InputNullEntity_Then_Mapper_Should_Return_Null()
            {
                Entity.Location nullEntity = null;
                var mappedLocationDto = nullEntity.ToDto();
                Assert.IsNull(mappedLocationDto);
            }

            [TestMethod]
            public void When_LocationMapper_ToDto_Then_Mapper_Should_ReturnDtoWithCorrectProperties()
            {
                var mappedLocationDto = locationEntity.ToDto();
                Assert.IsInstanceOfType(mappedLocationDto, typeof(Dto.Location));
                Assert.AreEqual(mappedLocationDto.Active, locationEntity.Active);
                Assert.AreEqual(mappedLocationDto.Cols, locationEntity.Cols);
                Assert.AreEqual(mappedLocationDto.Rows, locationEntity.Rows);
                Assert.AreEqual(mappedLocationDto.FloorLevel, locationEntity.FloorLevel);
                Assert.AreEqual(mappedLocationDto.Id, locationEntity.Id);
                Assert.AreEqual(mappedLocationDto.Name, locationEntity.Name);
            }
        }

        [TestClass]
        public class ToEntityTests : LocationMapperUnitTest
        {
            [TestMethod]
            public void When_LocationMapper_ToEntity_And_InputNullDto_Then_Mapper_Should_Return_Null()
            {
                Dto.Location nullDto = null;
                var mappedLocationDto = nullDto.ToEntity(null);
                Assert.IsNull(mappedLocationDto);
            }

            [TestMethod]
            public void When_LocationMapper_ToEntity_WithNullEntityAsInput_Then_Mapper_Should_ReturnDtoWithCorrectProperties()
            {
                var mappedLocationEntity = locationDto.ToEntity(null);
                Assert.IsInstanceOfType(mappedLocationEntity, typeof(Entity.Location));
                Assert.AreEqual(mappedLocationEntity.Active, locationDto.Active);
                Assert.AreEqual(mappedLocationEntity.Cols, locationDto.Cols);
                Assert.AreEqual(mappedLocationEntity.Rows, locationDto.Rows);
                Assert.AreEqual(mappedLocationEntity.FloorLevel, locationDto.FloorLevel);
                Assert.AreEqual(mappedLocationEntity.Id, locationDto.Id);
                Assert.AreEqual(mappedLocationEntity.Name, locationDto.Name);
            }

            [TestMethod]
            public void When_LocationMapper_ToEntity_WithExistingEntityAsInput_Then_Mapper_Should_ReturnDtoWithCorrectProperties()
            {
                var existingLocationEntity = CreateEntities.CreateNewLocationEntity();
                var mappedLocationEntity = locationDto.ToEntity(existingLocationEntity);
                Assert.IsInstanceOfType(mappedLocationEntity, typeof(Entity.Location));
                Assert.AreEqual(mappedLocationEntity.Active, locationDto.Active);
                Assert.AreEqual(mappedLocationEntity.Cols, locationDto.Cols);
                Assert.AreEqual(mappedLocationEntity.Rows, locationDto.Rows);
                Assert.AreEqual(mappedLocationEntity.FloorLevel, locationDto.FloorLevel);
                Assert.AreEqual(mappedLocationEntity.Id, locationDto.Id);
                Assert.AreEqual(mappedLocationEntity.Name, locationDto.Name);
            }
        }
    }
}
