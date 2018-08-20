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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ContactCriteriaBasedSharingRule" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ContactCriteriaBasedSharingRuleTest : AbstractBaseSetupTypedTest<ContactCriteriaBasedSharingRule>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ContactCriteriaBasedSharingRule) Initializer

        private const string PropertybooleanFilter = "booleanFilter";
        private const string PropertycontactAccessLevel = "contactAccessLevel";
        private const string Propertyname = "name";
        private const string FieldbooleanFilterField = "booleanFilterField";
        private const string FieldcontactAccessLevelField = "contactAccessLevelField";
        private const string FieldnameField = "nameField";
        private Type _contactCriteriaBasedSharingRuleInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ContactCriteriaBasedSharingRule _contactCriteriaBasedSharingRuleInstance;
        private ContactCriteriaBasedSharingRule _contactCriteriaBasedSharingRuleInstanceFixture;

        #region General Initializer : Class (ContactCriteriaBasedSharingRule) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ContactCriteriaBasedSharingRule" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _contactCriteriaBasedSharingRuleInstanceType = typeof(ContactCriteriaBasedSharingRule);
            _contactCriteriaBasedSharingRuleInstanceFixture = Create(true);
            _contactCriteriaBasedSharingRuleInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ContactCriteriaBasedSharingRule)

        #region General Initializer : Class (ContactCriteriaBasedSharingRule) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ContactCriteriaBasedSharingRule" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertybooleanFilter)]
        [TestCase(PropertycontactAccessLevel)]
        [TestCase(Propertyname)]
        public void AUT_ContactCriteriaBasedSharingRule_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_contactCriteriaBasedSharingRuleInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ContactCriteriaBasedSharingRule) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ContactCriteriaBasedSharingRule" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldbooleanFilterField)]
        [TestCase(FieldcontactAccessLevelField)]
        [TestCase(FieldnameField)]
        public void AUT_ContactCriteriaBasedSharingRule_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_contactCriteriaBasedSharingRuleInstanceFixture, 
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
        ///     Class (<see cref="ContactCriteriaBasedSharingRule" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ContactCriteriaBasedSharingRule_Is_Instance_Present_Test()
        {
            // Assert
            _contactCriteriaBasedSharingRuleInstanceType.ShouldNotBeNull();
            _contactCriteriaBasedSharingRuleInstance.ShouldNotBeNull();
            _contactCriteriaBasedSharingRuleInstanceFixture.ShouldNotBeNull();
            _contactCriteriaBasedSharingRuleInstance.ShouldBeAssignableTo<ContactCriteriaBasedSharingRule>();
            _contactCriteriaBasedSharingRuleInstanceFixture.ShouldBeAssignableTo<ContactCriteriaBasedSharingRule>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ContactCriteriaBasedSharingRule) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ContactCriteriaBasedSharingRule_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ContactCriteriaBasedSharingRule instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _contactCriteriaBasedSharingRuleInstanceType.ShouldNotBeNull();
            _contactCriteriaBasedSharingRuleInstance.ShouldNotBeNull();
            _contactCriteriaBasedSharingRuleInstanceFixture.ShouldNotBeNull();
            _contactCriteriaBasedSharingRuleInstance.ShouldBeAssignableTo<ContactCriteriaBasedSharingRule>();
            _contactCriteriaBasedSharingRuleInstanceFixture.ShouldBeAssignableTo<ContactCriteriaBasedSharingRule>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ContactCriteriaBasedSharingRule) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertybooleanFilter)]
        [TestCaseGeneric(typeof(ShareAccessLevelReadEdit) , PropertycontactAccessLevel)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_ContactCriteriaBasedSharingRule_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ContactCriteriaBasedSharingRule, T>(_contactCriteriaBasedSharingRuleInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ContactCriteriaBasedSharingRule) => Property (booleanFilter) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ContactCriteriaBasedSharingRule_Public_Class_booleanFilter_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ContactCriteriaBasedSharingRule) => Property (contactAccessLevel) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ContactCriteriaBasedSharingRule_contactAccessLevel_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycontactAccessLevel);
            Action currentAction = () => propertyInfo.SetValue(_contactCriteriaBasedSharingRuleInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ContactCriteriaBasedSharingRule) => Property (contactAccessLevel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ContactCriteriaBasedSharingRule_Public_Class_contactAccessLevel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycontactAccessLevel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ContactCriteriaBasedSharingRule) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ContactCriteriaBasedSharingRule_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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