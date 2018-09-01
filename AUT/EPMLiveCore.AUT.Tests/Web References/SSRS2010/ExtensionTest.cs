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
using Extension = EPMLiveCore.SSRS2010;

namespace EPMLiveCore.SSRS2010
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2010.Extension" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2010"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ExtensionTest : AbstractBaseSetupTypedTest<Extension>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Extension) Initializer

        private const string PropertyExtensionTypeName = "ExtensionTypeName";
        private const string PropertyName = "Name";
        private const string PropertyLocalizedName = "LocalizedName";
        private const string PropertyVisible = "Visible";
        private const string PropertyIsModelGenerationSupported = "IsModelGenerationSupported";
        private const string FieldextensionTypeNameField = "extensionTypeNameField";
        private const string FieldnameField = "nameField";
        private const string FieldlocalizedNameField = "localizedNameField";
        private const string FieldvisibleField = "visibleField";
        private const string FieldisModelGenerationSupportedField = "isModelGenerationSupportedField";
        private Type _extensionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Extension _extensionInstance;
        private Extension _extensionInstanceFixture;

        #region General Initializer : Class (Extension) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Extension" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _extensionInstanceType = typeof(Extension);
            _extensionInstanceFixture = Create(true);
            _extensionInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Extension)

        #region General Initializer : Class (Extension) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Extension" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyExtensionTypeName)]
        [TestCase(PropertyName)]
        [TestCase(PropertyLocalizedName)]
        [TestCase(PropertyVisible)]
        [TestCase(PropertyIsModelGenerationSupported)]
        public void AUT_Extension_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_extensionInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Extension) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Extension" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldextensionTypeNameField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldlocalizedNameField)]
        [TestCase(FieldvisibleField)]
        [TestCase(FieldisModelGenerationSupportedField)]
        public void AUT_Extension_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_extensionInstanceFixture, 
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
        ///     Class (<see cref="Extension" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Extension_Is_Instance_Present_Test()
        {
            // Assert
            _extensionInstanceType.ShouldNotBeNull();
            _extensionInstance.ShouldNotBeNull();
            _extensionInstanceFixture.ShouldNotBeNull();
            _extensionInstance.ShouldBeAssignableTo<Extension>();
            _extensionInstanceFixture.ShouldBeAssignableTo<Extension>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Extension) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Extension_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Extension instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _extensionInstanceType.ShouldNotBeNull();
            _extensionInstance.ShouldNotBeNull();
            _extensionInstanceFixture.ShouldNotBeNull();
            _extensionInstance.ShouldBeAssignableTo<Extension>();
            _extensionInstanceFixture.ShouldBeAssignableTo<Extension>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Extension) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyExtensionTypeName)]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        [TestCaseGeneric(typeof(string) , PropertyLocalizedName)]
        [TestCaseGeneric(typeof(bool) , PropertyVisible)]
        [TestCaseGeneric(typeof(bool) , PropertyIsModelGenerationSupported)]
        public void AUT_Extension_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Extension, T>(_extensionInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Extension) => Property (ExtensionTypeName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Extension_Public_Class_ExtensionTypeName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyExtensionTypeName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Extension) => Property (IsModelGenerationSupported) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Extension_Public_Class_IsModelGenerationSupported_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyIsModelGenerationSupported);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Extension) => Property (LocalizedName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Extension_Public_Class_LocalizedName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyLocalizedName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Extension) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Extension_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Extension) => Property (Visible) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Extension_Public_Class_Visible_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyVisible);

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