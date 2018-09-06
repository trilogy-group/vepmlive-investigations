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

namespace WorkEnginePPM.DataServiceModules
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.DataServiceModules.ScheduleDataImportResponse" />)
    ///     and namespace <see cref="WorkEnginePPM.DataServiceModules"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ScheduleDataImportResponseTest : AbstractBaseSetupTypedTest<ScheduleDataImportResponse>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ScheduleDataImportResponse) Initializer

        private const string PropertyJobId = "JobId";
        private Type _scheduleDataImportResponseInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ScheduleDataImportResponse _scheduleDataImportResponseInstance;
        private ScheduleDataImportResponse _scheduleDataImportResponseInstanceFixture;

        #region General Initializer : Class (ScheduleDataImportResponse) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ScheduleDataImportResponse" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _scheduleDataImportResponseInstanceType = typeof(ScheduleDataImportResponse);
            _scheduleDataImportResponseInstanceFixture = Create(true);
            _scheduleDataImportResponseInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ScheduleDataImportResponse)

        #region General Initializer : Class (ScheduleDataImportResponse) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ScheduleDataImportResponse" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyJobId)]
        public void AUT_ScheduleDataImportResponse_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_scheduleDataImportResponseInstanceFixture,
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
        ///     Class (<see cref="ScheduleDataImportResponse" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ScheduleDataImportResponse_Is_Instance_Present_Test()
        {
            // Assert
            _scheduleDataImportResponseInstanceType.ShouldNotBeNull();
            _scheduleDataImportResponseInstance.ShouldNotBeNull();
            _scheduleDataImportResponseInstanceFixture.ShouldNotBeNull();
            _scheduleDataImportResponseInstance.ShouldBeAssignableTo<ScheduleDataImportResponse>();
            _scheduleDataImportResponseInstanceFixture.ShouldBeAssignableTo<ScheduleDataImportResponse>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ScheduleDataImportResponse) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ScheduleDataImportResponse_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ScheduleDataImportResponse instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _scheduleDataImportResponseInstanceType.ShouldNotBeNull();
            _scheduleDataImportResponseInstance.ShouldNotBeNull();
            _scheduleDataImportResponseInstanceFixture.ShouldNotBeNull();
            _scheduleDataImportResponseInstance.ShouldBeAssignableTo<ScheduleDataImportResponse>();
            _scheduleDataImportResponseInstanceFixture.ShouldBeAssignableTo<ScheduleDataImportResponse>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ScheduleDataImportResponse) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(Guid) , PropertyJobId)]
        public void AUT_ScheduleDataImportResponse_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ScheduleDataImportResponse, T>(_scheduleDataImportResponseInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ScheduleDataImportResponse) => Property (JobId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ScheduleDataImportResponse_JobId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyJobId);
            Action currentAction = () => propertyInfo.SetValue(_scheduleDataImportResponseInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ScheduleDataImportResponse) => Property (JobId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ScheduleDataImportResponse_Public_Class_JobId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyJobId);

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