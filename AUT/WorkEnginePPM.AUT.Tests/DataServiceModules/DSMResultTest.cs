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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.DataServiceModules.DSMResult" />)
    ///     and namespace <see cref="WorkEnginePPM.DataServiceModules"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class DSMResultTest : AbstractBaseSetupTypedTest<DSMResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DSMResult) Initializer

        private const string PropertyCurrentProcess = "CurrentProcess";
        private const string PropertyTotalRecords = "TotalRecords";
        private const string PropertyPercentComplete = "PercentComplete";
        private const string PropertyProcessedRecords = "ProcessedRecords";
        private const string PropertySuccessRecords = "SuccessRecords";
        private const string PropertyFailedRecords = "FailedRecords";
        private const string PropertyLog = "Log";
        private Type _dSMResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DSMResult _dSMResultInstance;
        private DSMResult _dSMResultInstanceFixture;

        #region General Initializer : Class (DSMResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DSMResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dSMResultInstanceType = typeof(DSMResult);
            _dSMResultInstanceFixture = Create(true);
            _dSMResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DSMResult)

        #region General Initializer : Class (DSMResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DSMResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyCurrentProcess)]
        [TestCase(PropertyTotalRecords)]
        [TestCase(PropertyPercentComplete)]
        [TestCase(PropertyProcessedRecords)]
        [TestCase(PropertySuccessRecords)]
        [TestCase(PropertyFailedRecords)]
        [TestCase(PropertyLog)]
        public void AUT_DSMResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_dSMResultInstanceFixture,
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
        ///     Class (<see cref="DSMResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_DSMResult_Is_Instance_Present_Test()
        {
            // Assert
            _dSMResultInstanceType.ShouldNotBeNull();
            _dSMResultInstance.ShouldNotBeNull();
            _dSMResultInstanceFixture.ShouldNotBeNull();
            _dSMResultInstance.ShouldBeAssignableTo<DSMResult>();
            _dSMResultInstanceFixture.ShouldBeAssignableTo<DSMResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DSMResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_DSMResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DSMResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _dSMResultInstanceType.ShouldNotBeNull();
            _dSMResultInstance.ShouldNotBeNull();
            _dSMResultInstanceFixture.ShouldNotBeNull();
            _dSMResultInstance.ShouldBeAssignableTo<DSMResult>();
            _dSMResultInstanceFixture.ShouldBeAssignableTo<DSMResult>();
        }

        #endregion

        #region General Constructor : Class (DSMResult) Default Assignment Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DSMResult_Constructor_Instantiated_With_Default_Assignments_Test()
        {

            // Act
            var dSMResultInstance  = new DSMResult();

            // Asserts
            dSMResultInstance.ShouldNotBeNull();
            dSMResultInstance.ShouldBeAssignableTo<DSMResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DSMResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(String) , PropertyCurrentProcess)]
        [TestCaseGeneric(typeof(Int32) , PropertyTotalRecords)]
        [TestCaseGeneric(typeof(Int32) , PropertyPercentComplete)]
        [TestCaseGeneric(typeof(Int32) , PropertyProcessedRecords)]
        [TestCaseGeneric(typeof(Int32) , PropertySuccessRecords)]
        [TestCaseGeneric(typeof(Int32) , PropertyFailedRecords)]
        [TestCaseGeneric(typeof(DSMLog) , PropertyLog)]
        public void AUT_DSMResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DSMResult, T>(_dSMResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DSMResult) => Property (CurrentProcess) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DSMResult_Public_Class_CurrentProcess_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCurrentProcess);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DSMResult) => Property (FailedRecords) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DSMResult_Public_Class_FailedRecords_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyFailedRecords);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DSMResult) => Property (Log) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DSMResult_Log_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyLog);
            Action currentAction = () => propertyInfo.SetValue(_dSMResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DSMResult) => Property (Log) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DSMResult_Public_Class_Log_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyLog);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DSMResult) => Property (PercentComplete) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DSMResult_Public_Class_PercentComplete_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPercentComplete);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DSMResult) => Property (ProcessedRecords) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DSMResult_Public_Class_ProcessedRecords_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyProcessedRecords);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DSMResult) => Property (SuccessRecords) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DSMResult_Public_Class_SuccessRecords_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySuccessRecords);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DSMResult) => Property (TotalRecords) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DSMResult_Public_Class_TotalRecords_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyTotalRecords);

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