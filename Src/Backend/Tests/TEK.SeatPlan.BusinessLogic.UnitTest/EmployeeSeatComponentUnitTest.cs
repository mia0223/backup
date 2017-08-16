using Moq;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TEK.SeatPlan.BusinessLogic.Contract;
using TEK.SeatPlan.Entity;
using TEK.SeatPlan.ResourceAccess.Contract;
using TEK.SeatPlan.Tests.Shared;

namespace TEK.SeatPlan.BusinessLogic.UnitTest
{
    [TestClass]
    public class EmployeeSeatComponentUnitTest
    { 
        private EmployeeSeatComponent _sut;
        private Mock<IRepository<Seat>> _mockRepository;
		private Mock<IRepository<Project>> _mockProjectRepository;
        private Mock<IMoveComponent> _moveComponent;

        private readonly List<Seat> _seatList = new List<Seat>();

        private const int SeatNumber1 = 10;
        private const int SeatNumber2 = 11;
        private const int SeatNumber3 = 12;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IRepository<Seat>>();
			_mockProjectRepository = new Mock<IRepository<Project>>();
            _moveComponent = new Mock<IMoveComponent>();

            _seatList.Add(CreateEntities.CreateNewSeatEntity(10, 10, 11, "test", SeatNumber1));
            _seatList.Add(CreateEntities.CreateNewSeatEntity(11, 11, 12, "test2", SeatNumber2));
            _seatList.Add(CreateEntities.CreateNewSeatEntity(null, 12, 13, "empty seat", SeatNumber3));
            _seatList.Add(CreateEntities.CreateNewTransitSeatEntity(100, 101, "transit seat", 999));

            _mockRepository.Setup(r => r.Get(It.IsAny<Expression<Func<Seat, bool>>>()))
                .Returns((Expression<Func<Seat, bool>> predicate) => _seatList.AsQueryable().First(predicate));

            _sut = new EmployeeSeatComponent(
				_mockRepository.Object,
				_mockProjectRepository.Object,
                _moveComponent.Object);
        }

        [TestClass]
        public class MoveTests : EmployeeSeatComponentUnitTest
        {
            // TODO: Refactoring required
            //[TestMethod]
            //public void When_Move_AndSourceSeatIsEmpty_Then_ShouldThrowErrorMessage()
            //{
            //    var seatPairNullSource = CreateDtos.CreateNewSeatPairDto(SeatNumber3, SeatNumber1);
            //    var e = CustomAssert.ExpectedExceptionRaised(() => { _sut.Move(seatPairNullSource); },
            //        typeof(ArgumentException));
            //    Assert.AreEqual($"No Employee found at source seat [{SeatNumber3}]", e.Message);
            //
            //}

            //[TestMethod]
            //public void When_Move_AndSeatPairAreInvalidWithTwoSameSeats_Then_ShouldThorwErrorMessage()
            //{
            //    var seatPairSame = CreateDtos.CreateNewSeatPairDto(5, 5);
            //    var e = CustomAssert.ExpectedExceptionRaised(() => { _sut.Move(seatPairSame); },
            //        typeof(ArgumentException));
            //    Assert.AreEqual($"Source and Target seat [5] should not be the same", e.Message);
            //}

            // TODO: Refactoring required
            //[TestMethod]
            //public void When_Move_AndSeatPairAreBothOccupied_Then_ShouldMoveTargetToInTransit()
            //{
            //    var seatPairMoveIndirectly = CreateDtos.CreateNewSeatPairDto(SeatNumber1, SeatNumber2);
            //    var seat1 = _seatList[0];
            //    var seat2 = _seatList[1];
            //
            //    _sut.Move(seatPairMoveIndirectly);
            //    _mockRepository.Verify(x => x.Update(seat1), Times.Once);
            //    _mockRepository.Verify(x => x.Update(seat2), Times.Once);
            //}

            // TODO: Refactoring required
            //[TestMethod]
            //public void When_Move_AndSeatPairAreNotBothOccupied_Then_MoveSourceToTarget()
            //{
            //    var seatPairMoveDirectly = CreateDtos.CreateNewSeatPairDto(SeatNumber1, SeatNumber3);
            //    var seat1 = _seatList[0];
            //
            //    _sut.Move(seatPairMoveDirectly);
            //    _mockRepository.Verify(x => x.Update(seat1), Times.Once);
            //}
        }

		[TestClass]
        public class CreateSeatTests : EmployeeSeatComponentUnitTest
        {
            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void When_CreateSeat_AndSeatIsNull_Then_ShouldThrowErrorMessage()
            {
                _sut.CreateSeat(null);
            }

            [TestMethod]
            public void When_CreateSeat_AndSeatNotNull_Then_ShouldReturnSeat()
            {
                Entity.Seat seat = CreateEntities.CreateNewSeatEntity();
                _mockRepository.Setup(x => x.Add(seat)).Returns(seat);
                var result = _sut.CreateSeat(seat);

                _mockRepository.Verify(x => x.Add(seat), Times.Once);
                _mockRepository.Verify(x => x.SaveChanges(), Times.Once);
                Assert.AreEqual(seat, result);
            }
        }
    }
}