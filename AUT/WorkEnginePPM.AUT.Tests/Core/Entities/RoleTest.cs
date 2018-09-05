using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace WorkEnginePPM.Core.Entities
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Core.Entities.Role" />)
    ///     and namespace <see cref="WorkEnginePPM.Core.Entities"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class RoleTest : AbstractBaseSetupTypedTest<Role>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Role) Initializer

        private const string PropertyCCRId = "CCRId";
        private const string PropertyCCRName = "CCRName";
        private const string PropertyDataId = "DataId";
        private const string PropertyRoleId = "RoleId";
        private const string PropertyId = "Id";
        private const string PropertyTitle = "Title";
        private Type _roleInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Role _roleInstance;
        private Role _roleInstanceFixture;

        #region General Initializer : Class (Role) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Role" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _roleInstanceType = typeof(Role);
            _roleInstanceFixture = Create(true);
            _roleInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Role)

        #region General Initializer : Class (Role) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Role" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyCCRId)]
        [TestCase(PropertyCCRName)]
        [TestCase(PropertyDataId)]
        [TestCase(PropertyRoleId)]
        [TestCase(PropertyId)]
        [TestCase(PropertyTitle)]
        public void AUT_Role_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_roleInstanceFixture,
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
        ///     Class (<see cref="Role" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Role_Is_Instance_Present_Test()
        {
            // Assert
            _roleInstanceType.ShouldNotBeNull();
            _roleInstance.ShouldNotBeNull();
            _roleInstanceFixture.ShouldNotBeNull();
            _roleInstance.ShouldBeAssignableTo<Role>();
            _roleInstanceFixture.ShouldBeAssignableTo<Role>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Role) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Role_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Role instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _roleInstanceType.ShouldNotBeNull();
            _roleInstance.ShouldNotBeNull();
            _roleInstanceFixture.ShouldNotBeNull();
            _roleInstance.ShouldBeAssignableTo<Role>();
            _roleInstanceFixture.ShouldBeAssignableTo<Role>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Role) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyCCRId)]
        [TestCaseGeneric(typeof(string) , PropertyCCRName)]
        [TestCaseGeneric(typeof(string) , PropertyDataId)]
        [TestCaseGeneric(typeof(string) , PropertyRoleId)]
        [TestCaseGeneric(typeof(int?) , PropertyId)]
        [TestCaseGeneric(typeof(string) , PropertyTitle)]
        public void AUT_Role_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Role, T>(_roleInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Role) => Property (CCRId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Role_Public_Class_CCRId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCCRId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Role) => Property (CCRName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Role_Public_Class_CCRName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCCRName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Role) => Property (DataId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Role_Public_Class_DataId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDataId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Role) => Property (Id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Role_Public_Class_Id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Role) => Property (RoleId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Role_Public_Class_RoleId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyRoleId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Role) => Property (Title) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Role_Public_Class_Title_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyTitle);

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