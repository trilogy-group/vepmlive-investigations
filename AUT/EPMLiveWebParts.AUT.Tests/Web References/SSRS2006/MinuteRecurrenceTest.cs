using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveWebParts.SSRS2006
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SSRS2006.MinuteRecurrence" />)
    ///     and namespace <see cref="EPMLiveWebParts.SSRS2006"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class MinuteRecurrenceTest : AbstractBaseSetupTypedTest<MinuteRecurrence>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (MinuteRecurrence) Initializer

        private const string PropertyMinutesInterval = "MinutesInterval";
        private const string FieldminutesIntervalField = "minutesIntervalField";
        private Type _minuteRecurrenceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private MinuteRecurrence _minuteRecurrenceInstance;
        private MinuteRecurrence _minuteRecurrenceInstanceFixture;

        #region General Initializer : Class (MinuteRecurrence) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="MinuteRecurrence" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _minuteRecurrenceInstanceType = typeof(MinuteRecurrence);
            _minuteRecurrenceInstanceFixture = Create(true);
            _minuteRecurrenceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (MinuteRecurrence)

        #region General Initializer : Class (MinuteRecurrence) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="MinuteRecurrence" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyMinutesInterval)]
        public void AUT_MinuteRecurrence_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_minuteRecurrenceInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (MinuteRecurrence) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="MinuteRecurrence" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldminutesIntervalField)]
        public void AUT_MinuteRecurrence_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_minuteRecurrenceInstanceFixture, 
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
        ///     Class (<see cref="MinuteRecurrence" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_MinuteRecurrence_Is_Instance_Present_Test()
        {
            // Assert
            _minuteRecurrenceInstanceType.ShouldNotBeNull();
            _minuteRecurrenceInstance.ShouldNotBeNull();
            _minuteRecurrenceInstanceFixture.ShouldNotBeNull();
            _minuteRecurrenceInstance.ShouldBeAssignableTo<MinuteRecurrence>();
            _minuteRecurrenceInstanceFixture.ShouldBeAssignableTo<MinuteRecurrence>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (MinuteRecurrence) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_MinuteRecurrence_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            MinuteRecurrence instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _minuteRecurrenceInstanceType.ShouldNotBeNull();
            _minuteRecurrenceInstance.ShouldNotBeNull();
            _minuteRecurrenceInstanceFixture.ShouldNotBeNull();
            _minuteRecurrenceInstance.ShouldBeAssignableTo<MinuteRecurrence>();
            _minuteRecurrenceInstanceFixture.ShouldBeAssignableTo<MinuteRecurrence>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (MinuteRecurrence) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(int) , PropertyMinutesInterval)]
        public void AUT_MinuteRecurrence_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<MinuteRecurrence, T>(_minuteRecurrenceInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (MinuteRecurrence) => Property (MinutesInterval) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MinuteRecurrence_Public_Class_MinutesInterval_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyMinutesInterval);

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