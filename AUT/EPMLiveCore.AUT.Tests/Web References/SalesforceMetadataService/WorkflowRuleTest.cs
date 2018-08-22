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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.WorkflowRule" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class WorkflowRuleTest : AbstractBaseSetupTypedTest<WorkflowRule>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WorkflowRule) Initializer

        private const string Propertyactions = "actions";
        private const string Propertyactive = "active";
        private const string PropertybooleanFilter = "booleanFilter";
        private const string PropertycriteriaItems = "criteriaItems";
        private const string Propertydescription = "description";
        private const string Propertyformula = "formula";
        private const string PropertytriggerType = "triggerType";
        private const string PropertyworkflowTimeTriggers = "workflowTimeTriggers";
        private const string FieldactionsField = "actionsField";
        private const string FieldactiveField = "activeField";
        private const string FieldbooleanFilterField = "booleanFilterField";
        private const string FieldcriteriaItemsField = "criteriaItemsField";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldformulaField = "formulaField";
        private const string FieldtriggerTypeField = "triggerTypeField";
        private const string FieldworkflowTimeTriggersField = "workflowTimeTriggersField";
        private Type _workflowRuleInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WorkflowRule _workflowRuleInstance;
        private WorkflowRule _workflowRuleInstanceFixture;

        #region General Initializer : Class (WorkflowRule) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkflowRule" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workflowRuleInstanceType = typeof(WorkflowRule);
            _workflowRuleInstanceFixture = Create(true);
            _workflowRuleInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkflowRule)

        #region General Initializer : Class (WorkflowRule) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkflowRule" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyactions)]
        [TestCase(Propertyactive)]
        [TestCase(PropertybooleanFilter)]
        [TestCase(PropertycriteriaItems)]
        [TestCase(Propertydescription)]
        [TestCase(Propertyformula)]
        [TestCase(PropertytriggerType)]
        [TestCase(PropertyworkflowTimeTriggers)]
        public void AUT_WorkflowRule_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_workflowRuleInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WorkflowRule) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkflowRule" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldactionsField)]
        [TestCase(FieldactiveField)]
        [TestCase(FieldbooleanFilterField)]
        [TestCase(FieldcriteriaItemsField)]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldformulaField)]
        [TestCase(FieldtriggerTypeField)]
        [TestCase(FieldworkflowTimeTriggersField)]
        public void AUT_WorkflowRule_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_workflowRuleInstanceFixture, 
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
        ///     Class (<see cref="WorkflowRule" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_WorkflowRule_Is_Instance_Present_Test()
        {
            // Assert
            _workflowRuleInstanceType.ShouldNotBeNull();
            _workflowRuleInstance.ShouldNotBeNull();
            _workflowRuleInstanceFixture.ShouldNotBeNull();
            _workflowRuleInstance.ShouldBeAssignableTo<WorkflowRule>();
            _workflowRuleInstanceFixture.ShouldBeAssignableTo<WorkflowRule>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WorkflowRule) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_WorkflowRule_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WorkflowRule instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _workflowRuleInstanceType.ShouldNotBeNull();
            _workflowRuleInstance.ShouldNotBeNull();
            _workflowRuleInstanceFixture.ShouldNotBeNull();
            _workflowRuleInstance.ShouldBeAssignableTo<WorkflowRule>();
            _workflowRuleInstanceFixture.ShouldBeAssignableTo<WorkflowRule>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (WorkflowRule) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(WorkflowActionReference[]) , Propertyactions)]
        [TestCaseGeneric(typeof(bool) , Propertyactive)]
        [TestCaseGeneric(typeof(string) , PropertybooleanFilter)]
        [TestCaseGeneric(typeof(FilterItem[]) , PropertycriteriaItems)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(string) , Propertyformula)]
        [TestCaseGeneric(typeof(WorkflowTriggerTypes) , PropertytriggerType)]
        [TestCaseGeneric(typeof(WorkflowTimeTrigger[]) , PropertyworkflowTimeTriggers)]
        public void AUT_WorkflowRule_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<WorkflowRule, T>(_workflowRuleInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowRule) => Property (actions) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowRule_actions_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyactions);
            Action currentAction = () => propertyInfo.SetValue(_workflowRuleInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowRule) => Property (actions) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowRule_Public_Class_actions_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyactions);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowRule) => Property (active) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowRule_Public_Class_active_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyactive);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowRule) => Property (booleanFilter) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowRule_Public_Class_booleanFilter_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybooleanFilter);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowRule) => Property (criteriaItems) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowRule_criteriaItems_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycriteriaItems);
            Action currentAction = () => propertyInfo.SetValue(_workflowRuleInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowRule) => Property (criteriaItems) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowRule_Public_Class_criteriaItems_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycriteriaItems);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowRule) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowRule_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertydescription);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowRule) => Property (formula) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowRule_Public_Class_formula_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyformula);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowRule) => Property (triggerType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowRule_triggerType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertytriggerType);
            Action currentAction = () => propertyInfo.SetValue(_workflowRuleInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowRule) => Property (triggerType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowRule_Public_Class_triggerType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytriggerType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowRule) => Property (workflowTimeTriggers) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowRule_workflowTimeTriggers_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyworkflowTimeTriggers);
            Action currentAction = () => propertyInfo.SetValue(_workflowRuleInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowRule) => Property (workflowTimeTriggers) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowRule_Public_Class_workflowTimeTriggers_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyworkflowTimeTriggers);

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