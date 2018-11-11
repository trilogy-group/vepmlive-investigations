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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.LeadCriteriaBasedSharingRule" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class LeadCriteriaBasedSharingRuleTest : AbstractBaseSetupTypedTest<LeadCriteriaBasedSharingRule>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (LeadCriteriaBasedSharingRule) Initializer

        private const string PropertybooleanFilter = "booleanFilter";
        private const string PropertyleadAccessLevel = "leadAccessLevel";
        private const string Propertyname = "name";
        private const string FieldbooleanFilterField = "booleanFilterField";
        private const string FieldleadAccessLevelField = "leadAccessLevelField";
        private const string FieldnameField = "nameField";
        private Type _leadCriteriaBasedSharingRuleInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private LeadCriteriaBasedSharingRule _leadCriteriaBasedSharingRuleInstance;
        private LeadCriteriaBasedSharingRule _leadCriteriaBasedSharingRuleInstanceFixture;

        #region General Initializer : Class (LeadCriteriaBasedSharingRule) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="LeadCriteriaBasedSharingRule" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _leadCriteriaBasedSharingRuleInstanceType = typeof(LeadCriteriaBasedSharingRule);
            _leadCriteriaBasedSharingRuleInstanceFixture = Create(true);
            _leadCriteriaBasedSharingRuleInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (LeadCriteriaBasedSharingRule)

        #region General Initializer : Class (LeadCriteriaBasedSharingRule) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="LeadCriteriaBasedSharingRule" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertybooleanFilter)]
        [TestCase(PropertyleadAccessLevel)]
        [TestCase(Propertyname)]
        public void AUT_LeadCriteriaBasedSharingRule_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_leadCriteriaBasedSharingRuleInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (LeadCriteriaBasedSharingRule) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="LeadCriteriaBasedSharingRule" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldbooleanFilterField)]
        [TestCase(FieldleadAccessLevelField)]
        [TestCase(FieldnameField)]
        public void AUT_LeadCriteriaBasedSharingRule_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_leadCriteriaBasedSharingRuleInstanceFixture, 
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
        ///     Class (<see cref="LeadCriteriaBasedSharingRule" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_LeadCriteriaBasedSharingRule_Is_Instance_Present_Test()
        {
            // Assert
            _leadCriteriaBasedSharingRuleInstanceType.ShouldNotBeNull();
            _leadCriteriaBasedSharingRuleInstance.ShouldNotBeNull();
            _leadCriteriaBasedSharingRuleInstanceFixture.ShouldNotBeNull();
            _leadCriteriaBasedSharingRuleInstance.ShouldBeAssignableTo<LeadCriteriaBasedSharingRule>();
            _leadCriteriaBasedSharingRuleInstanceFixture.ShouldBeAssignableTo<LeadCriteriaBasedSharingRule>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (LeadCriteriaBasedSharingRule) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_LeadCriteriaBasedSharingRule_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            LeadCriteriaBasedSharingRule instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _leadCriteriaBasedSharingRuleInstanceType.ShouldNotBeNull();
            _leadCriteriaBasedSharingRuleInstance.ShouldNotBeNull();
            _leadCriteriaBasedSharingRuleInstanceFixture.ShouldNotBeNull();
            _leadCriteriaBasedSharingRuleInstance.ShouldBeAssignableTo<LeadCriteriaBasedSharingRule>();
            _leadCriteriaBasedSharingRuleInstanceFixture.ShouldBeAssignableTo<LeadCriteriaBasedSharingRule>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (LeadCriteriaBasedSharingRule) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertybooleanFilter)]
        [TestCaseGeneric(typeof(ShareAccessLevelReadEdit) , PropertyleadAccessLevel)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_LeadCriteriaBasedSharingRule_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<LeadCriteriaBasedSharingRule, T>(_leadCriteriaBasedSharingRuleInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (LeadCriteriaBasedSharingRule) => Property (booleanFilter) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LeadCriteriaBasedSharingRule_Public_Class_booleanFilter_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (LeadCriteriaBasedSharingRule) => Property (leadAccessLevel) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LeadCriteriaBasedSharingRule_leadAccessLevel_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyleadAccessLevel);
            Action currentAction = () => propertyInfo.SetValue(_leadCriteriaBasedSharingRuleInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (LeadCriteriaBasedSharingRule) => Property (leadAccessLevel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LeadCriteriaBasedSharingRule_Public_Class_leadAccessLevel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyleadAccessLevel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LeadCriteriaBasedSharingRule) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LeadCriteriaBasedSharingRule_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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