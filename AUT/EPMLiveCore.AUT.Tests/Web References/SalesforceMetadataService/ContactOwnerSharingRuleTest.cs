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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ContactOwnerSharingRule" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ContactOwnerSharingRuleTest : AbstractBaseSetupTypedTest<ContactOwnerSharingRule>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ContactOwnerSharingRule) Initializer

        private const string PropertycontactAccessLevel = "contactAccessLevel";
        private const string Propertyname = "name";
        private const string FieldcontactAccessLevelField = "contactAccessLevelField";
        private const string FieldnameField = "nameField";
        private Type _contactOwnerSharingRuleInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ContactOwnerSharingRule _contactOwnerSharingRuleInstance;
        private ContactOwnerSharingRule _contactOwnerSharingRuleInstanceFixture;

        #region General Initializer : Class (ContactOwnerSharingRule) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ContactOwnerSharingRule" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _contactOwnerSharingRuleInstanceType = typeof(ContactOwnerSharingRule);
            _contactOwnerSharingRuleInstanceFixture = Create(true);
            _contactOwnerSharingRuleInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ContactOwnerSharingRule)

        #region General Initializer : Class (ContactOwnerSharingRule) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ContactOwnerSharingRule" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycontactAccessLevel)]
        [TestCase(Propertyname)]
        public void AUT_ContactOwnerSharingRule_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_contactOwnerSharingRuleInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ContactOwnerSharingRule) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ContactOwnerSharingRule" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcontactAccessLevelField)]
        [TestCase(FieldnameField)]
        public void AUT_ContactOwnerSharingRule_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_contactOwnerSharingRuleInstanceFixture, 
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
        ///     Class (<see cref="ContactOwnerSharingRule" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ContactOwnerSharingRule_Is_Instance_Present_Test()
        {
            // Assert
            _contactOwnerSharingRuleInstanceType.ShouldNotBeNull();
            _contactOwnerSharingRuleInstance.ShouldNotBeNull();
            _contactOwnerSharingRuleInstanceFixture.ShouldNotBeNull();
            _contactOwnerSharingRuleInstance.ShouldBeAssignableTo<ContactOwnerSharingRule>();
            _contactOwnerSharingRuleInstanceFixture.ShouldBeAssignableTo<ContactOwnerSharingRule>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ContactOwnerSharingRule) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ContactOwnerSharingRule_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ContactOwnerSharingRule instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _contactOwnerSharingRuleInstanceType.ShouldNotBeNull();
            _contactOwnerSharingRuleInstance.ShouldNotBeNull();
            _contactOwnerSharingRuleInstanceFixture.ShouldNotBeNull();
            _contactOwnerSharingRuleInstance.ShouldBeAssignableTo<ContactOwnerSharingRule>();
            _contactOwnerSharingRuleInstanceFixture.ShouldBeAssignableTo<ContactOwnerSharingRule>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ContactOwnerSharingRule) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(ShareAccessLevelReadEdit) , PropertycontactAccessLevel)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_ContactOwnerSharingRule_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ContactOwnerSharingRule, T>(_contactOwnerSharingRuleInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ContactOwnerSharingRule) => Property (contactAccessLevel) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ContactOwnerSharingRule_contactAccessLevel_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycontactAccessLevel);
            Action currentAction = () => propertyInfo.SetValue(_contactOwnerSharingRuleInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ContactOwnerSharingRule) => Property (contactAccessLevel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ContactOwnerSharingRule_Public_Class_contactAccessLevel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ContactOwnerSharingRule) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ContactOwnerSharingRule_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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