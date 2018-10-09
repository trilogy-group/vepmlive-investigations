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
using Task = UplandIntegrations.TenroxTaskService;

namespace UplandIntegrations.TenroxTaskService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxTaskService.Task" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxTaskService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    public partial class TaskTest : AbstractBaseSetupV3Test
    {
        public TaskTest() : base(typeof(Task))
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

        #region General Initializer : Class (Task) Initializer

        #region Properties

        private const string PropertyExtensionData = "ExtensionData";
        private const string PropertyAccessType = "AccessType";
        private const string PropertyAssignment = "Assignment";
        private const string PropertyBaseWorkType = "BaseWorkType";
        private const string PropertyBudgetBill = "BudgetBill";
        private const string PropertyBudgetCost = "BudgetCost";
        private const string PropertyBudgetThreshhold = "BudgetThreshhold";
        private const string PropertyBudgetedTime = "BudgetedTime";
        private const string PropertyCapitalized = "Capitalized";
        private const string PropertyDescription = "Description";
        private const string PropertyEmail = "Email";
        private const string PropertyEndDate = "EndDate";
        private const string PropertyEstimateBill = "EstimateBill";
        private const string PropertyEstimateCost = "EstimateCost";
        private const string PropertyEstimateTime = "EstimateTime";
        private const string PropertyExpenseEntries = "ExpenseEntries";
        private const string PropertyId = "Id";
        private const string PropertyIsBillable = "IsBillable";
        private const string PropertyIsCosted = "IsCosted";
        private const string PropertyIsETCEnabled = "IsETCEnabled";
        private const string PropertyIsFunded = "IsFunded";
        private const string PropertyIsMilestoneBilling = "IsMilestoneBilling";
        private const string PropertyIsOverhead = "IsOverhead";
        private const string PropertyIsProjectLevelScheduling = "IsProjectLevelScheduling";
        private const string PropertyIsRandD = "IsRandD";
        private const string PropertyIsSuspended = "IsSuspended";
        private const string PropertyMailUserId = "MailUserId";
        private const string PropertyMilestoneTask = "MilestoneTask";
        private const string PropertyName = "Name";
        private const string PropertyParentAdjacenttask = "ParentAdjacenttask";
        private const string PropertyPortfolioId = "PortfolioId";
        private const string PropertyPriority = "Priority";
        private const string PropertyProject = "Project";
        private const string PropertyProjectId = "ProjectId";
        private const string PropertyProjectScheduling = "ProjectScheduling";
        private const string PropertyProjectSchedulingId = "ProjectSchedulingId";
        private const string PropertyStartDate = "StartDate";
        private const string PropertyState = "State";
        private const string PropertySuspendIfExceeded = "SuspendIfExceeded";
        private const string PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey";
        private const string PropertyTMILEST = "TMILEST";
        private const string PropertyTaskRate = "TaskRate";
        private const string PropertyTaskType = "TaskType";
        private const string PropertyTimeEntries = "TimeEntries";
        private const string PropertyTimeEntryNotesOption = "TimeEntryNotesOption";
        private const string PropertyUniqueId = "UniqueId";
        private const string PropertyWorktypeId = "WorktypeId";

        #endregion

        #region Methods

        private const string MethodRaisePropertyChanged = "RaisePropertyChanged";

        #endregion

        #region Fields

        private const string FieldextensionDataField = "extensionDataField";
        private const string FieldAccessTypeField = "AccessTypeField";
        private const string FieldAssignmentField = "AssignmentField";
        private const string FieldBaseWorkTypeField = "BaseWorkTypeField";
        private const string FieldBudgetBillField = "BudgetBillField";
        private const string FieldBudgetCostField = "BudgetCostField";
        private const string FieldBudgetThreshholdField = "BudgetThreshholdField";
        private const string FieldBudgetedTimeField = "BudgetedTimeField";
        private const string FieldCapitalizedField = "CapitalizedField";
        private const string FieldDescriptionField = "DescriptionField";
        private const string FieldEmailField = "EmailField";
        private const string FieldEndDateField = "EndDateField";
        private const string FieldEstimateBillField = "EstimateBillField";
        private const string FieldEstimateCostField = "EstimateCostField";
        private const string FieldEstimateTimeField = "EstimateTimeField";
        private const string FieldExpenseEntriesField = "ExpenseEntriesField";
        private const string FieldIdField = "IdField";
        private const string FieldIsBillableField = "IsBillableField";
        private const string FieldIsCostedField = "IsCostedField";
        private const string FieldIsETCEnabledField = "IsETCEnabledField";
        private const string FieldIsFundedField = "IsFundedField";
        private const string FieldIsMilestoneBillingField = "IsMilestoneBillingField";
        private const string FieldIsOverheadField = "IsOverheadField";
        private const string FieldIsProjectLevelSchedulingField = "IsProjectLevelSchedulingField";
        private const string FieldIsRandDField = "IsRandDField";
        private const string FieldIsSuspendedField = "IsSuspendedField";
        private const string FieldMailUserIdField = "MailUserIdField";
        private const string FieldMilestoneTaskField = "MilestoneTaskField";
        private const string FieldNameField = "NameField";
        private const string FieldParentAdjacenttaskField = "ParentAdjacenttaskField";
        private const string FieldPortfolioIdField = "PortfolioIdField";
        private const string FieldPriorityField = "PriorityField";
        private const string FieldProjectField = "ProjectField";
        private const string FieldProjectIdField = "ProjectIdField";
        private const string FieldProjectSchedulingField = "ProjectSchedulingField";
        private const string FieldProjectSchedulingIdField = "ProjectSchedulingIdField";
        private const string FieldStartDateField = "StartDateField";
        private const string FieldStateField = "StateField";
        private const string FieldSuspendIfExceededField = "SuspendIfExceededField";
        private const string FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField = "SystemDataObjectsDataClassesIEntityWithKeyEntityKeyField";
        private const string FieldTMILESTField = "TMILESTField";
        private const string FieldTaskRateField = "TaskRateField";
        private const string FieldTaskTypeField = "TaskTypeField";
        private const string FieldTimeEntriesField = "TimeEntriesField";
        private const string FieldTimeEntryNotesOptionField = "TimeEntryNotesOptionField";
        private const string FieldUniqueIdField = "UniqueIdField";
        private const string FieldWorktypeIdField = "WorktypeIdField";

        #endregion

        private Type _taskInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private Task _taskInstance;
        private Task _taskInstanceFixture;

        #region General Initializer : Class (Task) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Task" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _taskInstanceType = typeof(Task);
            _taskInstanceFixture = this.Create<Task>(true);
            _taskInstance = _taskInstanceFixture ?? this.Create<Task>(false);
            CurrentInstance = _taskInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Task)

        #region General Initializer : Class (Task) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Task" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRaisePropertyChanged, 0)]
        public void AUT_Task_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_taskInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Task) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Task" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyExtensionData)]
        [TestCase(PropertyAccessType)]
        [TestCase(PropertyAssignment)]
        [TestCase(PropertyBaseWorkType)]
        [TestCase(PropertyBudgetBill)]
        [TestCase(PropertyBudgetCost)]
        [TestCase(PropertyBudgetThreshhold)]
        [TestCase(PropertyBudgetedTime)]
        [TestCase(PropertyCapitalized)]
        [TestCase(PropertyDescription)]
        [TestCase(PropertyEmail)]
        [TestCase(PropertyEndDate)]
        [TestCase(PropertyEstimateBill)]
        [TestCase(PropertyEstimateCost)]
        [TestCase(PropertyEstimateTime)]
        [TestCase(PropertyExpenseEntries)]
        [TestCase(PropertyId)]
        [TestCase(PropertyIsBillable)]
        [TestCase(PropertyIsCosted)]
        [TestCase(PropertyIsETCEnabled)]
        [TestCase(PropertyIsFunded)]
        [TestCase(PropertyIsMilestoneBilling)]
        [TestCase(PropertyIsOverhead)]
        [TestCase(PropertyIsProjectLevelScheduling)]
        [TestCase(PropertyIsRandD)]
        [TestCase(PropertyIsSuspended)]
        [TestCase(PropertyMailUserId)]
        [TestCase(PropertyMilestoneTask)]
        [TestCase(PropertyName)]
        [TestCase(PropertyParentAdjacenttask)]
        [TestCase(PropertyPortfolioId)]
        [TestCase(PropertyPriority)]
        [TestCase(PropertyProject)]
        [TestCase(PropertyProjectId)]
        [TestCase(PropertyProjectScheduling)]
        [TestCase(PropertyProjectSchedulingId)]
        [TestCase(PropertyStartDate)]
        [TestCase(PropertyState)]
        [TestCase(PropertySuspendIfExceeded)]
        [TestCase(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCase(PropertyTMILEST)]
        [TestCase(PropertyTaskRate)]
        [TestCase(PropertyTaskType)]
        [TestCase(PropertyTimeEntries)]
        [TestCase(PropertyTimeEntryNotesOption)]
        [TestCase(PropertyUniqueId)]
        [TestCase(PropertyWorktypeId)]
        public void AUT_Task_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var propertyInfo = this.GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_taskInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Task) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Task" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldextensionDataField)]
        [TestCase(FieldAccessTypeField)]
        [TestCase(FieldAssignmentField)]
        [TestCase(FieldBaseWorkTypeField)]
        [TestCase(FieldBudgetBillField)]
        [TestCase(FieldBudgetCostField)]
        [TestCase(FieldBudgetThreshholdField)]
        [TestCase(FieldBudgetedTimeField)]
        [TestCase(FieldCapitalizedField)]
        [TestCase(FieldDescriptionField)]
        [TestCase(FieldEmailField)]
        [TestCase(FieldEndDateField)]
        [TestCase(FieldEstimateBillField)]
        [TestCase(FieldEstimateCostField)]
        [TestCase(FieldEstimateTimeField)]
        [TestCase(FieldExpenseEntriesField)]
        [TestCase(FieldIdField)]
        [TestCase(FieldIsBillableField)]
        [TestCase(FieldIsCostedField)]
        [TestCase(FieldIsETCEnabledField)]
        [TestCase(FieldIsFundedField)]
        [TestCase(FieldIsMilestoneBillingField)]
        [TestCase(FieldIsOverheadField)]
        [TestCase(FieldIsProjectLevelSchedulingField)]
        [TestCase(FieldIsRandDField)]
        [TestCase(FieldIsSuspendedField)]
        [TestCase(FieldMailUserIdField)]
        [TestCase(FieldMilestoneTaskField)]
        [TestCase(FieldNameField)]
        [TestCase(FieldParentAdjacenttaskField)]
        [TestCase(FieldPortfolioIdField)]
        [TestCase(FieldPriorityField)]
        [TestCase(FieldProjectField)]
        [TestCase(FieldProjectIdField)]
        [TestCase(FieldProjectSchedulingField)]
        [TestCase(FieldProjectSchedulingIdField)]
        [TestCase(FieldStartDateField)]
        [TestCase(FieldStateField)]
        [TestCase(FieldSuspendIfExceededField)]
        [TestCase(FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField)]
        [TestCase(FieldTMILESTField)]
        [TestCase(FieldTaskRateField)]
        [TestCase(FieldTaskTypeField)]
        [TestCase(FieldTimeEntriesField)]
        [TestCase(FieldTimeEntryNotesOptionField)]
        [TestCase(FieldUniqueIdField)]
        [TestCase(FieldWorktypeIdField)]
        public void AUT_Task_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_taskInstanceFixture, 
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
        ///     Class (<see cref="Task" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Task_Is_Instance_Present_Test()
        {
            // Assert
            _taskInstanceType.ShouldNotBeNull();
            _taskInstance.ShouldNotBeNull();
            _taskInstanceFixture.ShouldNotBeNull();
            _taskInstance.ShouldBeAssignableTo<Task>();
            _taskInstanceFixture.ShouldBeAssignableTo<Task>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Task) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Task_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Task instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _taskInstanceType.ShouldNotBeNull();
            _taskInstance.ShouldNotBeNull();
            _taskInstanceFixture.ShouldNotBeNull();
            _taskInstance.ShouldBeAssignableTo<Task>();
            _taskInstanceFixture.ShouldBeAssignableTo<Task>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Task) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(System.Runtime.Serialization.ExtensionDataObject) , PropertyExtensionData)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyAccessType)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxTaskService.Assignment[]) , PropertyAssignment)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxTaskService.BaseWorkType) , PropertyBaseWorkType)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyBudgetBill)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyBudgetCost)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyBudgetThreshhold)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyBudgetedTime)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyCapitalized)]
        [TestCaseGeneric(typeof(string) , PropertyDescription)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyEmail)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyEndDate)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyEstimateBill)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyEstimateCost)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyEstimateTime)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxTaskService.ExpenseEntry[]) , PropertyExpenseEntries)]
        [TestCaseGeneric(typeof(string) , PropertyId)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsBillable)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsCosted)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsETCEnabled)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsFunded)]
        [TestCaseGeneric(typeof(byte) , PropertyIsMilestoneBilling)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsOverhead)]
        [TestCaseGeneric(typeof(short) , PropertyIsProjectLevelScheduling)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsRandD)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsSuspended)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyMailUserId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxTaskService.MilestoneTask[]) , PropertyMilestoneTask)]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        [TestCaseGeneric(typeof(int) , PropertyParentAdjacenttask)]
        [TestCaseGeneric(typeof(int) , PropertyPortfolioId)]
        [TestCaseGeneric(typeof(string) , PropertyPriority)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxTaskService.Project) , PropertyProject)]
        [TestCaseGeneric(typeof(int) , PropertyProjectId)]
        [TestCaseGeneric(typeof(short) , PropertyProjectScheduling)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyProjectSchedulingId)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyStartDate)]
        [TestCaseGeneric(typeof(string) , PropertyState)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertySuspendIfExceeded)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxTaskService.EntityKey) , PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxTaskService.Milestone[]) , PropertyTMILEST)]
        [TestCaseGeneric(typeof(string) , PropertyTaskRate)]
        [TestCaseGeneric(typeof(string) , PropertyTaskType)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxTaskService.TimeEntry[]) , PropertyTimeEntries)]
        [TestCaseGeneric(typeof(string) , PropertyTimeEntryNotesOption)]
        [TestCaseGeneric(typeof(int) , PropertyUniqueId)]
        [TestCaseGeneric(typeof(int) , PropertyWorktypeId)]
        public void AUT_Task_Property_Type_Verify_Explore_By_Name_Test<T>(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);

            // Assert
            ShouldlyExtension.PropertyTypeVerify<Task, T>(_taskInstance, name, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Task) => Property (AccessType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_AccessType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (Assignment) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Assignment_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAssignment);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyAssignment);
            Action currentAction = () => propertyInfo.SetValue(_taskInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Task) => Property (Assignment) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_Assignment_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAssignment);
            var propertyInfo  = this.GetPropertyInfo(PropertyAssignment);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Task) => Property (BaseWorkType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_BaseWorkType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBaseWorkType);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyBaseWorkType);
            Action currentAction = () => propertyInfo.SetValue(_taskInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Task) => Property (BaseWorkType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_BaseWorkType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBaseWorkType);
            var propertyInfo  = this.GetPropertyInfo(PropertyBaseWorkType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Task) => Property (BudgetBill) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_BudgetBill_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (BudgetCost) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_BudgetCost_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (BudgetedTime) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_BudgetedTime_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (BudgetThreshhold) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_BudgetThreshhold_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (Capitalized) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_Capitalized_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCapitalized);
            var propertyInfo  = this.GetPropertyInfo(PropertyCapitalized);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Task) => Property (Description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_Description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (Email) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_Email_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (EndDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_EndDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (EstimateBill) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_EstimateBill_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (EstimateCost) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_EstimateCost_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (EstimateTime) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_EstimateTime_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (ExpenseEntries) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_ExpenseEntries_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExpenseEntries);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExpenseEntries);
            Action currentAction = () => propertyInfo.SetValue(_taskInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Task) => Property (ExpenseEntries) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_ExpenseEntries_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExpenseEntries);
            var propertyInfo  = this.GetPropertyInfo(PropertyExpenseEntries);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Task) => Property (ExtensionData) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_ExtensionData_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExtensionData);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExtensionData);
            Action currentAction = () => propertyInfo.SetValue(_taskInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Task) => Property (ExtensionData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_ExtensionData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (Id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_Id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (IsBillable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_IsBillable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (IsCosted) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_IsCosted_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (IsETCEnabled) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_IsETCEnabled_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsETCEnabled);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsETCEnabled);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Task) => Property (IsFunded) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_IsFunded_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (IsMilestoneBilling) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_IsMilestoneBilling_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsMilestoneBilling);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyIsMilestoneBilling);
            Action currentAction = () => propertyInfo.SetValue(_taskInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Task) => Property (IsMilestoneBilling) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_IsMilestoneBilling_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsMilestoneBilling);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsMilestoneBilling);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Task) => Property (IsOverhead) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_IsOverhead_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsOverhead);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsOverhead);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Task) => Property (IsProjectLevelScheduling) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_IsProjectLevelScheduling_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsProjectLevelScheduling);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyIsProjectLevelScheduling);
            Action currentAction = () => propertyInfo.SetValue(_taskInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Task) => Property (IsProjectLevelScheduling) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_IsProjectLevelScheduling_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsProjectLevelScheduling);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsProjectLevelScheduling);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Task) => Property (IsRandD) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_IsRandD_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (IsSuspended) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_IsSuspended_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsSuspended);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsSuspended);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Task) => Property (MailUserId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_MailUserId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (MilestoneTask) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_MilestoneTask_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMilestoneTask);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyMilestoneTask);
            Action currentAction = () => propertyInfo.SetValue(_taskInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Task) => Property (MilestoneTask) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_MilestoneTask_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMilestoneTask);
            var propertyInfo  = this.GetPropertyInfo(PropertyMilestoneTask);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Task) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (ParentAdjacenttask) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_ParentAdjacenttask_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyParentAdjacenttask);
            var propertyInfo  = this.GetPropertyInfo(PropertyParentAdjacenttask);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Task) => Property (PortfolioId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_PortfolioId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (Priority) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_Priority_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (Project) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Project_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProject);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyProject);
            Action currentAction = () => propertyInfo.SetValue(_taskInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Task) => Property (Project) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_Project_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProject);
            var propertyInfo  = this.GetPropertyInfo(PropertyProject);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Task) => Property (ProjectId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_ProjectId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (ProjectScheduling) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_ProjectScheduling_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectScheduling);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyProjectScheduling);
            Action currentAction = () => propertyInfo.SetValue(_taskInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Task) => Property (ProjectScheduling) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_ProjectScheduling_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (ProjectSchedulingId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_ProjectSchedulingId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (StartDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_StartDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (State) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_State_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (SuspendIfExceeded) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_SuspendIfExceeded_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            Action currentAction = () => propertyInfo.SetValue(_taskInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Task) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (TaskRate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_TaskRate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTaskRate);
            var propertyInfo  = this.GetPropertyInfo(PropertyTaskRate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Task) => Property (TaskType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_TaskType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTaskType);
            var propertyInfo  = this.GetPropertyInfo(PropertyTaskType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Task) => Property (TimeEntries) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_TimeEntries_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimeEntries);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTimeEntries);
            Action currentAction = () => propertyInfo.SetValue(_taskInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Task) => Property (TimeEntries) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_TimeEntries_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (TimeEntryNotesOption) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_TimeEntryNotesOption_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (TMILEST) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_TMILEST_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTMILEST);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTMILEST);
            Action currentAction = () => propertyInfo.SetValue(_taskInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Task) => Property (TMILEST) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_TMILEST_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (UniqueId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_UniqueId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Task) => Property (WorktypeId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Task_Public_Class_WorktypeId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWorktypeId);
            var propertyInfo  = this.GetPropertyInfo(PropertyWorktypeId);

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
        private void AUT_Task_RaisePropertyChanged_Method_Call_Internally(Type[] types)
        {
            var methodRaisePropertyChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_taskInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Task_RaisePropertyChanged_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_taskInstanceFixture, parametersOfRaisePropertyChanged);

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
        public void AUT_Task_RaisePropertyChanged_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_taskInstance, MethodRaisePropertyChanged, parametersOfRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes);

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
        public void AUT_Task_RaisePropertyChanged_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Task_RaisePropertyChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_taskInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);

            // Assert
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Task_RaisePropertyChanged_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_taskInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}