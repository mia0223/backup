using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using TEK.SeatPlan.Entity;
using TEK.SeatPlan.BusinessLogic.Contract;
using TEK.SeatPlan.ResourceAccess.Contract;
using TEK.SeatPlan.Tests.Shared;

namespace TEK.SeatPlan.BusinessLogic.UnitTest
{
    [TestClass]
    public class DataServiceUnitTest
    {
        private Mock<IRepository<Seat>> mockRepository;
        private Mock<IAccessLogger> mockLogger;
        private DataService<Seat> dataService;
        private Seat seatEntity = default (Seat);
        private int changesCount;

        [TestInitialize]
        public void Initialize()
        {
            changesCount = 0;
            mockRepository = new Mock<IRepository<Seat>>();
            mockLogger = new Mock<IAccessLogger>();
            dataService = new DataService<Seat>(mockRepository.Object, mockLogger.Object);
            mockRepository.Setup(a => a.SaveChanges()).Returns(changesCount = 1);
            seatEntity = CreateEntities.CreateNewSeatEntity();
        }

        [TestClass]
        public class AddTests : DataServiceUnitTest
        {
            [TestMethod]
            public void When_Add_Then_DataService_Should_ReturnEntity()
            {
                var loggerAction = "created";
                mockRepository.Setup(r => r.Add(seatEntity)).Returns(seatEntity);
                var result = dataService.Add(seatEntity);
                mockRepository.Verify(a => a.Add(seatEntity), Times.Once);
                mockRepository.Verify(r => r.SaveChanges(), Times.Once);
                mockLogger.Verify(a => a.LogOperationResult(changesCount, seatEntity, loggerAction), Times.Once);
                Assert.AreEqual(changesCount, 1);
                Assert.IsInstanceOfType(result, typeof(Seat));
            }

            [TestMethod]
            public void When_Add_AndErrorInRepo_Then_DataService_Should_ThrowException()
            {
                var badEntity = CreateEntities.CreateNewSeatEntity();
                mockRepository.Setup(r => r.Add(badEntity))
                    .Throws(new InvalidCastException());
                var expected = CustomAssert.ExpectedExceptionRaised(() =>
                    {
                        dataService.Add(badEntity);
                    },
                    typeof(InvalidOperationException));
                Assert.IsNotNull(expected.InnerException);
                Assert.IsInstanceOfType(expected.InnerException, typeof(InvalidCastException));
            }


        }

        [TestClass]
        public class AttachTests : DataServiceUnitTest
        {
            [TestMethod]
            public void When_Attach_Then_Repository_Attach_Should_Be_Called()
            {
                mockRepository.Setup(a => a.Attach(seatEntity)).Returns(seatEntity);
                var result = dataService.Attach(seatEntity);
                Assert.IsInstanceOfType(result, typeof(Seat));
                mockRepository.Verify(a => a.Attach(seatEntity), Times.Once);
            }
        }

        [TestClass]
        public class UpdateTests : DataServiceUnitTest
        {
            [TestMethod]
            public void When_Update_Then_DataService_Should_ReturnEntity()
            {
                var loggerAction = "updated";
                mockRepository.Setup(r => r.Update(seatEntity)).Returns(seatEntity);
                var result = dataService.Update(seatEntity);
                mockRepository.Verify(r => r.Update(seatEntity), Times.Once);
                mockRepository.Verify(r => r.SaveChanges(), Times.Once);
                mockLogger.Verify(l => l.LogOperationResult(changesCount, seatEntity, loggerAction), Times.Once);
                Assert.AreEqual(changesCount, 1);
                Assert.AreEqual(result, seatEntity);
            }

            [TestMethod]
            public void When_Update_AndErrorInRepo_Then_DataService_Should_ThrowException()
            {
                var badEntity = CreateEntities.CreateNewSeatEntity();
                mockRepository.Setup(r => r.Update(badEntity))
                    .Throws(new InvalidCastException());
                var expected = CustomAssert.ExpectedExceptionRaised(() =>
                    {
                        dataService.Update(badEntity);
                    },
                    typeof(InvalidOperationException));
                Assert.IsNotNull(expected.InnerException);
                Assert.IsInstanceOfType(expected.InnerException, typeof(InvalidCastException));
            }
        }

        [TestClass]
        public class GetTests : DataServiceUnitTest
        {
            //[TestMethod]
            //public void When_Get_WithKeyValue_Then_DataService_Should_ReturnEntity()
            //{
            //    var keyValue = new object[1];
            //    var returnEntity = CreateEntities.CreateNewSeatEntity();
            //    mockRepository.Setup(r => r.Get(keyValue)).Returns(returnEntity);
            //    var result = dataService.Get(keyValue);
            //    Assert.IsInstanceOfType(result, typeof(Seat));
            //    mockLogger.Verify(l => l.LogOperationResult(1, returnEntity, "get"), Times.Once);
            //    mockRepository.Verify(r => r.Get(keyValue), Times.Once);
            //}

