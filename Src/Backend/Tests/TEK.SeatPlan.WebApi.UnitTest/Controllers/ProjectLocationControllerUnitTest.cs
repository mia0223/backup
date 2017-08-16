﻿using System;
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
    public class ProjectLocationControllerUnitTest
    {
        private ProjectLocationController sut;
        private Mock<IDataService<Seat>> mockBusiness;

        [TestInitialize]
        public void Initialize()
        {
            mockBusiness = new Mock<IDataService<Seat>>();
            sut = new ProjectLocationController(mockBusiness.Object);
        }

        [TestClass]
        public class WhenGet : ProjectLocationControllerUnitTest
        {
            [TestMethod]
            public void AndBusinessReturnsNull_ShouldReturnNull()
            {
                mockBusiness.Setup(ds => ds.Find(It.IsAny<Expression<Func<Seat, bool>>>(), null, It.IsAny<Expression<Func<Seat, object>>>(), It.IsAny<Expression<Func<Seat, object>>>())).Returns<Seat>(null);

                var result = sut.Get(1);

                Assert.IsNull(result);
                mockBusiness.Verify(ds => ds.Find(It.IsAny<Expression<Func<Seat, bool>>>(), null, It.IsAny<Expression<Func<Seat, object>>>(), It.IsAny<Expression<Func<Seat, object>>>()), Times.Once);
            }

            [TestMethod]
            public void AndBusinessReturnsEntity_ShouldReturnCorrespondingDto()
            {
                var seat = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Seat>();
                seat.Employee = new Employee()
                {
                    Project = new Project()
                };
                var mockEntity = new []{ seat };
                mockBusiness.Setup(ds => ds.Find(It.IsAny<Expression<Func<Seat, bool>>>(), null, It.IsAny<Expression<Func<Seat, object>>>(), It.IsAny<Expression<Func<Seat, object>>>())).Returns(mockEntity);

                var result = sut.Get(1);

                Assert.IsNotNull(result);
                mockBusiness.Verify(ds => ds.Find(It.IsAny<Expression<Func<Seat, bool>>>(), null, It.IsAny<Expression<Func<Seat, object>>>(), It.IsAny<Expression<Func<Seat, object>>>()), Times.Once);
                Assert.IsTrue(DtoGenericUtils.IsEqual(mockEntity[0].Employee.Project, result.First()));
            }
        }
    }
}