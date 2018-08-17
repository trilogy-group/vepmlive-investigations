using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.Workflow" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class WorkflowTest : AbstractBaseSetupTypedTest<Workflow>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Workflow) Initializer

        private const string Propertyalerts = "alerts";
        private const string PropertyfieldUpdates = "fieldUpdates";
        private const string PropertyknowledgePublishes = "knowledgePublishes";
        private const string PropertyoutboundMessages = "outboundMessages";
        private const string Propertyrules = "rules";
        private const string Propertysend = "send";
        private const string Propertytasks = "tasks";
        private const string FieldalertsField = "alertsField";
        private const string FieldfieldUpdatesField = "fieldUpdatesField";
        private const string FieldknowledgePublishesField = "knowledgePublishesField";
        private const string FieldoutboundMessagesField = "outboundMessagesField";
        private const string FieldrulesField = "rulesField";
        private const string FieldsendField = "sendField";
        private const string FieldtasksField = "tasksField";
        private Type _workflowInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Workflow _workflowInstance;
        private Workflow _workflowInstanceFixture;

        #region General Initializer : Class (Workflow) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Workflow" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workflowInstanceType = typeof(Workflow);
            _workflowInstanceFixture = Create(true);
            _workflowInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Workflow)

        #region General Initializer : Class (Workflow) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Workflow" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyalerts)]
        [TestCase(PropertyfieldUpdates)]
        [TestCase(PropertyknowledgePublishes)]
        [TestCase(PropertyoutboundMessages)]
        [TestCase(Propertyrules)]
        [TestCase(Propertysend)]
        [TestCase(Propertytasks)]
        public void AUT_Workflow_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_workflowInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Workflow) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Workflow" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldalertsField)]
        [TestCase(FieldfieldUpdatesField)]
        [TestCase(FieldknowledgePublishesField)]
        [TestCase(FieldoutboundMessagesField)]
        [TestCase(FieldrulesField)]
        [TestCase(FieldsendField)]
        [TestCase(FieldtasksField)]
        public void AUT_Workflow_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_workflowInstanceFixture, 
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
        ///     Class (<see cref="Workflow" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Workflow_Is_Instance_Present_Test()
        {
            // Assert
            _workflowInstanceType.ShouldNotBeNull();
            _workflowInstance.ShouldNotBeNull();
            _workflowInstanceFixture.ShouldNotBeNull();
            _workflowInstance.ShouldBeAssignableTo<Workflow>();
            _workflowInstanceFixture.ShouldBeAssignableTo<Workflow>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Workflow) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Workflow_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Workflow instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _workflowInstanceType.ShouldNotBeNull();
            _workflowInstance.ShouldNotBeNull();
            _workflowInstanceFixture.ShouldNotBeNull();
            _workflowInstance.ShouldBeAssignableTo<Workflow>();
            _workflowInstanceFixture.ShouldBeAssignableTo<Workflow>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Workflow) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(WorkflowAlert[]) , Propertyalerts)]
        [TestCaseGeneric(typeof(WorkflowFieldUpdate[]) , PropertyfieldUpdates)]
        [TestCaseGeneric(typeof(WorkflowKnowledgePublish[]) , PropertyknowledgePublishes)]
        [TestCaseGeneric(typeof(WorkflowOutboundMessage[]) , PropertyoutboundMessages)]
        [TestCaseGeneric(typeof(WorkflowRule[]) , Propertyrules)]
        [TestCaseGeneric(typeof(WorkflowSend[]) , Propertysend)]
        [TestCaseGeneric(typeof(WorkflowTask[]) , Propertytasks)]
        public void AUT_Workflow_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Workflow, T>(_workflowInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Workflow) => Property (alerts) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Workflow_alerts_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyalerts);
            Action currentAction = () => propertyInfo.SetValue(_workflowInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Workflow) => Property (alerts) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Workflow_Public_Class_alerts_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyalerts);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Workflow) => Property (fieldUpdates) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Workflow_fieldUpdates_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyfieldUpdates);
            Action currentAction = () => propertyInfo.SetValue(_workflowInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Workflow) => Property (fieldUpdates) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Workflow_Public_Class_fieldUpdates_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyfieldUpdates);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Workflow) => Property (knowledgePublishes) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Workflow_knowledgePublishes_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyknowledgePublishes);
            Action currentAction = () => propertyInfo.SetValue(_workflowInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Workflow) => Property (knowledgePublishes) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Workflow_Public_Class_knowledgePublishes_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyknowledgePublishes);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Workflow) => Property (outboundMessages) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Workflow_outboundMessages_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyoutboundMessages);
            Action currentAction = () => propertyInfo.SetValue(_workflowInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Workflow) => Property (outboundMessages) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Workflow_Public_Class_outboundMessages_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyoutboundMessages);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Workflow) => Property (rules) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Workflow_rules_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyrules);
            Action currentAction = () => propertyInfo.SetValue(_workflowInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Workflow) => Property (rules) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Workflow_Public_Class_rules_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyrules);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Workflow) => Property (send) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Workflow_send_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertysend);
            Action currentAction = () => propertyInfo.SetValue(_workflowInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Workflow) => Property (send) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Workflow_Public_Class_send_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysend);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Workflow) => Property (tasks) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Workflow_tasks_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertytasks);
            Action currentAction = () => propertyInfo.SetValue(_workflowInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Workflow) => Property (tasks) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Workflow_Public_Class_tasks_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytasks);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #endregion
    }
}