using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using TimeDebug = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.TimeDebug" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class TimeDebugTest : AbstractBaseSetupTypedTest<TimeDebug>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (TimeDebug) Initializer

        private const string MethodAddTimer = "AddTimer";
        private const string MethodStopTimer = "StopTimer";
        private const string MethodStopTimers = "StopTimers";
        private const string MethodWriteTimers = "WriteTimers";
        private const string MethodGetHtml = "GetHtml";
        private const string FieldTimers = "Timers";
        private const string FieldbDebug = "bDebug";
        private const string FieldName = "Name";
        private const string FieldStartTime = "StartTime";
        private Type _timeDebugInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private TimeDebug _timeDebugInstance;
        private TimeDebug _timeDebugInstanceFixture;

        #region General Initializer : Class (TimeDebug) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="TimeDebug" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _timeDebugInstanceType = typeof(TimeDebug);
            _timeDebugInstanceFixture = Create(true);
            _timeDebugInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (TimeDebug)

        #region General Initializer : Class (TimeDebug) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="TimeDebug" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodAddTimer, 0)]
        [TestCase(MethodStopTimer, 0)]
        [TestCase(MethodStopTimers, 0)]
        [TestCase(MethodWriteTimers, 0)]
        [TestCase(MethodGetHtml, 0)]
        public void AUT_TimeDebug_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_timeDebugInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (TimeDebug) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="TimeDebug" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldTimers)]
        [TestCase(FieldbDebug)]
        [TestCase(FieldName)]
        [TestCase(FieldStartTime)]
        public void AUT_TimeDebug_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_timeDebugInstanceFixture, 
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
        ///     Class (<see cref="TimeDebug" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_TimeDebug_Is_Instance_Present_Test()
        {
            // Assert
            _timeDebugInstanceType.ShouldNotBeNull();
            _timeDebugInstance.ShouldNotBeNull();
            _timeDebugInstanceFixture.ShouldNotBeNull();
            _timeDebugInstance.ShouldBeAssignableTo<TimeDebug>();
            _timeDebugInstanceFixture.ShouldBeAssignableTo<TimeDebug>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (TimeDebug) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_TimeDebug_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var sbDebug = CreateType<string>();
            TimeDebug instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new TimeDebug(name, sbDebug);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _timeDebugInstance.ShouldNotBeNull();
            _timeDebugInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<TimeDebug>();
        }

        #endregion

        #region General Constructor : Class (TimeDebug) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_TimeDebug_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var sbDebug = CreateType<string>();
            TimeDebug instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new TimeDebug(name, sbDebug);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _timeDebugInstance.ShouldNotBeNull();
            _timeDebugInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="TimeDebug" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodAddTimer)]
        [TestCase(MethodStopTimer)]
        [TestCase(MethodStopTimers)]
        [TestCase(MethodWriteTimers)]
        [TestCase(MethodGetHtml)]
        public void AUT_TimeDebug_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<TimeDebug>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (AddTimer) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TimeDebug_AddTimer_Method_Call_Internally(Type[] types)
        {
            var methodAddTimerPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeDebugInstance, MethodAddTimer, Fixture, methodAddTimerPrametersTypes);
        }

        #endregion

        #region Method Call : (AddTimer) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeDebug_AddTimer_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _timeDebugInstance.AddTimer();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (AddTimer) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeDebug_AddTimer_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodAddTimerPrametersTypes = null;
            object[] parametersOfAddTimer = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddTimer, methodAddTimerPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_timeDebugInstanceFixture, parametersOfAddTimer);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddTimer.ShouldBeNull();
            methodAddTimerPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTimer) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeDebug_AddTimer_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodAddTimerPrametersTypes = null;
            object[] parametersOfAddTimer = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_timeDebugInstance, MethodAddTimer, parametersOfAddTimer, methodAddTimerPrametersTypes);

            // Assert
            parametersOfAddTimer.ShouldBeNull();
            methodAddTimerPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTimer) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeDebug_AddTimer_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodAddTimerPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeDebugInstance, MethodAddTimer, Fixture, methodAddTimerPrametersTypes);

            // Assert
            methodAddTimerPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTimer) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeDebug_AddTimer_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddTimer, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_timeDebugInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StopTimer) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TimeDebug_StopTimer_Method_Call_Internally(Type[] types)
        {
            var methodStopTimerPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeDebugInstance, MethodStopTimer, Fixture, methodStopTimerPrametersTypes);
        }

        #endregion

        #region Method Call : (StopTimer) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeDebug_StopTimer_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _timeDebugInstance.StopTimer();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (StopTimer) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeDebug_StopTimer_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodStopTimerPrametersTypes = null;
            object[] parametersOfStopTimer = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodStopTimer, methodStopTimerPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_timeDebugInstanceFixture, parametersOfStopTimer);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfStopTimer.ShouldBeNull();
            methodStopTimerPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StopTimer) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeDebug_StopTimer_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodStopTimerPrametersTypes = null;
            object[] parametersOfStopTimer = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_timeDebugInstance, MethodStopTimer, parametersOfStopTimer, methodStopTimerPrametersTypes);

            // Assert
            parametersOfStopTimer.ShouldBeNull();
            methodStopTimerPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StopTimer) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeDebug_StopTimer_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodStopTimerPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeDebugInstance, MethodStopTimer, Fixture, methodStopTimerPrametersTypes);

            // Assert
            methodStopTimerPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StopTimer) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeDebug_StopTimer_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodStopTimer, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_timeDebugInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StopTimers) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TimeDebug_StopTimers_Method_Call_Internally(Type[] types)
        {
            var methodStopTimersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeDebugInstance, MethodStopTimers, Fixture, methodStopTimersPrametersTypes);
        }

        #endregion

        #region Method Call : (StopTimers) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeDebug_StopTimers_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _timeDebugInstance.StopTimers();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (StopTimers) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeDebug_StopTimers_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodStopTimersPrametersTypes = null;
            object[] parametersOfStopTimers = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodStopTimers, methodStopTimersPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_timeDebugInstanceFixture, parametersOfStopTimers);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfStopTimers.ShouldBeNull();
            methodStopTimersPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StopTimers) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeDebug_StopTimers_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodStopTimersPrametersTypes = null;
            object[] parametersOfStopTimers = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_timeDebugInstance, MethodStopTimers, parametersOfStopTimers, methodStopTimersPrametersTypes);

            // Assert
            parametersOfStopTimers.ShouldBeNull();
            methodStopTimersPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StopTimers) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeDebug_StopTimers_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodStopTimersPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeDebugInstance, MethodStopTimers, Fixture, methodStopTimersPrametersTypes);

            // Assert
            methodStopTimersPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StopTimers) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeDebug_StopTimers_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodStopTimers, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_timeDebugInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteTimers) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TimeDebug_WriteTimers_Method_Call_Internally(Type[] types)
        {
            var methodWriteTimersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeDebugInstance, MethodWriteTimers, Fixture, methodWriteTimersPrametersTypes);
        }

        #endregion

        #region Method Call : (WriteTimers) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeDebug_WriteTimers_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var writer = CreateType<System.Web.UI.HtmlTextWriter>();
            Action executeAction = null;

            // Act
            executeAction = () => _timeDebugInstance.WriteTimers(writer);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (WriteTimers) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeDebug_WriteTimers_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var writer = CreateType<System.Web.UI.HtmlTextWriter>();
            var methodWriteTimersPrametersTypes = new Type[] { typeof(System.Web.UI.HtmlTextWriter) };
            object[] parametersOfWriteTimers = { writer };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWriteTimers, methodWriteTimersPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_timeDebugInstanceFixture, parametersOfWriteTimers);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWriteTimers.ShouldNotBeNull();
            parametersOfWriteTimers.Length.ShouldBe(1);
            methodWriteTimersPrametersTypes.Length.ShouldBe(1);
            methodWriteTimersPrametersTypes.Length.ShouldBe(parametersOfWriteTimers.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteTimers) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeDebug_WriteTimers_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var writer = CreateType<System.Web.UI.HtmlTextWriter>();
            var methodWriteTimersPrametersTypes = new Type[] { typeof(System.Web.UI.HtmlTextWriter) };
            object[] parametersOfWriteTimers = { writer };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_timeDebugInstance, MethodWriteTimers, parametersOfWriteTimers, methodWriteTimersPrametersTypes);

            // Assert
            parametersOfWriteTimers.ShouldNotBeNull();
            parametersOfWriteTimers.Length.ShouldBe(1);
            methodWriteTimersPrametersTypes.Length.ShouldBe(1);
            methodWriteTimersPrametersTypes.Length.ShouldBe(parametersOfWriteTimers.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteTimers) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeDebug_WriteTimers_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWriteTimers, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WriteTimers) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeDebug_WriteTimers_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWriteTimersPrametersTypes = new Type[] { typeof(System.Web.UI.HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeDebugInstance, MethodWriteTimers, Fixture, methodWriteTimersPrametersTypes);

            // Assert
            methodWriteTimersPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteTimers) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeDebug_WriteTimers_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWriteTimers, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_timeDebugInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetHtml) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TimeDebug_GetHtml_Method_Call_Internally(Type[] types)
        {
            var methodGetHtmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeDebugInstance, MethodGetHtml, Fixture, methodGetHtmlPrametersTypes);
        }

        #endregion

        #region Method Call : (GetHtml) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeDebug_GetHtml_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _timeDebugInstance.GetHtml();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetHtml) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeDebug_GetHtml_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetHtmlPrametersTypes = null;
            object[] parametersOfGetHtml = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetHtml, methodGetHtmlPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_timeDebugInstanceFixture, parametersOfGetHtml);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetHtml.ShouldBeNull();
            methodGetHtmlPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetHtml) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeDebug_GetHtml_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetHtmlPrametersTypes = null;
            object[] parametersOfGetHtml = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<TimeDebug, string>(_timeDebugInstance, MethodGetHtml, parametersOfGetHtml, methodGetHtmlPrametersTypes);

            // Assert
            parametersOfGetHtml.ShouldBeNull();
            methodGetHtmlPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetHtml) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeDebug_GetHtml_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetHtmlPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeDebugInstance, MethodGetHtml, Fixture, methodGetHtmlPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetHtmlPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetHtml) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeDebug_GetHtml_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetHtmlPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeDebugInstance, MethodGetHtml, Fixture, methodGetHtmlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetHtmlPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetHtml) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeDebug_GetHtml_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetHtml, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_timeDebugInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}