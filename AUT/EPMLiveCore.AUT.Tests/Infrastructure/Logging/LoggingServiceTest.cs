using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint.Administration;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Infrastructure.Logging
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Infrastructure.Logging.LoggingService" />)
    ///     and namespace <see cref="EPMLiveCore.Infrastructure.Logging"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class LoggingServiceTest : AbstractBaseSetupTypedTest<LoggingService>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (LoggingService) Initializer

        private const string PropertyLocal = "Local";
        private const string PropertyDefaultName = "DefaultName";
        private const string MethodProvideAreas = "ProvideAreas";
        private const string MethodWriteTrace = "WriteTrace";
        private const string MethodWriteEvent = "WriteEvent";
        private Type _loggingServiceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private LoggingService _loggingServiceInstance;
        private LoggingService _loggingServiceInstanceFixture;

        #region General Initializer : Class (LoggingService) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="LoggingService" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _loggingServiceInstanceType = typeof(LoggingService);
            _loggingServiceInstanceFixture = Create(true);
            _loggingServiceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (LoggingService)

        #region General Initializer : Class (LoggingService) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="LoggingService" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodProvideAreas, 0)]
        [TestCase(MethodWriteTrace, 0)]
        [TestCase(MethodWriteTrace, 1)]
        [TestCase(MethodWriteEvent, 0)]
        [TestCase(MethodWriteEvent, 1)]
        public void AUT_LoggingService_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_loggingServiceInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (LoggingService) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="LoggingService" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyLocal)]
        [TestCase(PropertyDefaultName)]
        public void AUT_LoggingService_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_loggingServiceInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (LoggingService) => Property (DefaultName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LoggingService_Public_Class_DefaultName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDefaultName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LoggingService) => Property (Local) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LoggingService_Local_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyLocal);
            Action currentAction = () => propertyInfo.SetValue(_loggingServiceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (LoggingService) => Property (Local) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LoggingService_Public_Class_Local_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyLocal);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="LoggingService" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodWriteTrace)]
        [TestCase(MethodWriteEvent)]
        public void AUT_LoggingService_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_loggingServiceInstanceFixture,
                                                                              _loggingServiceInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="LoggingService" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodProvideAreas)]
        public void AUT_LoggingService_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<LoggingService>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ProvideAreas) (Return Type : IEnumerable<SPDiagnosticsArea>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_LoggingService_ProvideAreas_Method_Call_Internally(Type[] types)
        {
            var methodProvideAreasPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_loggingServiceInstance, MethodProvideAreas, Fixture, methodProvideAreasPrametersTypes);
        }

        #endregion

        #region Method Call : (ProvideAreas) (Return Type : IEnumerable<SPDiagnosticsArea>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_ProvideAreas_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodProvideAreasPrametersTypes = null;
            object[] parametersOfProvideAreas = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodProvideAreas, methodProvideAreasPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<LoggingService, IEnumerable<SPDiagnosticsArea>>(_loggingServiceInstanceFixture, out exception1, parametersOfProvideAreas);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<LoggingService, IEnumerable<SPDiagnosticsArea>>(_loggingServiceInstance, MethodProvideAreas, parametersOfProvideAreas, methodProvideAreasPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfProvideAreas.ShouldBeNull();
            methodProvideAreasPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_loggingServiceInstanceFixture, parametersOfProvideAreas));
        }

        #endregion

        #region Method Call : (ProvideAreas) (Return Type : IEnumerable<SPDiagnosticsArea>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_ProvideAreas_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodProvideAreasPrametersTypes = null;
            object[] parametersOfProvideAreas = null; // no parameter present

            // Assert
            parametersOfProvideAreas.ShouldBeNull();
            methodProvideAreasPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<LoggingService, IEnumerable<SPDiagnosticsArea>>(_loggingServiceInstance, MethodProvideAreas, parametersOfProvideAreas, methodProvideAreasPrametersTypes));
        }

        #endregion

        #region Method Call : (ProvideAreas) (Return Type : IEnumerable<SPDiagnosticsArea>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_ProvideAreas_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodProvideAreasPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_loggingServiceInstance, MethodProvideAreas, Fixture, methodProvideAreasPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodProvideAreasPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ProvideAreas) (Return Type : IEnumerable<SPDiagnosticsArea>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_ProvideAreas_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodProvideAreasPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_loggingServiceInstance, MethodProvideAreas, Fixture, methodProvideAreasPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodProvideAreasPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ProvideAreas) (Return Type : IEnumerable<SPDiagnosticsArea>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_ProvideAreas_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProvideAreas, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_loggingServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (WriteTrace) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_LoggingService_WriteTrace_Static_Method_Call_Internally(Type[] types)
        {
            var methodWriteTracePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_loggingServiceInstanceFixture, _loggingServiceInstanceType, MethodWriteTrace, Fixture, methodWriteTracePrametersTypes);
        }

        #endregion

        #region Method Call : (WriteTrace) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_WriteTrace_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var areaName = CreateType<string>();
            var categoryName = CreateType<string>();
            var traceSeverity = CreateType<TraceSeverity>();
            var format = CreateType<string>();
            var arg = CreateType<string[]>();
            Action executeAction = null;

            // Act
            executeAction = () => LoggingService.WriteTrace(areaName, categoryName, traceSeverity, format, arg);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (WriteTrace) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_WriteTrace_Static_Method_Call_Void_With_5_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var areaName = CreateType<string>();
            var categoryName = CreateType<string>();
            var traceSeverity = CreateType<TraceSeverity>();
            var format = CreateType<string>();
            var arg = CreateType<string[]>();
            var methodWriteTracePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(TraceSeverity), typeof(string), typeof(string[]) };
            object[] parametersOfWriteTrace = { areaName, categoryName, traceSeverity, format, arg };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWriteTrace, methodWriteTracePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_loggingServiceInstanceFixture, parametersOfWriteTrace);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWriteTrace.ShouldNotBeNull();
            parametersOfWriteTrace.Length.ShouldBe(5);
            methodWriteTracePrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteTrace) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_WriteTrace_Static_Method_Call_Void_With_5_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var areaName = CreateType<string>();
            var categoryName = CreateType<string>();
            var traceSeverity = CreateType<TraceSeverity>();
            var format = CreateType<string>();
            var arg = CreateType<string[]>();
            var methodWriteTracePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(TraceSeverity), typeof(string), typeof(string[]) };
            object[] parametersOfWriteTrace = { areaName, categoryName, traceSeverity, format, arg };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_loggingServiceInstanceFixture, _loggingServiceInstanceType, MethodWriteTrace, parametersOfWriteTrace, methodWriteTracePrametersTypes);

            // Assert
            parametersOfWriteTrace.ShouldNotBeNull();
            parametersOfWriteTrace.Length.ShouldBe(5);
            methodWriteTracePrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteTrace) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_WriteTrace_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWriteTrace, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WriteTrace) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_WriteTrace_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWriteTracePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(TraceSeverity), typeof(string), typeof(string[]) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_loggingServiceInstanceFixture, _loggingServiceInstanceType, MethodWriteTrace, Fixture, methodWriteTracePrametersTypes);

            // Assert
            methodWriteTracePrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteTrace) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_WriteTrace_Static_Method_Call_With_5_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWriteTrace, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_loggingServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteTrace) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_LoggingService_WriteTrace_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodWriteTracePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_loggingServiceInstanceFixture, _loggingServiceInstanceType, MethodWriteTrace, Fixture, methodWriteTracePrametersTypes);
        }

        #endregion

        #region Method Call : (WriteTrace) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_WriteTrace_Static_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var areaName = CreateType<string>();
            var categoryName = CreateType<string>();
            var traceSeverity = CreateType<TraceSeverity>();
            var message = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => LoggingService.WriteTrace(areaName, categoryName, traceSeverity, message);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (WriteTrace) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_WriteTrace_Static_Method_Call_Void_Overloading_Of_1_With_4_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var areaName = CreateType<string>();
            var categoryName = CreateType<string>();
            var traceSeverity = CreateType<TraceSeverity>();
            var message = CreateType<string>();
            var methodWriteTracePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(TraceSeverity), typeof(string) };
            object[] parametersOfWriteTrace = { areaName, categoryName, traceSeverity, message };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWriteTrace, methodWriteTracePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_loggingServiceInstanceFixture, parametersOfWriteTrace);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWriteTrace.ShouldNotBeNull();
            parametersOfWriteTrace.Length.ShouldBe(4);
            methodWriteTracePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteTrace) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_WriteTrace_Static_Method_Call_Void_Overloading_Of_1_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var areaName = CreateType<string>();
            var categoryName = CreateType<string>();
            var traceSeverity = CreateType<TraceSeverity>();
            var message = CreateType<string>();
            var methodWriteTracePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(TraceSeverity), typeof(string) };
            object[] parametersOfWriteTrace = { areaName, categoryName, traceSeverity, message };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_loggingServiceInstanceFixture, _loggingServiceInstanceType, MethodWriteTrace, parametersOfWriteTrace, methodWriteTracePrametersTypes);

            // Assert
            parametersOfWriteTrace.ShouldNotBeNull();
            parametersOfWriteTrace.Length.ShouldBe(4);
            methodWriteTracePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteTrace) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_WriteTrace_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWriteTrace, 1);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WriteTrace) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_WriteTrace_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWriteTracePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(TraceSeverity), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_loggingServiceInstanceFixture, _loggingServiceInstanceType, MethodWriteTrace, Fixture, methodWriteTracePrametersTypes);

            // Assert
            methodWriteTracePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteTrace) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_WriteTrace_Static_Method_Call_Overloading_Of_1_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWriteTrace, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_loggingServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteEvent) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_LoggingService_WriteEvent_Static_Method_Call_Internally(Type[] types)
        {
            var methodWriteEventPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_loggingServiceInstanceFixture, _loggingServiceInstanceType, MethodWriteEvent, Fixture, methodWriteEventPrametersTypes);
        }

        #endregion

        #region Method Call : (WriteEvent) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_WriteEvent_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var areaName = CreateType<string>();
            var categoryName = CreateType<string>();
            var eventSeverity = CreateType<EventSeverity>();
            var format = CreateType<string>();
            var arg = CreateType<string[]>();
            Action executeAction = null;

            // Act
            executeAction = () => LoggingService.WriteEvent(areaName, categoryName, eventSeverity, format, arg);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (WriteEvent) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_WriteEvent_Static_Method_Call_Void_With_5_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var areaName = CreateType<string>();
            var categoryName = CreateType<string>();
            var eventSeverity = CreateType<EventSeverity>();
            var format = CreateType<string>();
            var arg = CreateType<string[]>();
            var methodWriteEventPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(EventSeverity), typeof(string), typeof(string[]) };
            object[] parametersOfWriteEvent = { areaName, categoryName, eventSeverity, format, arg };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWriteEvent, methodWriteEventPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_loggingServiceInstanceFixture, parametersOfWriteEvent);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWriteEvent.ShouldNotBeNull();
            parametersOfWriteEvent.Length.ShouldBe(5);
            methodWriteEventPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteEvent) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_WriteEvent_Static_Method_Call_Void_With_5_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var areaName = CreateType<string>();
            var categoryName = CreateType<string>();
            var eventSeverity = CreateType<EventSeverity>();
            var format = CreateType<string>();
            var arg = CreateType<string[]>();
            var methodWriteEventPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(EventSeverity), typeof(string), typeof(string[]) };
            object[] parametersOfWriteEvent = { areaName, categoryName, eventSeverity, format, arg };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_loggingServiceInstanceFixture, _loggingServiceInstanceType, MethodWriteEvent, parametersOfWriteEvent, methodWriteEventPrametersTypes);

            // Assert
            parametersOfWriteEvent.ShouldNotBeNull();
            parametersOfWriteEvent.Length.ShouldBe(5);
            methodWriteEventPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteEvent) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_WriteEvent_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWriteEvent, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WriteEvent) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_WriteEvent_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWriteEventPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(EventSeverity), typeof(string), typeof(string[]) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_loggingServiceInstanceFixture, _loggingServiceInstanceType, MethodWriteEvent, Fixture, methodWriteEventPrametersTypes);

            // Assert
            methodWriteEventPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteEvent) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_WriteEvent_Static_Method_Call_With_5_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWriteEvent, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_loggingServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteEvent) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_LoggingService_WriteEvent_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodWriteEventPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_loggingServiceInstanceFixture, _loggingServiceInstanceType, MethodWriteEvent, Fixture, methodWriteEventPrametersTypes);
        }

        #endregion

        #region Method Call : (WriteEvent) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_WriteEvent_Static_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var areaName = CreateType<string>();
            var categoryName = CreateType<string>();
            var eventSeverity = CreateType<EventSeverity>();
            var message = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => LoggingService.WriteEvent(areaName, categoryName, eventSeverity, message);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (WriteEvent) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_WriteEvent_Static_Method_Call_Void_Overloading_Of_1_With_4_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var areaName = CreateType<string>();
            var categoryName = CreateType<string>();
            var eventSeverity = CreateType<EventSeverity>();
            var message = CreateType<string>();
            var methodWriteEventPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(EventSeverity), typeof(string) };
            object[] parametersOfWriteEvent = { areaName, categoryName, eventSeverity, message };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWriteEvent, methodWriteEventPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_loggingServiceInstanceFixture, parametersOfWriteEvent);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWriteEvent.ShouldNotBeNull();
            parametersOfWriteEvent.Length.ShouldBe(4);
            methodWriteEventPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteEvent) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_WriteEvent_Static_Method_Call_Void_Overloading_Of_1_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var areaName = CreateType<string>();
            var categoryName = CreateType<string>();
            var eventSeverity = CreateType<EventSeverity>();
            var message = CreateType<string>();
            var methodWriteEventPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(EventSeverity), typeof(string) };
            object[] parametersOfWriteEvent = { areaName, categoryName, eventSeverity, message };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_loggingServiceInstanceFixture, _loggingServiceInstanceType, MethodWriteEvent, parametersOfWriteEvent, methodWriteEventPrametersTypes);

            // Assert
            parametersOfWriteEvent.ShouldNotBeNull();
            parametersOfWriteEvent.Length.ShouldBe(4);
            methodWriteEventPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteEvent) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_WriteEvent_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWriteEvent, 1);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WriteEvent) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_WriteEvent_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWriteEventPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(EventSeverity), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_loggingServiceInstanceFixture, _loggingServiceInstanceType, MethodWriteEvent, Fixture, methodWriteEventPrametersTypes);

            // Assert
            methodWriteEventPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteEvent) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LoggingService_WriteEvent_Static_Method_Call_Overloading_Of_1_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWriteEvent, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_loggingServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}