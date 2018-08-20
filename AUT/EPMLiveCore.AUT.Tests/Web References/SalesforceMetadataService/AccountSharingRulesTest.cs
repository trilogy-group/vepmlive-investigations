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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.AccountSharingRules" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AccountSharingRulesTest : AbstractBaseSetupTypedTest<AccountSharingRules>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AccountSharingRules) Initializer

        private const string PropertycriteriaBasedRules = "criteriaBasedRules";
        private const string PropertyownerRules = "ownerRules";
        private const string FieldcriteriaBasedRulesField = "criteriaBasedRulesField";
        private const string FieldownerRulesField = "ownerRulesField";
        private Type _accountSharingRulesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AccountSharingRules _accountSharingRulesInstance;
        private AccountSharingRules _accountSharingRulesInstanceFixture;

        #region General Initializer : Class (AccountSharingRules) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AccountSharingRules" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _accountSharingRulesInstanceType = typeof(AccountSharingRules);
            _accountSharingRulesInstanceFixture = Create(true);
            _accountSharingRulesInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AccountSharingRules)

        #region General Initializer : Class (AccountSharingRules) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="AccountSharingRules" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycriteriaBasedRules)]
        [TestCase(PropertyownerRules)]
        public void AUT_AccountSharingRules_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_accountSharingRulesInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AccountSharingRules) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="AccountSharingRules" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcriteriaBasedRulesField)]
        [TestCase(FieldownerRulesField)]
        public void AUT_AccountSharingRules_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_accountSharingRulesInstanceFixture, 
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
        ///     Class (<see cref="AccountSharingRules" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_AccountSharingRules_Is_Instance_Present_Test()
        {
            // Assert
            _accountSharingRulesInstanceType.ShouldNotBeNull();
            _accountSharingRulesInstance.ShouldNotBeNull();
            _accountSharingRulesInstanceFixture.ShouldNotBeNull();
            _accountSharingRulesInstance.ShouldBeAssignableTo<AccountSharingRules>();
            _accountSharingRulesInstanceFixture.ShouldBeAssignableTo<AccountSharingRules>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (AccountSharingRules) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_AccountSharingRules_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            AccountSharingRules instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _accountSharingRulesInstanceType.ShouldNotBeNull();
            _accountSharingRulesInstance.ShouldNotBeNull();
            _accountSharingRulesInstanceFixture.ShouldNotBeNull();
            _accountSharingRulesInstance.ShouldBeAssignableTo<AccountSharingRules>();
            _accountSharingRulesInstanceFixture.ShouldBeAssignableTo<AccountSharingRules>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (AccountSharingRules) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(AccountCriteriaBasedSharingRule[]) , PropertycriteriaBasedRules)]
        [TestCaseGeneric(typeof(AccountOwnerSharingRule[]) , PropertyownerRules)]
        public void AUT_AccountSharingRules_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<AccountSharingRules, T>(_accountSharingRulesInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (AccountSharingRules) => Property (criteriaBasedRules) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AccountSharingRules_criteriaBasedRules_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycriteriaBasedRules);
            Action currentAction = () => propertyInfo.SetValue(_accountSharingRulesInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AccountSharingRules) => Property (criteriaBasedRules) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AccountSharingRules_Public_Class_criteriaBasedRules_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycriteriaBasedRules);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountSharingRules) => Property (ownerRules) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AccountSharingRules_ownerRules_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyownerRules);
            Action currentAction = () => propertyInfo.SetValue(_accountSharingRulesInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AccountSharingRules) => Property (ownerRules) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AccountSharingRules_Public_Class_ownerRules_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyownerRules);

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