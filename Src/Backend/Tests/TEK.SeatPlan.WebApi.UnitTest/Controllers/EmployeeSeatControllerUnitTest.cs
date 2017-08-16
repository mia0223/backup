using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TEK.SeatPlan.BusinessLogic.Contract;
using TEK.SeatPlan.Tests.Shared;
using TEK.SeatPlan.WebApi.Controllers;

namespace TEK.SeatPlan.WebApi.UnitTest.Controllers
{
   [TestClass]
   public class EmployeeSeatControllerUnitTest
   {
      private EmployeeSeatController sut;
      private Mock<IEmployeeSeatComponent> mockBusiness;

      [TestInitialize]
      public void Initialize()
      {
         mockBusiness = new Mock<IEmployeeSeatComponent>();
         sut = new EmployeeSeatController(mockBusiness.Object);
      }

      [TestClass]
      public class WhenGet : EmployeeSeatControllerUnitTest
      {
         [TestMethod]
         public void CanFindEmployeeSeat()
         {
            var employeeId = 11;
            var expectedSeat = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Entity.Seat>();
            mockBusiness.Setup(c => c.GetSeatByEmployeeId(employeeId))
               .Returns(expectedSeat);

            var seat = sut.Get(employeeId);

            Assert.IsTrue(DtoGenericUtils.IsEqual(expectedSeat, seat));
         }

         [TestMethod]
         public void CannotFindEmployeeSeat()
         {
            var employeeId = 11;
            var expectedSeat = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Entity.Seat>();
            mockBusiness.Setup(c => c.GetSeatByEmployeeId(employeeId))
               .Returns((Entity.Seat)null);

            var seat = sut.Get(employeeId);

            Assert.IsNull(seat);
         }
      }

      [TestClass]
      public class WhenPut : EmployeeSeatControllerUnitTest
      {
         [TestMethod]
         public void CallUpdateWhenEmployeeSeatDtoIsValid()
         {
            var expectedEmployeeSeat = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Dto.EmployeeSeatProject>();
            mockBusiness.Setup(c => c.UpdateEmployeeSeatProject(expectedEmployeeSeat))
               .Returns(expectedEmployeeSeat);

            var employeeSeat = sut.Put(expectedEmployeeSeat);

            Assert.IsTrue(DtoGenericUtils.IsEqual(expectedEmployeeSeat, employeeSeat));
            mockBusiness.Verify(c=> c.UpdateEmployeeSeatProject(expectedEmployeeSeat),Times.Once);
         }

         [TestMethod]
         public void CallUpdateWhenEmployeeSeatDtoIsInvalid()
         {
            var expectedEmployeeSeat = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Dto.EmployeeSeatProject>();
            mockBusiness.Setup(c => c.UpdateEmployeeSeatProject(null))
               .Returns(expectedEmployeeSeat);

            var employeeSeat = sut.Put(null);

            Assert.IsTrue(DtoGenericUtils.IsEqual(expectedEmployeeSeat, employeeSeat));
            mockBusiness.Verify(c => c.UpdateEmployeeSeatProject(null), Times.Once);
         }
      }

   }
}
