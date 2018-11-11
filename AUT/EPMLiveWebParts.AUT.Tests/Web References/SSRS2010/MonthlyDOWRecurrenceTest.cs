using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts.SSRS2010
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SSRS2010.MonthlyDOWRecurrence" />)
    ///     and namespace <see cref="EPMLiveWebParts.SSRS2010"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class MonthlyDOWRecurrenceTest : AbstractBaseSetupTypedTest<MonthlyDOWRecurrence>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (MonthlyDOWRecurrence) Initializer

        private const string PropertyWhichWeek = "WhichWeek";
        private const string PropertyWhichWeekSpecified = "WhichWeekSpecified";
        private const string PropertyDaysOfWeek = "DaysOfWeek";
        private const string PropertyMonthsOfYear = "MonthsOfYear";
        private const string FieldwhichWeekField = "whichWeekField";
        private const string FieldwhichWeekFieldSpecified = "whichWeekFieldSpecified";
        private const string FielddaysOfWeekField = "daysOfWeekField";
        private const string FieldmonthsOfYearField = "monthsOfYearField";
        private Type _monthlyDOWRecurrenceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private MonthlyDOWRecurrence _monthlyDOWRecurrenceInstance;
        private MonthlyDOWRecurrence _monthlyDOWRecurrenceInstanceFixture;

        #region General Initializer : Class (MonthlyDOWRecurrence) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="MonthlyDOWRecurrence" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _monthlyDOWRecurrenceInstanceType = typeof(MonthlyDOWRecurrence);
            _monthlyDOWRecurrenceInstanceFixture = Create(true);
            _monthlyDOWRecurrenceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (MonthlyDOWRecurrence)

        #region General Initializer : Class (MonthlyDOWRecurrence) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="MonthlyDOWRecurrence" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyWhichWeek)]
        [TestCase(PropertyWhichWeekSpecified)]
        [TestCase(PropertyDaysOfWeek)]
        [TestCase(PropertyMonthsOfYear)]
        public void AUT_MonthlyDOWRecurrence_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_monthlyDOWRecurrenceInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (MonthlyDOWRecurrence) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="MonthlyDOWRecurrence" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldwhichWeekField)]
        [TestCase(FieldwhichWeekFieldSpecified)]
        [TestCase(FielddaysOfWeekField)]
        [TestCase(FieldmonthsOfYearField)]
        public void AUT_MonthlyDOWRecurrence_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_monthlyDOWRecurrenceInstanceFixture, 
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
        ///     Class (<see cref="MonthlyDOWRecurrence" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_MonthlyDOWRecurrence_Is_Instance_Present_Test()
        {
            // Assert
            _monthlyDOWRecurrenceInstanceType.ShouldNotBeNull();
            _monthlyDOWRecurrenceInstance.ShouldNotBeNull();
            _monthlyDOWRecurrenceInstanceFixture.ShouldNotBeNull();
            _monthlyDOWRecurrenceInstance.ShouldBeAssignableTo<MonthlyDOWRecurrence>();
            _monthlyDOWRecurrenceInstanceFixture.ShouldBeAssignableTo<MonthlyDOWRecurrence>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (MonthlyDOWRecurrence) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_MonthlyDOWRecurrence_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            MonthlyDOWRecurrence instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _monthlyDOWRecurrenceInstanceType.ShouldNotBeNull();
            _monthlyDOWRecurrenceInstance.ShouldNotBeNull();
            _monthlyDOWRecurrenceInstanceFixture.ShouldNotBeNull();
            _monthlyDOWRecurrenceInstance.ShouldBeAssignableTo<MonthlyDOWRecurrence>();
            _monthlyDOWRecurrenceInstanceFixture.ShouldBeAssignableTo<MonthlyDOWRecurrence>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (MonthlyDOWRecurrence) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(WeekNumberEnum) , PropertyWhichWeek)]
        [TestCaseGeneric(typeof(bool) , PropertyWhichWeekSpecified)]
        [TestCaseGeneric(typeof(DaysOfWeekSelector) , PropertyDaysOfWeek)]
        [TestCaseGeneric(typeof(MonthsOfYearSelector) , PropertyMonthsOfYear)]
        public void AUT_MonthlyDOWRecurrence_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<MonthlyDOWRecurrence, T>(_monthlyDOWRecurrenceInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (MonthlyDOWRecurrence) => Property (DaysOfWeek) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MonthlyDOWRecurrence_DaysOfWeek_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyDaysOfWeek);
            Action currentAction = () => propertyInfo.SetValue(_monthlyDOWRecurrenceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (MonthlyDOWRecurrence) => Property (DaysOfWeek) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MonthlyDOWRecurrence_Public_Class_DaysOfWeek_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDaysOfWeek);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MonthlyDOWRecurrence) => Property (MonthsOfYear) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MonthlyDOWRecurrence_MonthsOfYear_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyMonthsOfYear);
            Action currentAction = () => propertyInfo.SetValue(_monthlyDOWRecurrenceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (MonthlyDOWRecurrence) => Property (MonthsOfYear) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MonthlyDOWRecurrence_Public_Class_MonthsOfYear_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (MonthlyDOWRecurrence) => Property (WhichWeek) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MonthlyDOWRecurrence_WhichWeek_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyWhichWeek);
            Action currentAction = () => propertyInfo.SetValue(_monthlyDOWRecurrenceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (MonthlyDOWRecurrence) => Property (WhichWeek) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MonthlyDOWRecurrence_Public_Class_WhichWeek_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWhichWeek);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MonthlyDOWRecurrence) => Property (WhichWeekSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MonthlyDOWRecurrence_Public_Class_WhichWeekSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWhichWeekSpecified);

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