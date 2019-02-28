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
using UplandIntegrations.TenroxProjectService;
using ProjectType = UplandIntegrations.TenroxProjectService;

namespace UplandIntegrations.TenroxProjectService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxProjectService.ProjectType" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxProjectService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    public partial class ProjectTypeTest : AbstractBaseSetupV3Test
    {
        public ProjectTypeTest() : base(typeof(ProjectType))
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

        #region General Initializer : Class (ProjectType) Initializer

        #region Properties

        private const string PropertyExtensionData = "ExtensionData";
        private const string PropertyAccessType = "AccessType";
        private const string PropertyAdoptionRateMax = "AdoptionRateMax";
        private const string PropertyAdoptionRateMin = "AdoptionRateMin";
        private const string PropertyCompletionRateMax = "CompletionRateMax";
        private const string PropertyDescription = "Description";
        private const string PropertyEstimationMethodId = "EstimationMethodId";
        private const string PropertyId = "Id";
        private const string PropertyIssueWorkflowId = "IssueWorkflowId";
        private const string PropertyName = "Name";
        private const string PropertyProjectTypeDescriptions = "ProjectTypeDescriptions";
        private const string PropertyProjects = "Projects";
        private const string PropertyRiskWorkflowId = "RiskWorkflowId";
        private const string PropertyScopeChangeWorkflowId = "ScopeChangeWorkflowId";
        private const string PropertyShowAccounting = "ShowAccounting";
        private const string PropertyShowAdoptionRate = "ShowAdoptionRate";
        private const string PropertyShowAlignment = "ShowAlignment";
        private const string PropertyShowBilling = "ShowBilling";
        private const string PropertyShowBudget = "ShowBudget";
        private const string PropertyShowCalendar = "ShowCalendar";
        private const string PropertyShowCompletionRate = "ShowCompletionRate";
        private const string PropertyShowCost = "ShowCost";
        private const string PropertyShowExpectedBenefit = "ShowExpectedBenefit";
        private const string PropertyShowExpectedCost = "ShowExpectedCost";
        private const string PropertyShowExpectedDuration = "ShowExpectedDuration";
        private const string PropertyShowFinancial = "ShowFinancial";
        private const string PropertyShowGoals = "ShowGoals";
        private const string PropertyShowJustification = "ShowJustification";
        private const string PropertyShowMilestone = "ShowMilestone";
        private const string PropertyShowPlan = "ShowPlan";
        private const string PropertyShowProjectDependency = "ShowProjectDependency";
        private const string PropertyShowProjectPOs = "ShowProjectPOs";
        private const string PropertyShowProjectPlan = "ShowProjectPlan";
        private const string PropertyShowProjectTeam = "ShowProjectTeam";
        private const string PropertyShowResourceAvailability = "ShowResourceAvailability";
        private const string PropertyShowSponsors = "ShowSponsors";
        private const string PropertyShowTask = "ShowTask";
        private const string PropertyShowWorkPlan = "ShowWorkPlan";
        private const string PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey";
        private const string PropertyUniqueId = "UniqueId";

        #endregion

        #region Methods

        private const string MethodRaisePropertyChanged = "RaisePropertyChanged";

        #endregion

        #region Fields

        private const string FieldextensionDataField = "extensionDataField";
        private const string FieldAccessTypeField = "AccessTypeField";
        private const string FieldAdoptionRateMaxField = "AdoptionRateMaxField";
        private const string FieldAdoptionRateMinField = "AdoptionRateMinField";
        private const string FieldCompletionRateMaxField = "CompletionRateMaxField";
        private const string FieldDescriptionField = "DescriptionField";
        private const string FieldEstimationMethodIdField = "EstimationMethodIdField";
        private const string FieldIdField = "IdField";
        private const string FieldIssueWorkflowIdField = "IssueWorkflowIdField";
        private const string FieldNameField = "NameField";
        private const string FieldProjectTypeDescriptionsField = "ProjectTypeDescriptionsField";
        private const string FieldProjectsField = "ProjectsField";
        private const string FieldRiskWorkflowIdField = "RiskWorkflowIdField";
        private const string FieldScopeChangeWorkflowIdField = "ScopeChangeWorkflowIdField";
        private const string FieldShowAccountingField = "ShowAccountingField";
        private const string FieldShowAdoptionRateField = "ShowAdoptionRateField";
        private const string FieldShowAlignmentField = "ShowAlignmentField";
        private const string FieldShowBillingField = "ShowBillingField";
        private const string FieldShowBudgetField = "ShowBudgetField";
        private const string FieldShowCalendarField = "ShowCalendarField";
        private const string FieldShowCompletionRateField = "ShowCompletionRateField";
        private const string FieldShowCostField = "ShowCostField";
        private const string FieldShowExpectedBenefitField = "ShowExpectedBenefitField";
        private const string FieldShowExpectedCostField = "ShowExpectedCostField";
        private const string FieldShowExpectedDurationField = "ShowExpectedDurationField";
        private const string FieldShowFinancialField = "ShowFinancialField";
        private const string FieldShowGoalsField = "ShowGoalsField";
        private const string FieldShowJustificationField = "ShowJustificationField";
        private const string FieldShowMilestoneField = "ShowMilestoneField";
        private const string FieldShowPlanField = "ShowPlanField";
        private const string FieldShowProjectDependencyField = "ShowProjectDependencyField";
        private const string FieldShowProjectPOsField = "ShowProjectPOsField";
        private const string FieldShowProjectPlanField = "ShowProjectPlanField";
        private const string FieldShowProjectTeamField = "ShowProjectTeamField";
        private const string FieldShowResourceAvailabilityField = "ShowResourceAvailabilityField";
        private const string FieldShowSponsorsField = "ShowSponsorsField";
        private const string FieldShowTaskField = "ShowTaskField";
        private const string FieldShowWorkPlanField = "ShowWorkPlanField";
        private const string FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField = "SystemDataObjectsDataClassesIEntityWithKeyEntityKeyField";
        private const string FieldUniqueIdField = "UniqueIdField";

        #endregion

        private Type _projectTypeInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private ProjectType _projectTypeInstance;
        private ProjectType _projectTypeInstanceFixture;

        #region General Initializer : Class (ProjectType) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ProjectType" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _projectTypeInstanceType = typeof(ProjectType);
            _projectTypeInstanceFixture = this.Create<ProjectType>(true);
            _projectTypeInstance = _projectTypeInstanceFixture ?? this.Create<ProjectType>(false);
            CurrentInstance = _projectTypeInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ProjectType)

        #region General Initializer : Class (ProjectType) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ProjectType" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRaisePropertyChanged, 0)]
        public void AUT_ProjectType_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_projectTypeInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ProjectType) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ProjectType" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyExtensionData)]
        [TestCase(PropertyAccessType)]
        [TestCase(PropertyAdoptionRateMax)]
        [TestCase(PropertyAdoptionRateMin)]
        [TestCase(PropertyCompletionRateMax)]
        [TestCase(PropertyDescription)]
        [TestCase(PropertyEstimationMethodId)]
        [TestCase(PropertyId)]
        [TestCase(PropertyIssueWorkflowId)]
        [TestCase(PropertyName)]
        [TestCase(PropertyProjectTypeDescriptions)]
        [TestCase(PropertyProjects)]
        [TestCase(PropertyRiskWorkflowId)]
        [TestCase(PropertyScopeChangeWorkflowId)]
        [TestCase(PropertyShowAccounting)]
        [TestCase(PropertyShowAdoptionRate)]
        [TestCase(PropertyShowAlignment)]
        [TestCase(PropertyShowBilling)]
        [TestCase(PropertyShowBudget)]
        [TestCase(PropertyShowCalendar)]
        [TestCase(PropertyShowCompletionRate)]
        [TestCase(PropertyShowCost)]
        [TestCase(PropertyShowExpectedBenefit)]
        [TestCase(PropertyShowExpectedCost)]
        [TestCase(PropertyShowExpectedDuration)]
        [TestCase(PropertyShowFinancial)]
        [TestCase(PropertyShowGoals)]
        [TestCase(PropertyShowJustification)]
        [TestCase(PropertyShowMilestone)]
        [TestCase(PropertyShowPlan)]
        [TestCase(PropertyShowProjectDependency)]
        [TestCase(PropertyShowProjectPOs)]
        [TestCase(PropertyShowProjectPlan)]
        [TestCase(PropertyShowProjectTeam)]
        [TestCase(PropertyShowResourceAvailability)]
        [TestCase(PropertyShowSponsors)]
        [TestCase(PropertyShowTask)]
        [TestCase(PropertyShowWorkPlan)]
        [TestCase(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCase(PropertyUniqueId)]
        public void AUT_ProjectType_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var propertyInfo = this.GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_projectTypeInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ProjectType) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ProjectType" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldextensionDataField)]
        [TestCase(FieldAccessTypeField)]
        [TestCase(FieldAdoptionRateMaxField)]
        [TestCase(FieldAdoptionRateMinField)]
        [TestCase(FieldCompletionRateMaxField)]
        [TestCase(FieldDescriptionField)]
        [TestCase(FieldEstimationMethodIdField)]
        [TestCase(FieldIdField)]
        [TestCase(FieldIssueWorkflowIdField)]
        [TestCase(FieldNameField)]
        [TestCase(FieldProjectTypeDescriptionsField)]
        [TestCase(FieldProjectsField)]
        [TestCase(FieldRiskWorkflowIdField)]
        [TestCase(FieldScopeChangeWorkflowIdField)]
        [TestCase(FieldShowAccountingField)]
        [TestCase(FieldShowAdoptionRateField)]
        [TestCase(FieldShowAlignmentField)]
        [TestCase(FieldShowBillingField)]
        [TestCase(FieldShowBudgetField)]
        [TestCase(FieldShowCalendarField)]
        [TestCase(FieldShowCompletionRateField)]
        [TestCase(FieldShowCostField)]
        [TestCase(FieldShowExpectedBenefitField)]
        [TestCase(FieldShowExpectedCostField)]
        [TestCase(FieldShowExpectedDurationField)]
        [TestCase(FieldShowFinancialField)]
        [TestCase(FieldShowGoalsField)]
        [TestCase(FieldShowJustificationField)]
        [TestCase(FieldShowMilestoneField)]
        [TestCase(FieldShowPlanField)]
        [TestCase(FieldShowProjectDependencyField)]
        [TestCase(FieldShowProjectPOsField)]
        [TestCase(FieldShowProjectPlanField)]
        [TestCase(FieldShowProjectTeamField)]
        [TestCase(FieldShowResourceAvailabilityField)]
        [TestCase(FieldShowSponsorsField)]
        [TestCase(FieldShowTaskField)]
        [TestCase(FieldShowWorkPlanField)]
        [TestCase(FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField)]
        [TestCase(FieldUniqueIdField)]
        public void AUT_ProjectType_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_projectTypeInstanceFixture, 
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
        ///     Class (<see cref="ProjectType" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ProjectType_Is_Instance_Present_Test()
        {
            // Assert
            _projectTypeInstanceType.ShouldNotBeNull();
            _projectTypeInstance.ShouldNotBeNull();
            _projectTypeInstanceFixture.ShouldNotBeNull();
            _projectTypeInstance.ShouldBeAssignableTo<ProjectType>();
            _projectTypeInstanceFixture.ShouldBeAssignableTo<ProjectType>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ProjectType) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ProjectType_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ProjectType instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _projectTypeInstanceType.ShouldNotBeNull();
            _projectTypeInstance.ShouldNotBeNull();
            _projectTypeInstanceFixture.ShouldNotBeNull();
            _projectTypeInstance.ShouldBeAssignableTo<ProjectType>();
            _projectTypeInstanceFixture.ShouldBeAssignableTo<ProjectType>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ProjectType) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(System.Runtime.Serialization.ExtensionDataObject) , PropertyExtensionData)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyAccessType)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyAdoptionRateMax)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyAdoptionRateMin)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyCompletionRateMax)]
        [TestCaseGeneric(typeof(string) , PropertyDescription)]
        [TestCaseGeneric(typeof(string) , PropertyEstimationMethodId)]
        [TestCaseGeneric(typeof(string) , PropertyId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyIssueWorkflowId)]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxProjectService.ProjectTypeDescription[]) , PropertyProjectTypeDescriptions)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxProjectService.Project[]) , PropertyProjects)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyRiskWorkflowId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyScopeChangeWorkflowId)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyShowAccounting)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyShowAdoptionRate)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyShowAlignment)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyShowBilling)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyShowBudget)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyShowCalendar)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyShowCompletionRate)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyShowCost)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyShowExpectedBenefit)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyShowExpectedCost)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyShowExpectedDuration)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyShowFinancial)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyShowGoals)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyShowJustification)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyShowMilestone)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyShowPlan)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyShowProjectDependency)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyShowProjectPOs)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyShowProjectPlan)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyShowProjectTeam)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyShowResourceAvailability)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyShowSponsors)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyShowTask)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyShowWorkPlan)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxProjectService.EntityKey) , PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCaseGeneric(typeof(int) , PropertyUniqueId)]
        public void AUT_ProjectType_Property_Type_Verify_Explore_By_Name_Test<T>(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);

            // Assert
            ShouldlyExtension.PropertyTypeVerify<ProjectType, T>(_projectTypeInstance, name, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (AccessType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_AccessType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ProjectType) => Property (AdoptionRateMax) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_AdoptionRateMax_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAdoptionRateMax);
            var propertyInfo  = this.GetPropertyInfo(PropertyAdoptionRateMax);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (AdoptionRateMin) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_AdoptionRateMin_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAdoptionRateMin);
            var propertyInfo  = this.GetPropertyInfo(PropertyAdoptionRateMin);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (CompletionRateMax) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_CompletionRateMax_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCompletionRateMax);
            var propertyInfo  = this.GetPropertyInfo(PropertyCompletionRateMax);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (Description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_Description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ProjectType) => Property (EstimationMethodId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_EstimationMethodId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyEstimationMethodId);
            var propertyInfo  = this.GetPropertyInfo(PropertyEstimationMethodId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ExtensionData) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_ExtensionData_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExtensionData);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExtensionData);
            Action currentAction = () => propertyInfo.SetValue(_projectTypeInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ExtensionData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_ExtensionData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ProjectType) => Property (Id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_Id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ProjectType) => Property (IssueWorkflowId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_IssueWorkflowId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIssueWorkflowId);
            var propertyInfo  = this.GetPropertyInfo(PropertyIssueWorkflowId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ProjectType) => Property (Projects) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Projects_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjects);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyProjects);
            Action currentAction = () => propertyInfo.SetValue(_projectTypeInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (Projects) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_Projects_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjects);
            var propertyInfo  = this.GetPropertyInfo(PropertyProjects);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ProjectTypeDescriptions) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_ProjectTypeDescriptions_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectTypeDescriptions);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyProjectTypeDescriptions);
            Action currentAction = () => propertyInfo.SetValue(_projectTypeInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ProjectTypeDescriptions) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_ProjectTypeDescriptions_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectTypeDescriptions);
            var propertyInfo  = this.GetPropertyInfo(PropertyProjectTypeDescriptions);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (RiskWorkflowId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_RiskWorkflowId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRiskWorkflowId);
            var propertyInfo  = this.GetPropertyInfo(PropertyRiskWorkflowId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ScopeChangeWorkflowId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_ScopeChangeWorkflowId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyScopeChangeWorkflowId);
            var propertyInfo  = this.GetPropertyInfo(PropertyScopeChangeWorkflowId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ShowAccounting) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_ShowAccounting_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyShowAccounting);
            var propertyInfo  = this.GetPropertyInfo(PropertyShowAccounting);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ShowAdoptionRate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_ShowAdoptionRate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyShowAdoptionRate);
            var propertyInfo  = this.GetPropertyInfo(PropertyShowAdoptionRate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ShowAlignment) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_ShowAlignment_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyShowAlignment);
            var propertyInfo  = this.GetPropertyInfo(PropertyShowAlignment);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ShowBilling) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_ShowBilling_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyShowBilling);
            var propertyInfo  = this.GetPropertyInfo(PropertyShowBilling);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ShowBudget) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_ShowBudget_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyShowBudget);
            var propertyInfo  = this.GetPropertyInfo(PropertyShowBudget);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ShowCalendar) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_ShowCalendar_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyShowCalendar);
            var propertyInfo  = this.GetPropertyInfo(PropertyShowCalendar);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ShowCompletionRate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_ShowCompletionRate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyShowCompletionRate);
            var propertyInfo  = this.GetPropertyInfo(PropertyShowCompletionRate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ShowCost) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_ShowCost_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyShowCost);
            var propertyInfo  = this.GetPropertyInfo(PropertyShowCost);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ShowExpectedBenefit) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_ShowExpectedBenefit_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyShowExpectedBenefit);
            var propertyInfo  = this.GetPropertyInfo(PropertyShowExpectedBenefit);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ShowExpectedCost) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_ShowExpectedCost_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyShowExpectedCost);
            var propertyInfo  = this.GetPropertyInfo(PropertyShowExpectedCost);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ShowExpectedDuration) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_ShowExpectedDuration_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyShowExpectedDuration);
            var propertyInfo  = this.GetPropertyInfo(PropertyShowExpectedDuration);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ShowFinancial) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_ShowFinancial_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyShowFinancial);
            var propertyInfo  = this.GetPropertyInfo(PropertyShowFinancial);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ShowGoals) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_ShowGoals_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyShowGoals);
            var propertyInfo  = this.GetPropertyInfo(PropertyShowGoals);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ShowJustification) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_ShowJustification_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyShowJustification);
            var propertyInfo  = this.GetPropertyInfo(PropertyShowJustification);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ShowMilestone) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_ShowMilestone_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyShowMilestone);
            var propertyInfo  = this.GetPropertyInfo(PropertyShowMilestone);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ShowPlan) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_ShowPlan_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyShowPlan);
            var propertyInfo  = this.GetPropertyInfo(PropertyShowPlan);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ShowProjectDependency) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_ShowProjectDependency_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyShowProjectDependency);
            var propertyInfo  = this.GetPropertyInfo(PropertyShowProjectDependency);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ShowProjectPlan) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_ShowProjectPlan_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyShowProjectPlan);
            var propertyInfo  = this.GetPropertyInfo(PropertyShowProjectPlan);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ShowProjectPOs) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_ShowProjectPOs_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyShowProjectPOs);
            var propertyInfo  = this.GetPropertyInfo(PropertyShowProjectPOs);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ShowProjectTeam) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_ShowProjectTeam_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyShowProjectTeam);
            var propertyInfo  = this.GetPropertyInfo(PropertyShowProjectTeam);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ShowResourceAvailability) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_ShowResourceAvailability_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyShowResourceAvailability);
            var propertyInfo  = this.GetPropertyInfo(PropertyShowResourceAvailability);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ShowSponsors) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_ShowSponsors_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyShowSponsors);
            var propertyInfo  = this.GetPropertyInfo(PropertyShowSponsors);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ShowTask) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_ShowTask_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyShowTask);
            var propertyInfo  = this.GetPropertyInfo(PropertyShowTask);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (ShowWorkPlan) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_ShowWorkPlan_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyShowWorkPlan);
            var propertyInfo  = this.GetPropertyInfo(PropertyShowWorkPlan);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            Action currentAction = () => propertyInfo.SetValue(_projectTypeInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ProjectType) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ProjectType) => Property (UniqueId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectType_Public_Class_UniqueId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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
        private void AUT_ProjectType_RaisePropertyChanged_Method_Call_Internally(Type[] types)
        {
            var methodRaisePropertyChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectTypeInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ProjectType_RaisePropertyChanged_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_projectTypeInstanceFixture, parametersOfRaisePropertyChanged);

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
        public void AUT_ProjectType_RaisePropertyChanged_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_projectTypeInstance, MethodRaisePropertyChanged, parametersOfRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes);

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
        public void AUT_ProjectType_RaisePropertyChanged_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ProjectType_RaisePropertyChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectTypeInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);

            // Assert
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ProjectType_RaisePropertyChanged_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_projectTypeInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}