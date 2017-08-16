using System.Configuration;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TEK.SeatPlan.BusinessLogic.Contract;
using TEK.SeatPlan.Entity;
using TEK.SeatPlan.WebApi;
using TEK.SeatPlan.WebApi.Controllers;

namespace TEK.SeatPlan.IntegrationTest.Authorization
{
    [TestClass]
    public class ControllerAuthorizationTests
    {
        private string _dummyRole;

        //private EmployeeController _sutEmployee;
        private LocationController _sutLocation;
        private ProjectController _sutProject;
        private ProjectLocationController _sutProjectLocation;
        private SeatController _sutSeat;
        private SeatLocationController _sutLocationSeat;

        // Pending Refactoring
        // private Mock<IDataService<Employee>> _mockEmployeeData;

        private Mock<IDataService<Location>> _mockLocationData;
        private Mock<IEmployeeSeatComponent> _mockEmployeeSeatData;
        private Mock<IDataService<Seat>> _mockSeatData;
        private Mock<IProjectComponent> _mockProjectComponent;
        private Mock<IMoveComponent> _moveComponent;


        [TestInitialize]
        public void TestInitialize()
        {
            _dummyRole = ConfigurationManager.AppSettings["adminGroupAccess"];
        }

        [TestCleanup]
        public void TestCleanup_Restore()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("adminGroupAccess");
            config.AppSettings.Settings.Add("adminGroupAccess", _dummyRole);
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        // ToDo: Pending Refactoring
        //[TestClass]
        //public class WhenGetEmployee : ControllerAuthorizationTests
        //{
        //   [TestMethod]
        //   public void AndUserIsMemberOfAuthorizedGroup_Then_ShouldNotReturnNull()
        //   {
        //      _mockEmployeeData = new Mock<IDataService<Employee>>();
        //      _sutEmployee = new EmployeeController(_mockEmployeeData.Object);

        //      bool result = testGroupAttribute(_sutEmployee, _dummyRole);
        //      Assert.IsTrue(result);
        //   }

        //   [TestMethod]
        //   public void AndUserIsNotMemeberOfAuthorizedGroup_Then_ShouldReturnNull()
        //   {
        //      _mockEmployeeData = new Mock<IDataService<Employee>>();
        //      _sutEmployee = new EmployeeController(_mockEmployeeData.Object);
        //      SetConfig();

        //      bool result = testGroupAttribute(_sutEmployee, _dummyRole);
        //      Assert.IsFalse(result);
        //   }
        //}

        [TestClass]
        public class WhenGetLocation : ControllerAuthorizationTests
        {
            [TestMethod]
            public void AndUserIsMemeberOfAuthorizedGroup_Then_ShouldNotReturnNull()
            {
                _mockLocationData = new Mock<IDataService<Location>>();
                _sutLocation = new LocationController(_mockLocationData.Object);

                bool result = testGroupAttribute(_sutLocation, _dummyRole);
                Assert.IsTrue(result);
            }

            [TestMethod]
            public void AndUserIsNotMemeberOfAuthorizedGroup_Then_ShouldReturnNull()
            {
                _mockLocationData = new Mock<IDataService<Location>>();
                _sutLocation = new LocationController(_mockLocationData.Object);
                SetConfig();

                bool result = testGroupAttribute(_sutLocation, _dummyRole);
                Assert.IsFalse(result);
            }

        }

        [TestClass]
        public class WhenGetProject : ControllerAuthorizationTests
        {
            [TestMethod]
            public void AndUserIsMemberOfAuthorizedGroup_Then_ShouldNotReturnNull()
            {
                _mockProjectComponent = new Mock<IProjectComponent>();
                _sutProject = new ProjectController(_mockProjectComponent.Object);

                bool result = testGroupAttribute(_sutProject, _dummyRole);
                Assert.IsTrue(result);
            }

