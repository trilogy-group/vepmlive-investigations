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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.AutoResponseRules" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AutoResponseRulesTest : AbstractBaseSetupTypedTest<AutoResponseRules>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AutoResponseRules) Initializer

        private const string PropertyautoResponseRule = "autoResponseRule";
        private const string FieldautoResponseRuleField = "autoResponseRuleField";
        private Type _autoResponseRulesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AutoResponseRules _autoResponseRulesInstance;
        private AutoResponseRules _autoResponseRulesInstanceFixture;

        #region General Initializer : Class (AutoResponseRules) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AutoResponseRules" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _autoResponseRulesInstanceType = typeof(AutoResponseRules);
            _autoResponseRulesInstanceFixture = Create(true);
            _autoResponseRulesInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AutoResponseRules)

        #region General Initializer : Class (AutoResponseRules) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="AutoResponseRules" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyautoResponseRule)]
        public void AUT_AutoResponseRules_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_autoResponseRulesInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AutoResponseRules) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="AutoResponseRules" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldautoResponseRuleField)]
        public void AUT_AutoResponseRules_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_autoResponseRulesInstanceFixture, 
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
        ///     Class (<see cref="AutoResponseRules" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_AutoResponseRules_Is_Instance_Present_Test()
        {
            // Assert
            _autoResponseRulesInstanceType.ShouldNotBeNull();
            _autoResponseRulesInstance.ShouldNotBeNull();
            _autoResponseRulesInstanceFixture.ShouldNotBeNull();
            _autoResponseRulesInstance.ShouldBeAssignableTo<AutoResponseRules>();
            _autoResponseRulesInstanceFixture.ShouldBeAssignableTo<AutoResponseRules>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (AutoResponseRules) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_AutoResponseRules_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            AutoResponseRules instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _autoResponseRulesInstanceType.ShouldNotBeNull();
            _autoResponseRulesInstance.ShouldNotBeNull();
            _autoResponseRulesInstanceFixture.ShouldNotBeNull();
            _autoResponseRulesInstance.ShouldBeAssignableTo<AutoResponseRules>();
            _autoResponseRulesInstanceFixture.ShouldBeAssignableTo<AutoResponseRules>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (AutoResponseRules) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(AutoResponseRule[]) , PropertyautoResponseRule)]
        public void AUT_AutoResponseRules_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<AutoResponseRules, T>(_autoResponseRulesInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (AutoResponseRules) => Property (autoResponseRule) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AutoResponseRules_autoResponseRule_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyautoResponseRule);
            Action currentAction = () => propertyInfo.SetValue(_autoResponseRulesInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AutoResponseRules) => Property (autoResponseRule) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AutoResponseRules_Public_Class_autoResponseRule_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyautoResponseRule);

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