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
using MonthlyRecurrence = EPMLiveCore.SSRS2006;

namespace EPMLiveCore.SSRS2006
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2006.MonthlyRecurrence" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2006"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class MonthlyRecurrenceTest : AbstractBaseSetupTypedTest<MonthlyRecurrence>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (MonthlyRecurrence) Initializer

        private const string PropertyDays = "Days";
        private const string PropertyMonthsOfYear = "MonthsOfYear";
        private const string FielddaysField = "daysField";
        private const string FieldmonthsOfYearField = "monthsOfYearField";
        private Type _monthlyRecurrenceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private MonthlyRecurrence _monthlyRecurrenceInstance;
        private MonthlyRecurrence _monthlyRecurrenceInstanceFixture;

        #region General Initializer : Class (MonthlyRecurrence) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="MonthlyRecurrence" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _monthlyRecurrenceInstanceType = typeof(MonthlyRecurrence);
            _monthlyRecurrenceInstanceFixture = Create(true);
            _monthlyRecurrenceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (MonthlyRecurrence)

        #region General Initializer : Class (MonthlyRecurrence) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="MonthlyRecurrence" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyDays)]
        [TestCase(PropertyMonthsOfYear)]
        public void AUT_MonthlyRecurrence_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_monthlyRecurrenceInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (MonthlyRecurrence) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="MonthlyRecurrence" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddaysField)]
        [TestCase(FieldmonthsOfYearField)]
        public void AUT_MonthlyRecurrence_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_monthlyRecurrenceInstanceFixture, 
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
        ///     Class (<see cref="MonthlyRecurrence" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_MonthlyRecurrence_Is_Instance_Present_Test()
        {
            // Assert
            _monthlyRecurrenceInstanceType.ShouldNotBeNull();
            _monthlyRecurrenceInstance.ShouldNotBeNull();
            _monthlyRecurrenceInstanceFixture.ShouldNotBeNull();
            _monthlyRecurrenceInstance.ShouldBeAssignableTo<MonthlyRecurrence>();
            _monthlyRecurrenceInstanceFixture.ShouldBeAssignableTo<MonthlyRecurrence>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (MonthlyRecurrence) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_MonthlyRecurrence_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            MonthlyRecurrence instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _monthlyRecurrenceInstanceType.ShouldNotBeNull();
            _monthlyRecurrenceInstance.ShouldNotBeNull();
            _monthlyRecurrenceInstanceFixture.ShouldNotBeNull();
            _monthlyRecurrenceInstance.ShouldBeAssignableTo<MonthlyRecurrence>();
            _monthlyRecurrenceInstanceFixture.ShouldBeAssignableTo<MonthlyRecurrence>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (MonthlyRecurrence) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyDays)]
        [TestCaseGeneric(typeof(MonthsOfYearSelector) , PropertyMonthsOfYear)]
        public void AUT_MonthlyRecurrence_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<MonthlyRecurrence, T>(_monthlyRecurrenceInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (MonthlyRecurrence) => Property (Days) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MonthlyRecurrence_Public_Class_Days_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDays);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MonthlyRecurrence) => Property (MonthsOfYear) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MonthlyRecurrence_MonthsOfYear_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyMonthsOfYear);
            Action currentAction = () => propertyInfo.SetValue(_monthlyRecurrenceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (MonthlyRecurrence) => Property (MonthsOfYear) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MonthlyRecurrence_Public_Class_MonthsOfYear_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyMonthsOfYear);

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