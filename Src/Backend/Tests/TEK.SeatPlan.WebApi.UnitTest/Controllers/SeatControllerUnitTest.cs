using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using TEK.SeatPlan.BusinessLogic.Contract;
using TEK.SeatPlan.Dto;
using TEK.SeatPlan.Tests.Shared;
using TEK.SeatPlan.WebApi.Controllers;
using Seat = TEK.SeatPlan.Entity.Seat;

namespace TEK.SeatPlan.WebApi.UnitTest.Controllers
{
    [TestClass]
    public class SeatControllerUnitTest
    {
        private SeatController sut;
        private Mock<IEmployeeSeatComponent> employeeSeatComponent;
        private Mock<IMoveComponent> _moveComponent;

        [TestInitialize]
        public void Initialize()
        {
            employeeSeatComponent = new Mock<IEmployeeSeatComponent>();
            _moveComponent = new Mock<IMoveComponent>();

            sut = new SeatController(employeeSeatComponent.Object, _moveComponent.Object);
        }

        [TestClass]
        public class WhenGet : SeatControllerUnitTest
        {
            [TestMethod]
            public void AndBusinessReturnsNull_ShouldReturnNull()
            {
                employeeSeatComponent.Setup(ds => ds.GetSeatByNumber(It.IsAny<int>())).Returns<Seat>(null);

                var result = sut.Get(1);

                Assert.IsNull(result);
                employeeSeatComponent.Verify(ds => ds.GetSeatByNumber(It.IsAny<int>()), Times.Once);
            }

            [TestMethod]
            public void AndBusinessReturnsEntity_ShouldReturnCorrespondingDto()
            {
                var seat = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Seat>();
                var mockEntity = new[] { seat };
                employeeSeatComponent.Setup(ds => ds.GetSeatByNumber(It.IsAny<int>())).Returns(seat);

                var result = sut.Get(1);

                Assert.IsNotNull(result);
                employeeSeatComponent.Verify(ds => ds.GetSeatByNumber(It.IsAny<int>()), Times.Once);
                Assert.IsTrue(DtoGenericUtils.IsEqual(mockEntity, result));
            }
        }

        [TestClass]
        public class WhenPush : SeatControllerUnitTest
        {
            [TestMethod]
            public void ShouldCallMove()
            {
                _moveComponent.Setup(ds => ds.Move(It.IsAny<Dto.SeatPair>()));
                var seatPair = DtoGenericUtils.CreateNewInstanceWithDefaultValues<SeatPair>();

                sut.Post(seatPair);

                _moveComponent.Verify(ds => ds.Move(It.IsAny<Dto.SeatPair>()), Times.Once);
            }
        }

        [TestClass]
        public class WhenPut : SeatControllerUnitTest
        {
            [TestMethod]
            public void ShouldCallCreateSeat()
            {
                var seatDto = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Dto.Seat>();
                employeeSeatComponent.Setup(ds => ds.CreateSeat(It.IsAny<Entity.Seat>()));

                sut.Put(seatDto);

                employeeSeatComponent.Verify(ds => ds.CreateSeat(It.IsAny<Entity.Seat>()), Times.Once);
            }
        }
    }
}
