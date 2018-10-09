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
using ChargeEntry = UplandIntegrations.TenroxTaskService;

namespace UplandIntegrations.TenroxTaskService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxTaskService.ChargeEntry" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxTaskService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    public partial class ChargeEntryTest : AbstractBaseSetupV3Test
    {
        public ChargeEntryTest() : base(typeof(ChargeEntry))
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

        #region General Initializer : Class (ChargeEntry) Initializer

        #region Properties

        private const string PropertyExtensionData = "ExtensionData";
        private const string PropertyAmount = "Amount";
        private const string PropertyAmountBaseCurrency = "AmountBaseCurrency";
        private const string PropertyAmountClientCurrency = "AmountClientCurrency";
        private const string PropertyAmountUserCurrency = "AmountUserCurrency";
        private const string PropertyAppTimestamp = "AppTimestamp";
        private const string PropertyApprovalDate = "ApprovalDate";
        private const string PropertyApprovedBy = "ApprovedBy";
        private const string PropertyBilled = "Billed";
        private const string PropertyBilledAmount = "BilledAmount";
        private const string PropertyBilledUnitPrice = "BilledUnitPrice";
        private const string PropertyChargeId = "ChargeId";
        private const string PropertyClientCurrency = "ClientCurrency";
        private const string PropertyClientCurrencyId = "ClientCurrencyId";
        private const string PropertyCostAmountCostCurrency = "CostAmountCostCurrency";
        private const string PropertyCostCurrency = "CostCurrency";
        private const string PropertyCostCurrencyId = "CostCurrencyId";
        private const string PropertyCostedAmount = "CostedAmount";
        private const string PropertyCostedUnitPrice = "CostedUnitPrice";
        private const string PropertyCostedUnitPriceCostCurrency = "CostedUnitPriceCostCurrency";
        private const string PropertyCreatorId = "CreatorId";
        private const string PropertyCurrency = "Currency";
        private const string PropertyCurrencyId = "CurrencyId";
        private const string PropertyCurrentDate = "CurrentDate";
        private const string PropertyCurrentTime = "CurrentTime";
        private const string PropertyDescription = "Description";
        private const string PropertyInvoiceId = "InvoiceId";
        private const string PropertyIsApproved = "IsApproved";
        private const string PropertyIsBillable = "IsBillable";
        private const string PropertyIsCapitalized = "IsCapitalized";
        private const string PropertyIsCosted = "IsCosted";
        private const string PropertyIsFunded = "IsFunded";
        private const string PropertyIsRandD = "IsRandD";
        private const string PropertyIsRejected = "IsRejected";
        private const string PropertyIsRevenuRecognition = "IsRevenuRecognition";
        private const string PropertyIsTaxable = "IsTaxable";
        private const string PropertyMILESTONEID = "MILESTONEID";
        private const string PropertyPosted = "Posted";
        private const string PropertyPostedAmount = "PostedAmount";
        private const string PropertyRateToBaseCurrency = "RateToBaseCurrency";
        private const string PropertyRateToClientCurrency = "RateToClientCurrency";
        private const string PropertyRateToUserCurrency = "RateToUserCurrency";
        private const string PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey";
        private const string PropertyTMILEST = "TMILEST";
        private const string PropertyTaskId = "TaskId";
        private const string PropertyTimeEntries = "TimeEntries";
        private const string PropertyUniqueId = "UniqueId";
        private const string PropertyUpdateTimestamp = "UpdateTimestamp";
        private const string PropertyUserCurrency = "UserCurrency";
        private const string PropertyUserCurrencyId = "UserCurrencyId";
        private const string PropertyUserId = "UserId";

        #endregion

        #region Methods

        private const string MethodRaisePropertyChanged = "RaisePropertyChanged";

        #endregion

        #region Fields

        private const string FieldextensionDataField = "extensionDataField";
        private const string FieldAmountField = "AmountField";
        private const string FieldAmountBaseCurrencyField = "AmountBaseCurrencyField";
        private const string FieldAmountClientCurrencyField = "AmountClientCurrencyField";
        private const string FieldAmountUserCurrencyField = "AmountUserCurrencyField";
        private const string FieldAppTimestampField = "AppTimestampField";
        private const string FieldApprovalDateField = "ApprovalDateField";
        private const string FieldApprovedByField = "ApprovedByField";
        private const string FieldBilledField = "BilledField";
        private const string FieldBilledAmountField = "BilledAmountField";
        private const string FieldBilledUnitPriceField = "BilledUnitPriceField";
        private const string FieldChargeIdField = "ChargeIdField";
        private const string FieldClientCurrencyField = "ClientCurrencyField";
        private const string FieldClientCurrencyIdField = "ClientCurrencyIdField";
        private const string FieldCostAmountCostCurrencyField = "CostAmountCostCurrencyField";
        private const string FieldCostCurrencyField = "CostCurrencyField";
        private const string FieldCostCurrencyIdField = "CostCurrencyIdField";
        private const string FieldCostedAmountField = "CostedAmountField";
        private const string FieldCostedUnitPriceField = "CostedUnitPriceField";
        private const string FieldCostedUnitPriceCostCurrencyField = "CostedUnitPriceCostCurrencyField";
        private const string FieldCreatorIdField = "CreatorIdField";
        private const string FieldCurrencyField = "CurrencyField";
        private const string FieldCurrencyIdField = "CurrencyIdField";
        private const string FieldCurrentDateField = "CurrentDateField";
        private const string FieldCurrentTimeField = "CurrentTimeField";
        private const string FieldDescriptionField = "DescriptionField";
        private const string FieldInvoiceIdField = "InvoiceIdField";
        private const string FieldIsApprovedField = "IsApprovedField";
        private const string FieldIsBillableField = "IsBillableField";
        private const string FieldIsCapitalizedField = "IsCapitalizedField";
        private const string FieldIsCostedField = "IsCostedField";
        private const string FieldIsFundedField = "IsFundedField";
        private const string FieldIsRandDField = "IsRandDField";
        private const string FieldIsRejectedField = "IsRejectedField";
        private const string FieldIsRevenuRecognitionField = "IsRevenuRecognitionField";
        private const string FieldIsTaxableField = "IsTaxableField";
        private const string FieldMILESTONEIDField = "MILESTONEIDField";
        private const string FieldPostedField = "PostedField";
        private const string FieldPostedAmountField = "PostedAmountField";
        private const string FieldRateToBaseCurrencyField = "RateToBaseCurrencyField";
        private const string FieldRateToClientCurrencyField = "RateToClientCurrencyField";
        private const string FieldRateToUserCurrencyField = "RateToUserCurrencyField";
        private const string FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField = "SystemDataObjectsDataClassesIEntityWithKeyEntityKeyField";
        private const string FieldTMILESTField = "TMILESTField";
        private const string FieldTaskIdField = "TaskIdField";
        private const string FieldTimeEntriesField = "TimeEntriesField";
        private const string FieldUniqueIdField = "UniqueIdField";
        private const string FieldUpdateTimestampField = "UpdateTimestampField";
        private const string FieldUserCurrencyField = "UserCurrencyField";
        private const string FieldUserCurrencyIdField = "UserCurrencyIdField";
        private const string FieldUserIdField = "UserIdField";

        #endregion

        private Type _chargeEntryInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private ChargeEntry _chargeEntryInstance;
        private ChargeEntry _chargeEntryInstanceFixture;

        #region General Initializer : Class (ChargeEntry) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ChargeEntry" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _chargeEntryInstanceType = typeof(ChargeEntry);
            _chargeEntryInstanceFixture = this.Create<ChargeEntry>(true);
            _chargeEntryInstance = _chargeEntryInstanceFixture ?? this.Create<ChargeEntry>(false);
            CurrentInstance = _chargeEntryInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ChargeEntry)

        #region General Initializer : Class (ChargeEntry) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ChargeEntry" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRaisePropertyChanged, 0)]
        public void AUT_ChargeEntry_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_chargeEntryInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ChargeEntry) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ChargeEntry" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyExtensionData)]
        [TestCase(PropertyAmount)]
        [TestCase(PropertyAmountBaseCurrency)]
        [TestCase(PropertyAmountClientCurrency)]
        [TestCase(PropertyAmountUserCurrency)]
        [TestCase(PropertyAppTimestamp)]
        [TestCase(PropertyApprovalDate)]
        [TestCase(PropertyApprovedBy)]
        [TestCase(PropertyBilled)]
        [TestCase(PropertyBilledAmount)]
        [TestCase(PropertyBilledUnitPrice)]
        [TestCase(PropertyChargeId)]
        [TestCase(PropertyClientCurrency)]
        [TestCase(PropertyClientCurrencyId)]
        [TestCase(PropertyCostAmountCostCurrency)]
        [TestCase(PropertyCostCurrency)]
        [TestCase(PropertyCostCurrencyId)]
        [TestCase(PropertyCostedAmount)]
        [TestCase(PropertyCostedUnitPrice)]
        [TestCase(PropertyCostedUnitPriceCostCurrency)]
        [TestCase(PropertyCreatorId)]
        [TestCase(PropertyCurrency)]
        [TestCase(PropertyCurrencyId)]
        [TestCase(PropertyCurrentDate)]
        [TestCase(PropertyCurrentTime)]
        [TestCase(PropertyDescription)]
        [TestCase(PropertyInvoiceId)]
        [TestCase(PropertyIsApproved)]
        [TestCase(PropertyIsBillable)]
        [TestCase(PropertyIsCapitalized)]
        [TestCase(PropertyIsCosted)]
        [TestCase(PropertyIsFunded)]
        [TestCase(PropertyIsRandD)]
        [TestCase(PropertyIsRejected)]
        [TestCase(PropertyIsRevenuRecognition)]
        [TestCase(PropertyIsTaxable)]
        [TestCase(PropertyMILESTONEID)]
        [TestCase(PropertyPosted)]
        [TestCase(PropertyPostedAmount)]
        [TestCase(PropertyRateToBaseCurrency)]
        [TestCase(PropertyRateToClientCurrency)]
        [TestCase(PropertyRateToUserCurrency)]
        [TestCase(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCase(PropertyTMILEST)]
        [TestCase(PropertyTaskId)]
        [TestCase(PropertyTimeEntries)]
        [TestCase(PropertyUniqueId)]
        [TestCase(PropertyUpdateTimestamp)]
        [TestCase(PropertyUserCurrency)]
        [TestCase(PropertyUserCurrencyId)]
        [TestCase(PropertyUserId)]
        public void AUT_ChargeEntry_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var propertyInfo = this.GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_chargeEntryInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ChargeEntry) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ChargeEntry" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldextensionDataField)]
        [TestCase(FieldAmountField)]
        [TestCase(FieldAmountBaseCurrencyField)]
        [TestCase(FieldAmountClientCurrencyField)]
        [TestCase(FieldAmountUserCurrencyField)]
        [TestCase(FieldAppTimestampField)]
        [TestCase(FieldApprovalDateField)]
        [TestCase(FieldApprovedByField)]
        [TestCase(FieldBilledField)]
        [TestCase(FieldBilledAmountField)]
        [TestCase(FieldBilledUnitPriceField)]
        [TestCase(FieldChargeIdField)]
        [TestCase(FieldClientCurrencyField)]
        [TestCase(FieldClientCurrencyIdField)]
        [TestCase(FieldCostAmountCostCurrencyField)]
        [TestCase(FieldCostCurrencyField)]
        [TestCase(FieldCostCurrencyIdField)]
        [TestCase(FieldCostedAmountField)]
        [TestCase(FieldCostedUnitPriceField)]
        [TestCase(FieldCostedUnitPriceCostCurrencyField)]
        [TestCase(FieldCreatorIdField)]
        [TestCase(FieldCurrencyField)]
        [TestCase(FieldCurrencyIdField)]
        [TestCase(FieldCurrentDateField)]
        [TestCase(FieldCurrentTimeField)]
        [TestCase(FieldDescriptionField)]
        [TestCase(FieldInvoiceIdField)]
        [TestCase(FieldIsApprovedField)]
        [TestCase(FieldIsBillableField)]
        [TestCase(FieldIsCapitalizedField)]
        [TestCase(FieldIsCostedField)]
        [TestCase(FieldIsFundedField)]
        [TestCase(FieldIsRandDField)]
        [TestCase(FieldIsRejectedField)]
        [TestCase(FieldIsRevenuRecognitionField)]
        [TestCase(FieldIsTaxableField)]
        [TestCase(FieldMILESTONEIDField)]
        [TestCase(FieldPostedField)]
        [TestCase(FieldPostedAmountField)]
        [TestCase(FieldRateToBaseCurrencyField)]
        [TestCase(FieldRateToClientCurrencyField)]
        [TestCase(FieldRateToUserCurrencyField)]
        [TestCase(FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField)]
        [TestCase(FieldTMILESTField)]
        [TestCase(FieldTaskIdField)]
        [TestCase(FieldTimeEntriesField)]
        [TestCase(FieldUniqueIdField)]
        [TestCase(FieldUpdateTimestampField)]
        [TestCase(FieldUserCurrencyField)]
        [TestCase(FieldUserCurrencyIdField)]
        [TestCase(FieldUserIdField)]
        public void AUT_ChargeEntry_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_chargeEntryInstanceFixture, 
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
        ///     Class (<see cref="ChargeEntry" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ChargeEntry_Is_Instance_Present_Test()
        {
            // Assert
            _chargeEntryInstanceType.ShouldNotBeNull();
            _chargeEntryInstance.ShouldNotBeNull();
            _chargeEntryInstanceFixture.ShouldNotBeNull();
            _chargeEntryInstance.ShouldBeAssignableTo<ChargeEntry>();
            _chargeEntryInstanceFixture.ShouldBeAssignableTo<ChargeEntry>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ChargeEntry) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ChargeEntry_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ChargeEntry instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _chargeEntryInstanceType.ShouldNotBeNull();
            _chargeEntryInstance.ShouldNotBeNull();
            _chargeEntryInstanceFixture.ShouldNotBeNull();
            _chargeEntryInstance.ShouldBeAssignableTo<ChargeEntry>();
            _chargeEntryInstanceFixture.ShouldBeAssignableTo<ChargeEntry>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ChargeEntry) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(System.Runtime.Serialization.ExtensionDataObject) , PropertyExtensionData)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyAmount)]
        [TestCaseGeneric(typeof(decimal) , PropertyAmountBaseCurrency)]
        [TestCaseGeneric(typeof(decimal) , PropertyAmountClientCurrency)]
        [TestCaseGeneric(typeof(decimal) , PropertyAmountUserCurrency)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyAppTimestamp)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyApprovalDate)]
        [TestCaseGeneric(typeof(int) , PropertyApprovedBy)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyBilled)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyBilledAmount)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyBilledUnitPrice)]
        [TestCaseGeneric(typeof(int) , PropertyChargeId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxTaskService.Currency) , PropertyClientCurrency)]
        [TestCaseGeneric(typeof(int) , PropertyClientCurrencyId)]
        [TestCaseGeneric(typeof(decimal) , PropertyCostAmountCostCurrency)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxTaskService.Currency) , PropertyCostCurrency)]
        [TestCaseGeneric(typeof(int) , PropertyCostCurrencyId)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyCostedAmount)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyCostedUnitPrice)]
        [TestCaseGeneric(typeof(decimal) , PropertyCostedUnitPriceCostCurrency)]
        [TestCaseGeneric(typeof(int) , PropertyCreatorId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxTaskService.Currency) , PropertyCurrency)]
        [TestCaseGeneric(typeof(int) , PropertyCurrencyId)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertyCurrentDate)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyCurrentTime)]
        [TestCaseGeneric(typeof(string) , PropertyDescription)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyInvoiceId)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsApproved)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsBillable)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsCapitalized)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsCosted)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsFunded)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsRandD)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsRejected)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsRevenuRecognition)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsTaxable)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyMILESTONEID)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyPosted)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyPostedAmount)]
        [TestCaseGeneric(typeof(decimal) , PropertyRateToBaseCurrency)]
        [TestCaseGeneric(typeof(decimal) , PropertyRateToClientCurrency)]
        [TestCaseGeneric(typeof(decimal) , PropertyRateToUserCurrency)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxTaskService.EntityKey) , PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxTaskService.Milestone) , PropertyTMILEST)]
        [TestCaseGeneric(typeof(int) , PropertyTaskId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxTaskService.TimeEntry[]) , PropertyTimeEntries)]
        [TestCaseGeneric(typeof(int) , PropertyUniqueId)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyUpdateTimestamp)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxTaskService.Currency) , PropertyUserCurrency)]
        [TestCaseGeneric(typeof(int) , PropertyUserCurrencyId)]
        [TestCaseGeneric(typeof(int) , PropertyUserId)]
        public void AUT_ChargeEntry_Property_Type_Verify_Explore_By_Name_Test<T>(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);

            // Assert
            ShouldlyExtension.PropertyTypeVerify<ChargeEntry, T>(_chargeEntryInstance, name, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (Amount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_Amount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAmount);
            var propertyInfo  = this.GetPropertyInfo(PropertyAmount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (AmountBaseCurrency) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_AmountBaseCurrency_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAmountBaseCurrency);
            var propertyInfo  = this.GetPropertyInfo(PropertyAmountBaseCurrency);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (AmountClientCurrency) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_AmountClientCurrency_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAmountClientCurrency);
            var propertyInfo  = this.GetPropertyInfo(PropertyAmountClientCurrency);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (AmountUserCurrency) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_AmountUserCurrency_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAmountUserCurrency);
            var propertyInfo  = this.GetPropertyInfo(PropertyAmountUserCurrency);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (ApprovalDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_ApprovalDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyApprovalDate);
            var propertyInfo  = this.GetPropertyInfo(PropertyApprovalDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (ApprovedBy) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_ApprovedBy_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyApprovedBy);
            var propertyInfo  = this.GetPropertyInfo(PropertyApprovedBy);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (AppTimestamp) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_AppTimestamp_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAppTimestamp);
            var propertyInfo  = this.GetPropertyInfo(PropertyAppTimestamp);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (Billed) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_Billed_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBilled);
            var propertyInfo  = this.GetPropertyInfo(PropertyBilled);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (BilledAmount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_BilledAmount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBilledAmount);
            var propertyInfo  = this.GetPropertyInfo(PropertyBilledAmount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (BilledUnitPrice) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_BilledUnitPrice_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBilledUnitPrice);
            var propertyInfo  = this.GetPropertyInfo(PropertyBilledUnitPrice);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (ChargeId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_ChargeId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyChargeId);
            var propertyInfo  = this.GetPropertyInfo(PropertyChargeId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (ClientCurrency) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_ClientCurrency_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyClientCurrency);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyClientCurrency);
            Action currentAction = () => propertyInfo.SetValue(_chargeEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (ClientCurrency) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_ClientCurrency_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyClientCurrency);
            var propertyInfo  = this.GetPropertyInfo(PropertyClientCurrency);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (ClientCurrencyId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_ClientCurrencyId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyClientCurrencyId);
            var propertyInfo  = this.GetPropertyInfo(PropertyClientCurrencyId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (CostAmountCostCurrency) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_CostAmountCostCurrency_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCostAmountCostCurrency);
            var propertyInfo  = this.GetPropertyInfo(PropertyCostAmountCostCurrency);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (CostCurrency) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_CostCurrency_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCostCurrency);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyCostCurrency);
            Action currentAction = () => propertyInfo.SetValue(_chargeEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (CostCurrency) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_CostCurrency_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCostCurrency);
            var propertyInfo  = this.GetPropertyInfo(PropertyCostCurrency);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (CostCurrencyId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_CostCurrencyId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCostCurrencyId);
            var propertyInfo  = this.GetPropertyInfo(PropertyCostCurrencyId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (CostedAmount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_CostedAmount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCostedAmount);
            var propertyInfo  = this.GetPropertyInfo(PropertyCostedAmount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (CostedUnitPrice) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_CostedUnitPrice_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCostedUnitPrice);
            var propertyInfo  = this.GetPropertyInfo(PropertyCostedUnitPrice);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (CostedUnitPriceCostCurrency) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_CostedUnitPriceCostCurrency_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCostedUnitPriceCostCurrency);
            var propertyInfo  = this.GetPropertyInfo(PropertyCostedUnitPriceCostCurrency);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (CreatorId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_CreatorId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCreatorId);
            var propertyInfo  = this.GetPropertyInfo(PropertyCreatorId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (Currency) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Currency_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCurrency);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyCurrency);
            Action currentAction = () => propertyInfo.SetValue(_chargeEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (Currency) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_Currency_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCurrency);
            var propertyInfo  = this.GetPropertyInfo(PropertyCurrency);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (CurrencyId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_CurrencyId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCurrencyId);
            var propertyInfo  = this.GetPropertyInfo(PropertyCurrencyId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (CurrentDate) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_CurrentDate_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCurrentDate);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyCurrentDate);
            Action currentAction = () => propertyInfo.SetValue(_chargeEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (CurrentDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_CurrentDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCurrentDate);
            var propertyInfo  = this.GetPropertyInfo(PropertyCurrentDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (CurrentTime) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_CurrentTime_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCurrentTime);
            var propertyInfo  = this.GetPropertyInfo(PropertyCurrentTime);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (Description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_Description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ChargeEntry) => Property (ExtensionData) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_ExtensionData_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExtensionData);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExtensionData);
            Action currentAction = () => propertyInfo.SetValue(_chargeEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (ExtensionData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_ExtensionData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ChargeEntry) => Property (InvoiceId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_InvoiceId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyInvoiceId);
            var propertyInfo  = this.GetPropertyInfo(PropertyInvoiceId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (IsApproved) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_IsApproved_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsApproved);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsApproved);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (IsBillable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_IsBillable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsBillable);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsBillable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (IsCapitalized) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_IsCapitalized_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsCapitalized);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsCapitalized);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (IsCosted) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_IsCosted_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsCosted);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsCosted);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (IsFunded) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_IsFunded_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsFunded);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsFunded);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (IsRandD) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_IsRandD_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsRandD);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsRandD);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (IsRejected) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_IsRejected_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsRejected);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsRejected);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (IsRevenuRecognition) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_IsRevenuRecognition_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsRevenuRecognition);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsRevenuRecognition);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (IsTaxable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_IsTaxable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsTaxable);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsTaxable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (MILESTONEID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_MILESTONEID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMILESTONEID);
            var propertyInfo  = this.GetPropertyInfo(PropertyMILESTONEID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (Posted) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_Posted_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPosted);
            var propertyInfo  = this.GetPropertyInfo(PropertyPosted);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (PostedAmount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_PostedAmount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPostedAmount);
            var propertyInfo  = this.GetPropertyInfo(PropertyPostedAmount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (RateToBaseCurrency) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_RateToBaseCurrency_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRateToBaseCurrency);
            var propertyInfo  = this.GetPropertyInfo(PropertyRateToBaseCurrency);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (RateToClientCurrency) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_RateToClientCurrency_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRateToClientCurrency);
            var propertyInfo  = this.GetPropertyInfo(PropertyRateToClientCurrency);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (RateToUserCurrency) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_RateToUserCurrency_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRateToUserCurrency);
            var propertyInfo  = this.GetPropertyInfo(PropertyRateToUserCurrency);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            Action currentAction = () => propertyInfo.SetValue(_chargeEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ChargeEntry) => Property (TaskId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_TaskId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTaskId);
            var propertyInfo  = this.GetPropertyInfo(PropertyTaskId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (TimeEntries) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_TimeEntries_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimeEntries);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTimeEntries);
            Action currentAction = () => propertyInfo.SetValue(_chargeEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (TimeEntries) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_TimeEntries_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimeEntries);
            var propertyInfo  = this.GetPropertyInfo(PropertyTimeEntries);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (TMILEST) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_TMILEST_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTMILEST);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTMILEST);
            Action currentAction = () => propertyInfo.SetValue(_chargeEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (TMILEST) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_TMILEST_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTMILEST);
            var propertyInfo  = this.GetPropertyInfo(PropertyTMILEST);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (UniqueId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_UniqueId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ChargeEntry) => Property (UpdateTimestamp) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_UpdateTimestamp_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUpdateTimestamp);
            var propertyInfo  = this.GetPropertyInfo(PropertyUpdateTimestamp);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (UserCurrency) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_UserCurrency_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUserCurrency);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyUserCurrency);
            Action currentAction = () => propertyInfo.SetValue(_chargeEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (UserCurrency) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_UserCurrency_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUserCurrency);
            var propertyInfo  = this.GetPropertyInfo(PropertyUserCurrency);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (UserCurrencyId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_UserCurrencyId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUserCurrencyId);
            var propertyInfo  = this.GetPropertyInfo(PropertyUserCurrencyId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChargeEntry) => Property (UserId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChargeEntry_Public_Class_UserId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUserId);
            var propertyInfo  = this.GetPropertyInfo(PropertyUserId);

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
        private void AUT_ChargeEntry_RaisePropertyChanged_Method_Call_Internally(Type[] types)
        {
            var methodRaisePropertyChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chargeEntryInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChargeEntry_RaisePropertyChanged_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chargeEntryInstanceFixture, parametersOfRaisePropertyChanged);

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
        public void AUT_ChargeEntry_RaisePropertyChanged_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chargeEntryInstance, MethodRaisePropertyChanged, parametersOfRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes);

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
        public void AUT_ChargeEntry_RaisePropertyChanged_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ChargeEntry_RaisePropertyChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chargeEntryInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);

            // Assert
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChargeEntry_RaisePropertyChanged_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chargeEntryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}