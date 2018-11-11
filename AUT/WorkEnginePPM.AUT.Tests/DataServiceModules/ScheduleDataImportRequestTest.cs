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

namespace WorkEnginePPM.DataServiceModules
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.DataServiceModules.ScheduleDataImportRequest" />)
    ///     and namespace <see cref="WorkEnginePPM.DataServiceModules"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ScheduleDataImportRequestTest : AbstractBaseSetupTypedTest<ScheduleDataImportRequest>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ScheduleDataImportRequest) Initializer

        private const string PropertyModule = "Module";
        private const string PropertyListId = "ListId";
        private const string PropertyFileId = "FileId";
        private const string PropertyOptions = "Options";
        private Type _scheduleDataImportRequestInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ScheduleDataImportRequest _scheduleDataImportRequestInstance;
        private ScheduleDataImportRequest _scheduleDataImportRequestInstanceFixture;

        #region General Initializer : Class (ScheduleDataImportRequest) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ScheduleDataImportRequest" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _scheduleDataImportRequestInstanceType = typeof(ScheduleDataImportRequest);
            _scheduleDataImportRequestInstanceFixture = Create(true);
            _scheduleDataImportRequestInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ScheduleDataImportRequest)

        #region General Initializer : Class (ScheduleDataImportRequest) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ScheduleDataImportRequest" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyModule)]
        [TestCase(PropertyListId)]
        [TestCase(PropertyFileId)]
        [TestCase(PropertyOptions)]
        public void AUT_ScheduleDataImportRequest_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_scheduleDataImportRequestInstanceFixture,
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
        ///     Class (<see cref="ScheduleDataImportRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ScheduleDataImportRequest_Is_Instance_Present_Test()
        {
            // Assert
            _scheduleDataImportRequestInstanceType.ShouldNotBeNull();
            _scheduleDataImportRequestInstance.ShouldNotBeNull();
            _scheduleDataImportRequestInstanceFixture.ShouldNotBeNull();
            _scheduleDataImportRequestInstance.ShouldBeAssignableTo<ScheduleDataImportRequest>();
            _scheduleDataImportRequestInstanceFixture.ShouldBeAssignableTo<ScheduleDataImportRequest>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ScheduleDataImportRequest) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ScheduleDataImportRequest_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ScheduleDataImportRequest instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _scheduleDataImportRequestInstanceType.ShouldNotBeNull();
            _scheduleDataImportRequestInstance.ShouldNotBeNull();
            _scheduleDataImportRequestInstanceFixture.ShouldNotBeNull();
            _scheduleDataImportRequestInstance.ShouldBeAssignableTo<ScheduleDataImportRequest>();
            _scheduleDataImportRequestInstanceFixture.ShouldBeAssignableTo<ScheduleDataImportRequest>();
        }

        #endregion

        #region General Constructor : Class (ScheduleDataImportRequest) Default Assignment Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ScheduleDataImportRequest_Constructor_Instantiated_With_Default_Assignments_Test()
        {

            // Act
            var scheduleDataImportRequestInstance  = new ScheduleDataImportRequest();

            // Asserts
            scheduleDataImportRequestInstance.ShouldNotBeNull();
            scheduleDataImportRequestInstance.ShouldBeAssignableTo<ScheduleDataImportRequest>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ScheduleDataImportRequest) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(DSMModule) , PropertyModule)]
        [TestCaseGeneric(typeof(Guid) , PropertyListId)]
        [TestCaseGeneric(typeof(Guid) , PropertyFileId)]
        [TestCaseGeneric(typeof(List<KeyValuePair<string, string>>) , PropertyOptions)]
        public void AUT_ScheduleDataImportRequest_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ScheduleDataImportRequest, T>(_scheduleDataImportRequestInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ScheduleDataImportRequest) => Property (FileId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ScheduleDataImportRequest_FileId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyFileId);
            Action currentAction = () => propertyInfo.SetValue(_scheduleDataImportRequestInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ScheduleDataImportRequest) => Property (FileId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ScheduleDataImportRequest_Public_Class_FileId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyFileId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ScheduleDataImportRequest) => Property (ListId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ScheduleDataImportRequest_ListId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyListId);
            Action currentAction = () => propertyInfo.SetValue(_scheduleDataImportRequestInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ScheduleDataImportRequest) => Property (ListId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ScheduleDataImportRequest_Public_Class_ListId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyListId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ScheduleDataImportRequest) => Property (Module) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ScheduleDataImportRequest_Module_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyModule);
            Action currentAction = () => propertyInfo.SetValue(_scheduleDataImportRequestInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ScheduleDataImportRequest) => Property (Module) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ScheduleDataImportRequest_Public_Class_Module_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyModule);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ScheduleDataImportRequest) => Property (Options) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ScheduleDataImportRequest_Public_Class_Options_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyOptions);

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