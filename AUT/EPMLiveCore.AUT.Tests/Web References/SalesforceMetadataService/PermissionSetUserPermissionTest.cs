using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.PermissionSetUserPermission" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class PermissionSetUserPermissionTest : AbstractBaseSetupTypedTest<PermissionSetUserPermission>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PermissionSetUserPermission) Initializer

        private const string Propertyenabled = "enabled";
        private const string Propertyname = "name";
        private const string FieldenabledField = "enabledField";
        private const string FieldnameField = "nameField";
        private Type _permissionSetUserPermissionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PermissionSetUserPermission _permissionSetUserPermissionInstance;
        private PermissionSetUserPermission _permissionSetUserPermissionInstanceFixture;

        #region General Initializer : Class (PermissionSetUserPermission) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PermissionSetUserPermission" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _permissionSetUserPermissionInstanceType = typeof(PermissionSetUserPermission);
            _permissionSetUserPermissionInstanceFixture = Create(true);
            _permissionSetUserPermissionInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PermissionSetUserPermission)

        #region General Initializer : Class (PermissionSetUserPermission) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="PermissionSetUserPermission" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyenabled)]
        [TestCase(Propertyname)]
        public void AUT_PermissionSetUserPermission_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_permissionSetUserPermissionInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PermissionSetUserPermission) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PermissionSetUserPermission" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldenabledField)]
        [TestCase(FieldnameField)]
        public void AUT_PermissionSetUserPermission_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_permissionSetUserPermissionInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="PermissionSetUserPermission" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_PermissionSetUserPermission_Is_Instance_Present_Test()
        {
            // Assert
            _permissionSetUserPermissionInstanceType.ShouldNotBeNull();
            _permissionSetUserPermissionInstance.ShouldNotBeNull();
            _permissionSetUserPermissionInstanceFixture.ShouldNotBeNull();
            _permissionSetUserPermissionInstance.ShouldBeAssignableTo<PermissionSetUserPermission>();
            _permissionSetUserPermissionInstanceFixture.ShouldBeAssignableTo<PermissionSetUserPermission>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PermissionSetUserPermission) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_PermissionSetUserPermission_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PermissionSetUserPermission instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _permissionSetUserPermissionInstanceType.ShouldNotBeNull();
            _permissionSetUserPermissionInstance.ShouldNotBeNull();
            _permissionSetUserPermissionInstanceFixture.ShouldNotBeNull();
            _permissionSetUserPermissionInstance.ShouldBeAssignableTo<PermissionSetUserPermission>();
            _permissionSetUserPermissionInstanceFixture.ShouldBeAssignableTo<PermissionSetUserPermission>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (PermissionSetUserPermission) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , Propertyenabled)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_PermissionSetUserPermission_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<PermissionSetUserPermission, T>(_permissionSetUserPermissionInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSetUserPermission) => Property (enabled) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSetUserPermission_Public_Class_enabled_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyenabled);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSetUserPermission) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSetUserPermission_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyname);

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