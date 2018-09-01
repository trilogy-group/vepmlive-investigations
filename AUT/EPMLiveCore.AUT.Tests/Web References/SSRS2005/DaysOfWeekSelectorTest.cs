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
using DaysOfWeekSelector = EPMLiveCore.SSRS2005;

namespace EPMLiveCore.SSRS2005
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2005.DaysOfWeekSelector" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2005"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DaysOfWeekSelectorTest : AbstractBaseSetupTypedTest<DaysOfWeekSelector>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DaysOfWeekSelector) Initializer

        private const string PropertySunday = "Sunday";
        private const string PropertyMonday = "Monday";
        private const string PropertyTuesday = "Tuesday";
        private const string PropertyWednesday = "Wednesday";
        private const string PropertyThursday = "Thursday";
        private const string PropertyFriday = "Friday";
        private const string PropertySaturday = "Saturday";
        private const string FieldsundayField = "sundayField";
        private const string FieldmondayField = "mondayField";
        private const string FieldtuesdayField = "tuesdayField";
        private const string FieldwednesdayField = "wednesdayField";
        private const string FieldthursdayField = "thursdayField";
        private const string FieldfridayField = "fridayField";
        private const string FieldsaturdayField = "saturdayField";
        private Type _daysOfWeekSelectorInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DaysOfWeekSelector _daysOfWeekSelectorInstance;
        private DaysOfWeekSelector _daysOfWeekSelectorInstanceFixture;

        #region General Initializer : Class (DaysOfWeekSelector) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DaysOfWeekSelector" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _daysOfWeekSelectorInstanceType = typeof(DaysOfWeekSelector);
            _daysOfWeekSelectorInstanceFixture = Create(true);
            _daysOfWeekSelectorInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DaysOfWeekSelector)

        #region General Initializer : Class (DaysOfWeekSelector) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DaysOfWeekSelector" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertySunday)]
        [TestCase(PropertyMonday)]
        [TestCase(PropertyTuesday)]
        [TestCase(PropertyWednesday)]
        [TestCase(PropertyThursday)]
        [TestCase(PropertyFriday)]
        [TestCase(PropertySaturday)]
        public void AUT_DaysOfWeekSelector_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_daysOfWeekSelectorInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DaysOfWeekSelector) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DaysOfWeekSelector" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldsundayField)]
        [TestCase(FieldmondayField)]
        [TestCase(FieldtuesdayField)]
        [TestCase(FieldwednesdayField)]
        [TestCase(FieldthursdayField)]
        [TestCase(FieldfridayField)]
        [TestCase(FieldsaturdayField)]
        public void AUT_DaysOfWeekSelector_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_daysOfWeekSelectorInstanceFixture, 
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
        ///     Class (<see cref="DaysOfWeekSelector" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DaysOfWeekSelector_Is_Instance_Present_Test()
        {
            // Assert
            _daysOfWeekSelectorInstanceType.ShouldNotBeNull();
            _daysOfWeekSelectorInstance.ShouldNotBeNull();
            _daysOfWeekSelectorInstanceFixture.ShouldNotBeNull();
            _daysOfWeekSelectorInstance.ShouldBeAssignableTo<DaysOfWeekSelector>();
            _daysOfWeekSelectorInstanceFixture.ShouldBeAssignableTo<DaysOfWeekSelector>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DaysOfWeekSelector) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DaysOfWeekSelector_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DaysOfWeekSelector instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _daysOfWeekSelectorInstanceType.ShouldNotBeNull();
            _daysOfWeekSelectorInstance.ShouldNotBeNull();
            _daysOfWeekSelectorInstanceFixture.ShouldNotBeNull();
            _daysOfWeekSelectorInstance.ShouldBeAssignableTo<DaysOfWeekSelector>();
            _daysOfWeekSelectorInstanceFixture.ShouldBeAssignableTo<DaysOfWeekSelector>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DaysOfWeekSelector) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertySunday)]
        [TestCaseGeneric(typeof(bool) , PropertyMonday)]
        [TestCaseGeneric(typeof(bool) , PropertyTuesday)]
        [TestCaseGeneric(typeof(bool) , PropertyWednesday)]
        [TestCaseGeneric(typeof(bool) , PropertyThursday)]
        [TestCaseGeneric(typeof(bool) , PropertyFriday)]
        [TestCaseGeneric(typeof(bool) , PropertySaturday)]
        public void AUT_DaysOfWeekSelector_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DaysOfWeekSelector, T>(_daysOfWeekSelectorInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DaysOfWeekSelector) => Property (Friday) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DaysOfWeekSelector_Public_Class_Friday_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyFriday);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DaysOfWeekSelector) => Property (Monday) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DaysOfWeekSelector_Public_Class_Monday_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyMonday);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DaysOfWeekSelector) => Property (Saturday) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DaysOfWeekSelector_Public_Class_Saturday_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySaturday);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DaysOfWeekSelector) => Property (Sunday) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DaysOfWeekSelector_Public_Class_Sunday_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySunday);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DaysOfWeekSelector) => Property (Thursday) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DaysOfWeekSelector_Public_Class_Thursday_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyThursday);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DaysOfWeekSelector) => Property (Tuesday) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DaysOfWeekSelector_Public_Class_Tuesday_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyTuesday);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DaysOfWeekSelector) => Property (Wednesday) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DaysOfWeekSelector_Public_Class_Wednesday_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWednesday);

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