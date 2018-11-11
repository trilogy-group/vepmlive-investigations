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
using TimeZoneInformation = EPMLiveCore.SSRS2006;

namespace EPMLiveCore.SSRS2006
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2006.TimeZoneInformation" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2006"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class TimeZoneInformationTest : AbstractBaseSetupTypedTest<TimeZoneInformation>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (TimeZoneInformation) Initializer

        private const string PropertyBias = "Bias";
        private const string PropertyStandardBias = "StandardBias";
        private const string PropertyStandardDate = "StandardDate";
        private const string PropertyDaylightBias = "DaylightBias";
        private const string PropertyDaylightDate = "DaylightDate";
        private const string FieldbiasField = "biasField";
        private const string FieldstandardBiasField = "standardBiasField";
        private const string FieldstandardDateField = "standardDateField";
        private const string FielddaylightBiasField = "daylightBiasField";
        private const string FielddaylightDateField = "daylightDateField";
        private Type _timeZoneInformationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private TimeZoneInformation _timeZoneInformationInstance;
        private TimeZoneInformation _timeZoneInformationInstanceFixture;

        #region General Initializer : Class (TimeZoneInformation) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="TimeZoneInformation" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _timeZoneInformationInstanceType = typeof(TimeZoneInformation);
            _timeZoneInformationInstanceFixture = Create(true);
            _timeZoneInformationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (TimeZoneInformation)

        #region General Initializer : Class (TimeZoneInformation) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="TimeZoneInformation" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyBias)]
        [TestCase(PropertyStandardBias)]
        [TestCase(PropertyStandardDate)]
        [TestCase(PropertyDaylightBias)]
        [TestCase(PropertyDaylightDate)]
        public void AUT_TimeZoneInformation_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_timeZoneInformationInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (TimeZoneInformation) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="TimeZoneInformation" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldbiasField)]
        [TestCase(FieldstandardBiasField)]
        [TestCase(FieldstandardDateField)]
        [TestCase(FielddaylightBiasField)]
        [TestCase(FielddaylightDateField)]
        public void AUT_TimeZoneInformation_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_timeZoneInformationInstanceFixture, 
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
        ///     Class (<see cref="TimeZoneInformation" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_TimeZoneInformation_Is_Instance_Present_Test()
        {
            // Assert
            _timeZoneInformationInstanceType.ShouldNotBeNull();
            _timeZoneInformationInstance.ShouldNotBeNull();
            _timeZoneInformationInstanceFixture.ShouldNotBeNull();
            _timeZoneInformationInstance.ShouldBeAssignableTo<TimeZoneInformation>();
            _timeZoneInformationInstanceFixture.ShouldBeAssignableTo<TimeZoneInformation>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (TimeZoneInformation) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_TimeZoneInformation_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            TimeZoneInformation instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _timeZoneInformationInstanceType.ShouldNotBeNull();
            _timeZoneInformationInstance.ShouldNotBeNull();
            _timeZoneInformationInstanceFixture.ShouldNotBeNull();
            _timeZoneInformationInstance.ShouldBeAssignableTo<TimeZoneInformation>();
            _timeZoneInformationInstanceFixture.ShouldBeAssignableTo<TimeZoneInformation>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (TimeZoneInformation) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(int) , PropertyBias)]
        [TestCaseGeneric(typeof(int) , PropertyStandardBias)]
        [TestCaseGeneric(typeof(SYSTEMTIME) , PropertyStandardDate)]
        [TestCaseGeneric(typeof(int) , PropertyDaylightBias)]
        [TestCaseGeneric(typeof(SYSTEMTIME) , PropertyDaylightDate)]
        public void AUT_TimeZoneInformation_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<TimeZoneInformation, T>(_timeZoneInformationInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (TimeZoneInformation) => Property (Bias) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_TimeZoneInformation_Public_Class_Bias_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyBias);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeZoneInformation) => Property (DaylightBias) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_TimeZoneInformation_Public_Class_DaylightBias_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDaylightBias);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeZoneInformation) => Property (DaylightDate) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_TimeZoneInformation_DaylightDate_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyDaylightDate);
            Action currentAction = () => propertyInfo.SetValue(_timeZoneInformationInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (TimeZoneInformation) => Property (DaylightDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_TimeZoneInformation_Public_Class_DaylightDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDaylightDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeZoneInformation) => Property (StandardBias) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_TimeZoneInformation_Public_Class_StandardBias_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyStandardBias);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeZoneInformation) => Property (StandardDate) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_TimeZoneInformation_StandardDate_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyStandardDate);
            Action currentAction = () => propertyInfo.SetValue(_timeZoneInformationInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (TimeZoneInformation) => Property (StandardDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_TimeZoneInformation_Public_Class_StandardDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyStandardDate);

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