            //[TestMethod]
            //public void When_Get_WithPredicateAndNoInclude_Then_DataService_Should_ReturnEntity()
            //{
            //    Expression<Func<Seat, bool>> predicate = num => true;
            //    var returnEntity = CreateEntities.CreateNewSeatEntity();
            //    mockRepository.Setup(r => r.Get(predicate, null)).Returns(returnEntity);
            //    var result = dataService.Get(predicate);
            //    Assert.IsInstanceOfType(result, typeof(Seat));
            //    mockLogger.Verify(l => l.LogOperationResult(1, returnEntity, "get"), Times.Once);
            //    mockRepository.Verify(r => r.Get(predicate, null), Times.Once);

            //}

            //[TestMethod]
            //public void When_Get_WithPredicateAndInclude_Then_DataService_Should_ReturnEntity()
            //{
            //    Expression<Func<Seat, bool>> predicate = num => true;
            //    Expression<Func<Seat, bool>> include = num => true;
            //    var returnEntity = CreateEntities.CreateNewSeatEntity();
            //    mockRepository.Setup(r => r.Get(predicate, include)).Returns(returnEntity);
            //    var result = dataService.Get(predicate, include);
            //    Assert.IsInstanceOfType(result, typeof(Seat));
            //    mockLogger.Verify(l => l.LogOperationResult(1, returnEntity, "get"), Times.Once);
            //    mockRepository.Verify(r => r.Get(predicate, include), Times.Once);
            //}
        }

        [TestClass]
        public class FindTests : DataServiceUnitTest
        {
            //[TestMethod]
            //public void When_Find_WithNoInclude_Then_DataService_Should_Return_ListOfEntities()
            //{
            //    Expression<Func<Seat, bool>> predicate = num => true;
            //    IEnumerable<Seat> returnEntity = new List<Seat>();
            //    Func<IQueryable<Seat>, IOrderedQueryable<Seat>> orderBy = l => null;
            //    mockRepository.Setup(r => r.Find(predicate, orderBy)).Returns(returnEntity);
            //    var result = dataService.Find(predicate, orderBy);
            //    mockLogger.Verify(l => l.LogOperationResult(returnEntity.Count(), returnEntity, "get"), Times.Once);
            //    mockRepository.Verify(r => r.Find(predicate, orderBy, null), Times.Once);
            //    Assert.IsInstanceOfType(result, typeof(IEnumerable<Seat>));

            //}

            //[TestMethod]
            //public void When_Find_WithInclude_Then_DataService_Should_Return_ListOfEntities()
            //{
            //    Expression<Func<Seat, bool>> predicate = num => true;
            //    var include = new Expression<Func<Seat, object>>[1];
            //    include[0] = num => true;
            //    IEnumerable<Seat> returnEntity = new List<Seat>();
            //    Func<IQueryable<Seat>, IOrderedQueryable<Seat>> orderBy = l => null;
            //    mockRepository.Setup(r => r.Find(predicate, orderBy, include)).Returns(returnEntity);
            //    var result = dataService.Find(predicate, orderBy, include);
            //    mockLogger.Verify(l => l.LogOperationResult(returnEntity.Count(), returnEntity, "get"), Times.Once);
            //    mockRepository.Verify(r => r.Find(predicate, orderBy, include), Times.Once);
            //    Assert.IsInstanceOfType(result, typeof(IEnumerable<Seat>));
            //}
        }

        [TestClass]
        public class DeleteTests : DataServiceUnitTest
        {
            [TestMethod]
            public void When_Delete_Then_DataService_Should_ReturnDeletedEntity()
            {
                var loggerAction = "deleted";
                mockRepository.Setup(r => r.Delete(seatEntity)).Returns(seatEntity);
                var result = dataService.Delete(seatEntity);
                mockLogger.Verify(l => l.LogOperationResult(changesCount, seatEntity, loggerAction), Times.Once);
                mockRepository.Verify(r => r.SaveChanges(), Times.Once);
                mockRepository.Verify(r => r.Delete(seatEntity), Times.Once);
                Assert.AreEqual(result, seatEntity);
                Assert.IsInstanceOfType(result, typeof(Seat));
            }

            [TestMethod]
            public void When_Delete_AndErrorInRepo_Then_DataService_Should_ThrowException()
            {
                var badEntity = CreateEntities.CreateNewSeatEntity();
                mockRepository.Setup(r => r.Delete(badEntity))
                    .Throws(new InvalidCastException());
                var expected = CustomAssert.ExpectedExceptionRaised(() =>
                    {
                        dataService.Delete(badEntity);
                    },
                    typeof(InvalidOperationException));
                Assert.IsNotNull(expected.InnerException);
                Assert.IsInstanceOfType(expected.InnerException, typeof(InvalidCastException));
            }
        }

    }
}