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
using WorkflowTransition = UplandIntegrations.TenroxProjectService;

namespace UplandIntegrations.TenroxProjectService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxProjectService.WorkflowTransition" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxProjectService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class WorkflowTransitionTest : AbstractBaseSetupV3Test
    {
        public WorkflowTransitionTest() : base(typeof(WorkflowTransition))
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

        #region General Initializer : Class (WorkflowTransition) Initializer

        #region Properties

        private const string PropertyExtensionData = "ExtensionData";
        private const string PropertyCurrentStatusId = "CurrentStatusId";
        private const string PropertyEnableMoveForwardCondition = "EnableMoveForwardCondition";
        private const string PropertyEnableRollbackCondition = "EnableRollbackCondition";
        private const string PropertyIsApproval = "IsApproval";
        private const string PropertyIsRejection = "IsRejection";
        private const string PropertyMoveForwardCondition = "MoveForwardCondition";
        private const string PropertyName = "Name";
        private const string PropertyNextStateId = "NextStateId";
        private const string PropertyPostProcessAction = "PostProcessAction";
        private const string PropertyPreProcessAction = "PreProcessAction";
        private const string PropertyProjectWorkflowTransitionFlag = "ProjectWorkflowTransitionFlag";
        private const string PropertyRollbackCondition = "RollbackCondition";
        private const string PropertyRollbackStateId = "RollbackStateId";
        private const string PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey";
        private const string PropertyUniqueId = "UniqueId";
        private const string PropertyUseSubWorkflowMap = "UseSubWorkflowMap";
        private const string PropertyWorkflowMap = "WorkflowMap";
        private const string PropertyWorkflowMapId = "WorkflowMapId";
        private const string PropertyWorkflowState = "WorkflowState";

        #endregion

        #region Methods

        private const string MethodRaisePropertyChanged = "RaisePropertyChanged";

        #endregion

        #region Fields

        private const string FieldextensionDataField = "extensionDataField";
        private const string FieldCurrentStatusIdField = "CurrentStatusIdField";
        private const string FieldEnableMoveForwardConditionField = "EnableMoveForwardConditionField";
        private const string FieldEnableRollbackConditionField = "EnableRollbackConditionField";
        private const string FieldIsApprovalField = "IsApprovalField";
        private const string FieldIsRejectionField = "IsRejectionField";
        private const string FieldMoveForwardConditionField = "MoveForwardConditionField";
        private const string FieldNameField = "NameField";
        private const string FieldNextStateIdField = "NextStateIdField";
        private const string FieldPostProcessActionField = "PostProcessActionField";
        private const string FieldPreProcessActionField = "PreProcessActionField";
        private const string FieldProjectWorkflowTransitionFlagField = "ProjectWorkflowTransitionFlagField";
        private const string FieldRollbackConditionField = "RollbackConditionField";
        private const string FieldRollbackStateIdField = "RollbackStateIdField";
        private const string FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField = "SystemDataObjectsDataClassesIEntityWithKeyEntityKeyField";
        private const string FieldUniqueIdField = "UniqueIdField";
        private const string FieldUseSubWorkflowMapField = "UseSubWorkflowMapField";
        private const string FieldWorkflowMapField = "WorkflowMapField";
        private const string FieldWorkflowMapIdField = "WorkflowMapIdField";
        private const string FieldWorkflowStateField = "WorkflowStateField";

        #endregion

        private Type _workflowTransitionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private WorkflowTransition _workflowTransitionInstance;
        private WorkflowTransition _workflowTransitionInstanceFixture;

        #region General Initializer : Class (WorkflowTransition) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkflowTransition" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workflowTransitionInstanceType = typeof(WorkflowTransition);
            _workflowTransitionInstanceFixture = this.Create<WorkflowTransition>(true);
            _workflowTransitionInstance = _workflowTransitionInstanceFixture ?? this.Create<WorkflowTransition>(false);
            CurrentInstance = _workflowTransitionInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkflowTransition)

        #region General Initializer : Class (WorkflowTransition) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="WorkflowTransition" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRaisePropertyChanged, 0)]
        public void AUT_WorkflowTransition_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_workflowTransitionInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WorkflowTransition) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkflowTransition" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyExtensionData)]
        [TestCase(PropertyCurrentStatusId)]
        [TestCase(PropertyEnableMoveForwardCondition)]
        [TestCase(PropertyEnableRollbackCondition)]
        [TestCase(PropertyIsApproval)]
        [TestCase(PropertyIsRejection)]
        [TestCase(PropertyMoveForwardCondition)]
        [TestCase(PropertyName)]
        [TestCase(PropertyNextStateId)]
        [TestCase(PropertyPostProcessAction)]
        [TestCase(PropertyPreProcessAction)]
        [TestCase(PropertyProjectWorkflowTransitionFlag)]
        [TestCase(PropertyRollbackCondition)]
        [TestCase(PropertyRollbackStateId)]
        [TestCase(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCase(PropertyUniqueId)]
        [TestCase(PropertyUseSubWorkflowMap)]
        [TestCase(PropertyWorkflowMap)]
        [TestCase(PropertyWorkflowMapId)]
        [TestCase(PropertyWorkflowState)]
        public void AUT_WorkflowTransition_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var propertyInfo = this.GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_workflowTransitionInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WorkflowTransition) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkflowTransition" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldextensionDataField)]
        [TestCase(FieldCurrentStatusIdField)]
        [TestCase(FieldEnableMoveForwardConditionField)]
        [TestCase(FieldEnableRollbackConditionField)]
        [TestCase(FieldIsApprovalField)]
        [TestCase(FieldIsRejectionField)]
        [TestCase(FieldMoveForwardConditionField)]
        [TestCase(FieldNameField)]
        [TestCase(FieldNextStateIdField)]
        [TestCase(FieldPostProcessActionField)]
        [TestCase(FieldPreProcessActionField)]
        [TestCase(FieldProjectWorkflowTransitionFlagField)]
        [TestCase(FieldRollbackConditionField)]
        [TestCase(FieldRollbackStateIdField)]
        [TestCase(FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField)]
        [TestCase(FieldUniqueIdField)]
        [TestCase(FieldUseSubWorkflowMapField)]
        [TestCase(FieldWorkflowMapField)]
        [TestCase(FieldWorkflowMapIdField)]
        [TestCase(FieldWorkflowStateField)]
        public void AUT_WorkflowTransition_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_workflowTransitionInstanceFixture, 
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
        ///     Class (<see cref="WorkflowTransition" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_WorkflowTransition_Is_Instance_Present_Test()
        {
            // Assert
            _workflowTransitionInstanceType.ShouldNotBeNull();
            _workflowTransitionInstance.ShouldNotBeNull();
            _workflowTransitionInstanceFixture.ShouldNotBeNull();
            _workflowTransitionInstance.ShouldBeAssignableTo<WorkflowTransition>();
            _workflowTransitionInstanceFixture.ShouldBeAssignableTo<WorkflowTransition>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WorkflowTransition) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_WorkflowTransition_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WorkflowTransition instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _workflowTransitionInstanceType.ShouldNotBeNull();
            _workflowTransitionInstance.ShouldNotBeNull();
            _workflowTransitionInstanceFixture.ShouldNotBeNull();
            _workflowTransitionInstance.ShouldBeAssignableTo<WorkflowTransition>();
            _workflowTransitionInstanceFixture.ShouldBeAssignableTo<WorkflowTransition>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (WorkflowTransition) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(System.Runtime.Serialization.ExtensionDataObject) , PropertyExtensionData)]
        [TestCaseGeneric(typeof(int) , PropertyCurrentStatusId)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyEnableMoveForwardCondition)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyEnableRollbackCondition)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsApproval)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsRejection)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyMoveForwardCondition)]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyNextStateId)]
        [TestCaseGeneric(typeof(string) , PropertyPostProcessAction)]
        [TestCaseGeneric(typeof(string) , PropertyPreProcessAction)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxProjectService.ProjectWorkflowTransitionFlag[]) , PropertyProjectWorkflowTransitionFlag)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyRollbackCondition)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyRollbackStateId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxProjectService.EntityKey) , PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCaseGeneric(typeof(int) , PropertyUniqueId)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyUseSubWorkflowMap)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxProjectService.WorkflowMap) , PropertyWorkflowMap)]
        [TestCaseGeneric(typeof(int) , PropertyWorkflowMapId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxProjectService.WorkflowState) , PropertyWorkflowState)]
        public void AUT_WorkflowTransition_Property_Type_Verify_Explore_By_Name_Test<T>(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);

            // Assert
            ShouldlyExtension.PropertyTypeVerify<WorkflowTransition, T>(_workflowTransitionInstance, name, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTransition) => Property (CurrentStatusId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowTransition_Public_Class_CurrentStatusId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCurrentStatusId);
            var propertyInfo  = this.GetPropertyInfo(PropertyCurrentStatusId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTransition) => Property (EnableMoveForwardCondition) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowTransition_Public_Class_EnableMoveForwardCondition_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyEnableMoveForwardCondition);
            var propertyInfo  = this.GetPropertyInfo(PropertyEnableMoveForwardCondition);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTransition) => Property (EnableRollbackCondition) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowTransition_Public_Class_EnableRollbackCondition_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyEnableRollbackCondition);
            var propertyInfo  = this.GetPropertyInfo(PropertyEnableRollbackCondition);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTransition) => Property (ExtensionData) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowTransition_ExtensionData_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExtensionData);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExtensionData);
            Action currentAction = () => propertyInfo.SetValue(_workflowTransitionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTransition) => Property (ExtensionData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowTransition_Public_Class_ExtensionData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowTransition) => Property (IsApproval) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowTransition_Public_Class_IsApproval_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsApproval);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsApproval);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTransition) => Property (IsRejection) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowTransition_Public_Class_IsRejection_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsRejection);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsRejection);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTransition) => Property (MoveForwardCondition) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowTransition_Public_Class_MoveForwardCondition_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMoveForwardCondition);
            var propertyInfo  = this.GetPropertyInfo(PropertyMoveForwardCondition);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTransition) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowTransition_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowTransition) => Property (NextStateId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowTransition_Public_Class_NextStateId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyNextStateId);
            var propertyInfo  = this.GetPropertyInfo(PropertyNextStateId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTransition) => Property (PostProcessAction) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowTransition_Public_Class_PostProcessAction_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPostProcessAction);
            var propertyInfo  = this.GetPropertyInfo(PropertyPostProcessAction);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTransition) => Property (PreProcessAction) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowTransition_Public_Class_PreProcessAction_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPreProcessAction);
            var propertyInfo  = this.GetPropertyInfo(PropertyPreProcessAction);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTransition) => Property (ProjectWorkflowTransitionFlag) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowTransition_ProjectWorkflowTransitionFlag_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectWorkflowTransitionFlag);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyProjectWorkflowTransitionFlag);
            Action currentAction = () => propertyInfo.SetValue(_workflowTransitionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTransition) => Property (ProjectWorkflowTransitionFlag) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowTransition_Public_Class_ProjectWorkflowTransitionFlag_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectWorkflowTransitionFlag);
            var propertyInfo  = this.GetPropertyInfo(PropertyProjectWorkflowTransitionFlag);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTransition) => Property (RollbackCondition) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowTransition_Public_Class_RollbackCondition_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRollbackCondition);
            var propertyInfo  = this.GetPropertyInfo(PropertyRollbackCondition);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTransition) => Property (RollbackStateId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowTransition_Public_Class_RollbackStateId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRollbackStateId);
            var propertyInfo  = this.GetPropertyInfo(PropertyRollbackStateId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTransition) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowTransition_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            Action currentAction = () => propertyInfo.SetValue(_workflowTransitionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTransition) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowTransition_Public_Class_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowTransition) => Property (UniqueId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowTransition_Public_Class_UniqueId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowTransition) => Property (UseSubWorkflowMap) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowTransition_Public_Class_UseSubWorkflowMap_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUseSubWorkflowMap);
            var propertyInfo  = this.GetPropertyInfo(PropertyUseSubWorkflowMap);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTransition) => Property (WorkflowMap) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowTransition_WorkflowMap_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWorkflowMap);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyWorkflowMap);
            Action currentAction = () => propertyInfo.SetValue(_workflowTransitionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTransition) => Property (WorkflowMap) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowTransition_Public_Class_WorkflowMap_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWorkflowMap);
            var propertyInfo  = this.GetPropertyInfo(PropertyWorkflowMap);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTransition) => Property (WorkflowMapId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowTransition_Public_Class_WorkflowMapId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowTransition) => Property (WorkflowState) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowTransition_WorkflowState_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWorkflowState);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyWorkflowState);
            Action currentAction = () => propertyInfo.SetValue(_workflowTransitionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTransition) => Property (WorkflowState) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowTransition_Public_Class_WorkflowState_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWorkflowState);
            var propertyInfo  = this.GetPropertyInfo(PropertyWorkflowState);

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
        private void AUT_WorkflowTransition_RaisePropertyChanged_Method_Call_Internally(Type[] types)
        {
            var methodRaisePropertyChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workflowTransitionInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkflowTransition_RaisePropertyChanged_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workflowTransitionInstanceFixture, parametersOfRaisePropertyChanged);

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
        public void AUT_WorkflowTransition_RaisePropertyChanged_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_workflowTransitionInstance, MethodRaisePropertyChanged, parametersOfRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes);

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
        public void AUT_WorkflowTransition_RaisePropertyChanged_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_WorkflowTransition_RaisePropertyChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workflowTransitionInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);

            // Assert
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkflowTransition_RaisePropertyChanged_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workflowTransitionInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}