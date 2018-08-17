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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ProfileObjectPermissions" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ProfileObjectPermissionsTest : AbstractBaseSetupTypedTest<ProfileObjectPermissions>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ProfileObjectPermissions) Initializer

        private const string PropertyallowCreate = "allowCreate";
        private const string PropertyallowCreateSpecified = "allowCreateSpecified";
        private const string PropertyallowDelete = "allowDelete";
        private const string PropertyallowDeleteSpecified = "allowDeleteSpecified";
        private const string PropertyallowEdit = "allowEdit";
        private const string PropertyallowEditSpecified = "allowEditSpecified";
        private const string PropertyallowRead = "allowRead";
        private const string PropertyallowReadSpecified = "allowReadSpecified";
        private const string PropertymodifyAllRecords = "modifyAllRecords";
        private const string PropertymodifyAllRecordsSpecified = "modifyAllRecordsSpecified";
        private const string PropertyviewAllRecords = "viewAllRecords";
        private const string PropertyviewAllRecordsSpecified = "viewAllRecordsSpecified";
        private const string FieldallowCreateField = "allowCreateField";
        private const string FieldallowCreateFieldSpecified = "allowCreateFieldSpecified";
        private const string FieldallowDeleteField = "allowDeleteField";
        private const string FieldallowDeleteFieldSpecified = "allowDeleteFieldSpecified";
        private const string FieldallowEditField = "allowEditField";
        private const string FieldallowEditFieldSpecified = "allowEditFieldSpecified";
        private const string FieldallowReadField = "allowReadField";
        private const string FieldallowReadFieldSpecified = "allowReadFieldSpecified";
        private const string FieldmodifyAllRecordsField = "modifyAllRecordsField";
        private const string FieldmodifyAllRecordsFieldSpecified = "modifyAllRecordsFieldSpecified";
        private const string FieldobjectField = "objectField";
        private const string FieldviewAllRecordsField = "viewAllRecordsField";
        private const string FieldviewAllRecordsFieldSpecified = "viewAllRecordsFieldSpecified";
        private Type _profileObjectPermissionsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ProfileObjectPermissions _profileObjectPermissionsInstance;
        private ProfileObjectPermissions _profileObjectPermissionsInstanceFixture;

        #region General Initializer : Class (ProfileObjectPermissions) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ProfileObjectPermissions" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _profileObjectPermissionsInstanceType = typeof(ProfileObjectPermissions);
            _profileObjectPermissionsInstanceFixture = Create(true);
            _profileObjectPermissionsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ProfileObjectPermissions)

        #region General Initializer : Class (ProfileObjectPermissions) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ProfileObjectPermissions" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyallowCreate)]
        [TestCase(PropertyallowCreateSpecified)]
        [TestCase(PropertyallowDelete)]
        [TestCase(PropertyallowDeleteSpecified)]
        [TestCase(PropertyallowEdit)]
        [TestCase(PropertyallowEditSpecified)]
        [TestCase(PropertyallowRead)]
        [TestCase(PropertyallowReadSpecified)]
        [TestCase(PropertymodifyAllRecords)]
        [TestCase(PropertymodifyAllRecordsSpecified)]
        [TestCase(PropertyviewAllRecords)]
        [TestCase(PropertyviewAllRecordsSpecified)]
        public void AUT_ProfileObjectPermissions_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_profileObjectPermissionsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ProfileObjectPermissions) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ProfileObjectPermissions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldallowCreateField)]
        [TestCase(FieldallowCreateFieldSpecified)]
        [TestCase(FieldallowDeleteField)]
        [TestCase(FieldallowDeleteFieldSpecified)]
        [TestCase(FieldallowEditField)]
        [TestCase(FieldallowEditFieldSpecified)]
        [TestCase(FieldallowReadField)]
        [TestCase(FieldallowReadFieldSpecified)]
        [TestCase(FieldmodifyAllRecordsField)]
        [TestCase(FieldmodifyAllRecordsFieldSpecified)]
        [TestCase(FieldobjectField)]
        [TestCase(FieldviewAllRecordsField)]
        [TestCase(FieldviewAllRecordsFieldSpecified)]
        public void AUT_ProfileObjectPermissions_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_profileObjectPermissionsInstanceFixture, 
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
        ///     Class (<see cref="ProfileObjectPermissions" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ProfileObjectPermissions_Is_Instance_Present_Test()
        {
            // Assert
            _profileObjectPermissionsInstanceType.ShouldNotBeNull();
            _profileObjectPermissionsInstance.ShouldNotBeNull();
            _profileObjectPermissionsInstanceFixture.ShouldNotBeNull();
            _profileObjectPermissionsInstance.ShouldBeAssignableTo<ProfileObjectPermissions>();
            _profileObjectPermissionsInstanceFixture.ShouldBeAssignableTo<ProfileObjectPermissions>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ProfileObjectPermissions) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ProfileObjectPermissions_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ProfileObjectPermissions instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _profileObjectPermissionsInstanceType.ShouldNotBeNull();
            _profileObjectPermissionsInstance.ShouldNotBeNull();
            _profileObjectPermissionsInstanceFixture.ShouldNotBeNull();
            _profileObjectPermissionsInstance.ShouldBeAssignableTo<ProfileObjectPermissions>();
            _profileObjectPermissionsInstanceFixture.ShouldBeAssignableTo<ProfileObjectPermissions>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ProfileObjectPermissions) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyallowCreate)]
        [TestCaseGeneric(typeof(bool) , PropertyallowCreateSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyallowDelete)]
        [TestCaseGeneric(typeof(bool) , PropertyallowDeleteSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyallowEdit)]
        [TestCaseGeneric(typeof(bool) , PropertyallowEditSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyallowRead)]
        [TestCaseGeneric(typeof(bool) , PropertyallowReadSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertymodifyAllRecords)]
        [TestCaseGeneric(typeof(bool) , PropertymodifyAllRecordsSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyviewAllRecords)]
        [TestCaseGeneric(typeof(bool) , PropertyviewAllRecordsSpecified)]
        public void AUT_ProfileObjectPermissions_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ProfileObjectPermissions, T>(_profileObjectPermissionsInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (ProfileObjectPermissions) => Property (allowCreate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileObjectPermissions_Public_Class_allowCreate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ProfileObjectPermissions) => Property (allowCreateSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileObjectPermissions_Public_Class_allowCreateSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyallowCreateSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProfileObjectPermissions) => Property (allowDelete) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileObjectPermissions_Public_Class_allowDelete_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ProfileObjectPermissions) => Property (allowDeleteSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileObjectPermissions_Public_Class_allowDeleteSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyallowDeleteSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProfileObjectPermissions) => Property (allowEdit) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileObjectPermissions_Public_Class_allowEdit_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ProfileObjectPermissions) => Property (allowEditSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileObjectPermissions_Public_Class_allowEditSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyallowEditSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProfileObjectPermissions) => Property (allowRead) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileObjectPermissions_Public_Class_allowRead_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ProfileObjectPermissions) => Property (allowReadSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileObjectPermissions_Public_Class_allowReadSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyallowReadSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProfileObjectPermissions) => Property (modifyAllRecords) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileObjectPermissions_Public_Class_modifyAllRecords_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ProfileObjectPermissions) => Property (modifyAllRecordsSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileObjectPermissions_Public_Class_modifyAllRecordsSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymodifyAllRecordsSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProfileObjectPermissions) => Property (viewAllRecords) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileObjectPermissions_Public_Class_viewAllRecords_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ProfileObjectPermissions) => Property (viewAllRecordsSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileObjectPermissions_Public_Class_viewAllRecordsSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyviewAllRecordsSpecified);

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