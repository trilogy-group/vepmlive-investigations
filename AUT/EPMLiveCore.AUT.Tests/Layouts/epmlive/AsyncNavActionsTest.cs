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

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.AsyncNavActions" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AsyncNavActionsTest : AbstractBaseSetupTypedTest<AsyncNavActions>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AsyncNavActions) Initializer

        private const string MethodGetParams = "GetParams";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodExecute = "Execute";
        private const string MethodOutputResult = "OutputResult";
        private const string Field_action = "_action";
        private const string Field_appId = "_appId";
        private const string Field_origUserId = "_origUserId";
        private const string Field_title = "_title";
        private const string Field_url = "_url";
        private const string Field_nodeType = "_nodeType";
        private const string Field_headingNodeId = "_headingNodeId";
        private const string Field_nodeId = "_nodeId";
        private const string Field_parentNodeId = "_parentNodeId";
        private const string Field_moveInfos = "_moveInfos";
        private const string FieldappHelper = "appHelper";
        private const string Field_status = "_status";
        private Type _asyncNavActionsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AsyncNavActions _asyncNavActionsInstance;
        private AsyncNavActions _asyncNavActionsInstanceFixture;

        #region General Initializer : Class (AsyncNavActions) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AsyncNavActions" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _asyncNavActionsInstanceType = typeof(AsyncNavActions);
            _asyncNavActionsInstanceFixture = Create(true);
            _asyncNavActionsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AsyncNavActions)

        #region General Initializer : Class (AsyncNavActions) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="AsyncNavActions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetParams, 0)]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodExecute, 0)]
        [TestCase(MethodOutputResult, 0)]
        public void AUT_AsyncNavActions_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_asyncNavActionsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AsyncNavActions) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="AsyncNavActions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_action)]
        [TestCase(Field_appId)]
        [TestCase(Field_origUserId)]
        [TestCase(Field_title)]
        [TestCase(Field_url)]
        [TestCase(Field_nodeType)]
        [TestCase(Field_headingNodeId)]
        [TestCase(Field_nodeId)]
        [TestCase(Field_parentNodeId)]
        [TestCase(Field_moveInfos)]
        [TestCase(FieldappHelper)]
        [TestCase(Field_status)]
        public void AUT_AsyncNavActions_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_asyncNavActionsInstanceFixture, 
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
        ///     Class (<see cref="AsyncNavActions" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_AsyncNavActions_Is_Instance_Present_Test()
        {
            // Assert
            _asyncNavActionsInstanceType.ShouldNotBeNull();
            _asyncNavActionsInstance.ShouldNotBeNull();
            _asyncNavActionsInstanceFixture.ShouldNotBeNull();
            _asyncNavActionsInstance.ShouldBeAssignableTo<AsyncNavActions>();
            _asyncNavActionsInstanceFixture.ShouldBeAssignableTo<AsyncNavActions>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (AsyncNavActions) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_AsyncNavActions_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            AsyncNavActions instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _asyncNavActionsInstanceType.ShouldNotBeNull();
            _asyncNavActionsInstance.ShouldNotBeNull();
            _asyncNavActionsInstanceFixture.ShouldNotBeNull();
            _asyncNavActionsInstance.ShouldBeAssignableTo<AsyncNavActions>();
            _asyncNavActionsInstanceFixture.ShouldBeAssignableTo<AsyncNavActions>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="AsyncNavActions" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetParams)]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodExecute)]
        [TestCase(MethodOutputResult)]
        public void AUT_AsyncNavActions_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<AsyncNavActions>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetParams) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AsyncNavActions_GetParams_Method_Call_Internally(Type[] types)
        {
            var methodGetParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_asyncNavActionsInstance, MethodGetParams, Fixture, methodGetParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetParams) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AsyncNavActions_GetParams_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetParamsPrametersTypes = null;
            object[] parametersOfGetParams = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetParams, methodGetParamsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_asyncNavActionsInstanceFixture, parametersOfGetParams);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetParams.ShouldBeNull();
            methodGetParamsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetParams) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AsyncNavActions_GetParams_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetParamsPrametersTypes = null;
            object[] parametersOfGetParams = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_asyncNavActionsInstance, MethodGetParams, parametersOfGetParams, methodGetParamsPrametersTypes);

            // Assert
            parametersOfGetParams.ShouldBeNull();
            methodGetParamsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetParams) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AsyncNavActions_GetParams_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetParamsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_asyncNavActionsInstance, MethodGetParams, Fixture, methodGetParamsPrametersTypes);

            // Assert
            methodGetParamsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetParams) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AsyncNavActions_GetParams_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetParams, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_asyncNavActionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AsyncNavActions_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_asyncNavActionsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AsyncNavActions_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_asyncNavActionsInstanceFixture, parametersOfPage_Load);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AsyncNavActions_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_asyncNavActionsInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

            // Assert
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AsyncNavActions_Page_Load_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AsyncNavActions_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_asyncNavActionsInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AsyncNavActions_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_asyncNavActionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AsyncNavActions_Execute_Method_Call_Internally(Type[] types)
        {
            var methodExecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_asyncNavActionsInstance, MethodExecute, Fixture, methodExecutePrametersTypes);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AsyncNavActions_Execute_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodExecutePrametersTypes = null;
            object[] parametersOfExecute = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodExecute, methodExecutePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_asyncNavActionsInstanceFixture, parametersOfExecute);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfExecute.ShouldBeNull();
            methodExecutePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AsyncNavActions_Execute_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodExecutePrametersTypes = null;
            object[] parametersOfExecute = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_asyncNavActionsInstance, MethodExecute, parametersOfExecute, methodExecutePrametersTypes);

            // Assert
            parametersOfExecute.ShouldBeNull();
            methodExecutePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AsyncNavActions_Execute_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodExecutePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_asyncNavActionsInstance, MethodExecute, Fixture, methodExecutePrametersTypes);

            // Assert
            methodExecutePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AsyncNavActions_Execute_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecute, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_asyncNavActionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OutputResult) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AsyncNavActions_OutputResult_Method_Call_Internally(Type[] types)
        {
            var methodOutputResultPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_asyncNavActionsInstance, MethodOutputResult, Fixture, methodOutputResultPrametersTypes);
        }

        #endregion

        #region Method Call : (OutputResult) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AsyncNavActions_OutputResult_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodOutputResultPrametersTypes = null;
            object[] parametersOfOutputResult = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOutputResult, methodOutputResultPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_asyncNavActionsInstanceFixture, parametersOfOutputResult);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOutputResult.ShouldBeNull();
            methodOutputResultPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OutputResult) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AsyncNavActions_OutputResult_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodOutputResultPrametersTypes = null;
            object[] parametersOfOutputResult = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_asyncNavActionsInstance, MethodOutputResult, parametersOfOutputResult, methodOutputResultPrametersTypes);

            // Assert
            parametersOfOutputResult.ShouldBeNull();
            methodOutputResultPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OutputResult) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AsyncNavActions_OutputResult_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodOutputResultPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_asyncNavActionsInstance, MethodOutputResult, Fixture, methodOutputResultPrametersTypes);

            // Assert
            methodOutputResultPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OutputResult) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AsyncNavActions_OutputResult_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOutputResult, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_asyncNavActionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}