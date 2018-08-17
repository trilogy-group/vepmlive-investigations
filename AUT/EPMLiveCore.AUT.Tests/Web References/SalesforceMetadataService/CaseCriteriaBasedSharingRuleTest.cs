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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.CaseCriteriaBasedSharingRule" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CaseCriteriaBasedSharingRuleTest : AbstractBaseSetupTypedTest<CaseCriteriaBasedSharingRule>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CaseCriteriaBasedSharingRule) Initializer

        private const string PropertybooleanFilter = "booleanFilter";
        private const string PropertycaseAccessLevel = "caseAccessLevel";
        private const string Propertyname = "name";
        private const string FieldbooleanFilterField = "booleanFilterField";
        private const string FieldcaseAccessLevelField = "caseAccessLevelField";
        private const string FieldnameField = "nameField";
        private Type _caseCriteriaBasedSharingRuleInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CaseCriteriaBasedSharingRule _caseCriteriaBasedSharingRuleInstance;
        private CaseCriteriaBasedSharingRule _caseCriteriaBasedSharingRuleInstanceFixture;

        #region General Initializer : Class (CaseCriteriaBasedSharingRule) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CaseCriteriaBasedSharingRule" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _caseCriteriaBasedSharingRuleInstanceType = typeof(CaseCriteriaBasedSharingRule);
            _caseCriteriaBasedSharingRuleInstanceFixture = Create(true);
            _caseCriteriaBasedSharingRuleInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CaseCriteriaBasedSharingRule)

        #region General Initializer : Class (CaseCriteriaBasedSharingRule) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CaseCriteriaBasedSharingRule" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertybooleanFilter)]
        [TestCase(PropertycaseAccessLevel)]
        [TestCase(Propertyname)]
        public void AUT_CaseCriteriaBasedSharingRule_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_caseCriteriaBasedSharingRuleInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CaseCriteriaBasedSharingRule) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CaseCriteriaBasedSharingRule" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldbooleanFilterField)]
        [TestCase(FieldcaseAccessLevelField)]
        [TestCase(FieldnameField)]
        public void AUT_CaseCriteriaBasedSharingRule_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_caseCriteriaBasedSharingRuleInstanceFixture, 
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
        ///     Class (<see cref="CaseCriteriaBasedSharingRule" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CaseCriteriaBasedSharingRule_Is_Instance_Present_Test()
        {
            // Assert
            _caseCriteriaBasedSharingRuleInstanceType.ShouldNotBeNull();
            _caseCriteriaBasedSharingRuleInstance.ShouldNotBeNull();
            _caseCriteriaBasedSharingRuleInstanceFixture.ShouldNotBeNull();
            _caseCriteriaBasedSharingRuleInstance.ShouldBeAssignableTo<CaseCriteriaBasedSharingRule>();
            _caseCriteriaBasedSharingRuleInstanceFixture.ShouldBeAssignableTo<CaseCriteriaBasedSharingRule>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CaseCriteriaBasedSharingRule) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CaseCriteriaBasedSharingRule_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CaseCriteriaBasedSharingRule instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _caseCriteriaBasedSharingRuleInstanceType.ShouldNotBeNull();
            _caseCriteriaBasedSharingRuleInstance.ShouldNotBeNull();
            _caseCriteriaBasedSharingRuleInstanceFixture.ShouldNotBeNull();
            _caseCriteriaBasedSharingRuleInstance.ShouldBeAssignableTo<CaseCriteriaBasedSharingRule>();
            _caseCriteriaBasedSharingRuleInstanceFixture.ShouldBeAssignableTo<CaseCriteriaBasedSharingRule>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CaseCriteriaBasedSharingRule) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertybooleanFilter)]
        [TestCaseGeneric(typeof(ShareAccessLevelReadEdit) , PropertycaseAccessLevel)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_CaseCriteriaBasedSharingRule_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CaseCriteriaBasedSharingRule, T>(_caseCriteriaBasedSharingRuleInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CaseCriteriaBasedSharingRule) => Property (booleanFilter) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseCriteriaBasedSharingRule_Public_Class_booleanFilter_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CaseCriteriaBasedSharingRule) => Property (caseAccessLevel) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseCriteriaBasedSharingRule_caseAccessLevel_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycaseAccessLevel);
            Action currentAction = () => propertyInfo.SetValue(_caseCriteriaBasedSharingRuleInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CaseCriteriaBasedSharingRule) => Property (caseAccessLevel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseCriteriaBasedSharingRule_Public_Class_caseAccessLevel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycaseAccessLevel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseCriteriaBasedSharingRule) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseCriteriaBasedSharingRule_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyname);

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