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
using UplandIntegrations.TenroxAssignmentService;
using SystemDefault = UplandIntegrations.TenroxAssignmentService;

namespace UplandIntegrations.TenroxAssignmentService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxAssignmentService.SystemDefault" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxAssignmentService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SystemDefaultTest : AbstractBaseSetupV3Test
    {
        public SystemDefaultTest() : base(typeof(SystemDefault))
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

        #region General Initializer : Class (SystemDefault) Initializer

        #region Properties

        private const string PropertyExtensionData = "ExtensionData";
        private const string PropertyAccountId = "AccountId";
        private const string PropertyAccountingConnectionId = "AccountingConnectionId";
        private const string PropertyBussinesUnitId = "BussinesUnitId";
        private const string PropertyCalendarSetId = "CalendarSetId";
        private const string PropertyClassId = "ClassId";
        private const string PropertyClientId = "ClientId";
        private const string PropertyComponenetId = "ComponenetId";
        private const string PropertyContractId = "ContractId";
        private const string PropertyContractorId = "ContractorId";
        private const string PropertyCurrencyID = "CurrencyID";
        private const string PropertyEquimenetId = "EquimenetId";
        private const string PropertyExpenseId = "ExpenseId";
        private const string PropertyExpenseWorkflowId = "ExpenseWorkflowId";
        private const string PropertyExpenseWorkflowMapId = "ExpenseWorkflowMapId";
        private const string PropertyGroupId = "GroupId";
        private const string PropertyHolidateSetId = "HolidateSetId";
        private const string PropertyMSChargeId = "MSChargeId";
        private const string PropertyMSWorktypeId = "MSWorktypeId";
        private const string PropertyMaterialId = "MaterialId";
        private const string PropertyMilestoneUserId = "MilestoneUserId";
        private const string PropertyPLANNINGROLEID = "PLANNINGROLEID";
        private const string PropertyPhaseId = "PhaseId";
        private const string PropertyPortfolioBudgetFundingSource = "PortfolioBudgetFundingSource";
        private const string PropertyPortfolioId = "PortfolioId";
        private const string PropertyProjectId = "ProjectId";
        private const string PropertyProjectTypeId = "ProjectTypeId";
        private const string PropertyProjectWorkflow = "ProjectWorkflow";
        private const string PropertyProjectWorkflowMapId = "ProjectWorkflowMapId";
        private const string PropertyPurchaseTaxId = "PurchaseTaxId";
        private const string PropertyPurchaseWorkflowId = "PurchaseWorkflowId";
        private const string PropertyPurchaseWorkflowMapId = "PurchaseWorkflowMapId";
        private const string PropertyReccChargeId = "ReccChargeId";
        private const string PropertyReccWorktypeId = "ReccWorktypeId";
        private const string PropertyReccuringUserID = "ReccuringUserID";
        private const string PropertyReqWorkflowId = "ReqWorkflowId";
        private const string PropertyReqWorkflowMapId = "ReqWorkflowMapId";
        private const string PropertySalesTaxId = "SalesTaxId";
        private const string PropertyShiftId = "ShiftId";
        private const string PropertySiteId = "SiteId";
        private const string PropertySkillId = "SkillId";
        private const string PropertySkillSet = "SkillSet";
        private const string PropertySkillsetId = "SkillsetId";
        private const string PropertySupplierId = "SupplierId";
        private const string PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey";
        private const string PropertyTABreakId = "TABreakId";
        private const string PropertyTACCCONSET = "TACCCONSET";
        private const string PropertyTAScheduleId = "TAScheduleId";
        private const string PropertyTAShiftId = "TAShiftId";
        private const string PropertyTCHARGE = "TCHARGE";
        private const string PropertyTCHARGE1 = "TCHARGE1";
        private const string PropertyTWORKTYPE = "TWORKTYPE";
        private const string PropertyTWORKTYPE1 = "TWORKTYPE1";
        private const string PropertyTaskId = "TaskId";
        private const string PropertyTeamId = "TeamId";
        private const string PropertyTimeWorkflowId = "TimeWorkflowId";
        private const string PropertyTimeWorkflowMapId = "TimeWorkflowMapId";
        private const string PropertyTimeshetReportId = "TimeshetReportId";
        private const string PropertyTitleId = "TitleId";
        private const string PropertyUniqueId = "UniqueId";
        private const string PropertyUserId = "UserId";
        private const string PropertyUserResTypeId = "UserResTypeId";
        private const string PropertyWKFLOWORKFLOWMAPID = "WKFLOWORKFLOWMAPID";
        private const string PropertyWorkTypeId = "WorkTypeId";
        private const string PropertyWorkflowEntryId = "WorkflowEntryId";
        private const string PropertyWorkflowId = "WorkflowId";

        #endregion

        #region Methods

        private const string MethodRaisePropertyChanged = "RaisePropertyChanged";

        #endregion

        #region Fields

        private const string FieldextensionDataField = "extensionDataField";
        private const string FieldAccountIdField = "AccountIdField";
        private const string FieldAccountingConnectionIdField = "AccountingConnectionIdField";
        private const string FieldBussinesUnitIdField = "BussinesUnitIdField";
        private const string FieldCalendarSetIdField = "CalendarSetIdField";
        private const string FieldClassIdField = "ClassIdField";
        private const string FieldClientIdField = "ClientIdField";
        private const string FieldComponenetIdField = "ComponenetIdField";
        private const string FieldContractIdField = "ContractIdField";
        private const string FieldContractorIdField = "ContractorIdField";
        private const string FieldCurrencyIDField = "CurrencyIDField";
        private const string FieldEquimenetIdField = "EquimenetIdField";
        private const string FieldExpenseIdField = "ExpenseIdField";
        private const string FieldExpenseWorkflowIdField = "ExpenseWorkflowIdField";
        private const string FieldExpenseWorkflowMapIdField = "ExpenseWorkflowMapIdField";
        private const string FieldGroupIdField = "GroupIdField";
        private const string FieldHolidateSetIdField = "HolidateSetIdField";
        private const string FieldMSChargeIdField = "MSChargeIdField";
        private const string FieldMSWorktypeIdField = "MSWorktypeIdField";
        private const string FieldMaterialIdField = "MaterialIdField";
        private const string FieldMilestoneUserIdField = "MilestoneUserIdField";
        private const string FieldPLANNINGROLEIDField = "PLANNINGROLEIDField";
        private const string FieldPhaseIdField = "PhaseIdField";
        private const string FieldPortfolioBudgetFundingSourceField = "PortfolioBudgetFundingSourceField";
        private const string FieldPortfolioIdField = "PortfolioIdField";
        private const string FieldProjectIdField = "ProjectIdField";
        private const string FieldProjectTypeIdField = "ProjectTypeIdField";
        private const string FieldProjectWorkflowField = "ProjectWorkflowField";
        private const string FieldProjectWorkflowMapIdField = "ProjectWorkflowMapIdField";
        private const string FieldPurchaseTaxIdField = "PurchaseTaxIdField";
        private const string FieldPurchaseWorkflowIdField = "PurchaseWorkflowIdField";
        private const string FieldPurchaseWorkflowMapIdField = "PurchaseWorkflowMapIdField";
        private const string FieldReccChargeIdField = "ReccChargeIdField";
        private const string FieldReccWorktypeIdField = "ReccWorktypeIdField";
        private const string FieldReccuringUserIDField = "ReccuringUserIDField";
        private const string FieldReqWorkflowIdField = "ReqWorkflowIdField";
        private const string FieldReqWorkflowMapIdField = "ReqWorkflowMapIdField";
        private const string FieldSalesTaxIdField = "SalesTaxIdField";
        private const string FieldShiftIdField = "ShiftIdField";
        private const string FieldSiteIdField = "SiteIdField";
        private const string FieldSkillIdField = "SkillIdField";
        private const string FieldSkillSetField = "SkillSetField";
        private const string FieldSkillsetIdField = "SkillsetIdField";
        private const string FieldSupplierIdField = "SupplierIdField";
        private const string FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField = "SystemDataObjectsDataClassesIEntityWithKeyEntityKeyField";
        private const string FieldTABreakIdField = "TABreakIdField";
        private const string FieldTACCCONSETField = "TACCCONSETField";
        private const string FieldTAScheduleIdField = "TAScheduleIdField";
        private const string FieldTAShiftIdField = "TAShiftIdField";
        private const string FieldTCHARGEField = "TCHARGEField";
        private const string FieldTCHARGE1Field = "TCHARGE1Field";
        private const string FieldTWORKTYPEField = "TWORKTYPEField";
        private const string FieldTWORKTYPE1Field = "TWORKTYPE1Field";
        private const string FieldTaskIdField = "TaskIdField";
        private const string FieldTeamIdField = "TeamIdField";
        private const string FieldTimeWorkflowIdField = "TimeWorkflowIdField";
        private const string FieldTimeWorkflowMapIdField = "TimeWorkflowMapIdField";
        private const string FieldTimeshetReportIdField = "TimeshetReportIdField";
        private const string FieldTitleIdField = "TitleIdField";
        private const string FieldUniqueIdField = "UniqueIdField";
        private const string FieldUserIdField = "UserIdField";
        private const string FieldUserResTypeIdField = "UserResTypeIdField";
        private const string FieldWKFLOWORKFLOWMAPIDField = "WKFLOWORKFLOWMAPIDField";
        private const string FieldWorkTypeIdField = "WorkTypeIdField";
        private const string FieldWorkflowEntryIdField = "WorkflowEntryIdField";
        private const string FieldWorkflowIdField = "WorkflowIdField";

        #endregion

        private Type _systemDefaultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private SystemDefault _systemDefaultInstance;
        private SystemDefault _systemDefaultInstanceFixture;

        #region General Initializer : Class (SystemDefault) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SystemDefault" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _systemDefaultInstanceType = typeof(SystemDefault);
            _systemDefaultInstanceFixture = this.Create<SystemDefault>(true);
            _systemDefaultInstance = _systemDefaultInstanceFixture ?? this.Create<SystemDefault>(false);
            CurrentInstance = _systemDefaultInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SystemDefault)

        #region General Initializer : Class (SystemDefault) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="SystemDefault" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRaisePropertyChanged, 0)]
        public void AUT_SystemDefault_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_systemDefaultInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SystemDefault) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="SystemDefault" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyExtensionData)]
        [TestCase(PropertyAccountId)]
        [TestCase(PropertyAccountingConnectionId)]
        [TestCase(PropertyBussinesUnitId)]
        [TestCase(PropertyCalendarSetId)]
        [TestCase(PropertyClassId)]
        [TestCase(PropertyClientId)]
        [TestCase(PropertyComponenetId)]
        [TestCase(PropertyContractId)]
        [TestCase(PropertyContractorId)]
        [TestCase(PropertyCurrencyID)]
        [TestCase(PropertyEquimenetId)]
        [TestCase(PropertyExpenseId)]
        [TestCase(PropertyExpenseWorkflowId)]
        [TestCase(PropertyExpenseWorkflowMapId)]
        [TestCase(PropertyGroupId)]
        [TestCase(PropertyHolidateSetId)]
        [TestCase(PropertyMSChargeId)]
        [TestCase(PropertyMSWorktypeId)]
        [TestCase(PropertyMaterialId)]
        [TestCase(PropertyMilestoneUserId)]
        [TestCase(PropertyPLANNINGROLEID)]
        [TestCase(PropertyPhaseId)]
        [TestCase(PropertyPortfolioBudgetFundingSource)]
        [TestCase(PropertyPortfolioId)]
        [TestCase(PropertyProjectId)]
        [TestCase(PropertyProjectTypeId)]
        [TestCase(PropertyProjectWorkflow)]
        [TestCase(PropertyProjectWorkflowMapId)]
        [TestCase(PropertyPurchaseTaxId)]
        [TestCase(PropertyPurchaseWorkflowId)]
        [TestCase(PropertyPurchaseWorkflowMapId)]
        [TestCase(PropertyReccChargeId)]
        [TestCase(PropertyReccWorktypeId)]
        [TestCase(PropertyReccuringUserID)]
        [TestCase(PropertyReqWorkflowId)]
        [TestCase(PropertyReqWorkflowMapId)]
        [TestCase(PropertySalesTaxId)]
        [TestCase(PropertyShiftId)]
        [TestCase(PropertySiteId)]
        [TestCase(PropertySkillId)]
        [TestCase(PropertySkillSet)]
        [TestCase(PropertySkillsetId)]
        [TestCase(PropertySupplierId)]
        [TestCase(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCase(PropertyTABreakId)]
        [TestCase(PropertyTACCCONSET)]
        [TestCase(PropertyTAScheduleId)]
        [TestCase(PropertyTAShiftId)]
        [TestCase(PropertyTCHARGE)]
        [TestCase(PropertyTCHARGE1)]
        [TestCase(PropertyTWORKTYPE)]
        [TestCase(PropertyTWORKTYPE1)]
        [TestCase(PropertyTaskId)]
        [TestCase(PropertyTeamId)]
        [TestCase(PropertyTimeWorkflowId)]
        [TestCase(PropertyTimeWorkflowMapId)]
        [TestCase(PropertyTimeshetReportId)]
        [TestCase(PropertyTitleId)]
        [TestCase(PropertyUniqueId)]
        [TestCase(PropertyUserId)]
        [TestCase(PropertyUserResTypeId)]
        [TestCase(PropertyWKFLOWORKFLOWMAPID)]
        [TestCase(PropertyWorkTypeId)]
        [TestCase(PropertyWorkflowEntryId)]
        [TestCase(PropertyWorkflowId)]
        public void AUT_SystemDefault_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var propertyInfo = this.GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_systemDefaultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SystemDefault) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SystemDefault" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldextensionDataField)]
        [TestCase(FieldAccountIdField)]
        [TestCase(FieldAccountingConnectionIdField)]
        [TestCase(FieldBussinesUnitIdField)]
        [TestCase(FieldCalendarSetIdField)]
        [TestCase(FieldClassIdField)]
        [TestCase(FieldClientIdField)]
        [TestCase(FieldComponenetIdField)]
        [TestCase(FieldContractIdField)]
        [TestCase(FieldContractorIdField)]
        [TestCase(FieldCurrencyIDField)]
        [TestCase(FieldEquimenetIdField)]
        [TestCase(FieldExpenseIdField)]
        [TestCase(FieldExpenseWorkflowIdField)]
        [TestCase(FieldExpenseWorkflowMapIdField)]
        [TestCase(FieldGroupIdField)]
        [TestCase(FieldHolidateSetIdField)]
        [TestCase(FieldMSChargeIdField)]
        [TestCase(FieldMSWorktypeIdField)]
        [TestCase(FieldMaterialIdField)]
        [TestCase(FieldMilestoneUserIdField)]
        [TestCase(FieldPLANNINGROLEIDField)]
        [TestCase(FieldPhaseIdField)]
        [TestCase(FieldPortfolioBudgetFundingSourceField)]
        [TestCase(FieldPortfolioIdField)]
        [TestCase(FieldProjectIdField)]
        [TestCase(FieldProjectTypeIdField)]
        [TestCase(FieldProjectWorkflowField)]
        [TestCase(FieldProjectWorkflowMapIdField)]
        [TestCase(FieldPurchaseTaxIdField)]
        [TestCase(FieldPurchaseWorkflowIdField)]
        [TestCase(FieldPurchaseWorkflowMapIdField)]
        [TestCase(FieldReccChargeIdField)]
        [TestCase(FieldReccWorktypeIdField)]
        [TestCase(FieldReccuringUserIDField)]
        [TestCase(FieldReqWorkflowIdField)]
        [TestCase(FieldReqWorkflowMapIdField)]
        [TestCase(FieldSalesTaxIdField)]
        [TestCase(FieldShiftIdField)]
        [TestCase(FieldSiteIdField)]
        [TestCase(FieldSkillIdField)]
        [TestCase(FieldSkillSetField)]
        [TestCase(FieldSkillsetIdField)]
        [TestCase(FieldSupplierIdField)]
        [TestCase(FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField)]
        [TestCase(FieldTABreakIdField)]
        [TestCase(FieldTACCCONSETField)]
        [TestCase(FieldTAScheduleIdField)]
        [TestCase(FieldTAShiftIdField)]
        [TestCase(FieldTCHARGEField)]
        [TestCase(FieldTCHARGE1Field)]
        [TestCase(FieldTWORKTYPEField)]
        [TestCase(FieldTWORKTYPE1Field)]
        [TestCase(FieldTaskIdField)]
        [TestCase(FieldTeamIdField)]
        [TestCase(FieldTimeWorkflowIdField)]
        [TestCase(FieldTimeWorkflowMapIdField)]
        [TestCase(FieldTimeshetReportIdField)]
        [TestCase(FieldTitleIdField)]
        [TestCase(FieldUniqueIdField)]
        [TestCase(FieldUserIdField)]
        [TestCase(FieldUserResTypeIdField)]
        [TestCase(FieldWKFLOWORKFLOWMAPIDField)]
        [TestCase(FieldWorkTypeIdField)]
        [TestCase(FieldWorkflowEntryIdField)]
        [TestCase(FieldWorkflowIdField)]
        public void AUT_SystemDefault_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_systemDefaultInstanceFixture, 
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
        ///     Class (<see cref="SystemDefault" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_SystemDefault_Is_Instance_Present_Test()
        {
            // Assert
            _systemDefaultInstanceType.ShouldNotBeNull();
            _systemDefaultInstance.ShouldNotBeNull();
            _systemDefaultInstanceFixture.ShouldNotBeNull();
            _systemDefaultInstance.ShouldBeAssignableTo<SystemDefault>();
            _systemDefaultInstanceFixture.ShouldBeAssignableTo<SystemDefault>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SystemDefault) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_SystemDefault_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SystemDefault instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _systemDefaultInstanceType.ShouldNotBeNull();
            _systemDefaultInstance.ShouldNotBeNull();
            _systemDefaultInstanceFixture.ShouldNotBeNull();
            _systemDefaultInstance.ShouldBeAssignableTo<SystemDefault>();
            _systemDefaultInstanceFixture.ShouldBeAssignableTo<SystemDefault>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (SystemDefault) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(System.Runtime.Serialization.ExtensionDataObject) , PropertyExtensionData)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyAccountId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyAccountingConnectionId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyBussinesUnitId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyCalendarSetId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyClassId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyClientId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyComponenetId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyContractId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyContractorId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyCurrencyID)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyEquimenetId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyExpenseId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyExpenseWorkflowId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyExpenseWorkflowMapId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyGroupId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyHolidateSetId)]
        [TestCaseGeneric(typeof(int) , PropertyMSChargeId)]
        [TestCaseGeneric(typeof(int) , PropertyMSWorktypeId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyMaterialId)]
        [TestCaseGeneric(typeof(int) , PropertyMilestoneUserId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyPLANNINGROLEID)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyPhaseId)]
        [TestCaseGeneric(typeof(string) , PropertyPortfolioBudgetFundingSource)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyPortfolioId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyProjectId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyProjectTypeId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.ProjectWorkflowMap) , PropertyProjectWorkflow)]
        [TestCaseGeneric(typeof(int) , PropertyProjectWorkflowMapId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyPurchaseTaxId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyPurchaseWorkflowId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyPurchaseWorkflowMapId)]
        [TestCaseGeneric(typeof(int) , PropertyReccChargeId)]
        [TestCaseGeneric(typeof(int) , PropertyReccWorktypeId)]
        [TestCaseGeneric(typeof(int) , PropertyReccuringUserID)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyReqWorkflowId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyReqWorkflowMapId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertySalesTaxId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyShiftId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertySiteId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertySkillId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.SkillSet) , PropertySkillSet)]
        [TestCaseGeneric(typeof(int) , PropertySkillsetId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertySupplierId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.EntityKey) , PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTABreakId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.AccountingConnection) , PropertyTACCCONSET)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTAScheduleId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTAShiftId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.Charge) , PropertyTCHARGE)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.Charge) , PropertyTCHARGE1)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.BaseWorkType) , PropertyTWORKTYPE)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.BaseWorkType) , PropertyTWORKTYPE1)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTaskId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTeamId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTimeWorkflowId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTimeWorkflowMapId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTimeshetReportId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTitleId)]
        [TestCaseGeneric(typeof(int) , PropertyUniqueId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyUserId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyUserResTypeId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyWKFLOWORKFLOWMAPID)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyWorkTypeId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyWorkflowEntryId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyWorkflowId)]
        public void AUT_SystemDefault_Property_Type_Verify_Explore_By_Name_Test<T>(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);

            // Assert
            ShouldlyExtension.PropertyTypeVerify<SystemDefault, T>(_systemDefaultInstance, name, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (AccountId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_AccountId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAccountId);
            var propertyInfo  = this.GetPropertyInfo(PropertyAccountId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (AccountingConnectionId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_AccountingConnectionId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAccountingConnectionId);
            var propertyInfo  = this.GetPropertyInfo(PropertyAccountingConnectionId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (BussinesUnitId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_BussinesUnitId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBussinesUnitId);
            var propertyInfo  = this.GetPropertyInfo(PropertyBussinesUnitId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (CalendarSetId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_CalendarSetId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCalendarSetId);
            var propertyInfo  = this.GetPropertyInfo(PropertyCalendarSetId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (ClassId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_ClassId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyClassId);
            var propertyInfo  = this.GetPropertyInfo(PropertyClassId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (ClientId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_ClientId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (SystemDefault) => Property (ComponenetId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_ComponenetId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyComponenetId);
            var propertyInfo  = this.GetPropertyInfo(PropertyComponenetId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (ContractId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_ContractId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyContractId);
            var propertyInfo  = this.GetPropertyInfo(PropertyContractId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (ContractorId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_ContractorId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyContractorId);
            var propertyInfo  = this.GetPropertyInfo(PropertyContractorId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (CurrencyID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_CurrencyID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCurrencyID);
            var propertyInfo  = this.GetPropertyInfo(PropertyCurrencyID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (EquimenetId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_EquimenetId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyEquimenetId);
            var propertyInfo  = this.GetPropertyInfo(PropertyEquimenetId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (ExpenseId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_ExpenseId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (SystemDefault) => Property (ExpenseWorkflowId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_ExpenseWorkflowId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExpenseWorkflowId);
            var propertyInfo  = this.GetPropertyInfo(PropertyExpenseWorkflowId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (ExpenseWorkflowMapId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_ExpenseWorkflowMapId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExpenseWorkflowMapId);
            var propertyInfo  = this.GetPropertyInfo(PropertyExpenseWorkflowMapId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (ExtensionData) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_ExtensionData_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExtensionData);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExtensionData);
            Action currentAction = () => propertyInfo.SetValue(_systemDefaultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (ExtensionData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_ExtensionData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (SystemDefault) => Property (GroupId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_GroupId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyGroupId);
            var propertyInfo  = this.GetPropertyInfo(PropertyGroupId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (HolidateSetId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_HolidateSetId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyHolidateSetId);
            var propertyInfo  = this.GetPropertyInfo(PropertyHolidateSetId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (MaterialId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_MaterialId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMaterialId);
            var propertyInfo  = this.GetPropertyInfo(PropertyMaterialId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (MilestoneUserId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_MilestoneUserId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMilestoneUserId);
            var propertyInfo  = this.GetPropertyInfo(PropertyMilestoneUserId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (MSChargeId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_MSChargeId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMSChargeId);
            var propertyInfo  = this.GetPropertyInfo(PropertyMSChargeId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (MSWorktypeId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_MSWorktypeId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMSWorktypeId);
            var propertyInfo  = this.GetPropertyInfo(PropertyMSWorktypeId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (PhaseId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_PhaseId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPhaseId);
            var propertyInfo  = this.GetPropertyInfo(PropertyPhaseId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (PLANNINGROLEID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_PLANNINGROLEID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPLANNINGROLEID);
            var propertyInfo  = this.GetPropertyInfo(PropertyPLANNINGROLEID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (PortfolioBudgetFundingSource) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_PortfolioBudgetFundingSource_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPortfolioBudgetFundingSource);
            var propertyInfo  = this.GetPropertyInfo(PropertyPortfolioBudgetFundingSource);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (PortfolioId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_PortfolioId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPortfolioId);
            var propertyInfo  = this.GetPropertyInfo(PropertyPortfolioId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (ProjectId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_ProjectId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectId);
            var propertyInfo  = this.GetPropertyInfo(PropertyProjectId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (ProjectTypeId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_ProjectTypeId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectTypeId);
            var propertyInfo  = this.GetPropertyInfo(PropertyProjectTypeId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (ProjectWorkflow) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_ProjectWorkflow_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectWorkflow);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyProjectWorkflow);
            Action currentAction = () => propertyInfo.SetValue(_systemDefaultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (ProjectWorkflow) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_ProjectWorkflow_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectWorkflow);
            var propertyInfo  = this.GetPropertyInfo(PropertyProjectWorkflow);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (ProjectWorkflowMapId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_ProjectWorkflowMapId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectWorkflowMapId);
            var propertyInfo  = this.GetPropertyInfo(PropertyProjectWorkflowMapId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (PurchaseTaxId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_PurchaseTaxId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPurchaseTaxId);
            var propertyInfo  = this.GetPropertyInfo(PropertyPurchaseTaxId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (PurchaseWorkflowId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_PurchaseWorkflowId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPurchaseWorkflowId);
            var propertyInfo  = this.GetPropertyInfo(PropertyPurchaseWorkflowId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (PurchaseWorkflowMapId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_PurchaseWorkflowMapId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPurchaseWorkflowMapId);
            var propertyInfo  = this.GetPropertyInfo(PropertyPurchaseWorkflowMapId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (ReccChargeId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_ReccChargeId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyReccChargeId);
            var propertyInfo  = this.GetPropertyInfo(PropertyReccChargeId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (ReccuringUserID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_ReccuringUserID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyReccuringUserID);
            var propertyInfo  = this.GetPropertyInfo(PropertyReccuringUserID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (ReccWorktypeId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_ReccWorktypeId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyReccWorktypeId);
            var propertyInfo  = this.GetPropertyInfo(PropertyReccWorktypeId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (ReqWorkflowId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_ReqWorkflowId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyReqWorkflowId);
            var propertyInfo  = this.GetPropertyInfo(PropertyReqWorkflowId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (ReqWorkflowMapId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_ReqWorkflowMapId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyReqWorkflowMapId);
            var propertyInfo  = this.GetPropertyInfo(PropertyReqWorkflowMapId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (SalesTaxId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_SalesTaxId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySalesTaxId);
            var propertyInfo  = this.GetPropertyInfo(PropertySalesTaxId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (ShiftId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_ShiftId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyShiftId);
            var propertyInfo  = this.GetPropertyInfo(PropertyShiftId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (SiteId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_SiteId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (SystemDefault) => Property (SkillId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_SkillId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySkillId);
            var propertyInfo  = this.GetPropertyInfo(PropertySkillId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (SkillSet) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_SkillSet_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySkillSet);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySkillSet);
            Action currentAction = () => propertyInfo.SetValue(_systemDefaultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (SkillSet) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_SkillSet_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySkillSet);
            var propertyInfo  = this.GetPropertyInfo(PropertySkillSet);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (SkillsetId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_SkillsetId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySkillsetId);
            var propertyInfo  = this.GetPropertyInfo(PropertySkillsetId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (SupplierId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_SupplierId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySupplierId);
            var propertyInfo  = this.GetPropertyInfo(PropertySupplierId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            Action currentAction = () => propertyInfo.SetValue(_systemDefaultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (SystemDefault) => Property (TABreakId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_TABreakId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTABreakId);
            var propertyInfo  = this.GetPropertyInfo(PropertyTABreakId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (TACCCONSET) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_TACCCONSET_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTACCCONSET);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTACCCONSET);
            Action currentAction = () => propertyInfo.SetValue(_systemDefaultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (TACCCONSET) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_TACCCONSET_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTACCCONSET);
            var propertyInfo  = this.GetPropertyInfo(PropertyTACCCONSET);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (TAScheduleId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_TAScheduleId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTAScheduleId);
            var propertyInfo  = this.GetPropertyInfo(PropertyTAScheduleId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (TAShiftId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_TAShiftId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTAShiftId);
            var propertyInfo  = this.GetPropertyInfo(PropertyTAShiftId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (TaskId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_TaskId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (SystemDefault) => Property (TCHARGE) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_TCHARGE_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTCHARGE);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTCHARGE);
            Action currentAction = () => propertyInfo.SetValue(_systemDefaultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (TCHARGE) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_TCHARGE_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTCHARGE);
            var propertyInfo  = this.GetPropertyInfo(PropertyTCHARGE);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (TCHARGE1) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_TCHARGE1_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTCHARGE1);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTCHARGE1);
            Action currentAction = () => propertyInfo.SetValue(_systemDefaultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (TCHARGE1) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_TCHARGE1_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTCHARGE1);
            var propertyInfo  = this.GetPropertyInfo(PropertyTCHARGE1);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (TeamId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_TeamId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTeamId);
            var propertyInfo  = this.GetPropertyInfo(PropertyTeamId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (TimeshetReportId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_TimeshetReportId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimeshetReportId);
            var propertyInfo  = this.GetPropertyInfo(PropertyTimeshetReportId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (TimeWorkflowId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_TimeWorkflowId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimeWorkflowId);
            var propertyInfo  = this.GetPropertyInfo(PropertyTimeWorkflowId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (TimeWorkflowMapId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_TimeWorkflowMapId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimeWorkflowMapId);
            var propertyInfo  = this.GetPropertyInfo(PropertyTimeWorkflowMapId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (TitleId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_TitleId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTitleId);
            var propertyInfo  = this.GetPropertyInfo(PropertyTitleId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (TWORKTYPE) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_TWORKTYPE_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTWORKTYPE);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTWORKTYPE);
            Action currentAction = () => propertyInfo.SetValue(_systemDefaultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (TWORKTYPE) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_TWORKTYPE_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTWORKTYPE);
            var propertyInfo  = this.GetPropertyInfo(PropertyTWORKTYPE);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (TWORKTYPE1) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_TWORKTYPE1_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTWORKTYPE1);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTWORKTYPE1);
            Action currentAction = () => propertyInfo.SetValue(_systemDefaultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (TWORKTYPE1) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_TWORKTYPE1_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTWORKTYPE1);
            var propertyInfo  = this.GetPropertyInfo(PropertyTWORKTYPE1);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (UniqueId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_UniqueId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (SystemDefault) => Property (UserId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_UserId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (SystemDefault) => Property (UserResTypeId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_UserResTypeId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUserResTypeId);
            var propertyInfo  = this.GetPropertyInfo(PropertyUserResTypeId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (WKFLOWORKFLOWMAPID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_WKFLOWORKFLOWMAPID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWKFLOWORKFLOWMAPID);
            var propertyInfo  = this.GetPropertyInfo(PropertyWKFLOWORKFLOWMAPID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (WorkflowEntryId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_WorkflowEntryId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (SystemDefault) => Property (WorkflowId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_WorkflowId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWorkflowId);
            var propertyInfo  = this.GetPropertyInfo(PropertyWorkflowId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SystemDefault) => Property (WorkTypeId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SystemDefault_Public_Class_WorkTypeId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWorkTypeId);
            var propertyInfo  = this.GetPropertyInfo(PropertyWorkTypeId);

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
        private void AUT_SystemDefault_RaisePropertyChanged_Method_Call_Internally(Type[] types)
        {
            var methodRaisePropertyChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_systemDefaultInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SystemDefault_RaisePropertyChanged_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_systemDefaultInstanceFixture, parametersOfRaisePropertyChanged);

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
        public void AUT_SystemDefault_RaisePropertyChanged_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_systemDefaultInstance, MethodRaisePropertyChanged, parametersOfRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes);

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
        public void AUT_SystemDefault_RaisePropertyChanged_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_SystemDefault_RaisePropertyChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_systemDefaultInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);

            // Assert
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SystemDefault_RaisePropertyChanged_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_systemDefaultInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}