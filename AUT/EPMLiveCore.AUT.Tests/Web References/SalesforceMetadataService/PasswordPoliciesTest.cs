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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.PasswordPolicies" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class PasswordPoliciesTest : AbstractBaseSetupTypedTest<PasswordPolicies>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PasswordPolicies) Initializer

        private const string PropertyapiOnlyUserHomePageURL = "apiOnlyUserHomePageURL";
        private const string Propertycomplexity = "complexity";
        private const string PropertycomplexitySpecified = "complexitySpecified";
        private const string Propertyexpiration = "expiration";
        private const string PropertyexpirationSpecified = "expirationSpecified";
        private const string PropertyhistoryRestriction = "historyRestriction";
        private const string PropertylockoutInterval = "lockoutInterval";
        private const string PropertylockoutIntervalSpecified = "lockoutIntervalSpecified";
        private const string PropertymaxLoginAttempts = "maxLoginAttempts";
        private const string PropertymaxLoginAttemptsSpecified = "maxLoginAttemptsSpecified";
        private const string PropertyminPasswordLength = "minPasswordLength";
        private const string PropertyminPasswordLengthSpecified = "minPasswordLengthSpecified";
        private const string PropertypasswordAssistanceMessage = "passwordAssistanceMessage";
        private const string PropertypasswordAssistanceURL = "passwordAssistanceURL";
        private const string PropertyquestionRestriction = "questionRestriction";
        private const string PropertyquestionRestrictionSpecified = "questionRestrictionSpecified";
        private const string FieldapiOnlyUserHomePageURLField = "apiOnlyUserHomePageURLField";
        private const string FieldcomplexityField = "complexityField";
        private const string FieldcomplexityFieldSpecified = "complexityFieldSpecified";
        private const string FieldexpirationField = "expirationField";
        private const string FieldexpirationFieldSpecified = "expirationFieldSpecified";
        private const string FieldhistoryRestrictionField = "historyRestrictionField";
        private const string FieldlockoutIntervalField = "lockoutIntervalField";
        private const string FieldlockoutIntervalFieldSpecified = "lockoutIntervalFieldSpecified";
        private const string FieldmaxLoginAttemptsField = "maxLoginAttemptsField";
        private const string FieldmaxLoginAttemptsFieldSpecified = "maxLoginAttemptsFieldSpecified";
        private const string FieldminPasswordLengthField = "minPasswordLengthField";
        private const string FieldminPasswordLengthFieldSpecified = "minPasswordLengthFieldSpecified";
        private const string FieldpasswordAssistanceMessageField = "passwordAssistanceMessageField";
        private const string FieldpasswordAssistanceURLField = "passwordAssistanceURLField";
        private const string FieldquestionRestrictionField = "questionRestrictionField";
        private const string FieldquestionRestrictionFieldSpecified = "questionRestrictionFieldSpecified";
        private Type _passwordPoliciesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PasswordPolicies _passwordPoliciesInstance;
        private PasswordPolicies _passwordPoliciesInstanceFixture;

        #region General Initializer : Class (PasswordPolicies) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PasswordPolicies" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _passwordPoliciesInstanceType = typeof(PasswordPolicies);
            _passwordPoliciesInstanceFixture = Create(true);
            _passwordPoliciesInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PasswordPolicies)

        #region General Initializer : Class (PasswordPolicies) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="PasswordPolicies" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyapiOnlyUserHomePageURL)]
        [TestCase(Propertycomplexity)]
        [TestCase(PropertycomplexitySpecified)]
        [TestCase(Propertyexpiration)]
        [TestCase(PropertyexpirationSpecified)]
        [TestCase(PropertyhistoryRestriction)]
        [TestCase(PropertylockoutInterval)]
        [TestCase(PropertylockoutIntervalSpecified)]
        [TestCase(PropertymaxLoginAttempts)]
        [TestCase(PropertymaxLoginAttemptsSpecified)]
        [TestCase(PropertyminPasswordLength)]
        [TestCase(PropertyminPasswordLengthSpecified)]
        [TestCase(PropertypasswordAssistanceMessage)]
        [TestCase(PropertypasswordAssistanceURL)]
        [TestCase(PropertyquestionRestriction)]
        [TestCase(PropertyquestionRestrictionSpecified)]
        public void AUT_PasswordPolicies_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_passwordPoliciesInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PasswordPolicies) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PasswordPolicies" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldapiOnlyUserHomePageURLField)]
        [TestCase(FieldcomplexityField)]
        [TestCase(FieldcomplexityFieldSpecified)]
        [TestCase(FieldexpirationField)]
        [TestCase(FieldexpirationFieldSpecified)]
        [TestCase(FieldhistoryRestrictionField)]
        [TestCase(FieldlockoutIntervalField)]
        [TestCase(FieldlockoutIntervalFieldSpecified)]
        [TestCase(FieldmaxLoginAttemptsField)]
        [TestCase(FieldmaxLoginAttemptsFieldSpecified)]
        [TestCase(FieldminPasswordLengthField)]
        [TestCase(FieldminPasswordLengthFieldSpecified)]
        [TestCase(FieldpasswordAssistanceMessageField)]
        [TestCase(FieldpasswordAssistanceURLField)]
        [TestCase(FieldquestionRestrictionField)]
        [TestCase(FieldquestionRestrictionFieldSpecified)]
        public void AUT_PasswordPolicies_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_passwordPoliciesInstanceFixture, 
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
        ///     Class (<see cref="PasswordPolicies" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_PasswordPolicies_Is_Instance_Present_Test()
        {
            // Assert
            _passwordPoliciesInstanceType.ShouldNotBeNull();
            _passwordPoliciesInstance.ShouldNotBeNull();
            _passwordPoliciesInstanceFixture.ShouldNotBeNull();
            _passwordPoliciesInstance.ShouldBeAssignableTo<PasswordPolicies>();
            _passwordPoliciesInstanceFixture.ShouldBeAssignableTo<PasswordPolicies>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PasswordPolicies) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_PasswordPolicies_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PasswordPolicies instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _passwordPoliciesInstanceType.ShouldNotBeNull();
            _passwordPoliciesInstance.ShouldNotBeNull();
            _passwordPoliciesInstanceFixture.ShouldNotBeNull();
            _passwordPoliciesInstance.ShouldBeAssignableTo<PasswordPolicies>();
            _passwordPoliciesInstanceFixture.ShouldBeAssignableTo<PasswordPolicies>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (PasswordPolicies) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyapiOnlyUserHomePageURL)]
        [TestCaseGeneric(typeof(Complexity) , Propertycomplexity)]
        [TestCaseGeneric(typeof(bool) , PropertycomplexitySpecified)]
        [TestCaseGeneric(typeof(Expiration) , Propertyexpiration)]
        [TestCaseGeneric(typeof(bool) , PropertyexpirationSpecified)]
        [TestCaseGeneric(typeof(string) , PropertyhistoryRestriction)]
        [TestCaseGeneric(typeof(LockoutInterval) , PropertylockoutInterval)]
        [TestCaseGeneric(typeof(bool) , PropertylockoutIntervalSpecified)]
        [TestCaseGeneric(typeof(MaxLoginAttempts) , PropertymaxLoginAttempts)]
        [TestCaseGeneric(typeof(bool) , PropertymaxLoginAttemptsSpecified)]
        [TestCaseGeneric(typeof(MinPasswordLength) , PropertyminPasswordLength)]
        [TestCaseGeneric(typeof(bool) , PropertyminPasswordLengthSpecified)]
        [TestCaseGeneric(typeof(string) , PropertypasswordAssistanceMessage)]
        [TestCaseGeneric(typeof(string) , PropertypasswordAssistanceURL)]
        [TestCaseGeneric(typeof(QuestionRestriction) , PropertyquestionRestriction)]
        [TestCaseGeneric(typeof(bool) , PropertyquestionRestrictionSpecified)]
        public void AUT_PasswordPolicies_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<PasswordPolicies, T>(_passwordPoliciesInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (PasswordPolicies) => Property (apiOnlyUserHomePageURL) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PasswordPolicies_Public_Class_apiOnlyUserHomePageURL_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyapiOnlyUserHomePageURL);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PasswordPolicies) => Property (complexity) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PasswordPolicies_complexity_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertycomplexity);
            Action currentAction = () => propertyInfo.SetValue(_passwordPoliciesInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PasswordPolicies) => Property (complexity) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PasswordPolicies_Public_Class_complexity_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycomplexity);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PasswordPolicies) => Property (complexitySpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PasswordPolicies_Public_Class_complexitySpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycomplexitySpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PasswordPolicies) => Property (expiration) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PasswordPolicies_expiration_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyexpiration);
            Action currentAction = () => propertyInfo.SetValue(_passwordPoliciesInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PasswordPolicies) => Property (expiration) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PasswordPolicies_Public_Class_expiration_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyexpiration);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PasswordPolicies) => Property (expirationSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PasswordPolicies_Public_Class_expirationSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyexpirationSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PasswordPolicies) => Property (historyRestriction) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PasswordPolicies_Public_Class_historyRestriction_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyhistoryRestriction);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PasswordPolicies) => Property (lockoutInterval) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PasswordPolicies_lockoutInterval_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertylockoutInterval);
            Action currentAction = () => propertyInfo.SetValue(_passwordPoliciesInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PasswordPolicies) => Property (lockoutInterval) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PasswordPolicies_Public_Class_lockoutInterval_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylockoutInterval);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PasswordPolicies) => Property (lockoutIntervalSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PasswordPolicies_Public_Class_lockoutIntervalSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylockoutIntervalSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PasswordPolicies) => Property (maxLoginAttempts) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PasswordPolicies_maxLoginAttempts_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertymaxLoginAttempts);
            Action currentAction = () => propertyInfo.SetValue(_passwordPoliciesInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PasswordPolicies) => Property (maxLoginAttempts) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PasswordPolicies_Public_Class_maxLoginAttempts_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymaxLoginAttempts);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PasswordPolicies) => Property (maxLoginAttemptsSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PasswordPolicies_Public_Class_maxLoginAttemptsSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymaxLoginAttemptsSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PasswordPolicies) => Property (minPasswordLength) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PasswordPolicies_minPasswordLength_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyminPasswordLength);
            Action currentAction = () => propertyInfo.SetValue(_passwordPoliciesInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PasswordPolicies) => Property (minPasswordLength) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PasswordPolicies_Public_Class_minPasswordLength_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyminPasswordLength);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PasswordPolicies) => Property (minPasswordLengthSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PasswordPolicies_Public_Class_minPasswordLengthSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyminPasswordLengthSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PasswordPolicies) => Property (passwordAssistanceMessage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PasswordPolicies_Public_Class_passwordAssistanceMessage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypasswordAssistanceMessage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PasswordPolicies) => Property (passwordAssistanceURL) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PasswordPolicies_Public_Class_passwordAssistanceURL_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypasswordAssistanceURL);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PasswordPolicies) => Property (questionRestriction) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PasswordPolicies_questionRestriction_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyquestionRestriction);
            Action currentAction = () => propertyInfo.SetValue(_passwordPoliciesInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PasswordPolicies) => Property (questionRestriction) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PasswordPolicies_Public_Class_questionRestriction_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyquestionRestriction);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PasswordPolicies) => Property (questionRestrictionSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PasswordPolicies_Public_Class_questionRestrictionSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyquestionRestrictionSpecified);

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