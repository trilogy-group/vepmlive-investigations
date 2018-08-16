using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.ReportingProxy
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ReportingProxy.ReportingLogger" />)
    ///     and namespace <see cref="EPMLiveCore.ReportingProxy"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ReportingLoggerTest : AbstractBaseSetupTypedTest<ReportingLogger>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportingLogger) Initializer

        private const string MethodLog = "Log";
        private Type _reportingLoggerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportingLogger _reportingLoggerInstance;
        private ReportingLogger _reportingLoggerInstanceFixture;

        #region General Initializer : Class (ReportingLogger) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportingLogger" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportingLoggerInstanceType = typeof(ReportingLogger);
            _reportingLoggerInstanceFixture = Create(true);
            _reportingLoggerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportingLogger)

        #region General Initializer : Class (ReportingLogger) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ReportingLogger" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodLog, 0)]
        public void AUT_ReportingLogger_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_reportingLoggerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="ReportingLogger" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ReportingLogger_Is_Instance_Present_Test()
        {
            // Assert
            _reportingLoggerInstanceType.ShouldNotBeNull();
            _reportingLoggerInstance.ShouldNotBeNull();
            _reportingLoggerInstanceFixture.ShouldNotBeNull();
            _reportingLoggerInstance.ShouldBeAssignableTo<ReportingLogger>();
            _reportingLoggerInstanceFixture.ShouldBeAssignableTo<ReportingLogger>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportingLogger) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportingLogger_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            ReportingLogger instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new ReportingLogger(spWeb);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _reportingLoggerInstance.ShouldNotBeNull();
            _reportingLoggerInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<ReportingLogger>();
        }

        #endregion

        #region General Constructor : Class (ReportingLogger) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportingLogger_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            ReportingLogger instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new ReportingLogger(spWeb);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _reportingLoggerInstance.ShouldNotBeNull();
            _reportingLoggerInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ReportingLogger" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodLog)]
        public void AUT_ReportingLogger_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ReportingLogger>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Log) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingLogger_Log_Method_Call_Internally(Type[] types)
        {
            var methodLogPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingLoggerInstance, MethodLog, Fixture, methodLogPrametersTypes);
        }

        #endregion

        #region Method Call : (Log) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingLogger_Log_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var message = CreateType<string>();
            var details = CreateType<string>();
            var level = CreateType<int>();
            var kind = CreateType<int>();
            var timerJobId = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportingLoggerInstance.Log(list, message, details, level, kind, timerJobId);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Log) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingLogger_Log_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var message = CreateType<string>();
            var details = CreateType<string>();
            var level = CreateType<int>();
            var kind = CreateType<int>();
            var timerJobId = CreateType<string>();
            var methodLogPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(string), typeof(int), typeof(int), typeof(string) };
            object[] parametersOfLog = { list, message, details, level, kind, timerJobId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLog, methodLogPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingLoggerInstanceFixture, parametersOfLog);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLog.ShouldNotBeNull();
            parametersOfLog.Length.ShouldBe(6);
            methodLogPrametersTypes.Length.ShouldBe(6);
            methodLogPrametersTypes.Length.ShouldBe(parametersOfLog.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Log) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingLogger_Log_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var message = CreateType<string>();
            var details = CreateType<string>();
            var level = CreateType<int>();
            var kind = CreateType<int>();
            var timerJobId = CreateType<string>();
            var methodLogPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(string), typeof(int), typeof(int), typeof(string) };
            object[] parametersOfLog = { list, message, details, level, kind, timerJobId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingLoggerInstance, MethodLog, parametersOfLog, methodLogPrametersTypes);

            // Assert
            parametersOfLog.ShouldNotBeNull();
            parametersOfLog.Length.ShouldBe(6);
            methodLogPrametersTypes.Length.ShouldBe(6);
            methodLogPrametersTypes.Length.ShouldBe(parametersOfLog.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Log) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingLogger_Log_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLog, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Log) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingLogger_Log_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLogPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(string), typeof(int), typeof(int), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingLoggerInstance, MethodLog, Fixture, methodLogPrametersTypes);

            // Assert
            methodLogPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Log) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingLogger_Log_Method_Call_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLog, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingLoggerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}