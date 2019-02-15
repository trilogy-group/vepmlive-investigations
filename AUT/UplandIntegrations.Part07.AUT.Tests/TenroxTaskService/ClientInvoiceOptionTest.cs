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
using ClientInvoiceOption = UplandIntegrations.TenroxTaskService;

namespace UplandIntegrations.TenroxTaskService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxTaskService.ClientInvoiceOption" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxTaskService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    public partial class ClientInvoiceOptionTest : AbstractBaseSetupV3Test
    {
        public ClientInvoiceOptionTest() : base(typeof(ClientInvoiceOption))
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

        #region General Initializer : Class (ClientInvoiceOption) Initializer

        #region Properties

        private const string PropertyExtensionData = "ExtensionData";
        private const string PropertyAccountsReceivableAccount = "AccountsReceivableAccount";
        private const string PropertyApplyClientTax = "ApplyClientTax";
        private const string PropertyApplyTaxToExpense = "ApplyTaxToExpense";
        private const string PropertyBillAllProjects = "BillAllProjects";
        private const string PropertyBillAllUserAccounts = "BillAllUserAccounts";
        private const string PropertyBillAllUsers = "BillAllUsers";
        private const string PropertyBillingContactId = "BillingContactId";
        private const string PropertyClient = "Client";
        private const string PropertyClientId = "ClientId";
        private const string PropertyCompanyId = "CompanyId";
        private const string PropertyCurrencyId = "CurrencyId";
        private const string PropertyCurrentInvoiceNumber = "CurrentInvoiceNumber";
        private const string PropertyCurrentTempInvoiceNumber = "CurrentTempInvoiceNumber";
        private const string PropertyCycleDuration = "CycleDuration";
        private const string PropertyCycleDurationUnit = "CycleDurationUnit";
        private const string PropertyDiscountRate = "DiscountRate";
        private const string PropertyDisplayRatePerUser = "DisplayRatePerUser";
        private const string PropertyDisplayTotalPerEntry = "DisplayTotalPerEntry";
        private const string PropertyDisplayUnits = "DisplayUnits";
        private const string PropertyDisplayWorkDone = "DisplayWorkDone";
        private const string PropertyExchangeRateOption = "ExchangeRateOption";
        private const string PropertyGroupBy = "GroupBy";
        private const string PropertyHoursPerDay = "HoursPerDay";
        private const string PropertyIncludeBillableAdjustments = "IncludeBillableAdjustments";
        private const string PropertyIncludeBillableExpenses = "IncludeBillableExpenses";
        private const string PropertyIncludeBillableItems = "IncludeBillableItems";
        private const string PropertyIncludeBillableTime = "IncludeBillableTime";
        private const string PropertyIncludeLineItemNotes = "IncludeLineItemNotes";
        private const string PropertyIncludeOvertimeEntries = "IncludeOvertimeEntries";
        private const string PropertyIncludeSplitBillingPerProject = "IncludeSplitBillingPerProject";
        private const string PropertyIncludeTimeEntryNotes = "IncludeTimeEntryNotes";
        private const string PropertyInforceWorkflow = "InforceWorkflow";
        private const string PropertyInvoiceAllBillableItems = "InvoiceAllBillableItems";
        private const string PropertyInvoiceAllCharges = "InvoiceAllCharges";
        private const string PropertyInvoiceAllExpenses = "InvoiceAllExpenses";
        private const string PropertyInvoiceAllUsers = "InvoiceAllUsers";
        private const string PropertyInvoiceNumberPrefix = "InvoiceNumberPrefix";
        private const string PropertyInvoiceTemplateId = "InvoiceTemplateId";
        private const string PropertyIsOverridable = "IsOverridable";
        private const string PropertyIsPeriodBasedCycle = "IsPeriodBasedCycle";
        private const string PropertyIssuerContactId = "IssuerContactId";
        private const string PropertyLastInvoiceCreateDate = "LastInvoiceCreateDate";
        private const string PropertyLastInvoicedId = "LastInvoicedId";
        private const string PropertyLastInvoicedNumber = "LastInvoicedNumber";
        private const string PropertyLastIssuedDate = "LastIssuedDate";
        private const string PropertyLastIssuedInvoiceId = "LastIssuedInvoiceId";
        private const string PropertyLastIssuedNumber = "LastIssuedNumber";
        private const string PropertyNextInvoiceBatchStart = "NextInvoiceBatchStart";
        private const string PropertyNote1 = "Note1";
        private const string PropertyNote2 = "Note2";
        private const string PropertyNote3 = "Note3";
        private const string PropertyNoteType = "NoteType";
        private const string PropertyNotifyClientOnInvoice = "NotifyClientOnInvoice";
        private const string PropertyOverrideGLobalInvoiceNumber = "OverrideGLobalInvoiceNumber";
        private const string PropertyPaymentTerms = "PaymentTerms";
        private const string PropertyPreBillingReportTemplate = "PreBillingReportTemplate";
        private const string PropertyPreBillingWorkflowId = "PreBillingWorkflowId";
        private const string PropertyReportTemplateId = "ReportTemplateId";
        private const string PropertyShippingContactId = "ShippingContactId";
        private const string PropertyShowOvertimeEntriesInReport = "ShowOvertimeEntriesInReport";
        private const string PropertyStyle = "Style";
        private const string PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey";
        private const string PropertyTaxGroupId = "TaxGroupId";
        private const string PropertyTempInvoiceNumber = "TempInvoiceNumber";
        private const string PropertyUniqueId = "UniqueId";
        private const string PropertyUseDatabaseStartDate = "UseDatabaseStartDate";
        private const string PropertyWorkflowMapId = "WorkflowMapId";

        #endregion

        #region Methods

        private const string MethodRaisePropertyChanged = "RaisePropertyChanged";

        #endregion

        #region Fields

        private const string FieldextensionDataField = "extensionDataField";
        private const string FieldAccountsReceivableAccountField = "AccountsReceivableAccountField";
        private const string FieldApplyClientTaxField = "ApplyClientTaxField";
        private const string FieldApplyTaxToExpenseField = "ApplyTaxToExpenseField";
        private const string FieldBillAllProjectsField = "BillAllProjectsField";
        private const string FieldBillAllUserAccountsField = "BillAllUserAccountsField";
        private const string FieldBillAllUsersField = "BillAllUsersField";
        private const string FieldBillingContactIdField = "BillingContactIdField";
        private const string FieldClientField = "ClientField";
        private const string FieldClientIdField = "ClientIdField";
        private const string FieldCompanyIdField = "CompanyIdField";
        private const string FieldCurrencyIdField = "CurrencyIdField";
        private const string FieldCurrentInvoiceNumberField = "CurrentInvoiceNumberField";
        private const string FieldCurrentTempInvoiceNumberField = "CurrentTempInvoiceNumberField";
        private const string FieldCycleDurationField = "CycleDurationField";
        private const string FieldCycleDurationUnitField = "CycleDurationUnitField";
        private const string FieldDiscountRateField = "DiscountRateField";
        private const string FieldDisplayRatePerUserField = "DisplayRatePerUserField";
        private const string FieldDisplayTotalPerEntryField = "DisplayTotalPerEntryField";
        private const string FieldDisplayUnitsField = "DisplayUnitsField";
        private const string FieldDisplayWorkDoneField = "DisplayWorkDoneField";
        private const string FieldExchangeRateOptionField = "ExchangeRateOptionField";
        private const string FieldGroupByField = "GroupByField";
        private const string FieldHoursPerDayField = "HoursPerDayField";
        private const string FieldIncludeBillableAdjustmentsField = "IncludeBillableAdjustmentsField";
        private const string FieldIncludeBillableExpensesField = "IncludeBillableExpensesField";
        private const string FieldIncludeBillableItemsField = "IncludeBillableItemsField";
        private const string FieldIncludeBillableTimeField = "IncludeBillableTimeField";
        private const string FieldIncludeLineItemNotesField = "IncludeLineItemNotesField";
        private const string FieldIncludeOvertimeEntriesField = "IncludeOvertimeEntriesField";
        private const string FieldIncludeSplitBillingPerProjectField = "IncludeSplitBillingPerProjectField";
        private const string FieldIncludeTimeEntryNotesField = "IncludeTimeEntryNotesField";
        private const string FieldInforceWorkflowField = "InforceWorkflowField";
        private const string FieldInvoiceAllBillableItemsField = "InvoiceAllBillableItemsField";
        private const string FieldInvoiceAllChargesField = "InvoiceAllChargesField";
        private const string FieldInvoiceAllExpensesField = "InvoiceAllExpensesField";
        private const string FieldInvoiceAllUsersField = "InvoiceAllUsersField";
        private const string FieldInvoiceNumberPrefixField = "InvoiceNumberPrefixField";
        private const string FieldInvoiceTemplateIdField = "InvoiceTemplateIdField";
        private const string FieldIsOverridableField = "IsOverridableField";
        private const string FieldIsPeriodBasedCycleField = "IsPeriodBasedCycleField";
        private const string FieldIssuerContactIdField = "IssuerContactIdField";
        private const string FieldLastInvoiceCreateDateField = "LastInvoiceCreateDateField";
        private const string FieldLastInvoicedIdField = "LastInvoicedIdField";
        private const string FieldLastInvoicedNumberField = "LastInvoicedNumberField";
        private const string FieldLastIssuedDateField = "LastIssuedDateField";
        private const string FieldLastIssuedInvoiceIdField = "LastIssuedInvoiceIdField";
        private const string FieldLastIssuedNumberField = "LastIssuedNumberField";
        private const string FieldNextInvoiceBatchStartField = "NextInvoiceBatchStartField";
        private const string FieldNote1Field = "Note1Field";
        private const string FieldNote2Field = "Note2Field";
        private const string FieldNote3Field = "Note3Field";
        private const string FieldNoteTypeField = "NoteTypeField";
        private const string FieldNotifyClientOnInvoiceField = "NotifyClientOnInvoiceField";
        private const string FieldOverrideGLobalInvoiceNumberField = "OverrideGLobalInvoiceNumberField";
        private const string FieldPaymentTermsField = "PaymentTermsField";
        private const string FieldPreBillingReportTemplateField = "PreBillingReportTemplateField";
        private const string FieldPreBillingWorkflowIdField = "PreBillingWorkflowIdField";
        private const string FieldReportTemplateIdField = "ReportTemplateIdField";
        private const string FieldShippingContactIdField = "ShippingContactIdField";
        private const string FieldShowOvertimeEntriesInReportField = "ShowOvertimeEntriesInReportField";
        private const string FieldStyleField = "StyleField";
        private const string FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField = "SystemDataObjectsDataClassesIEntityWithKeyEntityKeyField";
        private const string FieldTaxGroupIdField = "TaxGroupIdField";
        private const string FieldTempInvoiceNumberField = "TempInvoiceNumberField";
        private const string FieldUniqueIdField = "UniqueIdField";
        private const string FieldUseDatabaseStartDateField = "UseDatabaseStartDateField";
        private const string FieldWorkflowMapIdField = "WorkflowMapIdField";

        #endregion

        private Type _clientInvoiceOptionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private ClientInvoiceOption _clientInvoiceOptionInstance;
        private ClientInvoiceOption _clientInvoiceOptionInstanceFixture;

        #region General Initializer : Class (ClientInvoiceOption) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ClientInvoiceOption" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _clientInvoiceOptionInstanceType = typeof(ClientInvoiceOption);
            _clientInvoiceOptionInstanceFixture = this.Create<ClientInvoiceOption>(true);
            _clientInvoiceOptionInstance = _clientInvoiceOptionInstanceFixture ?? this.Create<ClientInvoiceOption>(false);
            CurrentInstance = _clientInvoiceOptionInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ClientInvoiceOption)

        #region General Initializer : Class (ClientInvoiceOption) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ClientInvoiceOption" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRaisePropertyChanged, 0)]
        public void AUT_ClientInvoiceOption_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_clientInvoiceOptionInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ClientInvoiceOption) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ClientInvoiceOption" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyExtensionData)]
        [TestCase(PropertyAccountsReceivableAccount)]
        [TestCase(PropertyApplyClientTax)]
        [TestCase(PropertyApplyTaxToExpense)]
        [TestCase(PropertyBillAllProjects)]
        [TestCase(PropertyBillAllUserAccounts)]
        [TestCase(PropertyBillAllUsers)]
        [TestCase(PropertyBillingContactId)]
        [TestCase(PropertyClient)]
        [TestCase(PropertyClientId)]
        [TestCase(PropertyCompanyId)]
        [TestCase(PropertyCurrencyId)]
        [TestCase(PropertyCurrentInvoiceNumber)]
        [TestCase(PropertyCurrentTempInvoiceNumber)]
        [TestCase(PropertyCycleDuration)]
        [TestCase(PropertyCycleDurationUnit)]
        [TestCase(PropertyDiscountRate)]
        [TestCase(PropertyDisplayRatePerUser)]
        [TestCase(PropertyDisplayTotalPerEntry)]
        [TestCase(PropertyDisplayUnits)]
        [TestCase(PropertyDisplayWorkDone)]
        [TestCase(PropertyExchangeRateOption)]
        [TestCase(PropertyGroupBy)]
        [TestCase(PropertyHoursPerDay)]
        [TestCase(PropertyIncludeBillableAdjustments)]
        [TestCase(PropertyIncludeBillableExpenses)]
        [TestCase(PropertyIncludeBillableItems)]
        [TestCase(PropertyIncludeBillableTime)]
        [TestCase(PropertyIncludeLineItemNotes)]
        [TestCase(PropertyIncludeOvertimeEntries)]
        [TestCase(PropertyIncludeSplitBillingPerProject)]
        [TestCase(PropertyIncludeTimeEntryNotes)]
        [TestCase(PropertyInforceWorkflow)]
        [TestCase(PropertyInvoiceAllBillableItems)]
        [TestCase(PropertyInvoiceAllCharges)]
        [TestCase(PropertyInvoiceAllExpenses)]
        [TestCase(PropertyInvoiceAllUsers)]
        [TestCase(PropertyInvoiceNumberPrefix)]
        [TestCase(PropertyInvoiceTemplateId)]
        [TestCase(PropertyIsOverridable)]
        [TestCase(PropertyIsPeriodBasedCycle)]
        [TestCase(PropertyIssuerContactId)]
        [TestCase(PropertyLastInvoiceCreateDate)]
        [TestCase(PropertyLastInvoicedId)]
        [TestCase(PropertyLastInvoicedNumber)]
        [TestCase(PropertyLastIssuedDate)]
        [TestCase(PropertyLastIssuedInvoiceId)]
        [TestCase(PropertyLastIssuedNumber)]
        [TestCase(PropertyNextInvoiceBatchStart)]
        [TestCase(PropertyNote1)]
        [TestCase(PropertyNote2)]
        [TestCase(PropertyNote3)]
        [TestCase(PropertyNoteType)]
        [TestCase(PropertyNotifyClientOnInvoice)]
        [TestCase(PropertyOverrideGLobalInvoiceNumber)]
        [TestCase(PropertyPaymentTerms)]
        [TestCase(PropertyPreBillingReportTemplate)]
        [TestCase(PropertyPreBillingWorkflowId)]
        [TestCase(PropertyReportTemplateId)]
        [TestCase(PropertyShippingContactId)]
        [TestCase(PropertyShowOvertimeEntriesInReport)]
        [TestCase(PropertyStyle)]
        [TestCase(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCase(PropertyTaxGroupId)]
        [TestCase(PropertyTempInvoiceNumber)]
        [TestCase(PropertyUniqueId)]
        [TestCase(PropertyUseDatabaseStartDate)]
        [TestCase(PropertyWorkflowMapId)]
        public void AUT_ClientInvoiceOption_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var propertyInfo = this.GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_clientInvoiceOptionInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ClientInvoiceOption) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ClientInvoiceOption" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldextensionDataField)]
        [TestCase(FieldAccountsReceivableAccountField)]
        [TestCase(FieldApplyClientTaxField)]
        [TestCase(FieldApplyTaxToExpenseField)]
        [TestCase(FieldBillAllProjectsField)]
        [TestCase(FieldBillAllUserAccountsField)]
        [TestCase(FieldBillAllUsersField)]
        [TestCase(FieldBillingContactIdField)]
        [TestCase(FieldClientField)]
        [TestCase(FieldClientIdField)]
        [TestCase(FieldCompanyIdField)]
        [TestCase(FieldCurrencyIdField)]
        [TestCase(FieldCurrentInvoiceNumberField)]
        [TestCase(FieldCurrentTempInvoiceNumberField)]
        [TestCase(FieldCycleDurationField)]
        [TestCase(FieldCycleDurationUnitField)]
        [TestCase(FieldDiscountRateField)]
        [TestCase(FieldDisplayRatePerUserField)]
        [TestCase(FieldDisplayTotalPerEntryField)]
        [TestCase(FieldDisplayUnitsField)]
        [TestCase(FieldDisplayWorkDoneField)]
        [TestCase(FieldExchangeRateOptionField)]
        [TestCase(FieldGroupByField)]
        [TestCase(FieldHoursPerDayField)]
        [TestCase(FieldIncludeBillableAdjustmentsField)]
        [TestCase(FieldIncludeBillableExpensesField)]
        [TestCase(FieldIncludeBillableItemsField)]
        [TestCase(FieldIncludeBillableTimeField)]
        [TestCase(FieldIncludeLineItemNotesField)]
        [TestCase(FieldIncludeOvertimeEntriesField)]
        [TestCase(FieldIncludeSplitBillingPerProjectField)]
        [TestCase(FieldIncludeTimeEntryNotesField)]
        [TestCase(FieldInforceWorkflowField)]
        [TestCase(FieldInvoiceAllBillableItemsField)]
        [TestCase(FieldInvoiceAllChargesField)]
        [TestCase(FieldInvoiceAllExpensesField)]
        [TestCase(FieldInvoiceAllUsersField)]
        [TestCase(FieldInvoiceNumberPrefixField)]
        [TestCase(FieldInvoiceTemplateIdField)]
        [TestCase(FieldIsOverridableField)]
        [TestCase(FieldIsPeriodBasedCycleField)]
        [TestCase(FieldIssuerContactIdField)]
        [TestCase(FieldLastInvoiceCreateDateField)]
        [TestCase(FieldLastInvoicedIdField)]
        [TestCase(FieldLastInvoicedNumberField)]
        [TestCase(FieldLastIssuedDateField)]
        [TestCase(FieldLastIssuedInvoiceIdField)]
        [TestCase(FieldLastIssuedNumberField)]
        [TestCase(FieldNextInvoiceBatchStartField)]
        [TestCase(FieldNote1Field)]
        [TestCase(FieldNote2Field)]
        [TestCase(FieldNote3Field)]
        [TestCase(FieldNoteTypeField)]
        [TestCase(FieldNotifyClientOnInvoiceField)]
        [TestCase(FieldOverrideGLobalInvoiceNumberField)]
        [TestCase(FieldPaymentTermsField)]
        [TestCase(FieldPreBillingReportTemplateField)]
        [TestCase(FieldPreBillingWorkflowIdField)]
        [TestCase(FieldReportTemplateIdField)]
        [TestCase(FieldShippingContactIdField)]
        [TestCase(FieldShowOvertimeEntriesInReportField)]
        [TestCase(FieldStyleField)]
        [TestCase(FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField)]
        [TestCase(FieldTaxGroupIdField)]
        [TestCase(FieldTempInvoiceNumberField)]
        [TestCase(FieldUniqueIdField)]
        [TestCase(FieldUseDatabaseStartDateField)]
        [TestCase(FieldWorkflowMapIdField)]
        public void AUT_ClientInvoiceOption_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_clientInvoiceOptionInstanceFixture, 
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
        ///     Class (<see cref="ClientInvoiceOption" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ClientInvoiceOption_Is_Instance_Present_Test()
        {
            // Assert
            _clientInvoiceOptionInstanceType.ShouldNotBeNull();
            _clientInvoiceOptionInstance.ShouldNotBeNull();
            _clientInvoiceOptionInstanceFixture.ShouldNotBeNull();
            _clientInvoiceOptionInstance.ShouldBeAssignableTo<ClientInvoiceOption>();
            _clientInvoiceOptionInstanceFixture.ShouldBeAssignableTo<ClientInvoiceOption>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ClientInvoiceOption) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ClientInvoiceOption_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ClientInvoiceOption instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _clientInvoiceOptionInstanceType.ShouldNotBeNull();
            _clientInvoiceOptionInstance.ShouldNotBeNull();
            _clientInvoiceOptionInstanceFixture.ShouldNotBeNull();
            _clientInvoiceOptionInstance.ShouldBeAssignableTo<ClientInvoiceOption>();
            _clientInvoiceOptionInstanceFixture.ShouldBeAssignableTo<ClientInvoiceOption>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ClientInvoiceOption) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(System.Runtime.Serialization.ExtensionDataObject) , PropertyExtensionData)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyAccountsReceivableAccount)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyApplyClientTax)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyApplyTaxToExpense)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyBillAllProjects)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyBillAllUserAccounts)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyBillAllUsers)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyBillingContactId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxTaskService.Client) , PropertyClient)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyClientId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyCompanyId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyCurrencyId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyCurrentInvoiceNumber)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyCurrentTempInvoiceNumber)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyCycleDuration)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyCycleDurationUnit)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyDiscountRate)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyDisplayRatePerUser)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyDisplayTotalPerEntry)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyDisplayUnits)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyDisplayWorkDone)]
        [TestCaseGeneric(typeof(string) , PropertyExchangeRateOption)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyGroupBy)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyHoursPerDay)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIncludeBillableAdjustments)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIncludeBillableExpenses)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIncludeBillableItems)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIncludeBillableTime)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIncludeLineItemNotes)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIncludeOvertimeEntries)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIncludeSplitBillingPerProject)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIncludeTimeEntryNotes)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyInforceWorkflow)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyInvoiceAllBillableItems)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyInvoiceAllCharges)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyInvoiceAllExpenses)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyInvoiceAllUsers)]
        [TestCaseGeneric(typeof(string) , PropertyInvoiceNumberPrefix)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyInvoiceTemplateId)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsOverridable)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsPeriodBasedCycle)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyIssuerContactId)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyLastInvoiceCreateDate)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyLastInvoicedId)]
        [TestCaseGeneric(typeof(string) , PropertyLastInvoicedNumber)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyLastIssuedDate)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyLastIssuedInvoiceId)]
        [TestCaseGeneric(typeof(string) , PropertyLastIssuedNumber)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertyNextInvoiceBatchStart)]
        [TestCaseGeneric(typeof(string) , PropertyNote1)]
        [TestCaseGeneric(typeof(string) , PropertyNote2)]
        [TestCaseGeneric(typeof(string) , PropertyNote3)]
        [TestCaseGeneric(typeof(string) , PropertyNoteType)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyNotifyClientOnInvoice)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyOverrideGLobalInvoiceNumber)]
        [TestCaseGeneric(typeof(string) , PropertyPaymentTerms)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyPreBillingReportTemplate)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyPreBillingWorkflowId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyReportTemplateId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyShippingContactId)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyShowOvertimeEntriesInReport)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyStyle)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxTaskService.EntityKey) , PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTaxGroupId)]
        [TestCaseGeneric(typeof(string) , PropertyTempInvoiceNumber)]
        [TestCaseGeneric(typeof(int) , PropertyUniqueId)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyUseDatabaseStartDate)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyWorkflowMapId)]
        public void AUT_ClientInvoiceOption_Property_Type_Verify_Explore_By_Name_Test<T>(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);

            // Assert
            ShouldlyExtension.PropertyTypeVerify<ClientInvoiceOption, T>(_clientInvoiceOptionInstance, name, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (AccountsReceivableAccount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_AccountsReceivableAccount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAccountsReceivableAccount);
            var propertyInfo  = this.GetPropertyInfo(PropertyAccountsReceivableAccount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (ApplyClientTax) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_ApplyClientTax_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyApplyClientTax);
            var propertyInfo  = this.GetPropertyInfo(PropertyApplyClientTax);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (ApplyTaxToExpense) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_ApplyTaxToExpense_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyApplyTaxToExpense);
            var propertyInfo  = this.GetPropertyInfo(PropertyApplyTaxToExpense);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (BillAllProjects) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_BillAllProjects_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBillAllProjects);
            var propertyInfo  = this.GetPropertyInfo(PropertyBillAllProjects);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (BillAllUserAccounts) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_BillAllUserAccounts_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBillAllUserAccounts);
            var propertyInfo  = this.GetPropertyInfo(PropertyBillAllUserAccounts);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (BillAllUsers) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_BillAllUsers_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBillAllUsers);
            var propertyInfo  = this.GetPropertyInfo(PropertyBillAllUsers);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (BillingContactId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_BillingContactId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBillingContactId);
            var propertyInfo  = this.GetPropertyInfo(PropertyBillingContactId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (Client) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Client_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyClient);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyClient);
            Action currentAction = () => propertyInfo.SetValue(_clientInvoiceOptionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (Client) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_Client_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyClient);
            var propertyInfo  = this.GetPropertyInfo(PropertyClient);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (ClientId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_ClientId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyClientId);
            var propertyInfo  = this.GetPropertyInfo(PropertyClientId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (CompanyId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_CompanyId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCompanyId);
            var propertyInfo  = this.GetPropertyInfo(PropertyCompanyId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (CurrencyId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_CurrencyId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (CurrentInvoiceNumber) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_CurrentInvoiceNumber_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCurrentInvoiceNumber);
            var propertyInfo  = this.GetPropertyInfo(PropertyCurrentInvoiceNumber);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (CurrentTempInvoiceNumber) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_CurrentTempInvoiceNumber_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCurrentTempInvoiceNumber);
            var propertyInfo  = this.GetPropertyInfo(PropertyCurrentTempInvoiceNumber);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (CycleDuration) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_CycleDuration_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCycleDuration);
            var propertyInfo  = this.GetPropertyInfo(PropertyCycleDuration);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (CycleDurationUnit) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_CycleDurationUnit_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCycleDurationUnit);
            var propertyInfo  = this.GetPropertyInfo(PropertyCycleDurationUnit);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (DiscountRate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_DiscountRate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDiscountRate);
            var propertyInfo  = this.GetPropertyInfo(PropertyDiscountRate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (DisplayRatePerUser) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_DisplayRatePerUser_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDisplayRatePerUser);
            var propertyInfo  = this.GetPropertyInfo(PropertyDisplayRatePerUser);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (DisplayTotalPerEntry) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_DisplayTotalPerEntry_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDisplayTotalPerEntry);
            var propertyInfo  = this.GetPropertyInfo(PropertyDisplayTotalPerEntry);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (DisplayUnits) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_DisplayUnits_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDisplayUnits);
            var propertyInfo  = this.GetPropertyInfo(PropertyDisplayUnits);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (DisplayWorkDone) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_DisplayWorkDone_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDisplayWorkDone);
            var propertyInfo  = this.GetPropertyInfo(PropertyDisplayWorkDone);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (ExchangeRateOption) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_ExchangeRateOption_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExchangeRateOption);
            var propertyInfo  = this.GetPropertyInfo(PropertyExchangeRateOption);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (ExtensionData) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_ExtensionData_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExtensionData);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExtensionData);
            Action currentAction = () => propertyInfo.SetValue(_clientInvoiceOptionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (ExtensionData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_ExtensionData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (GroupBy) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_GroupBy_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyGroupBy);
            var propertyInfo  = this.GetPropertyInfo(PropertyGroupBy);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (HoursPerDay) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_HoursPerDay_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyHoursPerDay);
            var propertyInfo  = this.GetPropertyInfo(PropertyHoursPerDay);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (IncludeBillableAdjustments) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_IncludeBillableAdjustments_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIncludeBillableAdjustments);
            var propertyInfo  = this.GetPropertyInfo(PropertyIncludeBillableAdjustments);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (IncludeBillableExpenses) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_IncludeBillableExpenses_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIncludeBillableExpenses);
            var propertyInfo  = this.GetPropertyInfo(PropertyIncludeBillableExpenses);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (IncludeBillableItems) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_IncludeBillableItems_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIncludeBillableItems);
            var propertyInfo  = this.GetPropertyInfo(PropertyIncludeBillableItems);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (IncludeBillableTime) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_IncludeBillableTime_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIncludeBillableTime);
            var propertyInfo  = this.GetPropertyInfo(PropertyIncludeBillableTime);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (IncludeLineItemNotes) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_IncludeLineItemNotes_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIncludeLineItemNotes);
            var propertyInfo  = this.GetPropertyInfo(PropertyIncludeLineItemNotes);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (IncludeOvertimeEntries) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_IncludeOvertimeEntries_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIncludeOvertimeEntries);
            var propertyInfo  = this.GetPropertyInfo(PropertyIncludeOvertimeEntries);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (IncludeSplitBillingPerProject) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_IncludeSplitBillingPerProject_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIncludeSplitBillingPerProject);
            var propertyInfo  = this.GetPropertyInfo(PropertyIncludeSplitBillingPerProject);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (IncludeTimeEntryNotes) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_IncludeTimeEntryNotes_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIncludeTimeEntryNotes);
            var propertyInfo  = this.GetPropertyInfo(PropertyIncludeTimeEntryNotes);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (InforceWorkflow) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_InforceWorkflow_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyInforceWorkflow);
            var propertyInfo  = this.GetPropertyInfo(PropertyInforceWorkflow);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (InvoiceAllBillableItems) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_InvoiceAllBillableItems_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyInvoiceAllBillableItems);
            var propertyInfo  = this.GetPropertyInfo(PropertyInvoiceAllBillableItems);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (InvoiceAllCharges) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_InvoiceAllCharges_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyInvoiceAllCharges);
            var propertyInfo  = this.GetPropertyInfo(PropertyInvoiceAllCharges);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (InvoiceAllExpenses) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_InvoiceAllExpenses_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyInvoiceAllExpenses);
            var propertyInfo  = this.GetPropertyInfo(PropertyInvoiceAllExpenses);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (InvoiceAllUsers) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_InvoiceAllUsers_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyInvoiceAllUsers);
            var propertyInfo  = this.GetPropertyInfo(PropertyInvoiceAllUsers);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (InvoiceNumberPrefix) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_InvoiceNumberPrefix_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyInvoiceNumberPrefix);
            var propertyInfo  = this.GetPropertyInfo(PropertyInvoiceNumberPrefix);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (InvoiceTemplateId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_InvoiceTemplateId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyInvoiceTemplateId);
            var propertyInfo  = this.GetPropertyInfo(PropertyInvoiceTemplateId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (IsOverridable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_IsOverridable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsOverridable);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsOverridable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (IsPeriodBasedCycle) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_IsPeriodBasedCycle_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsPeriodBasedCycle);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsPeriodBasedCycle);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (IssuerContactId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_IssuerContactId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIssuerContactId);
            var propertyInfo  = this.GetPropertyInfo(PropertyIssuerContactId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (LastInvoiceCreateDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_LastInvoiceCreateDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLastInvoiceCreateDate);
            var propertyInfo  = this.GetPropertyInfo(PropertyLastInvoiceCreateDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (LastInvoicedId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_LastInvoicedId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLastInvoicedId);
            var propertyInfo  = this.GetPropertyInfo(PropertyLastInvoicedId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (LastInvoicedNumber) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_LastInvoicedNumber_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLastInvoicedNumber);
            var propertyInfo  = this.GetPropertyInfo(PropertyLastInvoicedNumber);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (LastIssuedDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_LastIssuedDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLastIssuedDate);
            var propertyInfo  = this.GetPropertyInfo(PropertyLastIssuedDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (LastIssuedInvoiceId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_LastIssuedInvoiceId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLastIssuedInvoiceId);
            var propertyInfo  = this.GetPropertyInfo(PropertyLastIssuedInvoiceId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (LastIssuedNumber) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_LastIssuedNumber_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLastIssuedNumber);
            var propertyInfo  = this.GetPropertyInfo(PropertyLastIssuedNumber);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (NextInvoiceBatchStart) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_NextInvoiceBatchStart_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyNextInvoiceBatchStart);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyNextInvoiceBatchStart);
            Action currentAction = () => propertyInfo.SetValue(_clientInvoiceOptionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (NextInvoiceBatchStart) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_NextInvoiceBatchStart_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyNextInvoiceBatchStart);
            var propertyInfo  = this.GetPropertyInfo(PropertyNextInvoiceBatchStart);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (Note1) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_Note1_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyNote1);
            var propertyInfo  = this.GetPropertyInfo(PropertyNote1);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (Note2) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_Note2_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyNote2);
            var propertyInfo  = this.GetPropertyInfo(PropertyNote2);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (Note3) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_Note3_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyNote3);
            var propertyInfo  = this.GetPropertyInfo(PropertyNote3);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (NoteType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_NoteType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyNoteType);
            var propertyInfo  = this.GetPropertyInfo(PropertyNoteType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (NotifyClientOnInvoice) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_NotifyClientOnInvoice_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyNotifyClientOnInvoice);
            var propertyInfo  = this.GetPropertyInfo(PropertyNotifyClientOnInvoice);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (OverrideGLobalInvoiceNumber) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_OverrideGLobalInvoiceNumber_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyOverrideGLobalInvoiceNumber);
            var propertyInfo  = this.GetPropertyInfo(PropertyOverrideGLobalInvoiceNumber);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (PaymentTerms) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_PaymentTerms_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPaymentTerms);
            var propertyInfo  = this.GetPropertyInfo(PropertyPaymentTerms);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (PreBillingReportTemplate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_PreBillingReportTemplate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPreBillingReportTemplate);
            var propertyInfo  = this.GetPropertyInfo(PropertyPreBillingReportTemplate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (PreBillingWorkflowId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_PreBillingWorkflowId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPreBillingWorkflowId);
            var propertyInfo  = this.GetPropertyInfo(PropertyPreBillingWorkflowId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (ReportTemplateId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_ReportTemplateId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyReportTemplateId);
            var propertyInfo  = this.GetPropertyInfo(PropertyReportTemplateId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (ShippingContactId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_ShippingContactId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyShippingContactId);
            var propertyInfo  = this.GetPropertyInfo(PropertyShippingContactId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (ShowOvertimeEntriesInReport) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_ShowOvertimeEntriesInReport_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyShowOvertimeEntriesInReport);
            var propertyInfo  = this.GetPropertyInfo(PropertyShowOvertimeEntriesInReport);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (Style) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_Style_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyStyle);
            var propertyInfo  = this.GetPropertyInfo(PropertyStyle);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            Action currentAction = () => propertyInfo.SetValue(_clientInvoiceOptionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (TaxGroupId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_TaxGroupId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (TempInvoiceNumber) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_TempInvoiceNumber_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTempInvoiceNumber);
            var propertyInfo  = this.GetPropertyInfo(PropertyTempInvoiceNumber);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (UniqueId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_UniqueId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (UseDatabaseStartDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_UseDatabaseStartDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUseDatabaseStartDate);
            var propertyInfo  = this.GetPropertyInfo(PropertyUseDatabaseStartDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ClientInvoiceOption) => Property (WorkflowMapId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ClientInvoiceOption_Public_Class_WorkflowMapId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWorkflowMapId);
            var propertyInfo  = this.GetPropertyInfo(PropertyWorkflowMapId);

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
        private void AUT_ClientInvoiceOption_RaisePropertyChanged_Method_Call_Internally(Type[] types)
        {
            var methodRaisePropertyChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientInvoiceOptionInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClientInvoiceOption_RaisePropertyChanged_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_clientInvoiceOptionInstanceFixture, parametersOfRaisePropertyChanged);

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
        public void AUT_ClientInvoiceOption_RaisePropertyChanged_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_clientInvoiceOptionInstance, MethodRaisePropertyChanged, parametersOfRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes);

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
        public void AUT_ClientInvoiceOption_RaisePropertyChanged_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ClientInvoiceOption_RaisePropertyChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clientInvoiceOptionInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);

            // Assert
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClientInvoiceOption_RaisePropertyChanged_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_clientInvoiceOptionInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}