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
using UplandIntegrations.TenroxClientService;
using Invoice = UplandIntegrations.TenroxClientService;

namespace UplandIntegrations.TenroxClientService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxClientService.Invoice" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxClientService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    public partial class InvoiceTest : AbstractBaseSetupV3Test
    {
        public InvoiceTest() : base(typeof(Invoice))
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

        #region General Initializer : Class (Invoice) Initializer

        #region Properties

        private const string PropertyExtensionData = "ExtensionData";
        private const string PropertyAccconSetId = "AccconSetId";
        private const string PropertyAddByUserId = "AddByUserId";
        private const string PropertyAddTimeStamp = "AddTimeStamp";
        private const string PropertyAddressLine1 = "AddressLine1";
        private const string PropertyAddressLine2 = "AddressLine2";
        private const string PropertyAppTimeStamp = "AppTimeStamp";
        private const string PropertyAttentionOf = "AttentionOf";
        private const string PropertyBatchId = "BatchId";
        private const string PropertyBillAllProjects = "BillAllProjects";
        private const string PropertyBillAllUserActs = "BillAllUserActs";
        private const string PropertyBillAllUsers = "BillAllUsers";
        private const string PropertyBillingContactId = "BillingContactId";
        private const string PropertyBillingStatus = "BillingStatus";
        private const string PropertyChargesForExpense = "ChargesForExpense";
        private const string PropertyChargesForService = "ChargesForService";
        private const string PropertyChargesForSrvNodis = "ChargesForSrvNodis";
        private const string PropertyChngForCharges = "ChngForCharges";
        private const string PropertyCity = "City";
        private const string PropertyClientId = "ClientId";
        private const string PropertyCountry = "Country";
        private const string PropertyCreatedBy = "CreatedBy";
        private const string PropertyCurrencyId = "CurrencyId";
        private const string PropertyCurrencyRate = "CurrencyRate";
        private const string PropertyDateFrom = "DateFrom";
        private const string PropertyDateTo = "DateTo";
        private const string PropertyDiscountRate = "DiscountRate";
        private const string PropertyDispRatePerUser = "DispRatePerUser";
        private const string PropertyDispTotalPerEntry = "DispTotalPerEntry";
        private const string PropertyDispUnit = "DispUnit";
        private const string PropertyDispWorkDone = "DispWorkDone";
        private const string PropertyDocumentDate = "DocumentDate";
        private const string PropertyExchRateOption = "ExchRateOption";
        private const string PropertyExportStatus = "ExportStatus";
        private const string PropertyExportTimeStamp = "ExportTimeStamp";
        private const string PropertyExporterId = "ExporterId";
        private const string PropertyGroupBy = "GroupBy";
        private const string PropertyHoursPerDay = "HoursPerDay";
        private const string PropertyInc0TimeEntries = "Inc0TimeEntries";
        private const string PropertyIncBillableAdj = "IncBillableAdj";
        private const string PropertyIncBillableExp = "IncBillableExp";
        private const string PropertyIncBillableIChr = "IncBillableIChr";
        private const string PropertyIncBillableTime = "IncBillableTime";
        private const string PropertyIncLineItemNotes = "IncLineItemNotes";
        private const string PropertyIncSplitBillPrjs = "IncSplitBillPrjs";
        private const string PropertyIncTEntryNotes = "IncTEntryNotes";
        private const string PropertyIntandFinCharges = "IntandFinCharges";
        private const string PropertyInvAllCharges = "InvAllCharges";
        private const string PropertyInvAllExpenses = "InvAllExpenses";
        private const string PropertyInvAllIChares = "InvAllIChares";
        private const string PropertyInvAllUsers = "InvAllUsers";
        private const string PropertyInvoiceNo = "InvoiceNo";
        private const string PropertyInvoiceType = "InvoiceType";
        private const string PropertyIssueDate = "IssueDate";
        private const string PropertyIssued = "Issued";
        private const string PropertyIssuerContactId = "IssuerContactId";
        private const string PropertyItemCharges = "ItemCharges";
        private const string PropertyLastGenDate = "LastGenDate";
        private const string PropertyModifyTimeStamp = "ModifyTimeStamp";
        private const string PropertyNewBalance = "NewBalance";
        private const string PropertyNote1 = "Note1";
        private const string PropertyNote2 = "Note2";
        private const string PropertyNote3 = "Note3";
        private const string PropertyNoteType = "NoteType";
        private const string PropertyNotifyOnIssue = "NotifyOnIssue";
        private const string PropertyNumGenerated = "NumGenerated";
        private const string PropertyObjectId = "ObjectId";
        private const string PropertyOrganizationName = "OrganizationName";
        private const string PropertyPaymentTerm = "PaymentTerm";
        private const string PropertyPaymntCreditRefund = "PaymntCreditRefund";
        private const string PropertyPostalCode = "PostalCode";
        private const string PropertyPreBillingRepTemplateId = "PreBillingRepTemplateId";
        private const string PropertyPreBillingWorkflowId = "PreBillingWorkflowId";
        private const string PropertyPreviousBalance = "PreviousBalance";
        private const string PropertyProcessing = "Processing";
        private const string PropertyPurchaseOrderNo = "PurchaseOrderNo";
        private const string PropertyREVRECOGTIMESTAMP = "REVRECOGTIMESTAMP";
        private const string PropertyRateToCompCurr = "RateToCompCurr";
        private const string PropertyRecompute = "Recompute";
        private const string PropertyRepTemplateId = "RepTemplateId";
        private const string PropertyRevRecog = "RevRecog";
        private const string PropertyShippingContactId = "ShippingContactId";
        private const string PropertyShow0TEinRep = "Show0TEinRep";
        private const string PropertyState = "State";
        private const string PropertyStateChangeDate = "StateChangeDate";
        private const string PropertyStatusId = "StatusId";
        private const string PropertyStyle = "Style";
        private const string PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey";
        private const string PropertyTAccconSet = "TAccconSet";
        private const string PropertyTaxGroupId = "TaxGroupId";
        private const string PropertyTemplateId = "TemplateId";
        private const string PropertyTotalTaxes = "TotalTaxes";
        private const string PropertyUSEPROJECTCONTACT = "USEPROJECTCONTACT";
        private const string PropertyUniqueId = "UniqueId";
        private const string PropertyUseClientExchRate = "UseClientExchRate";
        private const string PropertyUseDBStartDate = "UseDBStartDate";
        private const string PropertyWorkflowMapId = "WorkflowMapId";

        #endregion

        #region Methods

        private const string MethodRaisePropertyChanged = "RaisePropertyChanged";

        #endregion

        #region Fields

        private const string FieldextensionDataField = "extensionDataField";
        private const string FieldAccconSetIdField = "AccconSetIdField";
        private const string FieldAddByUserIdField = "AddByUserIdField";
        private const string FieldAddTimeStampField = "AddTimeStampField";
        private const string FieldAddressLine1Field = "AddressLine1Field";
        private const string FieldAddressLine2Field = "AddressLine2Field";
        private const string FieldAppTimeStampField = "AppTimeStampField";
        private const string FieldAttentionOfField = "AttentionOfField";
        private const string FieldBatchIdField = "BatchIdField";
        private const string FieldBillAllProjectsField = "BillAllProjectsField";
        private const string FieldBillAllUserActsField = "BillAllUserActsField";
        private const string FieldBillAllUsersField = "BillAllUsersField";
        private const string FieldBillingContactIdField = "BillingContactIdField";
        private const string FieldBillingStatusField = "BillingStatusField";
        private const string FieldChargesForExpenseField = "ChargesForExpenseField";
        private const string FieldChargesForServiceField = "ChargesForServiceField";
        private const string FieldChargesForSrvNodisField = "ChargesForSrvNodisField";
        private const string FieldChngForChargesField = "ChngForChargesField";
        private const string FieldCityField = "CityField";
        private const string FieldClientIdField = "ClientIdField";
        private const string FieldCountryField = "CountryField";
        private const string FieldCreatedByField = "CreatedByField";
        private const string FieldCurrencyIdField = "CurrencyIdField";
        private const string FieldCurrencyRateField = "CurrencyRateField";
        private const string FieldDateFromField = "DateFromField";
        private const string FieldDateToField = "DateToField";
        private const string FieldDiscountRateField = "DiscountRateField";
        private const string FieldDispRatePerUserField = "DispRatePerUserField";
        private const string FieldDispTotalPerEntryField = "DispTotalPerEntryField";
        private const string FieldDispUnitField = "DispUnitField";
        private const string FieldDispWorkDoneField = "DispWorkDoneField";
        private const string FieldDocumentDateField = "DocumentDateField";
        private const string FieldExchRateOptionField = "ExchRateOptionField";
        private const string FieldExportStatusField = "ExportStatusField";
        private const string FieldExportTimeStampField = "ExportTimeStampField";
        private const string FieldExporterIdField = "ExporterIdField";
        private const string FieldGroupByField = "GroupByField";
        private const string FieldHoursPerDayField = "HoursPerDayField";
        private const string FieldInc0TimeEntriesField = "Inc0TimeEntriesField";
        private const string FieldIncBillableAdjField = "IncBillableAdjField";
        private const string FieldIncBillableExpField = "IncBillableExpField";
        private const string FieldIncBillableIChrField = "IncBillableIChrField";
        private const string FieldIncBillableTimeField = "IncBillableTimeField";
        private const string FieldIncLineItemNotesField = "IncLineItemNotesField";
        private const string FieldIncSplitBillPrjsField = "IncSplitBillPrjsField";
        private const string FieldIncTEntryNotesField = "IncTEntryNotesField";
        private const string FieldIntandFinChargesField = "IntandFinChargesField";
        private const string FieldInvAllChargesField = "InvAllChargesField";
        private const string FieldInvAllExpensesField = "InvAllExpensesField";
        private const string FieldInvAllICharesField = "InvAllICharesField";
        private const string FieldInvAllUsersField = "InvAllUsersField";
        private const string FieldInvoiceNoField = "InvoiceNoField";
        private const string FieldInvoiceTypeField = "InvoiceTypeField";
        private const string FieldIssueDateField = "IssueDateField";
        private const string FieldIssuedField = "IssuedField";
        private const string FieldIssuerContactIdField = "IssuerContactIdField";
        private const string FieldItemChargesField = "ItemChargesField";
        private const string FieldLastGenDateField = "LastGenDateField";
        private const string FieldModifyTimeStampField = "ModifyTimeStampField";
        private const string FieldNewBalanceField = "NewBalanceField";
        private const string FieldNote1Field = "Note1Field";
        private const string FieldNote2Field = "Note2Field";
        private const string FieldNote3Field = "Note3Field";
        private const string FieldNoteTypeField = "NoteTypeField";
        private const string FieldNotifyOnIssueField = "NotifyOnIssueField";
        private const string FieldNumGeneratedField = "NumGeneratedField";
        private const string FieldObjectIdField = "ObjectIdField";
        private const string FieldOrganizationNameField = "OrganizationNameField";
        private const string FieldPaymentTermField = "PaymentTermField";
        private const string FieldPaymntCreditRefundField = "PaymntCreditRefundField";
        private const string FieldPostalCodeField = "PostalCodeField";
        private const string FieldPreBillingRepTemplateIdField = "PreBillingRepTemplateIdField";
        private const string FieldPreBillingWorkflowIdField = "PreBillingWorkflowIdField";
        private const string FieldPreviousBalanceField = "PreviousBalanceField";
        private const string FieldProcessingField = "ProcessingField";
        private const string FieldPurchaseOrderNoField = "PurchaseOrderNoField";
        private const string FieldREVRECOGTIMESTAMPField = "REVRECOGTIMESTAMPField";
        private const string FieldRateToCompCurrField = "RateToCompCurrField";
        private const string FieldRecomputeField = "RecomputeField";
        private const string FieldRepTemplateIdField = "RepTemplateIdField";
        private const string FieldRevRecogField = "RevRecogField";
        private const string FieldShippingContactIdField = "ShippingContactIdField";
        private const string FieldShow0TEinRepField = "Show0TEinRepField";
        private const string FieldStateField = "StateField";
        private const string FieldStateChangeDateField = "StateChangeDateField";
        private const string FieldStatusIdField = "StatusIdField";
        private const string FieldStyleField = "StyleField";
        private const string FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField = "SystemDataObjectsDataClassesIEntityWithKeyEntityKeyField";
        private const string FieldTAccconSetField = "TAccconSetField";
        private const string FieldTaxGroupIdField = "TaxGroupIdField";
        private const string FieldTemplateIdField = "TemplateIdField";
        private const string FieldTotalTaxesField = "TotalTaxesField";
        private const string FieldUSEPROJECTCONTACTField = "USEPROJECTCONTACTField";
        private const string FieldUniqueIdField = "UniqueIdField";
        private const string FieldUseClientExchRateField = "UseClientExchRateField";
        private const string FieldUseDBStartDateField = "UseDBStartDateField";
        private const string FieldWorkflowMapIdField = "WorkflowMapIdField";

        #endregion

        private Type _invoiceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private Invoice _invoiceInstance;
        private Invoice _invoiceInstanceFixture;

        #region General Initializer : Class (Invoice) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Invoice" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _invoiceInstanceType = typeof(Invoice);
            _invoiceInstanceFixture = this.Create<Invoice>(true);
            _invoiceInstance = _invoiceInstanceFixture ?? this.Create<Invoice>(false);
            CurrentInstance = _invoiceInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Invoice)

        #region General Initializer : Class (Invoice) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Invoice" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRaisePropertyChanged, 0)]
        public void AUT_Invoice_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_invoiceInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Invoice) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Invoice" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyExtensionData)]
        [TestCase(PropertyAccconSetId)]
        [TestCase(PropertyAddByUserId)]
        [TestCase(PropertyAddTimeStamp)]
        [TestCase(PropertyAddressLine1)]
        [TestCase(PropertyAddressLine2)]
        [TestCase(PropertyAppTimeStamp)]
        [TestCase(PropertyAttentionOf)]
        [TestCase(PropertyBatchId)]
        [TestCase(PropertyBillAllProjects)]
        [TestCase(PropertyBillAllUserActs)]
        [TestCase(PropertyBillAllUsers)]
        [TestCase(PropertyBillingContactId)]
        [TestCase(PropertyBillingStatus)]
        [TestCase(PropertyChargesForExpense)]
        [TestCase(PropertyChargesForService)]
        [TestCase(PropertyChargesForSrvNodis)]
        [TestCase(PropertyChngForCharges)]
        [TestCase(PropertyCity)]
        [TestCase(PropertyClientId)]
        [TestCase(PropertyCountry)]
        [TestCase(PropertyCreatedBy)]
        [TestCase(PropertyCurrencyId)]
        [TestCase(PropertyCurrencyRate)]
        [TestCase(PropertyDateFrom)]
        [TestCase(PropertyDateTo)]
        [TestCase(PropertyDiscountRate)]
        [TestCase(PropertyDispRatePerUser)]
        [TestCase(PropertyDispTotalPerEntry)]
        [TestCase(PropertyDispUnit)]
        [TestCase(PropertyDispWorkDone)]
        [TestCase(PropertyDocumentDate)]
        [TestCase(PropertyExchRateOption)]
        [TestCase(PropertyExportStatus)]
        [TestCase(PropertyExportTimeStamp)]
        [TestCase(PropertyExporterId)]
        [TestCase(PropertyGroupBy)]
        [TestCase(PropertyHoursPerDay)]
        [TestCase(PropertyInc0TimeEntries)]
        [TestCase(PropertyIncBillableAdj)]
        [TestCase(PropertyIncBillableExp)]
        [TestCase(PropertyIncBillableIChr)]
        [TestCase(PropertyIncBillableTime)]
        [TestCase(PropertyIncLineItemNotes)]
        [TestCase(PropertyIncSplitBillPrjs)]
        [TestCase(PropertyIncTEntryNotes)]
        [TestCase(PropertyIntandFinCharges)]
        [TestCase(PropertyInvAllCharges)]
        [TestCase(PropertyInvAllExpenses)]
        [TestCase(PropertyInvAllIChares)]
        [TestCase(PropertyInvAllUsers)]
        [TestCase(PropertyInvoiceNo)]
        [TestCase(PropertyInvoiceType)]
        [TestCase(PropertyIssueDate)]
        [TestCase(PropertyIssued)]
        [TestCase(PropertyIssuerContactId)]
        [TestCase(PropertyItemCharges)]
        [TestCase(PropertyLastGenDate)]
        [TestCase(PropertyModifyTimeStamp)]
        [TestCase(PropertyNewBalance)]
        [TestCase(PropertyNote1)]
        [TestCase(PropertyNote2)]
        [TestCase(PropertyNote3)]
        [TestCase(PropertyNoteType)]
        [TestCase(PropertyNotifyOnIssue)]
        [TestCase(PropertyNumGenerated)]
        [TestCase(PropertyObjectId)]
        [TestCase(PropertyOrganizationName)]
        [TestCase(PropertyPaymentTerm)]
        [TestCase(PropertyPaymntCreditRefund)]
        [TestCase(PropertyPostalCode)]
        [TestCase(PropertyPreBillingRepTemplateId)]
        [TestCase(PropertyPreBillingWorkflowId)]
        [TestCase(PropertyPreviousBalance)]
        [TestCase(PropertyProcessing)]
        [TestCase(PropertyPurchaseOrderNo)]
        [TestCase(PropertyREVRECOGTIMESTAMP)]
        [TestCase(PropertyRateToCompCurr)]
        [TestCase(PropertyRecompute)]
        [TestCase(PropertyRepTemplateId)]
        [TestCase(PropertyRevRecog)]
        [TestCase(PropertyShippingContactId)]
        [TestCase(PropertyShow0TEinRep)]
        [TestCase(PropertyState)]
        [TestCase(PropertyStateChangeDate)]
        [TestCase(PropertyStatusId)]
        [TestCase(PropertyStyle)]
        [TestCase(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCase(PropertyTAccconSet)]
        [TestCase(PropertyTaxGroupId)]
        [TestCase(PropertyTemplateId)]
        [TestCase(PropertyTotalTaxes)]
        [TestCase(PropertyUSEPROJECTCONTACT)]
        [TestCase(PropertyUniqueId)]
        [TestCase(PropertyUseClientExchRate)]
        [TestCase(PropertyUseDBStartDate)]
        [TestCase(PropertyWorkflowMapId)]
        public void AUT_Invoice_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var propertyInfo = this.GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_invoiceInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Invoice) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Invoice" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldextensionDataField)]
        [TestCase(FieldAccconSetIdField)]
        [TestCase(FieldAddByUserIdField)]
        [TestCase(FieldAddTimeStampField)]
        [TestCase(FieldAddressLine1Field)]
        [TestCase(FieldAddressLine2Field)]
        [TestCase(FieldAppTimeStampField)]
        [TestCase(FieldAttentionOfField)]
        [TestCase(FieldBatchIdField)]
        [TestCase(FieldBillAllProjectsField)]
        [TestCase(FieldBillAllUserActsField)]
        [TestCase(FieldBillAllUsersField)]
        [TestCase(FieldBillingContactIdField)]
        [TestCase(FieldBillingStatusField)]
        [TestCase(FieldChargesForExpenseField)]
        [TestCase(FieldChargesForServiceField)]
        [TestCase(FieldChargesForSrvNodisField)]
        [TestCase(FieldChngForChargesField)]
        [TestCase(FieldCityField)]
        [TestCase(FieldClientIdField)]
        [TestCase(FieldCountryField)]
        [TestCase(FieldCreatedByField)]
        [TestCase(FieldCurrencyIdField)]
        [TestCase(FieldCurrencyRateField)]
        [TestCase(FieldDateFromField)]
        [TestCase(FieldDateToField)]
        [TestCase(FieldDiscountRateField)]
        [TestCase(FieldDispRatePerUserField)]
        [TestCase(FieldDispTotalPerEntryField)]
        [TestCase(FieldDispUnitField)]
        [TestCase(FieldDispWorkDoneField)]
        [TestCase(FieldDocumentDateField)]
        [TestCase(FieldExchRateOptionField)]
        [TestCase(FieldExportStatusField)]
        [TestCase(FieldExportTimeStampField)]
        [TestCase(FieldExporterIdField)]
        [TestCase(FieldGroupByField)]
        [TestCase(FieldHoursPerDayField)]
        [TestCase(FieldInc0TimeEntriesField)]
        [TestCase(FieldIncBillableAdjField)]
        [TestCase(FieldIncBillableExpField)]
        [TestCase(FieldIncBillableIChrField)]
        [TestCase(FieldIncBillableTimeField)]
        [TestCase(FieldIncLineItemNotesField)]
        [TestCase(FieldIncSplitBillPrjsField)]
        [TestCase(FieldIncTEntryNotesField)]
        [TestCase(FieldIntandFinChargesField)]
        [TestCase(FieldInvAllChargesField)]
        [TestCase(FieldInvAllExpensesField)]
        [TestCase(FieldInvAllICharesField)]
        [TestCase(FieldInvAllUsersField)]
        [TestCase(FieldInvoiceNoField)]
        [TestCase(FieldInvoiceTypeField)]
        [TestCase(FieldIssueDateField)]
        [TestCase(FieldIssuedField)]
        [TestCase(FieldIssuerContactIdField)]
        [TestCase(FieldItemChargesField)]
        [TestCase(FieldLastGenDateField)]
        [TestCase(FieldModifyTimeStampField)]
        [TestCase(FieldNewBalanceField)]
        [TestCase(FieldNote1Field)]
        [TestCase(FieldNote2Field)]
        [TestCase(FieldNote3Field)]
        [TestCase(FieldNoteTypeField)]
        [TestCase(FieldNotifyOnIssueField)]
        [TestCase(FieldNumGeneratedField)]
        [TestCase(FieldObjectIdField)]
        [TestCase(FieldOrganizationNameField)]
        [TestCase(FieldPaymentTermField)]
        [TestCase(FieldPaymntCreditRefundField)]
        [TestCase(FieldPostalCodeField)]
        [TestCase(FieldPreBillingRepTemplateIdField)]
        [TestCase(FieldPreBillingWorkflowIdField)]
        [TestCase(FieldPreviousBalanceField)]
        [TestCase(FieldProcessingField)]
        [TestCase(FieldPurchaseOrderNoField)]
        [TestCase(FieldREVRECOGTIMESTAMPField)]
        [TestCase(FieldRateToCompCurrField)]
        [TestCase(FieldRecomputeField)]
        [TestCase(FieldRepTemplateIdField)]
        [TestCase(FieldRevRecogField)]
        [TestCase(FieldShippingContactIdField)]
        [TestCase(FieldShow0TEinRepField)]
        [TestCase(FieldStateField)]
        [TestCase(FieldStateChangeDateField)]
        [TestCase(FieldStatusIdField)]
        [TestCase(FieldStyleField)]
        [TestCase(FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField)]
        [TestCase(FieldTAccconSetField)]
        [TestCase(FieldTaxGroupIdField)]
        [TestCase(FieldTemplateIdField)]
        [TestCase(FieldTotalTaxesField)]
        [TestCase(FieldUSEPROJECTCONTACTField)]
        [TestCase(FieldUniqueIdField)]
        [TestCase(FieldUseClientExchRateField)]
        [TestCase(FieldUseDBStartDateField)]
        [TestCase(FieldWorkflowMapIdField)]
        public void AUT_Invoice_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_invoiceInstanceFixture, 
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
        ///     Class (<see cref="Invoice" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Invoice_Is_Instance_Present_Test()
        {
            // Assert
            _invoiceInstanceType.ShouldNotBeNull();
            _invoiceInstance.ShouldNotBeNull();
            _invoiceInstanceFixture.ShouldNotBeNull();
            _invoiceInstance.ShouldBeAssignableTo<Invoice>();
            _invoiceInstanceFixture.ShouldBeAssignableTo<Invoice>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Invoice) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Invoice_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Invoice instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _invoiceInstanceType.ShouldNotBeNull();
            _invoiceInstance.ShouldNotBeNull();
            _invoiceInstanceFixture.ShouldNotBeNull();
            _invoiceInstance.ShouldBeAssignableTo<Invoice>();
            _invoiceInstanceFixture.ShouldBeAssignableTo<Invoice>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Invoice) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(System.Runtime.Serialization.ExtensionDataObject) , PropertyExtensionData)]
        [TestCaseGeneric(typeof(int) , PropertyAccconSetId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyAddByUserId)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyAddTimeStamp)]
        [TestCaseGeneric(typeof(string) , PropertyAddressLine1)]
        [TestCaseGeneric(typeof(string) , PropertyAddressLine2)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertyAppTimeStamp)]
        [TestCaseGeneric(typeof(string) , PropertyAttentionOf)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyBatchId)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyBillAllProjects)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyBillAllUserActs)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyBillAllUsers)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyBillingContactId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyBillingStatus)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyChargesForExpense)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyChargesForService)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyChargesForSrvNodis)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyChngForCharges)]
        [TestCaseGeneric(typeof(string) , PropertyCity)]
        [TestCaseGeneric(typeof(int) , PropertyClientId)]
        [TestCaseGeneric(typeof(string) , PropertyCountry)]
        [TestCaseGeneric(typeof(int) , PropertyCreatedBy)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyCurrencyId)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyCurrencyRate)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertyDateFrom)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertyDateTo)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyDiscountRate)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyDispRatePerUser)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyDispTotalPerEntry)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyDispUnit)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyDispWorkDone)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertyDocumentDate)]
        [TestCaseGeneric(typeof(string) , PropertyExchRateOption)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyExportStatus)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyExportTimeStamp)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyExporterId)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyGroupBy)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyHoursPerDay)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyInc0TimeEntries)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIncBillableAdj)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIncBillableExp)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIncBillableIChr)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIncBillableTime)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIncLineItemNotes)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIncSplitBillPrjs)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIncTEntryNotes)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyIntandFinCharges)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyInvAllCharges)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyInvAllExpenses)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyInvAllIChares)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyInvAllUsers)]
        [TestCaseGeneric(typeof(string) , PropertyInvoiceNo)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyInvoiceType)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyIssueDate)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIssued)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyIssuerContactId)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyItemCharges)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyLastGenDate)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertyModifyTimeStamp)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyNewBalance)]
        [TestCaseGeneric(typeof(string) , PropertyNote1)]
        [TestCaseGeneric(typeof(string) , PropertyNote2)]
        [TestCaseGeneric(typeof(string) , PropertyNote3)]
        [TestCaseGeneric(typeof(string) , PropertyNoteType)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyNotifyOnIssue)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyNumGenerated)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyObjectId)]
        [TestCaseGeneric(typeof(string) , PropertyOrganizationName)]
        [TestCaseGeneric(typeof(string) , PropertyPaymentTerm)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyPaymntCreditRefund)]
        [TestCaseGeneric(typeof(string) , PropertyPostalCode)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyPreBillingRepTemplateId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyPreBillingWorkflowId)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyPreviousBalance)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyProcessing)]
        [TestCaseGeneric(typeof(string) , PropertyPurchaseOrderNo)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyREVRECOGTIMESTAMP)]
        [TestCaseGeneric(typeof(decimal) , PropertyRateToCompCurr)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyRecompute)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyRepTemplateId)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyRevRecog)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyShippingContactId)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyShow0TEinRep)]
        [TestCaseGeneric(typeof(string) , PropertyState)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertyStateChangeDate)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyStatusId)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyStyle)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxClientService.EntityKey) , PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxClientService.AccountingConnection) , PropertyTAccconSet)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTaxGroupId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTemplateId)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyTotalTaxes)]
        [TestCaseGeneric(typeof(short) , PropertyUSEPROJECTCONTACT)]
        [TestCaseGeneric(typeof(int) , PropertyUniqueId)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyUseClientExchRate)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyUseDBStartDate)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyWorkflowMapId)]
        public void AUT_Invoice_Property_Type_Verify_Explore_By_Name_Test<T>(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);

            // Assert
            ShouldlyExtension.PropertyTypeVerify<Invoice, T>(_invoiceInstance, name, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (AccconSetId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_AccconSetId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (AddByUserId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_AddByUserId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAddByUserId);
            var propertyInfo  = this.GetPropertyInfo(PropertyAddByUserId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (AddressLine1) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_AddressLine1_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAddressLine1);
            var propertyInfo  = this.GetPropertyInfo(PropertyAddressLine1);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (AddressLine2) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_AddressLine2_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAddressLine2);
            var propertyInfo  = this.GetPropertyInfo(PropertyAddressLine2);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (AddTimeStamp) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_AddTimeStamp_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAddTimeStamp);
            var propertyInfo  = this.GetPropertyInfo(PropertyAddTimeStamp);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (AppTimeStamp) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_AppTimeStamp_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAppTimeStamp);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyAppTimeStamp);
            Action currentAction = () => propertyInfo.SetValue(_invoiceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (AppTimeStamp) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_AppTimeStamp_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (AttentionOf) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_AttentionOf_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAttentionOf);
            var propertyInfo  = this.GetPropertyInfo(PropertyAttentionOf);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (BatchId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_BatchId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBatchId);
            var propertyInfo  = this.GetPropertyInfo(PropertyBatchId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (BillAllProjects) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_BillAllProjects_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (BillAllUserActs) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_BillAllUserActs_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBillAllUserActs);
            var propertyInfo  = this.GetPropertyInfo(PropertyBillAllUserActs);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (BillAllUsers) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_BillAllUsers_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (BillingContactId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_BillingContactId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (BillingStatus) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_BillingStatus_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBillingStatus);
            var propertyInfo  = this.GetPropertyInfo(PropertyBillingStatus);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (ChargesForExpense) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_ChargesForExpense_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyChargesForExpense);
            var propertyInfo  = this.GetPropertyInfo(PropertyChargesForExpense);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (ChargesForService) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_ChargesForService_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyChargesForService);
            var propertyInfo  = this.GetPropertyInfo(PropertyChargesForService);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (ChargesForSrvNodis) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_ChargesForSrvNodis_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyChargesForSrvNodis);
            var propertyInfo  = this.GetPropertyInfo(PropertyChargesForSrvNodis);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (ChngForCharges) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_ChngForCharges_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyChngForCharges);
            var propertyInfo  = this.GetPropertyInfo(PropertyChngForCharges);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (City) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_City_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (ClientId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_ClientId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (Country) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_Country_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCountry);
            var propertyInfo  = this.GetPropertyInfo(PropertyCountry);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (CreatedBy) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_CreatedBy_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (CurrencyId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_CurrencyId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (CurrencyRate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_CurrencyRate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCurrencyRate);
            var propertyInfo  = this.GetPropertyInfo(PropertyCurrencyRate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (DateFrom) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_DateFrom_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDateFrom);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyDateFrom);
            Action currentAction = () => propertyInfo.SetValue(_invoiceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (DateFrom) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_DateFrom_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (DateTo) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_DateTo_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDateTo);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyDateTo);
            Action currentAction = () => propertyInfo.SetValue(_invoiceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (DateTo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_DateTo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (DiscountRate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_DiscountRate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (DispRatePerUser) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_DispRatePerUser_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDispRatePerUser);
            var propertyInfo  = this.GetPropertyInfo(PropertyDispRatePerUser);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (DispTotalPerEntry) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_DispTotalPerEntry_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDispTotalPerEntry);
            var propertyInfo  = this.GetPropertyInfo(PropertyDispTotalPerEntry);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (DispUnit) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_DispUnit_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDispUnit);
            var propertyInfo  = this.GetPropertyInfo(PropertyDispUnit);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (DispWorkDone) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_DispWorkDone_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDispWorkDone);
            var propertyInfo  = this.GetPropertyInfo(PropertyDispWorkDone);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (DocumentDate) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_DocumentDate_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDocumentDate);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyDocumentDate);
            Action currentAction = () => propertyInfo.SetValue(_invoiceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (DocumentDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_DocumentDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (ExchRateOption) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_ExchRateOption_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExchRateOption);
            var propertyInfo  = this.GetPropertyInfo(PropertyExchRateOption);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (ExporterId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_ExporterId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExporterId);
            var propertyInfo  = this.GetPropertyInfo(PropertyExporterId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (ExportStatus) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_ExportStatus_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (ExportTimeStamp) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_ExportTimeStamp_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExportTimeStamp);
            var propertyInfo  = this.GetPropertyInfo(PropertyExportTimeStamp);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (ExtensionData) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_ExtensionData_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExtensionData);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExtensionData);
            Action currentAction = () => propertyInfo.SetValue(_invoiceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (ExtensionData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_ExtensionData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (GroupBy) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_GroupBy_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (HoursPerDay) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_HoursPerDay_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (Inc0TimeEntries) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_Inc0TimeEntries_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyInc0TimeEntries);
            var propertyInfo  = this.GetPropertyInfo(PropertyInc0TimeEntries);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (IncBillableAdj) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_IncBillableAdj_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIncBillableAdj);
            var propertyInfo  = this.GetPropertyInfo(PropertyIncBillableAdj);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (IncBillableExp) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_IncBillableExp_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIncBillableExp);
            var propertyInfo  = this.GetPropertyInfo(PropertyIncBillableExp);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (IncBillableIChr) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_IncBillableIChr_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIncBillableIChr);
            var propertyInfo  = this.GetPropertyInfo(PropertyIncBillableIChr);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (IncBillableTime) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_IncBillableTime_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIncBillableTime);
            var propertyInfo  = this.GetPropertyInfo(PropertyIncBillableTime);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (IncLineItemNotes) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_IncLineItemNotes_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIncLineItemNotes);
            var propertyInfo  = this.GetPropertyInfo(PropertyIncLineItemNotes);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (IncSplitBillPrjs) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_IncSplitBillPrjs_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIncSplitBillPrjs);
            var propertyInfo  = this.GetPropertyInfo(PropertyIncSplitBillPrjs);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (IncTEntryNotes) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_IncTEntryNotes_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIncTEntryNotes);
            var propertyInfo  = this.GetPropertyInfo(PropertyIncTEntryNotes);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (IntandFinCharges) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_IntandFinCharges_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIntandFinCharges);
            var propertyInfo  = this.GetPropertyInfo(PropertyIntandFinCharges);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (InvAllCharges) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_InvAllCharges_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyInvAllCharges);
            var propertyInfo  = this.GetPropertyInfo(PropertyInvAllCharges);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (InvAllExpenses) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_InvAllExpenses_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyInvAllExpenses);
            var propertyInfo  = this.GetPropertyInfo(PropertyInvAllExpenses);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (InvAllIChares) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_InvAllIChares_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyInvAllIChares);
            var propertyInfo  = this.GetPropertyInfo(PropertyInvAllIChares);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (InvAllUsers) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_InvAllUsers_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyInvAllUsers);
            var propertyInfo  = this.GetPropertyInfo(PropertyInvAllUsers);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (InvoiceNo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_InvoiceNo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyInvoiceNo);
            var propertyInfo  = this.GetPropertyInfo(PropertyInvoiceNo);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (InvoiceType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_InvoiceType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyInvoiceType);
            var propertyInfo  = this.GetPropertyInfo(PropertyInvoiceType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (Issued) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_Issued_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (IssueDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_IssueDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (IssuerContactId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_IssuerContactId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (ItemCharges) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_ItemCharges_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyItemCharges);
            var propertyInfo  = this.GetPropertyInfo(PropertyItemCharges);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (LastGenDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_LastGenDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLastGenDate);
            var propertyInfo  = this.GetPropertyInfo(PropertyLastGenDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (ModifyTimeStamp) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_ModifyTimeStamp_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyModifyTimeStamp);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyModifyTimeStamp);
            Action currentAction = () => propertyInfo.SetValue(_invoiceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (ModifyTimeStamp) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_ModifyTimeStamp_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (NewBalance) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_NewBalance_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyNewBalance);
            var propertyInfo  = this.GetPropertyInfo(PropertyNewBalance);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (Note1) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_Note1_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (Note2) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_Note2_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (Note3) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_Note3_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (NoteType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_NoteType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (NotifyOnIssue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_NotifyOnIssue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyNotifyOnIssue);
            var propertyInfo  = this.GetPropertyInfo(PropertyNotifyOnIssue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (NumGenerated) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_NumGenerated_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyNumGenerated);
            var propertyInfo  = this.GetPropertyInfo(PropertyNumGenerated);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (ObjectId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_ObjectId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyObjectId);
            var propertyInfo  = this.GetPropertyInfo(PropertyObjectId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (OrganizationName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_OrganizationName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyOrganizationName);
            var propertyInfo  = this.GetPropertyInfo(PropertyOrganizationName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (PaymentTerm) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_PaymentTerm_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPaymentTerm);
            var propertyInfo  = this.GetPropertyInfo(PropertyPaymentTerm);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (PaymntCreditRefund) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_PaymntCreditRefund_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPaymntCreditRefund);
            var propertyInfo  = this.GetPropertyInfo(PropertyPaymntCreditRefund);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (PostalCode) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_PostalCode_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPostalCode);
            var propertyInfo  = this.GetPropertyInfo(PropertyPostalCode);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (PreBillingRepTemplateId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_PreBillingRepTemplateId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPreBillingRepTemplateId);
            var propertyInfo  = this.GetPropertyInfo(PropertyPreBillingRepTemplateId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (PreBillingWorkflowId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_PreBillingWorkflowId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (PreviousBalance) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_PreviousBalance_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPreviousBalance);
            var propertyInfo  = this.GetPropertyInfo(PropertyPreviousBalance);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (Processing) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_Processing_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProcessing);
            var propertyInfo  = this.GetPropertyInfo(PropertyProcessing);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (PurchaseOrderNo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_PurchaseOrderNo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPurchaseOrderNo);
            var propertyInfo  = this.GetPropertyInfo(PropertyPurchaseOrderNo);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (RateToCompCurr) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_RateToCompCurr_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRateToCompCurr);
            var propertyInfo  = this.GetPropertyInfo(PropertyRateToCompCurr);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (Recompute) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_Recompute_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRecompute);
            var propertyInfo  = this.GetPropertyInfo(PropertyRecompute);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (RepTemplateId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_RepTemplateId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRepTemplateId);
            var propertyInfo  = this.GetPropertyInfo(PropertyRepTemplateId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (RevRecog) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_RevRecog_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRevRecog);
            var propertyInfo  = this.GetPropertyInfo(PropertyRevRecog);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (REVRECOGTIMESTAMP) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_REVRECOGTIMESTAMP_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyREVRECOGTIMESTAMP);
            var propertyInfo  = this.GetPropertyInfo(PropertyREVRECOGTIMESTAMP);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (ShippingContactId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_ShippingContactId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (Show0TEinRep) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_Show0TEinRep_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyShow0TEinRep);
            var propertyInfo  = this.GetPropertyInfo(PropertyShow0TEinRep);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (State) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_State_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyState);
            var propertyInfo  = this.GetPropertyInfo(PropertyState);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (StateChangeDate) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_StateChangeDate_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyStateChangeDate);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyStateChangeDate);
            Action currentAction = () => propertyInfo.SetValue(_invoiceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (StateChangeDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_StateChangeDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyStateChangeDate);
            var propertyInfo  = this.GetPropertyInfo(PropertyStateChangeDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (StatusId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_StatusId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyStatusId);
            var propertyInfo  = this.GetPropertyInfo(PropertyStatusId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (Style) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_Style_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            Action currentAction = () => propertyInfo.SetValue(_invoiceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (TAccconSet) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_TAccconSet_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTAccconSet);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTAccconSet);
            Action currentAction = () => propertyInfo.SetValue(_invoiceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (TAccconSet) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_TAccconSet_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTAccconSet);
            var propertyInfo  = this.GetPropertyInfo(PropertyTAccconSet);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (TaxGroupId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_TaxGroupId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (TemplateId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_TemplateId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (TotalTaxes) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_TotalTaxes_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTotalTaxes);
            var propertyInfo  = this.GetPropertyInfo(PropertyTotalTaxes);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (UniqueId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_UniqueId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Invoice) => Property (UseClientExchRate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_UseClientExchRate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUseClientExchRate);
            var propertyInfo  = this.GetPropertyInfo(PropertyUseClientExchRate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (UseDBStartDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_UseDBStartDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUseDBStartDate);
            var propertyInfo  = this.GetPropertyInfo(PropertyUseDBStartDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (USEPROJECTCONTACT) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_USEPROJECTCONTACT_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUSEPROJECTCONTACT);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyUSEPROJECTCONTACT);
            Action currentAction = () => propertyInfo.SetValue(_invoiceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (USEPROJECTCONTACT) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_USEPROJECTCONTACT_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUSEPROJECTCONTACT);
            var propertyInfo  = this.GetPropertyInfo(PropertyUSEPROJECTCONTACT);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Invoice) => Property (WorkflowMapId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Invoice_Public_Class_WorkflowMapId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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
        private void AUT_Invoice_RaisePropertyChanged_Method_Call_Internally(Type[] types)
        {
            var methodRaisePropertyChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_invoiceInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Invoice_RaisePropertyChanged_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_invoiceInstanceFixture, parametersOfRaisePropertyChanged);

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
        public void AUT_Invoice_RaisePropertyChanged_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_invoiceInstance, MethodRaisePropertyChanged, parametersOfRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes);

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
        public void AUT_Invoice_RaisePropertyChanged_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Invoice_RaisePropertyChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_invoiceInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);

            // Assert
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Invoice_RaisePropertyChanged_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_invoiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}