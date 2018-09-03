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
using MonthsOfYearSelector = EPMLiveCore.SSRS2005;

namespace EPMLiveCore.SSRS2005
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2005.MonthsOfYearSelector" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2005"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class MonthsOfYearSelectorTest : AbstractBaseSetupTypedTest<MonthsOfYearSelector>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (MonthsOfYearSelector) Initializer

        private const string PropertyJanuary = "January";
        private const string PropertyFebruary = "February";
        private const string PropertyMarch = "March";
        private const string PropertyApril = "April";
        private const string PropertyMay = "May";
        private const string PropertyJune = "June";
        private const string PropertyJuly = "July";
        private const string PropertyAugust = "August";
        private const string PropertySeptember = "September";
        private const string PropertyOctober = "October";
        private const string PropertyNovember = "November";
        private const string PropertyDecember = "December";
        private const string FieldjanuaryField = "januaryField";
        private const string FieldfebruaryField = "februaryField";
        private const string FieldmarchField = "marchField";
        private const string FieldaprilField = "aprilField";
        private const string FieldmayField = "mayField";
        private const string FieldjuneField = "juneField";
        private const string FieldjulyField = "julyField";
        private const string FieldaugustField = "augustField";
        private const string FieldseptemberField = "septemberField";
        private const string FieldoctoberField = "octoberField";
        private const string FieldnovemberField = "novemberField";
        private const string FielddecemberField = "decemberField";
        private Type _monthsOfYearSelectorInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private MonthsOfYearSelector _monthsOfYearSelectorInstance;
        private MonthsOfYearSelector _monthsOfYearSelectorInstanceFixture;

        #region General Initializer : Class (MonthsOfYearSelector) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="MonthsOfYearSelector" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _monthsOfYearSelectorInstanceType = typeof(MonthsOfYearSelector);
            _monthsOfYearSelectorInstanceFixture = Create(true);
            _monthsOfYearSelectorInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (MonthsOfYearSelector)

        #region General Initializer : Class (MonthsOfYearSelector) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="MonthsOfYearSelector" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyJanuary)]
        [TestCase(PropertyFebruary)]
        [TestCase(PropertyMarch)]
        [TestCase(PropertyApril)]
        [TestCase(PropertyMay)]
        [TestCase(PropertyJune)]
        [TestCase(PropertyJuly)]
        [TestCase(PropertyAugust)]
        [TestCase(PropertySeptember)]
        [TestCase(PropertyOctober)]
        [TestCase(PropertyNovember)]
        [TestCase(PropertyDecember)]
        public void AUT_MonthsOfYearSelector_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_monthsOfYearSelectorInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (MonthsOfYearSelector) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="MonthsOfYearSelector" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldjanuaryField)]
        [TestCase(FieldfebruaryField)]
        [TestCase(FieldmarchField)]
        [TestCase(FieldaprilField)]
        [TestCase(FieldmayField)]
        [TestCase(FieldjuneField)]
        [TestCase(FieldjulyField)]
        [TestCase(FieldaugustField)]
        [TestCase(FieldseptemberField)]
        [TestCase(FieldoctoberField)]
        [TestCase(FieldnovemberField)]
        [TestCase(FielddecemberField)]
        public void AUT_MonthsOfYearSelector_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_monthsOfYearSelectorInstanceFixture, 
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
        ///     Class (<see cref="MonthsOfYearSelector" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_MonthsOfYearSelector_Is_Instance_Present_Test()
        {
            // Assert
            _monthsOfYearSelectorInstanceType.ShouldNotBeNull();
            _monthsOfYearSelectorInstance.ShouldNotBeNull();
            _monthsOfYearSelectorInstanceFixture.ShouldNotBeNull();
            _monthsOfYearSelectorInstance.ShouldBeAssignableTo<MonthsOfYearSelector>();
            _monthsOfYearSelectorInstanceFixture.ShouldBeAssignableTo<MonthsOfYearSelector>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (MonthsOfYearSelector) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_MonthsOfYearSelector_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            MonthsOfYearSelector instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _monthsOfYearSelectorInstanceType.ShouldNotBeNull();
            _monthsOfYearSelectorInstance.ShouldNotBeNull();
            _monthsOfYearSelectorInstanceFixture.ShouldNotBeNull();
            _monthsOfYearSelectorInstance.ShouldBeAssignableTo<MonthsOfYearSelector>();
            _monthsOfYearSelectorInstanceFixture.ShouldBeAssignableTo<MonthsOfYearSelector>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (MonthsOfYearSelector) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyJanuary)]
        [TestCaseGeneric(typeof(bool) , PropertyFebruary)]
        [TestCaseGeneric(typeof(bool) , PropertyMarch)]
        [TestCaseGeneric(typeof(bool) , PropertyApril)]
        [TestCaseGeneric(typeof(bool) , PropertyMay)]
        [TestCaseGeneric(typeof(bool) , PropertyJune)]
        [TestCaseGeneric(typeof(bool) , PropertyJuly)]
        [TestCaseGeneric(typeof(bool) , PropertyAugust)]
        [TestCaseGeneric(typeof(bool) , PropertySeptember)]
        [TestCaseGeneric(typeof(bool) , PropertyOctober)]
        [TestCaseGeneric(typeof(bool) , PropertyNovember)]
        [TestCaseGeneric(typeof(bool) , PropertyDecember)]
        public void AUT_MonthsOfYearSelector_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<MonthsOfYearSelector, T>(_monthsOfYearSelectorInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (MonthsOfYearSelector) => Property (April) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MonthsOfYearSelector_Public_Class_April_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyApril);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MonthsOfYearSelector) => Property (August) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MonthsOfYearSelector_Public_Class_August_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyAugust);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MonthsOfYearSelector) => Property (December) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MonthsOfYearSelector_Public_Class_December_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDecember);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MonthsOfYearSelector) => Property (February) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MonthsOfYearSelector_Public_Class_February_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyFebruary);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MonthsOfYearSelector) => Property (January) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MonthsOfYearSelector_Public_Class_January_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyJanuary);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MonthsOfYearSelector) => Property (July) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MonthsOfYearSelector_Public_Class_July_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyJuly);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MonthsOfYearSelector) => Property (June) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MonthsOfYearSelector_Public_Class_June_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyJune);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MonthsOfYearSelector) => Property (March) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MonthsOfYearSelector_Public_Class_March_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyMarch);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MonthsOfYearSelector) => Property (May) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MonthsOfYearSelector_Public_Class_May_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyMay);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MonthsOfYearSelector) => Property (November) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MonthsOfYearSelector_Public_Class_November_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyNovember);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MonthsOfYearSelector) => Property (October) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MonthsOfYearSelector_Public_Class_October_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyOctober);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MonthsOfYearSelector) => Property (September) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MonthsOfYearSelector_Public_Class_September_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySeptember);

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