            [TestMethod]
            public void AndUserIsNotMemberOfAuthorizedGroup_Then_ShouldReturnNull()
            {
                _mockProjectComponent = new Mock<IProjectComponent>();
                _sutProject = new ProjectController(_mockProjectComponent.Object);
                SetConfig();

                bool result = testGroupAttribute(_sutProject, _dummyRole);
                Assert.IsFalse(result);
            }
        }

        [TestClass]
        public class WhenGetProjectLocation : ControllerAuthorizationTests
        {
            [TestMethod]
            public void AndUserIsMemberOfAuthorizedGroup_Then_ShouldNotReturnNull()
            {
                _mockSeatData = new Mock<IDataService<Seat>>();
                _sutProjectLocation = new ProjectLocationController(_mockSeatData.Object);

                bool result = testGroupAttribute(_sutProjectLocation, _dummyRole);
                Assert.IsTrue(result);
            }

            [TestMethod]
            public void AndUserIsNotMemberOfAuthorizedGroup_Then_ShouldReturnNull()
            {
                _mockSeatData = new Mock<IDataService<Seat>>();
                _sutProjectLocation = new ProjectLocationController(_mockSeatData.Object);
                SetConfig();

                bool result = testGroupAttribute(_sutProjectLocation, _dummyRole);
                Assert.IsFalse(result);
            }
        }

        [TestClass]
        public class WhenGetSeat : ControllerAuthorizationTests
        {
            [TestMethod]
            public void AndUserIsMemeberOfAuthorizedGroup_Then_ShouldNotReturnNull()
            {
                _mockEmployeeSeatData = new Mock<IEmployeeSeatComponent>();
                _moveComponent = new Mock<IMoveComponent>();
                _sutSeat = new SeatController(_mockEmployeeSeatData.Object, _moveComponent.Object);

                bool result = testGroupAttribute(_sutSeat, _dummyRole);
                Assert.IsTrue(result);
            }

            [TestMethod]
            public void AndUserIsNotMemeberOfAuthorizedGroup_Then_ShouldReturnNull()
            {
                _mockEmployeeSeatData = new Mock<IEmployeeSeatComponent>();
                _moveComponent = new Mock<IMoveComponent>();
                _sutSeat = new SeatController(_mockEmployeeSeatData.Object, _moveComponent.Object);
                SetConfig();

                bool result = testGroupAttribute(_sutSeat, _dummyRole);
                Assert.IsFalse(result);
            }
        }

        [TestClass]
        public class WhenGetSeatLocation : ControllerAuthorizationTests
        {
            [TestMethod]
            public void AndUserIsMemberOfAuthorizedGroup_Then_ShouldNotReturnNull()
            {
                _mockSeatData = new Mock<IDataService<Seat>>();
                _sutLocationSeat = new SeatLocationController(_mockSeatData.Object);

                bool result = testGroupAttribute(_sutLocationSeat, _dummyRole);
                Assert.IsTrue(result);
            }

            [TestMethod]
            public void AndUserIsNotMemberOfAuthorizedGroup_Then_ShouldReturnNull()
            {
                _mockSeatData = new Mock<IDataService<Seat>>();
                _sutLocationSeat = new SeatLocationController(_mockSeatData.Object);
                SetConfig();

                bool result = testGroupAttribute(_sutLocationSeat, _dummyRole);
                Assert.IsFalse(result);
            }
        }

        private bool testGroupAttribute(object controller, string role)
        {
            //Arrange
            var type = controller.GetType();
            var attributes = type.GetCustomAttributes(typeof(TEKAuthorizeAttribute), true);
            //Assert
            Assert.IsTrue(attributes.Any(), "No TEKAuthorizeAttribute found");
            var authorizeAttribute = attributes[0] as TEKAuthorizeAttribute;
            return authorizeAttribute.Roles.Split(',').Any(r => role == r);
        }


        private void SetConfig()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("adminGroupAccess");
            config.AppSettings.Settings.Add("adminGroupAccess", "blah");
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

    }
}


