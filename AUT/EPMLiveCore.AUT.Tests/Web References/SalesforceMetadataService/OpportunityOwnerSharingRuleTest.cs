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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.OpportunityOwnerSharingRule" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class OpportunityOwnerSharingRuleTest : AbstractBaseSetupTypedTest<OpportunityOwnerSharingRule>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (OpportunityOwnerSharingRule) Initializer

        private const string Propertyname = "name";
        private const string PropertyopportunityAccessLevel = "opportunityAccessLevel";
        private const string FieldnameField = "nameField";
        private const string FieldopportunityAccessLevelField = "opportunityAccessLevelField";
        private Type _opportunityOwnerSharingRuleInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private OpportunityOwnerSharingRule _opportunityOwnerSharingRuleInstance;
        private OpportunityOwnerSharingRule _opportunityOwnerSharingRuleInstanceFixture;

        #region General Initializer : Class (OpportunityOwnerSharingRule) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="OpportunityOwnerSharingRule" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _opportunityOwnerSharingRuleInstanceType = typeof(OpportunityOwnerSharingRule);
            _opportunityOwnerSharingRuleInstanceFixture = Create(true);
            _opportunityOwnerSharingRuleInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (OpportunityOwnerSharingRule)

        #region General Initializer : Class (OpportunityOwnerSharingRule) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="OpportunityOwnerSharingRule" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyname)]
        [TestCase(PropertyopportunityAccessLevel)]
        public void AUT_OpportunityOwnerSharingRule_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_opportunityOwnerSharingRuleInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (OpportunityOwnerSharingRule) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="OpportunityOwnerSharingRule" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldnameField)]
        [TestCase(FieldopportunityAccessLevelField)]
        public void AUT_OpportunityOwnerSharingRule_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_opportunityOwnerSharingRuleInstanceFixture, 
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
        ///     Class (<see cref="OpportunityOwnerSharingRule" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_OpportunityOwnerSharingRule_Is_Instance_Present_Test()
        {
            // Assert
            _opportunityOwnerSharingRuleInstanceType.ShouldNotBeNull();
            _opportunityOwnerSharingRuleInstance.ShouldNotBeNull();
            _opportunityOwnerSharingRuleInstanceFixture.ShouldNotBeNull();
            _opportunityOwnerSharingRuleInstance.ShouldBeAssignableTo<OpportunityOwnerSharingRule>();
            _opportunityOwnerSharingRuleInstanceFixture.ShouldBeAssignableTo<OpportunityOwnerSharingRule>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (OpportunityOwnerSharingRule) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_OpportunityOwnerSharingRule_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            OpportunityOwnerSharingRule instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _opportunityOwnerSharingRuleInstanceType.ShouldNotBeNull();
            _opportunityOwnerSharingRuleInstance.ShouldNotBeNull();
            _opportunityOwnerSharingRuleInstanceFixture.ShouldNotBeNull();
            _opportunityOwnerSharingRuleInstance.ShouldBeAssignableTo<OpportunityOwnerSharingRule>();
            _opportunityOwnerSharingRuleInstanceFixture.ShouldBeAssignableTo<OpportunityOwnerSharingRule>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (OpportunityOwnerSharingRule) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(ShareAccessLevelReadEdit) , PropertyopportunityAccessLevel)]
        public void AUT_OpportunityOwnerSharingRule_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<OpportunityOwnerSharingRule, T>(_opportunityOwnerSharingRuleInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (OpportunityOwnerSharingRule) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_OpportunityOwnerSharingRule_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (OpportunityOwnerSharingRule) => Property (opportunityAccessLevel) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_OpportunityOwnerSharingRule_opportunityAccessLevel_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyopportunityAccessLevel);
            Action currentAction = () => propertyInfo.SetValue(_opportunityOwnerSharingRuleInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (OpportunityOwnerSharingRule) => Property (opportunityAccessLevel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_OpportunityOwnerSharingRule_Public_Class_opportunityAccessLevel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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