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
using EPMLiveCore.SalesforcePartnerService;
using LocaleOptions = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.LocaleOptions" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class LocaleOptionsTest : AbstractBaseSetupTypedTest<LocaleOptions>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (LocaleOptions) Initializer

        private const string Propertylanguage = "language";
        private const string FieldlanguageField = "languageField";
        private Type _localeOptionsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private LocaleOptions _localeOptionsInstance;
        private LocaleOptions _localeOptionsInstanceFixture;

        #region General Initializer : Class (LocaleOptions) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="LocaleOptions" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _localeOptionsInstanceType = typeof(LocaleOptions);
            _localeOptionsInstanceFixture = Create(true);
            _localeOptionsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (LocaleOptions)

        #region General Initializer : Class (LocaleOptions) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="LocaleOptions" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertylanguage)]
        public void AUT_LocaleOptions_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_localeOptionsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (LocaleOptions) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="LocaleOptions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldlanguageField)]
        public void AUT_LocaleOptions_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_localeOptionsInstanceFixture, 
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
        ///     Class (<see cref="LocaleOptions" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_LocaleOptions_Is_Instance_Present_Test()
        {
            // Assert
            _localeOptionsInstanceType.ShouldNotBeNull();
            _localeOptionsInstance.ShouldNotBeNull();
            _localeOptionsInstanceFixture.ShouldNotBeNull();
            _localeOptionsInstance.ShouldBeAssignableTo<LocaleOptions>();
            _localeOptionsInstanceFixture.ShouldBeAssignableTo<LocaleOptions>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (LocaleOptions) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_LocaleOptions_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            LocaleOptions instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _localeOptionsInstanceType.ShouldNotBeNull();
            _localeOptionsInstance.ShouldNotBeNull();
            _localeOptionsInstanceFixture.ShouldNotBeNull();
            _localeOptionsInstance.ShouldBeAssignableTo<LocaleOptions>();
            _localeOptionsInstanceFixture.ShouldBeAssignableTo<LocaleOptions>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (LocaleOptions) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertylanguage)]
        public void AUT_LocaleOptions_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<LocaleOptions, T>(_localeOptionsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (LocaleOptions) => Property (language) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LocaleOptions_Public_Class_language_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylanguage);

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