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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.EntitlementProcessMilestoneItem" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class EntitlementProcessMilestoneItemTest : AbstractBaseSetupTypedTest<EntitlementProcessMilestoneItem>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EntitlementProcessMilestoneItem) Initializer

        private const string PropertycriteriaBooleanFilter = "criteriaBooleanFilter";
        private const string PropertymilestoneCriteriaFilterItems = "milestoneCriteriaFilterItems";
        private const string PropertymilestoneCriteriaFormula = "milestoneCriteriaFormula";
        private const string PropertymilestoneName = "milestoneName";
        private const string PropertyminutesToComplete = "minutesToComplete";
        private const string PropertyminutesToCompleteSpecified = "minutesToCompleteSpecified";
        private const string PropertysuccessActions = "successActions";
        private const string PropertytimeTriggers = "timeTriggers";
        private const string PropertyuseCriteriaStartTime = "useCriteriaStartTime";
        private const string PropertyuseCriteriaStartTimeSpecified = "useCriteriaStartTimeSpecified";
        private const string FieldcriteriaBooleanFilterField = "criteriaBooleanFilterField";
        private const string FieldmilestoneCriteriaFilterItemsField = "milestoneCriteriaFilterItemsField";
        private const string FieldmilestoneCriteriaFormulaField = "milestoneCriteriaFormulaField";
        private const string FieldmilestoneNameField = "milestoneNameField";
        private const string FieldminutesToCompleteField = "minutesToCompleteField";
        private const string FieldminutesToCompleteFieldSpecified = "minutesToCompleteFieldSpecified";
        private const string FieldsuccessActionsField = "successActionsField";
        private const string FieldtimeTriggersField = "timeTriggersField";
        private const string FielduseCriteriaStartTimeField = "useCriteriaStartTimeField";
        private const string FielduseCriteriaStartTimeFieldSpecified = "useCriteriaStartTimeFieldSpecified";
        private Type _entitlementProcessMilestoneItemInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EntitlementProcessMilestoneItem _entitlementProcessMilestoneItemInstance;
        private EntitlementProcessMilestoneItem _entitlementProcessMilestoneItemInstanceFixture;

        #region General Initializer : Class (EntitlementProcessMilestoneItem) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EntitlementProcessMilestoneItem" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _entitlementProcessMilestoneItemInstanceType = typeof(EntitlementProcessMilestoneItem);
            _entitlementProcessMilestoneItemInstanceFixture = Create(true);
            _entitlementProcessMilestoneItemInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EntitlementProcessMilestoneItem)

        #region General Initializer : Class (EntitlementProcessMilestoneItem) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="EntitlementProcessMilestoneItem" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycriteriaBooleanFilter)]
        [TestCase(PropertymilestoneCriteriaFilterItems)]
        [TestCase(PropertymilestoneCriteriaFormula)]
        [TestCase(PropertymilestoneName)]
        [TestCase(PropertyminutesToComplete)]
        [TestCase(PropertyminutesToCompleteSpecified)]
        [TestCase(PropertysuccessActions)]
        [TestCase(PropertytimeTriggers)]
        [TestCase(PropertyuseCriteriaStartTime)]
        [TestCase(PropertyuseCriteriaStartTimeSpecified)]
        public void AUT_EntitlementProcessMilestoneItem_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_entitlementProcessMilestoneItemInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EntitlementProcessMilestoneItem) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EntitlementProcessMilestoneItem" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcriteriaBooleanFilterField)]
        [TestCase(FieldmilestoneCriteriaFilterItemsField)]
        [TestCase(FieldmilestoneCriteriaFormulaField)]
        [TestCase(FieldmilestoneNameField)]
        [TestCase(FieldminutesToCompleteField)]
        [TestCase(FieldminutesToCompleteFieldSpecified)]
        [TestCase(FieldsuccessActionsField)]
        [TestCase(FieldtimeTriggersField)]
        [TestCase(FielduseCriteriaStartTimeField)]
        [TestCase(FielduseCriteriaStartTimeFieldSpecified)]
        public void AUT_EntitlementProcessMilestoneItem_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_entitlementProcessMilestoneItemInstanceFixture, 
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
        ///     Class (<see cref="EntitlementProcessMilestoneItem" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_EntitlementProcessMilestoneItem_Is_Instance_Present_Test()
        {
            // Assert
            _entitlementProcessMilestoneItemInstanceType.ShouldNotBeNull();
            _entitlementProcessMilestoneItemInstance.ShouldNotBeNull();
            _entitlementProcessMilestoneItemInstanceFixture.ShouldNotBeNull();
            _entitlementProcessMilestoneItemInstance.ShouldBeAssignableTo<EntitlementProcessMilestoneItem>();
            _entitlementProcessMilestoneItemInstanceFixture.ShouldBeAssignableTo<EntitlementProcessMilestoneItem>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EntitlementProcessMilestoneItem) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_EntitlementProcessMilestoneItem_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EntitlementProcessMilestoneItem instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _entitlementProcessMilestoneItemInstanceType.ShouldNotBeNull();
            _entitlementProcessMilestoneItemInstance.ShouldNotBeNull();
            _entitlementProcessMilestoneItemInstanceFixture.ShouldNotBeNull();
            _entitlementProcessMilestoneItemInstance.ShouldBeAssignableTo<EntitlementProcessMilestoneItem>();
            _entitlementProcessMilestoneItemInstanceFixture.ShouldBeAssignableTo<EntitlementProcessMilestoneItem>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (EntitlementProcessMilestoneItem) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertycriteriaBooleanFilter)]
        [TestCaseGeneric(typeof(FilterItem[]) , PropertymilestoneCriteriaFilterItems)]
        [TestCaseGeneric(typeof(string) , PropertymilestoneCriteriaFormula)]
        [TestCaseGeneric(typeof(string) , PropertymilestoneName)]
        [TestCaseGeneric(typeof(int) , PropertyminutesToComplete)]
        [TestCaseGeneric(typeof(bool) , PropertyminutesToCompleteSpecified)]
        [TestCaseGeneric(typeof(WorkflowActionReference[]) , PropertysuccessActions)]
        [TestCaseGeneric(typeof(EntitlementProcessMilestoneTimeTrigger[]) , PropertytimeTriggers)]
        [TestCaseGeneric(typeof(bool) , PropertyuseCriteriaStartTime)]
        [TestCaseGeneric(typeof(bool) , PropertyuseCriteriaStartTimeSpecified)]
        public void AUT_EntitlementProcessMilestoneItem_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<EntitlementProcessMilestoneItem, T>(_entitlementProcessMilestoneItemInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementProcessMilestoneItem) => Property (criteriaBooleanFilter) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcessMilestoneItem_Public_Class_criteriaBooleanFilter_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycriteriaBooleanFilter);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementProcessMilestoneItem) => Property (milestoneCriteriaFilterItems) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcessMilestoneItem_milestoneCriteriaFilterItems_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertymilestoneCriteriaFilterItems);
            Action currentAction = () => propertyInfo.SetValue(_entitlementProcessMilestoneItemInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementProcessMilestoneItem) => Property (milestoneCriteriaFilterItems) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcessMilestoneItem_Public_Class_milestoneCriteriaFilterItems_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymilestoneCriteriaFilterItems);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementProcessMilestoneItem) => Property (milestoneCriteriaFormula) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcessMilestoneItem_Public_Class_milestoneCriteriaFormula_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymilestoneCriteriaFormula);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementProcessMilestoneItem) => Property (milestoneName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcessMilestoneItem_Public_Class_milestoneName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymilestoneName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementProcessMilestoneItem) => Property (minutesToComplete) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcessMilestoneItem_Public_Class_minutesToComplete_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyminutesToComplete);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementProcessMilestoneItem) => Property (minutesToCompleteSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcessMilestoneItem_Public_Class_minutesToCompleteSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyminutesToCompleteSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementProcessMilestoneItem) => Property (successActions) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcessMilestoneItem_successActions_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysuccessActions);
            Action currentAction = () => propertyInfo.SetValue(_entitlementProcessMilestoneItemInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementProcessMilestoneItem) => Property (successActions) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcessMilestoneItem_Public_Class_successActions_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysuccessActions);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementProcessMilestoneItem) => Property (timeTriggers) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcessMilestoneItem_timeTriggers_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertytimeTriggers);
            Action currentAction = () => propertyInfo.SetValue(_entitlementProcessMilestoneItemInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementProcessMilestoneItem) => Property (timeTriggers) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcessMilestoneItem_Public_Class_timeTriggers_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytimeTriggers);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementProcessMilestoneItem) => Property (useCriteriaStartTime) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcessMilestoneItem_Public_Class_useCriteriaStartTime_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuseCriteriaStartTime);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementProcessMilestoneItem) => Property (useCriteriaStartTimeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcessMilestoneItem_Public_Class_useCriteriaStartTimeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuseCriteriaStartTimeSpecified);

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