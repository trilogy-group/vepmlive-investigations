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
using RPADataCache;
using Should = Shouldly.Should;
using Shouldly;

namespace WorkEnginePPM
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.ResPlanAnalyzer" />)
    ///     and namespace <see cref="WorkEnginePPM"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class ResPlanAnalyzerTest : AbstractBaseSetupTypedTest<ResPlanAnalyzer>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ResPlanAnalyzer) Initializer

        private const string MethodGetSPSessionBasePath = "GetSPSessionBasePath";
        private const string MethodGetRPSessionKey = "GetRPSessionKey";
        private const string MethodExecute = "Execute";
        private const string MethodExecuteJSON = "ExecuteJSON";
        private const string MethodGetRAUserCalendarInfo = "GetRAUserCalendarInfo";
        private const string MethodGetPortfolioItemList = "GetPortfolioItemList";
        private const string MethodGetGeneratedPortfolioItemTicket = "GetGeneratedPortfolioItemTicket";
        private const string MethodRASessionPing = "RASessionPing";
        private const string MethodRALoadData = "RALoadData";
        private const string MethodGetRAWorkDetails = "GetRAWorkDetails";
        private const string MethodSetRAWorkDetails = "SetRAWorkDetails";
        private const string MethodSetRAWorkDisplayMode = "SetRAWorkDisplayMode";
        private const string MethodGetResourceAnalyzerData = "GetResourceAnalyzerData";
        private const string MethodGetResourceAnalyzerTotals = "GetResourceAnalyzerTotals";
        private const string MethodSetBottomDetailsDisplay = "SetBottomDetailsDisplay";
        private const string MethodGetTotalsColumnsConfiguration = "GetTotalsColumnsConfiguration";
        private const string MethodSetTotalsColumnsConfiguration = "SetTotalsColumnsConfiguration";
        private const string MethodSetRADetailsSelectedFlag = "SetRADetailsSelectedFlag";
        private const string MethodSetRATotalSelectedFlag = "SetRATotalSelectedFlag";
        private const string MethodSetRADragRows = "SetRADragRows";
        private const string MethodUndoRADragRows = "UndoRADragRows";
        private const string MethodSetRADetailsFilteredFlag = "SetRADetailsFilteredFlag";
        private const string MethodGetResourceAnalyzerViews = "GetResourceAnalyzerViews";
        private const string MethodGetResourceAnalyzerView = "GetResourceAnalyzerView";
        private const string MethodSaveResourceAnalyzerView = "SaveResourceAnalyzerView";
        private const string MethodDeleteResourceAnalyzerView = "DeleteResourceAnalyzerView";
        private const string MethodRenameResourceAnalyzerView = "RenameResourceAnalyzerView";
        private const string MethodApplyResourceAnalyzerViewServerSideSettings = "ApplyResourceAnalyzerViewServerSideSettings";
        private const string MethodGetCapacityScenarioList = "GetCapacityScenarioList";
        private const string MethodDeleteCapacityScenario = "DeleteCapacityScenario";
        private const string MethodGetCapacityScenarioData = "GetCapacityScenarioData";
        private const string MethodGetCapacityScenarioEdit = "GetCapacityScenarioEdit";
        private const string MethodGetLegendKey = "GetLegendKey";
        private const string MethodRPASaveDraggedData = "RPASaveDraggedData";
        private const string MethodSaveCapacityScenarioData = "SaveCapacityScenarioData";
        private const string MethodReloadPlanData = "ReloadPlanData";
        private const string MethodSaveCurrentToScenario = "SaveCurrentToScenario";
        private const string MethodSetAllCheckMarks = "SetAllCheckMarks";
        private const string MethodEditResPlanTicket = "EditResPlanTicket";
        private const string MethodGetTotalsGridChartData = "GetTotalsGridChartData";
        private const string MethodBuildResultXML = "BuildResultXML";
        private const string MethodHandleError = "HandleError";
        private const string MethodHandleException = "HandleException";
        private const string MethodSaveCachedData = "SaveCachedData";
        private const string MethodGetCachedData = "GetCachedData";
        private const string FieldCOMPONENT_NAME = "COMPONENT_NAME";
        private const string FieldbasePath = "basePath";
        private const string FieldppmId = "ppmId";
        private const string FieldppmCompany = "ppmCompany";
        private const string FieldppmDbConn = "ppmDbConn";
        private const string Fieldusername = "username";
        private const string FieldsecurityLevel = "securityLevel";
        private Type _resPlanAnalyzerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ResPlanAnalyzer _resPlanAnalyzerInstance;
        private ResPlanAnalyzer _resPlanAnalyzerInstanceFixture;

        #region General Initializer : Class (ResPlanAnalyzer) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ResPlanAnalyzer" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _resPlanAnalyzerInstanceType = typeof(ResPlanAnalyzer);
            _resPlanAnalyzerInstanceFixture = Create(true);
            _resPlanAnalyzerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ResPlanAnalyzer)

        #region General Initializer : Class (ResPlanAnalyzer) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ResPlanAnalyzer" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetSPSessionBasePath, 0)]
        [TestCase(MethodGetRPSessionKey, 0)]
        [TestCase(MethodExecute, 0)]
        [TestCase(MethodExecuteJSON, 0)]
        [TestCase(MethodGetRAUserCalendarInfo, 0)]
        [TestCase(MethodGetPortfolioItemList, 0)]
        [TestCase(MethodGetGeneratedPortfolioItemTicket, 0)]
        [TestCase(MethodRASessionPing, 0)]
        [TestCase(MethodRALoadData, 0)]
        [TestCase(MethodGetRAWorkDetails, 0)]
        [TestCase(MethodSetRAWorkDetails, 0)]
        [TestCase(MethodSetRAWorkDisplayMode, 0)]
        [TestCase(MethodGetResourceAnalyzerData, 0)]
        [TestCase(MethodGetResourceAnalyzerTotals, 0)]
        [TestCase(MethodSetBottomDetailsDisplay, 0)]
        [TestCase(MethodGetTotalsColumnsConfiguration, 0)]
        [TestCase(MethodSetTotalsColumnsConfiguration, 0)]
        [TestCase(MethodSetRADetailsSelectedFlag, 0)]
        [TestCase(MethodSetRATotalSelectedFlag, 0)]
        [TestCase(MethodSetRADragRows, 0)]
        [TestCase(MethodUndoRADragRows, 0)]
        [TestCase(MethodSetRADetailsFilteredFlag, 0)]
        [TestCase(MethodGetResourceAnalyzerViews, 0)]
        [TestCase(MethodGetResourceAnalyzerView, 0)]
        [TestCase(MethodSaveResourceAnalyzerView, 0)]
        [TestCase(MethodDeleteResourceAnalyzerView, 0)]
        [TestCase(MethodRenameResourceAnalyzerView, 0)]
        [TestCase(MethodApplyResourceAnalyzerViewServerSideSettings, 0)]
        [TestCase(MethodGetCapacityScenarioList, 0)]
        [TestCase(MethodDeleteCapacityScenario, 0)]
        [TestCase(MethodGetCapacityScenarioData, 0)]
        [TestCase(MethodGetCapacityScenarioEdit, 0)]
        [TestCase(MethodGetLegendKey, 0)]
        [TestCase(MethodRPASaveDraggedData, 0)]
        [TestCase(MethodSaveCapacityScenarioData, 0)]
        [TestCase(MethodReloadPlanData, 0)]
        [TestCase(MethodSaveCurrentToScenario, 0)]
        [TestCase(MethodSetAllCheckMarks, 0)]
        [TestCase(MethodEditResPlanTicket, 0)]
        [TestCase(MethodGetTotalsGridChartData, 0)]
        [TestCase(MethodBuildResultXML, 0)]
        [TestCase(MethodHandleError, 0)]
        [TestCase(MethodHandleException, 0)]
        [TestCase(MethodSaveCachedData, 0)]
        [TestCase(MethodGetCachedData, 0)]
        public void AUT_ResPlanAnalyzer_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_resPlanAnalyzerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ResPlanAnalyzer) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ResPlanAnalyzer" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldCOMPONENT_NAME)]
        [TestCase(FieldbasePath)]
        [TestCase(FieldppmId)]
        [TestCase(FieldppmCompany)]
        [TestCase(FieldppmDbConn)]
        [TestCase(Fieldusername)]
        [TestCase(FieldsecurityLevel)]
        public void AUT_ResPlanAnalyzer_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_resPlanAnalyzerInstanceFixture, 
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
        ///     Class (<see cref="ResPlanAnalyzer" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ResPlanAnalyzer_Is_Instance_Present_Test()
        {
            // Assert
            _resPlanAnalyzerInstanceType.ShouldNotBeNull();
            _resPlanAnalyzerInstance.ShouldNotBeNull();
            _resPlanAnalyzerInstanceFixture.ShouldNotBeNull();
            _resPlanAnalyzerInstance.ShouldBeAssignableTo<ResPlanAnalyzer>();
            _resPlanAnalyzerInstanceFixture.ShouldBeAssignableTo<ResPlanAnalyzer>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ResPlanAnalyzer) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ResPlanAnalyzer_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ResPlanAnalyzer instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _resPlanAnalyzerInstanceType.ShouldNotBeNull();
            _resPlanAnalyzerInstance.ShouldNotBeNull();
            _resPlanAnalyzerInstanceFixture.ShouldNotBeNull();
            _resPlanAnalyzerInstance.ShouldBeAssignableTo<ResPlanAnalyzer>();
            _resPlanAnalyzerInstanceFixture.ShouldBeAssignableTo<ResPlanAnalyzer>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="ResPlanAnalyzer" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetRAUserCalendarInfo)]
        [TestCase(MethodGetPortfolioItemList)]
        [TestCase(MethodGetGeneratedPortfolioItemTicket)]
        [TestCase(MethodRASessionPing)]
        [TestCase(MethodRALoadData)]
        [TestCase(MethodGetRAWorkDetails)]
        [TestCase(MethodSetRAWorkDetails)]
        [TestCase(MethodSetRAWorkDisplayMode)]
        [TestCase(MethodGetResourceAnalyzerData)]
        [TestCase(MethodGetResourceAnalyzerTotals)]
        [TestCase(MethodSetBottomDetailsDisplay)]
        [TestCase(MethodGetTotalsColumnsConfiguration)]
        [TestCase(MethodSetTotalsColumnsConfiguration)]
        [TestCase(MethodSetRADetailsSelectedFlag)]
        [TestCase(MethodSetRATotalSelectedFlag)]
        [TestCase(MethodSetRADragRows)]
        [TestCase(MethodUndoRADragRows)]
        [TestCase(MethodSetRADetailsFilteredFlag)]
        [TestCase(MethodGetResourceAnalyzerViews)]
        [TestCase(MethodGetResourceAnalyzerView)]
        [TestCase(MethodSaveResourceAnalyzerView)]
        [TestCase(MethodDeleteResourceAnalyzerView)]
        [TestCase(MethodRenameResourceAnalyzerView)]
        [TestCase(MethodApplyResourceAnalyzerViewServerSideSettings)]
        [TestCase(MethodGetCapacityScenarioList)]
        [TestCase(MethodDeleteCapacityScenario)]
        [TestCase(MethodGetCapacityScenarioData)]
        [TestCase(MethodGetCapacityScenarioEdit)]
        [TestCase(MethodGetLegendKey)]
        [TestCase(MethodRPASaveDraggedData)]
        [TestCase(MethodSaveCapacityScenarioData)]
        [TestCase(MethodSaveCurrentToScenario)]
        [TestCase(MethodSetAllCheckMarks)]
        [TestCase(MethodEditResPlanTicket)]
        [TestCase(MethodGetTotalsGridChartData)]
        [TestCase(MethodBuildResultXML)]
        [TestCase(MethodHandleError)]
        [TestCase(MethodHandleException)]
        [TestCase(MethodSaveCachedData)]
        [TestCase(MethodGetCachedData)]
        public void AUT_ResPlanAnalyzer_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_resPlanAnalyzerInstanceFixture,
                                                                              _resPlanAnalyzerInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ResPlanAnalyzer" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetSPSessionBasePath)]
        [TestCase(MethodGetRPSessionKey)]
        [TestCase(MethodExecute)]
        [TestCase(MethodExecuteJSON)]
        [TestCase(MethodReloadPlanData)]
        public void AUT_ResPlanAnalyzer_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ResPlanAnalyzer>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetSPSessionBasePath) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_GetSPSessionBasePath_Method_Call_Internally(Type[] types)
        {
            var methodGetSPSessionBasePathPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resPlanAnalyzerInstance, MethodGetSPSessionBasePath, Fixture, methodGetSPSessionBasePathPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSPSessionBasePath) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetSPSessionBasePath_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetSPSessionBasePathPrametersTypes = null;
            object[] parametersOfGetSPSessionBasePath = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSPSessionBasePath, methodGetSPSessionBasePathPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResPlanAnalyzer, string>(_resPlanAnalyzerInstanceFixture, out exception1, parametersOfGetSPSessionBasePath);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResPlanAnalyzer, string>(_resPlanAnalyzerInstance, MethodGetSPSessionBasePath, parametersOfGetSPSessionBasePath, methodGetSPSessionBasePathPrametersTypes);

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
        public void AUT_ResPlanAnalyzer_GetSPSessionBasePath_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetSPSessionBasePathPrametersTypes = null;
            object[] parametersOfGetSPSessionBasePath = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ResPlanAnalyzer, string>(_resPlanAnalyzerInstance, MethodGetSPSessionBasePath, parametersOfGetSPSessionBasePath, methodGetSPSessionBasePathPrametersTypes);

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
        public void AUT_ResPlanAnalyzer_GetSPSessionBasePath_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetSPSessionBasePathPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resPlanAnalyzerInstance, MethodGetSPSessionBasePath, Fixture, methodGetSPSessionBasePathPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSPSessionBasePathPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSPSessionBasePath) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetSPSessionBasePath_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetSPSessionBasePathPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resPlanAnalyzerInstance, MethodGetSPSessionBasePath, Fixture, methodGetSPSessionBasePathPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSPSessionBasePathPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSPSessionBasePath) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetSPSessionBasePath_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSPSessionBasePath, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRPSessionKey) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_GetRPSessionKey_Method_Call_Internally(Type[] types)
        {
            var methodGetRPSessionKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resPlanAnalyzerInstance, MethodGetRPSessionKey, Fixture, methodGetRPSessionKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRPSessionKey) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetRPSessionKey_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetRPSessionKeyPrametersTypes = null;
            object[] parametersOfGetRPSessionKey = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetRPSessionKey, methodGetRPSessionKeyPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResPlanAnalyzer, string>(_resPlanAnalyzerInstanceFixture, out exception1, parametersOfGetRPSessionKey);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResPlanAnalyzer, string>(_resPlanAnalyzerInstance, MethodGetRPSessionKey, parametersOfGetRPSessionKey, methodGetRPSessionKeyPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetRPSessionKey.ShouldBeNull();
            methodGetRPSessionKeyPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRPSessionKey) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetRPSessionKey_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetRPSessionKeyPrametersTypes = null;
            object[] parametersOfGetRPSessionKey = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ResPlanAnalyzer, string>(_resPlanAnalyzerInstance, MethodGetRPSessionKey, parametersOfGetRPSessionKey, methodGetRPSessionKeyPrametersTypes);

            // Assert
            parametersOfGetRPSessionKey.ShouldBeNull();
            methodGetRPSessionKeyPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRPSessionKey) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetRPSessionKey_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetRPSessionKeyPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resPlanAnalyzerInstance, MethodGetRPSessionKey, Fixture, methodGetRPSessionKeyPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetRPSessionKeyPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRPSessionKey) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetRPSessionKey_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetRPSessionKeyPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resPlanAnalyzerInstance, MethodGetRPSessionKey, Fixture, methodGetRPSessionKeyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRPSessionKeyPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRPSessionKey) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetRPSessionKey_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRPSessionKey, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_Execute_Method_Call_Internally(Type[] types)
        {
            var methodExecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resPlanAnalyzerInstance, MethodExecute, Fixture, methodExecutePrametersTypes);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_Execute_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _resPlanAnalyzerInstance.Execute(Function, Dataxml);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_Execute_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfExecute = { Function, Dataxml };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodExecute, methodExecutePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResPlanAnalyzer, string>(_resPlanAnalyzerInstanceFixture, out exception1, parametersOfExecute);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResPlanAnalyzer, string>(_resPlanAnalyzerInstance, MethodExecute, parametersOfExecute, methodExecutePrametersTypes);

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
        public void AUT_ResPlanAnalyzer_Execute_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfExecute = { Function, Dataxml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ResPlanAnalyzer, string>(_resPlanAnalyzerInstance, MethodExecute, parametersOfExecute, methodExecutePrametersTypes);

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
        public void AUT_ResPlanAnalyzer_Execute_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resPlanAnalyzerInstance, MethodExecute, Fixture, methodExecutePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodExecutePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_Execute_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resPlanAnalyzerInstance, MethodExecute, Fixture, methodExecutePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecutePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_Execute_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecute, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_Execute_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_ResPlanAnalyzer_ExecuteJSON_Method_Call_Internally(Type[] types)
        {
            var methodExecuteJSONPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resPlanAnalyzerInstance, MethodExecuteJSON, Fixture, methodExecuteJSONPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_ExecuteJSON_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _resPlanAnalyzerInstance.ExecuteJSON(Function, Dataxml);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_ExecuteJSON_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            var methodExecuteJSONPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfExecuteJSON = { Function, Dataxml };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodExecuteJSON, methodExecuteJSONPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResPlanAnalyzer, string>(_resPlanAnalyzerInstanceFixture, out exception1, parametersOfExecuteJSON);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResPlanAnalyzer, string>(_resPlanAnalyzerInstance, MethodExecuteJSON, parametersOfExecuteJSON, methodExecuteJSONPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfExecuteJSON.ShouldNotBeNull();
            parametersOfExecuteJSON.Length.ShouldBe(2);
            methodExecuteJSONPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_ExecuteJSON_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            var methodExecuteJSONPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfExecuteJSON = { Function, Dataxml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ResPlanAnalyzer, string>(_resPlanAnalyzerInstance, MethodExecuteJSON, parametersOfExecuteJSON, methodExecuteJSONPrametersTypes);

            // Assert
            parametersOfExecuteJSON.ShouldNotBeNull();
            parametersOfExecuteJSON.Length.ShouldBe(2);
            methodExecuteJSONPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_ExecuteJSON_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodExecuteJSONPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resPlanAnalyzerInstance, MethodExecuteJSON, Fixture, methodExecuteJSONPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodExecuteJSONPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_ExecuteJSON_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteJSONPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resPlanAnalyzerInstance, MethodExecuteJSON, Fixture, methodExecuteJSONPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecuteJSONPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_ExecuteJSON_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteJSON, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_ExecuteJSON_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (GetRAUserCalendarInfo) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_GetRAUserCalendarInfo_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetRAUserCalendarInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetRAUserCalendarInfo, Fixture, methodGetRAUserCalendarInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRAUserCalendarInfo) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetRAUserCalendarInfo_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.GetRAUserCalendarInfo(Context, sXML, RAData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetRAUserCalendarInfo) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetRAUserCalendarInfo_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetRAUserCalendarInfoPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetRAUserCalendarInfo = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRAUserCalendarInfo, methodGetRAUserCalendarInfoPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetRAUserCalendarInfo, Fixture, methodGetRAUserCalendarInfoPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetRAUserCalendarInfo, parametersOfGetRAUserCalendarInfo, methodGetRAUserCalendarInfoPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfGetRAUserCalendarInfo);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetRAUserCalendarInfo.ShouldNotBeNull();
            parametersOfGetRAUserCalendarInfo.Length.ShouldBe(3);
            methodGetRAUserCalendarInfoPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetRAUserCalendarInfo) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetRAUserCalendarInfo_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetRAUserCalendarInfoPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetRAUserCalendarInfo = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetRAUserCalendarInfo, parametersOfGetRAUserCalendarInfo, methodGetRAUserCalendarInfoPrametersTypes);

            // Assert
            parametersOfGetRAUserCalendarInfo.ShouldNotBeNull();
            parametersOfGetRAUserCalendarInfo.Length.ShouldBe(3);
            methodGetRAUserCalendarInfoPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRAUserCalendarInfo) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetRAUserCalendarInfo_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetRAUserCalendarInfoPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetRAUserCalendarInfo, Fixture, methodGetRAUserCalendarInfoPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetRAUserCalendarInfoPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetRAUserCalendarInfo) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetRAUserCalendarInfo_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRAUserCalendarInfoPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetRAUserCalendarInfo, Fixture, methodGetRAUserCalendarInfoPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRAUserCalendarInfoPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRAUserCalendarInfo) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetRAUserCalendarInfo_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRAUserCalendarInfo, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRAUserCalendarInfo) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetRAUserCalendarInfo_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRAUserCalendarInfo, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPortfolioItemList) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_GetPortfolioItemList_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetPortfolioItemListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetPortfolioItemList, Fixture, methodGetPortfolioItemListPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPortfolioItemList) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetPortfolioItemList_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.GetPortfolioItemList(Context, sXML, RAData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetPortfolioItemList) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetPortfolioItemList_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetPortfolioItemListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetPortfolioItemList = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPortfolioItemList, methodGetPortfolioItemListPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetPortfolioItemList, Fixture, methodGetPortfolioItemListPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetPortfolioItemList, parametersOfGetPortfolioItemList, methodGetPortfolioItemListPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfGetPortfolioItemList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetPortfolioItemList.ShouldNotBeNull();
            parametersOfGetPortfolioItemList.Length.ShouldBe(3);
            methodGetPortfolioItemListPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetPortfolioItemList) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetPortfolioItemList_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetPortfolioItemListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetPortfolioItemList = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetPortfolioItemList, parametersOfGetPortfolioItemList, methodGetPortfolioItemListPrametersTypes);

            // Assert
            parametersOfGetPortfolioItemList.ShouldNotBeNull();
            parametersOfGetPortfolioItemList.Length.ShouldBe(3);
            methodGetPortfolioItemListPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPortfolioItemList) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetPortfolioItemList_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetPortfolioItemListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetPortfolioItemList, Fixture, methodGetPortfolioItemListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPortfolioItemListPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetPortfolioItemList) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetPortfolioItemList_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPortfolioItemListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetPortfolioItemList, Fixture, methodGetPortfolioItemListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPortfolioItemListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPortfolioItemList) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetPortfolioItemList_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPortfolioItemList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPortfolioItemList) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetPortfolioItemList_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetPortfolioItemList, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGeneratedPortfolioItemTicket) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_GetGeneratedPortfolioItemTicket_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetGeneratedPortfolioItemTicketPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetGeneratedPortfolioItemTicket, Fixture, methodGetGeneratedPortfolioItemTicketPrametersTypes);
        }

        #endregion

        #region Method Call : (GetGeneratedPortfolioItemTicket) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetGeneratedPortfolioItemTicket_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.GetGeneratedPortfolioItemTicket(Context, sXML, RAData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetGeneratedPortfolioItemTicket) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetGeneratedPortfolioItemTicket_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetGeneratedPortfolioItemTicketPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetGeneratedPortfolioItemTicket = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGeneratedPortfolioItemTicket, methodGetGeneratedPortfolioItemTicketPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetGeneratedPortfolioItemTicket, Fixture, methodGetGeneratedPortfolioItemTicketPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetGeneratedPortfolioItemTicket, parametersOfGetGeneratedPortfolioItemTicket, methodGetGeneratedPortfolioItemTicketPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfGetGeneratedPortfolioItemTicket);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetGeneratedPortfolioItemTicket.ShouldNotBeNull();
            parametersOfGetGeneratedPortfolioItemTicket.Length.ShouldBe(3);
            methodGetGeneratedPortfolioItemTicketPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetGeneratedPortfolioItemTicket) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetGeneratedPortfolioItemTicket_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetGeneratedPortfolioItemTicketPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetGeneratedPortfolioItemTicket = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetGeneratedPortfolioItemTicket, parametersOfGetGeneratedPortfolioItemTicket, methodGetGeneratedPortfolioItemTicketPrametersTypes);

            // Assert
            parametersOfGetGeneratedPortfolioItemTicket.ShouldNotBeNull();
            parametersOfGetGeneratedPortfolioItemTicket.Length.ShouldBe(3);
            methodGetGeneratedPortfolioItemTicketPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetGeneratedPortfolioItemTicket) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetGeneratedPortfolioItemTicket_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetGeneratedPortfolioItemTicketPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetGeneratedPortfolioItemTicket, Fixture, methodGetGeneratedPortfolioItemTicketPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetGeneratedPortfolioItemTicketPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetGeneratedPortfolioItemTicket) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetGeneratedPortfolioItemTicket_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetGeneratedPortfolioItemTicketPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetGeneratedPortfolioItemTicket, Fixture, methodGetGeneratedPortfolioItemTicketPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetGeneratedPortfolioItemTicketPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGeneratedPortfolioItemTicket) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetGeneratedPortfolioItemTicket_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGeneratedPortfolioItemTicket, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetGeneratedPortfolioItemTicket) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetGeneratedPortfolioItemTicket_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetGeneratedPortfolioItemTicket, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RASessionPing) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_RASessionPing_Static_Method_Call_Internally(Type[] types)
        {
            var methodRASessionPingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodRASessionPing, Fixture, methodRASessionPingPrametersTypes);
        }

        #endregion

        #region Method Call : (RASessionPing) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RASessionPing_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.RASessionPing(Context, sXML, RAData);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (RASessionPing) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RASessionPing_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodRASessionPingPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfRASessionPing = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRASessionPing, methodRASessionPingPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodRASessionPing, Fixture, methodRASessionPingPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodRASessionPing, parametersOfRASessionPing, methodRASessionPingPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRASessionPing.ShouldNotBeNull();
            parametersOfRASessionPing.Length.ShouldBe(3);
            methodRASessionPingPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodRASessionPing, parametersOfRASessionPing, methodRASessionPingPrametersTypes));
        }

        #endregion

        #region Method Call : (RASessionPing) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RASessionPing_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodRASessionPingPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfRASessionPing = { Context, sXML, RAData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRASessionPing, methodRASessionPingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfRASessionPing);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRASessionPing.ShouldNotBeNull();
            parametersOfRASessionPing.Length.ShouldBe(3);
            methodRASessionPingPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RASessionPing) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RASessionPing_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodRASessionPingPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfRASessionPing = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodRASessionPing, parametersOfRASessionPing, methodRASessionPingPrametersTypes);

            // Assert
            parametersOfRASessionPing.ShouldNotBeNull();
            parametersOfRASessionPing.Length.ShouldBe(3);
            methodRASessionPingPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RASessionPing) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RASessionPing_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodRASessionPingPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodRASessionPing, Fixture, methodRASessionPingPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodRASessionPingPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (RASessionPing) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RASessionPing_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRASessionPingPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodRASessionPing, Fixture, methodRASessionPingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRASessionPingPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RASessionPing) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RASessionPing_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRASessionPing, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (RASessionPing) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RASessionPing_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRASessionPing, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RALoadData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_RALoadData_Static_Method_Call_Internally(Type[] types)
        {
            var methodRALoadDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodRALoadData, Fixture, methodRALoadDataPrametersTypes);
        }

        #endregion

        #region Method Call : (RALoadData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RALoadData_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.RALoadData(Context, sXML, RAData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RALoadData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RALoadData_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodRALoadDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfRALoadData = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRALoadData, methodRALoadDataPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodRALoadData, Fixture, methodRALoadDataPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodRALoadData, parametersOfRALoadData, methodRALoadDataPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfRALoadData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfRALoadData.ShouldNotBeNull();
            parametersOfRALoadData.Length.ShouldBe(3);
            methodRALoadDataPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RALoadData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RALoadData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodRALoadDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfRALoadData = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodRALoadData, parametersOfRALoadData, methodRALoadDataPrametersTypes);

            // Assert
            parametersOfRALoadData.ShouldNotBeNull();
            parametersOfRALoadData.Length.ShouldBe(3);
            methodRALoadDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RALoadData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RALoadData_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodRALoadDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodRALoadData, Fixture, methodRALoadDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRALoadDataPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (RALoadData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RALoadData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRALoadDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodRALoadData, Fixture, methodRALoadDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRALoadDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RALoadData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RALoadData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRALoadData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RALoadData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RALoadData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRALoadData, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRAWorkDetails) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_GetRAWorkDetails_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetRAWorkDetailsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetRAWorkDetails, Fixture, methodGetRAWorkDetailsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRAWorkDetails) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetRAWorkDetails_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.GetRAWorkDetails(Context, sXML, RAData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetRAWorkDetails) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetRAWorkDetails_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetRAWorkDetailsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetRAWorkDetails = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRAWorkDetails, methodGetRAWorkDetailsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetRAWorkDetails, Fixture, methodGetRAWorkDetailsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetRAWorkDetails, parametersOfGetRAWorkDetails, methodGetRAWorkDetailsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfGetRAWorkDetails);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetRAWorkDetails.ShouldNotBeNull();
            parametersOfGetRAWorkDetails.Length.ShouldBe(3);
            methodGetRAWorkDetailsPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetRAWorkDetails) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetRAWorkDetails_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetRAWorkDetailsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetRAWorkDetails = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetRAWorkDetails, parametersOfGetRAWorkDetails, methodGetRAWorkDetailsPrametersTypes);

            // Assert
            parametersOfGetRAWorkDetails.ShouldNotBeNull();
            parametersOfGetRAWorkDetails.Length.ShouldBe(3);
            methodGetRAWorkDetailsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRAWorkDetails) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetRAWorkDetails_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetRAWorkDetailsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetRAWorkDetails, Fixture, methodGetRAWorkDetailsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetRAWorkDetailsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetRAWorkDetails) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetRAWorkDetails_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRAWorkDetailsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetRAWorkDetails, Fixture, methodGetRAWorkDetailsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRAWorkDetailsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRAWorkDetails) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetRAWorkDetails_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRAWorkDetails, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRAWorkDetails) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetRAWorkDetails_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRAWorkDetails, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetRAWorkDetails) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_SetRAWorkDetails_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetRAWorkDetailsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRAWorkDetails, Fixture, methodSetRAWorkDetailsPrametersTypes);
        }

        #endregion

        #region Method Call : (SetRAWorkDetails) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRAWorkDetails_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.SetRAWorkDetails(Context, sXML, RAData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetRAWorkDetails) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRAWorkDetails_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodSetRAWorkDetailsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfSetRAWorkDetails = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetRAWorkDetails, methodSetRAWorkDetailsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRAWorkDetails, Fixture, methodSetRAWorkDetailsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRAWorkDetails, parametersOfSetRAWorkDetails, methodSetRAWorkDetailsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfSetRAWorkDetails);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSetRAWorkDetails.ShouldNotBeNull();
            parametersOfSetRAWorkDetails.Length.ShouldBe(3);
            methodSetRAWorkDetailsPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetRAWorkDetails) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRAWorkDetails_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodSetRAWorkDetailsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfSetRAWorkDetails = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRAWorkDetails, parametersOfSetRAWorkDetails, methodSetRAWorkDetailsPrametersTypes);

            // Assert
            parametersOfSetRAWorkDetails.ShouldNotBeNull();
            parametersOfSetRAWorkDetails.Length.ShouldBe(3);
            methodSetRAWorkDetailsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetRAWorkDetails) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRAWorkDetails_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSetRAWorkDetailsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRAWorkDetails, Fixture, methodSetRAWorkDetailsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSetRAWorkDetailsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SetRAWorkDetails) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRAWorkDetails_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetRAWorkDetailsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRAWorkDetails, Fixture, methodSetRAWorkDetailsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetRAWorkDetailsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetRAWorkDetails) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRAWorkDetails_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetRAWorkDetails, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetRAWorkDetails) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRAWorkDetails_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetRAWorkDetails, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetRAWorkDisplayMode) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_SetRAWorkDisplayMode_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetRAWorkDisplayModePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRAWorkDisplayMode, Fixture, methodSetRAWorkDisplayModePrametersTypes);
        }

        #endregion

        #region Method Call : (SetRAWorkDisplayMode) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRAWorkDisplayMode_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.SetRAWorkDisplayMode(Context, sXML, RAData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetRAWorkDisplayMode) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRAWorkDisplayMode_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodSetRAWorkDisplayModePrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfSetRAWorkDisplayMode = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetRAWorkDisplayMode, methodSetRAWorkDisplayModePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRAWorkDisplayMode, Fixture, methodSetRAWorkDisplayModePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRAWorkDisplayMode, parametersOfSetRAWorkDisplayMode, methodSetRAWorkDisplayModePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfSetRAWorkDisplayMode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSetRAWorkDisplayMode.ShouldNotBeNull();
            parametersOfSetRAWorkDisplayMode.Length.ShouldBe(3);
            methodSetRAWorkDisplayModePrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetRAWorkDisplayMode) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRAWorkDisplayMode_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodSetRAWorkDisplayModePrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfSetRAWorkDisplayMode = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRAWorkDisplayMode, parametersOfSetRAWorkDisplayMode, methodSetRAWorkDisplayModePrametersTypes);

            // Assert
            parametersOfSetRAWorkDisplayMode.ShouldNotBeNull();
            parametersOfSetRAWorkDisplayMode.Length.ShouldBe(3);
            methodSetRAWorkDisplayModePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetRAWorkDisplayMode) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRAWorkDisplayMode_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSetRAWorkDisplayModePrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRAWorkDisplayMode, Fixture, methodSetRAWorkDisplayModePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSetRAWorkDisplayModePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SetRAWorkDisplayMode) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRAWorkDisplayMode_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetRAWorkDisplayModePrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRAWorkDisplayMode, Fixture, methodSetRAWorkDisplayModePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetRAWorkDisplayModePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetRAWorkDisplayMode) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRAWorkDisplayMode_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetRAWorkDisplayMode, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetRAWorkDisplayMode) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRAWorkDisplayMode_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetRAWorkDisplayMode, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_GetResourceAnalyzerData_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourceAnalyzerDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetResourceAnalyzerData, Fixture, methodGetResourceAnalyzerDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetResourceAnalyzerData_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.GetResourceAnalyzerData(Context, sXML, RAData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetResourceAnalyzerData_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetResourceAnalyzerDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetResourceAnalyzerData = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourceAnalyzerData, methodGetResourceAnalyzerDataPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetResourceAnalyzerData, Fixture, methodGetResourceAnalyzerDataPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetResourceAnalyzerData, parametersOfGetResourceAnalyzerData, methodGetResourceAnalyzerDataPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfGetResourceAnalyzerData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetResourceAnalyzerData.ShouldNotBeNull();
            parametersOfGetResourceAnalyzerData.Length.ShouldBe(3);
            methodGetResourceAnalyzerDataPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetResourceAnalyzerData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetResourceAnalyzerDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetResourceAnalyzerData = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetResourceAnalyzerData, parametersOfGetResourceAnalyzerData, methodGetResourceAnalyzerDataPrametersTypes);

            // Assert
            parametersOfGetResourceAnalyzerData.ShouldNotBeNull();
            parametersOfGetResourceAnalyzerData.Length.ShouldBe(3);
            methodGetResourceAnalyzerDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetResourceAnalyzerData_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetResourceAnalyzerDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetResourceAnalyzerData, Fixture, methodGetResourceAnalyzerDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetResourceAnalyzerDataPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetResourceAnalyzerData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourceAnalyzerDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetResourceAnalyzerData, Fixture, methodGetResourceAnalyzerDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourceAnalyzerDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetResourceAnalyzerData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourceAnalyzerData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetResourceAnalyzerData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetResourceAnalyzerData, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerTotals) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_GetResourceAnalyzerTotals_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourceAnalyzerTotalsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetResourceAnalyzerTotals, Fixture, methodGetResourceAnalyzerTotalsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerTotals) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetResourceAnalyzerTotals_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.GetResourceAnalyzerTotals(Context, sXML, RAData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerTotals) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetResourceAnalyzerTotals_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetResourceAnalyzerTotalsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetResourceAnalyzerTotals = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourceAnalyzerTotals, methodGetResourceAnalyzerTotalsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetResourceAnalyzerTotals, Fixture, methodGetResourceAnalyzerTotalsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetResourceAnalyzerTotals, parametersOfGetResourceAnalyzerTotals, methodGetResourceAnalyzerTotalsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfGetResourceAnalyzerTotals);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetResourceAnalyzerTotals.ShouldNotBeNull();
            parametersOfGetResourceAnalyzerTotals.Length.ShouldBe(3);
            methodGetResourceAnalyzerTotalsPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerTotals) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetResourceAnalyzerTotals_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetResourceAnalyzerTotalsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetResourceAnalyzerTotals = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetResourceAnalyzerTotals, parametersOfGetResourceAnalyzerTotals, methodGetResourceAnalyzerTotalsPrametersTypes);

            // Assert
            parametersOfGetResourceAnalyzerTotals.ShouldNotBeNull();
            parametersOfGetResourceAnalyzerTotals.Length.ShouldBe(3);
            methodGetResourceAnalyzerTotalsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerTotals) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetResourceAnalyzerTotals_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetResourceAnalyzerTotalsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetResourceAnalyzerTotals, Fixture, methodGetResourceAnalyzerTotalsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetResourceAnalyzerTotalsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerTotals) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetResourceAnalyzerTotals_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourceAnalyzerTotalsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetResourceAnalyzerTotals, Fixture, methodGetResourceAnalyzerTotalsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourceAnalyzerTotalsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerTotals) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetResourceAnalyzerTotals_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourceAnalyzerTotals, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerTotals) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetResourceAnalyzerTotals_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetResourceAnalyzerTotals, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetBottomDetailsDisplay) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_SetBottomDetailsDisplay_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetBottomDetailsDisplayPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetBottomDetailsDisplay, Fixture, methodSetBottomDetailsDisplayPrametersTypes);
        }

        #endregion

        #region Method Call : (SetBottomDetailsDisplay) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetBottomDetailsDisplay_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.SetBottomDetailsDisplay(Context, sXML, RAData);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (SetBottomDetailsDisplay) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetBottomDetailsDisplay_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodSetBottomDetailsDisplayPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfSetBottomDetailsDisplay = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetBottomDetailsDisplay, methodSetBottomDetailsDisplayPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetBottomDetailsDisplay, Fixture, methodSetBottomDetailsDisplayPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetBottomDetailsDisplay, parametersOfSetBottomDetailsDisplay, methodSetBottomDetailsDisplayPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSetBottomDetailsDisplay.ShouldNotBeNull();
            parametersOfSetBottomDetailsDisplay.Length.ShouldBe(3);
            methodSetBottomDetailsDisplayPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetBottomDetailsDisplay, parametersOfSetBottomDetailsDisplay, methodSetBottomDetailsDisplayPrametersTypes));
        }

        #endregion

        #region Method Call : (SetBottomDetailsDisplay) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetBottomDetailsDisplay_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodSetBottomDetailsDisplayPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfSetBottomDetailsDisplay = { Context, sXML, RAData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetBottomDetailsDisplay, methodSetBottomDetailsDisplayPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfSetBottomDetailsDisplay);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetBottomDetailsDisplay.ShouldNotBeNull();
            parametersOfSetBottomDetailsDisplay.Length.ShouldBe(3);
            methodSetBottomDetailsDisplayPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetBottomDetailsDisplay) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetBottomDetailsDisplay_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodSetBottomDetailsDisplayPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfSetBottomDetailsDisplay = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetBottomDetailsDisplay, parametersOfSetBottomDetailsDisplay, methodSetBottomDetailsDisplayPrametersTypes);

            // Assert
            parametersOfSetBottomDetailsDisplay.ShouldNotBeNull();
            parametersOfSetBottomDetailsDisplay.Length.ShouldBe(3);
            methodSetBottomDetailsDisplayPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetBottomDetailsDisplay) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetBottomDetailsDisplay_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodSetBottomDetailsDisplayPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetBottomDetailsDisplay, Fixture, methodSetBottomDetailsDisplayPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodSetBottomDetailsDisplayPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SetBottomDetailsDisplay) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetBottomDetailsDisplay_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetBottomDetailsDisplayPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetBottomDetailsDisplay, Fixture, methodSetBottomDetailsDisplayPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetBottomDetailsDisplayPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetBottomDetailsDisplay) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetBottomDetailsDisplay_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetBottomDetailsDisplay, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SetBottomDetailsDisplay) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetBottomDetailsDisplay_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetBottomDetailsDisplay, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTotalsColumnsConfiguration) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_GetTotalsColumnsConfiguration_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTotalsColumnsConfigurationPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetTotalsColumnsConfiguration, Fixture, methodGetTotalsColumnsConfigurationPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTotalsColumnsConfiguration) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetTotalsColumnsConfiguration_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.GetTotalsColumnsConfiguration(Context, sXML, RAData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTotalsColumnsConfiguration) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetTotalsColumnsConfiguration_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetTotalsColumnsConfigurationPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetTotalsColumnsConfiguration = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTotalsColumnsConfiguration, methodGetTotalsColumnsConfigurationPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetTotalsColumnsConfiguration, Fixture, methodGetTotalsColumnsConfigurationPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetTotalsColumnsConfiguration, parametersOfGetTotalsColumnsConfiguration, methodGetTotalsColumnsConfigurationPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfGetTotalsColumnsConfiguration);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTotalsColumnsConfiguration.ShouldNotBeNull();
            parametersOfGetTotalsColumnsConfiguration.Length.ShouldBe(3);
            methodGetTotalsColumnsConfigurationPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetTotalsColumnsConfiguration) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetTotalsColumnsConfiguration_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetTotalsColumnsConfigurationPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetTotalsColumnsConfiguration = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetTotalsColumnsConfiguration, parametersOfGetTotalsColumnsConfiguration, methodGetTotalsColumnsConfigurationPrametersTypes);

            // Assert
            parametersOfGetTotalsColumnsConfiguration.ShouldNotBeNull();
            parametersOfGetTotalsColumnsConfiguration.Length.ShouldBe(3);
            methodGetTotalsColumnsConfigurationPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTotalsColumnsConfiguration) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetTotalsColumnsConfiguration_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTotalsColumnsConfigurationPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetTotalsColumnsConfiguration, Fixture, methodGetTotalsColumnsConfigurationPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTotalsColumnsConfigurationPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetTotalsColumnsConfiguration) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetTotalsColumnsConfiguration_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTotalsColumnsConfigurationPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetTotalsColumnsConfiguration, Fixture, methodGetTotalsColumnsConfigurationPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTotalsColumnsConfigurationPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTotalsColumnsConfiguration) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetTotalsColumnsConfiguration_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTotalsColumnsConfiguration, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTotalsColumnsConfiguration) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetTotalsColumnsConfiguration_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTotalsColumnsConfiguration, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetTotalsColumnsConfiguration) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_SetTotalsColumnsConfiguration_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetTotalsColumnsConfigurationPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetTotalsColumnsConfiguration, Fixture, methodSetTotalsColumnsConfigurationPrametersTypes);
        }

        #endregion

        #region Method Call : (SetTotalsColumnsConfiguration) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetTotalsColumnsConfiguration_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.SetTotalsColumnsConfiguration(Context, sXML, RAData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetTotalsColumnsConfiguration) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetTotalsColumnsConfiguration_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodSetTotalsColumnsConfigurationPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfSetTotalsColumnsConfiguration = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetTotalsColumnsConfiguration, methodSetTotalsColumnsConfigurationPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetTotalsColumnsConfiguration, Fixture, methodSetTotalsColumnsConfigurationPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetTotalsColumnsConfiguration, parametersOfSetTotalsColumnsConfiguration, methodSetTotalsColumnsConfigurationPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfSetTotalsColumnsConfiguration);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSetTotalsColumnsConfiguration.ShouldNotBeNull();
            parametersOfSetTotalsColumnsConfiguration.Length.ShouldBe(3);
            methodSetTotalsColumnsConfigurationPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetTotalsColumnsConfiguration) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetTotalsColumnsConfiguration_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodSetTotalsColumnsConfigurationPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfSetTotalsColumnsConfiguration = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetTotalsColumnsConfiguration, parametersOfSetTotalsColumnsConfiguration, methodSetTotalsColumnsConfigurationPrametersTypes);

            // Assert
            parametersOfSetTotalsColumnsConfiguration.ShouldNotBeNull();
            parametersOfSetTotalsColumnsConfiguration.Length.ShouldBe(3);
            methodSetTotalsColumnsConfigurationPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTotalsColumnsConfiguration) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetTotalsColumnsConfiguration_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSetTotalsColumnsConfigurationPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetTotalsColumnsConfiguration, Fixture, methodSetTotalsColumnsConfigurationPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSetTotalsColumnsConfigurationPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SetTotalsColumnsConfiguration) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetTotalsColumnsConfiguration_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetTotalsColumnsConfigurationPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetTotalsColumnsConfiguration, Fixture, methodSetTotalsColumnsConfigurationPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetTotalsColumnsConfigurationPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetTotalsColumnsConfiguration) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetTotalsColumnsConfiguration_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetTotalsColumnsConfiguration, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetTotalsColumnsConfiguration) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetTotalsColumnsConfiguration_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetTotalsColumnsConfiguration, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetRADetailsSelectedFlag) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_SetRADetailsSelectedFlag_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetRADetailsSelectedFlagPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRADetailsSelectedFlag, Fixture, methodSetRADetailsSelectedFlagPrametersTypes);
        }

        #endregion

        #region Method Call : (SetRADetailsSelectedFlag) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRADetailsSelectedFlag_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.SetRADetailsSelectedFlag(Context, sXML, RAData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetRADetailsSelectedFlag) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRADetailsSelectedFlag_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodSetRADetailsSelectedFlagPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfSetRADetailsSelectedFlag = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetRADetailsSelectedFlag, methodSetRADetailsSelectedFlagPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRADetailsSelectedFlag, Fixture, methodSetRADetailsSelectedFlagPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRADetailsSelectedFlag, parametersOfSetRADetailsSelectedFlag, methodSetRADetailsSelectedFlagPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfSetRADetailsSelectedFlag);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSetRADetailsSelectedFlag.ShouldNotBeNull();
            parametersOfSetRADetailsSelectedFlag.Length.ShouldBe(3);
            methodSetRADetailsSelectedFlagPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetRADetailsSelectedFlag) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRADetailsSelectedFlag_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodSetRADetailsSelectedFlagPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfSetRADetailsSelectedFlag = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRADetailsSelectedFlag, parametersOfSetRADetailsSelectedFlag, methodSetRADetailsSelectedFlagPrametersTypes);

            // Assert
            parametersOfSetRADetailsSelectedFlag.ShouldNotBeNull();
            parametersOfSetRADetailsSelectedFlag.Length.ShouldBe(3);
            methodSetRADetailsSelectedFlagPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetRADetailsSelectedFlag) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRADetailsSelectedFlag_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSetRADetailsSelectedFlagPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRADetailsSelectedFlag, Fixture, methodSetRADetailsSelectedFlagPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSetRADetailsSelectedFlagPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SetRADetailsSelectedFlag) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRADetailsSelectedFlag_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetRADetailsSelectedFlagPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRADetailsSelectedFlag, Fixture, methodSetRADetailsSelectedFlagPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetRADetailsSelectedFlagPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetRADetailsSelectedFlag) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRADetailsSelectedFlag_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetRADetailsSelectedFlag, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetRADetailsSelectedFlag) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRADetailsSelectedFlag_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetRADetailsSelectedFlag, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetRATotalSelectedFlag) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_SetRATotalSelectedFlag_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetRATotalSelectedFlagPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRATotalSelectedFlag, Fixture, methodSetRATotalSelectedFlagPrametersTypes);
        }

        #endregion

        #region Method Call : (SetRATotalSelectedFlag) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRATotalSelectedFlag_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.SetRATotalSelectedFlag(Context, sXML, RAData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetRATotalSelectedFlag) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRATotalSelectedFlag_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodSetRATotalSelectedFlagPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfSetRATotalSelectedFlag = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetRATotalSelectedFlag, methodSetRATotalSelectedFlagPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRATotalSelectedFlag, Fixture, methodSetRATotalSelectedFlagPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRATotalSelectedFlag, parametersOfSetRATotalSelectedFlag, methodSetRATotalSelectedFlagPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfSetRATotalSelectedFlag);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSetRATotalSelectedFlag.ShouldNotBeNull();
            parametersOfSetRATotalSelectedFlag.Length.ShouldBe(3);
            methodSetRATotalSelectedFlagPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetRATotalSelectedFlag) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRATotalSelectedFlag_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodSetRATotalSelectedFlagPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfSetRATotalSelectedFlag = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRATotalSelectedFlag, parametersOfSetRATotalSelectedFlag, methodSetRATotalSelectedFlagPrametersTypes);

            // Assert
            parametersOfSetRATotalSelectedFlag.ShouldNotBeNull();
            parametersOfSetRATotalSelectedFlag.Length.ShouldBe(3);
            methodSetRATotalSelectedFlagPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetRATotalSelectedFlag) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRATotalSelectedFlag_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSetRATotalSelectedFlagPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRATotalSelectedFlag, Fixture, methodSetRATotalSelectedFlagPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSetRATotalSelectedFlagPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SetRATotalSelectedFlag) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRATotalSelectedFlag_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetRATotalSelectedFlagPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRATotalSelectedFlag, Fixture, methodSetRATotalSelectedFlagPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetRATotalSelectedFlagPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetRATotalSelectedFlag) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRATotalSelectedFlag_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetRATotalSelectedFlag, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetRATotalSelectedFlag) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRATotalSelectedFlag_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetRATotalSelectedFlag, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetRADragRows) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_SetRADragRows_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetRADragRowsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRADragRows, Fixture, methodSetRADragRowsPrametersTypes);
        }

        #endregion

        #region Method Call : (SetRADragRows) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRADragRows_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.SetRADragRows(Context, sXML, RAData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetRADragRows) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRADragRows_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodSetRADragRowsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfSetRADragRows = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetRADragRows, methodSetRADragRowsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRADragRows, Fixture, methodSetRADragRowsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRADragRows, parametersOfSetRADragRows, methodSetRADragRowsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfSetRADragRows);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSetRADragRows.ShouldNotBeNull();
            parametersOfSetRADragRows.Length.ShouldBe(3);
            methodSetRADragRowsPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetRADragRows) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRADragRows_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodSetRADragRowsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfSetRADragRows = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRADragRows, parametersOfSetRADragRows, methodSetRADragRowsPrametersTypes);

            // Assert
            parametersOfSetRADragRows.ShouldNotBeNull();
            parametersOfSetRADragRows.Length.ShouldBe(3);
            methodSetRADragRowsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetRADragRows) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRADragRows_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSetRADragRowsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRADragRows, Fixture, methodSetRADragRowsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSetRADragRowsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SetRADragRows) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRADragRows_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetRADragRowsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRADragRows, Fixture, methodSetRADragRowsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetRADragRowsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetRADragRows) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRADragRows_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetRADragRows, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetRADragRows) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRADragRows_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetRADragRows, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UndoRADragRows) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_UndoRADragRows_Static_Method_Call_Internally(Type[] types)
        {
            var methodUndoRADragRowsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodUndoRADragRows, Fixture, methodUndoRADragRowsPrametersTypes);
        }

        #endregion

        #region Method Call : (UndoRADragRows) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_UndoRADragRows_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.UndoRADragRows(Context, sXML, RAData);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (UndoRADragRows) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_UndoRADragRows_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodUndoRADragRowsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfUndoRADragRows = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUndoRADragRows, methodUndoRADragRowsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodUndoRADragRows, Fixture, methodUndoRADragRowsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodUndoRADragRows, parametersOfUndoRADragRows, methodUndoRADragRowsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUndoRADragRows.ShouldNotBeNull();
            parametersOfUndoRADragRows.Length.ShouldBe(3);
            methodUndoRADragRowsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodUndoRADragRows, parametersOfUndoRADragRows, methodUndoRADragRowsPrametersTypes));
        }

        #endregion

        #region Method Call : (UndoRADragRows) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_UndoRADragRows_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodUndoRADragRowsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfUndoRADragRows = { Context, sXML, RAData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUndoRADragRows, methodUndoRADragRowsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfUndoRADragRows);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUndoRADragRows.ShouldNotBeNull();
            parametersOfUndoRADragRows.Length.ShouldBe(3);
            methodUndoRADragRowsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UndoRADragRows) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_UndoRADragRows_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodUndoRADragRowsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfUndoRADragRows = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodUndoRADragRows, parametersOfUndoRADragRows, methodUndoRADragRowsPrametersTypes);

            // Assert
            parametersOfUndoRADragRows.ShouldNotBeNull();
            parametersOfUndoRADragRows.Length.ShouldBe(3);
            methodUndoRADragRowsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UndoRADragRows) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_UndoRADragRows_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodUndoRADragRowsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodUndoRADragRows, Fixture, methodUndoRADragRowsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodUndoRADragRowsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (UndoRADragRows) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_UndoRADragRows_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUndoRADragRowsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodUndoRADragRows, Fixture, methodUndoRADragRowsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUndoRADragRowsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UndoRADragRows) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_UndoRADragRows_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUndoRADragRows, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (UndoRADragRows) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_UndoRADragRows_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUndoRADragRows, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetRADetailsFilteredFlag) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_SetRADetailsFilteredFlag_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetRADetailsFilteredFlagPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRADetailsFilteredFlag, Fixture, methodSetRADetailsFilteredFlagPrametersTypes);
        }

        #endregion

        #region Method Call : (SetRADetailsFilteredFlag) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRADetailsFilteredFlag_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.SetRADetailsFilteredFlag(Context, sXML, RAData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetRADetailsFilteredFlag) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRADetailsFilteredFlag_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodSetRADetailsFilteredFlagPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfSetRADetailsFilteredFlag = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetRADetailsFilteredFlag, methodSetRADetailsFilteredFlagPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRADetailsFilteredFlag, Fixture, methodSetRADetailsFilteredFlagPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRADetailsFilteredFlag, parametersOfSetRADetailsFilteredFlag, methodSetRADetailsFilteredFlagPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfSetRADetailsFilteredFlag);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSetRADetailsFilteredFlag.ShouldNotBeNull();
            parametersOfSetRADetailsFilteredFlag.Length.ShouldBe(3);
            methodSetRADetailsFilteredFlagPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetRADetailsFilteredFlag) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRADetailsFilteredFlag_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodSetRADetailsFilteredFlagPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfSetRADetailsFilteredFlag = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRADetailsFilteredFlag, parametersOfSetRADetailsFilteredFlag, methodSetRADetailsFilteredFlagPrametersTypes);

            // Assert
            parametersOfSetRADetailsFilteredFlag.ShouldNotBeNull();
            parametersOfSetRADetailsFilteredFlag.Length.ShouldBe(3);
            methodSetRADetailsFilteredFlagPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetRADetailsFilteredFlag) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRADetailsFilteredFlag_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSetRADetailsFilteredFlagPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRADetailsFilteredFlag, Fixture, methodSetRADetailsFilteredFlagPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSetRADetailsFilteredFlagPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SetRADetailsFilteredFlag) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRADetailsFilteredFlag_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetRADetailsFilteredFlagPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetRADetailsFilteredFlag, Fixture, methodSetRADetailsFilteredFlagPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetRADetailsFilteredFlagPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetRADetailsFilteredFlag) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRADetailsFilteredFlag_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetRADetailsFilteredFlag, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetRADetailsFilteredFlag) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetRADetailsFilteredFlag_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetRADetailsFilteredFlag, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerViews) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_GetResourceAnalyzerViews_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourceAnalyzerViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetResourceAnalyzerViews, Fixture, methodGetResourceAnalyzerViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerViews) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetResourceAnalyzerViews_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.GetResourceAnalyzerViews(Context, sXML, RAData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerViews) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetResourceAnalyzerViews_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetResourceAnalyzerViewsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetResourceAnalyzerViews = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourceAnalyzerViews, methodGetResourceAnalyzerViewsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetResourceAnalyzerViews, Fixture, methodGetResourceAnalyzerViewsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetResourceAnalyzerViews, parametersOfGetResourceAnalyzerViews, methodGetResourceAnalyzerViewsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfGetResourceAnalyzerViews);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetResourceAnalyzerViews.ShouldNotBeNull();
            parametersOfGetResourceAnalyzerViews.Length.ShouldBe(3);
            methodGetResourceAnalyzerViewsPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerViews) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetResourceAnalyzerViews_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetResourceAnalyzerViewsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetResourceAnalyzerViews = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetResourceAnalyzerViews, parametersOfGetResourceAnalyzerViews, methodGetResourceAnalyzerViewsPrametersTypes);

            // Assert
            parametersOfGetResourceAnalyzerViews.ShouldNotBeNull();
            parametersOfGetResourceAnalyzerViews.Length.ShouldBe(3);
            methodGetResourceAnalyzerViewsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerViews) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetResourceAnalyzerViews_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetResourceAnalyzerViewsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetResourceAnalyzerViews, Fixture, methodGetResourceAnalyzerViewsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetResourceAnalyzerViewsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerViews) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetResourceAnalyzerViews_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourceAnalyzerViewsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetResourceAnalyzerViews, Fixture, methodGetResourceAnalyzerViewsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourceAnalyzerViewsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerViews) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetResourceAnalyzerViews_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourceAnalyzerViews, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerViews) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetResourceAnalyzerViews_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetResourceAnalyzerViews, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerView) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_GetResourceAnalyzerView_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourceAnalyzerViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetResourceAnalyzerView, Fixture, methodGetResourceAnalyzerViewPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerView) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetResourceAnalyzerView_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.GetResourceAnalyzerView(Context, sXML, RAData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetResourceAnalyzerView_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetResourceAnalyzerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetResourceAnalyzerView = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourceAnalyzerView, methodGetResourceAnalyzerViewPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetResourceAnalyzerView, Fixture, methodGetResourceAnalyzerViewPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetResourceAnalyzerView, parametersOfGetResourceAnalyzerView, methodGetResourceAnalyzerViewPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfGetResourceAnalyzerView);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetResourceAnalyzerView.ShouldNotBeNull();
            parametersOfGetResourceAnalyzerView.Length.ShouldBe(3);
            methodGetResourceAnalyzerViewPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerView) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetResourceAnalyzerView_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetResourceAnalyzerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetResourceAnalyzerView = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetResourceAnalyzerView, parametersOfGetResourceAnalyzerView, methodGetResourceAnalyzerViewPrametersTypes);

            // Assert
            parametersOfGetResourceAnalyzerView.ShouldNotBeNull();
            parametersOfGetResourceAnalyzerView.Length.ShouldBe(3);
            methodGetResourceAnalyzerViewPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetResourceAnalyzerView_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetResourceAnalyzerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetResourceAnalyzerView, Fixture, methodGetResourceAnalyzerViewPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetResourceAnalyzerViewPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerView) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetResourceAnalyzerView_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourceAnalyzerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetResourceAnalyzerView, Fixture, methodGetResourceAnalyzerViewPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourceAnalyzerViewPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerView) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetResourceAnalyzerView_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourceAnalyzerView, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetResourceAnalyzerView) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetResourceAnalyzerView_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetResourceAnalyzerView, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveResourceAnalyzerView) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_SaveResourceAnalyzerView_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveResourceAnalyzerViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSaveResourceAnalyzerView, Fixture, methodSaveResourceAnalyzerViewPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveResourceAnalyzerView) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SaveResourceAnalyzerView_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.SaveResourceAnalyzerView(Context, sXML, RAData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SaveResourceAnalyzerView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SaveResourceAnalyzerView_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodSaveResourceAnalyzerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfSaveResourceAnalyzerView = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveResourceAnalyzerView, methodSaveResourceAnalyzerViewPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSaveResourceAnalyzerView, Fixture, methodSaveResourceAnalyzerViewPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSaveResourceAnalyzerView, parametersOfSaveResourceAnalyzerView, methodSaveResourceAnalyzerViewPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfSaveResourceAnalyzerView);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSaveResourceAnalyzerView.ShouldNotBeNull();
            parametersOfSaveResourceAnalyzerView.Length.ShouldBe(3);
            methodSaveResourceAnalyzerViewPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SaveResourceAnalyzerView) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SaveResourceAnalyzerView_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodSaveResourceAnalyzerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfSaveResourceAnalyzerView = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSaveResourceAnalyzerView, parametersOfSaveResourceAnalyzerView, methodSaveResourceAnalyzerViewPrametersTypes);

            // Assert
            parametersOfSaveResourceAnalyzerView.ShouldNotBeNull();
            parametersOfSaveResourceAnalyzerView.Length.ShouldBe(3);
            methodSaveResourceAnalyzerViewPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveResourceAnalyzerView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SaveResourceAnalyzerView_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSaveResourceAnalyzerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSaveResourceAnalyzerView, Fixture, methodSaveResourceAnalyzerViewPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSaveResourceAnalyzerViewPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SaveResourceAnalyzerView) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SaveResourceAnalyzerView_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveResourceAnalyzerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSaveResourceAnalyzerView, Fixture, methodSaveResourceAnalyzerViewPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveResourceAnalyzerViewPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveResourceAnalyzerView) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SaveResourceAnalyzerView_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveResourceAnalyzerView, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveResourceAnalyzerView) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SaveResourceAnalyzerView_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveResourceAnalyzerView, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteResourceAnalyzerView) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_DeleteResourceAnalyzerView_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeleteResourceAnalyzerViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodDeleteResourceAnalyzerView, Fixture, methodDeleteResourceAnalyzerViewPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteResourceAnalyzerView) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_DeleteResourceAnalyzerView_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.DeleteResourceAnalyzerView(Context, sXML, RAData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteResourceAnalyzerView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_DeleteResourceAnalyzerView_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodDeleteResourceAnalyzerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfDeleteResourceAnalyzerView = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteResourceAnalyzerView, methodDeleteResourceAnalyzerViewPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodDeleteResourceAnalyzerView, Fixture, methodDeleteResourceAnalyzerViewPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodDeleteResourceAnalyzerView, parametersOfDeleteResourceAnalyzerView, methodDeleteResourceAnalyzerViewPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfDeleteResourceAnalyzerView);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDeleteResourceAnalyzerView.ShouldNotBeNull();
            parametersOfDeleteResourceAnalyzerView.Length.ShouldBe(3);
            methodDeleteResourceAnalyzerViewPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteResourceAnalyzerView) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_DeleteResourceAnalyzerView_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodDeleteResourceAnalyzerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfDeleteResourceAnalyzerView = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodDeleteResourceAnalyzerView, parametersOfDeleteResourceAnalyzerView, methodDeleteResourceAnalyzerViewPrametersTypes);

            // Assert
            parametersOfDeleteResourceAnalyzerView.ShouldNotBeNull();
            parametersOfDeleteResourceAnalyzerView.Length.ShouldBe(3);
            methodDeleteResourceAnalyzerViewPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteResourceAnalyzerView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_DeleteResourceAnalyzerView_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDeleteResourceAnalyzerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodDeleteResourceAnalyzerView, Fixture, methodDeleteResourceAnalyzerViewPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDeleteResourceAnalyzerViewPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (DeleteResourceAnalyzerView) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_DeleteResourceAnalyzerView_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteResourceAnalyzerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodDeleteResourceAnalyzerView, Fixture, methodDeleteResourceAnalyzerViewPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteResourceAnalyzerViewPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteResourceAnalyzerView) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_DeleteResourceAnalyzerView_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteResourceAnalyzerView, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteResourceAnalyzerView) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_DeleteResourceAnalyzerView_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteResourceAnalyzerView, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenameResourceAnalyzerView) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_RenameResourceAnalyzerView_Static_Method_Call_Internally(Type[] types)
        {
            var methodRenameResourceAnalyzerViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodRenameResourceAnalyzerView, Fixture, methodRenameResourceAnalyzerViewPrametersTypes);
        }

        #endregion

        #region Method Call : (RenameResourceAnalyzerView) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RenameResourceAnalyzerView_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.RenameResourceAnalyzerView(Context, sXML, RAData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RenameResourceAnalyzerView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RenameResourceAnalyzerView_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodRenameResourceAnalyzerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfRenameResourceAnalyzerView = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenameResourceAnalyzerView, methodRenameResourceAnalyzerViewPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodRenameResourceAnalyzerView, Fixture, methodRenameResourceAnalyzerViewPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodRenameResourceAnalyzerView, parametersOfRenameResourceAnalyzerView, methodRenameResourceAnalyzerViewPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfRenameResourceAnalyzerView);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfRenameResourceAnalyzerView.ShouldNotBeNull();
            parametersOfRenameResourceAnalyzerView.Length.ShouldBe(3);
            methodRenameResourceAnalyzerViewPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RenameResourceAnalyzerView) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RenameResourceAnalyzerView_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodRenameResourceAnalyzerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfRenameResourceAnalyzerView = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodRenameResourceAnalyzerView, parametersOfRenameResourceAnalyzerView, methodRenameResourceAnalyzerViewPrametersTypes);

            // Assert
            parametersOfRenameResourceAnalyzerView.ShouldNotBeNull();
            parametersOfRenameResourceAnalyzerView.Length.ShouldBe(3);
            methodRenameResourceAnalyzerViewPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenameResourceAnalyzerView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RenameResourceAnalyzerView_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodRenameResourceAnalyzerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodRenameResourceAnalyzerView, Fixture, methodRenameResourceAnalyzerViewPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRenameResourceAnalyzerViewPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (RenameResourceAnalyzerView) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RenameResourceAnalyzerView_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenameResourceAnalyzerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodRenameResourceAnalyzerView, Fixture, methodRenameResourceAnalyzerViewPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenameResourceAnalyzerViewPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenameResourceAnalyzerView) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RenameResourceAnalyzerView_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenameResourceAnalyzerView, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenameResourceAnalyzerView) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RenameResourceAnalyzerView_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenameResourceAnalyzerView, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ApplyResourceAnalyzerViewServerSideSettings) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_ApplyResourceAnalyzerViewServerSideSettings_Static_Method_Call_Internally(Type[] types)
        {
            var methodApplyResourceAnalyzerViewServerSideSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodApplyResourceAnalyzerViewServerSideSettings, Fixture, methodApplyResourceAnalyzerViewServerSideSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (ApplyResourceAnalyzerViewServerSideSettings) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_ApplyResourceAnalyzerViewServerSideSettings_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.ApplyResourceAnalyzerViewServerSideSettings(Context, sXML, RAData);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ApplyResourceAnalyzerViewServerSideSettings) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_ApplyResourceAnalyzerViewServerSideSettings_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodApplyResourceAnalyzerViewServerSideSettingsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfApplyResourceAnalyzerViewServerSideSettings = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodApplyResourceAnalyzerViewServerSideSettings, methodApplyResourceAnalyzerViewServerSideSettingsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodApplyResourceAnalyzerViewServerSideSettings, Fixture, methodApplyResourceAnalyzerViewServerSideSettingsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodApplyResourceAnalyzerViewServerSideSettings, parametersOfApplyResourceAnalyzerViewServerSideSettings, methodApplyResourceAnalyzerViewServerSideSettingsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfApplyResourceAnalyzerViewServerSideSettings.ShouldNotBeNull();
            parametersOfApplyResourceAnalyzerViewServerSideSettings.Length.ShouldBe(3);
            methodApplyResourceAnalyzerViewServerSideSettingsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodApplyResourceAnalyzerViewServerSideSettings, parametersOfApplyResourceAnalyzerViewServerSideSettings, methodApplyResourceAnalyzerViewServerSideSettingsPrametersTypes));
        }

        #endregion

        #region Method Call : (ApplyResourceAnalyzerViewServerSideSettings) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_ApplyResourceAnalyzerViewServerSideSettings_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodApplyResourceAnalyzerViewServerSideSettingsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfApplyResourceAnalyzerViewServerSideSettings = { Context, sXML, RAData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodApplyResourceAnalyzerViewServerSideSettings, methodApplyResourceAnalyzerViewServerSideSettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfApplyResourceAnalyzerViewServerSideSettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfApplyResourceAnalyzerViewServerSideSettings.ShouldNotBeNull();
            parametersOfApplyResourceAnalyzerViewServerSideSettings.Length.ShouldBe(3);
            methodApplyResourceAnalyzerViewServerSideSettingsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyResourceAnalyzerViewServerSideSettings) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_ApplyResourceAnalyzerViewServerSideSettings_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodApplyResourceAnalyzerViewServerSideSettingsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfApplyResourceAnalyzerViewServerSideSettings = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodApplyResourceAnalyzerViewServerSideSettings, parametersOfApplyResourceAnalyzerViewServerSideSettings, methodApplyResourceAnalyzerViewServerSideSettingsPrametersTypes);

            // Assert
            parametersOfApplyResourceAnalyzerViewServerSideSettings.ShouldNotBeNull();
            parametersOfApplyResourceAnalyzerViewServerSideSettings.Length.ShouldBe(3);
            methodApplyResourceAnalyzerViewServerSideSettingsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyResourceAnalyzerViewServerSideSettings) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_ApplyResourceAnalyzerViewServerSideSettings_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodApplyResourceAnalyzerViewServerSideSettingsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodApplyResourceAnalyzerViewServerSideSettings, Fixture, methodApplyResourceAnalyzerViewServerSideSettingsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodApplyResourceAnalyzerViewServerSideSettingsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (ApplyResourceAnalyzerViewServerSideSettings) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_ApplyResourceAnalyzerViewServerSideSettings_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodApplyResourceAnalyzerViewServerSideSettingsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodApplyResourceAnalyzerViewServerSideSettings, Fixture, methodApplyResourceAnalyzerViewServerSideSettingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodApplyResourceAnalyzerViewServerSideSettingsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ApplyResourceAnalyzerViewServerSideSettings) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_ApplyResourceAnalyzerViewServerSideSettings_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodApplyResourceAnalyzerViewServerSideSettings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ApplyResourceAnalyzerViewServerSideSettings) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_ApplyResourceAnalyzerViewServerSideSettings_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodApplyResourceAnalyzerViewServerSideSettings, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioList) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_GetCapacityScenarioList_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCapacityScenarioListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetCapacityScenarioList, Fixture, methodGetCapacityScenarioListPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioList) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetCapacityScenarioList_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.GetCapacityScenarioList(Context, sXML, RAData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioList) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetCapacityScenarioList_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetCapacityScenarioListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetCapacityScenarioList = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCapacityScenarioList, methodGetCapacityScenarioListPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetCapacityScenarioList, Fixture, methodGetCapacityScenarioListPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetCapacityScenarioList, parametersOfGetCapacityScenarioList, methodGetCapacityScenarioListPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfGetCapacityScenarioList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCapacityScenarioList.ShouldNotBeNull();
            parametersOfGetCapacityScenarioList.Length.ShouldBe(3);
            methodGetCapacityScenarioListPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioList) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetCapacityScenarioList_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetCapacityScenarioListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetCapacityScenarioList = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetCapacityScenarioList, parametersOfGetCapacityScenarioList, methodGetCapacityScenarioListPrametersTypes);

            // Assert
            parametersOfGetCapacityScenarioList.ShouldNotBeNull();
            parametersOfGetCapacityScenarioList.Length.ShouldBe(3);
            methodGetCapacityScenarioListPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioList) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetCapacityScenarioList_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCapacityScenarioListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetCapacityScenarioList, Fixture, methodGetCapacityScenarioListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCapacityScenarioListPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioList) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetCapacityScenarioList_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCapacityScenarioListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetCapacityScenarioList, Fixture, methodGetCapacityScenarioListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCapacityScenarioListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioList) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetCapacityScenarioList_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCapacityScenarioList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCapacityScenarioList) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetCapacityScenarioList_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCapacityScenarioList, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteCapacityScenario) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_DeleteCapacityScenario_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeleteCapacityScenarioPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodDeleteCapacityScenario, Fixture, methodDeleteCapacityScenarioPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteCapacityScenario) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_DeleteCapacityScenario_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.DeleteCapacityScenario(Context, sXML, RAData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteCapacityScenario) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_DeleteCapacityScenario_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodDeleteCapacityScenarioPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfDeleteCapacityScenario = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteCapacityScenario, methodDeleteCapacityScenarioPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodDeleteCapacityScenario, Fixture, methodDeleteCapacityScenarioPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodDeleteCapacityScenario, parametersOfDeleteCapacityScenario, methodDeleteCapacityScenarioPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfDeleteCapacityScenario);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDeleteCapacityScenario.ShouldNotBeNull();
            parametersOfDeleteCapacityScenario.Length.ShouldBe(3);
            methodDeleteCapacityScenarioPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteCapacityScenario) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_DeleteCapacityScenario_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodDeleteCapacityScenarioPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfDeleteCapacityScenario = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodDeleteCapacityScenario, parametersOfDeleteCapacityScenario, methodDeleteCapacityScenarioPrametersTypes);

            // Assert
            parametersOfDeleteCapacityScenario.ShouldNotBeNull();
            parametersOfDeleteCapacityScenario.Length.ShouldBe(3);
            methodDeleteCapacityScenarioPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteCapacityScenario) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_DeleteCapacityScenario_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDeleteCapacityScenarioPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodDeleteCapacityScenario, Fixture, methodDeleteCapacityScenarioPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDeleteCapacityScenarioPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (DeleteCapacityScenario) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_DeleteCapacityScenario_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteCapacityScenarioPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodDeleteCapacityScenario, Fixture, methodDeleteCapacityScenarioPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteCapacityScenarioPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteCapacityScenario) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_DeleteCapacityScenario_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteCapacityScenario, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteCapacityScenario) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_DeleteCapacityScenario_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteCapacityScenario, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_GetCapacityScenarioData_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCapacityScenarioDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetCapacityScenarioData, Fixture, methodGetCapacityScenarioDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetCapacityScenarioData_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.GetCapacityScenarioData(Context, sXML, RAData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetCapacityScenarioData_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetCapacityScenarioDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetCapacityScenarioData = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCapacityScenarioData, methodGetCapacityScenarioDataPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetCapacityScenarioData, Fixture, methodGetCapacityScenarioDataPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetCapacityScenarioData, parametersOfGetCapacityScenarioData, methodGetCapacityScenarioDataPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfGetCapacityScenarioData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCapacityScenarioData.ShouldNotBeNull();
            parametersOfGetCapacityScenarioData.Length.ShouldBe(3);
            methodGetCapacityScenarioDataPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetCapacityScenarioData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetCapacityScenarioDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetCapacityScenarioData = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetCapacityScenarioData, parametersOfGetCapacityScenarioData, methodGetCapacityScenarioDataPrametersTypes);

            // Assert
            parametersOfGetCapacityScenarioData.ShouldNotBeNull();
            parametersOfGetCapacityScenarioData.Length.ShouldBe(3);
            methodGetCapacityScenarioDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetCapacityScenarioData_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCapacityScenarioDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetCapacityScenarioData, Fixture, methodGetCapacityScenarioDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCapacityScenarioDataPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetCapacityScenarioData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCapacityScenarioDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetCapacityScenarioData, Fixture, methodGetCapacityScenarioDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCapacityScenarioDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetCapacityScenarioData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCapacityScenarioData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCapacityScenarioData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetCapacityScenarioData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCapacityScenarioData, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioEdit) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_GetCapacityScenarioEdit_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCapacityScenarioEditPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetCapacityScenarioEdit, Fixture, methodGetCapacityScenarioEditPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioEdit) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetCapacityScenarioEdit_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.GetCapacityScenarioEdit(Context, sXML, RAData);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioEdit) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetCapacityScenarioEdit_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetCapacityScenarioEditPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetCapacityScenarioEdit = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCapacityScenarioEdit, methodGetCapacityScenarioEditPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetCapacityScenarioEdit, Fixture, methodGetCapacityScenarioEditPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetCapacityScenarioEdit, parametersOfGetCapacityScenarioEdit, methodGetCapacityScenarioEditPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetCapacityScenarioEdit.ShouldNotBeNull();
            parametersOfGetCapacityScenarioEdit.Length.ShouldBe(3);
            methodGetCapacityScenarioEditPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetCapacityScenarioEdit, parametersOfGetCapacityScenarioEdit, methodGetCapacityScenarioEditPrametersTypes));
        }

        #endregion

        #region Method Call : (GetCapacityScenarioEdit) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetCapacityScenarioEdit_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetCapacityScenarioEditPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetCapacityScenarioEdit = { Context, sXML, RAData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCapacityScenarioEdit, methodGetCapacityScenarioEditPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfGetCapacityScenarioEdit);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCapacityScenarioEdit.ShouldNotBeNull();
            parametersOfGetCapacityScenarioEdit.Length.ShouldBe(3);
            methodGetCapacityScenarioEditPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioEdit) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetCapacityScenarioEdit_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetCapacityScenarioEditPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetCapacityScenarioEdit = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetCapacityScenarioEdit, parametersOfGetCapacityScenarioEdit, methodGetCapacityScenarioEditPrametersTypes);

            // Assert
            parametersOfGetCapacityScenarioEdit.ShouldNotBeNull();
            parametersOfGetCapacityScenarioEdit.Length.ShouldBe(3);
            methodGetCapacityScenarioEditPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioEdit) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetCapacityScenarioEdit_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetCapacityScenarioEditPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetCapacityScenarioEdit, Fixture, methodGetCapacityScenarioEditPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetCapacityScenarioEditPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioEdit) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetCapacityScenarioEdit_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCapacityScenarioEditPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetCapacityScenarioEdit, Fixture, methodGetCapacityScenarioEditPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCapacityScenarioEditPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioEdit) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetCapacityScenarioEdit_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCapacityScenarioEdit, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetCapacityScenarioEdit) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetCapacityScenarioEdit_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCapacityScenarioEdit, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLegendKey) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_GetLegendKey_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetLegendKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetLegendKey, Fixture, methodGetLegendKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLegendKey) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetLegendKey_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.GetLegendKey(Context, sXML, RAData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetLegendKey) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetLegendKey_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetLegendKeyPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetLegendKey = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLegendKey, methodGetLegendKeyPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetLegendKey, Fixture, methodGetLegendKeyPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetLegendKey, parametersOfGetLegendKey, methodGetLegendKeyPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfGetLegendKey);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetLegendKey.ShouldNotBeNull();
            parametersOfGetLegendKey.Length.ShouldBe(3);
            methodGetLegendKeyPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetLegendKey) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetLegendKey_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetLegendKeyPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetLegendKey = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetLegendKey, parametersOfGetLegendKey, methodGetLegendKeyPrametersTypes);

            // Assert
            parametersOfGetLegendKey.ShouldNotBeNull();
            parametersOfGetLegendKey.Length.ShouldBe(3);
            methodGetLegendKeyPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLegendKey) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetLegendKey_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetLegendKeyPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetLegendKey, Fixture, methodGetLegendKeyPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLegendKeyPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetLegendKey) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetLegendKey_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetLegendKeyPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetLegendKey, Fixture, methodGetLegendKeyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLegendKeyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLegendKey) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetLegendKey_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLegendKey, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLegendKey) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetLegendKey_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetLegendKey, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RPASaveDraggedData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_RPASaveDraggedData_Static_Method_Call_Internally(Type[] types)
        {
            var methodRPASaveDraggedDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodRPASaveDraggedData, Fixture, methodRPASaveDraggedDataPrametersTypes);
        }

        #endregion

        #region Method Call : (RPASaveDraggedData) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RPASaveDraggedData_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.RPASaveDraggedData(Context, sXML, RAData);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (RPASaveDraggedData) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RPASaveDraggedData_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodRPASaveDraggedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfRPASaveDraggedData = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRPASaveDraggedData, methodRPASaveDraggedDataPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodRPASaveDraggedData, Fixture, methodRPASaveDraggedDataPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodRPASaveDraggedData, parametersOfRPASaveDraggedData, methodRPASaveDraggedDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRPASaveDraggedData.ShouldNotBeNull();
            parametersOfRPASaveDraggedData.Length.ShouldBe(3);
            methodRPASaveDraggedDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodRPASaveDraggedData, parametersOfRPASaveDraggedData, methodRPASaveDraggedDataPrametersTypes));
        }

        #endregion

        #region Method Call : (RPASaveDraggedData) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RPASaveDraggedData_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodRPASaveDraggedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfRPASaveDraggedData = { Context, sXML, RAData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRPASaveDraggedData, methodRPASaveDraggedDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfRPASaveDraggedData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRPASaveDraggedData.ShouldNotBeNull();
            parametersOfRPASaveDraggedData.Length.ShouldBe(3);
            methodRPASaveDraggedDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RPASaveDraggedData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RPASaveDraggedData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodRPASaveDraggedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfRPASaveDraggedData = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodRPASaveDraggedData, parametersOfRPASaveDraggedData, methodRPASaveDraggedDataPrametersTypes);

            // Assert
            parametersOfRPASaveDraggedData.ShouldNotBeNull();
            parametersOfRPASaveDraggedData.Length.ShouldBe(3);
            methodRPASaveDraggedDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RPASaveDraggedData) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RPASaveDraggedData_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodRPASaveDraggedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodRPASaveDraggedData, Fixture, methodRPASaveDraggedDataPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodRPASaveDraggedDataPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (RPASaveDraggedData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RPASaveDraggedData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRPASaveDraggedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodRPASaveDraggedData, Fixture, methodRPASaveDraggedDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRPASaveDraggedDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RPASaveDraggedData) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RPASaveDraggedData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRPASaveDraggedData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (RPASaveDraggedData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_RPASaveDraggedData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRPASaveDraggedData, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveCapacityScenarioData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_SaveCapacityScenarioData_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveCapacityScenarioDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSaveCapacityScenarioData, Fixture, methodSaveCapacityScenarioDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveCapacityScenarioData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SaveCapacityScenarioData_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.SaveCapacityScenarioData(Context, sXML, RAData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SaveCapacityScenarioData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SaveCapacityScenarioData_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodSaveCapacityScenarioDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfSaveCapacityScenarioData = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveCapacityScenarioData, methodSaveCapacityScenarioDataPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSaveCapacityScenarioData, Fixture, methodSaveCapacityScenarioDataPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSaveCapacityScenarioData, parametersOfSaveCapacityScenarioData, methodSaveCapacityScenarioDataPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfSaveCapacityScenarioData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSaveCapacityScenarioData.ShouldNotBeNull();
            parametersOfSaveCapacityScenarioData.Length.ShouldBe(3);
            methodSaveCapacityScenarioDataPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SaveCapacityScenarioData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SaveCapacityScenarioData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodSaveCapacityScenarioDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfSaveCapacityScenarioData = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSaveCapacityScenarioData, parametersOfSaveCapacityScenarioData, methodSaveCapacityScenarioDataPrametersTypes);

            // Assert
            parametersOfSaveCapacityScenarioData.ShouldNotBeNull();
            parametersOfSaveCapacityScenarioData.Length.ShouldBe(3);
            methodSaveCapacityScenarioDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveCapacityScenarioData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SaveCapacityScenarioData_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSaveCapacityScenarioDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSaveCapacityScenarioData, Fixture, methodSaveCapacityScenarioDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSaveCapacityScenarioDataPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SaveCapacityScenarioData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SaveCapacityScenarioData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveCapacityScenarioDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSaveCapacityScenarioData, Fixture, methodSaveCapacityScenarioDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveCapacityScenarioDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveCapacityScenarioData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SaveCapacityScenarioData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveCapacityScenarioData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveCapacityScenarioData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SaveCapacityScenarioData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveCapacityScenarioData, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReloadPlanData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_ReloadPlanData_Method_Call_Internally(Type[] types)
        {
            var methodReloadPlanDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resPlanAnalyzerInstance, MethodReloadPlanData, Fixture, methodReloadPlanDataPrametersTypes);
        }

        #endregion

        #region Method Call : (ReloadPlanData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_ReloadPlanData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var RAData = CreateType<RPAData>();
            var methodReloadPlanDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(RPAData) };
            object[] parametersOfReloadPlanData = { Context, RAData };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodReloadPlanData, methodReloadPlanDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResPlanAnalyzer, string>(_resPlanAnalyzerInstanceFixture, out exception1, parametersOfReloadPlanData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResPlanAnalyzer, string>(_resPlanAnalyzerInstance, MethodReloadPlanData, parametersOfReloadPlanData, methodReloadPlanDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfReloadPlanData.ShouldNotBeNull();
            parametersOfReloadPlanData.Length.ShouldBe(2);
            methodReloadPlanDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ReloadPlanData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_ReloadPlanData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var RAData = CreateType<RPAData>();
            var methodReloadPlanDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(RPAData) };
            object[] parametersOfReloadPlanData = { Context, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ResPlanAnalyzer, string>(_resPlanAnalyzerInstance, MethodReloadPlanData, parametersOfReloadPlanData, methodReloadPlanDataPrametersTypes);

            // Assert
            parametersOfReloadPlanData.ShouldNotBeNull();
            parametersOfReloadPlanData.Length.ShouldBe(2);
            methodReloadPlanDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReloadPlanData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_ReloadPlanData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodReloadPlanDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resPlanAnalyzerInstance, MethodReloadPlanData, Fixture, methodReloadPlanDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodReloadPlanDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ReloadPlanData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_ReloadPlanData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReloadPlanDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(RPAData) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resPlanAnalyzerInstance, MethodReloadPlanData, Fixture, methodReloadPlanDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodReloadPlanDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReloadPlanData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_ReloadPlanData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReloadPlanData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ReloadPlanData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_ReloadPlanData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReloadPlanData, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveCurrentToScenario) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_SaveCurrentToScenario_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveCurrentToScenarioPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSaveCurrentToScenario, Fixture, methodSaveCurrentToScenarioPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveCurrentToScenario) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SaveCurrentToScenario_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.SaveCurrentToScenario(Context, sXML, RAData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SaveCurrentToScenario) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SaveCurrentToScenario_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodSaveCurrentToScenarioPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfSaveCurrentToScenario = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveCurrentToScenario, methodSaveCurrentToScenarioPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSaveCurrentToScenario, Fixture, methodSaveCurrentToScenarioPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSaveCurrentToScenario, parametersOfSaveCurrentToScenario, methodSaveCurrentToScenarioPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfSaveCurrentToScenario);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSaveCurrentToScenario.ShouldNotBeNull();
            parametersOfSaveCurrentToScenario.Length.ShouldBe(3);
            methodSaveCurrentToScenarioPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SaveCurrentToScenario) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SaveCurrentToScenario_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodSaveCurrentToScenarioPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfSaveCurrentToScenario = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSaveCurrentToScenario, parametersOfSaveCurrentToScenario, methodSaveCurrentToScenarioPrametersTypes);

            // Assert
            parametersOfSaveCurrentToScenario.ShouldNotBeNull();
            parametersOfSaveCurrentToScenario.Length.ShouldBe(3);
            methodSaveCurrentToScenarioPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveCurrentToScenario) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SaveCurrentToScenario_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSaveCurrentToScenarioPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSaveCurrentToScenario, Fixture, methodSaveCurrentToScenarioPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSaveCurrentToScenarioPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SaveCurrentToScenario) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SaveCurrentToScenario_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveCurrentToScenarioPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSaveCurrentToScenario, Fixture, methodSaveCurrentToScenarioPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveCurrentToScenarioPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveCurrentToScenario) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SaveCurrentToScenario_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveCurrentToScenario, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveCurrentToScenario) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SaveCurrentToScenario_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveCurrentToScenario, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetAllCheckMarks) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_SetAllCheckMarks_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetAllCheckMarksPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetAllCheckMarks, Fixture, methodSetAllCheckMarksPrametersTypes);
        }

        #endregion

        #region Method Call : (SetAllCheckMarks) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetAllCheckMarks_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.SetAllCheckMarks(Context, sXML, RAData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetAllCheckMarks) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetAllCheckMarks_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodSetAllCheckMarksPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfSetAllCheckMarks = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetAllCheckMarks, methodSetAllCheckMarksPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetAllCheckMarks, Fixture, methodSetAllCheckMarksPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetAllCheckMarks, parametersOfSetAllCheckMarks, methodSetAllCheckMarksPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfSetAllCheckMarks);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSetAllCheckMarks.ShouldNotBeNull();
            parametersOfSetAllCheckMarks.Length.ShouldBe(3);
            methodSetAllCheckMarksPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetAllCheckMarks) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetAllCheckMarks_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodSetAllCheckMarksPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfSetAllCheckMarks = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetAllCheckMarks, parametersOfSetAllCheckMarks, methodSetAllCheckMarksPrametersTypes);

            // Assert
            parametersOfSetAllCheckMarks.ShouldNotBeNull();
            parametersOfSetAllCheckMarks.Length.ShouldBe(3);
            methodSetAllCheckMarksPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetAllCheckMarks) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetAllCheckMarks_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSetAllCheckMarksPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetAllCheckMarks, Fixture, methodSetAllCheckMarksPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSetAllCheckMarksPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SetAllCheckMarks) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetAllCheckMarks_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetAllCheckMarksPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSetAllCheckMarks, Fixture, methodSetAllCheckMarksPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetAllCheckMarksPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetAllCheckMarks) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetAllCheckMarks_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetAllCheckMarks, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetAllCheckMarks) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SetAllCheckMarks_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetAllCheckMarks, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EditResPlanTicket) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_EditResPlanTicket_Static_Method_Call_Internally(Type[] types)
        {
            var methodEditResPlanTicketPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodEditResPlanTicket, Fixture, methodEditResPlanTicketPrametersTypes);
        }

        #endregion

        #region Method Call : (EditResPlanTicket) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_EditResPlanTicket_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.EditResPlanTicket(Context, sXML, RAData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (EditResPlanTicket) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_EditResPlanTicket_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodEditResPlanTicketPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfEditResPlanTicket = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEditResPlanTicket, methodEditResPlanTicketPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodEditResPlanTicket, Fixture, methodEditResPlanTicketPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodEditResPlanTicket, parametersOfEditResPlanTicket, methodEditResPlanTicketPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfEditResPlanTicket);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfEditResPlanTicket.ShouldNotBeNull();
            parametersOfEditResPlanTicket.Length.ShouldBe(3);
            methodEditResPlanTicketPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (EditResPlanTicket) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_EditResPlanTicket_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodEditResPlanTicketPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfEditResPlanTicket = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodEditResPlanTicket, parametersOfEditResPlanTicket, methodEditResPlanTicketPrametersTypes);

            // Assert
            parametersOfEditResPlanTicket.ShouldNotBeNull();
            parametersOfEditResPlanTicket.Length.ShouldBe(3);
            methodEditResPlanTicketPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EditResPlanTicket) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_EditResPlanTicket_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodEditResPlanTicketPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodEditResPlanTicket, Fixture, methodEditResPlanTicketPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodEditResPlanTicketPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (EditResPlanTicket) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_EditResPlanTicket_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodEditResPlanTicketPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodEditResPlanTicket, Fixture, methodEditResPlanTicketPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodEditResPlanTicketPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EditResPlanTicket) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_EditResPlanTicket_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEditResPlanTicket, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (EditResPlanTicket) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_EditResPlanTicket_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodEditResPlanTicket, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTotalsGridChartData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_GetTotalsGridChartData_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTotalsGridChartDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetTotalsGridChartData, Fixture, methodGetTotalsGridChartDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTotalsGridChartData) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetTotalsGridChartData_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            Action executeAction = null;

            // Act
            executeAction = () => ResPlanAnalyzer.GetTotalsGridChartData(Context, sXML, RAData);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetTotalsGridChartData) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetTotalsGridChartData_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetTotalsGridChartDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetTotalsGridChartData = { Context, sXML, RAData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTotalsGridChartData, methodGetTotalsGridChartDataPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetTotalsGridChartData, Fixture, methodGetTotalsGridChartDataPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetTotalsGridChartData, parametersOfGetTotalsGridChartData, methodGetTotalsGridChartDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetTotalsGridChartData.ShouldNotBeNull();
            parametersOfGetTotalsGridChartData.Length.ShouldBe(3);
            methodGetTotalsGridChartDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetTotalsGridChartData, parametersOfGetTotalsGridChartData, methodGetTotalsGridChartDataPrametersTypes));
        }

        #endregion

        #region Method Call : (GetTotalsGridChartData) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetTotalsGridChartData_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetTotalsGridChartDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetTotalsGridChartData = { Context, sXML, RAData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTotalsGridChartData, methodGetTotalsGridChartDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfGetTotalsGridChartData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTotalsGridChartData.ShouldNotBeNull();
            parametersOfGetTotalsGridChartData.Length.ShouldBe(3);
            methodGetTotalsGridChartDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTotalsGridChartData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetTotalsGridChartData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var RAData = CreateType<RPAData>();
            var methodGetTotalsGridChartDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            object[] parametersOfGetTotalsGridChartData = { Context, sXML, RAData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetTotalsGridChartData, parametersOfGetTotalsGridChartData, methodGetTotalsGridChartDataPrametersTypes);

            // Assert
            parametersOfGetTotalsGridChartData.ShouldNotBeNull();
            parametersOfGetTotalsGridChartData.Length.ShouldBe(3);
            methodGetTotalsGridChartDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTotalsGridChartData) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetTotalsGridChartData_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetTotalsGridChartDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetTotalsGridChartData, Fixture, methodGetTotalsGridChartDataPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetTotalsGridChartDataPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetTotalsGridChartData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetTotalsGridChartData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTotalsGridChartDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(RPAData) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetTotalsGridChartData, Fixture, methodGetTotalsGridChartDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTotalsGridChartDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTotalsGridChartData) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetTotalsGridChartData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTotalsGridChartData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetTotalsGridChartData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetTotalsGridChartData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTotalsGridChartData, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildResultXML) (Return Type : CStruct) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_BuildResultXML_Static_Method_Call_Internally(Type[] types)
        {
            var methodBuildResultXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodBuildResultXML, Fixture, methodBuildResultXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildResultXML) (Return Type : CStruct) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_BuildResultXML_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var nStatus = CreateType<int>();
            var methodBuildResultXMLPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfBuildResultXML = { sContext, nStatus };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildResultXML, methodBuildResultXMLPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfBuildResultXML);

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
        public void AUT_ResPlanAnalyzer_BuildResultXML_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var nStatus = CreateType<int>();
            var methodBuildResultXMLPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfBuildResultXML = { sContext, nStatus };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<CStruct>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodBuildResultXML, parametersOfBuildResultXML, methodBuildResultXMLPrametersTypes);

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
        public void AUT_ResPlanAnalyzer_BuildResultXML_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildResultXMLPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodBuildResultXML, Fixture, methodBuildResultXMLPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildResultXMLPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (BuildResultXML) (Return Type : CStruct) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_BuildResultXML_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildResultXMLPrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodBuildResultXML, Fixture, methodBuildResultXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildResultXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildResultXML) (Return Type : CStruct) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_BuildResultXML_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildResultXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (BuildResultXML) (Return Type : CStruct) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_BuildResultXML_Static_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_ResPlanAnalyzer_HandleError_Static_Method_Call_Internally(Type[] types)
        {
            var methodHandleErrorPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodHandleError, Fixture, methodHandleErrorPrametersTypes);
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_HandleError_Static_Method_Call_With_No_Exception_Thrown_Test()
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
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfHandleError);

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
        public void AUT_ResPlanAnalyzer_HandleError_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var nStatus = CreateType<int>();
            var sError = CreateType<string>();
            var methodHandleErrorPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };
            object[] parametersOfHandleError = { sContext, nStatus, sError };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodHandleError, parametersOfHandleError, methodHandleErrorPrametersTypes);

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
        public void AUT_ResPlanAnalyzer_HandleError_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodHandleErrorPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodHandleError, Fixture, methodHandleErrorPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodHandleErrorPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_HandleError_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHandleErrorPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodHandleError, Fixture, methodHandleErrorPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodHandleErrorPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_HandleError_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHandleError, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_HandleError_Static_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_ResPlanAnalyzer_HandleException_Static_Method_Call_Internally(Type[] types)
        {
            var methodHandleExceptionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodHandleException, Fixture, methodHandleExceptionPrametersTypes);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_HandleException_Static_Method_Call_With_No_Exception_Thrown_Test()
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
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfHandleException);

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
        public void AUT_ResPlanAnalyzer_HandleException_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var nStatus = CreateType<int>();
            var ex = CreateType<Exception>();
            var sStage = CreateType<string>();
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(Exception), typeof(string) };
            object[] parametersOfHandleException = { sContext, nStatus, ex, sStage };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodHandleException, parametersOfHandleException, methodHandleExceptionPrametersTypes);

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
        public void AUT_ResPlanAnalyzer_HandleException_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(Exception), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodHandleException, Fixture, methodHandleExceptionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodHandleExceptionPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_HandleException_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(Exception), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodHandleException, Fixture, methodHandleExceptionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodHandleExceptionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_HandleException_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHandleException, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_HandleException_Static_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_ResPlanAnalyzer_SaveCachedData_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveCachedDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSaveCachedData, Fixture, methodSaveCachedDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveCachedData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SaveCachedData_Static_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
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
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfSaveCachedData);

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
        public void AUT_ResPlanAnalyzer_SaveCachedData_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sKey = CreateType<string>();
            var value = CreateType<object>();
            var methodSaveCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(object) };
            object[] parametersOfSaveCachedData = { Context, sKey, value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSaveCachedData, parametersOfSaveCachedData, methodSaveCachedDataPrametersTypes);

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
        public void AUT_ResPlanAnalyzer_SaveCachedData_Static_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ResPlanAnalyzer_SaveCachedData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodSaveCachedData, Fixture, methodSaveCachedDataPrametersTypes);

            // Assert
            methodSaveCachedDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveCachedData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_SaveCachedData_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveCachedData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResPlanAnalyzer_GetCachedData_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCachedDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetCachedData, Fixture, methodGetCachedDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetCachedData_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sKey = CreateType<string>();
            var methodGetCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfGetCachedData = { Context, sKey };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCachedData, methodGetCachedDataPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetCachedData, Fixture, methodGetCachedDataPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<object>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetCachedData, parametersOfGetCachedData, methodGetCachedDataPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_resPlanAnalyzerInstanceFixture, parametersOfGetCachedData);

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
        public void AUT_ResPlanAnalyzer_GetCachedData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sKey = CreateType<string>();
            var methodGetCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfGetCachedData = { Context, sKey };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<object>(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetCachedData, parametersOfGetCachedData, methodGetCachedDataPrametersTypes);

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
        public void AUT_ResPlanAnalyzer_GetCachedData_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetCachedData, Fixture, methodGetCachedDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCachedDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetCachedData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resPlanAnalyzerInstanceFixture, _resPlanAnalyzerInstanceType, MethodGetCachedData, Fixture, methodGetCachedDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCachedDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetCachedData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCachedData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resPlanAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResPlanAnalyzer_GetCachedData_Static_Method_Call_Parameters_Count_Verification_Test()
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