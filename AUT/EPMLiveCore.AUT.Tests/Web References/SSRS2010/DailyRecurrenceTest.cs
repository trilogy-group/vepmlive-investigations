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
using DailyRecurrence = EPMLiveCore.SSRS2010;

namespace EPMLiveCore.SSRS2010
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2010.DailyRecurrence" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2010"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DailyRecurrenceTest : AbstractBaseSetupTypedTest<DailyRecurrence>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DailyRecurrence) Initializer

        private const string PropertyDaysInterval = "DaysInterval";
        private const string FielddaysIntervalField = "daysIntervalField";
        private Type _dailyRecurrenceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DailyRecurrence _dailyRecurrenceInstance;
        private DailyRecurrence _dailyRecurrenceInstanceFixture;

        #region General Initializer : Class (DailyRecurrence) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DailyRecurrence" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dailyRecurrenceInstanceType = typeof(DailyRecurrence);
            _dailyRecurrenceInstanceFixture = Create(true);
            _dailyRecurrenceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DailyRecurrence)

        #region General Initializer : Class (DailyRecurrence) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DailyRecurrence" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyDaysInterval)]
        public void AUT_DailyRecurrence_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_dailyRecurrenceInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DailyRecurrence) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DailyRecurrence" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddaysIntervalField)]
        public void AUT_DailyRecurrence_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_dailyRecurrenceInstanceFixture, 
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
        ///     Class (<see cref="DailyRecurrence" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DailyRecurrence_Is_Instance_Present_Test()
        {
            // Assert
            _dailyRecurrenceInstanceType.ShouldNotBeNull();
            _dailyRecurrenceInstance.ShouldNotBeNull();
            _dailyRecurrenceInstanceFixture.ShouldNotBeNull();
            _dailyRecurrenceInstance.ShouldBeAssignableTo<DailyRecurrence>();
            _dailyRecurrenceInstanceFixture.ShouldBeAssignableTo<DailyRecurrence>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DailyRecurrence) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DailyRecurrence_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DailyRecurrence instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _dailyRecurrenceInstanceType.ShouldNotBeNull();
            _dailyRecurrenceInstance.ShouldNotBeNull();
            _dailyRecurrenceInstanceFixture.ShouldNotBeNull();
            _dailyRecurrenceInstance.ShouldBeAssignableTo<DailyRecurrence>();
            _dailyRecurrenceInstanceFixture.ShouldBeAssignableTo<DailyRecurrence>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DailyRecurrence) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(int) , PropertyDaysInterval)]
        public void AUT_DailyRecurrence_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DailyRecurrence, T>(_dailyRecurrenceInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DailyRecurrence) => Property (DaysInterval) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DailyRecurrence_Public_Class_DaysInterval_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDaysInterval);

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