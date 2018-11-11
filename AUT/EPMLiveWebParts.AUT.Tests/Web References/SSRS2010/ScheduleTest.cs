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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SSRS2010.Schedule" />)
    ///     and namespace <see cref="EPMLiveWebParts.SSRS2010"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ScheduleTest : AbstractBaseSetupTypedTest<Schedule>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Schedule) Initializer

        private const string PropertyScheduleID = "ScheduleID";
        private const string PropertyName = "Name";
        private const string PropertyDefinition = "Definition";
        private const string PropertyDescription = "Description";
        private const string PropertyCreator = "Creator";
        private const string PropertyNextRunTime = "NextRunTime";
        private const string PropertyNextRunTimeSpecified = "NextRunTimeSpecified";
        private const string PropertyLastRunTime = "LastRunTime";
        private const string PropertyLastRunTimeSpecified = "LastRunTimeSpecified";
        private const string PropertyReferencesPresent = "ReferencesPresent";
        private const string PropertyScheduleStateName = "ScheduleStateName";
        private const string FieldscheduleIDField = "scheduleIDField";
        private const string FieldnameField = "nameField";
        private const string FielddefinitionField = "definitionField";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldcreatorField = "creatorField";
        private const string FieldnextRunTimeField = "nextRunTimeField";
        private const string FieldnextRunTimeFieldSpecified = "nextRunTimeFieldSpecified";
        private const string FieldlastRunTimeField = "lastRunTimeField";
        private const string FieldlastRunTimeFieldSpecified = "lastRunTimeFieldSpecified";
        private const string FieldreferencesPresentField = "referencesPresentField";
        private const string FieldscheduleStateNameField = "scheduleStateNameField";
        private Type _scheduleInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Schedule _scheduleInstance;
        private Schedule _scheduleInstanceFixture;

        #region General Initializer : Class (Schedule) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Schedule" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _scheduleInstanceType = typeof(Schedule);
            _scheduleInstanceFixture = Create(true);
            _scheduleInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Schedule)

        #region General Initializer : Class (Schedule) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Schedule" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyScheduleID)]
        [TestCase(PropertyName)]
        [TestCase(PropertyDefinition)]
        [TestCase(PropertyDescription)]
        [TestCase(PropertyCreator)]
        [TestCase(PropertyNextRunTime)]
        [TestCase(PropertyNextRunTimeSpecified)]
        [TestCase(PropertyLastRunTime)]
        [TestCase(PropertyLastRunTimeSpecified)]
        [TestCase(PropertyReferencesPresent)]
        [TestCase(PropertyScheduleStateName)]
        public void AUT_Schedule_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_scheduleInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Schedule) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Schedule" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldscheduleIDField)]
        [TestCase(FieldnameField)]
        [TestCase(FielddefinitionField)]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldcreatorField)]
        [TestCase(FieldnextRunTimeField)]
        [TestCase(FieldnextRunTimeFieldSpecified)]
        [TestCase(FieldlastRunTimeField)]
        [TestCase(FieldlastRunTimeFieldSpecified)]
        [TestCase(FieldreferencesPresentField)]
        [TestCase(FieldscheduleStateNameField)]
        public void AUT_Schedule_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_scheduleInstanceFixture, 
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
        ///     Class (<see cref="Schedule" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Schedule_Is_Instance_Present_Test()
        {
            // Assert
            _scheduleInstanceType.ShouldNotBeNull();
            _scheduleInstance.ShouldNotBeNull();
            _scheduleInstanceFixture.ShouldNotBeNull();
            _scheduleInstance.ShouldBeAssignableTo<Schedule>();
            _scheduleInstanceFixture.ShouldBeAssignableTo<Schedule>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Schedule) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Schedule_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Schedule instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _scheduleInstanceType.ShouldNotBeNull();
            _scheduleInstance.ShouldNotBeNull();
            _scheduleInstanceFixture.ShouldNotBeNull();
            _scheduleInstance.ShouldBeAssignableTo<Schedule>();
            _scheduleInstanceFixture.ShouldBeAssignableTo<Schedule>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Schedule) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyScheduleID)]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        [TestCaseGeneric(typeof(ScheduleDefinition) , PropertyDefinition)]
        [TestCaseGeneric(typeof(string) , PropertyDescription)]
        [TestCaseGeneric(typeof(string) , PropertyCreator)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertyNextRunTime)]
        [TestCaseGeneric(typeof(bool) , PropertyNextRunTimeSpecified)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertyLastRunTime)]
        [TestCaseGeneric(typeof(bool) , PropertyLastRunTimeSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyReferencesPresent)]
        [TestCaseGeneric(typeof(string) , PropertyScheduleStateName)]
        public void AUT_Schedule_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Schedule, T>(_scheduleInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Schedule) => Property (Creator) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Schedule_Public_Class_Creator_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCreator);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Schedule) => Property (Definition) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Schedule_Definition_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyDefinition);
            Action currentAction = () => propertyInfo.SetValue(_scheduleInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Schedule) => Property (Definition) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Schedule_Public_Class_Definition_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDefinition);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Schedule) => Property (Description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Schedule_Public_Class_Description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDescription);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Schedule) => Property (LastRunTime) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Schedule_LastRunTime_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyLastRunTime);
            Action currentAction = () => propertyInfo.SetValue(_scheduleInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Schedule) => Property (LastRunTime) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Schedule_Public_Class_LastRunTime_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyLastRunTime);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Schedule) => Property (LastRunTimeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Schedule_Public_Class_LastRunTimeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyLastRunTimeSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Schedule) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Schedule_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Schedule) => Property (NextRunTime) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Schedule_NextRunTime_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyNextRunTime);
            Action currentAction = () => propertyInfo.SetValue(_scheduleInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Schedule) => Property (NextRunTime) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Schedule_Public_Class_NextRunTime_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyNextRunTime);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Schedule) => Property (NextRunTimeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Schedule_Public_Class_NextRunTimeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyNextRunTimeSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Schedule) => Property (ReferencesPresent) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Schedule_Public_Class_ReferencesPresent_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyReferencesPresent);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Schedule) => Property (ScheduleID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Schedule_Public_Class_ScheduleID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyScheduleID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Schedule) => Property (ScheduleStateName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Schedule_Public_Class_ScheduleStateName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyScheduleStateName);

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