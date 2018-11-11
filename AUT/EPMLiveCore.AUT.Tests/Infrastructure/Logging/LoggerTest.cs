using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Infrastructure.Logging
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Infrastructure.Logging.Logger" />)
    ///     and namespace <see cref="EPMLiveCore.Infrastructure.Logging"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class LoggerTest : AbstractBaseSetupTypedTest<Logger>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Logger) Initializer

        private const string MethodDispose = "Dispose";
        private const string MethodInsertLog = "InsertLog";
        private const string MethodLogMessage = "LogMessage";
        private const string Field_sqlConnection = "_sqlConnection";
        private const string Field_userId = "_userId";
        private const string Field_webAppId = "_webAppId";
        private const string Field_webId = "_webId";
        private const string Field_disposed = "_disposed";
        private Type _loggerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Logger _loggerInstance;
        private Logger _loggerInstanceFixture;

        #region General Initializer : Class (Logger) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Logger" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _loggerInstanceType = typeof(Logger);
            _loggerInstanceFixture = Create(true);
            _loggerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Logger)

        #region General Initializer : Class (Logger) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Logger" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodDispose, 0)]
        [TestCase(MethodInsertLog, 0)]
        [TestCase(MethodLogMessage, 0)]
        [TestCase(MethodLogMessage, 1)]
        [TestCase(MethodDispose, 1)]
        public void AUT_Logger_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_loggerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Logger) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Logger" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_sqlConnection)]
        [TestCase(Field_userId)]
        [TestCase(Field_webAppId)]
        [TestCase(Field_webId)]
        [TestCase(Field_disposed)]
        public void AUT_Logger_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_loggerInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Logger) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="Logger" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_Logger_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<Logger>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (Logger) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="Logger" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Logger_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<Logger>(Fixture);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Logger" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodDispose)]
        [TestCase(MethodInsertLog)]
        [TestCase(MethodLogMessage)]
        public void AUT_Logger_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Logger>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Logger_Dispose_Method_Call_Internally(Type[] types)
        {
            var methodDisposePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_loggerInstance, MethodDispose, Fixture, methodDisposePrametersTypes);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Logger_Dispose_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var disposing = CreateType<bool>();
            var methodDisposePrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfDispose = { disposing };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDispose, methodDisposePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_loggerInstanceFixture, parametersOfDispose);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDispose.ShouldNotBeNull();
            parametersOfDispose.Length.ShouldBe(1);
            methodDisposePrametersTypes.Length.ShouldBe(1);
            methodDisposePrametersTypes.Length.ShouldBe(parametersOfDispose.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Logger_Dispose_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var disposing = CreateType<bool>();
            var methodDisposePrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfDispose = { disposing };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_loggerInstance, MethodDispose, parametersOfDispose, methodDisposePrametersTypes);

            // Assert
            parametersOfDispose.ShouldNotBeNull();
            parametersOfDispose.Length.ShouldBe(1);
            methodDisposePrametersTypes.Length.ShouldBe(1);
            methodDisposePrametersTypes.Length.ShouldBe(parametersOfDispose.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Logger_Dispose_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDisposePrametersTypes = new Type[] { typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_loggerInstance, MethodDispose, Fixture, methodDisposePrametersTypes);

            // Assert
            methodDisposePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Logger_Dispose_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDispose, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_loggerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InsertLog) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Logger_InsertLog_Method_Call_Internally(Type[] types)
        {
            var methodInsertLogPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_loggerInstance, MethodInsertLog, Fixture, methodInsertLogPrametersTypes);
        }

        #endregion

        #region Method Call : (InsertLog) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Logger_InsertLog_Method_Call_Void_With_5_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var details = CreateType<string>();
            var component = CreateType<string>();
            var kind = CreateType<LogKind>();
            var stackTrace = CreateType<string>();
            var methodInsertLogPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(LogKind), typeof(string) };
            object[] parametersOfInsertLog = { message, details, component, kind, stackTrace };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInsertLog, methodInsertLogPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_loggerInstanceFixture, parametersOfInsertLog);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInsertLog.ShouldNotBeNull();
            parametersOfInsertLog.Length.ShouldBe(5);
            methodInsertLogPrametersTypes.Length.ShouldBe(5);
            methodInsertLogPrametersTypes.Length.ShouldBe(parametersOfInsertLog.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InsertLog) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Logger_InsertLog_Method_Call_Void_With_5_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var details = CreateType<string>();
            var component = CreateType<string>();
            var kind = CreateType<LogKind>();
            var stackTrace = CreateType<string>();
            var methodInsertLogPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(LogKind), typeof(string) };
            object[] parametersOfInsertLog = { message, details, component, kind, stackTrace };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_loggerInstance, MethodInsertLog, parametersOfInsertLog, methodInsertLogPrametersTypes);

            // Assert
            parametersOfInsertLog.ShouldNotBeNull();
            parametersOfInsertLog.Length.ShouldBe(5);
            methodInsertLogPrametersTypes.Length.ShouldBe(5);
            methodInsertLogPrametersTypes.Length.ShouldBe(parametersOfInsertLog.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InsertLog) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Logger_InsertLog_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInsertLog, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InsertLog) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Logger_InsertLog_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInsertLogPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(LogKind), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_loggerInstance, MethodInsertLog, Fixture, methodInsertLogPrametersTypes);

            // Assert
            methodInsertLogPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InsertLog) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Logger_InsertLog_Method_Call_With_5_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInsertLog, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_loggerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogMessage) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Logger_LogMessage_Method_Call_Internally(Type[] types)
        {
            var methodLogMessagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_loggerInstance, MethodLogMessage, Fixture, methodLogMessagePrametersTypes);
        }

        #endregion

        #region Method Call : (LogMessage) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Logger_LogMessage_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var exception = CreateType<Exception>();
            var component = CreateType<string>();
            var kind = CreateType<LogKind>();
            Action executeAction = null;

            // Act
            executeAction = () => _loggerInstance.LogMessage(exception, component, kind);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (LogMessage) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Logger_LogMessage_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var exception = CreateType<Exception>();
            var component = CreateType<string>();
            var kind = CreateType<LogKind>();
            var methodLogMessagePrametersTypes = new Type[] { typeof(Exception), typeof(string), typeof(LogKind) };
            object[] parametersOfLogMessage = { exception, component, kind };
            var methodInfo = GetMethodInfo(MethodLogMessage, methodLogMessagePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_loggerInstanceFixture, parametersOfLogMessage);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLogMessage.ShouldNotBeNull();
            parametersOfLogMessage.Length.ShouldBe(3);
            methodLogMessagePrametersTypes.Length.ShouldBe(3);
            methodLogMessagePrametersTypes.Length.ShouldBe(parametersOfLogMessage.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (LogMessage) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Logger_LogMessage_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var exception = CreateType<Exception>();
            var component = CreateType<string>();
            var kind = CreateType<LogKind>();
            var methodLogMessagePrametersTypes = new Type[] { typeof(Exception), typeof(string), typeof(LogKind) };
            object[] parametersOfLogMessage = { exception, component, kind };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_loggerInstance, MethodLogMessage, parametersOfLogMessage, methodLogMessagePrametersTypes);

            // Assert
            parametersOfLogMessage.ShouldNotBeNull();
            parametersOfLogMessage.Length.ShouldBe(3);
            methodLogMessagePrametersTypes.Length.ShouldBe(3);
            methodLogMessagePrametersTypes.Length.ShouldBe(parametersOfLogMessage.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogMessage) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Logger_LogMessage_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLogMessage, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LogMessage) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Logger_LogMessage_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLogMessagePrametersTypes = new Type[] { typeof(Exception), typeof(string), typeof(LogKind) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_loggerInstance, MethodLogMessage, Fixture, methodLogMessagePrametersTypes);

            // Assert
            methodLogMessagePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogMessage) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Logger_LogMessage_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLogMessage, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_loggerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogMessage) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Logger_LogMessage_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodLogMessagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_loggerInstance, MethodLogMessage, Fixture, methodLogMessagePrametersTypes);
        }

        #endregion

        #region Method Call : (LogMessage) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Logger_LogMessage_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var component = CreateType<string>();
            var kind = CreateType<LogKind>();
            var details = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _loggerInstance.LogMessage(message, component, kind, details);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (LogMessage) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Logger_LogMessage_Method_Call_Void_Overloading_Of_1_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var component = CreateType<string>();
            var kind = CreateType<LogKind>();
            var details = CreateType<string>();
            var methodLogMessagePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(LogKind), typeof(string) };
            object[] parametersOfLogMessage = { message, component, kind, details };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLogMessage, methodLogMessagePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_loggerInstanceFixture, parametersOfLogMessage);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLogMessage.ShouldNotBeNull();
            parametersOfLogMessage.Length.ShouldBe(4);
            methodLogMessagePrametersTypes.Length.ShouldBe(4);
            methodLogMessagePrametersTypes.Length.ShouldBe(parametersOfLogMessage.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (LogMessage) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Logger_LogMessage_Method_Call_Void_Overloading_Of_1_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var component = CreateType<string>();
            var kind = CreateType<LogKind>();
            var details = CreateType<string>();
            var methodLogMessagePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(LogKind), typeof(string) };
            object[] parametersOfLogMessage = { message, component, kind, details };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_loggerInstance, MethodLogMessage, parametersOfLogMessage, methodLogMessagePrametersTypes);

            // Assert
            parametersOfLogMessage.ShouldNotBeNull();
            parametersOfLogMessage.Length.ShouldBe(4);
            methodLogMessagePrametersTypes.Length.ShouldBe(4);
            methodLogMessagePrametersTypes.Length.ShouldBe(parametersOfLogMessage.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogMessage) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Logger_LogMessage_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLogMessage, 1);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LogMessage) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Logger_LogMessage_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLogMessagePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(LogKind), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_loggerInstance, MethodLogMessage, Fixture, methodLogMessagePrametersTypes);

            // Assert
            methodLogMessagePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogMessage) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Logger_LogMessage_Method_Call_Overloading_Of_1_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLogMessage, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_loggerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Logger_Dispose_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodDisposePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_loggerInstance, MethodDispose, Fixture, methodDisposePrametersTypes);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Logger_Dispose_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _loggerInstance.Dispose();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Logger_Dispose_Method_Call_Void_Overloading_Of_1_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;
            object[] parametersOfDispose = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDispose, methodDisposePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_loggerInstanceFixture, parametersOfDispose);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDispose.ShouldBeNull();
            methodDisposePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Logger_Dispose_Method_Call_Void_Overloading_Of_1_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;
            object[] parametersOfDispose = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_loggerInstance, MethodDispose, parametersOfDispose, methodDisposePrametersTypes);

            // Assert
            parametersOfDispose.ShouldBeNull();
            methodDisposePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Logger_Dispose_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_loggerInstance, MethodDispose, Fixture, methodDisposePrametersTypes);

            // Assert
            methodDisposePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Logger_Dispose_Method_Call_Overloading_Of_1_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDispose, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_loggerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}