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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.EntitlementProcessMilestoneTimeTrigger" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class EntitlementProcessMilestoneTimeTriggerTest : AbstractBaseSetupTypedTest<EntitlementProcessMilestoneTimeTrigger>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EntitlementProcessMilestoneTimeTrigger) Initializer

        private const string Propertyactions = "actions";
        private const string PropertytimeLength = "timeLength";
        private const string PropertytimeLengthSpecified = "timeLengthSpecified";
        private const string PropertyworkflowTimeTriggerUnit = "workflowTimeTriggerUnit";
        private const string FieldactionsField = "actionsField";
        private const string FieldtimeLengthField = "timeLengthField";
        private const string FieldtimeLengthFieldSpecified = "timeLengthFieldSpecified";
        private const string FieldworkflowTimeTriggerUnitField = "workflowTimeTriggerUnitField";
        private Type _entitlementProcessMilestoneTimeTriggerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EntitlementProcessMilestoneTimeTrigger _entitlementProcessMilestoneTimeTriggerInstance;
        private EntitlementProcessMilestoneTimeTrigger _entitlementProcessMilestoneTimeTriggerInstanceFixture;

        #region General Initializer : Class (EntitlementProcessMilestoneTimeTrigger) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EntitlementProcessMilestoneTimeTrigger" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _entitlementProcessMilestoneTimeTriggerInstanceType = typeof(EntitlementProcessMilestoneTimeTrigger);
            _entitlementProcessMilestoneTimeTriggerInstanceFixture = Create(true);
            _entitlementProcessMilestoneTimeTriggerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EntitlementProcessMilestoneTimeTrigger)

        #region General Initializer : Class (EntitlementProcessMilestoneTimeTrigger) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="EntitlementProcessMilestoneTimeTrigger" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyactions)]
        [TestCase(PropertytimeLength)]
        [TestCase(PropertytimeLengthSpecified)]
        [TestCase(PropertyworkflowTimeTriggerUnit)]
        public void AUT_EntitlementProcessMilestoneTimeTrigger_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_entitlementProcessMilestoneTimeTriggerInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EntitlementProcessMilestoneTimeTrigger) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EntitlementProcessMilestoneTimeTrigger" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldactionsField)]
        [TestCase(FieldtimeLengthField)]
        [TestCase(FieldtimeLengthFieldSpecified)]
        [TestCase(FieldworkflowTimeTriggerUnitField)]
        public void AUT_EntitlementProcessMilestoneTimeTrigger_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_entitlementProcessMilestoneTimeTriggerInstanceFixture, 
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
        ///     Class (<see cref="EntitlementProcessMilestoneTimeTrigger" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_EntitlementProcessMilestoneTimeTrigger_Is_Instance_Present_Test()
        {
            // Assert
            _entitlementProcessMilestoneTimeTriggerInstanceType.ShouldNotBeNull();
            _entitlementProcessMilestoneTimeTriggerInstance.ShouldNotBeNull();
            _entitlementProcessMilestoneTimeTriggerInstanceFixture.ShouldNotBeNull();
            _entitlementProcessMilestoneTimeTriggerInstance.ShouldBeAssignableTo<EntitlementProcessMilestoneTimeTrigger>();
            _entitlementProcessMilestoneTimeTriggerInstanceFixture.ShouldBeAssignableTo<EntitlementProcessMilestoneTimeTrigger>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EntitlementProcessMilestoneTimeTrigger) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_EntitlementProcessMilestoneTimeTrigger_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EntitlementProcessMilestoneTimeTrigger instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _entitlementProcessMilestoneTimeTriggerInstanceType.ShouldNotBeNull();
            _entitlementProcessMilestoneTimeTriggerInstance.ShouldNotBeNull();
            _entitlementProcessMilestoneTimeTriggerInstanceFixture.ShouldNotBeNull();
            _entitlementProcessMilestoneTimeTriggerInstance.ShouldBeAssignableTo<EntitlementProcessMilestoneTimeTrigger>();
            _entitlementProcessMilestoneTimeTriggerInstanceFixture.ShouldBeAssignableTo<EntitlementProcessMilestoneTimeTrigger>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (EntitlementProcessMilestoneTimeTrigger) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(WorkflowActionReference[]) , Propertyactions)]
        [TestCaseGeneric(typeof(int) , PropertytimeLength)]
        [TestCaseGeneric(typeof(bool) , PropertytimeLengthSpecified)]
        [TestCaseGeneric(typeof(MilestoneTimeUnits) , PropertyworkflowTimeTriggerUnit)]
        public void AUT_EntitlementProcessMilestoneTimeTrigger_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<EntitlementProcessMilestoneTimeTrigger, T>(_entitlementProcessMilestoneTimeTriggerInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementProcessMilestoneTimeTrigger) => Property (actions) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcessMilestoneTimeTrigger_actions_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyactions);
            Action currentAction = () => propertyInfo.SetValue(_entitlementProcessMilestoneTimeTriggerInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementProcessMilestoneTimeTrigger) => Property (actions) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcessMilestoneTimeTrigger_Public_Class_actions_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (EntitlementProcessMilestoneTimeTrigger) => Property (timeLength) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcessMilestoneTimeTrigger_Public_Class_timeLength_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytimeLength);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementProcessMilestoneTimeTrigger) => Property (timeLengthSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcessMilestoneTimeTrigger_Public_Class_timeLengthSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytimeLengthSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementProcessMilestoneTimeTrigger) => Property (workflowTimeTriggerUnit) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcessMilestoneTimeTrigger_workflowTimeTriggerUnit_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyworkflowTimeTriggerUnit);
            Action currentAction = () => propertyInfo.SetValue(_entitlementProcessMilestoneTimeTriggerInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementProcessMilestoneTimeTrigger) => Property (workflowTimeTriggerUnit) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcessMilestoneTimeTrigger_Public_Class_workflowTimeTriggerUnit_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyworkflowTimeTriggerUnit);

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