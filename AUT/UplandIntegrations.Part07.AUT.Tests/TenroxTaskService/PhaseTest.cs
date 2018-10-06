using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.BaseSetup.Version.V2;
using AUT.ConfigureTestProjects.BaseSetup.Version.V3;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.Model;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using UplandIntegrations.TenroxTaskService;
using Phase = UplandIntegrations.TenroxTaskService;

namespace UplandIntegrations.TenroxTaskService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxTaskService.Phase" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxTaskService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class PhaseTest : AbstractBaseSetupV3Test
    {
        public PhaseTest() : base(typeof(Phase))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Overrides of IAbstractBaseSetupV2Test

        /// <summary>
        ///    Configure and ignore problematic tests.
        ///    Added tests will be ignored.
        /// </summary>
        public override void ConfigureIgnoringTests()
        {
            base.ConfigureIgnoringTests();
        }

        #endregion

        #region General Initializer : Class (Phase) Initializer

        #region Properties

        private const string PropertyExtensionData = "ExtensionData";
        private const string PropertyAccessType = "AccessType";
        private const string PropertyBillable = "Billable";
        private const string PropertyCosted = "Costed";
        private const string PropertyCustom = "Custom";
        private const string PropertyDescription = "Description";
        private const string PropertyFunded = "Funded";
        private const string PropertyHierarchyCode = "HierarchyCode";
        private const string PropertyId = "Id";
        private const string PropertyIsPlaceholder = "IsPlaceholder";
        private const string PropertyName = "Name";
        private const string PropertyOverrideBillable = "OverrideBillable";
        private const string PropertyOverrideCosted = "OverrideCosted";
        private const string PropertyOverrideCustom = "OverrideCustom";
        private const string PropertyOverrideFunded = "OverrideFunded";
        private const string PropertyOverrideRandD = "OverrideRandD";
        private const string PropertyParentId = "ParentId";
        private const string PropertyRandD = "RandD";
        private const string PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey";
        private const string PropertyTimeEntry = "TimeEntry";
        private const string PropertyUniqueId = "UniqueId";

        #endregion

        #region Methods

        private const string MethodRaisePropertyChanged = "RaisePropertyChanged";

        #endregion

        #region Fields

        private const string FieldextensionDataField = "extensionDataField";
        private const string FieldAccessTypeField = "AccessTypeField";
        private const string FieldBillableField = "BillableField";
        private const string FieldCostedField = "CostedField";
        private const string FieldCustomField = "CustomField";
        private const string FieldDescriptionField = "DescriptionField";
        private const string FieldFundedField = "FundedField";
        private const string FieldHierarchyCodeField = "HierarchyCodeField";
        private const string FieldIdField = "IdField";
        private const string FieldIsPlaceholderField = "IsPlaceholderField";
        private const string FieldNameField = "NameField";
        private const string FieldOverrideBillableField = "OverrideBillableField";
        private const string FieldOverrideCostedField = "OverrideCostedField";
        private const string FieldOverrideCustomField = "OverrideCustomField";
        private const string FieldOverrideFundedField = "OverrideFundedField";
        private const string FieldOverrideRandDField = "OverrideRandDField";
        private const string FieldParentIdField = "ParentIdField";
        private const string FieldRandDField = "RandDField";
        private const string FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField = "SystemDataObjectsDataClassesIEntityWithKeyEntityKeyField";
        private const string FieldTimeEntryField = "TimeEntryField";
        private const string FieldUniqueIdField = "UniqueIdField";

        #endregion

        private Type _phaseInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private Phase _phaseInstance;
        private Phase _phaseInstanceFixture;

        #region General Initializer : Class (Phase) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Phase" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _phaseInstanceType = typeof(Phase);
            _phaseInstanceFixture = this.Create<Phase>(true);
            _phaseInstance = _phaseInstanceFixture ?? this.Create<Phase>(false);
            CurrentInstance = _phaseInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Phase)

        #region General Initializer : Class (Phase) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Phase" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRaisePropertyChanged, 0)]
        public void AUT_Phase_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_phaseInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Phase) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Phase" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyExtensionData)]
        [TestCase(PropertyAccessType)]
        [TestCase(PropertyBillable)]
        [TestCase(PropertyCosted)]
        [TestCase(PropertyCustom)]
        [TestCase(PropertyDescription)]
        [TestCase(PropertyFunded)]
        [TestCase(PropertyHierarchyCode)]
        [TestCase(PropertyId)]
        [TestCase(PropertyIsPlaceholder)]
        [TestCase(PropertyName)]
        [TestCase(PropertyOverrideBillable)]
        [TestCase(PropertyOverrideCosted)]
        [TestCase(PropertyOverrideCustom)]
        [TestCase(PropertyOverrideFunded)]
        [TestCase(PropertyOverrideRandD)]
        [TestCase(PropertyParentId)]
        [TestCase(PropertyRandD)]
        [TestCase(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCase(PropertyTimeEntry)]
        [TestCase(PropertyUniqueId)]
        public void AUT_Phase_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var propertyInfo = this.GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_phaseInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Phase) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Phase" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldextensionDataField)]
        [TestCase(FieldAccessTypeField)]
        [TestCase(FieldBillableField)]
        [TestCase(FieldCostedField)]
        [TestCase(FieldCustomField)]
        [TestCase(FieldDescriptionField)]
        [TestCase(FieldFundedField)]
        [TestCase(FieldHierarchyCodeField)]
        [TestCase(FieldIdField)]
        [TestCase(FieldIsPlaceholderField)]
        [TestCase(FieldNameField)]
        [TestCase(FieldOverrideBillableField)]
        [TestCase(FieldOverrideCostedField)]
        [TestCase(FieldOverrideCustomField)]
        [TestCase(FieldOverrideFundedField)]
        [TestCase(FieldOverrideRandDField)]
        [TestCase(FieldParentIdField)]
        [TestCase(FieldRandDField)]
        [TestCase(FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField)]
        [TestCase(FieldTimeEntryField)]
        [TestCase(FieldUniqueIdField)]
        public void AUT_Phase_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_phaseInstanceFixture, 
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
        ///     Class (<see cref="Phase" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Phase_Is_Instance_Present_Test()
        {
            // Assert
            _phaseInstanceType.ShouldNotBeNull();
            _phaseInstance.ShouldNotBeNull();
            _phaseInstanceFixture.ShouldNotBeNull();
            _phaseInstance.ShouldBeAssignableTo<Phase>();
            _phaseInstanceFixture.ShouldBeAssignableTo<Phase>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Phase) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Phase_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Phase instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _phaseInstanceType.ShouldNotBeNull();
            _phaseInstance.ShouldNotBeNull();
            _phaseInstanceFixture.ShouldNotBeNull();
            _phaseInstance.ShouldBeAssignableTo<Phase>();
            _phaseInstanceFixture.ShouldBeAssignableTo<Phase>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Phase) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(System.Runtime.Serialization.ExtensionDataObject) , PropertyExtensionData)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyAccessType)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyBillable)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyCosted)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyCustom)]
        [TestCaseGeneric(typeof(string) , PropertyDescription)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyFunded)]
        [TestCaseGeneric(typeof(string) , PropertyHierarchyCode)]
        [TestCaseGeneric(typeof(string) , PropertyId)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsPlaceholder)]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyOverrideBillable)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyOverrideCosted)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyOverrideCustom)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyOverrideFunded)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyOverrideRandD)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyParentId)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyRandD)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxTaskService.EntityKey) , PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxTaskService.TimeEntry[]) , PropertyTimeEntry)]
        [TestCaseGeneric(typeof(int) , PropertyUniqueId)]
        public void AUT_Phase_Property_Type_Verify_Explore_By_Name_Test<T>(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);

            // Assert
            ShouldlyExtension.PropertyTypeVerify<Phase, T>(_phaseInstance, name, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Phase) => Property (AccessType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Phase_Public_Class_AccessType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAccessType);
            var propertyInfo  = this.GetPropertyInfo(PropertyAccessType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Phase) => Property (Billable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Phase_Public_Class_Billable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBillable);
            var propertyInfo  = this.GetPropertyInfo(PropertyBillable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Phase) => Property (Costed) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Phase_Public_Class_Costed_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCosted);
            var propertyInfo  = this.GetPropertyInfo(PropertyCosted);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Phase) => Property (Custom) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Phase_Public_Class_Custom_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCustom);
            var propertyInfo  = this.GetPropertyInfo(PropertyCustom);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Phase) => Property (Description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Phase_Public_Class_Description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDescription);
            var propertyInfo  = this.GetPropertyInfo(PropertyDescription);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Phase) => Property (ExtensionData) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Phase_ExtensionData_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExtensionData);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExtensionData);
            Action currentAction = () => propertyInfo.SetValue(_phaseInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Phase) => Property (ExtensionData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Phase_Public_Class_ExtensionData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExtensionData);
            var propertyInfo  = this.GetPropertyInfo(PropertyExtensionData);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Phase) => Property (Funded) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Phase_Public_Class_Funded_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyFunded);
            var propertyInfo  = this.GetPropertyInfo(PropertyFunded);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Phase) => Property (HierarchyCode) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Phase_Public_Class_HierarchyCode_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyHierarchyCode);
            var propertyInfo  = this.GetPropertyInfo(PropertyHierarchyCode);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Phase) => Property (Id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Phase_Public_Class_Id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyId);
            var propertyInfo  = this.GetPropertyInfo(PropertyId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Phase) => Property (IsPlaceholder) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Phase_Public_Class_IsPlaceholder_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsPlaceholder);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsPlaceholder);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Phase) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Phase_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyName);
            var propertyInfo  = this.GetPropertyInfo(PropertyName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Phase) => Property (OverrideBillable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Phase_Public_Class_OverrideBillable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyOverrideBillable);
            var propertyInfo  = this.GetPropertyInfo(PropertyOverrideBillable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Phase) => Property (OverrideCosted) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Phase_Public_Class_OverrideCosted_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyOverrideCosted);
            var propertyInfo  = this.GetPropertyInfo(PropertyOverrideCosted);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Phase) => Property (OverrideCustom) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Phase_Public_Class_OverrideCustom_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyOverrideCustom);
            var propertyInfo  = this.GetPropertyInfo(PropertyOverrideCustom);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Phase) => Property (OverrideFunded) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Phase_Public_Class_OverrideFunded_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyOverrideFunded);
            var propertyInfo  = this.GetPropertyInfo(PropertyOverrideFunded);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Phase) => Property (OverrideRandD) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Phase_Public_Class_OverrideRandD_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyOverrideRandD);
            var propertyInfo  = this.GetPropertyInfo(PropertyOverrideRandD);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Phase) => Property (ParentId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Phase_Public_Class_ParentId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyParentId);
            var propertyInfo  = this.GetPropertyInfo(PropertyParentId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Phase) => Property (RandD) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Phase_Public_Class_RandD_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRandD);
            var propertyInfo  = this.GetPropertyInfo(PropertyRandD);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Phase) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Phase_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            Action currentAction = () => propertyInfo.SetValue(_phaseInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Phase) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Phase_Public_Class_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            var propertyInfo  = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Phase) => Property (TimeEntry) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Phase_TimeEntry_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimeEntry);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTimeEntry);
            Action currentAction = () => propertyInfo.SetValue(_phaseInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Phase) => Property (TimeEntry) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Phase_Public_Class_TimeEntry_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimeEntry);
            var propertyInfo  = this.GetPropertyInfo(PropertyTimeEntry);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Phase) => Property (UniqueId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Phase_Public_Class_UniqueId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUniqueId);
            var propertyInfo  = this.GetPropertyInfo(PropertyUniqueId);

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

        #region Method Call : (RaisePropertyChanged) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Phase_RaisePropertyChanged_Method_Call_Internally(Type[] types)
        {
            var methodRaisePropertyChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_phaseInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Phase_RaisePropertyChanged_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_phaseInstanceFixture, parametersOfRaisePropertyChanged);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRaisePropertyChanged.ShouldNotBeNull();
            parametersOfRaisePropertyChanged.Length.ShouldBe(1);
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(parametersOfRaisePropertyChanged.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Phase_RaisePropertyChanged_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_phaseInstance, MethodRaisePropertyChanged, parametersOfRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes);

            // Assert
            parametersOfRaisePropertyChanged.ShouldNotBeNull();
            parametersOfRaisePropertyChanged.Length.ShouldBe(1);
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(parametersOfRaisePropertyChanged.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Phase_RaisePropertyChanged_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Phase_RaisePropertyChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_phaseInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);

            // Assert
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Phase_RaisePropertyChanged_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_phaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}