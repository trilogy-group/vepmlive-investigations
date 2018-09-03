using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore.SSRS2010;
using ItemParameter = EPMLiveCore.SSRS2010;

namespace EPMLiveCore.SSRS2010
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2010.ItemParameter" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2010"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ItemParameterTest : AbstractBaseSetupTypedTest<ItemParameter>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ItemParameter) Initializer

        private const string PropertyName = "Name";
        private const string PropertyParameterTypeName = "ParameterTypeName";
        private const string PropertyNullable = "Nullable";
        private const string PropertyNullableSpecified = "NullableSpecified";
        private const string PropertyAllowBlank = "AllowBlank";
        private const string PropertyAllowBlankSpecified = "AllowBlankSpecified";
        private const string PropertyMultiValue = "MultiValue";
        private const string PropertyMultiValueSpecified = "MultiValueSpecified";
        private const string PropertyQueryParameter = "QueryParameter";
        private const string PropertyQueryParameterSpecified = "QueryParameterSpecified";
        private const string PropertyPrompt = "Prompt";
        private const string PropertyPromptUser = "PromptUser";
        private const string PropertyPromptUserSpecified = "PromptUserSpecified";
        private const string PropertyDependencies = "Dependencies";
        private const string PropertyValidValuesQueryBased = "ValidValuesQueryBased";
        private const string PropertyValidValuesQueryBasedSpecified = "ValidValuesQueryBasedSpecified";
        private const string PropertyValidValues = "ValidValues";
        private const string PropertyDefaultValuesQueryBased = "DefaultValuesQueryBased";
        private const string PropertyDefaultValuesQueryBasedSpecified = "DefaultValuesQueryBasedSpecified";
        private const string PropertyDefaultValues = "DefaultValues";
        private const string PropertyParameterStateName = "ParameterStateName";
        private const string PropertyErrorMessage = "ErrorMessage";
        private const string FieldnameField = "nameField";
        private const string FieldparameterTypeNameField = "parameterTypeNameField";
        private const string FieldnullableField = "nullableField";
        private const string FieldnullableFieldSpecified = "nullableFieldSpecified";
        private const string FieldallowBlankField = "allowBlankField";
        private const string FieldallowBlankFieldSpecified = "allowBlankFieldSpecified";
        private const string FieldmultiValueField = "multiValueField";
        private const string FieldmultiValueFieldSpecified = "multiValueFieldSpecified";
        private const string FieldqueryParameterField = "queryParameterField";
        private const string FieldqueryParameterFieldSpecified = "queryParameterFieldSpecified";
        private const string FieldpromptField = "promptField";
        private const string FieldpromptUserField = "promptUserField";
        private const string FieldpromptUserFieldSpecified = "promptUserFieldSpecified";
        private const string FielddependenciesField = "dependenciesField";
        private const string FieldvalidValuesQueryBasedField = "validValuesQueryBasedField";
        private const string FieldvalidValuesQueryBasedFieldSpecified = "validValuesQueryBasedFieldSpecified";
        private const string FieldvalidValuesField = "validValuesField";
        private const string FielddefaultValuesQueryBasedField = "defaultValuesQueryBasedField";
        private const string FielddefaultValuesQueryBasedFieldSpecified = "defaultValuesQueryBasedFieldSpecified";
        private const string FielddefaultValuesField = "defaultValuesField";
        private const string FieldparameterStateNameField = "parameterStateNameField";
        private const string FielderrorMessageField = "errorMessageField";
        private Type _itemParameterInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ItemParameter _itemParameterInstance;
        private ItemParameter _itemParameterInstanceFixture;

        #region General Initializer : Class (ItemParameter) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ItemParameter" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _itemParameterInstanceType = typeof(ItemParameter);
            _itemParameterInstanceFixture = Create(true);
            _itemParameterInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ItemParameter)

        #region General Initializer : Class (ItemParameter) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ItemParameter" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyName)]
        [TestCase(PropertyParameterTypeName)]
        [TestCase(PropertyNullable)]
        [TestCase(PropertyNullableSpecified)]
        [TestCase(PropertyAllowBlank)]
        [TestCase(PropertyAllowBlankSpecified)]
        [TestCase(PropertyMultiValue)]
        [TestCase(PropertyMultiValueSpecified)]
        [TestCase(PropertyQueryParameter)]
        [TestCase(PropertyQueryParameterSpecified)]
        [TestCase(PropertyPrompt)]
        [TestCase(PropertyPromptUser)]
        [TestCase(PropertyPromptUserSpecified)]
        [TestCase(PropertyDependencies)]
        [TestCase(PropertyValidValuesQueryBased)]
        [TestCase(PropertyValidValuesQueryBasedSpecified)]
        [TestCase(PropertyValidValues)]
        [TestCase(PropertyDefaultValuesQueryBased)]
        [TestCase(PropertyDefaultValuesQueryBasedSpecified)]
        [TestCase(PropertyDefaultValues)]
        [TestCase(PropertyParameterStateName)]
        [TestCase(PropertyErrorMessage)]
        public void AUT_ItemParameter_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_itemParameterInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ItemParameter) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ItemParameter" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldnameField)]
        [TestCase(FieldparameterTypeNameField)]
        [TestCase(FieldnullableField)]
        [TestCase(FieldnullableFieldSpecified)]
        [TestCase(FieldallowBlankField)]
        [TestCase(FieldallowBlankFieldSpecified)]
        [TestCase(FieldmultiValueField)]
        [TestCase(FieldmultiValueFieldSpecified)]
        [TestCase(FieldqueryParameterField)]
        [TestCase(FieldqueryParameterFieldSpecified)]
        [TestCase(FieldpromptField)]
        [TestCase(FieldpromptUserField)]
        [TestCase(FieldpromptUserFieldSpecified)]
        [TestCase(FielddependenciesField)]
        [TestCase(FieldvalidValuesQueryBasedField)]
        [TestCase(FieldvalidValuesQueryBasedFieldSpecified)]
        [TestCase(FieldvalidValuesField)]
        [TestCase(FielddefaultValuesQueryBasedField)]
        [TestCase(FielddefaultValuesQueryBasedFieldSpecified)]
        [TestCase(FielddefaultValuesField)]
        [TestCase(FieldparameterStateNameField)]
        [TestCase(FielderrorMessageField)]
        public void AUT_ItemParameter_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_itemParameterInstanceFixture, 
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
        ///     Class (<see cref="ItemParameter" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ItemParameter_Is_Instance_Present_Test()
        {
            // Assert
            _itemParameterInstanceType.ShouldNotBeNull();
            _itemParameterInstance.ShouldNotBeNull();
            _itemParameterInstanceFixture.ShouldNotBeNull();
            _itemParameterInstance.ShouldBeAssignableTo<ItemParameter>();
            _itemParameterInstanceFixture.ShouldBeAssignableTo<ItemParameter>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ItemParameter) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ItemParameter_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ItemParameter instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _itemParameterInstanceType.ShouldNotBeNull();
            _itemParameterInstance.ShouldNotBeNull();
            _itemParameterInstanceFixture.ShouldNotBeNull();
            _itemParameterInstance.ShouldBeAssignableTo<ItemParameter>();
            _itemParameterInstanceFixture.ShouldBeAssignableTo<ItemParameter>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ItemParameter) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        [TestCaseGeneric(typeof(string) , PropertyParameterTypeName)]
        [TestCaseGeneric(typeof(bool) , PropertyNullable)]
        [TestCaseGeneric(typeof(bool) , PropertyNullableSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyAllowBlank)]
        [TestCaseGeneric(typeof(bool) , PropertyAllowBlankSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyMultiValue)]
        [TestCaseGeneric(typeof(bool) , PropertyMultiValueSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyQueryParameter)]
        [TestCaseGeneric(typeof(bool) , PropertyQueryParameterSpecified)]
        [TestCaseGeneric(typeof(string) , PropertyPrompt)]
        [TestCaseGeneric(typeof(bool) , PropertyPromptUser)]
        [TestCaseGeneric(typeof(bool) , PropertyPromptUserSpecified)]
        [TestCaseGeneric(typeof(string[]) , PropertyDependencies)]
        [TestCaseGeneric(typeof(bool) , PropertyValidValuesQueryBased)]
        [TestCaseGeneric(typeof(bool) , PropertyValidValuesQueryBasedSpecified)]
        [TestCaseGeneric(typeof(ValidValue[]) , PropertyValidValues)]
        [TestCaseGeneric(typeof(bool) , PropertyDefaultValuesQueryBased)]
        [TestCaseGeneric(typeof(bool) , PropertyDefaultValuesQueryBasedSpecified)]
        [TestCaseGeneric(typeof(string[]) , PropertyDefaultValues)]
        [TestCaseGeneric(typeof(string) , PropertyParameterStateName)]
        [TestCaseGeneric(typeof(string) , PropertyErrorMessage)]
        public void AUT_ItemParameter_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ItemParameter, T>(_itemParameterInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ItemParameter) => Property (AllowBlank) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemParameter_Public_Class_AllowBlank_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyAllowBlank);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ItemParameter) => Property (AllowBlankSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemParameter_Public_Class_AllowBlankSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyAllowBlankSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ItemParameter) => Property (DefaultValues) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemParameter_DefaultValues_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyDefaultValues);
            Action currentAction = () => propertyInfo.SetValue(_itemParameterInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ItemParameter) => Property (DefaultValues) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemParameter_Public_Class_DefaultValues_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDefaultValues);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ItemParameter) => Property (DefaultValuesQueryBased) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemParameter_Public_Class_DefaultValuesQueryBased_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDefaultValuesQueryBased);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ItemParameter) => Property (DefaultValuesQueryBasedSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemParameter_Public_Class_DefaultValuesQueryBasedSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDefaultValuesQueryBasedSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ItemParameter) => Property (Dependencies) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemParameter_Dependencies_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyDependencies);
            Action currentAction = () => propertyInfo.SetValue(_itemParameterInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ItemParameter) => Property (Dependencies) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemParameter_Public_Class_Dependencies_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDependencies);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ItemParameter) => Property (ErrorMessage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemParameter_Public_Class_ErrorMessage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyErrorMessage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ItemParameter) => Property (MultiValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemParameter_Public_Class_MultiValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyMultiValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ItemParameter) => Property (MultiValueSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemParameter_Public_Class_MultiValueSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyMultiValueSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ItemParameter) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemParameter_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ItemParameter) => Property (Nullable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemParameter_Public_Class_Nullable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyNullable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ItemParameter) => Property (NullableSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemParameter_Public_Class_NullableSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyNullableSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ItemParameter) => Property (ParameterStateName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemParameter_Public_Class_ParameterStateName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyParameterStateName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ItemParameter) => Property (ParameterTypeName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemParameter_Public_Class_ParameterTypeName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyParameterTypeName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ItemParameter) => Property (Prompt) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemParameter_Public_Class_Prompt_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPrompt);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ItemParameter) => Property (PromptUser) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemParameter_Public_Class_PromptUser_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPromptUser);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ItemParameter) => Property (PromptUserSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemParameter_Public_Class_PromptUserSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPromptUserSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ItemParameter) => Property (QueryParameter) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemParameter_Public_Class_QueryParameter_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyQueryParameter);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ItemParameter) => Property (QueryParameterSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemParameter_Public_Class_QueryParameterSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyQueryParameterSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ItemParameter) => Property (ValidValues) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemParameter_ValidValues_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyValidValues);
            Action currentAction = () => propertyInfo.SetValue(_itemParameterInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ItemParameter) => Property (ValidValues) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemParameter_Public_Class_ValidValues_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ItemParameter) => Property (ValidValuesQueryBased) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemParameter_Public_Class_ValidValuesQueryBased_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyValidValuesQueryBased);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ItemParameter) => Property (ValidValuesQueryBasedSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ItemParameter_Public_Class_ValidValuesQueryBasedSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyValidValuesQueryBasedSpecified);

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