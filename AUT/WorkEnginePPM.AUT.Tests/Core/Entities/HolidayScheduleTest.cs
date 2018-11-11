using System;
using System.Collections.Generic;
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

namespace WorkEnginePPM.Core.Entities
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Core.Entities.HolidaySchedule" />)
    ///     and namespace <see cref="WorkEnginePPM.Core.Entities"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class HolidayScheduleTest : AbstractBaseSetupTypedTest<HolidaySchedule>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (HolidaySchedule) Initializer

        private const string PropertyExtId = "ExtId";
        private const string PropertyHolidays = "Holidays";
        private const string PropertyId = "Id";
        private const string PropertyIsDefault = "IsDefault";
        private const string PropertyTitle = "Title";
        private const string PropertyUniqueId = "UniqueId";
        private Type _holidayScheduleInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private HolidaySchedule _holidayScheduleInstance;
        private HolidaySchedule _holidayScheduleInstanceFixture;

        #region General Initializer : Class (HolidaySchedule) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="HolidaySchedule" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _holidayScheduleInstanceType = typeof(HolidaySchedule);
            _holidayScheduleInstanceFixture = Create(true);
            _holidayScheduleInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (HolidaySchedule)

        #region General Initializer : Class (HolidaySchedule) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="HolidaySchedule" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyExtId)]
        [TestCase(PropertyHolidays)]
        [TestCase(PropertyId)]
        [TestCase(PropertyIsDefault)]
        [TestCase(PropertyTitle)]
        [TestCase(PropertyUniqueId)]
        public void AUT_HolidaySchedule_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_holidayScheduleInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="HolidaySchedule" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_HolidaySchedule_Is_Instance_Present_Test()
        {
            // Assert
            _holidayScheduleInstanceType.ShouldNotBeNull();
            _holidayScheduleInstance.ShouldNotBeNull();
            _holidayScheduleInstanceFixture.ShouldNotBeNull();
            _holidayScheduleInstance.ShouldBeAssignableTo<HolidaySchedule>();
            _holidayScheduleInstanceFixture.ShouldBeAssignableTo<HolidaySchedule>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (HolidaySchedule) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_HolidaySchedule_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            HolidaySchedule instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _holidayScheduleInstanceType.ShouldNotBeNull();
            _holidayScheduleInstance.ShouldNotBeNull();
            _holidayScheduleInstanceFixture.ShouldNotBeNull();
            _holidayScheduleInstance.ShouldBeAssignableTo<HolidaySchedule>();
            _holidayScheduleInstanceFixture.ShouldBeAssignableTo<HolidaySchedule>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (HolidaySchedule) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyExtId)]
        [TestCaseGeneric(typeof(List<Holiday>) , PropertyHolidays)]
        [TestCaseGeneric(typeof(int?) , PropertyId)]
        [TestCaseGeneric(typeof(bool) , PropertyIsDefault)]
        [TestCaseGeneric(typeof(string) , PropertyTitle)]
        [TestCaseGeneric(typeof(Guid) , PropertyUniqueId)]
        public void AUT_HolidaySchedule_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<HolidaySchedule, T>(_holidayScheduleInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (HolidaySchedule) => Property (ExtId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_HolidaySchedule_Public_Class_ExtId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyExtId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (HolidaySchedule) => Property (Holidays) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_HolidaySchedule_Public_Class_Holidays_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyHolidays);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (HolidaySchedule) => Property (Id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_HolidaySchedule_Public_Class_Id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (HolidaySchedule) => Property (IsDefault) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_HolidaySchedule_Public_Class_IsDefault_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyIsDefault);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (HolidaySchedule) => Property (Title) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_HolidaySchedule_Public_Class_Title_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyTitle);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (HolidaySchedule) => Property (UniqueId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_HolidaySchedule_UniqueId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyUniqueId);
            Action currentAction = () => propertyInfo.SetValue(_holidayScheduleInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (HolidaySchedule) => Property (UniqueId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_HolidaySchedule_Public_Class_UniqueId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUniqueId);

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