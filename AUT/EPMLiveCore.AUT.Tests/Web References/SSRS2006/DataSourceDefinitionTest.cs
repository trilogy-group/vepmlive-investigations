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
using EPMLiveCore.SSRS2006;
using DataSourceDefinition = EPMLiveCore.SSRS2006;

namespace EPMLiveCore.SSRS2006
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2006.DataSourceDefinition" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2006"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DataSourceDefinitionTest : AbstractBaseSetupTypedTest<DataSourceDefinition>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DataSourceDefinition) Initializer

        private const string PropertyExtension = "Extension";
        private const string PropertyConnectString = "ConnectString";
        private const string PropertyUseOriginalConnectString = "UseOriginalConnectString";
        private const string PropertyOriginalConnectStringExpressionBased = "OriginalConnectStringExpressionBased";
        private const string PropertyCredentialRetrieval = "CredentialRetrieval";
        private const string PropertyWindowsCredentials = "WindowsCredentials";
        private const string PropertyImpersonateUser = "ImpersonateUser";
        private const string PropertyImpersonateUserSpecified = "ImpersonateUserSpecified";
        private const string PropertyPrompt = "Prompt";
        private const string PropertyUserName = "UserName";
        private const string PropertyPassword = "Password";
        private const string PropertyEnabled = "Enabled";
        private const string PropertyEnabledSpecified = "EnabledSpecified";
        private const string FieldextensionField = "extensionField";
        private const string FieldconnectStringField = "connectStringField";
        private const string FielduseOriginalConnectStringField = "useOriginalConnectStringField";
        private const string FieldoriginalConnectStringExpressionBasedField = "originalConnectStringExpressionBasedField";
        private const string FieldcredentialRetrievalField = "credentialRetrievalField";
        private const string FieldwindowsCredentialsField = "windowsCredentialsField";
        private const string FieldimpersonateUserField = "impersonateUserField";
        private const string FieldimpersonateUserFieldSpecified = "impersonateUserFieldSpecified";
        private const string FieldpromptField = "promptField";
        private const string FielduserNameField = "userNameField";
        private const string FieldpasswordField = "passwordField";
        private const string FieldenabledField = "enabledField";
        private const string FieldenabledFieldSpecified = "enabledFieldSpecified";
        private Type _dataSourceDefinitionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DataSourceDefinition _dataSourceDefinitionInstance;
        private DataSourceDefinition _dataSourceDefinitionInstanceFixture;

        #region General Initializer : Class (DataSourceDefinition) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DataSourceDefinition" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dataSourceDefinitionInstanceType = typeof(DataSourceDefinition);
            _dataSourceDefinitionInstanceFixture = Create(true);
            _dataSourceDefinitionInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DataSourceDefinition)

        #region General Initializer : Class (DataSourceDefinition) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DataSourceDefinition" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyExtension)]
        [TestCase(PropertyConnectString)]
        [TestCase(PropertyUseOriginalConnectString)]
        [TestCase(PropertyOriginalConnectStringExpressionBased)]
        [TestCase(PropertyCredentialRetrieval)]
        [TestCase(PropertyWindowsCredentials)]
        [TestCase(PropertyImpersonateUser)]
        [TestCase(PropertyImpersonateUserSpecified)]
        [TestCase(PropertyPrompt)]
        [TestCase(PropertyUserName)]
        [TestCase(PropertyPassword)]
        [TestCase(PropertyEnabled)]
        [TestCase(PropertyEnabledSpecified)]
        public void AUT_DataSourceDefinition_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_dataSourceDefinitionInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DataSourceDefinition) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DataSourceDefinition" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldextensionField)]
        [TestCase(FieldconnectStringField)]
        [TestCase(FielduseOriginalConnectStringField)]
        [TestCase(FieldoriginalConnectStringExpressionBasedField)]
        [TestCase(FieldcredentialRetrievalField)]
        [TestCase(FieldwindowsCredentialsField)]
        [TestCase(FieldimpersonateUserField)]
        [TestCase(FieldimpersonateUserFieldSpecified)]
        [TestCase(FieldpromptField)]
        [TestCase(FielduserNameField)]
        [TestCase(FieldpasswordField)]
        [TestCase(FieldenabledField)]
        [TestCase(FieldenabledFieldSpecified)]
        public void AUT_DataSourceDefinition_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_dataSourceDefinitionInstanceFixture, 
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
        ///     Class (<see cref="DataSourceDefinition" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DataSourceDefinition_Is_Instance_Present_Test()
        {
            // Assert
            _dataSourceDefinitionInstanceType.ShouldNotBeNull();
            _dataSourceDefinitionInstance.ShouldNotBeNull();
            _dataSourceDefinitionInstanceFixture.ShouldNotBeNull();
            _dataSourceDefinitionInstance.ShouldBeAssignableTo<DataSourceDefinition>();
            _dataSourceDefinitionInstanceFixture.ShouldBeAssignableTo<DataSourceDefinition>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DataSourceDefinition) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DataSourceDefinition_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DataSourceDefinition instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _dataSourceDefinitionInstanceType.ShouldNotBeNull();
            _dataSourceDefinitionInstance.ShouldNotBeNull();
            _dataSourceDefinitionInstanceFixture.ShouldNotBeNull();
            _dataSourceDefinitionInstance.ShouldBeAssignableTo<DataSourceDefinition>();
            _dataSourceDefinitionInstanceFixture.ShouldBeAssignableTo<DataSourceDefinition>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DataSourceDefinition) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyExtension)]
        [TestCaseGeneric(typeof(string) , PropertyConnectString)]
        [TestCaseGeneric(typeof(bool) , PropertyUseOriginalConnectString)]
        [TestCaseGeneric(typeof(bool) , PropertyOriginalConnectStringExpressionBased)]
        [TestCaseGeneric(typeof(CredentialRetrievalEnum) , PropertyCredentialRetrieval)]
        [TestCaseGeneric(typeof(bool) , PropertyWindowsCredentials)]
        [TestCaseGeneric(typeof(bool) , PropertyImpersonateUser)]
        [TestCaseGeneric(typeof(bool) , PropertyImpersonateUserSpecified)]
        [TestCaseGeneric(typeof(string) , PropertyPrompt)]
        [TestCaseGeneric(typeof(string) , PropertyUserName)]
        [TestCaseGeneric(typeof(string) , PropertyPassword)]
        [TestCaseGeneric(typeof(bool) , PropertyEnabled)]
        [TestCaseGeneric(typeof(bool) , PropertyEnabledSpecified)]
        public void AUT_DataSourceDefinition_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DataSourceDefinition, T>(_dataSourceDefinitionInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DataSourceDefinition) => Property (ConnectString) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSourceDefinition_Public_Class_ConnectString_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyConnectString);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataSourceDefinition) => Property (CredentialRetrieval) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSourceDefinition_CredentialRetrieval_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyCredentialRetrieval);
            Action currentAction = () => propertyInfo.SetValue(_dataSourceDefinitionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DataSourceDefinition) => Property (CredentialRetrieval) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSourceDefinition_Public_Class_CredentialRetrieval_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCredentialRetrieval);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataSourceDefinition) => Property (Enabled) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSourceDefinition_Public_Class_Enabled_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyEnabled);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataSourceDefinition) => Property (EnabledSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSourceDefinition_Public_Class_EnabledSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyEnabledSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataSourceDefinition) => Property (Extension) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSourceDefinition_Public_Class_Extension_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyExtension);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataSourceDefinition) => Property (ImpersonateUser) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSourceDefinition_Public_Class_ImpersonateUser_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyImpersonateUser);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataSourceDefinition) => Property (ImpersonateUserSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSourceDefinition_Public_Class_ImpersonateUserSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyImpersonateUserSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataSourceDefinition) => Property (OriginalConnectStringExpressionBased) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSourceDefinition_Public_Class_OriginalConnectStringExpressionBased_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyOriginalConnectStringExpressionBased);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataSourceDefinition) => Property (Password) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSourceDefinition_Public_Class_Password_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPassword);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataSourceDefinition) => Property (Prompt) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSourceDefinition_Public_Class_Prompt_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DataSourceDefinition) => Property (UseOriginalConnectString) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSourceDefinition_Public_Class_UseOriginalConnectString_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUseOriginalConnectString);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataSourceDefinition) => Property (UserName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSourceDefinition_Public_Class_UserName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUserName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataSourceDefinition) => Property (WindowsCredentials) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSourceDefinition_Public_Class_WindowsCredentials_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWindowsCredentials);

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