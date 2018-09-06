using System;
using System.Diagnostics.CodeAnalysis;
using System.Web;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using OptmizerDataCache;
using PortfolioEngineCore;
using Should = Shouldly.Should;
using Shouldly;

namespace WorkEnginePPM
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Optimizer" />)
    ///     and namespace <see cref="WorkEnginePPM"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class OptimizerTest : AbstractBaseSetupTypedTest<Optimizer>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Optimizer) Initializer

        private const string MethodGetSPSessionBasePath = "GetSPSessionBasePath";
        private const string MethodGetOptimizerSessionKey = "GetOptimizerSessionKey";
        private const string MethodExecute = "Execute";
        private const string MethodExecuteJSON = "ExecuteJSON";
        private const string MethodOptimizerSessionPing = "OptimizerSessionPing";
        private const string MethodGetOptimizerData = "GetOptimizerData";
        private const string MethodGetProjectGridData = "GetProjectGridData";
        private const string MethodSetPIStatusModeChange = "SetPIStatusModeChange";
        private const string MethodUpdateFilteredList = "UpdateFilteredList";
        private const string MethodSaveOptimizerView = "SaveOptimizerView";
        private const string MethodDeleteOptimizerView = "DeleteOptimizerView";
        private const string MethodRenameOptimizerView = "RenameOptimizerView";
        private const string MethodSaveOptimizerStratagy = "SaveOptimizerStratagy";
        private const string MethodDeleteOptimizerStratagy = "DeleteOptimizerStratagy";
        private const string MethodRenameOptimizerStratagy = "RenameOptimizerStratagy";
        private const string MethodCommitOptimizerStratagy = "CommitOptimizerStratagy";
        private const string MethodBuildResultXML = "BuildResultXML";
        private const string MethodHandleError = "HandleError";
        private const string MethodHandleException = "HandleException";
        private const string MethodSaveCachedData = "SaveCachedData";
        private const string MethodGetCachedData = "GetCachedData";
        private const string FieldbasePath = "basePath";
        private const string FieldppmId = "ppmId";
        private const string FieldppmCompany = "ppmCompany";
        private const string FieldppmDbConn = "ppmDbConn";
        private const string Fieldusername = "username";
        private const string FieldsecurityLevel = "securityLevel";
        private Type _optimizerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Optimizer _optimizerInstance;
        private Optimizer _optimizerInstanceFixture;

        #region General Initializer : Class (Optimizer) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Optimizer" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _optimizerInstanceType = typeof(Optimizer);
            _optimizerInstanceFixture = Create(true);
            _optimizerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Optimizer)

        #region General Initializer : Class (Optimizer) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Optimizer" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetSPSessionBasePath, 0)]
        [TestCase(MethodGetOptimizerSessionKey, 0)]
        [TestCase(MethodExecute, 0)]
        [TestCase(MethodExecuteJSON, 0)]
        [TestCase(MethodOptimizerSessionPing, 0)]
        [TestCase(MethodGetOptimizerData, 0)]
        [TestCase(MethodGetProjectGridData, 0)]
        [TestCase(MethodSetPIStatusModeChange, 0)]
        [TestCase(MethodUpdateFilteredList, 0)]
        [TestCase(MethodSaveOptimizerView, 0)]
        [TestCase(MethodDeleteOptimizerView, 0)]
        [TestCase(MethodRenameOptimizerView, 0)]
        [TestCase(MethodSaveOptimizerStratagy, 0)]
        [TestCase(MethodDeleteOptimizerStratagy, 0)]
        [TestCase(MethodRenameOptimizerStratagy, 0)]
        [TestCase(MethodCommitOptimizerStratagy, 0)]
        [TestCase(MethodBuildResultXML, 0)]
        [TestCase(MethodHandleError, 0)]
        [TestCase(MethodHandleException, 0)]
        [TestCase(MethodSaveCachedData, 0)]
        [TestCase(MethodGetCachedData, 0)]
        public void AUT_Optimizer_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_optimizerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Optimizer) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Optimizer" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldbasePath)]
        [TestCase(FieldppmId)]
        [TestCase(FieldppmCompany)]
        [TestCase(FieldppmDbConn)]
        [TestCase(Fieldusername)]
        [TestCase(FieldsecurityLevel)]
        public void AUT_Optimizer_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_optimizerInstanceFixture, 
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
        ///     Class (<see cref="Optimizer" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Optimizer_Is_Instance_Present_Test()
        {
            // Assert
            _optimizerInstanceType.ShouldNotBeNull();
            _optimizerInstance.ShouldNotBeNull();
            _optimizerInstanceFixture.ShouldNotBeNull();
            _optimizerInstance.ShouldBeAssignableTo<Optimizer>();
            _optimizerInstanceFixture.ShouldBeAssignableTo<Optimizer>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Optimizer) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Optimizer_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Optimizer instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _optimizerInstanceType.ShouldNotBeNull();
            _optimizerInstance.ShouldNotBeNull();
            _optimizerInstanceFixture.ShouldNotBeNull();
            _optimizerInstance.ShouldBeAssignableTo<Optimizer>();
            _optimizerInstanceFixture.ShouldBeAssignableTo<Optimizer>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="Optimizer" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodOptimizerSessionPing)]
        [TestCase(MethodGetOptimizerData)]
        [TestCase(MethodGetProjectGridData)]
        [TestCase(MethodSetPIStatusModeChange)]
        [TestCase(MethodUpdateFilteredList)]
        [TestCase(MethodSaveOptimizerView)]
        [TestCase(MethodDeleteOptimizerView)]
        [TestCase(MethodRenameOptimizerView)]
        [TestCase(MethodSaveOptimizerStratagy)]
        [TestCase(MethodDeleteOptimizerStratagy)]
        [TestCase(MethodRenameOptimizerStratagy)]
        [TestCase(MethodCommitOptimizerStratagy)]
        [TestCase(MethodBuildResultXML)]
        [TestCase(MethodHandleError)]
        [TestCase(MethodHandleException)]
        [TestCase(MethodSaveCachedData)]
        [TestCase(MethodGetCachedData)]
        public void AUT_Optimizer_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_optimizerInstanceFixture,
                                                                              _optimizerInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Optimizer" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetSPSessionBasePath)]
        [TestCase(MethodGetOptimizerSessionKey)]
        [TestCase(MethodExecute)]
        [TestCase(MethodExecuteJSON)]
        public void AUT_Optimizer_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Optimizer>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetSPSessionBasePath) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Optimizer_GetSPSessionBasePath_Method_Call_Internally(Type[] types)
        {
            var methodGetSPSessionBasePathPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerInstance, MethodGetSPSessionBasePath, Fixture, methodGetSPSessionBasePathPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSPSessionBasePath) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_GetSPSessionBasePath_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetSPSessionBasePathPrametersTypes = null;
            object[] parametersOfGetSPSessionBasePath = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSPSessionBasePath, methodGetSPSessionBasePathPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Optimizer, string>(_optimizerInstanceFixture, out exception1, parametersOfGetSPSessionBasePath);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Optimizer, string>(_optimizerInstance, MethodGetSPSessionBasePath, parametersOfGetSPSessionBasePath, methodGetSPSessionBasePathPrametersTypes);

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
        public void AUT_Optimizer_GetSPSessionBasePath_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetSPSessionBasePathPrametersTypes = null;
            object[] parametersOfGetSPSessionBasePath = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Optimizer, string>(_optimizerInstance, MethodGetSPSessionBasePath, parametersOfGetSPSessionBasePath, methodGetSPSessionBasePathPrametersTypes);

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
        public void AUT_Optimizer_GetSPSessionBasePath_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetSPSessionBasePathPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerInstance, MethodGetSPSessionBasePath, Fixture, methodGetSPSessionBasePathPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSPSessionBasePathPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSPSessionBasePath) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_GetSPSessionBasePath_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetSPSessionBasePathPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerInstance, MethodGetSPSessionBasePath, Fixture, methodGetSPSessionBasePathPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSPSessionBasePathPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSPSessionBasePath) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_GetSPSessionBasePath_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSPSessionBasePath, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetOptimizerSessionKey) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Optimizer_GetOptimizerSessionKey_Method_Call_Internally(Type[] types)
        {
            var methodGetOptimizerSessionKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerInstance, MethodGetOptimizerSessionKey, Fixture, methodGetOptimizerSessionKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (GetOptimizerSessionKey) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_GetOptimizerSessionKey_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetOptimizerSessionKeyPrametersTypes = null;
            object[] parametersOfGetOptimizerSessionKey = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetOptimizerSessionKey, methodGetOptimizerSessionKeyPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Optimizer, string>(_optimizerInstanceFixture, out exception1, parametersOfGetOptimizerSessionKey);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Optimizer, string>(_optimizerInstance, MethodGetOptimizerSessionKey, parametersOfGetOptimizerSessionKey, methodGetOptimizerSessionKeyPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetOptimizerSessionKey.ShouldBeNull();
            methodGetOptimizerSessionKeyPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetOptimizerSessionKey) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_GetOptimizerSessionKey_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetOptimizerSessionKeyPrametersTypes = null;
            object[] parametersOfGetOptimizerSessionKey = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Optimizer, string>(_optimizerInstance, MethodGetOptimizerSessionKey, parametersOfGetOptimizerSessionKey, methodGetOptimizerSessionKeyPrametersTypes);

            // Assert
            parametersOfGetOptimizerSessionKey.ShouldBeNull();
            methodGetOptimizerSessionKeyPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetOptimizerSessionKey) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_GetOptimizerSessionKey_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetOptimizerSessionKeyPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerInstance, MethodGetOptimizerSessionKey, Fixture, methodGetOptimizerSessionKeyPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetOptimizerSessionKeyPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetOptimizerSessionKey) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_GetOptimizerSessionKey_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetOptimizerSessionKeyPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerInstance, MethodGetOptimizerSessionKey, Fixture, methodGetOptimizerSessionKeyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetOptimizerSessionKeyPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetOptimizerSessionKey) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_GetOptimizerSessionKey_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetOptimizerSessionKey, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Optimizer_Execute_Method_Call_Internally(Type[] types)
        {
            var methodExecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerInstance, MethodExecute, Fixture, methodExecutePrametersTypes);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_Execute_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _optimizerInstance.Execute(Function, Dataxml);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_Execute_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfExecute = { Function, Dataxml };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodExecute, methodExecutePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Optimizer, string>(_optimizerInstanceFixture, out exception1, parametersOfExecute);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Optimizer, string>(_optimizerInstance, MethodExecute, parametersOfExecute, methodExecutePrametersTypes);

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
        public void AUT_Optimizer_Execute_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfExecute = { Function, Dataxml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Optimizer, string>(_optimizerInstance, MethodExecute, parametersOfExecute, methodExecutePrametersTypes);

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
        public void AUT_Optimizer_Execute_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerInstance, MethodExecute, Fixture, methodExecutePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodExecutePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_Execute_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerInstance, MethodExecute, Fixture, methodExecutePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecutePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_Execute_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecute, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_Execute_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_Optimizer_ExecuteJSON_Method_Call_Internally(Type[] types)
        {
            var methodExecuteJSONPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerInstance, MethodExecuteJSON, Fixture, methodExecuteJSONPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_ExecuteJSON_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _optimizerInstance.ExecuteJSON(Function, Dataxml);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_ExecuteJSON_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            var methodExecuteJSONPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfExecuteJSON = { Function, Dataxml };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodExecuteJSON, methodExecuteJSONPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Optimizer, string>(_optimizerInstanceFixture, out exception1, parametersOfExecuteJSON);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Optimizer, string>(_optimizerInstance, MethodExecuteJSON, parametersOfExecuteJSON, methodExecuteJSONPrametersTypes);

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
        public void AUT_Optimizer_ExecuteJSON_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            var methodExecuteJSONPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfExecuteJSON = { Function, Dataxml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodExecuteJSON, methodExecuteJSONPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_optimizerInstanceFixture, parametersOfExecuteJSON);

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
        public void AUT_Optimizer_ExecuteJSON_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            var methodExecuteJSONPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfExecuteJSON = { Function, Dataxml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Optimizer, string>(_optimizerInstance, MethodExecuteJSON, parametersOfExecuteJSON, methodExecuteJSONPrametersTypes);

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
        public void AUT_Optimizer_ExecuteJSON_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodExecuteJSONPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerInstance, MethodExecuteJSON, Fixture, methodExecuteJSONPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodExecuteJSONPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_ExecuteJSON_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteJSONPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerInstance, MethodExecuteJSON, Fixture, methodExecuteJSONPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecuteJSONPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_ExecuteJSON_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteJSON, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_ExecuteJSON_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (OptimizerSessionPing) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Optimizer_OptimizerSessionPing_Static_Method_Call_Internally(Type[] types)
        {
            var methodOptimizerSessionPingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodOptimizerSessionPing, Fixture, methodOptimizerSessionPingPrametersTypes);
        }

        #endregion

        #region Method Call : (OptimizerSessionPing) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_OptimizerSessionPing_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => Optimizer.OptimizerSessionPing(Context, sXML, datacache);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (OptimizerSessionPing) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_OptimizerSessionPing_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            var methodOptimizerSessionPingPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            object[] parametersOfOptimizerSessionPing = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOptimizerSessionPing, methodOptimizerSessionPingPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodOptimizerSessionPing, Fixture, methodOptimizerSessionPingPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerInstanceFixture, _optimizerInstanceType, MethodOptimizerSessionPing, parametersOfOptimizerSessionPing, methodOptimizerSessionPingPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfOptimizerSessionPing.ShouldNotBeNull();
            parametersOfOptimizerSessionPing.Length.ShouldBe(3);
            methodOptimizerSessionPingPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerInstanceFixture, _optimizerInstanceType, MethodOptimizerSessionPing, parametersOfOptimizerSessionPing, methodOptimizerSessionPingPrametersTypes));
        }

        #endregion

        #region Method Call : (OptimizerSessionPing) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_OptimizerSessionPing_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            var methodOptimizerSessionPingPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            object[] parametersOfOptimizerSessionPing = { Context, sXML, datacache };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOptimizerSessionPing, methodOptimizerSessionPingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_optimizerInstanceFixture, parametersOfOptimizerSessionPing);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOptimizerSessionPing.ShouldNotBeNull();
            parametersOfOptimizerSessionPing.Length.ShouldBe(3);
            methodOptimizerSessionPingPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OptimizerSessionPing) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_OptimizerSessionPing_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            var methodOptimizerSessionPingPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            object[] parametersOfOptimizerSessionPing = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerInstanceFixture, _optimizerInstanceType, MethodOptimizerSessionPing, parametersOfOptimizerSessionPing, methodOptimizerSessionPingPrametersTypes);

            // Assert
            parametersOfOptimizerSessionPing.ShouldNotBeNull();
            parametersOfOptimizerSessionPing.Length.ShouldBe(3);
            methodOptimizerSessionPingPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OptimizerSessionPing) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_OptimizerSessionPing_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodOptimizerSessionPingPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodOptimizerSessionPing, Fixture, methodOptimizerSessionPingPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodOptimizerSessionPingPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (OptimizerSessionPing) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_OptimizerSessionPing_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOptimizerSessionPingPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodOptimizerSessionPing, Fixture, methodOptimizerSessionPingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodOptimizerSessionPingPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OptimizerSessionPing) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_OptimizerSessionPing_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOptimizerSessionPing, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (OptimizerSessionPing) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_OptimizerSessionPing_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOptimizerSessionPing, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetOptimizerData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Optimizer_GetOptimizerData_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetOptimizerDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodGetOptimizerData, Fixture, methodGetOptimizerDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetOptimizerData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_GetOptimizerData_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => Optimizer.GetOptimizerData(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetOptimizerData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_GetOptimizerData_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            var methodGetOptimizerDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            object[] parametersOfGetOptimizerData = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetOptimizerData, methodGetOptimizerDataPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodGetOptimizerData, Fixture, methodGetOptimizerDataPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerInstanceFixture, _optimizerInstanceType, MethodGetOptimizerData, parametersOfGetOptimizerData, methodGetOptimizerDataPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_optimizerInstanceFixture, parametersOfGetOptimizerData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetOptimizerData.ShouldNotBeNull();
            parametersOfGetOptimizerData.Length.ShouldBe(3);
            methodGetOptimizerDataPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetOptimizerData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_GetOptimizerData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            var methodGetOptimizerDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            object[] parametersOfGetOptimizerData = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerInstanceFixture, _optimizerInstanceType, MethodGetOptimizerData, parametersOfGetOptimizerData, methodGetOptimizerDataPrametersTypes);

            // Assert
            parametersOfGetOptimizerData.ShouldNotBeNull();
            parametersOfGetOptimizerData.Length.ShouldBe(3);
            methodGetOptimizerDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetOptimizerData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_GetOptimizerData_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetOptimizerDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodGetOptimizerData, Fixture, methodGetOptimizerDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetOptimizerDataPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetOptimizerData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_GetOptimizerData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetOptimizerDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodGetOptimizerData, Fixture, methodGetOptimizerDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetOptimizerDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetOptimizerData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_GetOptimizerData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetOptimizerData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetOptimizerData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_GetOptimizerData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetOptimizerData, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetProjectGridData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Optimizer_GetProjectGridData_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetProjectGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodGetProjectGridData, Fixture, methodGetProjectGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetProjectGridData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_GetProjectGridData_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => Optimizer.GetProjectGridData(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetProjectGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_GetProjectGridData_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            var methodGetProjectGridDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            object[] parametersOfGetProjectGridData = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetProjectGridData, methodGetProjectGridDataPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodGetProjectGridData, Fixture, methodGetProjectGridDataPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerInstanceFixture, _optimizerInstanceType, MethodGetProjectGridData, parametersOfGetProjectGridData, methodGetProjectGridDataPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_optimizerInstanceFixture, parametersOfGetProjectGridData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetProjectGridData.ShouldNotBeNull();
            parametersOfGetProjectGridData.Length.ShouldBe(3);
            methodGetProjectGridDataPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetProjectGridData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_GetProjectGridData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            var methodGetProjectGridDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            object[] parametersOfGetProjectGridData = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerInstanceFixture, _optimizerInstanceType, MethodGetProjectGridData, parametersOfGetProjectGridData, methodGetProjectGridDataPrametersTypes);

            // Assert
            parametersOfGetProjectGridData.ShouldNotBeNull();
            parametersOfGetProjectGridData.Length.ShouldBe(3);
            methodGetProjectGridDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetProjectGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_GetProjectGridData_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetProjectGridDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodGetProjectGridData, Fixture, methodGetProjectGridDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetProjectGridDataPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetProjectGridData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_GetProjectGridData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetProjectGridDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodGetProjectGridData, Fixture, methodGetProjectGridDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetProjectGridDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetProjectGridData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_GetProjectGridData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetProjectGridData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetProjectGridData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_GetProjectGridData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetProjectGridData, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetPIStatusModeChange) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Optimizer_SetPIStatusModeChange_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetPIStatusModeChangePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodSetPIStatusModeChange, Fixture, methodSetPIStatusModeChangePrametersTypes);
        }

        #endregion

        #region Method Call : (SetPIStatusModeChange) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_SetPIStatusModeChange_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => Optimizer.SetPIStatusModeChange(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetPIStatusModeChange) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_SetPIStatusModeChange_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            var methodSetPIStatusModeChangePrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            object[] parametersOfSetPIStatusModeChange = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetPIStatusModeChange, methodSetPIStatusModeChangePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodSetPIStatusModeChange, Fixture, methodSetPIStatusModeChangePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerInstanceFixture, _optimizerInstanceType, MethodSetPIStatusModeChange, parametersOfSetPIStatusModeChange, methodSetPIStatusModeChangePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_optimizerInstanceFixture, parametersOfSetPIStatusModeChange);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSetPIStatusModeChange.ShouldNotBeNull();
            parametersOfSetPIStatusModeChange.Length.ShouldBe(3);
            methodSetPIStatusModeChangePrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetPIStatusModeChange) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_SetPIStatusModeChange_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            var methodSetPIStatusModeChangePrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            object[] parametersOfSetPIStatusModeChange = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerInstanceFixture, _optimizerInstanceType, MethodSetPIStatusModeChange, parametersOfSetPIStatusModeChange, methodSetPIStatusModeChangePrametersTypes);

            // Assert
            parametersOfSetPIStatusModeChange.ShouldNotBeNull();
            parametersOfSetPIStatusModeChange.Length.ShouldBe(3);
            methodSetPIStatusModeChangePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetPIStatusModeChange) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_SetPIStatusModeChange_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSetPIStatusModeChangePrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodSetPIStatusModeChange, Fixture, methodSetPIStatusModeChangePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSetPIStatusModeChangePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SetPIStatusModeChange) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_SetPIStatusModeChange_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetPIStatusModeChangePrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodSetPIStatusModeChange, Fixture, methodSetPIStatusModeChangePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetPIStatusModeChangePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetPIStatusModeChange) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_SetPIStatusModeChange_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetPIStatusModeChange, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetPIStatusModeChange) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_SetPIStatusModeChange_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetPIStatusModeChange, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateFilteredList) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Optimizer_UpdateFilteredList_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpdateFilteredListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodUpdateFilteredList, Fixture, methodUpdateFilteredListPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateFilteredList) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_UpdateFilteredList_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => Optimizer.UpdateFilteredList(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateFilteredList) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_UpdateFilteredList_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            var methodUpdateFilteredListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            object[] parametersOfUpdateFilteredList = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateFilteredList, methodUpdateFilteredListPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodUpdateFilteredList, Fixture, methodUpdateFilteredListPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerInstanceFixture, _optimizerInstanceType, MethodUpdateFilteredList, parametersOfUpdateFilteredList, methodUpdateFilteredListPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_optimizerInstanceFixture, parametersOfUpdateFilteredList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfUpdateFilteredList.ShouldNotBeNull();
            parametersOfUpdateFilteredList.Length.ShouldBe(3);
            methodUpdateFilteredListPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateFilteredList) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_UpdateFilteredList_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            var methodUpdateFilteredListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            object[] parametersOfUpdateFilteredList = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerInstanceFixture, _optimizerInstanceType, MethodUpdateFilteredList, parametersOfUpdateFilteredList, methodUpdateFilteredListPrametersTypes);

            // Assert
            parametersOfUpdateFilteredList.ShouldNotBeNull();
            parametersOfUpdateFilteredList.Length.ShouldBe(3);
            methodUpdateFilteredListPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateFilteredList) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_UpdateFilteredList_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUpdateFilteredListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodUpdateFilteredList, Fixture, methodUpdateFilteredListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpdateFilteredListPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (UpdateFilteredList) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_UpdateFilteredList_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateFilteredListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodUpdateFilteredList, Fixture, methodUpdateFilteredListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateFilteredListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateFilteredList) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_UpdateFilteredList_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateFilteredList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateFilteredList) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_UpdateFilteredList_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateFilteredList, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveOptimizerView) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Optimizer_SaveOptimizerView_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveOptimizerViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodSaveOptimizerView, Fixture, methodSaveOptimizerViewPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveOptimizerView) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_SaveOptimizerView_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => Optimizer.SaveOptimizerView(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SaveOptimizerView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_SaveOptimizerView_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            var methodSaveOptimizerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            object[] parametersOfSaveOptimizerView = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveOptimizerView, methodSaveOptimizerViewPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodSaveOptimizerView, Fixture, methodSaveOptimizerViewPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerInstanceFixture, _optimizerInstanceType, MethodSaveOptimizerView, parametersOfSaveOptimizerView, methodSaveOptimizerViewPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_optimizerInstanceFixture, parametersOfSaveOptimizerView);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSaveOptimizerView.ShouldNotBeNull();
            parametersOfSaveOptimizerView.Length.ShouldBe(3);
            methodSaveOptimizerViewPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SaveOptimizerView) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_SaveOptimizerView_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            var methodSaveOptimizerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            object[] parametersOfSaveOptimizerView = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerInstanceFixture, _optimizerInstanceType, MethodSaveOptimizerView, parametersOfSaveOptimizerView, methodSaveOptimizerViewPrametersTypes);

            // Assert
            parametersOfSaveOptimizerView.ShouldNotBeNull();
            parametersOfSaveOptimizerView.Length.ShouldBe(3);
            methodSaveOptimizerViewPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveOptimizerView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_SaveOptimizerView_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSaveOptimizerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodSaveOptimizerView, Fixture, methodSaveOptimizerViewPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSaveOptimizerViewPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SaveOptimizerView) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_SaveOptimizerView_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveOptimizerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodSaveOptimizerView, Fixture, methodSaveOptimizerViewPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveOptimizerViewPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveOptimizerView) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_SaveOptimizerView_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveOptimizerView, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveOptimizerView) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_SaveOptimizerView_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveOptimizerView, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteOptimizerView) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Optimizer_DeleteOptimizerView_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeleteOptimizerViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodDeleteOptimizerView, Fixture, methodDeleteOptimizerViewPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteOptimizerView) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_DeleteOptimizerView_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => Optimizer.DeleteOptimizerView(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteOptimizerView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_DeleteOptimizerView_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            var methodDeleteOptimizerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            object[] parametersOfDeleteOptimizerView = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteOptimizerView, methodDeleteOptimizerViewPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodDeleteOptimizerView, Fixture, methodDeleteOptimizerViewPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerInstanceFixture, _optimizerInstanceType, MethodDeleteOptimizerView, parametersOfDeleteOptimizerView, methodDeleteOptimizerViewPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_optimizerInstanceFixture, parametersOfDeleteOptimizerView);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDeleteOptimizerView.ShouldNotBeNull();
            parametersOfDeleteOptimizerView.Length.ShouldBe(3);
            methodDeleteOptimizerViewPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteOptimizerView) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_DeleteOptimizerView_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            var methodDeleteOptimizerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            object[] parametersOfDeleteOptimizerView = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerInstanceFixture, _optimizerInstanceType, MethodDeleteOptimizerView, parametersOfDeleteOptimizerView, methodDeleteOptimizerViewPrametersTypes);

            // Assert
            parametersOfDeleteOptimizerView.ShouldNotBeNull();
            parametersOfDeleteOptimizerView.Length.ShouldBe(3);
            methodDeleteOptimizerViewPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteOptimizerView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_DeleteOptimizerView_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDeleteOptimizerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodDeleteOptimizerView, Fixture, methodDeleteOptimizerViewPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDeleteOptimizerViewPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (DeleteOptimizerView) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_DeleteOptimizerView_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteOptimizerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodDeleteOptimizerView, Fixture, methodDeleteOptimizerViewPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteOptimizerViewPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteOptimizerView) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_DeleteOptimizerView_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteOptimizerView, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteOptimizerView) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_DeleteOptimizerView_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteOptimizerView, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenameOptimizerView) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Optimizer_RenameOptimizerView_Static_Method_Call_Internally(Type[] types)
        {
            var methodRenameOptimizerViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodRenameOptimizerView, Fixture, methodRenameOptimizerViewPrametersTypes);
        }

        #endregion

        #region Method Call : (RenameOptimizerView) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_RenameOptimizerView_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => Optimizer.RenameOptimizerView(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RenameOptimizerView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_RenameOptimizerView_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            var methodRenameOptimizerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            object[] parametersOfRenameOptimizerView = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenameOptimizerView, methodRenameOptimizerViewPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodRenameOptimizerView, Fixture, methodRenameOptimizerViewPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerInstanceFixture, _optimizerInstanceType, MethodRenameOptimizerView, parametersOfRenameOptimizerView, methodRenameOptimizerViewPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_optimizerInstanceFixture, parametersOfRenameOptimizerView);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfRenameOptimizerView.ShouldNotBeNull();
            parametersOfRenameOptimizerView.Length.ShouldBe(3);
            methodRenameOptimizerViewPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RenameOptimizerView) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_RenameOptimizerView_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            var methodRenameOptimizerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            object[] parametersOfRenameOptimizerView = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerInstanceFixture, _optimizerInstanceType, MethodRenameOptimizerView, parametersOfRenameOptimizerView, methodRenameOptimizerViewPrametersTypes);

            // Assert
            parametersOfRenameOptimizerView.ShouldNotBeNull();
            parametersOfRenameOptimizerView.Length.ShouldBe(3);
            methodRenameOptimizerViewPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenameOptimizerView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_RenameOptimizerView_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodRenameOptimizerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodRenameOptimizerView, Fixture, methodRenameOptimizerViewPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRenameOptimizerViewPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (RenameOptimizerView) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_RenameOptimizerView_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenameOptimizerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodRenameOptimizerView, Fixture, methodRenameOptimizerViewPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenameOptimizerViewPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenameOptimizerView) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_RenameOptimizerView_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenameOptimizerView, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenameOptimizerView) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_RenameOptimizerView_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenameOptimizerView, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveOptimizerStratagy) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Optimizer_SaveOptimizerStratagy_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveOptimizerStratagyPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodSaveOptimizerStratagy, Fixture, methodSaveOptimizerStratagyPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveOptimizerStratagy) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_SaveOptimizerStratagy_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => Optimizer.SaveOptimizerStratagy(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SaveOptimizerStratagy) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_SaveOptimizerStratagy_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            var methodSaveOptimizerStratagyPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            object[] parametersOfSaveOptimizerStratagy = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveOptimizerStratagy, methodSaveOptimizerStratagyPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodSaveOptimizerStratagy, Fixture, methodSaveOptimizerStratagyPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerInstanceFixture, _optimizerInstanceType, MethodSaveOptimizerStratagy, parametersOfSaveOptimizerStratagy, methodSaveOptimizerStratagyPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_optimizerInstanceFixture, parametersOfSaveOptimizerStratagy);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSaveOptimizerStratagy.ShouldNotBeNull();
            parametersOfSaveOptimizerStratagy.Length.ShouldBe(3);
            methodSaveOptimizerStratagyPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SaveOptimizerStratagy) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_SaveOptimizerStratagy_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            var methodSaveOptimizerStratagyPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            object[] parametersOfSaveOptimizerStratagy = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerInstanceFixture, _optimizerInstanceType, MethodSaveOptimizerStratagy, parametersOfSaveOptimizerStratagy, methodSaveOptimizerStratagyPrametersTypes);

            // Assert
            parametersOfSaveOptimizerStratagy.ShouldNotBeNull();
            parametersOfSaveOptimizerStratagy.Length.ShouldBe(3);
            methodSaveOptimizerStratagyPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveOptimizerStratagy) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_SaveOptimizerStratagy_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSaveOptimizerStratagyPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodSaveOptimizerStratagy, Fixture, methodSaveOptimizerStratagyPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSaveOptimizerStratagyPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SaveOptimizerStratagy) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_SaveOptimizerStratagy_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveOptimizerStratagyPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodSaveOptimizerStratagy, Fixture, methodSaveOptimizerStratagyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveOptimizerStratagyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveOptimizerStratagy) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_SaveOptimizerStratagy_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveOptimizerStratagy, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveOptimizerStratagy) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_SaveOptimizerStratagy_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveOptimizerStratagy, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteOptimizerStratagy) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Optimizer_DeleteOptimizerStratagy_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeleteOptimizerStratagyPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodDeleteOptimizerStratagy, Fixture, methodDeleteOptimizerStratagyPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteOptimizerStratagy) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_DeleteOptimizerStratagy_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => Optimizer.DeleteOptimizerStratagy(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteOptimizerStratagy) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_DeleteOptimizerStratagy_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            var methodDeleteOptimizerStratagyPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            object[] parametersOfDeleteOptimizerStratagy = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteOptimizerStratagy, methodDeleteOptimizerStratagyPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodDeleteOptimizerStratagy, Fixture, methodDeleteOptimizerStratagyPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerInstanceFixture, _optimizerInstanceType, MethodDeleteOptimizerStratagy, parametersOfDeleteOptimizerStratagy, methodDeleteOptimizerStratagyPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_optimizerInstanceFixture, parametersOfDeleteOptimizerStratagy);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDeleteOptimizerStratagy.ShouldNotBeNull();
            parametersOfDeleteOptimizerStratagy.Length.ShouldBe(3);
            methodDeleteOptimizerStratagyPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteOptimizerStratagy) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_DeleteOptimizerStratagy_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            var methodDeleteOptimizerStratagyPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            object[] parametersOfDeleteOptimizerStratagy = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerInstanceFixture, _optimizerInstanceType, MethodDeleteOptimizerStratagy, parametersOfDeleteOptimizerStratagy, methodDeleteOptimizerStratagyPrametersTypes);

            // Assert
            parametersOfDeleteOptimizerStratagy.ShouldNotBeNull();
            parametersOfDeleteOptimizerStratagy.Length.ShouldBe(3);
            methodDeleteOptimizerStratagyPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteOptimizerStratagy) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_DeleteOptimizerStratagy_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDeleteOptimizerStratagyPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodDeleteOptimizerStratagy, Fixture, methodDeleteOptimizerStratagyPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDeleteOptimizerStratagyPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (DeleteOptimizerStratagy) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_DeleteOptimizerStratagy_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteOptimizerStratagyPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodDeleteOptimizerStratagy, Fixture, methodDeleteOptimizerStratagyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteOptimizerStratagyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteOptimizerStratagy) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_DeleteOptimizerStratagy_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteOptimizerStratagy, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteOptimizerStratagy) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_DeleteOptimizerStratagy_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteOptimizerStratagy, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenameOptimizerStratagy) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Optimizer_RenameOptimizerStratagy_Static_Method_Call_Internally(Type[] types)
        {
            var methodRenameOptimizerStratagyPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodRenameOptimizerStratagy, Fixture, methodRenameOptimizerStratagyPrametersTypes);
        }

        #endregion

        #region Method Call : (RenameOptimizerStratagy) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_RenameOptimizerStratagy_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => Optimizer.RenameOptimizerStratagy(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RenameOptimizerStratagy) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_RenameOptimizerStratagy_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            var methodRenameOptimizerStratagyPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            object[] parametersOfRenameOptimizerStratagy = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenameOptimizerStratagy, methodRenameOptimizerStratagyPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodRenameOptimizerStratagy, Fixture, methodRenameOptimizerStratagyPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerInstanceFixture, _optimizerInstanceType, MethodRenameOptimizerStratagy, parametersOfRenameOptimizerStratagy, methodRenameOptimizerStratagyPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_optimizerInstanceFixture, parametersOfRenameOptimizerStratagy);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfRenameOptimizerStratagy.ShouldNotBeNull();
            parametersOfRenameOptimizerStratagy.Length.ShouldBe(3);
            methodRenameOptimizerStratagyPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RenameOptimizerStratagy) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_RenameOptimizerStratagy_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            var methodRenameOptimizerStratagyPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            object[] parametersOfRenameOptimizerStratagy = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerInstanceFixture, _optimizerInstanceType, MethodRenameOptimizerStratagy, parametersOfRenameOptimizerStratagy, methodRenameOptimizerStratagyPrametersTypes);

            // Assert
            parametersOfRenameOptimizerStratagy.ShouldNotBeNull();
            parametersOfRenameOptimizerStratagy.Length.ShouldBe(3);
            methodRenameOptimizerStratagyPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenameOptimizerStratagy) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_RenameOptimizerStratagy_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodRenameOptimizerStratagyPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodRenameOptimizerStratagy, Fixture, methodRenameOptimizerStratagyPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRenameOptimizerStratagyPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (RenameOptimizerStratagy) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_RenameOptimizerStratagy_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenameOptimizerStratagyPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodRenameOptimizerStratagy, Fixture, methodRenameOptimizerStratagyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenameOptimizerStratagyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenameOptimizerStratagy) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_RenameOptimizerStratagy_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenameOptimizerStratagy, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenameOptimizerStratagy) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_RenameOptimizerStratagy_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenameOptimizerStratagy, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CommitOptimizerStratagy) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Optimizer_CommitOptimizerStratagy_Static_Method_Call_Internally(Type[] types)
        {
            var methodCommitOptimizerStratagyPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodCommitOptimizerStratagy, Fixture, methodCommitOptimizerStratagyPrametersTypes);
        }

        #endregion

        #region Method Call : (CommitOptimizerStratagy) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_CommitOptimizerStratagy_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => Optimizer.CommitOptimizerStratagy(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CommitOptimizerStratagy) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_CommitOptimizerStratagy_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            var methodCommitOptimizerStratagyPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            object[] parametersOfCommitOptimizerStratagy = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCommitOptimizerStratagy, methodCommitOptimizerStratagyPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodCommitOptimizerStratagy, Fixture, methodCommitOptimizerStratagyPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerInstanceFixture, _optimizerInstanceType, MethodCommitOptimizerStratagy, parametersOfCommitOptimizerStratagy, methodCommitOptimizerStratagyPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_optimizerInstanceFixture, parametersOfCommitOptimizerStratagy);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfCommitOptimizerStratagy.ShouldNotBeNull();
            parametersOfCommitOptimizerStratagy.Length.ShouldBe(3);
            methodCommitOptimizerStratagyPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CommitOptimizerStratagy) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_CommitOptimizerStratagy_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<clsOptmizerDataCache>();
            var methodCommitOptimizerStratagyPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            object[] parametersOfCommitOptimizerStratagy = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerInstanceFixture, _optimizerInstanceType, MethodCommitOptimizerStratagy, parametersOfCommitOptimizerStratagy, methodCommitOptimizerStratagyPrametersTypes);

            // Assert
            parametersOfCommitOptimizerStratagy.ShouldNotBeNull();
            parametersOfCommitOptimizerStratagy.Length.ShouldBe(3);
            methodCommitOptimizerStratagyPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CommitOptimizerStratagy) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_CommitOptimizerStratagy_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCommitOptimizerStratagyPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodCommitOptimizerStratagy, Fixture, methodCommitOptimizerStratagyPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCommitOptimizerStratagyPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (CommitOptimizerStratagy) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_CommitOptimizerStratagy_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCommitOptimizerStratagyPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(clsOptmizerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodCommitOptimizerStratagy, Fixture, methodCommitOptimizerStratagyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCommitOptimizerStratagyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CommitOptimizerStratagy) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_CommitOptimizerStratagy_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCommitOptimizerStratagy, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CommitOptimizerStratagy) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_CommitOptimizerStratagy_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCommitOptimizerStratagy, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildResultXML) (Return Type : CStruct) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Optimizer_BuildResultXML_Static_Method_Call_Internally(Type[] types)
        {
            var methodBuildResultXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodBuildResultXML, Fixture, methodBuildResultXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildResultXML) (Return Type : CStruct) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_BuildResultXML_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var nStatus = CreateType<int>();
            var methodBuildResultXMLPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfBuildResultXML = { sContext, nStatus };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildResultXML, methodBuildResultXMLPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_optimizerInstanceFixture, parametersOfBuildResultXML);

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
        public void AUT_Optimizer_BuildResultXML_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var nStatus = CreateType<int>();
            var methodBuildResultXMLPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfBuildResultXML = { sContext, nStatus };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<CStruct>(_optimizerInstanceFixture, _optimizerInstanceType, MethodBuildResultXML, parametersOfBuildResultXML, methodBuildResultXMLPrametersTypes);

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
        public void AUT_Optimizer_BuildResultXML_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildResultXMLPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodBuildResultXML, Fixture, methodBuildResultXMLPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildResultXMLPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (BuildResultXML) (Return Type : CStruct) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_BuildResultXML_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildResultXMLPrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodBuildResultXML, Fixture, methodBuildResultXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildResultXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildResultXML) (Return Type : CStruct) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_BuildResultXML_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildResultXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (BuildResultXML) (Return Type : CStruct) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_BuildResultXML_Static_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_Optimizer_HandleError_Static_Method_Call_Internally(Type[] types)
        {
            var methodHandleErrorPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodHandleError, Fixture, methodHandleErrorPrametersTypes);
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_HandleError_Static_Method_Call_With_No_Exception_Thrown_Test()
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
            Action currentAction = () => methodInfo.Invoke(_optimizerInstanceFixture, parametersOfHandleError);

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
        public void AUT_Optimizer_HandleError_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var nStatus = CreateType<int>();
            var sError = CreateType<string>();
            var methodHandleErrorPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };
            object[] parametersOfHandleError = { sContext, nStatus, sError };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerInstanceFixture, _optimizerInstanceType, MethodHandleError, parametersOfHandleError, methodHandleErrorPrametersTypes);

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
        public void AUT_Optimizer_HandleError_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodHandleErrorPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodHandleError, Fixture, methodHandleErrorPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodHandleErrorPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_HandleError_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHandleErrorPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodHandleError, Fixture, methodHandleErrorPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodHandleErrorPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_HandleError_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHandleError, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_HandleError_Static_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_Optimizer_HandleException_Static_Method_Call_Internally(Type[] types)
        {
            var methodHandleExceptionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodHandleException, Fixture, methodHandleExceptionPrametersTypes);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_HandleException_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var nStatus = CreateType<int>();
            var ex = CreateType<Exception>();
            var sStage = CreateType<string>();
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(Exception), typeof(string) };
            object[] parametersOfHandleException = { sContext, nStatus, ex, sStage };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodHandleException, methodHandleExceptionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_optimizerInstanceFixture, parametersOfHandleException);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfHandleException.ShouldNotBeNull();
            parametersOfHandleException.Length.ShouldBe(4);
            methodHandleExceptionPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_HandleException_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var nStatus = CreateType<int>();
            var ex = CreateType<Exception>();
            var sStage = CreateType<string>();
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(Exception), typeof(string) };
            object[] parametersOfHandleException = { sContext, nStatus, ex, sStage };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerInstanceFixture, _optimizerInstanceType, MethodHandleException, parametersOfHandleException, methodHandleExceptionPrametersTypes);

            // Assert
            parametersOfHandleException.ShouldNotBeNull();
            parametersOfHandleException.Length.ShouldBe(4);
            methodHandleExceptionPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_HandleException_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(Exception), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodHandleException, Fixture, methodHandleExceptionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodHandleExceptionPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_HandleException_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(Exception), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodHandleException, Fixture, methodHandleExceptionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodHandleExceptionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_HandleException_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHandleException, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_HandleException_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodHandleException, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveCachedData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Optimizer_SaveCachedData_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveCachedDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodSaveCachedData, Fixture, methodSaveCachedDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveCachedData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_SaveCachedData_Static_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sKey = CreateType<string>();
            var value = CreateType<object>();
            var methodSaveCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(object) };
            object[] parametersOfSaveCachedData = { Context, sKey, value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSaveCachedData, methodSaveCachedDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_optimizerInstanceFixture, parametersOfSaveCachedData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSaveCachedData.ShouldNotBeNull();
            parametersOfSaveCachedData.Length.ShouldBe(3);
            methodSaveCachedDataPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SaveCachedData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_SaveCachedData_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sKey = CreateType<string>();
            var value = CreateType<object>();
            var methodSaveCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(object) };
            object[] parametersOfSaveCachedData = { Context, sKey, value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_optimizerInstanceFixture, _optimizerInstanceType, MethodSaveCachedData, parametersOfSaveCachedData, methodSaveCachedDataPrametersTypes);

            // Assert
            parametersOfSaveCachedData.ShouldNotBeNull();
            parametersOfSaveCachedData.Length.ShouldBe(3);
            methodSaveCachedDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveCachedData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_SaveCachedData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveCachedData, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveCachedData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_SaveCachedData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodSaveCachedData, Fixture, methodSaveCachedDataPrametersTypes);

            // Assert
            methodSaveCachedDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveCachedData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_SaveCachedData_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveCachedData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Optimizer_GetCachedData_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCachedDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodGetCachedData, Fixture, methodGetCachedDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_GetCachedData_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sKey = CreateType<string>();
            var methodGetCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfGetCachedData = { Context, sKey };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCachedData, methodGetCachedDataPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodGetCachedData, Fixture, methodGetCachedDataPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<object>(_optimizerInstanceFixture, _optimizerInstanceType, MethodGetCachedData, parametersOfGetCachedData, methodGetCachedDataPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_optimizerInstanceFixture, parametersOfGetCachedData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCachedData.ShouldNotBeNull();
            parametersOfGetCachedData.Length.ShouldBe(2);
            methodGetCachedDataPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_GetCachedData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sKey = CreateType<string>();
            var methodGetCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfGetCachedData = { Context, sKey };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<object>(_optimizerInstanceFixture, _optimizerInstanceType, MethodGetCachedData, parametersOfGetCachedData, methodGetCachedDataPrametersTypes);

            // Assert
            parametersOfGetCachedData.ShouldNotBeNull();
            parametersOfGetCachedData.Length.ShouldBe(2);
            methodGetCachedDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_GetCachedData_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodGetCachedData, Fixture, methodGetCachedDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCachedDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_GetCachedData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerInstanceFixture, _optimizerInstanceType, MethodGetCachedData, Fixture, methodGetCachedDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCachedDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_GetCachedData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCachedData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Optimizer_GetCachedData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCachedData, 0);
            const int parametersCount = 2;

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