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

namespace EPMLiveWebParts.SSRS2005
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SSRS2005.ExtensionParameter" />)
    ///     and namespace <see cref="EPMLiveWebParts.SSRS2005"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ExtensionParameterTest : AbstractBaseSetupTypedTest<ExtensionParameter>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ExtensionParameter) Initializer

        private const string PropertyName = "Name";
        private const string PropertyDisplayName = "DisplayName";
        private const string PropertyRequired = "Required";
        private const string PropertyRequiredSpecified = "RequiredSpecified";
        private const string PropertyReadOnly = "ReadOnly";
        private const string PropertyValue = "Value";
        private const string PropertyError = "Error";
        private const string PropertyEncrypted = "Encrypted";
        private const string PropertyIsPassword = "IsPassword";
        private const string PropertyValidValues = "ValidValues";
        private const string FieldnameField = "nameField";
        private const string FielddisplayNameField = "displayNameField";
        private const string FieldrequiredField = "requiredField";
        private const string FieldrequiredFieldSpecified = "requiredFieldSpecified";
        private const string FieldreadOnlyField = "readOnlyField";
        private const string FieldvalueField = "valueField";
        private const string FielderrorField = "errorField";
        private const string FieldencryptedField = "encryptedField";
        private const string FieldisPasswordField = "isPasswordField";
        private const string FieldvalidValuesField = "validValuesField";
        private Type _extensionParameterInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ExtensionParameter _extensionParameterInstance;
        private ExtensionParameter _extensionParameterInstanceFixture;

        #region General Initializer : Class (ExtensionParameter) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ExtensionParameter" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _extensionParameterInstanceType = typeof(ExtensionParameter);
            _extensionParameterInstanceFixture = Create(true);
            _extensionParameterInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ExtensionParameter)

        #region General Initializer : Class (ExtensionParameter) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ExtensionParameter" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyName)]
        [TestCase(PropertyDisplayName)]
        [TestCase(PropertyRequired)]
        [TestCase(PropertyRequiredSpecified)]
        [TestCase(PropertyReadOnly)]
        [TestCase(PropertyValue)]
        [TestCase(PropertyError)]
        [TestCase(PropertyEncrypted)]
        [TestCase(PropertyIsPassword)]
        [TestCase(PropertyValidValues)]
        public void AUT_ExtensionParameter_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_extensionParameterInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ExtensionParameter) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ExtensionParameter" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldnameField)]
        [TestCase(FielddisplayNameField)]
        [TestCase(FieldrequiredField)]
        [TestCase(FieldrequiredFieldSpecified)]
        [TestCase(FieldreadOnlyField)]
        [TestCase(FieldvalueField)]
        [TestCase(FielderrorField)]
        [TestCase(FieldencryptedField)]
        [TestCase(FieldisPasswordField)]
        [TestCase(FieldvalidValuesField)]
        public void AUT_ExtensionParameter_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_extensionParameterInstanceFixture, 
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
        ///     Class (<see cref="ExtensionParameter" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ExtensionParameter_Is_Instance_Present_Test()
        {
            // Assert
            _extensionParameterInstanceType.ShouldNotBeNull();
            _extensionParameterInstance.ShouldNotBeNull();
            _extensionParameterInstanceFixture.ShouldNotBeNull();
            _extensionParameterInstance.ShouldBeAssignableTo<ExtensionParameter>();
            _extensionParameterInstanceFixture.ShouldBeAssignableTo<ExtensionParameter>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ExtensionParameter) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ExtensionParameter_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ExtensionParameter instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _extensionParameterInstanceType.ShouldNotBeNull();
            _extensionParameterInstance.ShouldNotBeNull();
            _extensionParameterInstanceFixture.ShouldNotBeNull();
            _extensionParameterInstance.ShouldBeAssignableTo<ExtensionParameter>();
            _extensionParameterInstanceFixture.ShouldBeAssignableTo<ExtensionParameter>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ExtensionParameter) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        [TestCaseGeneric(typeof(string) , PropertyDisplayName)]
        [TestCaseGeneric(typeof(bool) , PropertyRequired)]
        [TestCaseGeneric(typeof(bool) , PropertyRequiredSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyReadOnly)]
        [TestCaseGeneric(typeof(string) , PropertyValue)]
        [TestCaseGeneric(typeof(string) , PropertyError)]
        [TestCaseGeneric(typeof(bool) , PropertyEncrypted)]
        [TestCaseGeneric(typeof(bool) , PropertyIsPassword)]
        [TestCaseGeneric(typeof(ValidValue[]) , PropertyValidValues)]
        public void AUT_ExtensionParameter_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ExtensionParameter, T>(_extensionParameterInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ExtensionParameter) => Property (DisplayName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExtensionParameter_Public_Class_DisplayName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDisplayName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExtensionParameter) => Property (Encrypted) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExtensionParameter_Public_Class_Encrypted_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyEncrypted);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExtensionParameter) => Property (Error) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExtensionParameter_Public_Class_Error_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyError);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExtensionParameter) => Property (IsPassword) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExtensionParameter_Public_Class_IsPassword_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyIsPassword);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExtensionParameter) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExtensionParameter_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExtensionParameter) => Property (ReadOnly) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExtensionParameter_Public_Class_ReadOnly_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyReadOnly);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExtensionParameter) => Property (Required) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExtensionParameter_Public_Class_Required_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyRequired);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExtensionParameter) => Property (RequiredSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExtensionParameter_Public_Class_RequiredSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyRequiredSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExtensionParameter) => Property (ValidValues) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExtensionParameter_ValidValues_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyValidValues);
            Action currentAction = () => propertyInfo.SetValue(_extensionParameterInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ExtensionParameter) => Property (ValidValues) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExtensionParameter_Public_Class_ValidValues_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyValidValues);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExtensionParameter) => Property (Value) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExtensionParameter_Public_Class_Value_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyValue);

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