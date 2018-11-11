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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Core.Entities.WorkSchedule" />)
    ///     and namespace <see cref="WorkEnginePPM.Core.Entities"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class WorkScheduleTest : AbstractBaseSetupTypedTest<WorkSchedule>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WorkSchedule) Initializer

        private const string PropertyExtId = "ExtId";
        private const string PropertyFriday = "Friday";
        private const string PropertyId = "Id";
        private const string PropertyIsDefault = "IsDefault";
        private const string PropertyMonday = "Monday";
        private const string PropertySaturday = "Saturday";
        private const string PropertySunday = "Sunday";
        private const string PropertyThursday = "Thursday";
        private const string PropertyTitle = "Title";
        private const string PropertyTuesday = "Tuesday";
        private const string PropertyUniqueId = "UniqueId";
        private const string PropertyWednesday = "Wednesday";
        private Type _workScheduleInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WorkSchedule _workScheduleInstance;
        private WorkSchedule _workScheduleInstanceFixture;

        #region General Initializer : Class (WorkSchedule) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkSchedule" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workScheduleInstanceType = typeof(WorkSchedule);
            _workScheduleInstanceFixture = Create(true);
            _workScheduleInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkSchedule)

        #region General Initializer : Class (WorkSchedule) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkSchedule" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyExtId)]
        [TestCase(PropertyFriday)]
        [TestCase(PropertyId)]
        [TestCase(PropertyIsDefault)]
        [TestCase(PropertyMonday)]
        [TestCase(PropertySaturday)]
        [TestCase(PropertySunday)]
        [TestCase(PropertyThursday)]
        [TestCase(PropertyTitle)]
        [TestCase(PropertyTuesday)]
        [TestCase(PropertyUniqueId)]
        [TestCase(PropertyWednesday)]
        public void AUT_WorkSchedule_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_workScheduleInstanceFixture,
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
        ///     Class (<see cref="WorkSchedule" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_WorkSchedule_Is_Instance_Present_Test()
        {
            // Assert
            _workScheduleInstanceType.ShouldNotBeNull();
            _workScheduleInstance.ShouldNotBeNull();
            _workScheduleInstanceFixture.ShouldNotBeNull();
            _workScheduleInstance.ShouldBeAssignableTo<WorkSchedule>();
            _workScheduleInstanceFixture.ShouldBeAssignableTo<WorkSchedule>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WorkSchedule) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_WorkSchedule_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WorkSchedule instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _workScheduleInstanceType.ShouldNotBeNull();
            _workScheduleInstance.ShouldNotBeNull();
            _workScheduleInstanceFixture.ShouldNotBeNull();
            _workScheduleInstance.ShouldBeAssignableTo<WorkSchedule>();
            _workScheduleInstanceFixture.ShouldBeAssignableTo<WorkSchedule>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (WorkSchedule) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyExtId)]
        [TestCaseGeneric(typeof(decimal) , PropertyFriday)]
        [TestCaseGeneric(typeof(int?) , PropertyId)]
        [TestCaseGeneric(typeof(bool) , PropertyIsDefault)]
        [TestCaseGeneric(typeof(decimal) , PropertyMonday)]
        [TestCaseGeneric(typeof(decimal) , PropertySaturday)]
        [TestCaseGeneric(typeof(decimal) , PropertySunday)]
        [TestCaseGeneric(typeof(decimal) , PropertyThursday)]
        [TestCaseGeneric(typeof(string) , PropertyTitle)]
        [TestCaseGeneric(typeof(decimal) , PropertyTuesday)]
        [TestCaseGeneric(typeof(Guid) , PropertyUniqueId)]
        [TestCaseGeneric(typeof(decimal) , PropertyWednesday)]
        public void AUT_WorkSchedule_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<WorkSchedule, T>(_workScheduleInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (WorkSchedule) => Property (ExtId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkSchedule_Public_Class_ExtId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkSchedule) => Property (Friday) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkSchedule_Public_Class_Friday_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkSchedule) => Property (Id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkSchedule_Public_Class_Id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkSchedule) => Property (IsDefault) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkSchedule_Public_Class_IsDefault_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkSchedule) => Property (Monday) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkSchedule_Public_Class_Monday_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkSchedule) => Property (Saturday) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkSchedule_Public_Class_Saturday_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkSchedule) => Property (Sunday) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkSchedule_Public_Class_Sunday_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkSchedule) => Property (Thursday) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkSchedule_Public_Class_Thursday_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkSchedule) => Property (Title) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkSchedule_Public_Class_Title_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkSchedule) => Property (Tuesday) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkSchedule_Public_Class_Tuesday_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkSchedule) => Property (UniqueId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkSchedule_UniqueId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyUniqueId);
            Action currentAction = () => propertyInfo.SetValue(_workScheduleInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkSchedule) => Property (UniqueId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkSchedule_Public_Class_UniqueId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkSchedule) => Property (Wednesday) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkSchedule_Public_Class_Wednesday_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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