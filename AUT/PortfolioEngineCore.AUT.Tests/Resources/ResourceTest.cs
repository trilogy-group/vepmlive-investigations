using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using PortfolioEngineCore.Infrastructure.Fields;
using Should = Shouldly.Should;
using Shouldly;

namespace PortfolioEngineCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.Resource" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ResourceTest : AbstractBaseSetupTypedTest<Resource>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Resource) Initializer

        private const string PropertyAvailableFrom = "AvailableFrom";
        private const string PropertyAvailableTo = "AvailableTo";
        private const string PropertyCanLogin = "CanLogin";
        private const string PropertyCostCategoryRoleId = "CostCategoryRoleId";
        private const string PropertyCustomFields = "CustomFields";
        private const string PropertyEmail = "Email";
        private const string PropertyExternalUId = "ExternalUId";
        private const string PropertyHolidaysListId = "HolidaysListId";
        private const string PropertyHolidaysListName = "HolidaysListName";
        private const string PropertyId = "Id";
        private const string PropertyInActive = "InActive";
        private const string PropertyIsGeneric = "IsGeneric";
        private const string PropertyIsResource = "IsResource";
        private const string PropertyName = "Name";
        private const string PropertyNotes = "Notes";
        private const string PropertyNTAccount = "NTAccount";
        private const string PropertyPassword = "Password";
        private const string PropertyPermissions = "Permissions";
        private const string PropertyPermissionsDictionary = "PermissionsDictionary";
        private const string PropertyRateId = "RateId";
        private const string PropertyRPDepartment = "RPDepartment";
        private const string PropertyTimesheetListId = "TimesheetListId";
        private const string PropertyTimesheetListName = "TimesheetListName";
        private const string PropertyTrace = "Trace";
        private const string PropertyTSDepartment = "TSDepartment";
        private const string PropertyUseNTLogin = "UseNTLogin";
        private const string PropertyWorkingHoursListId = "WorkingHoursListId";
        private const string PropertyWorkingHoursListName = "WorkingHoursListName";
        private const string MethodValidate = "Validate";
        private const string FieldEmailRegExPattern = "EmailRegExPattern";
        private Type _resourceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Resource _resourceInstance;
        private Resource _resourceInstanceFixture;

        #region General Initializer : Class (Resource) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Resource" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _resourceInstanceType = typeof(Resource);
            _resourceInstanceFixture = Create(true);
            _resourceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Resource)

        #region General Initializer : Class (Resource) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Resource" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodValidate, 0)]
        public void AUT_Resource_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_resourceInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Resource) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Resource" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyAvailableFrom)]
        [TestCase(PropertyAvailableTo)]
        [TestCase(PropertyCanLogin)]
        [TestCase(PropertyCostCategoryRoleId)]
        [TestCase(PropertyCustomFields)]
        [TestCase(PropertyEmail)]
        [TestCase(PropertyExternalUId)]
        [TestCase(PropertyHolidaysListId)]
        [TestCase(PropertyHolidaysListName)]
        [TestCase(PropertyId)]
        [TestCase(PropertyInActive)]
        [TestCase(PropertyIsGeneric)]
        [TestCase(PropertyIsResource)]
        [TestCase(PropertyName)]
        [TestCase(PropertyNotes)]
        [TestCase(PropertyNTAccount)]
        [TestCase(PropertyPassword)]
        [TestCase(PropertyPermissions)]
        [TestCase(PropertyPermissionsDictionary)]
        [TestCase(PropertyRateId)]
        [TestCase(PropertyRPDepartment)]
        [TestCase(PropertyTimesheetListId)]
        [TestCase(PropertyTimesheetListName)]
        [TestCase(PropertyTrace)]
        [TestCase(PropertyTSDepartment)]
        [TestCase(PropertyUseNTLogin)]
        [TestCase(PropertyWorkingHoursListId)]
        [TestCase(PropertyWorkingHoursListName)]
        public void AUT_Resource_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_resourceInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Resource) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Resource" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldEmailRegExPattern)]
        public void AUT_Resource_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_resourceInstanceFixture, 
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
        ///     Class (<see cref="Resource" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Resource_Is_Instance_Present_Test()
        {
            // Assert
            _resourceInstanceType.ShouldNotBeNull();
            _resourceInstance.ShouldNotBeNull();
            _resourceInstanceFixture.ShouldNotBeNull();
            _resourceInstance.ShouldBeAssignableTo<Resource>();
            _resourceInstanceFixture.ShouldBeAssignableTo<Resource>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Resource) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Resource_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Resource instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _resourceInstanceType.ShouldNotBeNull();
            _resourceInstance.ShouldNotBeNull();
            _resourceInstanceFixture.ShouldNotBeNull();
            _resourceInstance.ShouldBeAssignableTo<Resource>();
            _resourceInstanceFixture.ShouldBeAssignableTo<Resource>();
        }

        #endregion

        #region General Constructor : Class (Resource) Default Assignment Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Resource_Constructor_Instantiated_With_Default_Assignments_Test()
        {

            // Act
            var resourceInstance  = new Resource();

            // Asserts
            resourceInstance.ShouldNotBeNull();
            resourceInstance.ShouldBeAssignableTo<Resource>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Resource) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(DateTime?) , PropertyAvailableFrom)]
        [TestCaseGeneric(typeof(DateTime?) , PropertyAvailableTo)]
        [TestCaseGeneric(typeof(byte?) , PropertyCanLogin)]
        [TestCaseGeneric(typeof(int?) , PropertyCostCategoryRoleId)]
        [TestCaseGeneric(typeof(ICollection<IField>) , PropertyCustomFields)]
        [TestCaseGeneric(typeof(string) , PropertyEmail)]
        [TestCaseGeneric(typeof(string) , PropertyExternalUId)]
        [TestCaseGeneric(typeof(int?) , PropertyHolidaysListId)]
        [TestCaseGeneric(typeof(string) , PropertyHolidaysListName)]
        [TestCaseGeneric(typeof(int) , PropertyId)]
        [TestCaseGeneric(typeof(byte?) , PropertyInActive)]
        [TestCaseGeneric(typeof(byte?) , PropertyIsGeneric)]
        [TestCaseGeneric(typeof(byte?) , PropertyIsResource)]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        [TestCaseGeneric(typeof(string) , PropertyNotes)]
        [TestCaseGeneric(typeof(string) , PropertyNTAccount)]
        [TestCaseGeneric(typeof(string) , PropertyPassword)]
        [TestCaseGeneric(typeof(string) , PropertyPermissions)]
        [TestCaseGeneric(typeof(Dictionary<int, string>) , PropertyPermissionsDictionary)]
        [TestCaseGeneric(typeof(int?) , PropertyRateId)]
        [TestCaseGeneric(typeof(int?) , PropertyRPDepartment)]
        [TestCaseGeneric(typeof(int?) , PropertyTimesheetListId)]
        [TestCaseGeneric(typeof(string) , PropertyTimesheetListName)]
        [TestCaseGeneric(typeof(int?) , PropertyTrace)]
        [TestCaseGeneric(typeof(int?) , PropertyTSDepartment)]
        [TestCaseGeneric(typeof(byte?) , PropertyUseNTLogin)]
        [TestCaseGeneric(typeof(int?) , PropertyWorkingHoursListId)]
        [TestCaseGeneric(typeof(string) , PropertyWorkingHoursListName)]
        public void AUT_Resource_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Resource, T>(_resourceInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (AvailableFrom) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_AvailableFrom_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyAvailableFrom);
            Action currentAction = () => propertyInfo.SetValue(_resourceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (AvailableFrom) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_Public_Class_AvailableFrom_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyAvailableFrom);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (AvailableTo) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_AvailableTo_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyAvailableTo);
            Action currentAction = () => propertyInfo.SetValue(_resourceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (AvailableTo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_Public_Class_AvailableTo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyAvailableTo);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (CanLogin) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_CanLogin_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyCanLogin);
            Action currentAction = () => propertyInfo.SetValue(_resourceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (CanLogin) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_Public_Class_CanLogin_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCanLogin);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (CostCategoryRoleId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_Public_Class_CostCategoryRoleId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCostCategoryRoleId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (CustomFields) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_Public_Class_CustomFields_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCustomFields);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (Email) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_Public_Class_Email_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyEmail);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (ExternalUId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_Public_Class_ExternalUId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyExternalUId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (HolidaysListId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_Public_Class_HolidaysListId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyHolidaysListId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (HolidaysListName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_Public_Class_HolidaysListName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyHolidaysListName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (Id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_Public_Class_Id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Resource) => Property (InActive) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_InActive_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyInActive);
            Action currentAction = () => propertyInfo.SetValue(_resourceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (InActive) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_Public_Class_InActive_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyInActive);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (IsGeneric) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_IsGeneric_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyIsGeneric);
            Action currentAction = () => propertyInfo.SetValue(_resourceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (IsGeneric) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_Public_Class_IsGeneric_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyIsGeneric);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (IsResource) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_IsResource_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyIsResource);
            Action currentAction = () => propertyInfo.SetValue(_resourceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (IsResource) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_Public_Class_IsResource_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyIsResource);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (Notes) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_Public_Class_Notes_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyNotes);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (NTAccount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_Public_Class_NTAccount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyNTAccount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (Password) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_Public_Class_Password_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPassword);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (Permissions) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_Public_Class_Permissions_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPermissions);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (PermissionsDictionary) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_Public_Class_PermissionsDictionary_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPermissionsDictionary);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (RateId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_Public_Class_RateId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyRateId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (RPDepartment) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_Public_Class_RPDepartment_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyRPDepartment);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (TimesheetListId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_Public_Class_TimesheetListId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyTimesheetListId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (TimesheetListName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_Public_Class_TimesheetListName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyTimesheetListName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (Trace) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_Public_Class_Trace_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyTrace);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (TSDepartment) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_Public_Class_TSDepartment_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyTSDepartment);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (UseNTLogin) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_UseNTLogin_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyUseNTLogin);
            Action currentAction = () => propertyInfo.SetValue(_resourceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (UseNTLogin) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_Public_Class_UseNTLogin_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUseNTLogin);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (WorkingHoursListId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_Public_Class_WorkingHoursListId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWorkingHoursListId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Resource) => Property (WorkingHoursListName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Resource_Public_Class_WorkingHoursListName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWorkingHoursListName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Resource" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodValidate)]
        public void AUT_Resource_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Resource>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Validate) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Resource_Validate_Method_Call_Internally(Type[] types)
        {
            var methodValidatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceInstance, MethodValidate, Fixture, methodValidatePrametersTypes);
        }

        #endregion

        #region Method Call : (Validate) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resource_Validate_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var errorMessages = CreateType<IList<string>>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourceInstance.Validate(out errorMessages);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Validate) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resource_Validate_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var errorMessages = CreateType<IList<string>>();
            var methodValidatePrametersTypes = new Type[] { typeof(IList<string>) };
            object[] parametersOfValidate = { errorMessages };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodValidate, methodValidatePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Resource, bool>(_resourceInstanceFixture, out exception1, parametersOfValidate);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Resource, bool>(_resourceInstance, MethodValidate, parametersOfValidate, methodValidatePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfValidate.ShouldNotBeNull();
            parametersOfValidate.Length.ShouldBe(1);
            methodValidatePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Validate) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resource_Validate_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var errorMessages = CreateType<IList<string>>();
            var methodValidatePrametersTypes = new Type[] { typeof(IList<string>) };
            object[] parametersOfValidate = { errorMessages };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodValidate, methodValidatePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Resource, bool>(_resourceInstanceFixture, out exception1, parametersOfValidate);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Resource, bool>(_resourceInstance, MethodValidate, parametersOfValidate, methodValidatePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfValidate.ShouldNotBeNull();
            parametersOfValidate.Length.ShouldBe(1);
            methodValidatePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Validate) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resource_Validate_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var errorMessages = CreateType<IList<string>>();
            var methodValidatePrametersTypes = new Type[] { typeof(IList<string>) };
            object[] parametersOfValidate = { errorMessages };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodValidate, methodValidatePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceInstanceFixture, parametersOfValidate);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfValidate.ShouldNotBeNull();
            parametersOfValidate.Length.ShouldBe(1);
            methodValidatePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Validate) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resource_Validate_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var errorMessages = CreateType<IList<string>>();
            var methodValidatePrametersTypes = new Type[] { typeof(IList<string>) };
            object[] parametersOfValidate = { errorMessages };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Resource, bool>(_resourceInstance, MethodValidate, parametersOfValidate, methodValidatePrametersTypes);

            // Assert
            parametersOfValidate.ShouldNotBeNull();
            parametersOfValidate.Length.ShouldBe(1);
            methodValidatePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Validate) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resource_Validate_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodValidatePrametersTypes = new Type[] { typeof(IList<string>) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceInstance, MethodValidate, Fixture, methodValidatePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodValidatePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Validate) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resource_Validate_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodValidate, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Validate) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Resource_Validate_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodValidate, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #endregion

        #endregion
    }
}