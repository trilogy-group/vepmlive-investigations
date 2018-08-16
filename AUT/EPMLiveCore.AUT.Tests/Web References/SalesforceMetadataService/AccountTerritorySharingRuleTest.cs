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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.AccountTerritorySharingRule" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AccountTerritorySharingRuleTest : AbstractBaseSetupTypedTest<AccountTerritorySharingRule>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AccountTerritorySharingRule) Initializer

        private const string PropertyaccountAccessLevel = "accountAccessLevel";
        private const string PropertycaseAccessLevel = "caseAccessLevel";
        private const string PropertycontactAccessLevel = "contactAccessLevel";
        private const string Propertyname = "name";
        private const string PropertyopportunityAccessLevel = "opportunityAccessLevel";
        private const string FieldaccountAccessLevelField = "accountAccessLevelField";
        private const string FieldcaseAccessLevelField = "caseAccessLevelField";
        private const string FieldcontactAccessLevelField = "contactAccessLevelField";
        private const string FieldnameField = "nameField";
        private const string FieldopportunityAccessLevelField = "opportunityAccessLevelField";
        private Type _accountTerritorySharingRuleInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AccountTerritorySharingRule _accountTerritorySharingRuleInstance;
        private AccountTerritorySharingRule _accountTerritorySharingRuleInstanceFixture;

        #region General Initializer : Class (AccountTerritorySharingRule) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AccountTerritorySharingRule" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _accountTerritorySharingRuleInstanceType = typeof(AccountTerritorySharingRule);
            _accountTerritorySharingRuleInstanceFixture = Create(true);
            _accountTerritorySharingRuleInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AccountTerritorySharingRule)

        #region General Initializer : Class (AccountTerritorySharingRule) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="AccountTerritorySharingRule" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyaccountAccessLevel)]
        [TestCase(PropertycaseAccessLevel)]
        [TestCase(PropertycontactAccessLevel)]
        [TestCase(Propertyname)]
        [TestCase(PropertyopportunityAccessLevel)]
        public void AUT_AccountTerritorySharingRule_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_accountTerritorySharingRuleInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AccountTerritorySharingRule) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="AccountTerritorySharingRule" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldaccountAccessLevelField)]
        [TestCase(FieldcaseAccessLevelField)]
        [TestCase(FieldcontactAccessLevelField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldopportunityAccessLevelField)]
        public void AUT_AccountTerritorySharingRule_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_accountTerritorySharingRuleInstanceFixture, 
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
        ///     Class (<see cref="AccountTerritorySharingRule" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_AccountTerritorySharingRule_Is_Instance_Present_Test()
        {
            // Assert
            _accountTerritorySharingRuleInstanceType.ShouldNotBeNull();
            _accountTerritorySharingRuleInstance.ShouldNotBeNull();
            _accountTerritorySharingRuleInstanceFixture.ShouldNotBeNull();
            _accountTerritorySharingRuleInstance.ShouldBeAssignableTo<AccountTerritorySharingRule>();
            _accountTerritorySharingRuleInstanceFixture.ShouldBeAssignableTo<AccountTerritorySharingRule>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (AccountTerritorySharingRule) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_AccountTerritorySharingRule_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            AccountTerritorySharingRule instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _accountTerritorySharingRuleInstanceType.ShouldNotBeNull();
            _accountTerritorySharingRuleInstance.ShouldNotBeNull();
            _accountTerritorySharingRuleInstanceFixture.ShouldNotBeNull();
            _accountTerritorySharingRuleInstance.ShouldBeAssignableTo<AccountTerritorySharingRule>();
            _accountTerritorySharingRuleInstanceFixture.ShouldBeAssignableTo<AccountTerritorySharingRule>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (AccountTerritorySharingRule) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(ShareAccessLevelNoNone) , PropertyaccountAccessLevel)]
        [TestCaseGeneric(typeof(ShareAccessLevelNoAll) , PropertycaseAccessLevel)]
        [TestCaseGeneric(typeof(ShareAccessLevelNoAll) , PropertycontactAccessLevel)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(ShareAccessLevelNoAll) , PropertyopportunityAccessLevel)]
        public void AUT_AccountTerritorySharingRule_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<AccountTerritorySharingRule, T>(_accountTerritorySharingRuleInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (AccountTerritorySharingRule) => Property (accountAccessLevel) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AccountTerritorySharingRule_accountAccessLevel_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyaccountAccessLevel);
            Action currentAction = () => propertyInfo.SetValue(_accountTerritorySharingRuleInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AccountTerritorySharingRule) => Property (accountAccessLevel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AccountTerritorySharingRule_Public_Class_accountAccessLevel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (AccountTerritorySharingRule) => Property (caseAccessLevel) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AccountTerritorySharingRule_caseAccessLevel_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycaseAccessLevel);
            Action currentAction = () => propertyInfo.SetValue(_accountTerritorySharingRuleInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AccountTerritorySharingRule) => Property (caseAccessLevel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AccountTerritorySharingRule_Public_Class_caseAccessLevel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (AccountTerritorySharingRule) => Property (contactAccessLevel) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AccountTerritorySharingRule_contactAccessLevel_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycontactAccessLevel);
            Action currentAction = () => propertyInfo.SetValue(_accountTerritorySharingRuleInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AccountTerritorySharingRule) => Property (contactAccessLevel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AccountTerritorySharingRule_Public_Class_contactAccessLevel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (AccountTerritorySharingRule) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AccountTerritorySharingRule_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (AccountTerritorySharingRule) => Property (opportunityAccessLevel) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AccountTerritorySharingRule_opportunityAccessLevel_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyopportunityAccessLevel);
            Action currentAction = () => propertyInfo.SetValue(_accountTerritorySharingRuleInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AccountTerritorySharingRule) => Property (opportunityAccessLevel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AccountTerritorySharingRule_Public_Class_opportunityAccessLevel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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