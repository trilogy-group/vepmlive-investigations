using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveCore.SocialEngine.Core;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.SocialEngine.Entities
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SocialEngine.Entities.User" />)
    ///     and namespace <see cref="EPMLiveCore.SocialEngine.Entities"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class UserTest : AbstractBaseSetupTypedTest<User>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (User) Initializer

        private const string PropertyId = "Id";
        private const string PropertyRole = "Role";
        private Type _userInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private User _userInstance;
        private User _userInstanceFixture;

        #region General Initializer : Class (User) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="User" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _userInstanceType = typeof(User);
            _userInstanceFixture = Create(true);
            _userInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (User)

        #region General Initializer : Class (User) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="User" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyId)]
        [TestCase(PropertyRole)]
        public void AUT_User_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_userInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="User" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_User_Is_Instance_Present_Test()
        {
            // Assert
            _userInstanceType.ShouldNotBeNull();
            _userInstance.ShouldNotBeNull();
            _userInstanceFixture.ShouldNotBeNull();
            _userInstance.ShouldBeAssignableTo<User>();
            _userInstanceFixture.ShouldBeAssignableTo<User>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (User) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_User_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            User instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _userInstanceType.ShouldNotBeNull();
            _userInstance.ShouldNotBeNull();
            _userInstanceFixture.ShouldNotBeNull();
            _userInstance.ShouldBeAssignableTo<User>();
            _userInstanceFixture.ShouldBeAssignableTo<User>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (User) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(int) , PropertyId)]
        [TestCaseGeneric(typeof(UserRole) , PropertyRole)]
        public void AUT_User_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<User, T>(_userInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (Id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_Id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (Role) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Role_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyRole);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (Role) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_Role_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyRole);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #endregion
    }
}