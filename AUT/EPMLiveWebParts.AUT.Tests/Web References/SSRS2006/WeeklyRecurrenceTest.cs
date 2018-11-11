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

namespace EPMLiveWebParts.SSRS2006
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SSRS2006.WeeklyRecurrence" />)
    ///     and namespace <see cref="EPMLiveWebParts.SSRS2006"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class WeeklyRecurrenceTest : AbstractBaseSetupTypedTest<WeeklyRecurrence>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WeeklyRecurrence) Initializer

        private const string PropertyWeeksInterval = "WeeksInterval";
        private const string PropertyWeeksIntervalSpecified = "WeeksIntervalSpecified";
        private const string PropertyDaysOfWeek = "DaysOfWeek";
        private const string FieldweeksIntervalField = "weeksIntervalField";
        private const string FieldweeksIntervalFieldSpecified = "weeksIntervalFieldSpecified";
        private const string FielddaysOfWeekField = "daysOfWeekField";
        private Type _weeklyRecurrenceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WeeklyRecurrence _weeklyRecurrenceInstance;
        private WeeklyRecurrence _weeklyRecurrenceInstanceFixture;

        #region General Initializer : Class (WeeklyRecurrence) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WeeklyRecurrence" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _weeklyRecurrenceInstanceType = typeof(WeeklyRecurrence);
            _weeklyRecurrenceInstanceFixture = Create(true);
            _weeklyRecurrenceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WeeklyRecurrence)

        #region General Initializer : Class (WeeklyRecurrence) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="WeeklyRecurrence" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyWeeksInterval)]
        [TestCase(PropertyWeeksIntervalSpecified)]
        [TestCase(PropertyDaysOfWeek)]
        public void AUT_WeeklyRecurrence_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_weeklyRecurrenceInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WeeklyRecurrence) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WeeklyRecurrence" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldweeksIntervalField)]
        [TestCase(FieldweeksIntervalFieldSpecified)]
        [TestCase(FielddaysOfWeekField)]
        public void AUT_WeeklyRecurrence_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_weeklyRecurrenceInstanceFixture, 
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
        ///     Class (<see cref="WeeklyRecurrence" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_WeeklyRecurrence_Is_Instance_Present_Test()
        {
            // Assert
            _weeklyRecurrenceInstanceType.ShouldNotBeNull();
            _weeklyRecurrenceInstance.ShouldNotBeNull();
            _weeklyRecurrenceInstanceFixture.ShouldNotBeNull();
            _weeklyRecurrenceInstance.ShouldBeAssignableTo<WeeklyRecurrence>();
            _weeklyRecurrenceInstanceFixture.ShouldBeAssignableTo<WeeklyRecurrence>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WeeklyRecurrence) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_WeeklyRecurrence_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WeeklyRecurrence instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _weeklyRecurrenceInstanceType.ShouldNotBeNull();
            _weeklyRecurrenceInstance.ShouldNotBeNull();
            _weeklyRecurrenceInstanceFixture.ShouldNotBeNull();
            _weeklyRecurrenceInstance.ShouldBeAssignableTo<WeeklyRecurrence>();
            _weeklyRecurrenceInstanceFixture.ShouldBeAssignableTo<WeeklyRecurrence>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (WeeklyRecurrence) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(int) , PropertyWeeksInterval)]
        [TestCaseGeneric(typeof(bool) , PropertyWeeksIntervalSpecified)]
        [TestCaseGeneric(typeof(DaysOfWeekSelector) , PropertyDaysOfWeek)]
        public void AUT_WeeklyRecurrence_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<WeeklyRecurrence, T>(_weeklyRecurrenceInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (WeeklyRecurrence) => Property (DaysOfWeek) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WeeklyRecurrence_DaysOfWeek_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyDaysOfWeek);
            Action currentAction = () => propertyInfo.SetValue(_weeklyRecurrenceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WeeklyRecurrence) => Property (DaysOfWeek) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WeeklyRecurrence_Public_Class_DaysOfWeek_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WeeklyRecurrence) => Property (WeeksInterval) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WeeklyRecurrence_Public_Class_WeeksInterval_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWeeksInterval);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WeeklyRecurrence) => Property (WeeksIntervalSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WeeklyRecurrence_Public_Class_WeeksIntervalSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWeeksIntervalSpecified);

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