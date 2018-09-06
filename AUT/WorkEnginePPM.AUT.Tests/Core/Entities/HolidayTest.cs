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

namespace WorkEnginePPM.Core.Entities
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Core.Entities.Holiday" />)
    ///     and namespace <see cref="WorkEnginePPM.Core.Entities"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class HolidayTest : AbstractBaseSetupTypedTest<Holiday>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Holiday) Initializer

        private const string PropertyDate = "Date";
        private const string PropertyHours = "Hours";
        private const string PropertyId = "Id";
        private const string PropertyTitle = "Title";
        private const string PropertyUniqueId = "UniqueId";
        private Type _holidayInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Holiday _holidayInstance;
        private Holiday _holidayInstanceFixture;

        #region General Initializer : Class (Holiday) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Holiday" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _holidayInstanceType = typeof(Holiday);
            _holidayInstanceFixture = Create(true);
            _holidayInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Holiday)

        #region General Initializer : Class (Holiday) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Holiday" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyDate)]
        [TestCase(PropertyHours)]
        [TestCase(PropertyId)]
        [TestCase(PropertyTitle)]
        [TestCase(PropertyUniqueId)]
        public void AUT_Holiday_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_holidayInstanceFixture,
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
        ///     Class (<see cref="Holiday" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Holiday_Is_Instance_Present_Test()
        {
            // Assert
            _holidayInstanceType.ShouldNotBeNull();
            _holidayInstance.ShouldNotBeNull();
            _holidayInstanceFixture.ShouldNotBeNull();
            _holidayInstance.ShouldBeAssignableTo<Holiday>();
            _holidayInstanceFixture.ShouldBeAssignableTo<Holiday>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Holiday) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Holiday_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Holiday instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _holidayInstanceType.ShouldNotBeNull();
            _holidayInstance.ShouldNotBeNull();
            _holidayInstanceFixture.ShouldNotBeNull();
            _holidayInstance.ShouldBeAssignableTo<Holiday>();
            _holidayInstanceFixture.ShouldBeAssignableTo<Holiday>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Holiday) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyDate)]
        [TestCaseGeneric(typeof(double) , PropertyHours)]
        [TestCaseGeneric(typeof(int) , PropertyId)]
        [TestCaseGeneric(typeof(string) , PropertyTitle)]
        [TestCaseGeneric(typeof(Guid) , PropertyUniqueId)]
        public void AUT_Holiday_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Holiday, T>(_holidayInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Holiday) => Property (Date) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Holiday_Public_Class_Date_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Holiday) => Property (Hours) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Holiday_Public_Class_Hours_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyHours);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Holiday) => Property (Id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Holiday_Public_Class_Id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Holiday) => Property (Title) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Holiday_Public_Class_Title_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Holiday) => Property (UniqueId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Holiday_UniqueId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyUniqueId);
            Action currentAction = () => propertyInfo.SetValue(_holidayInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Holiday) => Property (UniqueId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Holiday_Public_Class_UniqueId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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