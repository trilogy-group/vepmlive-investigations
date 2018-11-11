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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.AccountCriteriaBasedSharingRule" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AccountCriteriaBasedSharingRuleTest : AbstractBaseSetupTypedTest<AccountCriteriaBasedSharingRule>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AccountCriteriaBasedSharingRule) Initializer

        private const string PropertyaccountAccessLevel = "accountAccessLevel";
        private const string PropertybooleanFilter = "booleanFilter";
        private const string PropertycaseAccessLevel = "caseAccessLevel";
        private const string PropertycontactAccessLevel = "contactAccessLevel";
        private const string Propertyname = "name";
        private const string PropertyopportunityAccessLevel = "opportunityAccessLevel";
        private const string FieldaccountAccessLevelField = "accountAccessLevelField";
        private const string FieldbooleanFilterField = "booleanFilterField";
        private const string FieldcaseAccessLevelField = "caseAccessLevelField";
        private const string FieldcontactAccessLevelField = "contactAccessLevelField";
        private const string FieldnameField = "nameField";
        private const string FieldopportunityAccessLevelField = "opportunityAccessLevelField";
        private Type _accountCriteriaBasedSharingRuleInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AccountCriteriaBasedSharingRule _accountCriteriaBasedSharingRuleInstance;
        private AccountCriteriaBasedSharingRule _accountCriteriaBasedSharingRuleInstanceFixture;

        #region General Initializer : Class (AccountCriteriaBasedSharingRule) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AccountCriteriaBasedSharingRule" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _accountCriteriaBasedSharingRuleInstanceType = typeof(AccountCriteriaBasedSharingRule);
            _accountCriteriaBasedSharingRuleInstanceFixture = Create(true);
            _accountCriteriaBasedSharingRuleInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AccountCriteriaBasedSharingRule)

        #region General Initializer : Class (AccountCriteriaBasedSharingRule) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="AccountCriteriaBasedSharingRule" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyaccountAccessLevel)]
        [TestCase(PropertybooleanFilter)]
        [TestCase(PropertycaseAccessLevel)]
        [TestCase(PropertycontactAccessLevel)]
        [TestCase(Propertyname)]
        [TestCase(PropertyopportunityAccessLevel)]
        public void AUT_AccountCriteriaBasedSharingRule_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_accountCriteriaBasedSharingRuleInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AccountCriteriaBasedSharingRule) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="AccountCriteriaBasedSharingRule" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldaccountAccessLevelField)]
        [TestCase(FieldbooleanFilterField)]
        [TestCase(FieldcaseAccessLevelField)]
        [TestCase(FieldcontactAccessLevelField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldopportunityAccessLevelField)]
        public void AUT_AccountCriteriaBasedSharingRule_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_accountCriteriaBasedSharingRuleInstanceFixture, 
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
        ///     Class (<see cref="AccountCriteriaBasedSharingRule" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_AccountCriteriaBasedSharingRule_Is_Instance_Present_Test()
        {
            // Assert
            _accountCriteriaBasedSharingRuleInstanceType.ShouldNotBeNull();
            _accountCriteriaBasedSharingRuleInstance.ShouldNotBeNull();
            _accountCriteriaBasedSharingRuleInstanceFixture.ShouldNotBeNull();
            _accountCriteriaBasedSharingRuleInstance.ShouldBeAssignableTo<AccountCriteriaBasedSharingRule>();
            _accountCriteriaBasedSharingRuleInstanceFixture.ShouldBeAssignableTo<AccountCriteriaBasedSharingRule>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (AccountCriteriaBasedSharingRule) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_AccountCriteriaBasedSharingRule_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            AccountCriteriaBasedSharingRule instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _accountCriteriaBasedSharingRuleInstanceType.ShouldNotBeNull();
            _accountCriteriaBasedSharingRuleInstance.ShouldNotBeNull();
            _accountCriteriaBasedSharingRuleInstanceFixture.ShouldNotBeNull();
            _accountCriteriaBasedSharingRuleInstance.ShouldBeAssignableTo<AccountCriteriaBasedSharingRule>();
            _accountCriteriaBasedSharingRuleInstanceFixture.ShouldBeAssignableTo<AccountCriteriaBasedSharingRule>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (AccountCriteriaBasedSharingRule) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(ShareAccessLevelNoNone) , PropertyaccountAccessLevel)]
        [TestCaseGeneric(typeof(string) , PropertybooleanFilter)]
        [TestCaseGeneric(typeof(ShareAccessLevelNoAll) , PropertycaseAccessLevel)]
        [TestCaseGeneric(typeof(ShareAccessLevelNoAll) , PropertycontactAccessLevel)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(ShareAccessLevelNoAll) , PropertyopportunityAccessLevel)]
        public void AUT_AccountCriteriaBasedSharingRule_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<AccountCriteriaBasedSharingRule, T>(_accountCriteriaBasedSharingRuleInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (AccountCriteriaBasedSharingRule) => Property (accountAccessLevel) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AccountCriteriaBasedSharingRule_accountAccessLevel_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyaccountAccessLevel);
            Action currentAction = () => propertyInfo.SetValue(_accountCriteriaBasedSharingRuleInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AccountCriteriaBasedSharingRule) => Property (accountAccessLevel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AccountCriteriaBasedSharingRule_Public_Class_accountAccessLevel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyaccountAccessLevel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountCriteriaBasedSharingRule) => Property (booleanFilter) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AccountCriteriaBasedSharingRule_Public_Class_booleanFilter_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (AccountCriteriaBasedSharingRule) => Property (caseAccessLevel) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AccountCriteriaBasedSharingRule_caseAccessLevel_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycaseAccessLevel);
            Action currentAction = () => propertyInfo.SetValue(_accountCriteriaBasedSharingRuleInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AccountCriteriaBasedSharingRule) => Property (caseAccessLevel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AccountCriteriaBasedSharingRule_Public_Class_caseAccessLevel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (AccountCriteriaBasedSharingRule) => Property (contactAccessLevel) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AccountCriteriaBasedSharingRule_contactAccessLevel_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycontactAccessLevel);
            Action currentAction = () => propertyInfo.SetValue(_accountCriteriaBasedSharingRuleInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AccountCriteriaBasedSharingRule) => Property (contactAccessLevel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AccountCriteriaBasedSharingRule_Public_Class_contactAccessLevel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (AccountCriteriaBasedSharingRule) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AccountCriteriaBasedSharingRule_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (AccountCriteriaBasedSharingRule) => Property (opportunityAccessLevel) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AccountCriteriaBasedSharingRule_opportunityAccessLevel_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyopportunityAccessLevel);
            Action currentAction = () => propertyInfo.SetValue(_accountCriteriaBasedSharingRuleInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AccountCriteriaBasedSharingRule) => Property (opportunityAccessLevel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AccountCriteriaBasedSharingRule_Public_Class_opportunityAccessLevel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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