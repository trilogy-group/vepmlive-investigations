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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.EscalationRules" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class EscalationRulesTest : AbstractBaseSetupTypedTest<EscalationRules>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EscalationRules) Initializer

        private const string PropertyescalationRule = "escalationRule";
        private const string FieldescalationRuleField = "escalationRuleField";
        private Type _escalationRulesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EscalationRules _escalationRulesInstance;
        private EscalationRules _escalationRulesInstanceFixture;

        #region General Initializer : Class (EscalationRules) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EscalationRules" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _escalationRulesInstanceType = typeof(EscalationRules);
            _escalationRulesInstanceFixture = Create(true);
            _escalationRulesInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EscalationRules)

        #region General Initializer : Class (EscalationRules) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="EscalationRules" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyescalationRule)]
        public void AUT_EscalationRules_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_escalationRulesInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EscalationRules) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EscalationRules" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldescalationRuleField)]
        public void AUT_EscalationRules_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_escalationRulesInstanceFixture, 
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
        ///     Class (<see cref="EscalationRules" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_EscalationRules_Is_Instance_Present_Test()
        {
            // Assert
            _escalationRulesInstanceType.ShouldNotBeNull();
            _escalationRulesInstance.ShouldNotBeNull();
            _escalationRulesInstanceFixture.ShouldNotBeNull();
            _escalationRulesInstance.ShouldBeAssignableTo<EscalationRules>();
            _escalationRulesInstanceFixture.ShouldBeAssignableTo<EscalationRules>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EscalationRules) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_EscalationRules_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EscalationRules instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _escalationRulesInstanceType.ShouldNotBeNull();
            _escalationRulesInstance.ShouldNotBeNull();
            _escalationRulesInstanceFixture.ShouldNotBeNull();
            _escalationRulesInstance.ShouldBeAssignableTo<EscalationRules>();
            _escalationRulesInstanceFixture.ShouldBeAssignableTo<EscalationRules>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (EscalationRules) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(EscalationRule[]) , PropertyescalationRule)]
        public void AUT_EscalationRules_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<EscalationRules, T>(_escalationRulesInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (EscalationRules) => Property (escalationRule) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EscalationRules_escalationRule_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyescalationRule);
            Action currentAction = () => propertyInfo.SetValue(_escalationRulesInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EscalationRules) => Property (escalationRule) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EscalationRules_Public_Class_escalationRule_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyescalationRule);

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