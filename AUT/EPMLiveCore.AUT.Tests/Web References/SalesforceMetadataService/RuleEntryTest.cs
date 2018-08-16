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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.RuleEntry" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RuleEntryTest : AbstractBaseSetupTypedTest<RuleEntry>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RuleEntry) Initializer

        private const string PropertyassignedTo = "assignedTo";
        private const string PropertyassignedToType = "assignedToType";
        private const string PropertyassignedToTypeSpecified = "assignedToTypeSpecified";
        private const string PropertybooleanFilter = "booleanFilter";
        private const string PropertybusinessHours = "businessHours";
        private const string PropertybusinessHoursSource = "businessHoursSource";
        private const string PropertybusinessHoursSourceSpecified = "businessHoursSourceSpecified";
        private const string PropertycriteriaItems = "criteriaItems";
        private const string PropertydisableEscalationWhenModified = "disableEscalationWhenModified";
        private const string PropertydisableEscalationWhenModifiedSpecified = "disableEscalationWhenModifiedSpecified";
        private const string PropertyescalationAction = "escalationAction";
        private const string PropertyescalationStartTime = "escalationStartTime";
        private const string PropertyescalationStartTimeSpecified = "escalationStartTimeSpecified";
        private const string Propertyformula = "formula";
        private const string PropertyoverrideExistingTeams = "overrideExistingTeams";
        private const string PropertyoverrideExistingTeamsSpecified = "overrideExistingTeamsSpecified";
        private const string PropertyreplyToEmail = "replyToEmail";
        private const string PropertysenderEmail = "senderEmail";
        private const string PropertysenderName = "senderName";
        private const string Propertyteam = "team";
        private const string Propertytemplate = "template";
        private const string FieldassignedToField = "assignedToField";
        private const string FieldassignedToTypeField = "assignedToTypeField";
        private const string FieldassignedToTypeFieldSpecified = "assignedToTypeFieldSpecified";
        private const string FieldbooleanFilterField = "booleanFilterField";
        private const string FieldbusinessHoursField = "businessHoursField";
        private const string FieldbusinessHoursSourceField = "businessHoursSourceField";
        private const string FieldbusinessHoursSourceFieldSpecified = "businessHoursSourceFieldSpecified";
        private const string FieldcriteriaItemsField = "criteriaItemsField";
        private const string FielddisableEscalationWhenModifiedField = "disableEscalationWhenModifiedField";
        private const string FielddisableEscalationWhenModifiedFieldSpecified = "disableEscalationWhenModifiedFieldSpecified";
        private const string FieldescalationActionField = "escalationActionField";
        private const string FieldescalationStartTimeField = "escalationStartTimeField";
        private const string FieldescalationStartTimeFieldSpecified = "escalationStartTimeFieldSpecified";
        private const string FieldformulaField = "formulaField";
        private const string FieldoverrideExistingTeamsField = "overrideExistingTeamsField";
        private const string FieldoverrideExistingTeamsFieldSpecified = "overrideExistingTeamsFieldSpecified";
        private const string FieldreplyToEmailField = "replyToEmailField";
        private const string FieldsenderEmailField = "senderEmailField";
        private const string FieldsenderNameField = "senderNameField";
        private const string FieldteamField = "teamField";
        private const string FieldtemplateField = "templateField";
        private Type _ruleEntryInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RuleEntry _ruleEntryInstance;
        private RuleEntry _ruleEntryInstanceFixture;

        #region General Initializer : Class (RuleEntry) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RuleEntry" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _ruleEntryInstanceType = typeof(RuleEntry);
            _ruleEntryInstanceFixture = Create(true);
            _ruleEntryInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RuleEntry)

        #region General Initializer : Class (RuleEntry) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="RuleEntry" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyassignedTo)]
        [TestCase(PropertyassignedToType)]
        [TestCase(PropertyassignedToTypeSpecified)]
        [TestCase(PropertybooleanFilter)]
        [TestCase(PropertybusinessHours)]
        [TestCase(PropertybusinessHoursSource)]
        [TestCase(PropertybusinessHoursSourceSpecified)]
        [TestCase(PropertycriteriaItems)]
        [TestCase(PropertydisableEscalationWhenModified)]
        [TestCase(PropertydisableEscalationWhenModifiedSpecified)]
        [TestCase(PropertyescalationAction)]
        [TestCase(PropertyescalationStartTime)]
        [TestCase(PropertyescalationStartTimeSpecified)]
        [TestCase(Propertyformula)]
        [TestCase(PropertyoverrideExistingTeams)]
        [TestCase(PropertyoverrideExistingTeamsSpecified)]
        [TestCase(PropertyreplyToEmail)]
        [TestCase(PropertysenderEmail)]
        [TestCase(PropertysenderName)]
        [TestCase(Propertyteam)]
        [TestCase(Propertytemplate)]
        public void AUT_RuleEntry_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_ruleEntryInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (RuleEntry) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RuleEntry" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldassignedToField)]
        [TestCase(FieldassignedToTypeField)]
        [TestCase(FieldassignedToTypeFieldSpecified)]
        [TestCase(FieldbooleanFilterField)]
        [TestCase(FieldbusinessHoursField)]
        [TestCase(FieldbusinessHoursSourceField)]
        [TestCase(FieldbusinessHoursSourceFieldSpecified)]
        [TestCase(FieldcriteriaItemsField)]
        [TestCase(FielddisableEscalationWhenModifiedField)]
        [TestCase(FielddisableEscalationWhenModifiedFieldSpecified)]
        [TestCase(FieldescalationActionField)]
        [TestCase(FieldescalationStartTimeField)]
        [TestCase(FieldescalationStartTimeFieldSpecified)]
        [TestCase(FieldformulaField)]
        [TestCase(FieldoverrideExistingTeamsField)]
        [TestCase(FieldoverrideExistingTeamsFieldSpecified)]
        [TestCase(FieldreplyToEmailField)]
        [TestCase(FieldsenderEmailField)]
        [TestCase(FieldsenderNameField)]
        [TestCase(FieldteamField)]
        [TestCase(FieldtemplateField)]
        public void AUT_RuleEntry_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_ruleEntryInstanceFixture, 
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
        ///     Class (<see cref="RuleEntry" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_RuleEntry_Is_Instance_Present_Test()
        {
            // Assert
            _ruleEntryInstanceType.ShouldNotBeNull();
            _ruleEntryInstance.ShouldNotBeNull();
            _ruleEntryInstanceFixture.ShouldNotBeNull();
            _ruleEntryInstance.ShouldBeAssignableTo<RuleEntry>();
            _ruleEntryInstanceFixture.ShouldBeAssignableTo<RuleEntry>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RuleEntry) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_RuleEntry_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RuleEntry instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _ruleEntryInstanceType.ShouldNotBeNull();
            _ruleEntryInstance.ShouldNotBeNull();
            _ruleEntryInstanceFixture.ShouldNotBeNull();
            _ruleEntryInstance.ShouldBeAssignableTo<RuleEntry>();
            _ruleEntryInstanceFixture.ShouldBeAssignableTo<RuleEntry>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (RuleEntry) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyassignedTo)]
        [TestCaseGeneric(typeof(AssignToLookupValueType) , PropertyassignedToType)]
        [TestCaseGeneric(typeof(bool) , PropertyassignedToTypeSpecified)]
        [TestCaseGeneric(typeof(string) , PropertybooleanFilter)]
        [TestCaseGeneric(typeof(string) , PropertybusinessHours)]
        [TestCaseGeneric(typeof(BusinessHoursSourceType) , PropertybusinessHoursSource)]
        [TestCaseGeneric(typeof(bool) , PropertybusinessHoursSourceSpecified)]
        [TestCaseGeneric(typeof(FilterItem[]) , PropertycriteriaItems)]
        [TestCaseGeneric(typeof(bool) , PropertydisableEscalationWhenModified)]
        [TestCaseGeneric(typeof(bool) , PropertydisableEscalationWhenModifiedSpecified)]
        [TestCaseGeneric(typeof(EscalationAction[]) , PropertyescalationAction)]
        [TestCaseGeneric(typeof(EscalationStartTimeType) , PropertyescalationStartTime)]
        [TestCaseGeneric(typeof(bool) , PropertyescalationStartTimeSpecified)]
        [TestCaseGeneric(typeof(string) , Propertyformula)]
        [TestCaseGeneric(typeof(bool) , PropertyoverrideExistingTeams)]
        [TestCaseGeneric(typeof(bool) , PropertyoverrideExistingTeamsSpecified)]
        [TestCaseGeneric(typeof(string) , PropertyreplyToEmail)]
        [TestCaseGeneric(typeof(string) , PropertysenderEmail)]
        [TestCaseGeneric(typeof(string) , PropertysenderName)]
        [TestCaseGeneric(typeof(string[]) , Propertyteam)]
        [TestCaseGeneric(typeof(string) , Propertytemplate)]
        public void AUT_RuleEntry_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<RuleEntry, T>(_ruleEntryInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (RuleEntry) => Property (assignedTo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RuleEntry_Public_Class_assignedTo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyassignedTo);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RuleEntry) => Property (assignedToType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RuleEntry_assignedToType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyassignedToType);
            Action currentAction = () => propertyInfo.SetValue(_ruleEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (RuleEntry) => Property (assignedToType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RuleEntry_Public_Class_assignedToType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyassignedToType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RuleEntry) => Property (assignedToTypeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RuleEntry_Public_Class_assignedToTypeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyassignedToTypeSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RuleEntry) => Property (booleanFilter) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RuleEntry_Public_Class_booleanFilter_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (RuleEntry) => Property (businessHours) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RuleEntry_Public_Class_businessHours_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybusinessHours);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RuleEntry) => Property (businessHoursSource) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RuleEntry_businessHoursSource_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertybusinessHoursSource);
            Action currentAction = () => propertyInfo.SetValue(_ruleEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (RuleEntry) => Property (businessHoursSource) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RuleEntry_Public_Class_businessHoursSource_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybusinessHoursSource);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RuleEntry) => Property (businessHoursSourceSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RuleEntry_Public_Class_businessHoursSourceSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybusinessHoursSourceSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RuleEntry) => Property (criteriaItems) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RuleEntry_criteriaItems_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycriteriaItems);
            Action currentAction = () => propertyInfo.SetValue(_ruleEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (RuleEntry) => Property (criteriaItems) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RuleEntry_Public_Class_criteriaItems_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (RuleEntry) => Property (disableEscalationWhenModified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RuleEntry_Public_Class_disableEscalationWhenModified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydisableEscalationWhenModified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RuleEntry) => Property (disableEscalationWhenModifiedSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RuleEntry_Public_Class_disableEscalationWhenModifiedSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydisableEscalationWhenModifiedSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RuleEntry) => Property (escalationAction) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RuleEntry_escalationAction_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyescalationAction);
            Action currentAction = () => propertyInfo.SetValue(_ruleEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (RuleEntry) => Property (escalationAction) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RuleEntry_Public_Class_escalationAction_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyescalationAction);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RuleEntry) => Property (escalationStartTime) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RuleEntry_escalationStartTime_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyescalationStartTime);
            Action currentAction = () => propertyInfo.SetValue(_ruleEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (RuleEntry) => Property (escalationStartTime) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RuleEntry_Public_Class_escalationStartTime_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyescalationStartTime);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RuleEntry) => Property (escalationStartTimeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RuleEntry_Public_Class_escalationStartTimeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyescalationStartTimeSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RuleEntry) => Property (formula) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RuleEntry_Public_Class_formula_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (RuleEntry) => Property (overrideExistingTeams) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RuleEntry_Public_Class_overrideExistingTeams_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyoverrideExistingTeams);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RuleEntry) => Property (overrideExistingTeamsSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RuleEntry_Public_Class_overrideExistingTeamsSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyoverrideExistingTeamsSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RuleEntry) => Property (replyToEmail) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RuleEntry_Public_Class_replyToEmail_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyreplyToEmail);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RuleEntry) => Property (senderEmail) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RuleEntry_Public_Class_senderEmail_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysenderEmail);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RuleEntry) => Property (senderName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RuleEntry_Public_Class_senderName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysenderName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RuleEntry) => Property (team) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RuleEntry_team_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyteam);
            Action currentAction = () => propertyInfo.SetValue(_ruleEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (RuleEntry) => Property (team) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RuleEntry_Public_Class_team_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyteam);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RuleEntry) => Property (template) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RuleEntry_Public_Class_template_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytemplate);

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