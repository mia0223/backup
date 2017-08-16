using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TEK.SeatPlan.BusinessLogic.Mappers;
using TEK.SeatPlan.Tests.Shared;

namespace TEK.SeatPlan.BusinessLogic.UnitTest
{
    [TestClass]
    public class SeatMapperUnitTest
    {
        private Entity.Seat seatEntity;
        private Dto.Seat seatDto;

        [TestInitialize]
        public void Initialize()
        {
            seatEntity = CreateEntities.CreateNewSeatEntity();
            seatDto = CreateDtos.CreateNewSeatDto();
        }

        [TestClass]
        public class ToDtoTests : SeatMapperUnitTest
        {
            [TestMethod]
            public void When_SeatMapper_ToDto_AndInputListOfEntities_Then_Mapper_Should_Return_ListOfDtos_OfSameSizeAsInput()
            {
                var listOfEntities = new List<Entity.Seat>();
                listOfEntities.Add(CreateEntities.CreateNewSeatEntity());
                var mappedSeatDtoList = listOfEntities.ToDto();
                Assert.IsInstanceOfType(mappedSeatDtoList, typeof(ICollection<Dto.Seat>));
                Assert.AreEqual(mappedSeatDtoList.Count, listOfEntities.Count);
            }

            [TestMethod]
            public void When_SeatMapper_ToDto_AndInputListOfEntities_Then_Mapper_Should_Return_CorrectListOfDtos_InProperSequence()
            {
                var listOfEntities = new List<Entity.Seat>();
                listOfEntities.Add(CreateEntities.CreateNewSeatEntity(row: 1));
                listOfEntities.Add(CreateEntities.CreateNewSeatEntity(row: 2));
                var mappedSeatDtoList = listOfEntities.ToDto();
                Assert.AreEqual(mappedSeatDtoList.ElementAt(0).Row, listOfEntities.ElementAt(0).Row);
                Assert.AreEqual(mappedSeatDtoList.ElementAt(1).Row, listOfEntities.ElementAt(1).Row);
            }

            [TestMethod]
            public void When_SeatMapper_ToDto_And_InputNullEntity_Then_Mapper_Should_Return_Null()
            {
                Entity.Seat nullEntity = null;
                var mappedSeatDto = nullEntity.ToDto();
                Assert.IsNull(mappedSeatDto);
            }

            [TestMethod]
            public void When_SeatMapper_ToDto_Then_Mapper_Should_ReturnDtoWithCorrectProperties()
            {
                var mappedSeatDto = seatEntity.ToDto();
                Assert.IsInstanceOfType(mappedSeatDto, typeof(Dto.Seat));
                Assert.AreEqual(mappedSeatDto.Description, seatEntity.Description);
                Assert.AreEqual(mappedSeatDto.Col, seatEntity.Col);
                Assert.AreEqual(mappedSeatDto.Number, seatEntity.Number);
                Assert.AreEqual(mappedSeatDto.Row, seatEntity.Row);
            }
        }

        [TestClass]
        public class ToEntityTests : SeatMapperUnitTest
        {
            [TestMethod]
            public void When_SeatMapper_ToEntity_And_InputNullDto_Then_Mapper_Should_Return_Null()
            {
                Dto.Seat nullDto = null;
                var mappedSeatDto = nullDto.ToEntity(null);
                Assert.IsNull(mappedSeatDto);
            }

            [TestMethod]
            public void When_SeatMapper_ToEntity_WithNullEntityAsInput_Then_Mapper_Should_ReturnDtoWithCorrectProperties()
            {
                var mappedSeatEntity = seatDto.ToEntity(null);
                Assert.IsInstanceOfType(mappedSeatEntity, typeof(Entity.Seat));
                Assert.AreEqual(mappedSeatEntity.Description, seatDto.Description);
                Assert.AreEqual(mappedSeatEntity.Col, seatDto.Col);
                Assert.AreEqual(mappedSeatEntity.Number, seatDto.Number);
                Assert.AreEqual(mappedSeatEntity.Row, seatDto.Row);
            }

            [TestMethod]
            public void When_SeatMapper_ToEntity_WithExistingEntityAsInput_Then_Mapper_Should_ReturnDtoWithCorrectProperties()
            {
                var existingSeatEntity = CreateEntities.CreateNewSeatEntity();
                var mappedSeatEntity = seatDto.ToEntity(existingSeatEntity);
                Assert.IsInstanceOfType(mappedSeatEntity, typeof(Entity.Seat));
                Assert.AreEqual(mappedSeatEntity.Description, seatDto.Description);
                Assert.AreEqual(mappedSeatEntity.Col, seatDto.Col);
                Assert.AreEqual(mappedSeatEntity.Number, seatDto.Number);
                Assert.AreEqual(mappedSeatEntity.Row, seatDto.Row);
            }
        }
    }
}