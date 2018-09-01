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

namespace PortfolioEngineCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.Debugger" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class DebuggerTest : AbstractBaseSetupTypedTest<Debugger>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Debugger) Initializer

        private const string MethodAddMessage = "AddMessage";
        private const string MethodGetMessage = "GetMessage";
        private const string Fieldmessage = "message";
        private const string Field_debug = "_debug";
        private Type _debuggerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Debugger _debuggerInstance;
        private Debugger _debuggerInstanceFixture;

        #region General Initializer : Class (Debugger) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Debugger" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _debuggerInstanceType = typeof(Debugger);
            _debuggerInstanceFixture = Create(true);
            _debuggerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Debugger)

        #region General Initializer : Class (Debugger) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Debugger" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodAddMessage, 0)]
        [TestCase(MethodGetMessage, 0)]
        public void AUT_Debugger_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_debuggerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Debugger) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Debugger" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldmessage)]
        [TestCase(Field_debug)]
        public void AUT_Debugger_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_debuggerInstanceFixture, 
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
        ///     Class (<see cref="Debugger" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Debugger_Is_Instance_Present_Test()
        {
            // Assert
            _debuggerInstanceType.ShouldNotBeNull();
            _debuggerInstance.ShouldNotBeNull();
            _debuggerInstanceFixture.ShouldNotBeNull();
            _debuggerInstance.ShouldBeAssignableTo<Debugger>();
            _debuggerInstanceFixture.ShouldBeAssignableTo<Debugger>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Debugger) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Debugger_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var debug = CreateType<bool>();
            Debugger instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new Debugger(debug);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _debuggerInstance.ShouldNotBeNull();
            _debuggerInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<Debugger>();
        }

        #endregion

        #region General Constructor : Class (Debugger) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Debugger_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var debug = CreateType<bool>();
            Debugger instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new Debugger(debug);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _debuggerInstance.ShouldNotBeNull();
            _debuggerInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Debugger" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodAddMessage)]
        [TestCase(MethodGetMessage)]
        public void AUT_Debugger_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Debugger>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (AddMessage) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Debugger_AddMessage_Method_Call_Internally(Type[] types)
        {
            var methodAddMessagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_debuggerInstance, MethodAddMessage, Fixture, methodAddMessagePrametersTypes);
        }

        #endregion

        #region Method Call : (AddMessage) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Debugger_AddMessage_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var msg = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _debuggerInstance.AddMessage(msg);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (AddMessage) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Debugger_AddMessage_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var msg = CreateType<string>();
            var methodAddMessagePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfAddMessage = { msg };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddMessage, methodAddMessagePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_debuggerInstanceFixture, parametersOfAddMessage);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddMessage.ShouldNotBeNull();
            parametersOfAddMessage.Length.ShouldBe(1);
            methodAddMessagePrametersTypes.Length.ShouldBe(1);
            methodAddMessagePrametersTypes.Length.ShouldBe(parametersOfAddMessage.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddMessage) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Debugger_AddMessage_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var msg = CreateType<string>();
            var methodAddMessagePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfAddMessage = { msg };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_debuggerInstance, MethodAddMessage, parametersOfAddMessage, methodAddMessagePrametersTypes);

            // Assert
            parametersOfAddMessage.ShouldNotBeNull();
            parametersOfAddMessage.Length.ShouldBe(1);
            methodAddMessagePrametersTypes.Length.ShouldBe(1);
            methodAddMessagePrametersTypes.Length.ShouldBe(parametersOfAddMessage.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddMessage) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Debugger_AddMessage_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddMessage, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddMessage) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Debugger_AddMessage_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddMessagePrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_debuggerInstance, MethodAddMessage, Fixture, methodAddMessagePrametersTypes);

            // Assert
            methodAddMessagePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddMessage) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Debugger_AddMessage_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddMessage, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_debuggerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMessage) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Debugger_GetMessage_Method_Call_Internally(Type[] types)
        {
            var methodGetMessagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_debuggerInstance, MethodGetMessage, Fixture, methodGetMessagePrametersTypes);
        }

        #endregion

        #region Method Call : (GetMessage) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Debugger_GetMessage_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _debuggerInstance.GetMessage();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetMessage) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Debugger_GetMessage_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetMessagePrametersTypes = null;
            object[] parametersOfGetMessage = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetMessage, methodGetMessagePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_debuggerInstanceFixture, parametersOfGetMessage);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetMessage.ShouldBeNull();
            methodGetMessagePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMessage) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Debugger_GetMessage_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetMessagePrametersTypes = null;
            object[] parametersOfGetMessage = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Debugger, string>(_debuggerInstance, MethodGetMessage, parametersOfGetMessage, methodGetMessagePrametersTypes);

            // Assert
            parametersOfGetMessage.ShouldBeNull();
            methodGetMessagePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMessage) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Debugger_GetMessage_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetMessagePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_debuggerInstance, MethodGetMessage, Fixture, methodGetMessagePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetMessagePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMessage) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Debugger_GetMessage_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetMessagePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_debuggerInstance, MethodGetMessage, Fixture, methodGetMessagePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMessagePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMessage) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Debugger_GetMessage_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMessage, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_debuggerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}