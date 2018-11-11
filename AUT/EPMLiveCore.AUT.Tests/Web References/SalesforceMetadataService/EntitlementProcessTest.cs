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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.EntitlementProcess" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class EntitlementProcessTest : AbstractBaseSetupTypedTest<EntitlementProcess>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EntitlementProcess) Initializer

        private const string Propertyactive = "active";
        private const string PropertyactiveSpecified = "activeSpecified";
        private const string Propertydescription = "description";
        private const string PropertyentryStartDateField = "entryStartDateField";
        private const string PropertyexitCriteriaBooleanFilter = "exitCriteriaBooleanFilter";
        private const string PropertyexitCriteriaFilterItems = "exitCriteriaFilterItems";
        private const string PropertyexitCriteriaFormula = "exitCriteriaFormula";
        private const string Propertymilestones = "milestones";
        private const string FieldactiveField = "activeField";
        private const string FieldactiveFieldSpecified = "activeFieldSpecified";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldentryStartDateFieldField = "entryStartDateFieldField";
        private const string FieldexitCriteriaBooleanFilterField = "exitCriteriaBooleanFilterField";
        private const string FieldexitCriteriaFilterItemsField = "exitCriteriaFilterItemsField";
        private const string FieldexitCriteriaFormulaField = "exitCriteriaFormulaField";
        private const string FieldmilestonesField = "milestonesField";
        private Type _entitlementProcessInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EntitlementProcess _entitlementProcessInstance;
        private EntitlementProcess _entitlementProcessInstanceFixture;

        #region General Initializer : Class (EntitlementProcess) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EntitlementProcess" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _entitlementProcessInstanceType = typeof(EntitlementProcess);
            _entitlementProcessInstanceFixture = Create(true);
            _entitlementProcessInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EntitlementProcess)

        #region General Initializer : Class (EntitlementProcess) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="EntitlementProcess" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyactive)]
        [TestCase(PropertyactiveSpecified)]
        [TestCase(Propertydescription)]
        [TestCase(PropertyentryStartDateField)]
        [TestCase(PropertyexitCriteriaBooleanFilter)]
        [TestCase(PropertyexitCriteriaFilterItems)]
        [TestCase(PropertyexitCriteriaFormula)]
        [TestCase(Propertymilestones)]
        public void AUT_EntitlementProcess_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_entitlementProcessInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EntitlementProcess) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EntitlementProcess" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldactiveField)]
        [TestCase(FieldactiveFieldSpecified)]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldentryStartDateFieldField)]
        [TestCase(FieldexitCriteriaBooleanFilterField)]
        [TestCase(FieldexitCriteriaFilterItemsField)]
        [TestCase(FieldexitCriteriaFormulaField)]
        [TestCase(FieldmilestonesField)]
        public void AUT_EntitlementProcess_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_entitlementProcessInstanceFixture, 
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
        ///     Class (<see cref="EntitlementProcess" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_EntitlementProcess_Is_Instance_Present_Test()
        {
            // Assert
            _entitlementProcessInstanceType.ShouldNotBeNull();
            _entitlementProcessInstance.ShouldNotBeNull();
            _entitlementProcessInstanceFixture.ShouldNotBeNull();
            _entitlementProcessInstance.ShouldBeAssignableTo<EntitlementProcess>();
            _entitlementProcessInstanceFixture.ShouldBeAssignableTo<EntitlementProcess>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EntitlementProcess) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_EntitlementProcess_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EntitlementProcess instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _entitlementProcessInstanceType.ShouldNotBeNull();
            _entitlementProcessInstance.ShouldNotBeNull();
            _entitlementProcessInstanceFixture.ShouldNotBeNull();
            _entitlementProcessInstance.ShouldBeAssignableTo<EntitlementProcess>();
            _entitlementProcessInstanceFixture.ShouldBeAssignableTo<EntitlementProcess>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (EntitlementProcess) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , Propertyactive)]
        [TestCaseGeneric(typeof(bool) , PropertyactiveSpecified)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(string) , PropertyentryStartDateField)]
        [TestCaseGeneric(typeof(string) , PropertyexitCriteriaBooleanFilter)]
        [TestCaseGeneric(typeof(FilterItem[]) , PropertyexitCriteriaFilterItems)]
        [TestCaseGeneric(typeof(string) , PropertyexitCriteriaFormula)]
        [TestCaseGeneric(typeof(EntitlementProcessMilestoneItem[]) , Propertymilestones)]
        public void AUT_EntitlementProcess_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<EntitlementProcess, T>(_entitlementProcessInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementProcess) => Property (active) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcess_Public_Class_active_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (EntitlementProcess) => Property (activeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcess_Public_Class_activeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyactiveSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementProcess) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcess_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (EntitlementProcess) => Property (entryStartDateField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcess_Public_Class_entryStartDateField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyentryStartDateField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementProcess) => Property (exitCriteriaBooleanFilter) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcess_Public_Class_exitCriteriaBooleanFilter_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyexitCriteriaBooleanFilter);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementProcess) => Property (exitCriteriaFilterItems) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcess_exitCriteriaFilterItems_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyexitCriteriaFilterItems);
            Action currentAction = () => propertyInfo.SetValue(_entitlementProcessInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementProcess) => Property (exitCriteriaFilterItems) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcess_Public_Class_exitCriteriaFilterItems_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyexitCriteriaFilterItems);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementProcess) => Property (exitCriteriaFormula) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcess_Public_Class_exitCriteriaFormula_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyexitCriteriaFormula);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementProcess) => Property (milestones) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcess_milestones_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertymilestones);
            Action currentAction = () => propertyInfo.SetValue(_entitlementProcessInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementProcess) => Property (milestones) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementProcess_Public_Class_milestones_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertymilestones);

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