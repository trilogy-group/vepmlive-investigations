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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.PermissionSetFieldPermissions" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class PermissionSetFieldPermissionsTest : AbstractBaseSetupTypedTest<PermissionSetFieldPermissions>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PermissionSetFieldPermissions) Initializer

        private const string Propertyeditable = "editable";
        private const string Propertyfield = "field";
        private const string Propertyreadable = "readable";
        private const string PropertyreadableSpecified = "readableSpecified";
        private const string FieldeditableField = "editableField";
        private const string FieldfieldField = "fieldField";
        private const string FieldreadableField = "readableField";
        private const string FieldreadableFieldSpecified = "readableFieldSpecified";
        private Type _permissionSetFieldPermissionsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PermissionSetFieldPermissions _permissionSetFieldPermissionsInstance;
        private PermissionSetFieldPermissions _permissionSetFieldPermissionsInstanceFixture;

        #region General Initializer : Class (PermissionSetFieldPermissions) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PermissionSetFieldPermissions" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _permissionSetFieldPermissionsInstanceType = typeof(PermissionSetFieldPermissions);
            _permissionSetFieldPermissionsInstanceFixture = Create(true);
            _permissionSetFieldPermissionsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PermissionSetFieldPermissions)

        #region General Initializer : Class (PermissionSetFieldPermissions) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="PermissionSetFieldPermissions" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyeditable)]
        [TestCase(Propertyfield)]
        [TestCase(Propertyreadable)]
        [TestCase(PropertyreadableSpecified)]
        public void AUT_PermissionSetFieldPermissions_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_permissionSetFieldPermissionsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PermissionSetFieldPermissions) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PermissionSetFieldPermissions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldeditableField)]
        [TestCase(FieldfieldField)]
        [TestCase(FieldreadableField)]
        [TestCase(FieldreadableFieldSpecified)]
        public void AUT_PermissionSetFieldPermissions_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_permissionSetFieldPermissionsInstanceFixture, 
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
        ///     Class (<see cref="PermissionSetFieldPermissions" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_PermissionSetFieldPermissions_Is_Instance_Present_Test()
        {
            // Assert
            _permissionSetFieldPermissionsInstanceType.ShouldNotBeNull();
            _permissionSetFieldPermissionsInstance.ShouldNotBeNull();
            _permissionSetFieldPermissionsInstanceFixture.ShouldNotBeNull();
            _permissionSetFieldPermissionsInstance.ShouldBeAssignableTo<PermissionSetFieldPermissions>();
            _permissionSetFieldPermissionsInstanceFixture.ShouldBeAssignableTo<PermissionSetFieldPermissions>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PermissionSetFieldPermissions) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_PermissionSetFieldPermissions_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PermissionSetFieldPermissions instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _permissionSetFieldPermissionsInstanceType.ShouldNotBeNull();
            _permissionSetFieldPermissionsInstance.ShouldNotBeNull();
            _permissionSetFieldPermissionsInstanceFixture.ShouldNotBeNull();
            _permissionSetFieldPermissionsInstance.ShouldBeAssignableTo<PermissionSetFieldPermissions>();
            _permissionSetFieldPermissionsInstanceFixture.ShouldBeAssignableTo<PermissionSetFieldPermissions>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (PermissionSetFieldPermissions) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , Propertyeditable)]
        [TestCaseGeneric(typeof(string) , Propertyfield)]
        [TestCaseGeneric(typeof(bool) , Propertyreadable)]
        [TestCaseGeneric(typeof(bool) , PropertyreadableSpecified)]
        public void AUT_PermissionSetFieldPermissions_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<PermissionSetFieldPermissions, T>(_permissionSetFieldPermissionsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSetFieldPermissions) => Property (editable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSetFieldPermissions_Public_Class_editable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyeditable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSetFieldPermissions) => Property (field) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSetFieldPermissions_Public_Class_field_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyfield);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSetFieldPermissions) => Property (readable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSetFieldPermissions_Public_Class_readable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyreadable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSetFieldPermissions) => Property (readableSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSetFieldPermissions_Public_Class_readableSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyreadableSpecified);

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