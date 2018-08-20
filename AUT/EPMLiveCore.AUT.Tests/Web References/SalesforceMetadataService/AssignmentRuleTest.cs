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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.AssignmentRule" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AssignmentRuleTest : AbstractBaseSetupTypedTest<AssignmentRule>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AssignmentRule) Initializer

        private const string Propertyactive = "active";
        private const string PropertyactiveSpecified = "activeSpecified";
        private const string PropertyruleEntry = "ruleEntry";
        private const string FieldactiveField = "activeField";
        private const string FieldactiveFieldSpecified = "activeFieldSpecified";
        private const string FieldruleEntryField = "ruleEntryField";
        private Type _assignmentRuleInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AssignmentRule _assignmentRuleInstance;
        private AssignmentRule _assignmentRuleInstanceFixture;

        #region General Initializer : Class (AssignmentRule) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AssignmentRule" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _assignmentRuleInstanceType = typeof(AssignmentRule);
            _assignmentRuleInstanceFixture = Create(true);
            _assignmentRuleInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AssignmentRule)

        #region General Initializer : Class (AssignmentRule) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="AssignmentRule" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyactive)]
        [TestCase(PropertyactiveSpecified)]
        [TestCase(PropertyruleEntry)]
        public void AUT_AssignmentRule_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_assignmentRuleInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AssignmentRule) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="AssignmentRule" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldactiveField)]
        [TestCase(FieldactiveFieldSpecified)]
        [TestCase(FieldruleEntryField)]
        public void AUT_AssignmentRule_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_assignmentRuleInstanceFixture, 
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
        ///     Class (<see cref="AssignmentRule" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_AssignmentRule_Is_Instance_Present_Test()
        {
            // Assert
            _assignmentRuleInstanceType.ShouldNotBeNull();
            _assignmentRuleInstance.ShouldNotBeNull();
            _assignmentRuleInstanceFixture.ShouldNotBeNull();
            _assignmentRuleInstance.ShouldBeAssignableTo<AssignmentRule>();
            _assignmentRuleInstanceFixture.ShouldBeAssignableTo<AssignmentRule>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (AssignmentRule) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_AssignmentRule_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            AssignmentRule instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _assignmentRuleInstanceType.ShouldNotBeNull();
            _assignmentRuleInstance.ShouldNotBeNull();
            _assignmentRuleInstanceFixture.ShouldNotBeNull();
            _assignmentRuleInstance.ShouldBeAssignableTo<AssignmentRule>();
            _assignmentRuleInstanceFixture.ShouldBeAssignableTo<AssignmentRule>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (AssignmentRule) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , Propertyactive)]
        [TestCaseGeneric(typeof(bool) , PropertyactiveSpecified)]
        [TestCaseGeneric(typeof(RuleEntry[]) , PropertyruleEntry)]
        public void AUT_AssignmentRule_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<AssignmentRule, T>(_assignmentRuleInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (AssignmentRule) => Property (active) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AssignmentRule_Public_Class_active_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (AssignmentRule) => Property (activeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AssignmentRule_Public_Class_activeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (AssignmentRule) => Property (ruleEntry) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AssignmentRule_ruleEntry_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyruleEntry);
            Action currentAction = () => propertyInfo.SetValue(_assignmentRuleInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AssignmentRule) => Property (ruleEntry) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AssignmentRule_Public_Class_ruleEntry_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyruleEntry);

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