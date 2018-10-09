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
using WorkflowEntry = UplandIntegrations.TenroxUserService;

namespace UplandIntegrations.TenroxUserService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxUserService.WorkflowEntry" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxUserService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class WorkflowEntryTest : AbstractBaseSetupV3Test
    {
        public WorkflowEntryTest() : base(typeof(WorkflowEntry))
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

        #region General Initializer : Class (WorkflowEntry) Initializer

        #region Properties

        private const string PropertyExtensionData = "ExtensionData";
        private const string PropertyAdditionalInfo = "AdditionalInfo";
        private const string PropertyAppTimeStamp = "AppTimeStamp";
        private const string PropertyClientId = "ClientId";
        private const string PropertyCreatorId = "CreatorId";
        private const string PropertyCreatorType = "CreatorType";
        private const string PropertyDeadline = "Deadline";
        private const string PropertyFullDesc = "FullDesc";
        private const string PropertyLastStatusId = "LastStatusId";
        private const string PropertyOrginatorId = "OrginatorId";
        private const string PropertyOriginiatorType = "OriginiatorType";
        private const string PropertyPPMRiskAssociation = "PPMRiskAssociation";
        private const string PropertyPriority = "Priority";
        private const string PropertyProjectComponentId = "ProjectComponentId";
        private const string PropertyProjectId = "ProjectId";
        private const string PropertyProjectVersionId = "ProjectVersionId";
        private const string PropertyStateChangeDate = "StateChangeDate";
        private const string PropertySummaryDesc = "SummaryDesc";
        private const string PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey";
        private const string PropertyTaskId = "TaskId";
        private const string PropertyTimeEntry = "TimeEntry";
        private const string PropertyUniqueId = "UniqueId";
        private const string PropertyUpdateTimeStamp = "UpdateTimeStamp";
        private const string PropertyWayToProduce = "WayToProduce";
        private const string PropertyWorkFlowWorkType = "WorkFlowWorkType";
        private const string PropertyWorkaround = "Workaround";
        private const string PropertyWorkflowEntryNumber = "WorkflowEntryNumber";
        private const string PropertyWorkflowId = "WorkflowId";
        private const string PropertymarkedForDelete = "markedForDelete";

        #endregion

        #region Methods

        private const string MethodRaisePropertyChanged = "RaisePropertyChanged";

        #endregion

        #region Fields

        private const string FieldextensionDataField = "extensionDataField";
        private const string FieldAdditionalInfoField = "AdditionalInfoField";
        private const string FieldAppTimeStampField = "AppTimeStampField";
        private const string FieldClientIdField = "ClientIdField";
        private const string FieldCreatorIdField = "CreatorIdField";
        private const string FieldCreatorTypeField = "CreatorTypeField";
        private const string FieldDeadlineField = "DeadlineField";
        private const string FieldFullDescField = "FullDescField";
        private const string FieldLastStatusIdField = "LastStatusIdField";
        private const string FieldOrginatorIdField = "OrginatorIdField";
        private const string FieldOriginiatorTypeField = "OriginiatorTypeField";
        private const string FieldPPMRiskAssociationField = "PPMRiskAssociationField";
        private const string FieldPriorityField = "PriorityField";
        private const string FieldProjectComponentIdField = "ProjectComponentIdField";
        private const string FieldProjectIdField = "ProjectIdField";
        private const string FieldProjectVersionIdField = "ProjectVersionIdField";
        private const string FieldStateChangeDateField = "StateChangeDateField";
        private const string FieldSummaryDescField = "SummaryDescField";
        private const string FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField = "SystemDataObjectsDataClassesIEntityWithKeyEntityKeyField";
        private const string FieldTaskIdField = "TaskIdField";
        private const string FieldTimeEntryField = "TimeEntryField";
        private const string FieldUniqueIdField = "UniqueIdField";
        private const string FieldUpdateTimeStampField = "UpdateTimeStampField";
        private const string FieldWayToProduceField = "WayToProduceField";
        private const string FieldWorkFlowWorkTypeField = "WorkFlowWorkTypeField";
        private const string FieldWorkaroundField = "WorkaroundField";
        private const string FieldWorkflowEntryNumberField = "WorkflowEntryNumberField";
        private const string FieldWorkflowIdField = "WorkflowIdField";
        private const string FieldmarkedForDeleteField = "markedForDeleteField";

        #endregion

        private Type _workflowEntryInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private WorkflowEntry _workflowEntryInstance;
        private WorkflowEntry _workflowEntryInstanceFixture;

        #region General Initializer : Class (WorkflowEntry) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkflowEntry" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workflowEntryInstanceType = typeof(WorkflowEntry);
            _workflowEntryInstanceFixture = this.Create<WorkflowEntry>(true);
            _workflowEntryInstance = _workflowEntryInstanceFixture ?? this.Create<WorkflowEntry>(false);
            CurrentInstance = _workflowEntryInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkflowEntry)

        #region General Initializer : Class (WorkflowEntry) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="WorkflowEntry" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRaisePropertyChanged, 0)]
        public void AUT_WorkflowEntry_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_workflowEntryInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WorkflowEntry) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkflowEntry" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyExtensionData)]
        [TestCase(PropertyAdditionalInfo)]
        [TestCase(PropertyAppTimeStamp)]
        [TestCase(PropertyClientId)]
        [TestCase(PropertyCreatorId)]
        [TestCase(PropertyCreatorType)]
        [TestCase(PropertyDeadline)]
        [TestCase(PropertyFullDesc)]
        [TestCase(PropertyLastStatusId)]
        [TestCase(PropertyOrginatorId)]
        [TestCase(PropertyOriginiatorType)]
        [TestCase(PropertyPPMRiskAssociation)]
        [TestCase(PropertyPriority)]
        [TestCase(PropertyProjectComponentId)]
        [TestCase(PropertyProjectId)]
        [TestCase(PropertyProjectVersionId)]
        [TestCase(PropertyStateChangeDate)]
        [TestCase(PropertySummaryDesc)]
        [TestCase(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCase(PropertyTaskId)]
        [TestCase(PropertyTimeEntry)]
        [TestCase(PropertyUniqueId)]
        [TestCase(PropertyUpdateTimeStamp)]
        [TestCase(PropertyWayToProduce)]
        [TestCase(PropertyWorkFlowWorkType)]
        [TestCase(PropertyWorkaround)]
        [TestCase(PropertyWorkflowEntryNumber)]
        [TestCase(PropertyWorkflowId)]
        [TestCase(PropertymarkedForDelete)]
        public void AUT_WorkflowEntry_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var propertyInfo = this.GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_workflowEntryInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WorkflowEntry) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkflowEntry" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldextensionDataField)]
        [TestCase(FieldAdditionalInfoField)]
        [TestCase(FieldAppTimeStampField)]
        [TestCase(FieldClientIdField)]
        [TestCase(FieldCreatorIdField)]
        [TestCase(FieldCreatorTypeField)]
        [TestCase(FieldDeadlineField)]
        [TestCase(FieldFullDescField)]
        [TestCase(FieldLastStatusIdField)]
        [TestCase(FieldOrginatorIdField)]
        [TestCase(FieldOriginiatorTypeField)]
        [TestCase(FieldPPMRiskAssociationField)]
        [TestCase(FieldPriorityField)]
        [TestCase(FieldProjectComponentIdField)]
        [TestCase(FieldProjectIdField)]
        [TestCase(FieldProjectVersionIdField)]
        [TestCase(FieldStateChangeDateField)]
        [TestCase(FieldSummaryDescField)]
        [TestCase(FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField)]
        [TestCase(FieldTaskIdField)]
        [TestCase(FieldTimeEntryField)]
        [TestCase(FieldUniqueIdField)]
        [TestCase(FieldUpdateTimeStampField)]
        [TestCase(FieldWayToProduceField)]
        [TestCase(FieldWorkFlowWorkTypeField)]
        [TestCase(FieldWorkaroundField)]
        [TestCase(FieldWorkflowEntryNumberField)]
        [TestCase(FieldWorkflowIdField)]
        [TestCase(FieldmarkedForDeleteField)]
        public void AUT_WorkflowEntry_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_workflowEntryInstanceFixture, 
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
        ///     Class (<see cref="WorkflowEntry" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_WorkflowEntry_Is_Instance_Present_Test()
        {
            // Assert
            _workflowEntryInstanceType.ShouldNotBeNull();
            _workflowEntryInstance.ShouldNotBeNull();
            _workflowEntryInstanceFixture.ShouldNotBeNull();
            _workflowEntryInstance.ShouldBeAssignableTo<WorkflowEntry>();
            _workflowEntryInstanceFixture.ShouldBeAssignableTo<WorkflowEntry>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WorkflowEntry) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_WorkflowEntry_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WorkflowEntry instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _workflowEntryInstanceType.ShouldNotBeNull();
            _workflowEntryInstance.ShouldNotBeNull();
            _workflowEntryInstanceFixture.ShouldNotBeNull();
            _workflowEntryInstance.ShouldBeAssignableTo<WorkflowEntry>();
            _workflowEntryInstanceFixture.ShouldBeAssignableTo<WorkflowEntry>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (WorkflowEntry) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(System.Runtime.Serialization.ExtensionDataObject) , PropertyExtensionData)]
        [TestCaseGeneric(typeof(string) , PropertyAdditionalInfo)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyAppTimeStamp)]
        [TestCaseGeneric(typeof(int) , PropertyClientId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyCreatorId)]
        [TestCaseGeneric(typeof(string) , PropertyCreatorType)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyDeadline)]
        [TestCaseGeneric(typeof(string) , PropertyFullDesc)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyLastStatusId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyOrginatorId)]
        [TestCaseGeneric(typeof(string) , PropertyOriginiatorType)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.PPMRiskAssociation[]) , PropertyPPMRiskAssociation)]
        [TestCaseGeneric(typeof(string) , PropertyPriority)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyProjectComponentId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyProjectId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyProjectVersionId)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyStateChangeDate)]
        [TestCaseGeneric(typeof(string) , PropertySummaryDesc)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.EntityKey) , PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCaseGeneric(typeof(int) , PropertyTaskId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.TimeEntry[]) , PropertyTimeEntry)]
        [TestCaseGeneric(typeof(int) , PropertyUniqueId)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyUpdateTimeStamp)]
        [TestCaseGeneric(typeof(string) , PropertyWayToProduce)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyWorkFlowWorkType)]
        [TestCaseGeneric(typeof(string) , PropertyWorkaround)]
        [TestCaseGeneric(typeof(string) , PropertyWorkflowEntryNumber)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyWorkflowId)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertymarkedForDelete)]
        public void AUT_WorkflowEntry_Property_Type_Verify_Explore_By_Name_Test<T>(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);

            // Assert
            ShouldlyExtension.PropertyTypeVerify<WorkflowEntry, T>(_workflowEntryInstance, name, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowEntry) => Property (AdditionalInfo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_AdditionalInfo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAdditionalInfo);
            var propertyInfo  = this.GetPropertyInfo(PropertyAdditionalInfo);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowEntry) => Property (AppTimeStamp) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_AppTimeStamp_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowEntry) => Property (ClientId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_ClientId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowEntry) => Property (CreatorId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_CreatorId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowEntry) => Property (CreatorType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_CreatorType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCreatorType);
            var propertyInfo  = this.GetPropertyInfo(PropertyCreatorType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowEntry) => Property (Deadline) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_Deadline_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDeadline);
            var propertyInfo  = this.GetPropertyInfo(PropertyDeadline);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowEntry) => Property (ExtensionData) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_ExtensionData_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExtensionData);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExtensionData);
            Action currentAction = () => propertyInfo.SetValue(_workflowEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowEntry) => Property (ExtensionData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_ExtensionData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowEntry) => Property (FullDesc) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_FullDesc_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyFullDesc);
            var propertyInfo  = this.GetPropertyInfo(PropertyFullDesc);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowEntry) => Property (LastStatusId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_LastStatusId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLastStatusId);
            var propertyInfo  = this.GetPropertyInfo(PropertyLastStatusId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowEntry) => Property (markedForDelete) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_markedForDelete_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertymarkedForDelete);
            var propertyInfo  = this.GetPropertyInfo(PropertymarkedForDelete);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowEntry) => Property (OrginatorId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_OrginatorId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyOrginatorId);
            var propertyInfo  = this.GetPropertyInfo(PropertyOrginatorId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowEntry) => Property (OriginiatorType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_OriginiatorType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyOriginiatorType);
            var propertyInfo  = this.GetPropertyInfo(PropertyOriginiatorType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowEntry) => Property (PPMRiskAssociation) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_PPMRiskAssociation_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPPMRiskAssociation);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyPPMRiskAssociation);
            Action currentAction = () => propertyInfo.SetValue(_workflowEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowEntry) => Property (PPMRiskAssociation) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_PPMRiskAssociation_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPPMRiskAssociation);
            var propertyInfo  = this.GetPropertyInfo(PropertyPPMRiskAssociation);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowEntry) => Property (Priority) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_Priority_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowEntry) => Property (ProjectComponentId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_ProjectComponentId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectComponentId);
            var propertyInfo  = this.GetPropertyInfo(PropertyProjectComponentId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowEntry) => Property (ProjectId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_ProjectId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowEntry) => Property (ProjectVersionId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_ProjectVersionId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowEntry) => Property (StateChangeDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_StateChangeDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowEntry) => Property (SummaryDesc) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_SummaryDesc_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySummaryDesc);
            var propertyInfo  = this.GetPropertyInfo(PropertySummaryDesc);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowEntry) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            Action currentAction = () => propertyInfo.SetValue(_workflowEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowEntry) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowEntry) => Property (TaskId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_TaskId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowEntry) => Property (TimeEntry) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_TimeEntry_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimeEntry);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTimeEntry);
            Action currentAction = () => propertyInfo.SetValue(_workflowEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowEntry) => Property (TimeEntry) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_TimeEntry_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimeEntry);
            var propertyInfo  = this.GetPropertyInfo(PropertyTimeEntry);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowEntry) => Property (UniqueId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_UniqueId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowEntry) => Property (UpdateTimeStamp) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_UpdateTimeStamp_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUpdateTimeStamp);
            var propertyInfo  = this.GetPropertyInfo(PropertyUpdateTimeStamp);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowEntry) => Property (WayToProduce) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_WayToProduce_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWayToProduce);
            var propertyInfo  = this.GetPropertyInfo(PropertyWayToProduce);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowEntry) => Property (Workaround) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_Workaround_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWorkaround);
            var propertyInfo  = this.GetPropertyInfo(PropertyWorkaround);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowEntry) => Property (WorkflowEntryNumber) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_WorkflowEntryNumber_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWorkflowEntryNumber);
            var propertyInfo  = this.GetPropertyInfo(PropertyWorkflowEntryNumber);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowEntry) => Property (WorkflowId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_WorkflowId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowEntry) => Property (WorkFlowWorkType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowEntry_Public_Class_WorkFlowWorkType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWorkFlowWorkType);
            var propertyInfo  = this.GetPropertyInfo(PropertyWorkFlowWorkType);

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
        private void AUT_WorkflowEntry_RaisePropertyChanged_Method_Call_Internally(Type[] types)
        {
            var methodRaisePropertyChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workflowEntryInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkflowEntry_RaisePropertyChanged_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workflowEntryInstanceFixture, parametersOfRaisePropertyChanged);

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
        public void AUT_WorkflowEntry_RaisePropertyChanged_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_workflowEntryInstance, MethodRaisePropertyChanged, parametersOfRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes);

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
        public void AUT_WorkflowEntry_RaisePropertyChanged_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_WorkflowEntry_RaisePropertyChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workflowEntryInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);

            // Assert
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkflowEntry_RaisePropertyChanged_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workflowEntryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}