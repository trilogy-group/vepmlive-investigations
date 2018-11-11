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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.PermissionSetObjectPermissions" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class PermissionSetObjectPermissionsTest : AbstractBaseSetupTypedTest<PermissionSetObjectPermissions>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PermissionSetObjectPermissions) Initializer

        private const string PropertyallowCreate = "allowCreate";
        private const string PropertyallowDelete = "allowDelete";
        private const string PropertyallowEdit = "allowEdit";
        private const string PropertyallowRead = "allowRead";
        private const string PropertymodifyAllRecords = "modifyAllRecords";
        private const string PropertyviewAllRecords = "viewAllRecords";
        private const string FieldallowCreateField = "allowCreateField";
        private const string FieldallowDeleteField = "allowDeleteField";
        private const string FieldallowEditField = "allowEditField";
        private const string FieldallowReadField = "allowReadField";
        private const string FieldmodifyAllRecordsField = "modifyAllRecordsField";
        private const string FieldobjectField = "objectField";
        private const string FieldviewAllRecordsField = "viewAllRecordsField";
        private Type _permissionSetObjectPermissionsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PermissionSetObjectPermissions _permissionSetObjectPermissionsInstance;
        private PermissionSetObjectPermissions _permissionSetObjectPermissionsInstanceFixture;

        #region General Initializer : Class (PermissionSetObjectPermissions) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PermissionSetObjectPermissions" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _permissionSetObjectPermissionsInstanceType = typeof(PermissionSetObjectPermissions);
            _permissionSetObjectPermissionsInstanceFixture = Create(true);
            _permissionSetObjectPermissionsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PermissionSetObjectPermissions)

        #region General Initializer : Class (PermissionSetObjectPermissions) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="PermissionSetObjectPermissions" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyallowCreate)]
        [TestCase(PropertyallowDelete)]
        [TestCase(PropertyallowEdit)]
        [TestCase(PropertyallowRead)]
        [TestCase(PropertymodifyAllRecords)]
        [TestCase(PropertyviewAllRecords)]
        public void AUT_PermissionSetObjectPermissions_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_permissionSetObjectPermissionsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PermissionSetObjectPermissions) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PermissionSetObjectPermissions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldallowCreateField)]
        [TestCase(FieldallowDeleteField)]
        [TestCase(FieldallowEditField)]
        [TestCase(FieldallowReadField)]
        [TestCase(FieldmodifyAllRecordsField)]
        [TestCase(FieldobjectField)]
        [TestCase(FieldviewAllRecordsField)]
        public void AUT_PermissionSetObjectPermissions_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_permissionSetObjectPermissionsInstanceFixture, 
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
        ///     Class (<see cref="PermissionSetObjectPermissions" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_PermissionSetObjectPermissions_Is_Instance_Present_Test()
        {
            // Assert
            _permissionSetObjectPermissionsInstanceType.ShouldNotBeNull();
            _permissionSetObjectPermissionsInstance.ShouldNotBeNull();
            _permissionSetObjectPermissionsInstanceFixture.ShouldNotBeNull();
            _permissionSetObjectPermissionsInstance.ShouldBeAssignableTo<PermissionSetObjectPermissions>();
            _permissionSetObjectPermissionsInstanceFixture.ShouldBeAssignableTo<PermissionSetObjectPermissions>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PermissionSetObjectPermissions) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_PermissionSetObjectPermissions_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PermissionSetObjectPermissions instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _permissionSetObjectPermissionsInstanceType.ShouldNotBeNull();
            _permissionSetObjectPermissionsInstance.ShouldNotBeNull();
            _permissionSetObjectPermissionsInstanceFixture.ShouldNotBeNull();
            _permissionSetObjectPermissionsInstance.ShouldBeAssignableTo<PermissionSetObjectPermissions>();
            _permissionSetObjectPermissionsInstanceFixture.ShouldBeAssignableTo<PermissionSetObjectPermissions>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (PermissionSetObjectPermissions) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyallowCreate)]
        [TestCaseGeneric(typeof(bool) , PropertyallowDelete)]
        [TestCaseGeneric(typeof(bool) , PropertyallowEdit)]
        [TestCaseGeneric(typeof(bool) , PropertyallowRead)]
        [TestCaseGeneric(typeof(bool) , PropertymodifyAllRecords)]
        [TestCaseGeneric(typeof(bool) , PropertyviewAllRecords)]
        public void AUT_PermissionSetObjectPermissions_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<PermissionSetObjectPermissions, T>(_permissionSetObjectPermissionsInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (PermissionSetObjectPermissions) => Property (allowCreate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSetObjectPermissions_Public_Class_allowCreate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyallowCreate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSetObjectPermissions) => Property (allowDelete) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSetObjectPermissions_Public_Class_allowDelete_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyallowDelete);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSetObjectPermissions) => Property (allowEdit) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSetObjectPermissions_Public_Class_allowEdit_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyallowEdit);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSetObjectPermissions) => Property (allowRead) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSetObjectPermissions_Public_Class_allowRead_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyallowRead);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSetObjectPermissions) => Property (modifyAllRecords) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSetObjectPermissions_Public_Class_modifyAllRecords_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymodifyAllRecords);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSetObjectPermissions) => Property (viewAllRecords) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSetObjectPermissions_Public_Class_viewAllRecords_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyviewAllRecords);

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