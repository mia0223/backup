using System;
using System.Collections.Generic;
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
    //[TestClass]
    //public class EmployeeControllerUnitTest
    //{
    //    private EmployeeController sut;
    //    private Mock<IDataService<Entity.Employee>> mockBusiness;

    //    [TestInitialize]
    //    public void Initialize()
    //    {
    //        mockBusiness = new Mock<IDataService<Employee>>();
    //        sut = new EmployeeController(mockBusiness.Object);
    //    }

    //    [TestClass]
    //    public class WhenGetById : EmployeeControllerUnitTest
    //    {
            //[TestMethod]
            //public void AndBusinessReturnsNull_ShouldReturnNull()
            //{
            //    mockBusiness.Setup(ds => ds.Get(It.IsAny<Expression<Func<Employee, bool>>>(),
            //       It.IsAny<Expression<Func<Employee, object>>>())).Returns<Employee>(null);

            //    var result = sut.Get(1);

            //    Assert.IsNull(result);
            //    mockBusiness.Verify(ds => ds.Get(It.IsAny<Expression<Func<Employee, bool>>>(),
            //       It.IsAny<Expression<Func<Employee, object>>>()), Times.Once);
            //}

        //    [TestMethod]
        //    public void AndBusinessReturnsEntity_ShouldReturnCorrespondingDto()
        //    {
        //        var mockEntity = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Employee>();

        //        mockBusiness.Setup(ds => ds.Get(
        //            It.IsAny<Expression<Func<Employee, bool>>>(),
        //            It.IsAny<Expression<Func<Employee, object>>>(),
        //            It.IsAny<Expression<Func<Employee, object>>>(),
        //            It.IsAny<Expression<Func<Employee, object>>>()
        //            ))
        //           .Returns(mockEntity);

        //        var result = sut.Get(1);

        //        Assert.IsNotNull(result);
        //        mockBusiness.Verify(ds => ds.Get(
        //            It.IsAny<Expression<Func<Employee, bool>>>(),
        //            It.IsAny<Expression<Func<Employee, object>>>(),
        //            It.IsAny<Expression<Func<Employee, object>>>(),
        //            It.IsAny<Expression<Func<Employee, object>>>()
        //        ),
        //        Times.Once);

        //        Assert.IsTrue(DtoGenericUtils.IsEqual(mockEntity, result));
        //    }
        //}

        //[TestClass]
        //public class WhenGetAll : EmployeeControllerUnitTest
        //{
            //[TestMethod]
            //public void AndBusinessReturnsNull_ShouldReturnNull()
            //{
            //    mockBusiness.Setup(ds => ds.Find(It.IsAny<Expression<Func<Employee, bool>>>(),
            //       It.IsAny<Func<IQueryable<Employee>, IOrderedQueryable<Employee>>>())).Returns<Employee>(null);

            //    var result = sut.Get();

            //    Assert.IsNull(result);
            //    mockBusiness.Verify(ds => ds.Find(It.IsAny<Expression<Func<Employee, bool>>>(),
            //       It.IsAny<Func<IQueryable<Employee>, IOrderedQueryable<Employee>>>()), Times.Once);
            //}

            //[TestMethod]
            //public void AndBusinessReturnsEntity_ShouldReturnCorrespondingDto()
            //{
            //    var mockEntities = new List<Employee> { DtoGenericUtils.CreateNewInstanceWithDefaultValues<Employee>(), DtoGenericUtils.CreateNewInstanceWithDefaultValues<Employee>() };

            //    mockBusiness.Setup(ds => ds.Find(It.IsAny<Expression<Func<Employee, bool>>>(),
            //       It.IsAny<Func<IQueryable<Employee>, IOrderedQueryable<Employee>>>())).Returns(mockEntities);

            //    var result = sut.Get();

            //    var dtoList = result as IList<Dto.Employee> ?? result.ToList();
            //    Assert.IsNotNull(dtoList);
            //    Assert.AreEqual(mockEntities.Count, dtoList.Count());
            //    mockBusiness.Verify(
            //       ds => ds.Find(It.IsAny<Expression<Func<Employee, bool>>>(),
            //          It.IsAny<Func<IQueryable<Employee>, IOrderedQueryable<Employee>>>()), Times.Once);

            //    for (var i = 0; i < mockEntities.Count; i++)
            //    {
            //        Assert.IsTrue(DtoGenericUtils.IsEqual(mockEntities[i], dtoList[i]));
            //    }
            //}
        }

        //[TestClass]
        //public class WhenPush : EmployeeControllerUnitTest
        //{
        //    [TestMethod]
        //    public void ConvertDtoToEntity_AndPassItToBusiness()
        //    {
        //        var ignoredProperties = new[] { "Id" };
        //        var mockDto = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Dto.Employee>();

        //        sut.Post(mockDto);

        //        mockBusiness.Verify(ds => ds.Add(It.Is<Employee>(v => DtoGenericUtils.IsEqual(mockDto, v, ignoredProperties))), Times.Once);
        //    }
        //}

        // ToDo: Pending Refactoring
		//[TestClass]
        //public class WhenPut : EmployeeControllerUnitTest
        //{
        //    [TestMethod]
        //    public void ConvertDtoToEntity_AndPassItToBusiness()
        //    {
        //        var mockDto = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Dto.Employee>();
        //        var mockEntity = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Entity.Employee>();
        //        mockBusiness
        //           .Setup(ds => ds.Get(It.IsAny<Expression<Func<Entity.Employee, bool>>>(),
        //              It.IsAny<Expression<Func<Entity.Employee, object>>[]>()))
        //           .Returns(mockEntity);
        //        mockBusiness
        //           .Setup(ds => ds.Update(mockEntity))
        //           .Returns(mockEntity);

        //        var res = sut.Put(mockDto);

        //        mockBusiness.Verify(ds => ds.Get(It.IsAny<Expression<Func<Entity.Employee, bool>>>(),
        //           It.IsAny<Expression<Func<Entity.Employee, object>>[]>()), Times.Once);
        //        mockBusiness.Verify(ds => ds.Update(mockEntity), Times.Once);
        //        Assert.IsTrue(DtoGenericUtils.IsEqual(mockDto, res));
        //    }

        //    [TestMethod]
        //    public void CannotFindTheEmployeeToUpdate()
        //    {
        //        var mockDto = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Dto.Employee>();
        //        mockBusiness
        //           .Setup(ds => ds.Get(It.IsAny<Expression<Func<Entity.Employee, bool>>>(),
        //              It.IsAny<Expression<Func<Entity.Employee, object>>[]>()))
        //           .Returns((Entity.Employee)null);


        //        var ex = CustomAssert.ExpectedExceptionRaised(() => sut.Put(mockDto), typeof(InvalidOperationException));

        //        Assert.AreEqual($"Employee [{mockDto.LastName}] not found", ex.Message);
        //    }

        //    [TestMethod]
        //    public void CannotUpdateTheEmployee()
        //    {
        //        var mockDto = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Dto.Employee>();
        //        var mockEntity = DtoGenericUtils.CreateNewInstanceWithDefaultValues<Entity.Employee>();
        //        mockBusiness
        //           .Setup(ds => ds.Get(It.IsAny<Expression<Func<Entity.Employee, bool>>>(),
        //              It.IsAny<Expression<Func<Entity.Employee, object>>[]>()))
        //           .Returns(mockEntity);
        //        mockBusiness
        //           .Setup(ds => ds.Update(mockEntity))
        //           .Returns((Entity.Employee)null);

        //        var res = sut.Put(mockDto);

        //        mockBusiness.Verify(ds => ds.Get(It.IsAny<Expression<Func<Entity.Employee, bool>>>(),
        //           It.IsAny<Expression<Func<Entity.Employee, object>>[]>()), Times.Once);
        //        mockBusiness.Verify(ds => ds.Update(mockEntity), Times.Once);
        //        Assert.IsNull(res);
        //    }
        //}
    //}
//}