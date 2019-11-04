using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Web;
using EPMLiveCore.Fakes;
using EPMLiveCore.Helpers.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.ISAPI.Lic
{
    [TestClass, ExcludeFromCodeCoverage]
    public class LicensingTests
    {
        private const int Id = 1;
        private const string One = "1";
        private const string DummyString = "DummyString";
        private const string LongUsername = @"i:0#.w|np3\mpritchard,#i:0#.w|np3\mpritchard,#mpritchard@frbnp3.com,#,#Protchard, Marsha,#,#Project Management Office,#Project Services:1";
        private const string ShortFormOfLongUsername = @"np3\mpritchard:1";
        private const string Unlimited = "Unlimited";
        private const string ExampleUrl = "http://example.com";
        private const string NormalizeUsernameMethodName = "NormalizeUsername";
        private Licensing _testObject;
        private PrivateObject _privateObject;
        private IDisposable _shimsContext;
        private StringWriter _responseWriter;
        private bool _didUpdateUserManager;
        private bool _didUpdateFarm;
        private string _user;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            _testObject = new Licensing();
            _privateObject = new PrivateObject(_testObject);

            HttpContext.Current = new HttpContext(
                new HttpRequest(string.Empty, ExampleUrl, string.Empty),
                new HttpResponse(_responseWriter));

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = callback => callback?.Invoke();
            ShimSPFarm.LocalGet = () => new ShimSPFarm();

            ShimWebServicesHelper.FarmFeatureUsersInt32 = _ => new ArrayList();

            _user = $"{DummyString}:{Id}";
            ShimCoreFunctions.GetRealUserNameString = _ => _user;

            _didUpdateUserManager = false;
            _didUpdateFarm = false;
            ShimSPFarm.AllInstances.Update = _ => _didUpdateFarm = true;
            ShimSPPersistedObject.AllInstances.Update = _ => _didUpdateUserManager = true;
            ShimSPPersistedObject.AllInstances.GetChildOf1String<UserManager>((_, __) => null);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
            _responseWriter?.Dispose();
        }

        [TestMethod]
        public void SetUserLevel_Unlimited_ReturnsZero()
        {
            // Arrange
            ShimCoreFunctions.getFeatureLicenseUserCountInt32 = _ => Unlimited;

            // Act
            var result = _testObject.SetUserLevel(DummyString, Id);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => HttpContext.Current.Items["FormDigestValidated"].ShouldBe(true),
                () => result.ShouldBe(0));
        }

        [TestMethod]
        public void SetUserLevel_LimitedEmpty_ReturnsZero()
        {
            // Arrange
            ShimCoreFunctions.getFeatureLicenseUserCountInt32 = _ => One;
            ShimUserManager.AllInstances.UserListGet = _ => new ArrayList { string.Empty };

            // Act
            var result = _testObject.SetUserLevel(DummyString, Id);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _didUpdateUserManager.ShouldBeTrue(),
                () => _didUpdateFarm.ShouldBeTrue(),
                () => result.ShouldBe(0));
        }

        [TestMethod]
        public void SetUserLevel_LimitedNone_ReturnsZero()
        {
            // Arrange
            ShimCoreFunctions.getFeatureLicenseUserCountInt32 = _ => One;
            ShimUserManager.AllInstances.UserListGet = _ => new ArrayList { string.Empty };

            // Act
            var result = _testObject.SetUserLevel(DummyString, Id);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _didUpdateUserManager.ShouldBeTrue(),
                () => _didUpdateFarm.ShouldBeTrue(),
                () => result.ShouldBe(0));
        }

        [TestMethod]
        public void SetUserLevel_LimitedBelow_ReturnsOne()
        {
            // Arrange
            ShimCoreFunctions.getFeatureLicenseUserCountInt32 = _ => One;
            ShimUserManager.AllInstances.UserListGet = _ => new ArrayList { "User1", "User2" };

            // Act
            var result = _testObject.SetUserLevel(DummyString, Id);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _didUpdateUserManager.ShouldBeTrue(),
                () => _didUpdateFarm.ShouldBeTrue(),
                () => result.ShouldBe(1));
        }

        [TestMethod]
        public void SetUserLevel_Feature1000AlreadyExists_ReturnsZero()
        {
            // Arrange
            ShimUserManager.AllInstances.UserListGet = _ => new ArrayList { _user };
            ShimAct.GetAllAvailableLevelsInt32Out = (out int actType) =>
            {
                actType = Id;
                return new SortedList { { Id, Id } };
            };

            // Act
            var result = _testObject.SetUserLevel(DummyString, 1000);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(0),
                () => _didUpdateUserManager.ShouldBeTrue(),
                () => _didUpdateFarm.ShouldBeTrue(),
                () => HttpContext.Current.Items["FormDigestValidated"].ShouldBe(true));
        }

        [TestMethod]
        public void SetUserLevel_Feature1000AlreadyExistsWithLongUsername_ReturnsZero()
        {
            // Arrange
            ShimUserManager.AllInstances.UserListGet = _ => new ArrayList { LongUsername };
            ShimCoreFunctions.GetRealUserNameString = _ => LongUsername;
            ShimAct.GetAllAvailableLevelsInt32Out = (out int actType) =>
            {
                actType = Id;
                return new SortedList { { Id, Id } };
            };

            // Act
            var result = _testObject.SetUserLevel(LongUsername, 1000);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(0),
                () => _didUpdateUserManager.ShouldBeTrue(),
                () => _didUpdateFarm.ShouldBeTrue(),
                () => HttpContext.Current.Items["FormDigestValidated"].ShouldBe(true));
        }

        [TestMethod]
        public void SetUserLevel_Feature1000NewUser_ReturnsZero()
        {
            // Arrange
            ShimUserManager.AllInstances.UserListGet = _ => new ArrayList { $"Dummy:2" };
            ShimAct.GetAllAvailableLevelsInt32Out = (out int actType) =>
            {
                actType = Id;
                return new SortedList { { Id, Id } };
            };

            // Act
            var result = _testObject.SetUserLevel(DummyString, 1000);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(0),
                () => _didUpdateUserManager.ShouldBeTrue(),
                () => _didUpdateFarm.ShouldBeTrue(),
                () => HttpContext.Current.Items["FormDigestValidated"].ShouldBe(true));
        }

        [TestMethod]
        public void SetUserLevel_Feature1000NewUserWithLongUsername_ReturnsZero()
        {
            // Arrange
            ShimUserManager.AllInstances.UserListGet = _ => new ArrayList { LongUsername };
            ShimCoreFunctions.GetRealUserNameString = _ => LongUsername;
            ShimAct.GetAllAvailableLevelsInt32Out = (out int actType) =>
            {
                actType = Id;
                return new SortedList { { Id, Id } };
            };

            // Act
            var result = _testObject.SetUserLevel(LongUsername, 1000);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(0),
                () => _didUpdateUserManager.ShouldBeTrue(),
                () => _didUpdateFarm.ShouldBeTrue(),
                () => HttpContext.Current.Items["FormDigestValidated"].ShouldBe(true));
        }

        [TestMethod]
        public void SetUserLevel_Feature1000NotExist_ReturnsOne()
        {
            // Arrange
            ShimUserManager.AllInstances.UserListGet = _ => new ArrayList { $"Dummy:1" };
            ShimAct.GetAllAvailableLevelsInt32Out = (out int actType) =>
            {
                actType = Id;
                return new SortedList { { Id, Id } };
            };

            // Act
            var result = _testObject.SetUserLevel(DummyString, 1000);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(1),
                () => _didUpdateUserManager.ShouldBeTrue(),
                () => _didUpdateFarm.ShouldBeTrue(),
                () => HttpContext.Current.Items["FormDigestValidated"].ShouldBe(true));
        }

        [TestMethod]
        public void SetUserLevel_Feature1000NotContainFeature_ReturnsTwo()
        {
            // Arrange
            ShimUserManager.AllInstances.UserListGet = _ => new ArrayList { $"{DummyString}:2" };
            ShimAct.GetAllAvailableLevelsInt32Out = (out int actType) =>
            {
                actType = Id;
                return new SortedList { { 2, 2 } };
            };

            // Act
            var result = _testObject.SetUserLevel(DummyString, 1000);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(2),
                () => _didUpdateUserManager.ShouldBeTrue(),
                () => _didUpdateFarm.ShouldBeTrue(),
                () => HttpContext.Current.Items["FormDigestValidated"].ShouldBe(true));
        }

        [TestMethod]
        public void NormalizeUsername_WithStandardUsername_ReturnsTheSame()
        {
            // Arrange
            var username = "Username:1";
            var paramsToPass = new object[] { username };
            var normalizeUsernameMethod = typeof(Licensing).GetMethod(NormalizeUsernameMethodName, BindingFlags.Static | BindingFlags.NonPublic);

            // Act
            normalizeUsernameMethod.Invoke(null, paramsToPass);

            // Assert
            Assert.AreEqual(username, paramsToPass[0]);
        }

        [TestMethod]
        public void NormalizeUsername_WithLongUsername_ReturnsTheSame()
        {
            // Arrange
            var paramsToPass = new object[] { LongUsername };
            var normalizeUsernameMethod = typeof(Licensing).GetMethod(NormalizeUsernameMethodName, BindingFlags.Static | BindingFlags.NonPublic);

            // Act
            normalizeUsernameMethod.Invoke(null, paramsToPass);

            // Assert
            Assert.AreEqual(ShortFormOfLongUsername, paramsToPass[0]);
        }
    }
}
