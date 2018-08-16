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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.AccountTerritorySharingRules" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AccountTerritorySharingRulesTest : AbstractBaseSetupTypedTest<AccountTerritorySharingRules>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AccountTerritorySharingRules) Initializer

        private const string Propertyrules = "rules";
        private const string FieldrulesField = "rulesField";
        private Type _accountTerritorySharingRulesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AccountTerritorySharingRules _accountTerritorySharingRulesInstance;
        private AccountTerritorySharingRules _accountTerritorySharingRulesInstanceFixture;

        #region General Initializer : Class (AccountTerritorySharingRules) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AccountTerritorySharingRules" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _accountTerritorySharingRulesInstanceType = typeof(AccountTerritorySharingRules);
            _accountTerritorySharingRulesInstanceFixture = Create(true);
            _accountTerritorySharingRulesInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AccountTerritorySharingRules)

        #region General Initializer : Class (AccountTerritorySharingRules) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="AccountTerritorySharingRules" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyrules)]
        public void AUT_AccountTerritorySharingRules_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_accountTerritorySharingRulesInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AccountTerritorySharingRules) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="AccountTerritorySharingRules" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldrulesField)]
        public void AUT_AccountTerritorySharingRules_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_accountTerritorySharingRulesInstanceFixture, 
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
        ///     Class (<see cref="AccountTerritorySharingRules" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_AccountTerritorySharingRules_Is_Instance_Present_Test()
        {
            // Assert
            _accountTerritorySharingRulesInstanceType.ShouldNotBeNull();
            _accountTerritorySharingRulesInstance.ShouldNotBeNull();
            _accountTerritorySharingRulesInstanceFixture.ShouldNotBeNull();
            _accountTerritorySharingRulesInstance.ShouldBeAssignableTo<AccountTerritorySharingRules>();
            _accountTerritorySharingRulesInstanceFixture.ShouldBeAssignableTo<AccountTerritorySharingRules>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (AccountTerritorySharingRules) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_AccountTerritorySharingRules_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            AccountTerritorySharingRules instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _accountTerritorySharingRulesInstanceType.ShouldNotBeNull();
            _accountTerritorySharingRulesInstance.ShouldNotBeNull();
            _accountTerritorySharingRulesInstanceFixture.ShouldNotBeNull();
            _accountTerritorySharingRulesInstance.ShouldBeAssignableTo<AccountTerritorySharingRules>();
            _accountTerritorySharingRulesInstanceFixture.ShouldBeAssignableTo<AccountTerritorySharingRules>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (AccountTerritorySharingRules) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(AccountTerritorySharingRule[]) , Propertyrules)]
        public void AUT_AccountTerritorySharingRules_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<AccountTerritorySharingRules, T>(_accountTerritorySharingRulesInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (AccountTerritorySharingRules) => Property (rules) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AccountTerritorySharingRules_rules_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyrules);
            Action currentAction = () => propertyInfo.SetValue(_accountTerritorySharingRulesInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AccountTerritorySharingRules) => Property (rules) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AccountTerritorySharingRules_Public_Class_rules_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyrules);

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