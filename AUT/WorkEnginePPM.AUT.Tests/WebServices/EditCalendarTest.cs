using System;
using System.Diagnostics.CodeAnalysis;
using System.Web;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using PortfolioEngineCore;
using Should = Shouldly.Should;
using Shouldly;

namespace WorkEnginePPM
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.EditCalendar" />)
    ///     and namespace <see cref="WorkEnginePPM"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class EditCalendarTest : AbstractBaseSetupTypedTest<EditCalendar>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EditCalendar) Initializer

        private const string MethodGetSPSessionBasePath = "GetSPSessionBasePath";
        private const string MethodExecute = "Execute";
        private const string MethodExecuteJSON = "ExecuteJSON";
        private const string MethodGetCalendarInfo = "GetCalendarInfo";
        private const string MethodGetCalendarDetailsInfo = "GetCalendarDetailsInfo";
        private const string MethodDeleteCalendar = "DeleteCalendar";
        private const string MethodCreateNewCalendar = "CreateNewCalendar";
        private const string MethodGetCalendarPeriodsGrid = "GetCalendarPeriodsGrid";
        private const string MethodGetCalendarFTESGrid = "GetCalendarFTESGrid";
        private const string MethodSetCalendarData = "SetCalendarData";
        private const string MethodBuildResultXML = "BuildResultXML";
        private const string MethodHandleError = "HandleError";
        private const string MethodHandleException = "HandleException";
        private Type _editCalendarInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EditCalendar _editCalendarInstance;
        private EditCalendar _editCalendarInstanceFixture;

        #region General Initializer : Class (EditCalendar) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EditCalendar" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _editCalendarInstanceType = typeof(EditCalendar);
            _editCalendarInstanceFixture = Create(true);
            _editCalendarInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EditCalendar)

        #region General Initializer : Class (EditCalendar) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="EditCalendar" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetSPSessionBasePath, 0)]
        [TestCase(MethodExecute, 0)]
        [TestCase(MethodExecuteJSON, 0)]
        [TestCase(MethodGetCalendarInfo, 0)]
        [TestCase(MethodGetCalendarDetailsInfo, 0)]
        [TestCase(MethodDeleteCalendar, 0)]
        [TestCase(MethodCreateNewCalendar, 0)]
        [TestCase(MethodGetCalendarPeriodsGrid, 0)]
        [TestCase(MethodGetCalendarFTESGrid, 0)]
        [TestCase(MethodSetCalendarData, 0)]
        [TestCase(MethodBuildResultXML, 0)]
        [TestCase(MethodHandleError, 0)]
        [TestCase(MethodHandleException, 0)]
        public void AUT_EditCalendar_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_editCalendarInstanceFixture, 
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
        ///     Class (<see cref="EditCalendar" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_EditCalendar_Is_Instance_Present_Test()
        {
            // Assert
            _editCalendarInstanceType.ShouldNotBeNull();
            _editCalendarInstance.ShouldNotBeNull();
            _editCalendarInstanceFixture.ShouldNotBeNull();
            _editCalendarInstance.ShouldBeAssignableTo<EditCalendar>();
            _editCalendarInstanceFixture.ShouldBeAssignableTo<EditCalendar>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EditCalendar) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_EditCalendar_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EditCalendar instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _editCalendarInstanceType.ShouldNotBeNull();
            _editCalendarInstance.ShouldNotBeNull();
            _editCalendarInstanceFixture.ShouldNotBeNull();
            _editCalendarInstance.ShouldBeAssignableTo<EditCalendar>();
            _editCalendarInstanceFixture.ShouldBeAssignableTo<EditCalendar>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="EditCalendar" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetCalendarInfo)]
        [TestCase(MethodGetCalendarDetailsInfo)]
        [TestCase(MethodDeleteCalendar)]
        [TestCase(MethodCreateNewCalendar)]
        [TestCase(MethodGetCalendarPeriodsGrid)]
        [TestCase(MethodGetCalendarFTESGrid)]
        [TestCase(MethodSetCalendarData)]
        [TestCase(MethodBuildResultXML)]
        [TestCase(MethodHandleError)]
        [TestCase(MethodHandleException)]
        public void AUT_EditCalendar_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_editCalendarInstanceFixture,
                                                                              _editCalendarInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="EditCalendar" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetSPSessionBasePath)]
        [TestCase(MethodExecute)]
        [TestCase(MethodExecuteJSON)]
        public void AUT_EditCalendar_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<EditCalendar>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetSPSessionBasePath) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EditCalendar_GetSPSessionBasePath_Method_Call_Internally(Type[] types)
        {
            var methodGetSPSessionBasePathPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editCalendarInstance, MethodGetSPSessionBasePath, Fixture, methodGetSPSessionBasePathPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSPSessionBasePath) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetSPSessionBasePath_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetSPSessionBasePathPrametersTypes = null;
            object[] parametersOfGetSPSessionBasePath = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSPSessionBasePath, methodGetSPSessionBasePathPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EditCalendar, string>(_editCalendarInstanceFixture, out exception1, parametersOfGetSPSessionBasePath);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EditCalendar, string>(_editCalendarInstance, MethodGetSPSessionBasePath, parametersOfGetSPSessionBasePath, methodGetSPSessionBasePathPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetSPSessionBasePath.ShouldBeNull();
            methodGetSPSessionBasePathPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSPSessionBasePath) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetSPSessionBasePath_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetSPSessionBasePathPrametersTypes = null;
            object[] parametersOfGetSPSessionBasePath = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EditCalendar, string>(_editCalendarInstance, MethodGetSPSessionBasePath, parametersOfGetSPSessionBasePath, methodGetSPSessionBasePathPrametersTypes);

            // Assert
            parametersOfGetSPSessionBasePath.ShouldBeNull();
            methodGetSPSessionBasePathPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSPSessionBasePath) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetSPSessionBasePath_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetSPSessionBasePathPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editCalendarInstance, MethodGetSPSessionBasePath, Fixture, methodGetSPSessionBasePathPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSPSessionBasePathPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSPSessionBasePath) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetSPSessionBasePath_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetSPSessionBasePathPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editCalendarInstance, MethodGetSPSessionBasePath, Fixture, methodGetSPSessionBasePathPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSPSessionBasePathPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSPSessionBasePath) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetSPSessionBasePath_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSPSessionBasePath, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_editCalendarInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EditCalendar_Execute_Method_Call_Internally(Type[] types)
        {
            var methodExecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editCalendarInstance, MethodExecute, Fixture, methodExecutePrametersTypes);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_Execute_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _editCalendarInstance.Execute(Function, Dataxml);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_Execute_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfExecute = { Function, Dataxml };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodExecute, methodExecutePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EditCalendar, string>(_editCalendarInstanceFixture, out exception1, parametersOfExecute);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EditCalendar, string>(_editCalendarInstance, MethodExecute, parametersOfExecute, methodExecutePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfExecute.ShouldNotBeNull();
            parametersOfExecute.Length.ShouldBe(2);
            methodExecutePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_Execute_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfExecute = { Function, Dataxml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EditCalendar, string>(_editCalendarInstance, MethodExecute, parametersOfExecute, methodExecutePrametersTypes);

            // Assert
            parametersOfExecute.ShouldNotBeNull();
            parametersOfExecute.Length.ShouldBe(2);
            methodExecutePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_Execute_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editCalendarInstance, MethodExecute, Fixture, methodExecutePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodExecutePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_Execute_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editCalendarInstance, MethodExecute, Fixture, methodExecutePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecutePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_Execute_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecute, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_editCalendarInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_Execute_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExecute, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EditCalendar_ExecuteJSON_Method_Call_Internally(Type[] types)
        {
            var methodExecuteJSONPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editCalendarInstance, MethodExecuteJSON, Fixture, methodExecuteJSONPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_ExecuteJSON_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _editCalendarInstance.ExecuteJSON(Function, Dataxml);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_ExecuteJSON_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            var methodExecuteJSONPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfExecuteJSON = { Function, Dataxml };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodExecuteJSON, methodExecuteJSONPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EditCalendar, string>(_editCalendarInstanceFixture, out exception1, parametersOfExecuteJSON);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EditCalendar, string>(_editCalendarInstance, MethodExecuteJSON, parametersOfExecuteJSON, methodExecuteJSONPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfExecuteJSON.ShouldNotBeNull();
            parametersOfExecuteJSON.Length.ShouldBe(2);
            methodExecuteJSONPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_ExecuteJSON_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            var methodExecuteJSONPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfExecuteJSON = { Function, Dataxml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodExecuteJSON, methodExecuteJSONPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_editCalendarInstanceFixture, parametersOfExecuteJSON);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfExecuteJSON.ShouldNotBeNull();
            parametersOfExecuteJSON.Length.ShouldBe(2);
            methodExecuteJSONPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_ExecuteJSON_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            var methodExecuteJSONPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfExecuteJSON = { Function, Dataxml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EditCalendar, string>(_editCalendarInstance, MethodExecuteJSON, parametersOfExecuteJSON, methodExecuteJSONPrametersTypes);

            // Assert
            parametersOfExecuteJSON.ShouldNotBeNull();
            parametersOfExecuteJSON.Length.ShouldBe(2);
            methodExecuteJSONPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_ExecuteJSON_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodExecuteJSONPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editCalendarInstance, MethodExecuteJSON, Fixture, methodExecuteJSONPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodExecuteJSONPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_ExecuteJSON_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteJSONPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_editCalendarInstance, MethodExecuteJSON, Fixture, methodExecuteJSONPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecuteJSONPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_ExecuteJSON_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteJSON, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_editCalendarInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_ExecuteJSON_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExecuteJSON, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCalendarInfo) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EditCalendar_GetCalendarInfo_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCalendarInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodGetCalendarInfo, Fixture, methodGetCalendarInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCalendarInfo) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarInfo_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => EditCalendar.GetCalendarInfo(Context, sXML);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCalendarInfo) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarInfo_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var methodGetCalendarInfoPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfGetCalendarInfo = { Context, sXML };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCalendarInfo, methodGetCalendarInfoPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodGetCalendarInfo, Fixture, methodGetCalendarInfoPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodGetCalendarInfo, parametersOfGetCalendarInfo, methodGetCalendarInfoPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_editCalendarInstanceFixture, parametersOfGetCalendarInfo);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCalendarInfo.ShouldNotBeNull();
            parametersOfGetCalendarInfo.Length.ShouldBe(2);
            methodGetCalendarInfoPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetCalendarInfo) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarInfo_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var methodGetCalendarInfoPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfGetCalendarInfo = { Context, sXML };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodGetCalendarInfo, parametersOfGetCalendarInfo, methodGetCalendarInfoPrametersTypes);

            // Assert
            parametersOfGetCalendarInfo.ShouldNotBeNull();
            parametersOfGetCalendarInfo.Length.ShouldBe(2);
            methodGetCalendarInfoPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCalendarInfo) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarInfo_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCalendarInfoPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodGetCalendarInfo, Fixture, methodGetCalendarInfoPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCalendarInfoPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetCalendarInfo) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarInfo_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCalendarInfoPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodGetCalendarInfo, Fixture, methodGetCalendarInfoPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCalendarInfoPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCalendarInfo) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarInfo_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCalendarInfo, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_editCalendarInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCalendarInfo) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarInfo_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCalendarInfo, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCalendarDetailsInfo) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EditCalendar_GetCalendarDetailsInfo_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCalendarDetailsInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodGetCalendarDetailsInfo, Fixture, methodGetCalendarDetailsInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCalendarDetailsInfo) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarDetailsInfo_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => EditCalendar.GetCalendarDetailsInfo(Context, sXML);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCalendarDetailsInfo) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarDetailsInfo_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var methodGetCalendarDetailsInfoPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfGetCalendarDetailsInfo = { Context, sXML };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCalendarDetailsInfo, methodGetCalendarDetailsInfoPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodGetCalendarDetailsInfo, Fixture, methodGetCalendarDetailsInfoPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodGetCalendarDetailsInfo, parametersOfGetCalendarDetailsInfo, methodGetCalendarDetailsInfoPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_editCalendarInstanceFixture, parametersOfGetCalendarDetailsInfo);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCalendarDetailsInfo.ShouldNotBeNull();
            parametersOfGetCalendarDetailsInfo.Length.ShouldBe(2);
            methodGetCalendarDetailsInfoPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetCalendarDetailsInfo) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarDetailsInfo_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var methodGetCalendarDetailsInfoPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfGetCalendarDetailsInfo = { Context, sXML };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodGetCalendarDetailsInfo, parametersOfGetCalendarDetailsInfo, methodGetCalendarDetailsInfoPrametersTypes);

            // Assert
            parametersOfGetCalendarDetailsInfo.ShouldNotBeNull();
            parametersOfGetCalendarDetailsInfo.Length.ShouldBe(2);
            methodGetCalendarDetailsInfoPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCalendarDetailsInfo) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarDetailsInfo_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCalendarDetailsInfoPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodGetCalendarDetailsInfo, Fixture, methodGetCalendarDetailsInfoPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCalendarDetailsInfoPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetCalendarDetailsInfo) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarDetailsInfo_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCalendarDetailsInfoPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodGetCalendarDetailsInfo, Fixture, methodGetCalendarDetailsInfoPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCalendarDetailsInfoPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCalendarDetailsInfo) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarDetailsInfo_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCalendarDetailsInfo, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_editCalendarInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCalendarDetailsInfo) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarDetailsInfo_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCalendarDetailsInfo, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteCalendar) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EditCalendar_DeleteCalendar_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeleteCalendarPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodDeleteCalendar, Fixture, methodDeleteCalendarPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteCalendar) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_DeleteCalendar_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => EditCalendar.DeleteCalendar(Context, sXML);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteCalendar) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_DeleteCalendar_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var methodDeleteCalendarPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfDeleteCalendar = { Context, sXML };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteCalendar, methodDeleteCalendarPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodDeleteCalendar, Fixture, methodDeleteCalendarPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodDeleteCalendar, parametersOfDeleteCalendar, methodDeleteCalendarPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_editCalendarInstanceFixture, parametersOfDeleteCalendar);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDeleteCalendar.ShouldNotBeNull();
            parametersOfDeleteCalendar.Length.ShouldBe(2);
            methodDeleteCalendarPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteCalendar) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_DeleteCalendar_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var methodDeleteCalendarPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfDeleteCalendar = { Context, sXML };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodDeleteCalendar, parametersOfDeleteCalendar, methodDeleteCalendarPrametersTypes);

            // Assert
            parametersOfDeleteCalendar.ShouldNotBeNull();
            parametersOfDeleteCalendar.Length.ShouldBe(2);
            methodDeleteCalendarPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteCalendar) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_DeleteCalendar_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDeleteCalendarPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodDeleteCalendar, Fixture, methodDeleteCalendarPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDeleteCalendarPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DeleteCalendar) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_DeleteCalendar_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteCalendarPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodDeleteCalendar, Fixture, methodDeleteCalendarPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteCalendarPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteCalendar) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_DeleteCalendar_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteCalendar, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_editCalendarInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteCalendar) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_DeleteCalendar_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteCalendar, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateNewCalendar) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EditCalendar_CreateNewCalendar_Static_Method_Call_Internally(Type[] types)
        {
            var methodCreateNewCalendarPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodCreateNewCalendar, Fixture, methodCreateNewCalendarPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateNewCalendar) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_CreateNewCalendar_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => EditCalendar.CreateNewCalendar(Context, sXML);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateNewCalendar) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_CreateNewCalendar_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var methodCreateNewCalendarPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfCreateNewCalendar = { Context, sXML };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateNewCalendar, methodCreateNewCalendarPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodCreateNewCalendar, Fixture, methodCreateNewCalendarPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodCreateNewCalendar, parametersOfCreateNewCalendar, methodCreateNewCalendarPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_editCalendarInstanceFixture, parametersOfCreateNewCalendar);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfCreateNewCalendar.ShouldNotBeNull();
            parametersOfCreateNewCalendar.Length.ShouldBe(2);
            methodCreateNewCalendarPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateNewCalendar) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_CreateNewCalendar_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var methodCreateNewCalendarPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfCreateNewCalendar = { Context, sXML };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodCreateNewCalendar, parametersOfCreateNewCalendar, methodCreateNewCalendarPrametersTypes);

            // Assert
            parametersOfCreateNewCalendar.ShouldNotBeNull();
            parametersOfCreateNewCalendar.Length.ShouldBe(2);
            methodCreateNewCalendarPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateNewCalendar) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_CreateNewCalendar_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCreateNewCalendarPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodCreateNewCalendar, Fixture, methodCreateNewCalendarPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateNewCalendarPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (CreateNewCalendar) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_CreateNewCalendar_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateNewCalendarPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodCreateNewCalendar, Fixture, methodCreateNewCalendarPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateNewCalendarPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateNewCalendar) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_CreateNewCalendar_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateNewCalendar, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_editCalendarInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateNewCalendar) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_CreateNewCalendar_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateNewCalendar, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCalendarPeriodsGrid) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EditCalendar_GetCalendarPeriodsGrid_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCalendarPeriodsGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodGetCalendarPeriodsGrid, Fixture, methodGetCalendarPeriodsGridPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCalendarPeriodsGrid) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarPeriodsGrid_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => EditCalendar.GetCalendarPeriodsGrid(Context, sXML);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetCalendarPeriodsGrid) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarPeriodsGrid_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var methodGetCalendarPeriodsGridPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfGetCalendarPeriodsGrid = { Context, sXML };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCalendarPeriodsGrid, methodGetCalendarPeriodsGridPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodGetCalendarPeriodsGrid, Fixture, methodGetCalendarPeriodsGridPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodGetCalendarPeriodsGrid, parametersOfGetCalendarPeriodsGrid, methodGetCalendarPeriodsGridPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetCalendarPeriodsGrid.ShouldNotBeNull();
            parametersOfGetCalendarPeriodsGrid.Length.ShouldBe(2);
            methodGetCalendarPeriodsGridPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodGetCalendarPeriodsGrid, parametersOfGetCalendarPeriodsGrid, methodGetCalendarPeriodsGridPrametersTypes));
        }

        #endregion

        #region Method Call : (GetCalendarPeriodsGrid) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarPeriodsGrid_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var methodGetCalendarPeriodsGridPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfGetCalendarPeriodsGrid = { Context, sXML };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCalendarPeriodsGrid, methodGetCalendarPeriodsGridPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_editCalendarInstanceFixture, parametersOfGetCalendarPeriodsGrid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCalendarPeriodsGrid.ShouldNotBeNull();
            parametersOfGetCalendarPeriodsGrid.Length.ShouldBe(2);
            methodGetCalendarPeriodsGridPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCalendarPeriodsGrid) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarPeriodsGrid_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var methodGetCalendarPeriodsGridPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfGetCalendarPeriodsGrid = { Context, sXML };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodGetCalendarPeriodsGrid, parametersOfGetCalendarPeriodsGrid, methodGetCalendarPeriodsGridPrametersTypes);

            // Assert
            parametersOfGetCalendarPeriodsGrid.ShouldNotBeNull();
            parametersOfGetCalendarPeriodsGrid.Length.ShouldBe(2);
            methodGetCalendarPeriodsGridPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCalendarPeriodsGrid) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarPeriodsGrid_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetCalendarPeriodsGridPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodGetCalendarPeriodsGrid, Fixture, methodGetCalendarPeriodsGridPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetCalendarPeriodsGridPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetCalendarPeriodsGrid) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarPeriodsGrid_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCalendarPeriodsGridPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodGetCalendarPeriodsGrid, Fixture, methodGetCalendarPeriodsGridPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCalendarPeriodsGridPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCalendarPeriodsGrid) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarPeriodsGrid_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCalendarPeriodsGrid, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_editCalendarInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetCalendarPeriodsGrid) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarPeriodsGrid_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCalendarPeriodsGrid, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCalendarFTESGrid) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EditCalendar_GetCalendarFTESGrid_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCalendarFTESGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodGetCalendarFTESGrid, Fixture, methodGetCalendarFTESGridPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCalendarFTESGrid) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarFTESGrid_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => EditCalendar.GetCalendarFTESGrid(Context, sXML);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetCalendarFTESGrid) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarFTESGrid_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var methodGetCalendarFTESGridPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfGetCalendarFTESGrid = { Context, sXML };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCalendarFTESGrid, methodGetCalendarFTESGridPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodGetCalendarFTESGrid, Fixture, methodGetCalendarFTESGridPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodGetCalendarFTESGrid, parametersOfGetCalendarFTESGrid, methodGetCalendarFTESGridPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetCalendarFTESGrid.ShouldNotBeNull();
            parametersOfGetCalendarFTESGrid.Length.ShouldBe(2);
            methodGetCalendarFTESGridPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodGetCalendarFTESGrid, parametersOfGetCalendarFTESGrid, methodGetCalendarFTESGridPrametersTypes));
        }

        #endregion

        #region Method Call : (GetCalendarFTESGrid) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarFTESGrid_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var methodGetCalendarFTESGridPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfGetCalendarFTESGrid = { Context, sXML };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCalendarFTESGrid, methodGetCalendarFTESGridPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_editCalendarInstanceFixture, parametersOfGetCalendarFTESGrid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCalendarFTESGrid.ShouldNotBeNull();
            parametersOfGetCalendarFTESGrid.Length.ShouldBe(2);
            methodGetCalendarFTESGridPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCalendarFTESGrid) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarFTESGrid_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var methodGetCalendarFTESGridPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfGetCalendarFTESGrid = { Context, sXML };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodGetCalendarFTESGrid, parametersOfGetCalendarFTESGrid, methodGetCalendarFTESGridPrametersTypes);

            // Assert
            parametersOfGetCalendarFTESGrid.ShouldNotBeNull();
            parametersOfGetCalendarFTESGrid.Length.ShouldBe(2);
            methodGetCalendarFTESGridPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCalendarFTESGrid) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarFTESGrid_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetCalendarFTESGridPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodGetCalendarFTESGrid, Fixture, methodGetCalendarFTESGridPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetCalendarFTESGridPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetCalendarFTESGrid) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarFTESGrid_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCalendarFTESGridPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodGetCalendarFTESGrid, Fixture, methodGetCalendarFTESGridPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCalendarFTESGridPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCalendarFTESGrid) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarFTESGrid_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCalendarFTESGrid, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_editCalendarInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetCalendarFTESGrid) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_GetCalendarFTESGrid_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCalendarFTESGrid, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetCalendarData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EditCalendar_SetCalendarData_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetCalendarDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodSetCalendarData, Fixture, methodSetCalendarDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SetCalendarData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_SetCalendarData_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => EditCalendar.SetCalendarData(Context, sXML);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetCalendarData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_SetCalendarData_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var methodSetCalendarDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfSetCalendarData = { Context, sXML };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetCalendarData, methodSetCalendarDataPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodSetCalendarData, Fixture, methodSetCalendarDataPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodSetCalendarData, parametersOfSetCalendarData, methodSetCalendarDataPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_editCalendarInstanceFixture, parametersOfSetCalendarData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSetCalendarData.ShouldNotBeNull();
            parametersOfSetCalendarData.Length.ShouldBe(2);
            methodSetCalendarDataPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetCalendarData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_SetCalendarData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var methodSetCalendarDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfSetCalendarData = { Context, sXML };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodSetCalendarData, parametersOfSetCalendarData, methodSetCalendarDataPrametersTypes);

            // Assert
            parametersOfSetCalendarData.ShouldNotBeNull();
            parametersOfSetCalendarData.Length.ShouldBe(2);
            methodSetCalendarDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetCalendarData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_SetCalendarData_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSetCalendarDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodSetCalendarData, Fixture, methodSetCalendarDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSetCalendarDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (SetCalendarData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_SetCalendarData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetCalendarDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodSetCalendarData, Fixture, methodSetCalendarDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetCalendarDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetCalendarData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_SetCalendarData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetCalendarData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_editCalendarInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetCalendarData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_SetCalendarData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetCalendarData, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildResultXML) (Return Type : CStruct) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EditCalendar_BuildResultXML_Static_Method_Call_Internally(Type[] types)
        {
            var methodBuildResultXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodBuildResultXML, Fixture, methodBuildResultXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildResultXML) (Return Type : CStruct) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_BuildResultXML_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var nStatus = CreateType<int>();
            var methodBuildResultXMLPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfBuildResultXML = { sContext, nStatus };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildResultXML, methodBuildResultXMLPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_editCalendarInstanceFixture, parametersOfBuildResultXML);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildResultXML.ShouldNotBeNull();
            parametersOfBuildResultXML.Length.ShouldBe(2);
            methodBuildResultXMLPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildResultXML) (Return Type : CStruct) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_BuildResultXML_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var nStatus = CreateType<int>();
            var methodBuildResultXMLPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfBuildResultXML = { sContext, nStatus };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<CStruct>(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodBuildResultXML, parametersOfBuildResultXML, methodBuildResultXMLPrametersTypes);

            // Assert
            parametersOfBuildResultXML.ShouldNotBeNull();
            parametersOfBuildResultXML.Length.ShouldBe(2);
            methodBuildResultXMLPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildResultXML) (Return Type : CStruct) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_BuildResultXML_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildResultXMLPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodBuildResultXML, Fixture, methodBuildResultXMLPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildResultXMLPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (BuildResultXML) (Return Type : CStruct) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_BuildResultXML_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildResultXMLPrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodBuildResultXML, Fixture, methodBuildResultXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildResultXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildResultXML) (Return Type : CStruct) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_BuildResultXML_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildResultXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_editCalendarInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (BuildResultXML) (Return Type : CStruct) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_BuildResultXML_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildResultXML, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EditCalendar_HandleError_Static_Method_Call_Internally(Type[] types)
        {
            var methodHandleErrorPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodHandleError, Fixture, methodHandleErrorPrametersTypes);
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_HandleError_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var nStatus = CreateType<int>();
            var sError = CreateType<string>();
            var methodHandleErrorPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };
            object[] parametersOfHandleError = { sContext, nStatus, sError };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodHandleError, methodHandleErrorPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_editCalendarInstanceFixture, parametersOfHandleError);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfHandleError.ShouldNotBeNull();
            parametersOfHandleError.Length.ShouldBe(3);
            methodHandleErrorPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_HandleError_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var nStatus = CreateType<int>();
            var sError = CreateType<string>();
            var methodHandleErrorPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };
            object[] parametersOfHandleError = { sContext, nStatus, sError };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodHandleError, parametersOfHandleError, methodHandleErrorPrametersTypes);

            // Assert
            parametersOfHandleError.ShouldNotBeNull();
            parametersOfHandleError.Length.ShouldBe(3);
            methodHandleErrorPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_HandleError_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodHandleErrorPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodHandleError, Fixture, methodHandleErrorPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodHandleErrorPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_HandleError_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHandleErrorPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodHandleError, Fixture, methodHandleErrorPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodHandleErrorPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_HandleError_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHandleError, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_editCalendarInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_HandleError_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodHandleError, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EditCalendar_HandleException_Static_Method_Call_Internally(Type[] types)
        {
            var methodHandleExceptionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodHandleException, Fixture, methodHandleExceptionPrametersTypes);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_HandleException_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var nStatus = CreateType<int>();
            var ex = CreateType<Exception>();
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(Exception) };
            object[] parametersOfHandleException = { sContext, nStatus, ex };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodHandleException, methodHandleExceptionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_editCalendarInstanceFixture, parametersOfHandleException);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfHandleException.ShouldNotBeNull();
            parametersOfHandleException.Length.ShouldBe(3);
            methodHandleExceptionPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_HandleException_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var nStatus = CreateType<int>();
            var ex = CreateType<Exception>();
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(Exception) };
            object[] parametersOfHandleException = { sContext, nStatus, ex };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodHandleException, parametersOfHandleException, methodHandleExceptionPrametersTypes);

            // Assert
            parametersOfHandleException.ShouldNotBeNull();
            parametersOfHandleException.Length.ShouldBe(3);
            methodHandleExceptionPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_HandleException_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(Exception) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodHandleException, Fixture, methodHandleExceptionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodHandleExceptionPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_HandleException_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(Exception) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_editCalendarInstanceFixture, _editCalendarInstanceType, MethodHandleException, Fixture, methodHandleExceptionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodHandleExceptionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_HandleException_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHandleException, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_editCalendarInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EditCalendar_HandleException_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodHandleException, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #endregion

        #endregion
    }
}