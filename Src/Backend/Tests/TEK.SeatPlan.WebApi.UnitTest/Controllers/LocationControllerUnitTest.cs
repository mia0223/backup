using System;
using System.Linq;
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
   public class LocationControllerUnitTest
   {
      private LocationController sut;
      private Mock<IDataService<Location>> mockBusiness;

      [TestInitialize]
      public void Initialize()
      {
         mockBusiness = new Mock<IDataService<Location>>();
         sut = new LocationController(mockBusiness.Object);
      }

      [TestClass]
      public class WhenGet : LocationControllerUnitTest
      {
         [TestMethod]
         public void AndBusinessReturnsNull_ShouldReturnNull()
         {
            mockBusiness.Setup(ds => ds.Find(It.IsAny<Expression<Func<Location, bool>>>(), It.IsAny<Func<IQueryable<Location>, IOrderedQueryable<Location>>>())).Returns<Location>(null);

            var result = sut.Get();

            Assert.IsNull(result);
            mockBusiness.Verify(ds => ds.Find(It.IsAny<Expression<Func<Location, bool>>>(), It.IsAny<Func<IQueryable<Location>, IOrderedQueryable<Location>>>()), Times.Once);
         }

         [TestMethod]
         public void AndBusinessReturnsEntity_ShouldReturnCorrespondingDto()
         {
            var mockEntity = new [] {DtoGenericUtils.CreateNewInstanceWithDefaultValues<Location>()};
            mockBusiness.Setup(ds => ds.Find(It.IsAny<Expression<Func<Location, bool>>>(), It.IsAny<Func<IQueryable<Location>, IOrderedQueryable<Location>>>())).Returns(mockEntity);

            var result = sut.Get();

            Assert.IsNotNull(result);
            mockBusiness.Verify(ds => ds.Find(It.IsAny<Expression<Func<Location, bool>>>(), It.IsAny<Func<IQueryable<Location>, IOrderedQueryable<Location>>>()), Times.Once);
            Assert.IsTrue(DtoGenericUtils.IsEqual(mockEntity[0], result.First()));
         }
      }

   }
}
