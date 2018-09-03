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
using SYSTEMTIME = EPMLiveCore.SSRS2010;

namespace EPMLiveCore.SSRS2010
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2010.SYSTEMTIME" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2010"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SYSTEMTIMETest : AbstractBaseSetupTypedTest<SYSTEMTIME>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SYSTEMTIME) Initializer

        private const string Propertyyear = "year";
        private const string Propertymonth = "month";
        private const string PropertydayOfWeek = "dayOfWeek";
        private const string Propertyday = "day";
        private const string Propertyhour = "hour";
        private const string Propertyminute = "minute";
        private const string Propertysecond = "second";
        private const string Propertymilliseconds = "milliseconds";
        private const string FieldyearField = "yearField";
        private const string FieldmonthField = "monthField";
        private const string FielddayOfWeekField = "dayOfWeekField";
        private const string FielddayField = "dayField";
        private const string FieldhourField = "hourField";
        private const string FieldminuteField = "minuteField";
        private const string FieldsecondField = "secondField";
        private const string FieldmillisecondsField = "millisecondsField";
        private Type _sYSTEMTIMEInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SYSTEMTIME _sYSTEMTIMEInstance;
        private SYSTEMTIME _sYSTEMTIMEInstanceFixture;

        #region General Initializer : Class (SYSTEMTIME) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SYSTEMTIME" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sYSTEMTIMEInstanceType = typeof(SYSTEMTIME);
            _sYSTEMTIMEInstanceFixture = Create(true);
            _sYSTEMTIMEInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SYSTEMTIME)

        #region General Initializer : Class (SYSTEMTIME) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="SYSTEMTIME" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyyear)]
        [TestCase(Propertymonth)]
        [TestCase(PropertydayOfWeek)]
        [TestCase(Propertyday)]
        [TestCase(Propertyhour)]
        [TestCase(Propertyminute)]
        [TestCase(Propertysecond)]
        [TestCase(Propertymilliseconds)]
        public void AUT_SYSTEMTIME_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_sYSTEMTIMEInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SYSTEMTIME) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SYSTEMTIME" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldyearField)]
        [TestCase(FieldmonthField)]
        [TestCase(FielddayOfWeekField)]
        [TestCase(FielddayField)]
        [TestCase(FieldhourField)]
        [TestCase(FieldminuteField)]
        [TestCase(FieldsecondField)]
        [TestCase(FieldmillisecondsField)]
        public void AUT_SYSTEMTIME_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_sYSTEMTIMEInstanceFixture, 
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
        ///     Class (<see cref="SYSTEMTIME" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_SYSTEMTIME_Is_Instance_Present_Test()
        {
            // Assert
            _sYSTEMTIMEInstanceType.ShouldNotBeNull();
            _sYSTEMTIMEInstance.ShouldNotBeNull();
            _sYSTEMTIMEInstanceFixture.ShouldNotBeNull();
            _sYSTEMTIMEInstance.ShouldBeAssignableTo<SYSTEMTIME>();
            _sYSTEMTIMEInstanceFixture.ShouldBeAssignableTo<SYSTEMTIME>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SYSTEMTIME) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_SYSTEMTIME_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SYSTEMTIME instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _sYSTEMTIMEInstanceType.ShouldNotBeNull();
            _sYSTEMTIMEInstance.ShouldNotBeNull();
            _sYSTEMTIMEInstanceFixture.ShouldNotBeNull();
            _sYSTEMTIMEInstance.ShouldBeAssignableTo<SYSTEMTIME>();
            _sYSTEMTIMEInstanceFixture.ShouldBeAssignableTo<SYSTEMTIME>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (SYSTEMTIME) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(short) , Propertyyear)]
        [TestCaseGeneric(typeof(short) , Propertymonth)]
        [TestCaseGeneric(typeof(short) , PropertydayOfWeek)]
        [TestCaseGeneric(typeof(short) , Propertyday)]
        [TestCaseGeneric(typeof(short) , Propertyhour)]
        [TestCaseGeneric(typeof(short) , Propertyminute)]
        [TestCaseGeneric(typeof(short) , Propertysecond)]
        [TestCaseGeneric(typeof(short) , Propertymilliseconds)]
        public void AUT_SYSTEMTIME_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<SYSTEMTIME, T>(_sYSTEMTIMEInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (SYSTEMTIME) => Property (day) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SYSTEMTIME_day_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyday);
            Action currentAction = () => propertyInfo.SetValue(_sYSTEMTIMEInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SYSTEMTIME) => Property (day) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SYSTEMTIME_Public_Class_day_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyday);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SYSTEMTIME) => Property (dayOfWeek) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SYSTEMTIME_dayOfWeek_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydayOfWeek);
            Action currentAction = () => propertyInfo.SetValue(_sYSTEMTIMEInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SYSTEMTIME) => Property (dayOfWeek) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SYSTEMTIME_Public_Class_dayOfWeek_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydayOfWeek);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SYSTEMTIME) => Property (hour) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SYSTEMTIME_hour_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyhour);
            Action currentAction = () => propertyInfo.SetValue(_sYSTEMTIMEInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SYSTEMTIME) => Property (hour) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SYSTEMTIME_Public_Class_hour_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyhour);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SYSTEMTIME) => Property (milliseconds) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SYSTEMTIME_milliseconds_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertymilliseconds);
            Action currentAction = () => propertyInfo.SetValue(_sYSTEMTIMEInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SYSTEMTIME) => Property (milliseconds) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SYSTEMTIME_Public_Class_milliseconds_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertymilliseconds);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SYSTEMTIME) => Property (minute) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SYSTEMTIME_minute_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyminute);
            Action currentAction = () => propertyInfo.SetValue(_sYSTEMTIMEInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SYSTEMTIME) => Property (minute) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SYSTEMTIME_Public_Class_minute_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyminute);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SYSTEMTIME) => Property (month) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SYSTEMTIME_month_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertymonth);
            Action currentAction = () => propertyInfo.SetValue(_sYSTEMTIMEInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SYSTEMTIME) => Property (month) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SYSTEMTIME_Public_Class_month_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertymonth);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SYSTEMTIME) => Property (second) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SYSTEMTIME_second_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertysecond);
            Action currentAction = () => propertyInfo.SetValue(_sYSTEMTIMEInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SYSTEMTIME) => Property (second) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SYSTEMTIME_Public_Class_second_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysecond);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SYSTEMTIME) => Property (year) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SYSTEMTIME_year_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyyear);
            Action currentAction = () => propertyInfo.SetValue(_sYSTEMTIMEInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SYSTEMTIME) => Property (year) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SYSTEMTIME_Public_Class_year_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyyear);

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