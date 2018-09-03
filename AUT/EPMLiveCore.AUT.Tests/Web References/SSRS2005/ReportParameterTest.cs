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
using EPMLiveCore.SSRS2005;
using ReportParameter = EPMLiveCore.SSRS2005;

namespace EPMLiveCore.SSRS2005
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2005.ReportParameter" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2005"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ReportParameterTest : AbstractBaseSetupTypedTest<ReportParameter>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportParameter) Initializer

        private const string PropertyName = "Name";
        private const string PropertyType = "Type";
        private const string PropertyTypeSpecified = "TypeSpecified";
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
        private const string PropertyState = "State";
        private const string PropertyStateSpecified = "StateSpecified";
        private const string PropertyErrorMessage = "ErrorMessage";
        private const string FieldnameField = "nameField";
        private const string FieldtypeField = "typeField";
        private const string FieldtypeFieldSpecified = "typeFieldSpecified";
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
        private const string FieldstateField = "stateField";
        private const string FieldstateFieldSpecified = "stateFieldSpecified";
        private const string FielderrorMessageField = "errorMessageField";
        private Type _reportParameterInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportParameter _reportParameterInstance;
        private ReportParameter _reportParameterInstanceFixture;

        #region General Initializer : Class (ReportParameter) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportParameter" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportParameterInstanceType = typeof(ReportParameter);
            _reportParameterInstanceFixture = Create(true);
            _reportParameterInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportParameter)

        #region General Initializer : Class (ReportParameter) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportParameter" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyName)]
        [TestCase(PropertyType)]
        [TestCase(PropertyTypeSpecified)]
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
        [TestCase(PropertyState)]
        [TestCase(PropertyStateSpecified)]
        [TestCase(PropertyErrorMessage)]
        public void AUT_ReportParameter_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportParameterInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportParameter) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportParameter" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldnameField)]
        [TestCase(FieldtypeField)]
        [TestCase(FieldtypeFieldSpecified)]
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
        [TestCase(FieldstateField)]
        [TestCase(FieldstateFieldSpecified)]
        [TestCase(FielderrorMessageField)]
        public void AUT_ReportParameter_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportParameterInstanceFixture, 
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
        ///     Class (<see cref="ReportParameter" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ReportParameter_Is_Instance_Present_Test()
        {
            // Assert
            _reportParameterInstanceType.ShouldNotBeNull();
            _reportParameterInstance.ShouldNotBeNull();
            _reportParameterInstanceFixture.ShouldNotBeNull();
            _reportParameterInstance.ShouldBeAssignableTo<ReportParameter>();
            _reportParameterInstanceFixture.ShouldBeAssignableTo<ReportParameter>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportParameter) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ReportParameter_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportParameter instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportParameterInstanceType.ShouldNotBeNull();
            _reportParameterInstance.ShouldNotBeNull();
            _reportParameterInstanceFixture.ShouldNotBeNull();
            _reportParameterInstance.ShouldBeAssignableTo<ReportParameter>();
            _reportParameterInstanceFixture.ShouldBeAssignableTo<ReportParameter>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportParameter) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        [TestCaseGeneric(typeof(ParameterTypeEnum) , PropertyType)]
        [TestCaseGeneric(typeof(bool) , PropertyTypeSpecified)]
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
        [TestCaseGeneric(typeof(ParameterStateEnum) , PropertyState)]
        [TestCaseGeneric(typeof(bool) , PropertyStateSpecified)]
        [TestCaseGeneric(typeof(string) , PropertyErrorMessage)]
        public void AUT_ReportParameter_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportParameter, T>(_reportParameterInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ReportParameter) => Property (AllowBlank) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_Public_Class_AllowBlank_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportParameter) => Property (AllowBlankSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_Public_Class_AllowBlankSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportParameter) => Property (DefaultValues) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_DefaultValues_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyDefaultValues);
            Action currentAction = () => propertyInfo.SetValue(_reportParameterInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportParameter) => Property (DefaultValues) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_Public_Class_DefaultValues_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportParameter) => Property (DefaultValuesQueryBased) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_Public_Class_DefaultValuesQueryBased_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportParameter) => Property (DefaultValuesQueryBasedSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_Public_Class_DefaultValuesQueryBasedSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportParameter) => Property (Dependencies) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_Dependencies_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyDependencies);
            Action currentAction = () => propertyInfo.SetValue(_reportParameterInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportParameter) => Property (Dependencies) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_Public_Class_Dependencies_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportParameter) => Property (ErrorMessage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_Public_Class_ErrorMessage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportParameter) => Property (MultiValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_Public_Class_MultiValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportParameter) => Property (MultiValueSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_Public_Class_MultiValueSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportParameter) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportParameter) => Property (Nullable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_Public_Class_Nullable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportParameter) => Property (NullableSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_Public_Class_NullableSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportParameter) => Property (Prompt) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_Public_Class_Prompt_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportParameter) => Property (PromptUser) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_Public_Class_PromptUser_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportParameter) => Property (PromptUserSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_Public_Class_PromptUserSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportParameter) => Property (QueryParameter) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_Public_Class_QueryParameter_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportParameter) => Property (QueryParameterSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_Public_Class_QueryParameterSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportParameter) => Property (State) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_State_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyState);
            Action currentAction = () => propertyInfo.SetValue(_reportParameterInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportParameter) => Property (State) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_Public_Class_State_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyState);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportParameter) => Property (StateSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_Public_Class_StateSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyStateSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportParameter) => Property (Type) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_Type_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyType);
            Action currentAction = () => propertyInfo.SetValue(_reportParameterInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportParameter) => Property (Type) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_Public_Class_Type_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportParameter) => Property (TypeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_Public_Class_TypeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyTypeSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportParameter) => Property (ValidValues) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_ValidValues_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyValidValues);
            Action currentAction = () => propertyInfo.SetValue(_reportParameterInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportParameter) => Property (ValidValues) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_Public_Class_ValidValues_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportParameter) => Property (ValidValuesQueryBased) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_Public_Class_ValidValuesQueryBased_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportParameter) => Property (ValidValuesQueryBasedSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportParameter_Public_Class_ValidValuesQueryBasedSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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