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
using PayrollBatch = UplandIntegrations.TenroxTaskService;

namespace UplandIntegrations.TenroxTaskService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxTaskService.PayrollBatch" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxTaskService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class PayrollBatchTest : AbstractBaseSetupV3Test
    {
        public PayrollBatchTest() : base(typeof(PayrollBatch))
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

        #region General Initializer : Class (PayrollBatch) Initializer

        #region Properties

        private const string PropertyExtensionData = "ExtensionData";
        private const string PropertyAccconSet = "AccconSet";
        private const string PropertyAccconSetId = "AccconSetId";
        private const string PropertyAppTimeStamp = "AppTimeStamp";
        private const string PropertyBatchNo = "BatchNo";
        private const string PropertyCreatedBy = "CreatedBy";
        private const string PropertyDateFrom = "DateFrom";
        private const string PropertyDateTo = "DateTo";
        private const string PropertyExportStatus = "ExportStatus";
        private const string PropertyIncAllCharges = "IncAllCharges";
        private const string PropertyIncAllUsers = "IncAllUsers";
        private const string PropertyIncCostPerUser = "IncCostPerUser";
        private const string PropertyIncJobCosting = "IncJobCosting";
        private const string PropertyIssueDate = "IssueDate";
        private const string PropertyIssued = "Issued";
        private const string PropertyModifyTimeStamp = "ModifyTimeStamp";
        private const string PropertyProcAllUsers = "ProcAllUsers";
        private const string PropertyProcCharges = "ProcCharges";
        private const string PropertyProcTime = "ProcTime";
        private const string PropertyRegenerateCharge = "RegenerateCharge";
        private const string PropertyRegeneratePayCode = "RegeneratePayCode";
        private const string PropertyRegenerateTime = "RegenerateTime";
        private const string PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey";
        private const string PropertyTemplateId = "TemplateId";
        private const string PropertyTotAmount = "TotAmount";
        private const string PropertyTotalCharge = "TotalCharge";
        private const string PropertyTotalTime = "TotalTime";
        private const string PropertyTotalTimeCost = "TotalTimeCost";
        private const string PropertyUniqueId = "UniqueId";

        #endregion

        #region Methods

        private const string MethodRaisePropertyChanged = "RaisePropertyChanged";

        #endregion

        #region Fields

        private const string FieldextensionDataField = "extensionDataField";
        private const string FieldAccconSetField = "AccconSetField";
        private const string FieldAccconSetIdField = "AccconSetIdField";
        private const string FieldAppTimeStampField = "AppTimeStampField";
        private const string FieldBatchNoField = "BatchNoField";
        private const string FieldCreatedByField = "CreatedByField";
        private const string FieldDateFromField = "DateFromField";
        private const string FieldDateToField = "DateToField";
        private const string FieldExportStatusField = "ExportStatusField";
        private const string FieldIncAllChargesField = "IncAllChargesField";
        private const string FieldIncAllUsersField = "IncAllUsersField";
        private const string FieldIncCostPerUserField = "IncCostPerUserField";
        private const string FieldIncJobCostingField = "IncJobCostingField";
        private const string FieldIssueDateField = "IssueDateField";
        private const string FieldIssuedField = "IssuedField";
        private const string FieldModifyTimeStampField = "ModifyTimeStampField";
        private const string FieldProcAllUsersField = "ProcAllUsersField";
        private const string FieldProcChargesField = "ProcChargesField";
        private const string FieldProcTimeField = "ProcTimeField";
        private const string FieldRegenerateChargeField = "RegenerateChargeField";
        private const string FieldRegeneratePayCodeField = "RegeneratePayCodeField";
        private const string FieldRegenerateTimeField = "RegenerateTimeField";
        private const string FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField = "SystemDataObjectsDataClassesIEntityWithKeyEntityKeyField";
        private const string FieldTemplateIdField = "TemplateIdField";
        private const string FieldTotAmountField = "TotAmountField";
        private const string FieldTotalChargeField = "TotalChargeField";
        private const string FieldTotalTimeField = "TotalTimeField";
        private const string FieldTotalTimeCostField = "TotalTimeCostField";
        private const string FieldUniqueIdField = "UniqueIdField";

        #endregion

        private Type _payrollBatchInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private PayrollBatch _payrollBatchInstance;
        private PayrollBatch _payrollBatchInstanceFixture;

        #region General Initializer : Class (PayrollBatch) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PayrollBatch" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _payrollBatchInstanceType = typeof(PayrollBatch);
            _payrollBatchInstanceFixture = this.Create<PayrollBatch>(true);
            _payrollBatchInstance = _payrollBatchInstanceFixture ?? this.Create<PayrollBatch>(false);
            CurrentInstance = _payrollBatchInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PayrollBatch)

        #region General Initializer : Class (PayrollBatch) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="PayrollBatch" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRaisePropertyChanged, 0)]
        public void AUT_PayrollBatch_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_payrollBatchInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PayrollBatch) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="PayrollBatch" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyExtensionData)]
        [TestCase(PropertyAccconSet)]
        [TestCase(PropertyAccconSetId)]
        [TestCase(PropertyAppTimeStamp)]
        [TestCase(PropertyBatchNo)]
        [TestCase(PropertyCreatedBy)]
        [TestCase(PropertyDateFrom)]
        [TestCase(PropertyDateTo)]
        [TestCase(PropertyExportStatus)]
        [TestCase(PropertyIncAllCharges)]
        [TestCase(PropertyIncAllUsers)]
        [TestCase(PropertyIncCostPerUser)]
        [TestCase(PropertyIncJobCosting)]
        [TestCase(PropertyIssueDate)]
        [TestCase(PropertyIssued)]
        [TestCase(PropertyModifyTimeStamp)]
        [TestCase(PropertyProcAllUsers)]
        [TestCase(PropertyProcCharges)]
        [TestCase(PropertyProcTime)]
        [TestCase(PropertyRegenerateCharge)]
        [TestCase(PropertyRegeneratePayCode)]
        [TestCase(PropertyRegenerateTime)]
        [TestCase(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCase(PropertyTemplateId)]
        [TestCase(PropertyTotAmount)]
        [TestCase(PropertyTotalCharge)]
        [TestCase(PropertyTotalTime)]
        [TestCase(PropertyTotalTimeCost)]
        [TestCase(PropertyUniqueId)]
        public void AUT_PayrollBatch_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var propertyInfo = this.GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_payrollBatchInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PayrollBatch) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PayrollBatch" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldextensionDataField)]
        [TestCase(FieldAccconSetField)]
        [TestCase(FieldAccconSetIdField)]
        [TestCase(FieldAppTimeStampField)]
        [TestCase(FieldBatchNoField)]
        [TestCase(FieldCreatedByField)]
        [TestCase(FieldDateFromField)]
        [TestCase(FieldDateToField)]
        [TestCase(FieldExportStatusField)]
        [TestCase(FieldIncAllChargesField)]
        [TestCase(FieldIncAllUsersField)]
        [TestCase(FieldIncCostPerUserField)]
        [TestCase(FieldIncJobCostingField)]
        [TestCase(FieldIssueDateField)]
        [TestCase(FieldIssuedField)]
        [TestCase(FieldModifyTimeStampField)]
        [TestCase(FieldProcAllUsersField)]
        [TestCase(FieldProcChargesField)]
        [TestCase(FieldProcTimeField)]
        [TestCase(FieldRegenerateChargeField)]
        [TestCase(FieldRegeneratePayCodeField)]
        [TestCase(FieldRegenerateTimeField)]
        [TestCase(FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField)]
        [TestCase(FieldTemplateIdField)]
        [TestCase(FieldTotAmountField)]
        [TestCase(FieldTotalChargeField)]
        [TestCase(FieldTotalTimeField)]
        [TestCase(FieldTotalTimeCostField)]
        [TestCase(FieldUniqueIdField)]
        public void AUT_PayrollBatch_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_payrollBatchInstanceFixture, 
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
        ///     Class (<see cref="PayrollBatch" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_PayrollBatch_Is_Instance_Present_Test()
        {
            // Assert
            _payrollBatchInstanceType.ShouldNotBeNull();
            _payrollBatchInstance.ShouldNotBeNull();
            _payrollBatchInstanceFixture.ShouldNotBeNull();
            _payrollBatchInstance.ShouldBeAssignableTo<PayrollBatch>();
            _payrollBatchInstanceFixture.ShouldBeAssignableTo<PayrollBatch>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PayrollBatch) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_PayrollBatch_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PayrollBatch instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _payrollBatchInstanceType.ShouldNotBeNull();
            _payrollBatchInstance.ShouldNotBeNull();
            _payrollBatchInstanceFixture.ShouldNotBeNull();
            _payrollBatchInstance.ShouldBeAssignableTo<PayrollBatch>();
            _payrollBatchInstanceFixture.ShouldBeAssignableTo<PayrollBatch>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (PayrollBatch) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(System.Runtime.Serialization.ExtensionDataObject) , PropertyExtensionData)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxTaskService.AccountingConnection) , PropertyAccconSet)]
        [TestCaseGeneric(typeof(int) , PropertyAccconSetId)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyAppTimeStamp)]
        [TestCaseGeneric(typeof(string) , PropertyBatchNo)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyCreatedBy)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyDateFrom)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyDateTo)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyExportStatus)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIncAllCharges)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIncAllUsers)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIncCostPerUser)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIncJobCosting)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyIssueDate)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIssued)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyModifyTimeStamp)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyProcAllUsers)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyProcCharges)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyProcTime)]
        [TestCaseGeneric(typeof(byte) , PropertyRegenerateCharge)]
        [TestCaseGeneric(typeof(byte) , PropertyRegeneratePayCode)]
        [TestCaseGeneric(typeof(byte) , PropertyRegenerateTime)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxTaskService.EntityKey) , PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTemplateId)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyTotAmount)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyTotalCharge)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyTotalTime)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyTotalTimeCost)]
        [TestCaseGeneric(typeof(int) , PropertyUniqueId)]
        public void AUT_PayrollBatch_Property_Type_Verify_Explore_By_Name_Test<T>(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);

            // Assert
            ShouldlyExtension.PropertyTypeVerify<PayrollBatch, T>(_payrollBatchInstance, name, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (AccconSet) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_AccconSet_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAccconSet);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyAccconSet);
            Action currentAction = () => propertyInfo.SetValue(_payrollBatchInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (AccconSet) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_AccconSet_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAccconSet);
            var propertyInfo  = this.GetPropertyInfo(PropertyAccconSet);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (AccconSetId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_AccconSetId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAccconSetId);
            var propertyInfo  = this.GetPropertyInfo(PropertyAccconSetId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (AppTimeStamp) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_AppTimeStamp_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAppTimeStamp);
            var propertyInfo  = this.GetPropertyInfo(PropertyAppTimeStamp);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (BatchNo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_BatchNo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBatchNo);
            var propertyInfo  = this.GetPropertyInfo(PropertyBatchNo);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (CreatedBy) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_CreatedBy_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCreatedBy);
            var propertyInfo  = this.GetPropertyInfo(PropertyCreatedBy);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (DateFrom) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_DateFrom_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDateFrom);
            var propertyInfo  = this.GetPropertyInfo(PropertyDateFrom);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (DateTo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_DateTo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDateTo);
            var propertyInfo  = this.GetPropertyInfo(PropertyDateTo);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (ExportStatus) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_ExportStatus_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExportStatus);
            var propertyInfo  = this.GetPropertyInfo(PropertyExportStatus);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (ExtensionData) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_ExtensionData_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExtensionData);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExtensionData);
            Action currentAction = () => propertyInfo.SetValue(_payrollBatchInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (ExtensionData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_ExtensionData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PayrollBatch) => Property (IncAllCharges) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_IncAllCharges_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIncAllCharges);
            var propertyInfo  = this.GetPropertyInfo(PropertyIncAllCharges);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (IncAllUsers) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_IncAllUsers_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIncAllUsers);
            var propertyInfo  = this.GetPropertyInfo(PropertyIncAllUsers);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (IncCostPerUser) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_IncCostPerUser_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIncCostPerUser);
            var propertyInfo  = this.GetPropertyInfo(PropertyIncCostPerUser);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (IncJobCosting) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_IncJobCosting_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIncJobCosting);
            var propertyInfo  = this.GetPropertyInfo(PropertyIncJobCosting);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (Issued) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_Issued_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIssued);
            var propertyInfo  = this.GetPropertyInfo(PropertyIssued);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (IssueDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_IssueDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIssueDate);
            var propertyInfo  = this.GetPropertyInfo(PropertyIssueDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (ModifyTimeStamp) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_ModifyTimeStamp_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyModifyTimeStamp);
            var propertyInfo  = this.GetPropertyInfo(PropertyModifyTimeStamp);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (ProcAllUsers) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_ProcAllUsers_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProcAllUsers);
            var propertyInfo  = this.GetPropertyInfo(PropertyProcAllUsers);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (ProcCharges) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_ProcCharges_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProcCharges);
            var propertyInfo  = this.GetPropertyInfo(PropertyProcCharges);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (ProcTime) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_ProcTime_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProcTime);
            var propertyInfo  = this.GetPropertyInfo(PropertyProcTime);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (RegenerateCharge) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_RegenerateCharge_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRegenerateCharge);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyRegenerateCharge);
            Action currentAction = () => propertyInfo.SetValue(_payrollBatchInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (RegenerateCharge) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_RegenerateCharge_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRegenerateCharge);
            var propertyInfo  = this.GetPropertyInfo(PropertyRegenerateCharge);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (RegeneratePayCode) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_RegeneratePayCode_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRegeneratePayCode);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyRegeneratePayCode);
            Action currentAction = () => propertyInfo.SetValue(_payrollBatchInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (RegeneratePayCode) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_RegeneratePayCode_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRegeneratePayCode);
            var propertyInfo  = this.GetPropertyInfo(PropertyRegeneratePayCode);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (RegenerateTime) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_RegenerateTime_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRegenerateTime);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyRegenerateTime);
            Action currentAction = () => propertyInfo.SetValue(_payrollBatchInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (RegenerateTime) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_RegenerateTime_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRegenerateTime);
            var propertyInfo  = this.GetPropertyInfo(PropertyRegenerateTime);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            Action currentAction = () => propertyInfo.SetValue(_payrollBatchInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PayrollBatch) => Property (TemplateId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_TemplateId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTemplateId);
            var propertyInfo  = this.GetPropertyInfo(PropertyTemplateId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (TotalCharge) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_TotalCharge_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTotalCharge);
            var propertyInfo  = this.GetPropertyInfo(PropertyTotalCharge);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (TotalTime) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_TotalTime_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTotalTime);
            var propertyInfo  = this.GetPropertyInfo(PropertyTotalTime);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (TotalTimeCost) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_TotalTimeCost_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTotalTimeCost);
            var propertyInfo  = this.GetPropertyInfo(PropertyTotalTimeCost);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (TotAmount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_TotAmount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTotAmount);
            var propertyInfo  = this.GetPropertyInfo(PropertyTotAmount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayrollBatch) => Property (UniqueId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayrollBatch_Public_Class_UniqueId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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
        private void AUT_PayrollBatch_RaisePropertyChanged_Method_Call_Internally(Type[] types)
        {
            var methodRaisePropertyChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_payrollBatchInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PayrollBatch_RaisePropertyChanged_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_payrollBatchInstanceFixture, parametersOfRaisePropertyChanged);

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
        public void AUT_PayrollBatch_RaisePropertyChanged_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_payrollBatchInstance, MethodRaisePropertyChanged, parametersOfRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes);

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
        public void AUT_PayrollBatch_RaisePropertyChanged_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_PayrollBatch_RaisePropertyChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_payrollBatchInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);

            // Assert
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PayrollBatch_RaisePropertyChanged_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_payrollBatchInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}