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
using ExtensionSettings = EPMLiveCore.SSRS2005;

namespace EPMLiveCore.SSRS2005
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2005.ExtensionSettings" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2005"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ExtensionSettingsTest : AbstractBaseSetupTypedTest<ExtensionSettings>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ExtensionSettings) Initializer

        private const string PropertyExtension = "Extension";
        private const string PropertyParameterValues = "ParameterValues";
        private const string FieldextensionField = "extensionField";
        private const string FieldparameterValuesField = "parameterValuesField";
        private Type _extensionSettingsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ExtensionSettings _extensionSettingsInstance;
        private ExtensionSettings _extensionSettingsInstanceFixture;

        #region General Initializer : Class (ExtensionSettings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ExtensionSettings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _extensionSettingsInstanceType = typeof(ExtensionSettings);
            _extensionSettingsInstanceFixture = Create(true);
            _extensionSettingsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ExtensionSettings)

        #region General Initializer : Class (ExtensionSettings) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ExtensionSettings" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyExtension)]
        [TestCase(PropertyParameterValues)]
        public void AUT_ExtensionSettings_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_extensionSettingsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ExtensionSettings) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ExtensionSettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldextensionField)]
        [TestCase(FieldparameterValuesField)]
        public void AUT_ExtensionSettings_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_extensionSettingsInstanceFixture, 
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
        ///     Class (<see cref="ExtensionSettings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ExtensionSettings_Is_Instance_Present_Test()
        {
            // Assert
            _extensionSettingsInstanceType.ShouldNotBeNull();
            _extensionSettingsInstance.ShouldNotBeNull();
            _extensionSettingsInstanceFixture.ShouldNotBeNull();
            _extensionSettingsInstance.ShouldBeAssignableTo<ExtensionSettings>();
            _extensionSettingsInstanceFixture.ShouldBeAssignableTo<ExtensionSettings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ExtensionSettings) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ExtensionSettings_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ExtensionSettings instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _extensionSettingsInstanceType.ShouldNotBeNull();
            _extensionSettingsInstance.ShouldNotBeNull();
            _extensionSettingsInstanceFixture.ShouldNotBeNull();
            _extensionSettingsInstance.ShouldBeAssignableTo<ExtensionSettings>();
            _extensionSettingsInstanceFixture.ShouldBeAssignableTo<ExtensionSettings>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ExtensionSettings) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyExtension)]
        [TestCaseGeneric(typeof(ParameterValueOrFieldReference[]) , PropertyParameterValues)]
        public void AUT_ExtensionSettings_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ExtensionSettings, T>(_extensionSettingsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ExtensionSettings) => Property (Extension) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExtensionSettings_Public_Class_Extension_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ExtensionSettings) => Property (ParameterValues) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExtensionSettings_ParameterValues_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyParameterValues);
            Action currentAction = () => propertyInfo.SetValue(_extensionSettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ExtensionSettings) => Property (ParameterValues) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExtensionSettings_Public_Class_ParameterValues_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyParameterValues);

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