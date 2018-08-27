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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.CampaignOwnerSharingRule" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CampaignOwnerSharingRuleTest : AbstractBaseSetupTypedTest<CampaignOwnerSharingRule>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CampaignOwnerSharingRule) Initializer

        private const string PropertycampaignAccessLevel = "campaignAccessLevel";
        private const string Propertyname = "name";
        private const string FieldcampaignAccessLevelField = "campaignAccessLevelField";
        private const string FieldnameField = "nameField";
        private Type _campaignOwnerSharingRuleInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CampaignOwnerSharingRule _campaignOwnerSharingRuleInstance;
        private CampaignOwnerSharingRule _campaignOwnerSharingRuleInstanceFixture;

        #region General Initializer : Class (CampaignOwnerSharingRule) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CampaignOwnerSharingRule" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _campaignOwnerSharingRuleInstanceType = typeof(CampaignOwnerSharingRule);
            _campaignOwnerSharingRuleInstanceFixture = Create(true);
            _campaignOwnerSharingRuleInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CampaignOwnerSharingRule)

        #region General Initializer : Class (CampaignOwnerSharingRule) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CampaignOwnerSharingRule" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycampaignAccessLevel)]
        [TestCase(Propertyname)]
        public void AUT_CampaignOwnerSharingRule_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_campaignOwnerSharingRuleInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CampaignOwnerSharingRule) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CampaignOwnerSharingRule" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcampaignAccessLevelField)]
        [TestCase(FieldnameField)]
        public void AUT_CampaignOwnerSharingRule_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_campaignOwnerSharingRuleInstanceFixture, 
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
        ///     Class (<see cref="CampaignOwnerSharingRule" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CampaignOwnerSharingRule_Is_Instance_Present_Test()
        {
            // Assert
            _campaignOwnerSharingRuleInstanceType.ShouldNotBeNull();
            _campaignOwnerSharingRuleInstance.ShouldNotBeNull();
            _campaignOwnerSharingRuleInstanceFixture.ShouldNotBeNull();
            _campaignOwnerSharingRuleInstance.ShouldBeAssignableTo<CampaignOwnerSharingRule>();
            _campaignOwnerSharingRuleInstanceFixture.ShouldBeAssignableTo<CampaignOwnerSharingRule>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CampaignOwnerSharingRule) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CampaignOwnerSharingRule_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CampaignOwnerSharingRule instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _campaignOwnerSharingRuleInstanceType.ShouldNotBeNull();
            _campaignOwnerSharingRuleInstance.ShouldNotBeNull();
            _campaignOwnerSharingRuleInstanceFixture.ShouldNotBeNull();
            _campaignOwnerSharingRuleInstance.ShouldBeAssignableTo<CampaignOwnerSharingRule>();
            _campaignOwnerSharingRuleInstanceFixture.ShouldBeAssignableTo<CampaignOwnerSharingRule>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CampaignOwnerSharingRule) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(ShareAccessLevelNoNone) , PropertycampaignAccessLevel)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_CampaignOwnerSharingRule_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CampaignOwnerSharingRule, T>(_campaignOwnerSharingRuleInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CampaignOwnerSharingRule) => Property (campaignAccessLevel) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CampaignOwnerSharingRule_campaignAccessLevel_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycampaignAccessLevel);
            Action currentAction = () => propertyInfo.SetValue(_campaignOwnerSharingRuleInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CampaignOwnerSharingRule) => Property (campaignAccessLevel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CampaignOwnerSharingRule_Public_Class_campaignAccessLevel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycampaignAccessLevel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CampaignOwnerSharingRule) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CampaignOwnerSharingRule_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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