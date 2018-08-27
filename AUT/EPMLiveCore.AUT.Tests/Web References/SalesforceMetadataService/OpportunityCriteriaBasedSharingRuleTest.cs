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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.OpportunityCriteriaBasedSharingRule" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class OpportunityCriteriaBasedSharingRuleTest : AbstractBaseSetupTypedTest<OpportunityCriteriaBasedSharingRule>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (OpportunityCriteriaBasedSharingRule) Initializer

        private const string PropertybooleanFilter = "booleanFilter";
        private const string Propertyname = "name";
        private const string PropertyopportunityAccessLevel = "opportunityAccessLevel";
        private const string FieldbooleanFilterField = "booleanFilterField";
        private const string FieldnameField = "nameField";
        private const string FieldopportunityAccessLevelField = "opportunityAccessLevelField";
        private Type _opportunityCriteriaBasedSharingRuleInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private OpportunityCriteriaBasedSharingRule _opportunityCriteriaBasedSharingRuleInstance;
        private OpportunityCriteriaBasedSharingRule _opportunityCriteriaBasedSharingRuleInstanceFixture;

        #region General Initializer : Class (OpportunityCriteriaBasedSharingRule) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="OpportunityCriteriaBasedSharingRule" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _opportunityCriteriaBasedSharingRuleInstanceType = typeof(OpportunityCriteriaBasedSharingRule);
            _opportunityCriteriaBasedSharingRuleInstanceFixture = Create(true);
            _opportunityCriteriaBasedSharingRuleInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (OpportunityCriteriaBasedSharingRule)

        #region General Initializer : Class (OpportunityCriteriaBasedSharingRule) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="OpportunityCriteriaBasedSharingRule" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertybooleanFilter)]
        [TestCase(Propertyname)]
        [TestCase(PropertyopportunityAccessLevel)]
        public void AUT_OpportunityCriteriaBasedSharingRule_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_opportunityCriteriaBasedSharingRuleInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (OpportunityCriteriaBasedSharingRule) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="OpportunityCriteriaBasedSharingRule" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldbooleanFilterField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldopportunityAccessLevelField)]
        public void AUT_OpportunityCriteriaBasedSharingRule_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_opportunityCriteriaBasedSharingRuleInstanceFixture, 
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
        ///     Class (<see cref="OpportunityCriteriaBasedSharingRule" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_OpportunityCriteriaBasedSharingRule_Is_Instance_Present_Test()
        {
            // Assert
            _opportunityCriteriaBasedSharingRuleInstanceType.ShouldNotBeNull();
            _opportunityCriteriaBasedSharingRuleInstance.ShouldNotBeNull();
            _opportunityCriteriaBasedSharingRuleInstanceFixture.ShouldNotBeNull();
            _opportunityCriteriaBasedSharingRuleInstance.ShouldBeAssignableTo<OpportunityCriteriaBasedSharingRule>();
            _opportunityCriteriaBasedSharingRuleInstanceFixture.ShouldBeAssignableTo<OpportunityCriteriaBasedSharingRule>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (OpportunityCriteriaBasedSharingRule) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_OpportunityCriteriaBasedSharingRule_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            OpportunityCriteriaBasedSharingRule instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _opportunityCriteriaBasedSharingRuleInstanceType.ShouldNotBeNull();
            _opportunityCriteriaBasedSharingRuleInstance.ShouldNotBeNull();
            _opportunityCriteriaBasedSharingRuleInstanceFixture.ShouldNotBeNull();
            _opportunityCriteriaBasedSharingRuleInstance.ShouldBeAssignableTo<OpportunityCriteriaBasedSharingRule>();
            _opportunityCriteriaBasedSharingRuleInstanceFixture.ShouldBeAssignableTo<OpportunityCriteriaBasedSharingRule>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (OpportunityCriteriaBasedSharingRule) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertybooleanFilter)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(ShareAccessLevelReadEdit) , PropertyopportunityAccessLevel)]
        public void AUT_OpportunityCriteriaBasedSharingRule_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<OpportunityCriteriaBasedSharingRule, T>(_opportunityCriteriaBasedSharingRuleInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (OpportunityCriteriaBasedSharingRule) => Property (booleanFilter) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_OpportunityCriteriaBasedSharingRule_Public_Class_booleanFilter_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (OpportunityCriteriaBasedSharingRule) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_OpportunityCriteriaBasedSharingRule_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (OpportunityCriteriaBasedSharingRule) => Property (opportunityAccessLevel) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_OpportunityCriteriaBasedSharingRule_opportunityAccessLevel_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyopportunityAccessLevel);
            Action currentAction = () => propertyInfo.SetValue(_opportunityCriteriaBasedSharingRuleInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (OpportunityCriteriaBasedSharingRule) => Property (opportunityAccessLevel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_OpportunityCriteriaBasedSharingRule_Public_Class_opportunityAccessLevel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyopportunityAccessLevel);

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