using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Jobs
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.ResourceImportResult" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ResourceImportResultTest : AbstractBaseSetupTypedTest<ResourceImportResult>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ResourceImportResult) Initializer

        private const string PropertyCurrentProcess = "CurrentProcess";
        private const string PropertyTotalRecords = "TotalRecords";
        private const string PropertyPercentComplete = "PercentComplete";
        private const string PropertyProcessedRecords = "ProcessedRecords";
        private const string PropertySuccessRecords = "SuccessRecords";
        private const string PropertyFailedRecords = "FailedRecords";
        private const string PropertyLog = "Log";
        private Type _resourceImportResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ResourceImportResult _resourceImportResultInstance;
        private ResourceImportResult _resourceImportResultInstanceFixture;

        #region General Initializer : Class (ResourceImportResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ResourceImportResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _resourceImportResultInstanceType = typeof(ResourceImportResult);
            _resourceImportResultInstanceFixture = Create(true);
            _resourceImportResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ResourceImportResult)

        #region General Initializer : Class (ResourceImportResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ResourceImportResult" />) explore and verify properties for coverage gain.
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
        public void AUT_ResourceImportResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_resourceImportResultInstanceFixture,
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
        ///     Class (<see cref="ResourceImportResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ResourceImportResult_Is_Instance_Present_Test()
        {
            // Assert
            _resourceImportResultInstanceType.ShouldNotBeNull();
            _resourceImportResultInstance.ShouldNotBeNull();
            _resourceImportResultInstanceFixture.ShouldNotBeNull();
            _resourceImportResultInstance.ShouldBeAssignableTo<ResourceImportResult>();
            _resourceImportResultInstanceFixture.ShouldBeAssignableTo<ResourceImportResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ResourceImportResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ResourceImportResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ResourceImportResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _resourceImportResultInstanceType.ShouldNotBeNull();
            _resourceImportResultInstance.ShouldNotBeNull();
            _resourceImportResultInstanceFixture.ShouldNotBeNull();
            _resourceImportResultInstance.ShouldBeAssignableTo<ResourceImportResult>();
            _resourceImportResultInstanceFixture.ShouldBeAssignableTo<ResourceImportResult>();
        }

        #endregion

        #region General Constructor : Class (ResourceImportResult) Default Assignment Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ResourceImportResult_Constructor_Instantiated_With_Default_Assignments_Test()
        {

            // Act
            var resourceImportResultInstance  = new ResourceImportResult();

            // Asserts
            resourceImportResultInstance.ShouldNotBeNull();
            resourceImportResultInstance.ShouldBeAssignableTo<ResourceImportResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ResourceImportResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(String) , PropertyCurrentProcess)]
        [TestCaseGeneric(typeof(Int32) , PropertyTotalRecords)]
        [TestCaseGeneric(typeof(Int32) , PropertyPercentComplete)]
        [TestCaseGeneric(typeof(Int32) , PropertyProcessedRecords)]
        [TestCaseGeneric(typeof(Int32) , PropertySuccessRecords)]
        [TestCaseGeneric(typeof(Int32) , PropertyFailedRecords)]
        [TestCaseGeneric(typeof(ResourceImportLog) , PropertyLog)]
        public void AUT_ResourceImportResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ResourceImportResult, T>(_resourceImportResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ResourceImportResult) => Property (CurrentProcess) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ResourceImportResult_Public_Class_CurrentProcess_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ResourceImportResult) => Property (FailedRecords) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ResourceImportResult_Public_Class_FailedRecords_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ResourceImportResult) => Property (Log) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ResourceImportResult_Log_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyLog);
            Action currentAction = () => propertyInfo.SetValue(_resourceImportResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ResourceImportResult) => Property (Log) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ResourceImportResult_Public_Class_Log_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ResourceImportResult) => Property (PercentComplete) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ResourceImportResult_Public_Class_PercentComplete_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ResourceImportResult) => Property (ProcessedRecords) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ResourceImportResult_Public_Class_ProcessedRecords_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ResourceImportResult) => Property (SuccessRecords) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ResourceImportResult_Public_Class_SuccessRecords_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ResourceImportResult) => Property (TotalRecords) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ResourceImportResult_Public_Class_TotalRecords_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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