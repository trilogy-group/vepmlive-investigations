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
using UplandIntegrations.TenroxUserService;
using PayableBatch = UplandIntegrations.TenroxUserService;

namespace UplandIntegrations.TenroxUserService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxUserService.PayableBatch" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxUserService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class PayableBatchTest : AbstractBaseSetupV3Test
    {
        public PayableBatchTest() : base(typeof(PayableBatch))
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

        #region General Initializer : Class (PayableBatch) Initializer

        #region Properties

        private const string PropertyExtensionData = "ExtensionData";
        private const string PropertyAccconSet = "AccconSet";
        private const string PropertyAcconSetId = "AcconSetId";
        private const string PropertyAppTimeStamp = "AppTimeStamp";
        private const string PropertyBatchNo = "BatchNo";
        private const string PropertyComments = "Comments";
        private const string PropertyCreatedBy = "CreatedBy";
        private const string PropertyDateFrom = "DateFrom";
        private const string PropertyDateTo = "DateTo";
        private const string PropertyDocumentDate = "DocumentDate";
        private const string PropertyEXCLUDETAXES = "EXCLUDETAXES";
        private const string PropertyIncDBStartDate = "IncDBStartDate";
        private const string PropertyIncludeCharges = "IncludeCharges";
        private const string PropertyIncludeExpenses = "IncludeExpenses";
        private const string PropertyIncludeNonReimExpenses = "IncludeNonReimExpenses";
        private const string PropertyIssueDate = "IssueDate";
        private const string PropertyIssued = "Issued";
        private const string PropertyMapExpenseToOriginator = "MapExpenseToOriginator";
        private const string PropertyModifyTimeStamp = "ModifyTimeStamp";
        private const string PropertyPType = "PType";
        private const string PropertyProcAllAdjs = "ProcAllAdjs";
        private const string PropertyProcAllExpReps = "ProcAllExpReps";
        private const string PropertyProcAllUsers = "ProcAllUsers";
        private const string PropertyRegenerateCharge = "RegenerateCharge";
        private const string PropertyRegenerateExpense = "RegenerateExpense";
        private const string PropertyRegenerateTransaction = "RegenerateTransaction";
        private const string PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey";
        private const string PropertyTemplateId = "TemplateId";
        private const string PropertyTotAmount = "TotAmount";
        private const string PropertyTotalExpense = "TotalExpense";
        private const string PropertyTotalLCharge = "TotalLCharge";
        private const string PropertyUniqueId = "UniqueId";

        #endregion

        #region Methods

        private const string MethodRaisePropertyChanged = "RaisePropertyChanged";

        #endregion

        #region Fields

        private const string FieldextensionDataField = "extensionDataField";
        private const string FieldAccconSetField = "AccconSetField";
        private const string FieldAcconSetIdField = "AcconSetIdField";
        private const string FieldAppTimeStampField = "AppTimeStampField";
        private const string FieldBatchNoField = "BatchNoField";
        private const string FieldCommentsField = "CommentsField";
        private const string FieldCreatedByField = "CreatedByField";
        private const string FieldDateFromField = "DateFromField";
        private const string FieldDateToField = "DateToField";
        private const string FieldDocumentDateField = "DocumentDateField";
        private const string FieldEXCLUDETAXESField = "EXCLUDETAXESField";
        private const string FieldIncDBStartDateField = "IncDBStartDateField";
        private const string FieldIncludeChargesField = "IncludeChargesField";
        private const string FieldIncludeExpensesField = "IncludeExpensesField";
        private const string FieldIncludeNonReimExpensesField = "IncludeNonReimExpensesField";
        private const string FieldIssueDateField = "IssueDateField";
        private const string FieldIssuedField = "IssuedField";
        private const string FieldMapExpenseToOriginatorField = "MapExpenseToOriginatorField";
        private const string FieldModifyTimeStampField = "ModifyTimeStampField";
        private const string FieldPTypeField = "PTypeField";
        private const string FieldProcAllAdjsField = "ProcAllAdjsField";
        private const string FieldProcAllExpRepsField = "ProcAllExpRepsField";
        private const string FieldProcAllUsersField = "ProcAllUsersField";
        private const string FieldRegenerateChargeField = "RegenerateChargeField";
        private const string FieldRegenerateExpenseField = "RegenerateExpenseField";
        private const string FieldRegenerateTransactionField = "RegenerateTransactionField";
        private const string FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField = "SystemDataObjectsDataClassesIEntityWithKeyEntityKeyField";
        private const string FieldTemplateIdField = "TemplateIdField";
        private const string FieldTotAmountField = "TotAmountField";
        private const string FieldTotalExpenseField = "TotalExpenseField";
        private const string FieldTotalLChargeField = "TotalLChargeField";
        private const string FieldUniqueIdField = "UniqueIdField";

        #endregion

        private Type _payableBatchInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private PayableBatch _payableBatchInstance;
        private PayableBatch _payableBatchInstanceFixture;

        #region General Initializer : Class (PayableBatch) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PayableBatch" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _payableBatchInstanceType = typeof(PayableBatch);
            _payableBatchInstanceFixture = this.Create<PayableBatch>(true);
            _payableBatchInstance = _payableBatchInstanceFixture ?? this.Create<PayableBatch>(false);
            CurrentInstance = _payableBatchInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PayableBatch)

        #region General Initializer : Class (PayableBatch) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="PayableBatch" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRaisePropertyChanged, 0)]
        public void AUT_PayableBatch_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_payableBatchInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PayableBatch) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="PayableBatch" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyExtensionData)]
        [TestCase(PropertyAccconSet)]
        [TestCase(PropertyAcconSetId)]
        [TestCase(PropertyAppTimeStamp)]
        [TestCase(PropertyBatchNo)]
        [TestCase(PropertyComments)]
        [TestCase(PropertyCreatedBy)]
        [TestCase(PropertyDateFrom)]
        [TestCase(PropertyDateTo)]
        [TestCase(PropertyDocumentDate)]
        [TestCase(PropertyEXCLUDETAXES)]
        [TestCase(PropertyIncDBStartDate)]
        [TestCase(PropertyIncludeCharges)]
        [TestCase(PropertyIncludeExpenses)]
        [TestCase(PropertyIncludeNonReimExpenses)]
        [TestCase(PropertyIssueDate)]
        [TestCase(PropertyIssued)]
        [TestCase(PropertyMapExpenseToOriginator)]
        [TestCase(PropertyModifyTimeStamp)]
        [TestCase(PropertyPType)]
        [TestCase(PropertyProcAllAdjs)]
        [TestCase(PropertyProcAllExpReps)]
        [TestCase(PropertyProcAllUsers)]
        [TestCase(PropertyRegenerateCharge)]
        [TestCase(PropertyRegenerateExpense)]
        [TestCase(PropertyRegenerateTransaction)]
        [TestCase(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCase(PropertyTemplateId)]
        [TestCase(PropertyTotAmount)]
        [TestCase(PropertyTotalExpense)]
        [TestCase(PropertyTotalLCharge)]
        [TestCase(PropertyUniqueId)]
        public void AUT_PayableBatch_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var propertyInfo = this.GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_payableBatchInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PayableBatch) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PayableBatch" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldextensionDataField)]
        [TestCase(FieldAccconSetField)]
        [TestCase(FieldAcconSetIdField)]
        [TestCase(FieldAppTimeStampField)]
        [TestCase(FieldBatchNoField)]
        [TestCase(FieldCommentsField)]
        [TestCase(FieldCreatedByField)]
        [TestCase(FieldDateFromField)]
        [TestCase(FieldDateToField)]
        [TestCase(FieldDocumentDateField)]
        [TestCase(FieldEXCLUDETAXESField)]
        [TestCase(FieldIncDBStartDateField)]
        [TestCase(FieldIncludeChargesField)]
        [TestCase(FieldIncludeExpensesField)]
        [TestCase(FieldIncludeNonReimExpensesField)]
        [TestCase(FieldIssueDateField)]
        [TestCase(FieldIssuedField)]
        [TestCase(FieldMapExpenseToOriginatorField)]
        [TestCase(FieldModifyTimeStampField)]
        [TestCase(FieldPTypeField)]
        [TestCase(FieldProcAllAdjsField)]
        [TestCase(FieldProcAllExpRepsField)]
        [TestCase(FieldProcAllUsersField)]
        [TestCase(FieldRegenerateChargeField)]
        [TestCase(FieldRegenerateExpenseField)]
        [TestCase(FieldRegenerateTransactionField)]
        [TestCase(FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField)]
        [TestCase(FieldTemplateIdField)]
        [TestCase(FieldTotAmountField)]
        [TestCase(FieldTotalExpenseField)]
        [TestCase(FieldTotalLChargeField)]
        [TestCase(FieldUniqueIdField)]
        public void AUT_PayableBatch_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_payableBatchInstanceFixture, 
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
        ///     Class (<see cref="PayableBatch" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_PayableBatch_Is_Instance_Present_Test()
        {
            // Assert
            _payableBatchInstanceType.ShouldNotBeNull();
            _payableBatchInstance.ShouldNotBeNull();
            _payableBatchInstanceFixture.ShouldNotBeNull();
            _payableBatchInstance.ShouldBeAssignableTo<PayableBatch>();
            _payableBatchInstanceFixture.ShouldBeAssignableTo<PayableBatch>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PayableBatch) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_PayableBatch_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PayableBatch instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _payableBatchInstanceType.ShouldNotBeNull();
            _payableBatchInstance.ShouldNotBeNull();
            _payableBatchInstanceFixture.ShouldNotBeNull();
            _payableBatchInstance.ShouldBeAssignableTo<PayableBatch>();
            _payableBatchInstanceFixture.ShouldBeAssignableTo<PayableBatch>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (PayableBatch) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(System.Runtime.Serialization.ExtensionDataObject) , PropertyExtensionData)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.AccountingConnection) , PropertyAccconSet)]
        [TestCaseGeneric(typeof(int) , PropertyAcconSetId)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyAppTimeStamp)]
        [TestCaseGeneric(typeof(string) , PropertyBatchNo)]
        [TestCaseGeneric(typeof(string) , PropertyComments)]
        [TestCaseGeneric(typeof(int) , PropertyCreatedBy)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyDateFrom)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyDateTo)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyDocumentDate)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyEXCLUDETAXES)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIncDBStartDate)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIncludeCharges)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIncludeExpenses)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIncludeNonReimExpenses)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyIssueDate)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIssued)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyMapExpenseToOriginator)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyModifyTimeStamp)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyPType)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyProcAllAdjs)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyProcAllExpReps)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyProcAllUsers)]
        [TestCaseGeneric(typeof(byte) , PropertyRegenerateCharge)]
        [TestCaseGeneric(typeof(byte) , PropertyRegenerateExpense)]
        [TestCaseGeneric(typeof(byte) , PropertyRegenerateTransaction)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.EntityKey) , PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTemplateId)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyTotAmount)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyTotalExpense)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyTotalLCharge)]
        [TestCaseGeneric(typeof(int) , PropertyUniqueId)]
        public void AUT_PayableBatch_Property_Type_Verify_Explore_By_Name_Test<T>(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);

            // Assert
            ShouldlyExtension.PropertyTypeVerify<PayableBatch, T>(_payableBatchInstance, name, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (PayableBatch) => Property (AccconSet) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_AccconSet_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAccconSet);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyAccconSet);
            Action currentAction = () => propertyInfo.SetValue(_payableBatchInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PayableBatch) => Property (AccconSet) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_AccconSet_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PayableBatch) => Property (AcconSetId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_AcconSetId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAcconSetId);
            var propertyInfo  = this.GetPropertyInfo(PropertyAcconSetId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayableBatch) => Property (AppTimeStamp) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_AppTimeStamp_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PayableBatch) => Property (BatchNo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_BatchNo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PayableBatch) => Property (Comments) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_Comments_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyComments);
            var propertyInfo  = this.GetPropertyInfo(PropertyComments);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayableBatch) => Property (CreatedBy) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_CreatedBy_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PayableBatch) => Property (DateFrom) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_DateFrom_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PayableBatch) => Property (DateTo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_DateTo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PayableBatch) => Property (DocumentDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_DocumentDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDocumentDate);
            var propertyInfo  = this.GetPropertyInfo(PropertyDocumentDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayableBatch) => Property (EXCLUDETAXES) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_EXCLUDETAXES_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyEXCLUDETAXES);
            var propertyInfo  = this.GetPropertyInfo(PropertyEXCLUDETAXES);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayableBatch) => Property (ExtensionData) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_ExtensionData_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExtensionData);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExtensionData);
            Action currentAction = () => propertyInfo.SetValue(_payableBatchInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PayableBatch) => Property (ExtensionData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_ExtensionData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PayableBatch) => Property (IncDBStartDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_IncDBStartDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIncDBStartDate);
            var propertyInfo  = this.GetPropertyInfo(PropertyIncDBStartDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayableBatch) => Property (IncludeCharges) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_IncludeCharges_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIncludeCharges);
            var propertyInfo  = this.GetPropertyInfo(PropertyIncludeCharges);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayableBatch) => Property (IncludeExpenses) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_IncludeExpenses_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIncludeExpenses);
            var propertyInfo  = this.GetPropertyInfo(PropertyIncludeExpenses);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayableBatch) => Property (IncludeNonReimExpenses) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_IncludeNonReimExpenses_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIncludeNonReimExpenses);
            var propertyInfo  = this.GetPropertyInfo(PropertyIncludeNonReimExpenses);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayableBatch) => Property (Issued) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_Issued_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PayableBatch) => Property (IssueDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_IssueDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PayableBatch) => Property (MapExpenseToOriginator) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_MapExpenseToOriginator_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMapExpenseToOriginator);
            var propertyInfo  = this.GetPropertyInfo(PropertyMapExpenseToOriginator);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayableBatch) => Property (ModifyTimeStamp) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_ModifyTimeStamp_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PayableBatch) => Property (ProcAllAdjs) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_ProcAllAdjs_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProcAllAdjs);
            var propertyInfo  = this.GetPropertyInfo(PropertyProcAllAdjs);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayableBatch) => Property (ProcAllExpReps) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_ProcAllExpReps_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProcAllExpReps);
            var propertyInfo  = this.GetPropertyInfo(PropertyProcAllExpReps);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayableBatch) => Property (ProcAllUsers) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_ProcAllUsers_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PayableBatch) => Property (PType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_PType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPType);
            var propertyInfo  = this.GetPropertyInfo(PropertyPType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayableBatch) => Property (RegenerateCharge) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_RegenerateCharge_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRegenerateCharge);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyRegenerateCharge);
            Action currentAction = () => propertyInfo.SetValue(_payableBatchInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PayableBatch) => Property (RegenerateCharge) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_RegenerateCharge_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PayableBatch) => Property (RegenerateExpense) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_RegenerateExpense_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRegenerateExpense);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyRegenerateExpense);
            Action currentAction = () => propertyInfo.SetValue(_payableBatchInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PayableBatch) => Property (RegenerateExpense) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_RegenerateExpense_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRegenerateExpense);
            var propertyInfo  = this.GetPropertyInfo(PropertyRegenerateExpense);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayableBatch) => Property (RegenerateTransaction) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_RegenerateTransaction_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRegenerateTransaction);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyRegenerateTransaction);
            Action currentAction = () => propertyInfo.SetValue(_payableBatchInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PayableBatch) => Property (RegenerateTransaction) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_RegenerateTransaction_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRegenerateTransaction);
            var propertyInfo  = this.GetPropertyInfo(PropertyRegenerateTransaction);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayableBatch) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            Action currentAction = () => propertyInfo.SetValue(_payableBatchInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PayableBatch) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PayableBatch) => Property (TemplateId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_TemplateId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PayableBatch) => Property (TotalExpense) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_TotalExpense_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTotalExpense);
            var propertyInfo  = this.GetPropertyInfo(PropertyTotalExpense);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayableBatch) => Property (TotalLCharge) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_TotalLCharge_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTotalLCharge);
            var propertyInfo  = this.GetPropertyInfo(PropertyTotalLCharge);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PayableBatch) => Property (TotAmount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_TotAmount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PayableBatch) => Property (UniqueId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PayableBatch_Public_Class_UniqueId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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
        private void AUT_PayableBatch_RaisePropertyChanged_Method_Call_Internally(Type[] types)
        {
            var methodRaisePropertyChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_payableBatchInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PayableBatch_RaisePropertyChanged_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_payableBatchInstanceFixture, parametersOfRaisePropertyChanged);

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
        public void AUT_PayableBatch_RaisePropertyChanged_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_payableBatchInstance, MethodRaisePropertyChanged, parametersOfRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes);

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
        public void AUT_PayableBatch_RaisePropertyChanged_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_PayableBatch_RaisePropertyChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_payableBatchInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);

            // Assert
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PayableBatch_RaisePropertyChanged_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_payableBatchInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}