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
using Project = UplandIntegrations.TenroxAssignmentService;

namespace UplandIntegrations.TenroxAssignmentService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxAssignmentService.Project" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxAssignmentService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    public partial class ProjectTest : AbstractBaseSetupV3Test
    {
        public ProjectTest() : base(typeof(Project))
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

        #region General Initializer : Class (Project) Initializer

        #region Properties

        private const string PropertyExtensionData = "ExtensionData";
        private const string PropertyAccConSetId = "AccConSetId";
        private const string PropertyAccessType = "AccessType";
        private const string PropertyActualManager = "ActualManager";
        private const string PropertyActualManagerId = "ActualManagerId";
        private const string PropertyAdoptAcceptFrom = "AdoptAcceptFrom";
        private const string PropertyAdoptAcceptTo = "AdoptAcceptTo";
        private const string PropertyAlignment = "Alignment";
        private const string PropertyAllocationUnit = "AllocationUnit";
        private const string PropertyAllowUserToEditETC = "AllowUserToEditETC";
        private const string PropertyAlternateManager = "AlternateManager";
        private const string PropertyAlternateManagerId = "AlternateManagerId";
        private const string PropertyAnnualDiscountRate = "AnnualDiscountRate";
        private const string PropertyBudgetBill = "BudgetBill";
        private const string PropertyBudgetCost = "BudgetCost";
        private const string PropertyBudgetThreshhold = "BudgetThreshhold";
        private const string PropertyBudgetedTime = "BudgetedTime";
        private const string PropertyCabBeInvoiced = "CabBeInvoiced";
        private const string PropertyChildren = "Children";
        private const string PropertyClient = "Client";
        private const string PropertyClientId = "ClientId";
        private const string PropertyCompletionProbability = "CompletionProbability";
        private const string PropertyCreatedBy = "CreatedBy";
        private const string PropertyCreationDate = "CreationDate";
        private const string PropertyDefaultHoursPerDay = "DefaultHoursPerDay";
        private const string PropertyDefaultPhaseId = "DefaultPhaseId";
        private const string PropertyDefaultWorkday = "DefaultWorkday";
        private const string PropertyDependentProjects = "DependentProjects";
        private const string PropertyDescription = "Description";
        private const string PropertyEmail = "Email";
        private const string PropertyEndDate = "EndDate";
        private const string PropertyEstimateBill = "EstimateBill";
        private const string PropertyEstimateCost = "EstimateCost";
        private const string PropertyEstimateTime = "EstimateTime";
        private const string PropertyExpectedBenefit = "ExpectedBenefit";
        private const string PropertyExpectedCost = "ExpectedCost";
        private const string PropertyExpectedDuration = "ExpectedDuration";
        private const string PropertyExpectedDurationType = "ExpectedDurationType";
        private const string PropertyExpenseReports = "ExpenseReports";
        private const string PropertyForecastBillable = "ForecastBillable";
        private const string PropertyForecastCost = "ForecastCost";
        private const string PropertyHealth = "Health";
        private const string PropertyHierarchyCode = "HierarchyCode";
        private const string PropertyId = "Id";
        private const string PropertyIsBillable = "IsBillable";
        private const string PropertyIsCapitalized = "IsCapitalized";
        private const string PropertyIsCosted = "IsCosted";
        private const string PropertyIsFunded = "IsFunded";
        private const string PropertyIsPlaceholder = "IsPlaceholder";
        private const string PropertyIsRandD = "IsRandD";
        private const string PropertyJustificationSummary = "JustificationSummary";
        private const string PropertyLevelNumber = "LevelNumber";
        private const string PropertyMSProjectFilePath = "MSProjectFilePath";
        private const string PropertyMailUserId = "MailUserId";
        private const string PropertyManager = "Manager";
        private const string PropertyManagerAutoApproved = "ManagerAutoApproved";
        private const string PropertyManagerId = "ManagerId";
        private const string PropertyMinimumBudgetRequested = "MinimumBudgetRequested";
        private const string PropertyMustFund = "MustFund";
        private const string PropertyMustFundReason = "MustFundReason";
        private const string PropertyName = "Name";
        private const string PropertyOverrideBillable = "OverrideBillable";
        private const string PropertyOverrideCapitalized = "OverrideCapitalized";
        private const string PropertyOverrideCosted = "OverrideCosted";
        private const string PropertyOverrideFunded = "OverrideFunded";
        private const string PropertyOverridePlan = "OverridePlan";
        private const string PropertyOverrideRandD = "OverrideRandD";
        private const string PropertyPPBBaseLines = "PPBBaseLines";
        private const string PropertyPPMExpectedCostBenefits = "PPMExpectedCostBenefits";
        private const string PropertyPPMExpectedDurations = "PPMExpectedDurations";
        private const string PropertyPPMGoals = "PPMGoals";
        private const string PropertyPPMProjectDependencies = "PPMProjectDependencies";
        private const string PropertyPPMResourceAllocations = "PPMResourceAllocations";
        private const string PropertyPPMSponsors = "PPMSponsors";
        private const string PropertyPPMTimeHorizons = "PPMTimeHorizons";
        private const string PropertyPROJECTCONTACTID = "PROJECTCONTACTID";
        private const string PropertyParent = "Parent";
        private const string PropertyParentId = "ParentId";
        private const string PropertyPhealth = "Phealth";
        private const string PropertyPlannedEndDate = "PlannedEndDate";
        private const string PropertyPlannedStartDate = "PlannedStartDate";
        private const string PropertyPortfolio = "Portfolio";
        private const string PropertyPortfolioAllocatedBudgets = "PortfolioAllocatedBudgets";
        private const string PropertyPortfolioId = "PortfolioId";
        private const string PropertyPriority = "Priority";
        private const string PropertyProjectRevenueRecognitionPreference = "ProjectRevenueRecognitionPreference";
        private const string PropertyProjectScheduling = "ProjectScheduling";
        private const string PropertyProjectSchedulingId = "ProjectSchedulingId";
        private const string PropertyProjectType = "ProjectType";
        private const string PropertyProjectTypeId = "ProjectTypeId";
        private const string PropertyProjectVersionId = "ProjectVersionId";
        private const string PropertyProjectWorkflowMapId = "ProjectWorkflowMapId";
        private const string PropertyReleaseAlias = "ReleaseAlias";
        private const string PropertyRevenueAccount = "RevenueAccount";
        private const string PropertyRevenueRecognitionAccountId = "RevenueRecognitionAccountId";
        private const string PropertyStartDate = "StartDate";
        private const string PropertyState = "State";
        private const string PropertyStatus = "Status";
        private const string PropertySuspend = "Suspend";
        private const string PropertySuspendIfExceeded = "SuspendIfExceeded";
        private const string PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey";
        private const string PropertyTACCOUNT = "TACCOUNT";
        private const string PropertyTACCOUNT1 = "TACCOUNT1";
        private const string PropertyTACCOUNT2 = "TACCOUNT2";
        private const string PropertyTMILEST = "TMILEST";
        private const string PropertyTask = "Task";
        private const string PropertyTerminationCostPeriod = "TerminationCostPeriod";
        private const string PropertyTimeEntryNotesOption = "TimeEntryNotesOption";
        private const string PropertyTimeHorizon = "TimeHorizon";
        private const string PropertyTrackingNo = "TrackingNo";
        private const string PropertyUnearnedRevenueAccount = "UnearnedRevenueAccount";
        private const string PropertyUniqueId = "UniqueId";
        private const string PropertyUpdatedOn = "UpdatedOn";
        private const string PropertyWIPAccount = "WIPAccount";
        private const string PropertyWIPRule = "WIPRule";

        #endregion

        #region Methods

        private const string MethodRaisePropertyChanged = "RaisePropertyChanged";

        #endregion

        #region Fields

        private const string FieldextensionDataField = "extensionDataField";
        private const string FieldAccConSetIdField = "AccConSetIdField";
        private const string FieldAccessTypeField = "AccessTypeField";
        private const string FieldActualManagerField = "ActualManagerField";
        private const string FieldActualManagerIdField = "ActualManagerIdField";
        private const string FieldAdoptAcceptFromField = "AdoptAcceptFromField";
        private const string FieldAdoptAcceptToField = "AdoptAcceptToField";
        private const string FieldAlignmentField = "AlignmentField";
        private const string FieldAllocationUnitField = "AllocationUnitField";
        private const string FieldAllowUserToEditETCField = "AllowUserToEditETCField";
        private const string FieldAlternateManagerField = "AlternateManagerField";
        private const string FieldAlternateManagerIdField = "AlternateManagerIdField";
        private const string FieldAnnualDiscountRateField = "AnnualDiscountRateField";
        private const string FieldBudgetBillField = "BudgetBillField";
        private const string FieldBudgetCostField = "BudgetCostField";
        private const string FieldBudgetThreshholdField = "BudgetThreshholdField";
        private const string FieldBudgetedTimeField = "BudgetedTimeField";
        private const string FieldCabBeInvoicedField = "CabBeInvoicedField";
        private const string FieldChildrenField = "ChildrenField";
        private const string FieldClientField = "ClientField";
        private const string FieldClientIdField = "ClientIdField";
        private const string FieldCompletionProbabilityField = "CompletionProbabilityField";
        private const string FieldCreatedByField = "CreatedByField";
        private const string FieldCreationDateField = "CreationDateField";
        private const string FieldDefaultHoursPerDayField = "DefaultHoursPerDayField";
        private const string FieldDefaultPhaseIdField = "DefaultPhaseIdField";
        private const string FieldDefaultWorkdayField = "DefaultWorkdayField";
        private const string FieldDependentProjectsField = "DependentProjectsField";
        private const string FieldDescriptionField = "DescriptionField";
        private const string FieldEmailField = "EmailField";
        private const string FieldEndDateField = "EndDateField";
        private const string FieldEstimateBillField = "EstimateBillField";
        private const string FieldEstimateCostField = "EstimateCostField";
        private const string FieldEstimateTimeField = "EstimateTimeField";
        private const string FieldExpectedBenefitField = "ExpectedBenefitField";
        private const string FieldExpectedCostField = "ExpectedCostField";
        private const string FieldExpectedDurationField = "ExpectedDurationField";
        private const string FieldExpectedDurationTypeField = "ExpectedDurationTypeField";
        private const string FieldExpenseReportsField = "ExpenseReportsField";
        private const string FieldForecastBillableField = "ForecastBillableField";
        private const string FieldForecastCostField = "ForecastCostField";
        private const string FieldHealthField = "HealthField";
        private const string FieldHierarchyCodeField = "HierarchyCodeField";
        private const string FieldIdField = "IdField";
        private const string FieldIsBillableField = "IsBillableField";
        private const string FieldIsCapitalizedField = "IsCapitalizedField";
        private const string FieldIsCostedField = "IsCostedField";
        private const string FieldIsFundedField = "IsFundedField";
        private const string FieldIsPlaceholderField = "IsPlaceholderField";
        private const string FieldIsRandDField = "IsRandDField";
        private const string FieldJustificationSummaryField = "JustificationSummaryField";
        private const string FieldLevelNumberField = "LevelNumberField";
        private const string FieldMSProjectFilePathField = "MSProjectFilePathField";
        private const string FieldMailUserIdField = "MailUserIdField";
        private const string FieldManagerField = "ManagerField";
        private const string FieldManagerAutoApprovedField = "ManagerAutoApprovedField";
        private const string FieldManagerIdField = "ManagerIdField";
        private const string FieldMinimumBudgetRequestedField = "MinimumBudgetRequestedField";
        private const string FieldMustFundField = "MustFundField";
        private const string FieldMustFundReasonField = "MustFundReasonField";
        private const string FieldNameField = "NameField";
        private const string FieldOverrideBillableField = "OverrideBillableField";
        private const string FieldOverrideCapitalizedField = "OverrideCapitalizedField";
        private const string FieldOverrideCostedField = "OverrideCostedField";
        private const string FieldOverrideFundedField = "OverrideFundedField";
        private const string FieldOverridePlanField = "OverridePlanField";
        private const string FieldOverrideRandDField = "OverrideRandDField";
        private const string FieldPPBBaseLinesField = "PPBBaseLinesField";
        private const string FieldPPMExpectedCostBenefitsField = "PPMExpectedCostBenefitsField";
        private const string FieldPPMExpectedDurationsField = "PPMExpectedDurationsField";
        private const string FieldPPMGoalsField = "PPMGoalsField";
        private const string FieldPPMProjectDependenciesField = "PPMProjectDependenciesField";
        private const string FieldPPMResourceAllocationsField = "PPMResourceAllocationsField";
        private const string FieldPPMSponsorsField = "PPMSponsorsField";
        private const string FieldPPMTimeHorizonsField = "PPMTimeHorizonsField";
        private const string FieldPROJECTCONTACTIDField = "PROJECTCONTACTIDField";
        private const string FieldParentField = "ParentField";
        private const string FieldParentIdField = "ParentIdField";
        private const string FieldPhealthField = "PhealthField";
        private const string FieldPlannedEndDateField = "PlannedEndDateField";
        private const string FieldPlannedStartDateField = "PlannedStartDateField";
        private const string FieldPortfolioField = "PortfolioField";
        private const string FieldPortfolioAllocatedBudgetsField = "PortfolioAllocatedBudgetsField";
        private const string FieldPortfolioIdField = "PortfolioIdField";
        private const string FieldPriorityField = "PriorityField";
        private const string FieldProjectRevenueRecognitionPreferenceField = "ProjectRevenueRecognitionPreferenceField";
        private const string FieldProjectSchedulingField = "ProjectSchedulingField";
        private const string FieldProjectSchedulingIdField = "ProjectSchedulingIdField";
        private const string FieldProjectTypeField = "ProjectTypeField";
        private const string FieldProjectTypeIdField = "ProjectTypeIdField";
        private const string FieldProjectVersionIdField = "ProjectVersionIdField";
        private const string FieldProjectWorkflowMapIdField = "ProjectWorkflowMapIdField";
        private const string FieldReleaseAliasField = "ReleaseAliasField";
        private const string FieldRevenueAccountField = "RevenueAccountField";
        private const string FieldRevenueRecognitionAccountIdField = "RevenueRecognitionAccountIdField";
        private const string FieldStartDateField = "StartDateField";
        private const string FieldStateField = "StateField";
        private const string FieldStatusField = "StatusField";
        private const string FieldSuspendField = "SuspendField";
        private const string FieldSuspendIfExceededField = "SuspendIfExceededField";
        private const string FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField = "SystemDataObjectsDataClassesIEntityWithKeyEntityKeyField";
        private const string FieldTACCOUNTField = "TACCOUNTField";
        private const string FieldTACCOUNT1Field = "TACCOUNT1Field";
        private const string FieldTACCOUNT2Field = "TACCOUNT2Field";
        private const string FieldTMILESTField = "TMILESTField";
        private const string FieldTaskField = "TaskField";
        private const string FieldTerminationCostPeriodField = "TerminationCostPeriodField";
        private const string FieldTimeEntryNotesOptionField = "TimeEntryNotesOptionField";
        private const string FieldTimeHorizonField = "TimeHorizonField";
        private const string FieldTrackingNoField = "TrackingNoField";
        private const string FieldUnearnedRevenueAccountField = "UnearnedRevenueAccountField";
        private const string FieldUniqueIdField = "UniqueIdField";
        private const string FieldUpdatedOnField = "UpdatedOnField";
        private const string FieldWIPAccountField = "WIPAccountField";
        private const string FieldWIPRuleField = "WIPRuleField";

        #endregion

        private Type _projectInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private Project _projectInstance;
        private Project _projectInstanceFixture;

        #region General Initializer : Class (Project) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Project" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _projectInstanceType = typeof(Project);
            _projectInstanceFixture = this.Create<Project>(true);
            _projectInstance = _projectInstanceFixture ?? this.Create<Project>(false);
            CurrentInstance = _projectInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Project)

        #region General Initializer : Class (Project) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Project" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRaisePropertyChanged, 0)]
        public void AUT_Project_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_projectInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Project) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Project" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyExtensionData)]
        [TestCase(PropertyAccConSetId)]
        [TestCase(PropertyAccessType)]
        [TestCase(PropertyActualManager)]
        [TestCase(PropertyActualManagerId)]
        [TestCase(PropertyAdoptAcceptFrom)]
        [TestCase(PropertyAdoptAcceptTo)]
        [TestCase(PropertyAlignment)]
        [TestCase(PropertyAllocationUnit)]
        [TestCase(PropertyAllowUserToEditETC)]
        [TestCase(PropertyAlternateManager)]
        [TestCase(PropertyAlternateManagerId)]
        [TestCase(PropertyAnnualDiscountRate)]
        [TestCase(PropertyBudgetBill)]
        [TestCase(PropertyBudgetCost)]
        [TestCase(PropertyBudgetThreshhold)]
        [TestCase(PropertyBudgetedTime)]
        [TestCase(PropertyCabBeInvoiced)]
        [TestCase(PropertyChildren)]
        [TestCase(PropertyClient)]
        [TestCase(PropertyClientId)]
        [TestCase(PropertyCompletionProbability)]
        [TestCase(PropertyCreatedBy)]
        [TestCase(PropertyCreationDate)]
        [TestCase(PropertyDefaultHoursPerDay)]
        [TestCase(PropertyDefaultPhaseId)]
        [TestCase(PropertyDefaultWorkday)]
        [TestCase(PropertyDependentProjects)]
        [TestCase(PropertyDescription)]
        [TestCase(PropertyEmail)]
        [TestCase(PropertyEndDate)]
        [TestCase(PropertyEstimateBill)]
        [TestCase(PropertyEstimateCost)]
        [TestCase(PropertyEstimateTime)]
        [TestCase(PropertyExpectedBenefit)]
        [TestCase(PropertyExpectedCost)]
        [TestCase(PropertyExpectedDuration)]
        [TestCase(PropertyExpectedDurationType)]
        [TestCase(PropertyExpenseReports)]
        [TestCase(PropertyForecastBillable)]
        [TestCase(PropertyForecastCost)]
        [TestCase(PropertyHealth)]
        [TestCase(PropertyHierarchyCode)]
        [TestCase(PropertyId)]
        [TestCase(PropertyIsBillable)]
        [TestCase(PropertyIsCapitalized)]
        [TestCase(PropertyIsCosted)]
        [TestCase(PropertyIsFunded)]
        [TestCase(PropertyIsPlaceholder)]
        [TestCase(PropertyIsRandD)]
        [TestCase(PropertyJustificationSummary)]
        [TestCase(PropertyLevelNumber)]
        [TestCase(PropertyMSProjectFilePath)]
        [TestCase(PropertyMailUserId)]
        [TestCase(PropertyManager)]
        [TestCase(PropertyManagerAutoApproved)]
        [TestCase(PropertyManagerId)]
        [TestCase(PropertyMinimumBudgetRequested)]
        [TestCase(PropertyMustFund)]
        [TestCase(PropertyMustFundReason)]
        [TestCase(PropertyName)]
        [TestCase(PropertyOverrideBillable)]
        [TestCase(PropertyOverrideCapitalized)]
        [TestCase(PropertyOverrideCosted)]
        [TestCase(PropertyOverrideFunded)]
        [TestCase(PropertyOverridePlan)]
        [TestCase(PropertyOverrideRandD)]
        [TestCase(PropertyPPBBaseLines)]
        [TestCase(PropertyPPMExpectedCostBenefits)]
        [TestCase(PropertyPPMExpectedDurations)]
        [TestCase(PropertyPPMGoals)]
        [TestCase(PropertyPPMProjectDependencies)]
        [TestCase(PropertyPPMResourceAllocations)]
        [TestCase(PropertyPPMSponsors)]
        [TestCase(PropertyPPMTimeHorizons)]
        [TestCase(PropertyPROJECTCONTACTID)]
        [TestCase(PropertyParent)]
        [TestCase(PropertyParentId)]
        [TestCase(PropertyPhealth)]
        [TestCase(PropertyPlannedEndDate)]
        [TestCase(PropertyPlannedStartDate)]
        [TestCase(PropertyPortfolio)]
        [TestCase(PropertyPortfolioAllocatedBudgets)]
        [TestCase(PropertyPortfolioId)]
        [TestCase(PropertyPriority)]
        [TestCase(PropertyProjectRevenueRecognitionPreference)]
        [TestCase(PropertyProjectScheduling)]
        [TestCase(PropertyProjectSchedulingId)]
        [TestCase(PropertyProjectType)]
        [TestCase(PropertyProjectTypeId)]
        [TestCase(PropertyProjectVersionId)]
        [TestCase(PropertyProjectWorkflowMapId)]
        [TestCase(PropertyReleaseAlias)]
        [TestCase(PropertyRevenueAccount)]
        [TestCase(PropertyRevenueRecognitionAccountId)]
        [TestCase(PropertyStartDate)]
        [TestCase(PropertyState)]
        [TestCase(PropertyStatus)]
        [TestCase(PropertySuspend)]
        [TestCase(PropertySuspendIfExceeded)]
        [TestCase(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCase(PropertyTACCOUNT)]
        [TestCase(PropertyTACCOUNT1)]
        [TestCase(PropertyTACCOUNT2)]
        [TestCase(PropertyTMILEST)]
        [TestCase(PropertyTask)]
        [TestCase(PropertyTerminationCostPeriod)]
        [TestCase(PropertyTimeEntryNotesOption)]
        [TestCase(PropertyTimeHorizon)]
        [TestCase(PropertyTrackingNo)]
        [TestCase(PropertyUnearnedRevenueAccount)]
        [TestCase(PropertyUniqueId)]
        [TestCase(PropertyUpdatedOn)]
        [TestCase(PropertyWIPAccount)]
        [TestCase(PropertyWIPRule)]
        public void AUT_Project_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var propertyInfo = this.GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_projectInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Project) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Project" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldextensionDataField)]
        [TestCase(FieldAccConSetIdField)]
        [TestCase(FieldAccessTypeField)]
        [TestCase(FieldActualManagerField)]
        [TestCase(FieldActualManagerIdField)]
        [TestCase(FieldAdoptAcceptFromField)]
        [TestCase(FieldAdoptAcceptToField)]
        [TestCase(FieldAlignmentField)]
        [TestCase(FieldAllocationUnitField)]
        [TestCase(FieldAllowUserToEditETCField)]
        [TestCase(FieldAlternateManagerField)]
        [TestCase(FieldAlternateManagerIdField)]
        [TestCase(FieldAnnualDiscountRateField)]
        [TestCase(FieldBudgetBillField)]
        [TestCase(FieldBudgetCostField)]
        [TestCase(FieldBudgetThreshholdField)]
        [TestCase(FieldBudgetedTimeField)]
        [TestCase(FieldCabBeInvoicedField)]
        [TestCase(FieldChildrenField)]
        [TestCase(FieldClientField)]
        [TestCase(FieldClientIdField)]
        [TestCase(FieldCompletionProbabilityField)]
        [TestCase(FieldCreatedByField)]
        [TestCase(FieldCreationDateField)]
        [TestCase(FieldDefaultHoursPerDayField)]
        [TestCase(FieldDefaultPhaseIdField)]
        [TestCase(FieldDefaultWorkdayField)]
        [TestCase(FieldDependentProjectsField)]
        [TestCase(FieldDescriptionField)]
        [TestCase(FieldEmailField)]
        [TestCase(FieldEndDateField)]
        [TestCase(FieldEstimateBillField)]
        [TestCase(FieldEstimateCostField)]
        [TestCase(FieldEstimateTimeField)]
        [TestCase(FieldExpectedBenefitField)]
        [TestCase(FieldExpectedCostField)]
        [TestCase(FieldExpectedDurationField)]
        [TestCase(FieldExpectedDurationTypeField)]
        [TestCase(FieldExpenseReportsField)]
        [TestCase(FieldForecastBillableField)]
        [TestCase(FieldForecastCostField)]
        [TestCase(FieldHealthField)]
        [TestCase(FieldHierarchyCodeField)]
        [TestCase(FieldIdField)]
        [TestCase(FieldIsBillableField)]
        [TestCase(FieldIsCapitalizedField)]
        [TestCase(FieldIsCostedField)]
        [TestCase(FieldIsFundedField)]
        [TestCase(FieldIsPlaceholderField)]
        [TestCase(FieldIsRandDField)]
        [TestCase(FieldJustificationSummaryField)]
        [TestCase(FieldLevelNumberField)]
        [TestCase(FieldMSProjectFilePathField)]
        [TestCase(FieldMailUserIdField)]
        [TestCase(FieldManagerField)]
        [TestCase(FieldManagerAutoApprovedField)]
        [TestCase(FieldManagerIdField)]
        [TestCase(FieldMinimumBudgetRequestedField)]
        [TestCase(FieldMustFundField)]
        [TestCase(FieldMustFundReasonField)]
        [TestCase(FieldNameField)]
        [TestCase(FieldOverrideBillableField)]
        [TestCase(FieldOverrideCapitalizedField)]
        [TestCase(FieldOverrideCostedField)]
        [TestCase(FieldOverrideFundedField)]
        [TestCase(FieldOverridePlanField)]
        [TestCase(FieldOverrideRandDField)]
        [TestCase(FieldPPBBaseLinesField)]
        [TestCase(FieldPPMExpectedCostBenefitsField)]
        [TestCase(FieldPPMExpectedDurationsField)]
        [TestCase(FieldPPMGoalsField)]
        [TestCase(FieldPPMProjectDependenciesField)]
        [TestCase(FieldPPMResourceAllocationsField)]
        [TestCase(FieldPPMSponsorsField)]
        [TestCase(FieldPPMTimeHorizonsField)]
        [TestCase(FieldPROJECTCONTACTIDField)]
        [TestCase(FieldParentField)]
        [TestCase(FieldParentIdField)]
        [TestCase(FieldPhealthField)]
        [TestCase(FieldPlannedEndDateField)]
        [TestCase(FieldPlannedStartDateField)]
        [TestCase(FieldPortfolioField)]
        [TestCase(FieldPortfolioAllocatedBudgetsField)]
        [TestCase(FieldPortfolioIdField)]
        [TestCase(FieldPriorityField)]
        [TestCase(FieldProjectRevenueRecognitionPreferenceField)]
        [TestCase(FieldProjectSchedulingField)]
        [TestCase(FieldProjectSchedulingIdField)]
        [TestCase(FieldProjectTypeField)]
        [TestCase(FieldProjectTypeIdField)]
        [TestCase(FieldProjectVersionIdField)]
        [TestCase(FieldProjectWorkflowMapIdField)]
        [TestCase(FieldReleaseAliasField)]
        [TestCase(FieldRevenueAccountField)]
        [TestCase(FieldRevenueRecognitionAccountIdField)]
        [TestCase(FieldStartDateField)]
        [TestCase(FieldStateField)]
        [TestCase(FieldStatusField)]
        [TestCase(FieldSuspendField)]
        [TestCase(FieldSuspendIfExceededField)]
        [TestCase(FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField)]
        [TestCase(FieldTACCOUNTField)]
        [TestCase(FieldTACCOUNT1Field)]
        [TestCase(FieldTACCOUNT2Field)]
        [TestCase(FieldTMILESTField)]
        [TestCase(FieldTaskField)]
        [TestCase(FieldTerminationCostPeriodField)]
        [TestCase(FieldTimeEntryNotesOptionField)]
        [TestCase(FieldTimeHorizonField)]
        [TestCase(FieldTrackingNoField)]
        [TestCase(FieldUnearnedRevenueAccountField)]
        [TestCase(FieldUniqueIdField)]
        [TestCase(FieldUpdatedOnField)]
        [TestCase(FieldWIPAccountField)]
        [TestCase(FieldWIPRuleField)]
        public void AUT_Project_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_projectInstanceFixture, 
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
        ///     Class (<see cref="Project" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Project_Is_Instance_Present_Test()
        {
            // Assert
            _projectInstanceType.ShouldNotBeNull();
            _projectInstance.ShouldNotBeNull();
            _projectInstanceFixture.ShouldNotBeNull();
            _projectInstance.ShouldBeAssignableTo<Project>();
            _projectInstanceFixture.ShouldBeAssignableTo<Project>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Project) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Project_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Project instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _projectInstanceType.ShouldNotBeNull();
            _projectInstance.ShouldNotBeNull();
            _projectInstanceFixture.ShouldNotBeNull();
            _projectInstance.ShouldBeAssignableTo<Project>();
            _projectInstanceFixture.ShouldBeAssignableTo<Project>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Project) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(System.Runtime.Serialization.ExtensionDataObject) , PropertyExtensionData)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyAccConSetId)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyAccessType)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.User) , PropertyActualManager)]
        [TestCaseGeneric(typeof(int) , PropertyActualManagerId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyAdoptAcceptFrom)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyAdoptAcceptTo)]
        [TestCaseGeneric(typeof(string) , PropertyAlignment)]
        [TestCaseGeneric(typeof(string) , PropertyAllocationUnit)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyAllowUserToEditETC)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.User) , PropertyAlternateManager)]
        [TestCaseGeneric(typeof(int) , PropertyAlternateManagerId)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyAnnualDiscountRate)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyBudgetBill)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyBudgetCost)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyBudgetThreshhold)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyBudgetedTime)]
        [TestCaseGeneric(typeof(short) , PropertyCabBeInvoiced)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.Project[]) , PropertyChildren)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.Client) , PropertyClient)]
        [TestCaseGeneric(typeof(int) , PropertyClientId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyCompletionProbability)]
        [TestCaseGeneric(typeof(int) , PropertyCreatedBy)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyCreationDate)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyDefaultHoursPerDay)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyDefaultPhaseId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyDefaultWorkday)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.PPMProjectDependency[]) , PropertyDependentProjects)]
        [TestCaseGeneric(typeof(string) , PropertyDescription)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyEmail)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyEndDate)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyEstimateBill)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyEstimateCost)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyEstimateTime)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyExpectedBenefit)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyExpectedCost)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyExpectedDuration)]
        [TestCaseGeneric(typeof(string) , PropertyExpectedDurationType)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.ExpenseReport[]) , PropertyExpenseReports)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyForecastBillable)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyForecastCost)]
        [TestCaseGeneric(typeof(string) , PropertyHealth)]
        [TestCaseGeneric(typeof(string) , PropertyHierarchyCode)]
        [TestCaseGeneric(typeof(string) , PropertyId)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsBillable)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsCapitalized)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsCosted)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsFunded)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsPlaceholder)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsRandD)]
        [TestCaseGeneric(typeof(string) , PropertyJustificationSummary)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyLevelNumber)]
        [TestCaseGeneric(typeof(string) , PropertyMSProjectFilePath)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyMailUserId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.User) , PropertyManager)]
        [TestCaseGeneric(typeof(short) , PropertyManagerAutoApproved)]
        [TestCaseGeneric(typeof(int) , PropertyManagerId)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyMinimumBudgetRequested)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyMustFund)]
        [TestCaseGeneric(typeof(string) , PropertyMustFundReason)]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyOverrideBillable)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyOverrideCapitalized)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyOverrideCosted)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyOverrideFunded)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyOverridePlan)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyOverrideRandD)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.PPMBaseLine[]) , PropertyPPBBaseLines)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.PPMExpectedCostBenefit[]) , PropertyPPMExpectedCostBenefits)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.PPMExpectedDuration[]) , PropertyPPMExpectedDurations)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.PPMGoal[]) , PropertyPPMGoals)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.PPMProjectDependency[]) , PropertyPPMProjectDependencies)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.PPMResourceAllocation[]) , PropertyPPMResourceAllocations)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.PPMSponsor[]) , PropertyPPMSponsors)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.PPMTimeHorizon[]) , PropertyPPMTimeHorizons)]
        [TestCaseGeneric(typeof(int) , PropertyPROJECTCONTACTID)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.Project) , PropertyParent)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyParentId)]
        [TestCaseGeneric(typeof(string) , PropertyPhealth)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyPlannedEndDate)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyPlannedStartDate)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.Portfolio) , PropertyPortfolio)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.PortfolioAllocatedBudget[]) , PropertyPortfolioAllocatedBudgets)]
        [TestCaseGeneric(typeof(int) , PropertyPortfolioId)]
        [TestCaseGeneric(typeof(string) , PropertyPriority)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.ProjectRevenueRecognitionPreference) , PropertyProjectRevenueRecognitionPreference)]
        [TestCaseGeneric(typeof(short) , PropertyProjectScheduling)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyProjectSchedulingId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.ProjectType) , PropertyProjectType)]
        [TestCaseGeneric(typeof(int) , PropertyProjectTypeId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyProjectVersionId)]
        [TestCaseGeneric(typeof(int) , PropertyProjectWorkflowMapId)]
        [TestCaseGeneric(typeof(string) , PropertyReleaseAlias)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyRevenueAccount)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyRevenueRecognitionAccountId)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyStartDate)]
        [TestCaseGeneric(typeof(string) , PropertyState)]
        [TestCaseGeneric(typeof(string) , PropertyStatus)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertySuspend)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertySuspendIfExceeded)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.EntityKey) , PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.Account) , PropertyTACCOUNT)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.Account) , PropertyTACCOUNT1)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.Account) , PropertyTACCOUNT2)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.Milestone[]) , PropertyTMILEST)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.Task[]) , PropertyTask)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTerminationCostPeriod)]
        [TestCaseGeneric(typeof(string) , PropertyTimeEntryNotesOption)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTimeHorizon)]
        [TestCaseGeneric(typeof(string) , PropertyTrackingNo)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyUnearnedRevenueAccount)]
        [TestCaseGeneric(typeof(int) , PropertyUniqueId)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyUpdatedOn)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyWIPAccount)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyWIPRule)]
        public void AUT_Project_Property_Type_Verify_Explore_By_Name_Test<T>(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);

            // Assert
            ShouldlyExtension.PropertyTypeVerify<Project, T>(_projectInstance, name, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (AccConSetId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_AccConSetId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAccConSetId);
            var propertyInfo  = this.GetPropertyInfo(PropertyAccConSetId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (AccessType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_AccessType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Project) => Property (ActualManager) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_ActualManager_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyActualManager);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyActualManager);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (ActualManager) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_ActualManager_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyActualManager);
            var propertyInfo  = this.GetPropertyInfo(PropertyActualManager);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (ActualManagerId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_ActualManagerId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyActualManagerId);
            var propertyInfo  = this.GetPropertyInfo(PropertyActualManagerId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (AdoptAcceptFrom) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_AdoptAcceptFrom_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAdoptAcceptFrom);
            var propertyInfo  = this.GetPropertyInfo(PropertyAdoptAcceptFrom);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (AdoptAcceptTo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_AdoptAcceptTo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAdoptAcceptTo);
            var propertyInfo  = this.GetPropertyInfo(PropertyAdoptAcceptTo);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (Alignment) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_Alignment_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAlignment);
            var propertyInfo  = this.GetPropertyInfo(PropertyAlignment);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (AllocationUnit) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_AllocationUnit_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAllocationUnit);
            var propertyInfo  = this.GetPropertyInfo(PropertyAllocationUnit);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (AllowUserToEditETC) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_AllowUserToEditETC_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAllowUserToEditETC);
            var propertyInfo  = this.GetPropertyInfo(PropertyAllowUserToEditETC);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (AlternateManager) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_AlternateManager_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAlternateManager);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyAlternateManager);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (AlternateManager) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_AlternateManager_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAlternateManager);
            var propertyInfo  = this.GetPropertyInfo(PropertyAlternateManager);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (AlternateManagerId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_AlternateManagerId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAlternateManagerId);
            var propertyInfo  = this.GetPropertyInfo(PropertyAlternateManagerId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (AnnualDiscountRate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_AnnualDiscountRate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAnnualDiscountRate);
            var propertyInfo  = this.GetPropertyInfo(PropertyAnnualDiscountRate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (BudgetBill) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_BudgetBill_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBudgetBill);
            var propertyInfo  = this.GetPropertyInfo(PropertyBudgetBill);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (BudgetCost) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_BudgetCost_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBudgetCost);
            var propertyInfo  = this.GetPropertyInfo(PropertyBudgetCost);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (BudgetedTime) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_BudgetedTime_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBudgetedTime);
            var propertyInfo  = this.GetPropertyInfo(PropertyBudgetedTime);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (BudgetThreshhold) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_BudgetThreshhold_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBudgetThreshhold);
            var propertyInfo  = this.GetPropertyInfo(PropertyBudgetThreshhold);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (CabBeInvoiced) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_CabBeInvoiced_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCabBeInvoiced);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyCabBeInvoiced);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (CabBeInvoiced) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_CabBeInvoiced_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCabBeInvoiced);
            var propertyInfo  = this.GetPropertyInfo(PropertyCabBeInvoiced);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (Children) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Children_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyChildren);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyChildren);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (Children) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_Children_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyChildren);
            var propertyInfo  = this.GetPropertyInfo(PropertyChildren);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (Client) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Client_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyClient);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyClient);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (Client) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_Client_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Project) => Property (ClientId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_ClientId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Project) => Property (CompletionProbability) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_CompletionProbability_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCompletionProbability);
            var propertyInfo  = this.GetPropertyInfo(PropertyCompletionProbability);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (CreatedBy) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_CreatedBy_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Project) => Property (CreationDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_CreationDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCreationDate);
            var propertyInfo  = this.GetPropertyInfo(PropertyCreationDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (DefaultHoursPerDay) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_DefaultHoursPerDay_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDefaultHoursPerDay);
            var propertyInfo  = this.GetPropertyInfo(PropertyDefaultHoursPerDay);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (DefaultPhaseId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_DefaultPhaseId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDefaultPhaseId);
            var propertyInfo  = this.GetPropertyInfo(PropertyDefaultPhaseId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (DefaultWorkday) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_DefaultWorkday_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDefaultWorkday);
            var propertyInfo  = this.GetPropertyInfo(PropertyDefaultWorkday);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (DependentProjects) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_DependentProjects_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDependentProjects);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyDependentProjects);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (DependentProjects) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_DependentProjects_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDependentProjects);
            var propertyInfo  = this.GetPropertyInfo(PropertyDependentProjects);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (Description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_Description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Project) => Property (Email) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_Email_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyEmail);
            var propertyInfo  = this.GetPropertyInfo(PropertyEmail);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (EndDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_EndDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyEndDate);
            var propertyInfo  = this.GetPropertyInfo(PropertyEndDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (EstimateBill) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_EstimateBill_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyEstimateBill);
            var propertyInfo  = this.GetPropertyInfo(PropertyEstimateBill);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (EstimateCost) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_EstimateCost_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyEstimateCost);
            var propertyInfo  = this.GetPropertyInfo(PropertyEstimateCost);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (EstimateTime) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_EstimateTime_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyEstimateTime);
            var propertyInfo  = this.GetPropertyInfo(PropertyEstimateTime);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (ExpectedBenefit) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_ExpectedBenefit_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExpectedBenefit);
            var propertyInfo  = this.GetPropertyInfo(PropertyExpectedBenefit);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (ExpectedCost) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_ExpectedCost_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExpectedCost);
            var propertyInfo  = this.GetPropertyInfo(PropertyExpectedCost);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (ExpectedDuration) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_ExpectedDuration_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExpectedDuration);
            var propertyInfo  = this.GetPropertyInfo(PropertyExpectedDuration);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (ExpectedDurationType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_ExpectedDurationType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExpectedDurationType);
            var propertyInfo  = this.GetPropertyInfo(PropertyExpectedDurationType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (ExpenseReports) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_ExpenseReports_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExpenseReports);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExpenseReports);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (ExpenseReports) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_ExpenseReports_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExpenseReports);
            var propertyInfo  = this.GetPropertyInfo(PropertyExpenseReports);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (ExtensionData) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_ExtensionData_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExtensionData);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExtensionData);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (ExtensionData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_ExtensionData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Project) => Property (ForecastBillable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_ForecastBillable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyForecastBillable);
            var propertyInfo  = this.GetPropertyInfo(PropertyForecastBillable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (ForecastCost) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_ForecastCost_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyForecastCost);
            var propertyInfo  = this.GetPropertyInfo(PropertyForecastCost);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (Health) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_Health_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyHealth);
            var propertyInfo  = this.GetPropertyInfo(PropertyHealth);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (HierarchyCode) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_HierarchyCode_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Project) => Property (Id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_Id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Project) => Property (IsBillable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_IsBillable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Project) => Property (IsCapitalized) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_IsCapitalized_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Project) => Property (IsCosted) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_IsCosted_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Project) => Property (IsFunded) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_IsFunded_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Project) => Property (IsPlaceholder) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_IsPlaceholder_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Project) => Property (IsRandD) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_IsRandD_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Project) => Property (JustificationSummary) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_JustificationSummary_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyJustificationSummary);
            var propertyInfo  = this.GetPropertyInfo(PropertyJustificationSummary);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (LevelNumber) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_LevelNumber_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLevelNumber);
            var propertyInfo  = this.GetPropertyInfo(PropertyLevelNumber);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (MailUserId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_MailUserId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMailUserId);
            var propertyInfo  = this.GetPropertyInfo(PropertyMailUserId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (Manager) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Manager_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyManager);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyManager);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (Manager) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_Manager_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyManager);
            var propertyInfo  = this.GetPropertyInfo(PropertyManager);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (ManagerAutoApproved) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_ManagerAutoApproved_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyManagerAutoApproved);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyManagerAutoApproved);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (ManagerAutoApproved) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_ManagerAutoApproved_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyManagerAutoApproved);
            var propertyInfo  = this.GetPropertyInfo(PropertyManagerAutoApproved);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (ManagerId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_ManagerId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyManagerId);
            var propertyInfo  = this.GetPropertyInfo(PropertyManagerId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (MinimumBudgetRequested) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_MinimumBudgetRequested_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMinimumBudgetRequested);
            var propertyInfo  = this.GetPropertyInfo(PropertyMinimumBudgetRequested);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (MSProjectFilePath) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_MSProjectFilePath_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMSProjectFilePath);
            var propertyInfo  = this.GetPropertyInfo(PropertyMSProjectFilePath);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (MustFund) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_MustFund_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMustFund);
            var propertyInfo  = this.GetPropertyInfo(PropertyMustFund);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (MustFundReason) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_MustFundReason_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMustFundReason);
            var propertyInfo  = this.GetPropertyInfo(PropertyMustFundReason);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Project) => Property (OverrideBillable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_OverrideBillable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Project) => Property (OverrideCapitalized) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_OverrideCapitalized_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyOverrideCapitalized);
            var propertyInfo  = this.GetPropertyInfo(PropertyOverrideCapitalized);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (OverrideCosted) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_OverrideCosted_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Project) => Property (OverrideFunded) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_OverrideFunded_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Project) => Property (OverridePlan) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_OverridePlan_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyOverridePlan);
            var propertyInfo  = this.GetPropertyInfo(PropertyOverridePlan);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (OverrideRandD) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_OverrideRandD_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Project) => Property (Parent) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Parent_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyParent);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyParent);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (Parent) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_Parent_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyParent);
            var propertyInfo  = this.GetPropertyInfo(PropertyParent);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (ParentId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_ParentId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Project) => Property (Phealth) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_Phealth_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPhealth);
            var propertyInfo  = this.GetPropertyInfo(PropertyPhealth);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (PlannedEndDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_PlannedEndDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPlannedEndDate);
            var propertyInfo  = this.GetPropertyInfo(PropertyPlannedEndDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (PlannedStartDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_PlannedStartDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPlannedStartDate);
            var propertyInfo  = this.GetPropertyInfo(PropertyPlannedStartDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (Portfolio) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Portfolio_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPortfolio);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyPortfolio);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (Portfolio) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_Portfolio_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPortfolio);
            var propertyInfo  = this.GetPropertyInfo(PropertyPortfolio);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (PortfolioAllocatedBudgets) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_PortfolioAllocatedBudgets_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPortfolioAllocatedBudgets);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyPortfolioAllocatedBudgets);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (PortfolioAllocatedBudgets) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_PortfolioAllocatedBudgets_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPortfolioAllocatedBudgets);
            var propertyInfo  = this.GetPropertyInfo(PropertyPortfolioAllocatedBudgets);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (PortfolioId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_PortfolioId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Project) => Property (PPBBaseLines) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_PPBBaseLines_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPPBBaseLines);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyPPBBaseLines);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (PPBBaseLines) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_PPBBaseLines_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPPBBaseLines);
            var propertyInfo  = this.GetPropertyInfo(PropertyPPBBaseLines);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (PPMExpectedCostBenefits) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_PPMExpectedCostBenefits_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPPMExpectedCostBenefits);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyPPMExpectedCostBenefits);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (PPMExpectedCostBenefits) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_PPMExpectedCostBenefits_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPPMExpectedCostBenefits);
            var propertyInfo  = this.GetPropertyInfo(PropertyPPMExpectedCostBenefits);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (PPMExpectedDurations) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_PPMExpectedDurations_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPPMExpectedDurations);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyPPMExpectedDurations);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (PPMExpectedDurations) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_PPMExpectedDurations_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPPMExpectedDurations);
            var propertyInfo  = this.GetPropertyInfo(PropertyPPMExpectedDurations);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (PPMGoals) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_PPMGoals_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPPMGoals);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyPPMGoals);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (PPMGoals) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_PPMGoals_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPPMGoals);
            var propertyInfo  = this.GetPropertyInfo(PropertyPPMGoals);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (PPMProjectDependencies) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_PPMProjectDependencies_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPPMProjectDependencies);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyPPMProjectDependencies);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (PPMProjectDependencies) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_PPMProjectDependencies_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPPMProjectDependencies);
            var propertyInfo  = this.GetPropertyInfo(PropertyPPMProjectDependencies);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (PPMResourceAllocations) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_PPMResourceAllocations_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPPMResourceAllocations);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyPPMResourceAllocations);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (PPMResourceAllocations) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_PPMResourceAllocations_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPPMResourceAllocations);
            var propertyInfo  = this.GetPropertyInfo(PropertyPPMResourceAllocations);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (PPMSponsors) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_PPMSponsors_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPPMSponsors);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyPPMSponsors);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (PPMSponsors) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_PPMSponsors_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPPMSponsors);
            var propertyInfo  = this.GetPropertyInfo(PropertyPPMSponsors);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (PPMTimeHorizons) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_PPMTimeHorizons_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPPMTimeHorizons);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyPPMTimeHorizons);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (PPMTimeHorizons) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_PPMTimeHorizons_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPPMTimeHorizons);
            var propertyInfo  = this.GetPropertyInfo(PropertyPPMTimeHorizons);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (Priority) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_Priority_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPriority);
            var propertyInfo  = this.GetPropertyInfo(PropertyPriority);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (PROJECTCONTACTID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_PROJECTCONTACTID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPROJECTCONTACTID);
            var propertyInfo  = this.GetPropertyInfo(PropertyPROJECTCONTACTID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (ProjectRevenueRecognitionPreference) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_ProjectRevenueRecognitionPreference_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectRevenueRecognitionPreference);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyProjectRevenueRecognitionPreference);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (ProjectRevenueRecognitionPreference) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_ProjectRevenueRecognitionPreference_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectRevenueRecognitionPreference);
            var propertyInfo  = this.GetPropertyInfo(PropertyProjectRevenueRecognitionPreference);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (ProjectScheduling) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_ProjectScheduling_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectScheduling);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyProjectScheduling);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (ProjectScheduling) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_ProjectScheduling_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectScheduling);
            var propertyInfo  = this.GetPropertyInfo(PropertyProjectScheduling);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (ProjectSchedulingId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_ProjectSchedulingId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectSchedulingId);
            var propertyInfo  = this.GetPropertyInfo(PropertyProjectSchedulingId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (ProjectType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_ProjectType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectType);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyProjectType);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (ProjectType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_ProjectType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectType);
            var propertyInfo  = this.GetPropertyInfo(PropertyProjectType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (ProjectTypeId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_ProjectTypeId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Project) => Property (ProjectVersionId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_ProjectVersionId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectVersionId);
            var propertyInfo  = this.GetPropertyInfo(PropertyProjectVersionId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (ProjectWorkflowMapId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_ProjectWorkflowMapId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Project) => Property (ReleaseAlias) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_ReleaseAlias_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyReleaseAlias);
            var propertyInfo  = this.GetPropertyInfo(PropertyReleaseAlias);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (RevenueAccount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_RevenueAccount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRevenueAccount);
            var propertyInfo  = this.GetPropertyInfo(PropertyRevenueAccount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (RevenueRecognitionAccountId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_RevenueRecognitionAccountId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRevenueRecognitionAccountId);
            var propertyInfo  = this.GetPropertyInfo(PropertyRevenueRecognitionAccountId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (StartDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_StartDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyStartDate);
            var propertyInfo  = this.GetPropertyInfo(PropertyStartDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (State) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_State_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Project) => Property (Status) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_Status_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyStatus);
            var propertyInfo  = this.GetPropertyInfo(PropertyStatus);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (Suspend) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_Suspend_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySuspend);
            var propertyInfo  = this.GetPropertyInfo(PropertySuspend);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (SuspendIfExceeded) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_SuspendIfExceeded_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySuspendIfExceeded);
            var propertyInfo  = this.GetPropertyInfo(PropertySuspendIfExceeded);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Project) => Property (TACCOUNT) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_TACCOUNT_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTACCOUNT);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTACCOUNT);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (TACCOUNT) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_TACCOUNT_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTACCOUNT);
            var propertyInfo  = this.GetPropertyInfo(PropertyTACCOUNT);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (TACCOUNT1) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_TACCOUNT1_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTACCOUNT1);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTACCOUNT1);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (TACCOUNT1) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_TACCOUNT1_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTACCOUNT1);
            var propertyInfo  = this.GetPropertyInfo(PropertyTACCOUNT1);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (TACCOUNT2) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_TACCOUNT2_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTACCOUNT2);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTACCOUNT2);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (TACCOUNT2) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_TACCOUNT2_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTACCOUNT2);
            var propertyInfo  = this.GetPropertyInfo(PropertyTACCOUNT2);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (Task) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Task_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTask);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTask);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (Task) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_Task_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Project) => Property (TerminationCostPeriod) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_TerminationCostPeriod_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTerminationCostPeriod);
            var propertyInfo  = this.GetPropertyInfo(PropertyTerminationCostPeriod);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (TimeEntryNotesOption) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_TimeEntryNotesOption_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimeEntryNotesOption);
            var propertyInfo  = this.GetPropertyInfo(PropertyTimeEntryNotesOption);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (TimeHorizon) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_TimeHorizon_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimeHorizon);
            var propertyInfo  = this.GetPropertyInfo(PropertyTimeHorizon);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (TMILEST) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_TMILEST_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTMILEST);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTMILEST);
            Action currentAction = () => propertyInfo.SetValue(_projectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (TMILEST) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_TMILEST_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Project) => Property (TrackingNo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_TrackingNo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTrackingNo);
            var propertyInfo  = this.GetPropertyInfo(PropertyTrackingNo);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (UnearnedRevenueAccount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_UnearnedRevenueAccount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUnearnedRevenueAccount);
            var propertyInfo  = this.GetPropertyInfo(PropertyUnearnedRevenueAccount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (UniqueId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_UniqueId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Project) => Property (UpdatedOn) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_UpdatedOn_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUpdatedOn);
            var propertyInfo  = this.GetPropertyInfo(PropertyUpdatedOn);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (WIPAccount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_WIPAccount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWIPAccount);
            var propertyInfo  = this.GetPropertyInfo(PropertyWIPAccount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Project) => Property (WIPRule) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Project_Public_Class_WIPRule_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWIPRule);
            var propertyInfo  = this.GetPropertyInfo(PropertyWIPRule);

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
        private void AUT_Project_RaisePropertyChanged_Method_Call_Internally(Type[] types)
        {
            var methodRaisePropertyChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Project_RaisePropertyChanged_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_projectInstanceFixture, parametersOfRaisePropertyChanged);

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
        public void AUT_Project_RaisePropertyChanged_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_projectInstance, MethodRaisePropertyChanged, parametersOfRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes);

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
        public void AUT_Project_RaisePropertyChanged_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Project_RaisePropertyChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);

            // Assert
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Project_RaisePropertyChanged_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_projectInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}