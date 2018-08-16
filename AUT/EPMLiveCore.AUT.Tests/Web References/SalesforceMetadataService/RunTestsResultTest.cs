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

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.RunTestsResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RunTestsResultTest : AbstractBaseSetupTypedTest<RunTestsResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RunTestsResult) Initializer

        private const string PropertycodeCoverage = "codeCoverage";
        private const string PropertycodeCoverageWarnings = "codeCoverageWarnings";
        private const string Propertyfailures = "failures";
        private const string PropertynumFailures = "numFailures";
        private const string PropertynumTestsRun = "numTestsRun";
        private const string Propertysuccesses = "successes";
        private const string PropertytotalTime = "totalTime";
        private const string FieldcodeCoverageField = "codeCoverageField";
        private const string FieldcodeCoverageWarningsField = "codeCoverageWarningsField";
        private const string FieldfailuresField = "failuresField";
        private const string FieldnumFailuresField = "numFailuresField";
        private const string FieldnumTestsRunField = "numTestsRunField";
        private const string FieldsuccessesField = "successesField";
        private const string FieldtotalTimeField = "totalTimeField";
        private Type _runTestsResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RunTestsResult _runTestsResultInstance;
        private RunTestsResult _runTestsResultInstanceFixture;

        #region General Initializer : Class (RunTestsResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RunTestsResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _runTestsResultInstanceType = typeof(RunTestsResult);
            _runTestsResultInstanceFixture = Create(true);
            _runTestsResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RunTestsResult)

        #region General Initializer : Class (RunTestsResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="RunTestsResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycodeCoverage)]
        [TestCase(PropertycodeCoverageWarnings)]
        [TestCase(Propertyfailures)]
        [TestCase(PropertynumFailures)]
        [TestCase(PropertynumTestsRun)]
        [TestCase(Propertysuccesses)]
        [TestCase(PropertytotalTime)]
        public void AUT_RunTestsResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_runTestsResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (RunTestsResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RunTestsResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcodeCoverageField)]
        [TestCase(FieldcodeCoverageWarningsField)]
        [TestCase(FieldfailuresField)]
        [TestCase(FieldnumFailuresField)]
        [TestCase(FieldnumTestsRunField)]
        [TestCase(FieldsuccessesField)]
        [TestCase(FieldtotalTimeField)]
        public void AUT_RunTestsResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_runTestsResultInstanceFixture, 
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
        ///     Class (<see cref="RunTestsResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_RunTestsResult_Is_Instance_Present_Test()
        {
            // Assert
            _runTestsResultInstanceType.ShouldNotBeNull();
            _runTestsResultInstance.ShouldNotBeNull();
            _runTestsResultInstanceFixture.ShouldNotBeNull();
            _runTestsResultInstance.ShouldBeAssignableTo<RunTestsResult>();
            _runTestsResultInstanceFixture.ShouldBeAssignableTo<RunTestsResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RunTestsResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_RunTestsResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RunTestsResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _runTestsResultInstanceType.ShouldNotBeNull();
            _runTestsResultInstance.ShouldNotBeNull();
            _runTestsResultInstanceFixture.ShouldNotBeNull();
            _runTestsResultInstance.ShouldBeAssignableTo<RunTestsResult>();
            _runTestsResultInstanceFixture.ShouldBeAssignableTo<RunTestsResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (RunTestsResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(CodeCoverageResult[]) , PropertycodeCoverage)]
        [TestCaseGeneric(typeof(CodeCoverageWarning[]) , PropertycodeCoverageWarnings)]
        [TestCaseGeneric(typeof(RunTestFailure[]) , Propertyfailures)]
        [TestCaseGeneric(typeof(int) , PropertynumFailures)]
        [TestCaseGeneric(typeof(int) , PropertynumTestsRun)]
        [TestCaseGeneric(typeof(RunTestSuccess[]) , Propertysuccesses)]
        [TestCaseGeneric(typeof(double) , PropertytotalTime)]
        public void AUT_RunTestsResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<RunTestsResult, T>(_runTestsResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (RunTestsResult) => Property (codeCoverage) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RunTestsResult_codeCoverage_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycodeCoverage);
            Action currentAction = () => propertyInfo.SetValue(_runTestsResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (RunTestsResult) => Property (codeCoverage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RunTestsResult_Public_Class_codeCoverage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycodeCoverage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RunTestsResult) => Property (codeCoverageWarnings) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RunTestsResult_codeCoverageWarnings_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycodeCoverageWarnings);
            Action currentAction = () => propertyInfo.SetValue(_runTestsResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (RunTestsResult) => Property (codeCoverageWarnings) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RunTestsResult_Public_Class_codeCoverageWarnings_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycodeCoverageWarnings);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RunTestsResult) => Property (failures) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RunTestsResult_failures_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyfailures);
            Action currentAction = () => propertyInfo.SetValue(_runTestsResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (RunTestsResult) => Property (failures) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RunTestsResult_Public_Class_failures_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyfailures);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RunTestsResult) => Property (numFailures) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RunTestsResult_Public_Class_numFailures_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynumFailures);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RunTestsResult) => Property (numTestsRun) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RunTestsResult_Public_Class_numTestsRun_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynumTestsRun);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RunTestsResult) => Property (successes) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RunTestsResult_successes_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertysuccesses);
            Action currentAction = () => propertyInfo.SetValue(_runTestsResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (RunTestsResult) => Property (successes) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RunTestsResult_Public_Class_successes_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysuccesses);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RunTestsResult) => Property (totalTime) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RunTestsResult_Public_Class_totalTime_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytotalTime);

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