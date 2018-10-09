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
using ExpenseEntry = UplandIntegrations.TenroxUserService;

namespace UplandIntegrations.TenroxUserService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxUserService.ExpenseEntry" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxUserService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    public partial class ExpenseEntryTest : AbstractBaseSetupV3Test
    {
        public ExpenseEntryTest() : base(typeof(ExpenseEntry))
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

        #region General Initializer : Class (ExpenseEntry) Initializer

        #region Properties

        private const string PropertyExtensionData = "ExtensionData";
        private const string PropertyAirline = "Airline";
        private const string PropertyAirlineTicketNumber = "AirlineTicketNumber";
        private const string PropertyAmount = "Amount";
        private const string PropertyAmountWithTips = "AmountWithTips";
        private const string PropertyApproved = "Approved";
        private const string PropertyBilled = "Billed";
        private const string PropertyCanExceedLimit = "CanExceedLimit";
        private const string PropertyCity = "City";
        private const string PropertyCreateTimestamp = "CreateTimestamp";
        private const string PropertyCurrency = "Currency";
        private const string PropertyCurrencyId = "CurrencyId";
        private const string PropertyCurrentDate = "CurrentDate";
        private const string PropertyEntryNumber = "EntryNumber";
        private const string PropertyExchangeRate = "ExchangeRate";
        private const string PropertyExpenseId = "ExpenseId";
        private const string PropertyExpenseItem = "ExpenseItem";
        private const string PropertyExpenseReport = "ExpenseReport";
        private const string PropertyExpenseReportId = "ExpenseReportId";
        private const string PropertyFederalTax = "FederalTax";
        private const string PropertyFinalAmount = "FinalAmount";
        private const string PropertyGuests = "Guests";
        private const string PropertyInvoiceId = "InvoiceId";
        private const string PropertyIsBillable = "IsBillable";
        private const string PropertyIsCompleted = "IsCompleted";
        private const string PropertyIsCustom = "IsCustom";
        private const string PropertyIsFunded = "IsFunded";
        private const string PropertyIsPayable = "IsPayable";
        private const string PropertyIsRandD = "IsRandD";
        private const string PropertyIsReimbursable = "IsReimbursable";
        private const string PropertyIsReimbursed = "IsReimbursed";
        private const string PropertyMarkupPercentage = "MarkupPercentage";
        private const string PropertyMemo = "Memo";
        private const string PropertyMilageDestination = "MilageDestination";
        private const string PropertyMilageRate = "MilageRate";
        private const string PropertyMilageScheme = "MilageScheme";
        private const string PropertyMilageSource = "MilageSource";
        private const string PropertyMiles = "Miles";
        private const string PropertyModifiedByOffline = "ModifiedByOffline";
        private const string PropertyPaid = "Paid";
        private const string PropertyPaymentMethod = "PaymentMethod";
        private const string PropertyPosted = "Posted";
        private const string PropertyProvincialTax = "ProvincialTax";
        private const string PropertyPurpose = "Purpose";
        private const string PropertyReceiptId = "ReceiptId";
        private const string PropertyRejected = "Rejected";
        private const string PropertyRevenueRecognition = "RevenueRecognition";
        private const string PropertySite = "Site";
        private const string PropertySiteId = "SiteId";
        private const string PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey";
        private const string PropertyTask = "Task";
        private const string PropertyTaskId = "TaskId";
        private const string PropertyTaxCategoryId = "TaxCategoryId";
        private const string PropertyTaxGroupId = "TaxGroupId";
        private const string PropertyTaxJurisdictionId = "TaxJurisdictionId";
        private const string PropertyTips = "Tips";
        private const string PropertyTotalAmount = "TotalAmount";
        private const string PropertyTotalAmountWithMarkup = "TotalAmountWithMarkup";
        private const string PropertyTotalInUserCurrency = "TotalInUserCurrency";
        private const string PropertyTotalTax = "TotalTax";
        private const string PropertyUniqueId = "UniqueId";
        private const string PropertyUpdateTimestamp = "UpdateTimestamp";
        private const string PropertyUser = "User";
        private const string PropertyUserCurrencyId = "UserCurrencyId";
        private const string PropertyUserExchangeRate = "UserExchangeRate";
        private const string PropertyUserId = "UserId";
        private const string PropertyWorkflowEntryId = "WorkflowEntryId";

        #endregion

        #region Methods

        private const string MethodRaisePropertyChanged = "RaisePropertyChanged";

        #endregion

        #region Fields

        private const string FieldextensionDataField = "extensionDataField";
        private const string FieldAirlineField = "AirlineField";
        private const string FieldAirlineTicketNumberField = "AirlineTicketNumberField";
        private const string FieldAmountField = "AmountField";
        private const string FieldAmountWithTipsField = "AmountWithTipsField";
        private const string FieldApprovedField = "ApprovedField";
        private const string FieldBilledField = "BilledField";
        private const string FieldCanExceedLimitField = "CanExceedLimitField";
        private const string FieldCityField = "CityField";
        private const string FieldCreateTimestampField = "CreateTimestampField";
        private const string FieldCurrencyField = "CurrencyField";
        private const string FieldCurrencyIdField = "CurrencyIdField";
        private const string FieldCurrentDateField = "CurrentDateField";
        private const string FieldEntryNumberField = "EntryNumberField";
        private const string FieldExchangeRateField = "ExchangeRateField";
        private const string FieldExpenseIdField = "ExpenseIdField";
        private const string FieldExpenseItemField = "ExpenseItemField";
        private const string FieldExpenseReportField = "ExpenseReportField";
        private const string FieldExpenseReportIdField = "ExpenseReportIdField";
        private const string FieldFederalTaxField = "FederalTaxField";
        private const string FieldFinalAmountField = "FinalAmountField";
        private const string FieldGuestsField = "GuestsField";
        private const string FieldInvoiceIdField = "InvoiceIdField";
        private const string FieldIsBillableField = "IsBillableField";
        private const string FieldIsCompletedField = "IsCompletedField";
        private const string FieldIsCustomField = "IsCustomField";
        private const string FieldIsFundedField = "IsFundedField";
        private const string FieldIsPayableField = "IsPayableField";
        private const string FieldIsRandDField = "IsRandDField";
        private const string FieldIsReimbursableField = "IsReimbursableField";
        private const string FieldIsReimbursedField = "IsReimbursedField";
        private const string FieldMarkupPercentageField = "MarkupPercentageField";
        private const string FieldMemoField = "MemoField";
        private const string FieldMilageDestinationField = "MilageDestinationField";
        private const string FieldMilageRateField = "MilageRateField";
        private const string FieldMilageSchemeField = "MilageSchemeField";
        private const string FieldMilageSourceField = "MilageSourceField";
        private const string FieldMilesField = "MilesField";
        private const string FieldModifiedByOfflineField = "ModifiedByOfflineField";
        private const string FieldPaidField = "PaidField";
        private const string FieldPaymentMethodField = "PaymentMethodField";
        private const string FieldPostedField = "PostedField";
        private const string FieldProvincialTaxField = "ProvincialTaxField";
        private const string FieldPurposeField = "PurposeField";
        private const string FieldReceiptIdField = "ReceiptIdField";
        private const string FieldRejectedField = "RejectedField";
        private const string FieldRevenueRecognitionField = "RevenueRecognitionField";
        private const string FieldSiteField = "SiteField";
        private const string FieldSiteIdField = "SiteIdField";
        private const string FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField = "SystemDataObjectsDataClassesIEntityWithKeyEntityKeyField";
        private const string FieldTaskField = "TaskField";
        private const string FieldTaskIdField = "TaskIdField";
        private const string FieldTaxCategoryIdField = "TaxCategoryIdField";
        private const string FieldTaxGroupIdField = "TaxGroupIdField";
        private const string FieldTaxJurisdictionIdField = "TaxJurisdictionIdField";
        private const string FieldTipsField = "TipsField";
        private const string FieldTotalAmountField = "TotalAmountField";
        private const string FieldTotalAmountWithMarkupField = "TotalAmountWithMarkupField";
        private const string FieldTotalInUserCurrencyField = "TotalInUserCurrencyField";
        private const string FieldTotalTaxField = "TotalTaxField";
        private const string FieldUniqueIdField = "UniqueIdField";
        private const string FieldUpdateTimestampField = "UpdateTimestampField";
        private const string FieldUserField = "UserField";
        private const string FieldUserCurrencyIdField = "UserCurrencyIdField";
        private const string FieldUserExchangeRateField = "UserExchangeRateField";
        private const string FieldUserIdField = "UserIdField";
        private const string FieldWorkflowEntryIdField = "WorkflowEntryIdField";

        #endregion

        private Type _expenseEntryInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private ExpenseEntry _expenseEntryInstance;
        private ExpenseEntry _expenseEntryInstanceFixture;

        #region General Initializer : Class (ExpenseEntry) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ExpenseEntry" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _expenseEntryInstanceType = typeof(ExpenseEntry);
            _expenseEntryInstanceFixture = this.Create<ExpenseEntry>(true);
            _expenseEntryInstance = _expenseEntryInstanceFixture ?? this.Create<ExpenseEntry>(false);
            CurrentInstance = _expenseEntryInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ExpenseEntry)

        #region General Initializer : Class (ExpenseEntry) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ExpenseEntry" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRaisePropertyChanged, 0)]
        public void AUT_ExpenseEntry_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_expenseEntryInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ExpenseEntry) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ExpenseEntry" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyExtensionData)]
        [TestCase(PropertyAirline)]
        [TestCase(PropertyAirlineTicketNumber)]
        [TestCase(PropertyAmount)]
        [TestCase(PropertyAmountWithTips)]
        [TestCase(PropertyApproved)]
        [TestCase(PropertyBilled)]
        [TestCase(PropertyCanExceedLimit)]
        [TestCase(PropertyCity)]
        [TestCase(PropertyCreateTimestamp)]
        [TestCase(PropertyCurrency)]
        [TestCase(PropertyCurrencyId)]
        [TestCase(PropertyCurrentDate)]
        [TestCase(PropertyEntryNumber)]
        [TestCase(PropertyExchangeRate)]
        [TestCase(PropertyExpenseId)]
        [TestCase(PropertyExpenseItem)]
        [TestCase(PropertyExpenseReport)]
        [TestCase(PropertyExpenseReportId)]
        [TestCase(PropertyFederalTax)]
        [TestCase(PropertyFinalAmount)]
        [TestCase(PropertyGuests)]
        [TestCase(PropertyInvoiceId)]
        [TestCase(PropertyIsBillable)]
        [TestCase(PropertyIsCompleted)]
        [TestCase(PropertyIsCustom)]
        [TestCase(PropertyIsFunded)]
        [TestCase(PropertyIsPayable)]
        [TestCase(PropertyIsRandD)]
        [TestCase(PropertyIsReimbursable)]
        [TestCase(PropertyIsReimbursed)]
        [TestCase(PropertyMarkupPercentage)]
        [TestCase(PropertyMemo)]
        [TestCase(PropertyMilageDestination)]
        [TestCase(PropertyMilageRate)]
        [TestCase(PropertyMilageScheme)]
        [TestCase(PropertyMilageSource)]
        [TestCase(PropertyMiles)]
        [TestCase(PropertyModifiedByOffline)]
        [TestCase(PropertyPaid)]
        [TestCase(PropertyPaymentMethod)]
        [TestCase(PropertyPosted)]
        [TestCase(PropertyProvincialTax)]
        [TestCase(PropertyPurpose)]
        [TestCase(PropertyReceiptId)]
        [TestCase(PropertyRejected)]
        [TestCase(PropertyRevenueRecognition)]
        [TestCase(PropertySite)]
        [TestCase(PropertySiteId)]
        [TestCase(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCase(PropertyTask)]
        [TestCase(PropertyTaskId)]
        [TestCase(PropertyTaxCategoryId)]
        [TestCase(PropertyTaxGroupId)]
        [TestCase(PropertyTaxJurisdictionId)]
        [TestCase(PropertyTips)]
        [TestCase(PropertyTotalAmount)]
        [TestCase(PropertyTotalAmountWithMarkup)]
        [TestCase(PropertyTotalInUserCurrency)]
        [TestCase(PropertyTotalTax)]
        [TestCase(PropertyUniqueId)]
        [TestCase(PropertyUpdateTimestamp)]
        [TestCase(PropertyUser)]
        [TestCase(PropertyUserCurrencyId)]
        [TestCase(PropertyUserExchangeRate)]
        [TestCase(PropertyUserId)]
        [TestCase(PropertyWorkflowEntryId)]
        public void AUT_ExpenseEntry_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var propertyInfo = this.GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_expenseEntryInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ExpenseEntry) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ExpenseEntry" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldextensionDataField)]
        [TestCase(FieldAirlineField)]
        [TestCase(FieldAirlineTicketNumberField)]
        [TestCase(FieldAmountField)]
        [TestCase(FieldAmountWithTipsField)]
        [TestCase(FieldApprovedField)]
        [TestCase(FieldBilledField)]
        [TestCase(FieldCanExceedLimitField)]
        [TestCase(FieldCityField)]
        [TestCase(FieldCreateTimestampField)]
        [TestCase(FieldCurrencyField)]
        [TestCase(FieldCurrencyIdField)]
        [TestCase(FieldCurrentDateField)]
        [TestCase(FieldEntryNumberField)]
        [TestCase(FieldExchangeRateField)]
        [TestCase(FieldExpenseIdField)]
        [TestCase(FieldExpenseItemField)]
        [TestCase(FieldExpenseReportField)]
        [TestCase(FieldExpenseReportIdField)]
        [TestCase(FieldFederalTaxField)]
        [TestCase(FieldFinalAmountField)]
        [TestCase(FieldGuestsField)]
        [TestCase(FieldInvoiceIdField)]
        [TestCase(FieldIsBillableField)]
        [TestCase(FieldIsCompletedField)]
        [TestCase(FieldIsCustomField)]
        [TestCase(FieldIsFundedField)]
        [TestCase(FieldIsPayableField)]
        [TestCase(FieldIsRandDField)]
        [TestCase(FieldIsReimbursableField)]
        [TestCase(FieldIsReimbursedField)]
        [TestCase(FieldMarkupPercentageField)]
        [TestCase(FieldMemoField)]
        [TestCase(FieldMilageDestinationField)]
        [TestCase(FieldMilageRateField)]
        [TestCase(FieldMilageSchemeField)]
        [TestCase(FieldMilageSourceField)]
        [TestCase(FieldMilesField)]
        [TestCase(FieldModifiedByOfflineField)]
        [TestCase(FieldPaidField)]
        [TestCase(FieldPaymentMethodField)]
        [TestCase(FieldPostedField)]
        [TestCase(FieldProvincialTaxField)]
        [TestCase(FieldPurposeField)]
        [TestCase(FieldReceiptIdField)]
        [TestCase(FieldRejectedField)]
        [TestCase(FieldRevenueRecognitionField)]
        [TestCase(FieldSiteField)]
        [TestCase(FieldSiteIdField)]
        [TestCase(FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField)]
        [TestCase(FieldTaskField)]
        [TestCase(FieldTaskIdField)]
        [TestCase(FieldTaxCategoryIdField)]
        [TestCase(FieldTaxGroupIdField)]
        [TestCase(FieldTaxJurisdictionIdField)]
        [TestCase(FieldTipsField)]
        [TestCase(FieldTotalAmountField)]
        [TestCase(FieldTotalAmountWithMarkupField)]
        [TestCase(FieldTotalInUserCurrencyField)]
        [TestCase(FieldTotalTaxField)]
        [TestCase(FieldUniqueIdField)]
        [TestCase(FieldUpdateTimestampField)]
        [TestCase(FieldUserField)]
        [TestCase(FieldUserCurrencyIdField)]
        [TestCase(FieldUserExchangeRateField)]
        [TestCase(FieldUserIdField)]
        [TestCase(FieldWorkflowEntryIdField)]
        public void AUT_ExpenseEntry_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_expenseEntryInstanceFixture, 
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
        ///     Class (<see cref="ExpenseEntry" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ExpenseEntry_Is_Instance_Present_Test()
        {
            // Assert
            _expenseEntryInstanceType.ShouldNotBeNull();
            _expenseEntryInstance.ShouldNotBeNull();
            _expenseEntryInstanceFixture.ShouldNotBeNull();
            _expenseEntryInstance.ShouldBeAssignableTo<ExpenseEntry>();
            _expenseEntryInstanceFixture.ShouldBeAssignableTo<ExpenseEntry>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ExpenseEntry) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ExpenseEntry_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ExpenseEntry instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _expenseEntryInstanceType.ShouldNotBeNull();
            _expenseEntryInstance.ShouldNotBeNull();
            _expenseEntryInstanceFixture.ShouldNotBeNull();
            _expenseEntryInstance.ShouldBeAssignableTo<ExpenseEntry>();
            _expenseEntryInstanceFixture.ShouldBeAssignableTo<ExpenseEntry>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ExpenseEntry) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(System.Runtime.Serialization.ExtensionDataObject) , PropertyExtensionData)]
        [TestCaseGeneric(typeof(string) , PropertyAirline)]
        [TestCaseGeneric(typeof(string) , PropertyAirlineTicketNumber)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyAmount)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyAmountWithTips)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyApproved)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyBilled)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyCanExceedLimit)]
        [TestCaseGeneric(typeof(string) , PropertyCity)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyCreateTimestamp)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.Currency) , PropertyCurrency)]
        [TestCaseGeneric(typeof(int) , PropertyCurrencyId)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyCurrentDate)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyEntryNumber)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyExchangeRate)]
        [TestCaseGeneric(typeof(int) , PropertyExpenseId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.ExpenseItem) , PropertyExpenseItem)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.ExpenseReport) , PropertyExpenseReport)]
        [TestCaseGeneric(typeof(int) , PropertyExpenseReportId)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyFederalTax)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyFinalAmount)]
        [TestCaseGeneric(typeof(string) , PropertyGuests)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyInvoiceId)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsBillable)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsCompleted)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsCustom)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsFunded)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsPayable)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsRandD)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsReimbursable)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsReimbursed)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyMarkupPercentage)]
        [TestCaseGeneric(typeof(string) , PropertyMemo)]
        [TestCaseGeneric(typeof(string) , PropertyMilageDestination)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyMilageRate)]
        [TestCaseGeneric(typeof(string) , PropertyMilageScheme)]
        [TestCaseGeneric(typeof(string) , PropertyMilageSource)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyMiles)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyModifiedByOffline)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyPaid)]
        [TestCaseGeneric(typeof(string) , PropertyPaymentMethod)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyPosted)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyProvincialTax)]
        [TestCaseGeneric(typeof(string) , PropertyPurpose)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyReceiptId)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyRejected)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyRevenueRecognition)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.Site) , PropertySite)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertySiteId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.EntityKey) , PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.Task) , PropertyTask)]
        [TestCaseGeneric(typeof(int) , PropertyTaskId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTaxCategoryId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTaxGroupId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTaxJurisdictionId)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyTips)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyTotalAmount)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyTotalAmountWithMarkup)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyTotalInUserCurrency)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyTotalTax)]
        [TestCaseGeneric(typeof(int) , PropertyUniqueId)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyUpdateTimestamp)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.User) , PropertyUser)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyUserCurrencyId)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyUserExchangeRate)]
        [TestCaseGeneric(typeof(int) , PropertyUserId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyWorkflowEntryId)]
        public void AUT_ExpenseEntry_Property_Type_Verify_Explore_By_Name_Test<T>(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);

            // Assert
            ShouldlyExtension.PropertyTypeVerify<ExpenseEntry, T>(_expenseEntryInstance, name, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (Airline) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_Airline_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAirline);
            var propertyInfo  = this.GetPropertyInfo(PropertyAirline);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (AirlineTicketNumber) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_AirlineTicketNumber_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAirlineTicketNumber);
            var propertyInfo  = this.GetPropertyInfo(PropertyAirlineTicketNumber);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (Amount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_Amount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ExpenseEntry) => Property (AmountWithTips) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_AmountWithTips_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAmountWithTips);
            var propertyInfo  = this.GetPropertyInfo(PropertyAmountWithTips);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (Approved) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_Approved_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyApproved);
            var propertyInfo  = this.GetPropertyInfo(PropertyApproved);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (Billed) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_Billed_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ExpenseEntry) => Property (CanExceedLimit) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_CanExceedLimit_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCanExceedLimit);
            var propertyInfo  = this.GetPropertyInfo(PropertyCanExceedLimit);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (City) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_City_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCity);
            var propertyInfo  = this.GetPropertyInfo(PropertyCity);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (CreateTimestamp) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_CreateTimestamp_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCreateTimestamp);
            var propertyInfo  = this.GetPropertyInfo(PropertyCreateTimestamp);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (Currency) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Currency_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCurrency);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyCurrency);
            Action currentAction = () => propertyInfo.SetValue(_expenseEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (Currency) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_Currency_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ExpenseEntry) => Property (CurrencyId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_CurrencyId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ExpenseEntry) => Property (CurrentDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_CurrentDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ExpenseEntry) => Property (EntryNumber) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_EntryNumber_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyEntryNumber);
            var propertyInfo  = this.GetPropertyInfo(PropertyEntryNumber);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (ExchangeRate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_ExchangeRate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExchangeRate);
            var propertyInfo  = this.GetPropertyInfo(PropertyExchangeRate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (ExpenseId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_ExpenseId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExpenseId);
            var propertyInfo  = this.GetPropertyInfo(PropertyExpenseId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (ExpenseItem) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_ExpenseItem_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExpenseItem);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExpenseItem);
            Action currentAction = () => propertyInfo.SetValue(_expenseEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (ExpenseItem) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_ExpenseItem_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExpenseItem);
            var propertyInfo  = this.GetPropertyInfo(PropertyExpenseItem);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (ExpenseReport) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_ExpenseReport_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExpenseReport);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExpenseReport);
            Action currentAction = () => propertyInfo.SetValue(_expenseEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (ExpenseReport) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_ExpenseReport_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExpenseReport);
            var propertyInfo  = this.GetPropertyInfo(PropertyExpenseReport);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (ExpenseReportId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_ExpenseReportId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExpenseReportId);
            var propertyInfo  = this.GetPropertyInfo(PropertyExpenseReportId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (ExtensionData) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_ExtensionData_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExtensionData);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExtensionData);
            Action currentAction = () => propertyInfo.SetValue(_expenseEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (ExtensionData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_ExtensionData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ExpenseEntry) => Property (FederalTax) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_FederalTax_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyFederalTax);
            var propertyInfo  = this.GetPropertyInfo(PropertyFederalTax);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (FinalAmount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_FinalAmount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyFinalAmount);
            var propertyInfo  = this.GetPropertyInfo(PropertyFinalAmount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (Guests) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_Guests_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyGuests);
            var propertyInfo  = this.GetPropertyInfo(PropertyGuests);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (InvoiceId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_InvoiceId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ExpenseEntry) => Property (IsBillable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_IsBillable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ExpenseEntry) => Property (IsCompleted) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_IsCompleted_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsCompleted);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsCompleted);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (IsCustom) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_IsCustom_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsCustom);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsCustom);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (IsFunded) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_IsFunded_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ExpenseEntry) => Property (IsPayable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_IsPayable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsPayable);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsPayable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (IsRandD) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_IsRandD_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ExpenseEntry) => Property (IsReimbursable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_IsReimbursable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsReimbursable);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsReimbursable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (IsReimbursed) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_IsReimbursed_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsReimbursed);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsReimbursed);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (MarkupPercentage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_MarkupPercentage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMarkupPercentage);
            var propertyInfo  = this.GetPropertyInfo(PropertyMarkupPercentage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (Memo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_Memo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMemo);
            var propertyInfo  = this.GetPropertyInfo(PropertyMemo);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (MilageDestination) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_MilageDestination_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMilageDestination);
            var propertyInfo  = this.GetPropertyInfo(PropertyMilageDestination);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (MilageRate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_MilageRate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMilageRate);
            var propertyInfo  = this.GetPropertyInfo(PropertyMilageRate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (MilageScheme) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_MilageScheme_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMilageScheme);
            var propertyInfo  = this.GetPropertyInfo(PropertyMilageScheme);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (MilageSource) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_MilageSource_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMilageSource);
            var propertyInfo  = this.GetPropertyInfo(PropertyMilageSource);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (Miles) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_Miles_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMiles);
            var propertyInfo  = this.GetPropertyInfo(PropertyMiles);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (ModifiedByOffline) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_ModifiedByOffline_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyModifiedByOffline);
            var propertyInfo  = this.GetPropertyInfo(PropertyModifiedByOffline);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (Paid) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_Paid_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPaid);
            var propertyInfo  = this.GetPropertyInfo(PropertyPaid);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (PaymentMethod) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_PaymentMethod_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPaymentMethod);
            var propertyInfo  = this.GetPropertyInfo(PropertyPaymentMethod);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (Posted) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_Posted_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ExpenseEntry) => Property (ProvincialTax) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_ProvincialTax_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProvincialTax);
            var propertyInfo  = this.GetPropertyInfo(PropertyProvincialTax);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (Purpose) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_Purpose_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPurpose);
            var propertyInfo  = this.GetPropertyInfo(PropertyPurpose);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (ReceiptId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_ReceiptId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyReceiptId);
            var propertyInfo  = this.GetPropertyInfo(PropertyReceiptId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (Rejected) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_Rejected_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRejected);
            var propertyInfo  = this.GetPropertyInfo(PropertyRejected);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (RevenueRecognition) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_RevenueRecognition_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRevenueRecognition);
            var propertyInfo  = this.GetPropertyInfo(PropertyRevenueRecognition);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (Site) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Site_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySite);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySite);
            Action currentAction = () => propertyInfo.SetValue(_expenseEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (Site) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_Site_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySite);
            var propertyInfo  = this.GetPropertyInfo(PropertySite);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (SiteId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_SiteId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySiteId);
            var propertyInfo  = this.GetPropertyInfo(PropertySiteId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            Action currentAction = () => propertyInfo.SetValue(_expenseEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ExpenseEntry) => Property (Task) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Task_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTask);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTask);
            Action currentAction = () => propertyInfo.SetValue(_expenseEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (Task) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_Task_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTask);
            var propertyInfo  = this.GetPropertyInfo(PropertyTask);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (TaskId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_TaskId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ExpenseEntry) => Property (TaxCategoryId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_TaxCategoryId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTaxCategoryId);
            var propertyInfo  = this.GetPropertyInfo(PropertyTaxCategoryId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (TaxGroupId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_TaxGroupId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTaxGroupId);
            var propertyInfo  = this.GetPropertyInfo(PropertyTaxGroupId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (TaxJurisdictionId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_TaxJurisdictionId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTaxJurisdictionId);
            var propertyInfo  = this.GetPropertyInfo(PropertyTaxJurisdictionId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (Tips) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_Tips_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTips);
            var propertyInfo  = this.GetPropertyInfo(PropertyTips);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (TotalAmount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_TotalAmount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTotalAmount);
            var propertyInfo  = this.GetPropertyInfo(PropertyTotalAmount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (TotalAmountWithMarkup) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_TotalAmountWithMarkup_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTotalAmountWithMarkup);
            var propertyInfo  = this.GetPropertyInfo(PropertyTotalAmountWithMarkup);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (TotalInUserCurrency) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_TotalInUserCurrency_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTotalInUserCurrency);
            var propertyInfo  = this.GetPropertyInfo(PropertyTotalInUserCurrency);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (TotalTax) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_TotalTax_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTotalTax);
            var propertyInfo  = this.GetPropertyInfo(PropertyTotalTax);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (UniqueId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_UniqueId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ExpenseEntry) => Property (UpdateTimestamp) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_UpdateTimestamp_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ExpenseEntry) => Property (User) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_User_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUser);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyUser);
            Action currentAction = () => propertyInfo.SetValue(_expenseEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (User) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_User_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUser);
            var propertyInfo  = this.GetPropertyInfo(PropertyUser);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (UserCurrencyId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_UserCurrencyId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ExpenseEntry) => Property (UserExchangeRate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_UserExchangeRate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUserExchangeRate);
            var propertyInfo  = this.GetPropertyInfo(PropertyUserExchangeRate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExpenseEntry) => Property (UserId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_UserId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ExpenseEntry) => Property (WorkflowEntryId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ExpenseEntry_Public_Class_WorkflowEntryId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWorkflowEntryId);
            var propertyInfo  = this.GetPropertyInfo(PropertyWorkflowEntryId);

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
        private void AUT_ExpenseEntry_RaisePropertyChanged_Method_Call_Internally(Type[] types)
        {
            var methodRaisePropertyChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_expenseEntryInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExpenseEntry_RaisePropertyChanged_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_expenseEntryInstanceFixture, parametersOfRaisePropertyChanged);

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
        public void AUT_ExpenseEntry_RaisePropertyChanged_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_expenseEntryInstance, MethodRaisePropertyChanged, parametersOfRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes);

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
        public void AUT_ExpenseEntry_RaisePropertyChanged_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ExpenseEntry_RaisePropertyChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_expenseEntryInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);

            // Assert
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ExpenseEntry_RaisePropertyChanged_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_expenseEntryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}