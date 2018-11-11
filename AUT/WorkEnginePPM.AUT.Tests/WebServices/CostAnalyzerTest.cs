using System;
using System.Diagnostics.CodeAnalysis;
using System.Web;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using CADataCache;
using NUnit.Framework;
using PortfolioEngineCore;
using Should = Shouldly.Should;
using Shouldly;

namespace WorkEnginePPM
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.CostAnalyzer" />)
    ///     and namespace <see cref="WorkEnginePPM"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class CostAnalyzerTest : AbstractBaseSetupTypedTest<CostAnalyzer>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CostAnalyzer) Initializer

        private const string MethodGetSPSessionBasePath = "GetSPSessionBasePath";
        private const string MethodGetCASessionKey = "GetCASessionKey";
        private const string MethodExecute = "Execute";
        private const string MethodExecuteJSON = "ExecuteJSON";
        private const string MethodGetPortfolioItemList = "GetPortfolioItemList";
        private const string MethodGetGeneratedPortfolioItemTicket = "GetGeneratedPortfolioItemTicket";
        private const string MethodCASessionPing = "CASessionPing";
        private const string MethodCALoadData = "CALoadData";
        private const string MethodSetCTDetails = "SetCTDetails";
        private const string MethodSetDisplayMode = "SetDisplayMode";
        private const string MethodGetCostAnalyzerData = "GetCostAnalyzerData";
        private const string MethodGetCostAnalyzerTotals = "GetCostAnalyzerTotals";
        private const string MethodGetTargetGrid = "GetTargetGrid";
        private const string MethodGetTotalsConfiguration = "GetTotalsConfiguration";
        private const string MethodSetTotalsConfiguration = "SetTotalsConfiguration";
        private const string MethodGetCompareCostTypeList = "GetCompareCostTypeList";
        private const string MethodSetCompareCostTypeList = "SetCompareCostTypeList";
        private const string MethodSetDetailsSelectedFlag = "SetDetailsSelectedFlag";
        private const string MethodSetDetailsFilteredFlag = "SetDetailsFilteredFlag";
        private const string MethodGetLegendKey = "GetLegendKey";
        private const string MethodSetShowRemaining = "SetShowRemaining";
        private const string MethodSaveCostPlanAnalyzerView = "SaveCostPlanAnalyzerView";
        private const string MethodDeleteCostAnalyzerView = "DeleteCostAnalyzerView";
        private const string MethodRenameCostAnalyzerView = "RenameCostAnalyzerView";
        private const string MethodApplyCostAnalyzerViewServerSideSettings = "ApplyCostAnalyzerViewServerSideSettings";
        private const string MethodGetTargetList = "GetTargetList";
        private const string MethodDeleteTarget = "DeleteTarget";
        private const string MethodGetClientSideCalcData = "GetClientSideCalcData";
        private const string MethodGetTargetTotalsData = "GetTargetTotalsData";
        private const string MethodPrepareTargetData = "PrepareTargetData";
        private const string MethodSaveTargetData = "SaveTargetData";
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
        private Type _costAnalyzerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CostAnalyzer _costAnalyzerInstance;
        private CostAnalyzer _costAnalyzerInstanceFixture;

        #region General Initializer : Class (CostAnalyzer) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CostAnalyzer" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _costAnalyzerInstanceType = typeof(CostAnalyzer);
            _costAnalyzerInstanceFixture = Create(true);
            _costAnalyzerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CostAnalyzer)

        #region General Initializer : Class (CostAnalyzer) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="CostAnalyzer" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetSPSessionBasePath, 0)]
        [TestCase(MethodGetCASessionKey, 0)]
        [TestCase(MethodExecute, 0)]
        [TestCase(MethodExecuteJSON, 0)]
        [TestCase(MethodGetPortfolioItemList, 0)]
        [TestCase(MethodGetGeneratedPortfolioItemTicket, 0)]
        [TestCase(MethodCASessionPing, 0)]
        [TestCase(MethodCALoadData, 0)]
        [TestCase(MethodSetCTDetails, 0)]
        [TestCase(MethodSetDisplayMode, 0)]
        [TestCase(MethodGetCostAnalyzerData, 0)]
        [TestCase(MethodGetCostAnalyzerTotals, 0)]
        [TestCase(MethodGetTargetGrid, 0)]
        [TestCase(MethodGetTotalsConfiguration, 0)]
        [TestCase(MethodSetTotalsConfiguration, 0)]
        [TestCase(MethodGetCompareCostTypeList, 0)]
        [TestCase(MethodSetCompareCostTypeList, 0)]
        [TestCase(MethodSetDetailsSelectedFlag, 0)]
        [TestCase(MethodSetDetailsFilteredFlag, 0)]
        [TestCase(MethodGetLegendKey, 0)]
        [TestCase(MethodSetShowRemaining, 0)]
        [TestCase(MethodSaveCostPlanAnalyzerView, 0)]
        [TestCase(MethodDeleteCostAnalyzerView, 0)]
        [TestCase(MethodRenameCostAnalyzerView, 0)]
        [TestCase(MethodApplyCostAnalyzerViewServerSideSettings, 0)]
        [TestCase(MethodGetTargetList, 0)]
        [TestCase(MethodDeleteTarget, 0)]
        [TestCase(MethodGetClientSideCalcData, 0)]
        [TestCase(MethodGetTargetTotalsData, 0)]
        [TestCase(MethodPrepareTargetData, 0)]
        [TestCase(MethodSaveTargetData, 0)]
        [TestCase(MethodBuildResultXML, 0)]
        [TestCase(MethodHandleError, 0)]
        [TestCase(MethodHandleException, 0)]
        [TestCase(MethodSaveCachedData, 0)]
        [TestCase(MethodGetCachedData, 0)]
        public void AUT_CostAnalyzer_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_costAnalyzerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CostAnalyzer) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CostAnalyzer" />) explore and verify fields for coverage gain.
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
        public void AUT_CostAnalyzer_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_costAnalyzerInstanceFixture, 
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
        ///     Class (<see cref="CostAnalyzer" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_CostAnalyzer_Is_Instance_Present_Test()
        {
            // Assert
            _costAnalyzerInstanceType.ShouldNotBeNull();
            _costAnalyzerInstance.ShouldNotBeNull();
            _costAnalyzerInstanceFixture.ShouldNotBeNull();
            _costAnalyzerInstance.ShouldBeAssignableTo<CostAnalyzer>();
            _costAnalyzerInstanceFixture.ShouldBeAssignableTo<CostAnalyzer>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CostAnalyzer) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_CostAnalyzer_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CostAnalyzer instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _costAnalyzerInstanceType.ShouldNotBeNull();
            _costAnalyzerInstance.ShouldNotBeNull();
            _costAnalyzerInstanceFixture.ShouldNotBeNull();
            _costAnalyzerInstance.ShouldBeAssignableTo<CostAnalyzer>();
            _costAnalyzerInstanceFixture.ShouldBeAssignableTo<CostAnalyzer>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="CostAnalyzer" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetPortfolioItemList)]
        [TestCase(MethodGetGeneratedPortfolioItemTicket)]
        [TestCase(MethodCASessionPing)]
        [TestCase(MethodCALoadData)]
        [TestCase(MethodSetCTDetails)]
        [TestCase(MethodSetDisplayMode)]
        [TestCase(MethodGetCostAnalyzerData)]
        [TestCase(MethodGetCostAnalyzerTotals)]
        [TestCase(MethodGetTargetGrid)]
        [TestCase(MethodGetTotalsConfiguration)]
        [TestCase(MethodSetTotalsConfiguration)]
        [TestCase(MethodGetCompareCostTypeList)]
        [TestCase(MethodSetCompareCostTypeList)]
        [TestCase(MethodSetDetailsSelectedFlag)]
        [TestCase(MethodSetDetailsFilteredFlag)]
        [TestCase(MethodGetLegendKey)]
        [TestCase(MethodSetShowRemaining)]
        [TestCase(MethodSaveCostPlanAnalyzerView)]
        [TestCase(MethodDeleteCostAnalyzerView)]
        [TestCase(MethodRenameCostAnalyzerView)]
        [TestCase(MethodApplyCostAnalyzerViewServerSideSettings)]
        [TestCase(MethodGetTargetList)]
        [TestCase(MethodDeleteTarget)]
        [TestCase(MethodGetClientSideCalcData)]
        [TestCase(MethodGetTargetTotalsData)]
        [TestCase(MethodPrepareTargetData)]
        [TestCase(MethodSaveTargetData)]
        [TestCase(MethodBuildResultXML)]
        [TestCase(MethodHandleError)]
        [TestCase(MethodHandleException)]
        [TestCase(MethodSaveCachedData)]
        [TestCase(MethodGetCachedData)]
        public void AUT_CostAnalyzer_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_costAnalyzerInstanceFixture,
                                                                              _costAnalyzerInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="CostAnalyzer" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetSPSessionBasePath)]
        [TestCase(MethodGetCASessionKey)]
        [TestCase(MethodExecute)]
        [TestCase(MethodExecuteJSON)]
        public void AUT_CostAnalyzer_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<CostAnalyzer>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetSPSessionBasePath) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_GetSPSessionBasePath_Method_Call_Internally(Type[] types)
        {
            var methodGetSPSessionBasePathPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerInstance, MethodGetSPSessionBasePath, Fixture, methodGetSPSessionBasePathPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSPSessionBasePath) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetSPSessionBasePath_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetSPSessionBasePathPrametersTypes = null;
            object[] parametersOfGetSPSessionBasePath = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSPSessionBasePath, methodGetSPSessionBasePathPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzer, string>(_costAnalyzerInstanceFixture, out exception1, parametersOfGetSPSessionBasePath);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzer, string>(_costAnalyzerInstance, MethodGetSPSessionBasePath, parametersOfGetSPSessionBasePath, methodGetSPSessionBasePathPrametersTypes);

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
        public void AUT_CostAnalyzer_GetSPSessionBasePath_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetSPSessionBasePathPrametersTypes = null;
            object[] parametersOfGetSPSessionBasePath = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzer, string>(_costAnalyzerInstance, MethodGetSPSessionBasePath, parametersOfGetSPSessionBasePath, methodGetSPSessionBasePathPrametersTypes);

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
        public void AUT_CostAnalyzer_GetSPSessionBasePath_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetSPSessionBasePathPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerInstance, MethodGetSPSessionBasePath, Fixture, methodGetSPSessionBasePathPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSPSessionBasePathPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSPSessionBasePath) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetSPSessionBasePath_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetSPSessionBasePathPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerInstance, MethodGetSPSessionBasePath, Fixture, methodGetSPSessionBasePathPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSPSessionBasePathPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSPSessionBasePath) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetSPSessionBasePath_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSPSessionBasePath, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCASessionKey) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_GetCASessionKey_Method_Call_Internally(Type[] types)
        {
            var methodGetCASessionKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerInstance, MethodGetCASessionKey, Fixture, methodGetCASessionKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCASessionKey) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCASessionKey_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetCASessionKeyPrametersTypes = null;
            object[] parametersOfGetCASessionKey = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCASessionKey, methodGetCASessionKeyPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzer, string>(_costAnalyzerInstanceFixture, out exception1, parametersOfGetCASessionKey);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzer, string>(_costAnalyzerInstance, MethodGetCASessionKey, parametersOfGetCASessionKey, methodGetCASessionKeyPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCASessionKey.ShouldBeNull();
            methodGetCASessionKeyPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCASessionKey) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCASessionKey_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetCASessionKeyPrametersTypes = null;
            object[] parametersOfGetCASessionKey = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzer, string>(_costAnalyzerInstance, MethodGetCASessionKey, parametersOfGetCASessionKey, methodGetCASessionKeyPrametersTypes);

            // Assert
            parametersOfGetCASessionKey.ShouldBeNull();
            methodGetCASessionKeyPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCASessionKey) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCASessionKey_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetCASessionKeyPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerInstance, MethodGetCASessionKey, Fixture, methodGetCASessionKeyPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCASessionKeyPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCASessionKey) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCASessionKey_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetCASessionKeyPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerInstance, MethodGetCASessionKey, Fixture, methodGetCASessionKeyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCASessionKeyPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCASessionKey) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCASessionKey_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCASessionKey, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_Execute_Method_Call_Internally(Type[] types)
        {
            var methodExecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerInstance, MethodExecute, Fixture, methodExecutePrametersTypes);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_Execute_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerInstance.Execute(Function, Dataxml);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_Execute_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfExecute = { Function, Dataxml };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodExecute, methodExecutePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzer, string>(_costAnalyzerInstanceFixture, out exception1, parametersOfExecute);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzer, string>(_costAnalyzerInstance, MethodExecute, parametersOfExecute, methodExecutePrametersTypes);

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
        public void AUT_CostAnalyzer_Execute_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfExecute = { Function, Dataxml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzer, string>(_costAnalyzerInstance, MethodExecute, parametersOfExecute, methodExecutePrametersTypes);

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
        public void AUT_CostAnalyzer_Execute_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerInstance, MethodExecute, Fixture, methodExecutePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodExecutePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_Execute_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerInstance, MethodExecute, Fixture, methodExecutePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecutePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_Execute_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecute, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_Execute_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_CostAnalyzer_ExecuteJSON_Method_Call_Internally(Type[] types)
        {
            var methodExecuteJSONPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerInstance, MethodExecuteJSON, Fixture, methodExecuteJSONPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_ExecuteJSON_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerInstance.ExecuteJSON(Function, Dataxml);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_ExecuteJSON_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            var methodExecuteJSONPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfExecuteJSON = { Function, Dataxml };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodExecuteJSON, methodExecuteJSONPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzer, string>(_costAnalyzerInstanceFixture, out exception1, parametersOfExecuteJSON);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzer, string>(_costAnalyzerInstance, MethodExecuteJSON, parametersOfExecuteJSON, methodExecuteJSONPrametersTypes);

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
        public void AUT_CostAnalyzer_ExecuteJSON_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            var methodExecuteJSONPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfExecuteJSON = { Function, Dataxml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodExecuteJSON, methodExecuteJSONPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfExecuteJSON);

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
        public void AUT_CostAnalyzer_ExecuteJSON_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            var methodExecuteJSONPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfExecuteJSON = { Function, Dataxml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzer, string>(_costAnalyzerInstance, MethodExecuteJSON, parametersOfExecuteJSON, methodExecuteJSONPrametersTypes);

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
        public void AUT_CostAnalyzer_ExecuteJSON_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodExecuteJSONPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerInstance, MethodExecuteJSON, Fixture, methodExecuteJSONPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodExecuteJSONPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_ExecuteJSON_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteJSONPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerInstance, MethodExecuteJSON, Fixture, methodExecuteJSONPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecuteJSONPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_ExecuteJSON_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteJSON, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_ExecuteJSON_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (GetPortfolioItemList) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_GetPortfolioItemList_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetPortfolioItemListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetPortfolioItemList, Fixture, methodGetPortfolioItemListPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPortfolioItemList) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetPortfolioItemList_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzer.GetPortfolioItemList(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetPortfolioItemList) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetPortfolioItemList_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodGetPortfolioItemListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfGetPortfolioItemList = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPortfolioItemList, methodGetPortfolioItemListPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetPortfolioItemList, Fixture, methodGetPortfolioItemListPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetPortfolioItemList, parametersOfGetPortfolioItemList, methodGetPortfolioItemListPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfGetPortfolioItemList);

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
        public void AUT_CostAnalyzer_GetPortfolioItemList_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodGetPortfolioItemListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfGetPortfolioItemList = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetPortfolioItemList, parametersOfGetPortfolioItemList, methodGetPortfolioItemListPrametersTypes);

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
        public void AUT_CostAnalyzer_GetPortfolioItemList_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetPortfolioItemListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetPortfolioItemList, Fixture, methodGetPortfolioItemListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPortfolioItemListPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetPortfolioItemList) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetPortfolioItemList_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPortfolioItemListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetPortfolioItemList, Fixture, methodGetPortfolioItemListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPortfolioItemListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPortfolioItemList) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetPortfolioItemList_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPortfolioItemList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPortfolioItemList) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetPortfolioItemList_Static_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_CostAnalyzer_GetGeneratedPortfolioItemTicket_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetGeneratedPortfolioItemTicketPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetGeneratedPortfolioItemTicket, Fixture, methodGetGeneratedPortfolioItemTicketPrametersTypes);
        }

        #endregion

        #region Method Call : (GetGeneratedPortfolioItemTicket) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetGeneratedPortfolioItemTicket_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzer.GetGeneratedPortfolioItemTicket(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetGeneratedPortfolioItemTicket) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetGeneratedPortfolioItemTicket_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodGetGeneratedPortfolioItemTicketPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfGetGeneratedPortfolioItemTicket = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGeneratedPortfolioItemTicket, methodGetGeneratedPortfolioItemTicketPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetGeneratedPortfolioItemTicket, Fixture, methodGetGeneratedPortfolioItemTicketPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetGeneratedPortfolioItemTicket, parametersOfGetGeneratedPortfolioItemTicket, methodGetGeneratedPortfolioItemTicketPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfGetGeneratedPortfolioItemTicket);

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
        public void AUT_CostAnalyzer_GetGeneratedPortfolioItemTicket_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodGetGeneratedPortfolioItemTicketPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfGetGeneratedPortfolioItemTicket = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetGeneratedPortfolioItemTicket, parametersOfGetGeneratedPortfolioItemTicket, methodGetGeneratedPortfolioItemTicketPrametersTypes);

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
        public void AUT_CostAnalyzer_GetGeneratedPortfolioItemTicket_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetGeneratedPortfolioItemTicketPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetGeneratedPortfolioItemTicket, Fixture, methodGetGeneratedPortfolioItemTicketPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetGeneratedPortfolioItemTicketPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetGeneratedPortfolioItemTicket) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetGeneratedPortfolioItemTicket_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetGeneratedPortfolioItemTicketPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetGeneratedPortfolioItemTicket, Fixture, methodGetGeneratedPortfolioItemTicketPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetGeneratedPortfolioItemTicketPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGeneratedPortfolioItemTicket) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetGeneratedPortfolioItemTicket_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGeneratedPortfolioItemTicket, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetGeneratedPortfolioItemTicket) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetGeneratedPortfolioItemTicket_Static_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (CASessionPing) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_CASessionPing_Static_Method_Call_Internally(Type[] types)
        {
            var methodCASessionPingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodCASessionPing, Fixture, methodCASessionPingPrametersTypes);
        }

        #endregion

        #region Method Call : (CASessionPing) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_CASessionPing_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzer.CASessionPing(Context, sXML, datacache);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (CASessionPing) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_CASessionPing_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodCASessionPingPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfCASessionPing = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCASessionPing, methodCASessionPingPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodCASessionPing, Fixture, methodCASessionPingPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodCASessionPing, parametersOfCASessionPing, methodCASessionPingPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCASessionPing.ShouldNotBeNull();
            parametersOfCASessionPing.Length.ShouldBe(3);
            methodCASessionPingPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodCASessionPing, parametersOfCASessionPing, methodCASessionPingPrametersTypes));
        }

        #endregion

        #region Method Call : (CASessionPing) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_CASessionPing_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodCASessionPingPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfCASessionPing = { Context, sXML, datacache };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCASessionPing, methodCASessionPingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfCASessionPing);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCASessionPing.ShouldNotBeNull();
            parametersOfCASessionPing.Length.ShouldBe(3);
            methodCASessionPingPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CASessionPing) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_CASessionPing_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodCASessionPingPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfCASessionPing = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodCASessionPing, parametersOfCASessionPing, methodCASessionPingPrametersTypes);

            // Assert
            parametersOfCASessionPing.ShouldNotBeNull();
            parametersOfCASessionPing.Length.ShouldBe(3);
            methodCASessionPingPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CASessionPing) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_CASessionPing_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodCASessionPingPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodCASessionPing, Fixture, methodCASessionPingPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodCASessionPingPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (CASessionPing) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_CASessionPing_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCASessionPingPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodCASessionPing, Fixture, methodCASessionPingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCASessionPingPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CASessionPing) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_CASessionPing_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCASessionPing, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (CASessionPing) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_CASessionPing_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCASessionPing, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CALoadData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_CALoadData_Static_Method_Call_Internally(Type[] types)
        {
            var methodCALoadDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodCALoadData, Fixture, methodCALoadDataPrametersTypes);
        }

        #endregion

        #region Method Call : (CALoadData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_CALoadData_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzer.CALoadData(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CALoadData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_CALoadData_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodCALoadDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfCALoadData = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCALoadData, methodCALoadDataPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodCALoadData, Fixture, methodCALoadDataPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodCALoadData, parametersOfCALoadData, methodCALoadDataPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfCALoadData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfCALoadData.ShouldNotBeNull();
            parametersOfCALoadData.Length.ShouldBe(3);
            methodCALoadDataPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CALoadData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_CALoadData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodCALoadDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfCALoadData = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodCALoadData, parametersOfCALoadData, methodCALoadDataPrametersTypes);

            // Assert
            parametersOfCALoadData.ShouldNotBeNull();
            parametersOfCALoadData.Length.ShouldBe(3);
            methodCALoadDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CALoadData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_CALoadData_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCALoadDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodCALoadData, Fixture, methodCALoadDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCALoadDataPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (CALoadData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_CALoadData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCALoadDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodCALoadData, Fixture, methodCALoadDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCALoadDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CALoadData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_CALoadData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCALoadData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CALoadData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_CALoadData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCALoadData, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetCTDetails) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_SetCTDetails_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetCTDetailsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetCTDetails, Fixture, methodSetCTDetailsPrametersTypes);
        }

        #endregion

        #region Method Call : (SetCTDetails) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetCTDetails_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzer.SetCTDetails(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetCTDetails) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetCTDetails_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodSetCTDetailsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfSetCTDetails = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetCTDetails, methodSetCTDetailsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetCTDetails, Fixture, methodSetCTDetailsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetCTDetails, parametersOfSetCTDetails, methodSetCTDetailsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfSetCTDetails);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSetCTDetails.ShouldNotBeNull();
            parametersOfSetCTDetails.Length.ShouldBe(3);
            methodSetCTDetailsPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetCTDetails) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetCTDetails_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodSetCTDetailsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfSetCTDetails = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetCTDetails, parametersOfSetCTDetails, methodSetCTDetailsPrametersTypes);

            // Assert
            parametersOfSetCTDetails.ShouldNotBeNull();
            parametersOfSetCTDetails.Length.ShouldBe(3);
            methodSetCTDetailsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetCTDetails) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetCTDetails_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSetCTDetailsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetCTDetails, Fixture, methodSetCTDetailsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSetCTDetailsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SetCTDetails) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetCTDetails_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetCTDetailsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetCTDetails, Fixture, methodSetCTDetailsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetCTDetailsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetCTDetails) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetCTDetails_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetCTDetails, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetCTDetails) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetCTDetails_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetCTDetails, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetDisplayMode) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_SetDisplayMode_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetDisplayModePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetDisplayMode, Fixture, methodSetDisplayModePrametersTypes);
        }

        #endregion

        #region Method Call : (SetDisplayMode) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetDisplayMode_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzer.SetDisplayMode(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetDisplayMode) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetDisplayMode_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodSetDisplayModePrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfSetDisplayMode = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetDisplayMode, methodSetDisplayModePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetDisplayMode, Fixture, methodSetDisplayModePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetDisplayMode, parametersOfSetDisplayMode, methodSetDisplayModePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfSetDisplayMode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSetDisplayMode.ShouldNotBeNull();
            parametersOfSetDisplayMode.Length.ShouldBe(3);
            methodSetDisplayModePrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetDisplayMode) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetDisplayMode_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodSetDisplayModePrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfSetDisplayMode = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetDisplayMode, parametersOfSetDisplayMode, methodSetDisplayModePrametersTypes);

            // Assert
            parametersOfSetDisplayMode.ShouldNotBeNull();
            parametersOfSetDisplayMode.Length.ShouldBe(3);
            methodSetDisplayModePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetDisplayMode) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetDisplayMode_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSetDisplayModePrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetDisplayMode, Fixture, methodSetDisplayModePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSetDisplayModePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SetDisplayMode) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetDisplayMode_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetDisplayModePrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetDisplayMode, Fixture, methodSetDisplayModePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetDisplayModePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetDisplayMode) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetDisplayMode_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetDisplayMode, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetDisplayMode) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetDisplayMode_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetDisplayMode, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCostAnalyzerData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_GetCostAnalyzerData_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCostAnalyzerDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetCostAnalyzerData, Fixture, methodGetCostAnalyzerDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCostAnalyzerData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCostAnalyzerData_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzer.GetCostAnalyzerData(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCostAnalyzerData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCostAnalyzerData_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodGetCostAnalyzerDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfGetCostAnalyzerData = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCostAnalyzerData, methodGetCostAnalyzerDataPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetCostAnalyzerData, Fixture, methodGetCostAnalyzerDataPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetCostAnalyzerData, parametersOfGetCostAnalyzerData, methodGetCostAnalyzerDataPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfGetCostAnalyzerData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCostAnalyzerData.ShouldNotBeNull();
            parametersOfGetCostAnalyzerData.Length.ShouldBe(3);
            methodGetCostAnalyzerDataPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetCostAnalyzerData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCostAnalyzerData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodGetCostAnalyzerDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfGetCostAnalyzerData = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetCostAnalyzerData, parametersOfGetCostAnalyzerData, methodGetCostAnalyzerDataPrametersTypes);

            // Assert
            parametersOfGetCostAnalyzerData.ShouldNotBeNull();
            parametersOfGetCostAnalyzerData.Length.ShouldBe(3);
            methodGetCostAnalyzerDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCostAnalyzerData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCostAnalyzerData_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCostAnalyzerDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetCostAnalyzerData, Fixture, methodGetCostAnalyzerDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCostAnalyzerDataPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetCostAnalyzerData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCostAnalyzerData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCostAnalyzerDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetCostAnalyzerData, Fixture, methodGetCostAnalyzerDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCostAnalyzerDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCostAnalyzerData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCostAnalyzerData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCostAnalyzerData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCostAnalyzerData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCostAnalyzerData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCostAnalyzerData, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCostAnalyzerTotals) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_GetCostAnalyzerTotals_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCostAnalyzerTotalsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetCostAnalyzerTotals, Fixture, methodGetCostAnalyzerTotalsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCostAnalyzerTotals) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCostAnalyzerTotals_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzer.GetCostAnalyzerTotals(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCostAnalyzerTotals) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCostAnalyzerTotals_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodGetCostAnalyzerTotalsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfGetCostAnalyzerTotals = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCostAnalyzerTotals, methodGetCostAnalyzerTotalsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetCostAnalyzerTotals, Fixture, methodGetCostAnalyzerTotalsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetCostAnalyzerTotals, parametersOfGetCostAnalyzerTotals, methodGetCostAnalyzerTotalsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfGetCostAnalyzerTotals);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCostAnalyzerTotals.ShouldNotBeNull();
            parametersOfGetCostAnalyzerTotals.Length.ShouldBe(3);
            methodGetCostAnalyzerTotalsPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetCostAnalyzerTotals) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCostAnalyzerTotals_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodGetCostAnalyzerTotalsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfGetCostAnalyzerTotals = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetCostAnalyzerTotals, parametersOfGetCostAnalyzerTotals, methodGetCostAnalyzerTotalsPrametersTypes);

            // Assert
            parametersOfGetCostAnalyzerTotals.ShouldNotBeNull();
            parametersOfGetCostAnalyzerTotals.Length.ShouldBe(3);
            methodGetCostAnalyzerTotalsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCostAnalyzerTotals) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCostAnalyzerTotals_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCostAnalyzerTotalsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetCostAnalyzerTotals, Fixture, methodGetCostAnalyzerTotalsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCostAnalyzerTotalsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetCostAnalyzerTotals) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCostAnalyzerTotals_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCostAnalyzerTotalsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetCostAnalyzerTotals, Fixture, methodGetCostAnalyzerTotalsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCostAnalyzerTotalsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCostAnalyzerTotals) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCostAnalyzerTotals_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCostAnalyzerTotals, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCostAnalyzerTotals) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCostAnalyzerTotals_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCostAnalyzerTotals, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTargetGrid) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_GetTargetGrid_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTargetGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetTargetGrid, Fixture, methodGetTargetGridPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTargetGrid) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTargetGrid_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzer.GetTargetGrid(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTargetGrid) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTargetGrid_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodGetTargetGridPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfGetTargetGrid = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTargetGrid, methodGetTargetGridPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetTargetGrid, Fixture, methodGetTargetGridPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetTargetGrid, parametersOfGetTargetGrid, methodGetTargetGridPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfGetTargetGrid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTargetGrid.ShouldNotBeNull();
            parametersOfGetTargetGrid.Length.ShouldBe(3);
            methodGetTargetGridPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetTargetGrid) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTargetGrid_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodGetTargetGridPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfGetTargetGrid = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetTargetGrid, parametersOfGetTargetGrid, methodGetTargetGridPrametersTypes);

            // Assert
            parametersOfGetTargetGrid.ShouldNotBeNull();
            parametersOfGetTargetGrid.Length.ShouldBe(3);
            methodGetTargetGridPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTargetGrid) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTargetGrid_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTargetGridPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetTargetGrid, Fixture, methodGetTargetGridPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTargetGridPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetTargetGrid) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTargetGrid_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTargetGridPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetTargetGrid, Fixture, methodGetTargetGridPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTargetGridPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTargetGrid) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTargetGrid_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTargetGrid, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTargetGrid) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTargetGrid_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTargetGrid, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTotalsConfiguration) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_GetTotalsConfiguration_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTotalsConfigurationPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetTotalsConfiguration, Fixture, methodGetTotalsConfigurationPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTotalsConfiguration) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTotalsConfiguration_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzer.GetTotalsConfiguration(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTotalsConfiguration) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTotalsConfiguration_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodGetTotalsConfigurationPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfGetTotalsConfiguration = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTotalsConfiguration, methodGetTotalsConfigurationPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetTotalsConfiguration, Fixture, methodGetTotalsConfigurationPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetTotalsConfiguration, parametersOfGetTotalsConfiguration, methodGetTotalsConfigurationPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfGetTotalsConfiguration);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTotalsConfiguration.ShouldNotBeNull();
            parametersOfGetTotalsConfiguration.Length.ShouldBe(3);
            methodGetTotalsConfigurationPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetTotalsConfiguration) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTotalsConfiguration_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodGetTotalsConfigurationPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfGetTotalsConfiguration = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetTotalsConfiguration, parametersOfGetTotalsConfiguration, methodGetTotalsConfigurationPrametersTypes);

            // Assert
            parametersOfGetTotalsConfiguration.ShouldNotBeNull();
            parametersOfGetTotalsConfiguration.Length.ShouldBe(3);
            methodGetTotalsConfigurationPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTotalsConfiguration) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTotalsConfiguration_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTotalsConfigurationPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetTotalsConfiguration, Fixture, methodGetTotalsConfigurationPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTotalsConfigurationPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetTotalsConfiguration) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTotalsConfiguration_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTotalsConfigurationPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetTotalsConfiguration, Fixture, methodGetTotalsConfigurationPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTotalsConfigurationPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTotalsConfiguration) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTotalsConfiguration_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTotalsConfiguration, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTotalsConfiguration) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTotalsConfiguration_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTotalsConfiguration, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetTotalsConfiguration) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_SetTotalsConfiguration_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetTotalsConfigurationPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetTotalsConfiguration, Fixture, methodSetTotalsConfigurationPrametersTypes);
        }

        #endregion

        #region Method Call : (SetTotalsConfiguration) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetTotalsConfiguration_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzer.SetTotalsConfiguration(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetTotalsConfiguration) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetTotalsConfiguration_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodSetTotalsConfigurationPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfSetTotalsConfiguration = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetTotalsConfiguration, methodSetTotalsConfigurationPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetTotalsConfiguration, Fixture, methodSetTotalsConfigurationPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetTotalsConfiguration, parametersOfSetTotalsConfiguration, methodSetTotalsConfigurationPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfSetTotalsConfiguration);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSetTotalsConfiguration.ShouldNotBeNull();
            parametersOfSetTotalsConfiguration.Length.ShouldBe(3);
            methodSetTotalsConfigurationPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetTotalsConfiguration) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetTotalsConfiguration_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodSetTotalsConfigurationPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfSetTotalsConfiguration = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetTotalsConfiguration, parametersOfSetTotalsConfiguration, methodSetTotalsConfigurationPrametersTypes);

            // Assert
            parametersOfSetTotalsConfiguration.ShouldNotBeNull();
            parametersOfSetTotalsConfiguration.Length.ShouldBe(3);
            methodSetTotalsConfigurationPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTotalsConfiguration) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetTotalsConfiguration_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSetTotalsConfigurationPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetTotalsConfiguration, Fixture, methodSetTotalsConfigurationPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSetTotalsConfigurationPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SetTotalsConfiguration) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetTotalsConfiguration_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetTotalsConfigurationPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetTotalsConfiguration, Fixture, methodSetTotalsConfigurationPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetTotalsConfigurationPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetTotalsConfiguration) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetTotalsConfiguration_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetTotalsConfiguration, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetTotalsConfiguration) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetTotalsConfiguration_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetTotalsConfiguration, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCompareCostTypeList) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_GetCompareCostTypeList_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCompareCostTypeListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetCompareCostTypeList, Fixture, methodGetCompareCostTypeListPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCompareCostTypeList) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCompareCostTypeList_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzer.GetCompareCostTypeList(Context, sXML, datacache);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetCompareCostTypeList) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCompareCostTypeList_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodGetCompareCostTypeListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfGetCompareCostTypeList = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCompareCostTypeList, methodGetCompareCostTypeListPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetCompareCostTypeList, Fixture, methodGetCompareCostTypeListPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetCompareCostTypeList, parametersOfGetCompareCostTypeList, methodGetCompareCostTypeListPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetCompareCostTypeList.ShouldNotBeNull();
            parametersOfGetCompareCostTypeList.Length.ShouldBe(3);
            methodGetCompareCostTypeListPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetCompareCostTypeList, parametersOfGetCompareCostTypeList, methodGetCompareCostTypeListPrametersTypes));
        }

        #endregion

        #region Method Call : (GetCompareCostTypeList) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCompareCostTypeList_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodGetCompareCostTypeListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfGetCompareCostTypeList = { Context, sXML, datacache };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCompareCostTypeList, methodGetCompareCostTypeListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfGetCompareCostTypeList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCompareCostTypeList.ShouldNotBeNull();
            parametersOfGetCompareCostTypeList.Length.ShouldBe(3);
            methodGetCompareCostTypeListPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCompareCostTypeList) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCompareCostTypeList_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodGetCompareCostTypeListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfGetCompareCostTypeList = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetCompareCostTypeList, parametersOfGetCompareCostTypeList, methodGetCompareCostTypeListPrametersTypes);

            // Assert
            parametersOfGetCompareCostTypeList.ShouldNotBeNull();
            parametersOfGetCompareCostTypeList.Length.ShouldBe(3);
            methodGetCompareCostTypeListPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCompareCostTypeList) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCompareCostTypeList_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetCompareCostTypeListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetCompareCostTypeList, Fixture, methodGetCompareCostTypeListPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetCompareCostTypeListPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetCompareCostTypeList) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCompareCostTypeList_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCompareCostTypeListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetCompareCostTypeList, Fixture, methodGetCompareCostTypeListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCompareCostTypeListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCompareCostTypeList) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCompareCostTypeList_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCompareCostTypeList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetCompareCostTypeList) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCompareCostTypeList_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCompareCostTypeList, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetCompareCostTypeList) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_SetCompareCostTypeList_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetCompareCostTypeListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetCompareCostTypeList, Fixture, methodSetCompareCostTypeListPrametersTypes);
        }

        #endregion

        #region Method Call : (SetCompareCostTypeList) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetCompareCostTypeList_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzer.SetCompareCostTypeList(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetCompareCostTypeList) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetCompareCostTypeList_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodSetCompareCostTypeListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfSetCompareCostTypeList = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetCompareCostTypeList, methodSetCompareCostTypeListPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetCompareCostTypeList, Fixture, methodSetCompareCostTypeListPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetCompareCostTypeList, parametersOfSetCompareCostTypeList, methodSetCompareCostTypeListPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfSetCompareCostTypeList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSetCompareCostTypeList.ShouldNotBeNull();
            parametersOfSetCompareCostTypeList.Length.ShouldBe(3);
            methodSetCompareCostTypeListPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetCompareCostTypeList) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetCompareCostTypeList_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodSetCompareCostTypeListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfSetCompareCostTypeList = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetCompareCostTypeList, parametersOfSetCompareCostTypeList, methodSetCompareCostTypeListPrametersTypes);

            // Assert
            parametersOfSetCompareCostTypeList.ShouldNotBeNull();
            parametersOfSetCompareCostTypeList.Length.ShouldBe(3);
            methodSetCompareCostTypeListPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetCompareCostTypeList) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetCompareCostTypeList_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSetCompareCostTypeListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetCompareCostTypeList, Fixture, methodSetCompareCostTypeListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSetCompareCostTypeListPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SetCompareCostTypeList) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetCompareCostTypeList_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetCompareCostTypeListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetCompareCostTypeList, Fixture, methodSetCompareCostTypeListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetCompareCostTypeListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetCompareCostTypeList) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetCompareCostTypeList_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetCompareCostTypeList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetCompareCostTypeList) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetCompareCostTypeList_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetCompareCostTypeList, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetDetailsSelectedFlag) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_SetDetailsSelectedFlag_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetDetailsSelectedFlagPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetDetailsSelectedFlag, Fixture, methodSetDetailsSelectedFlagPrametersTypes);
        }

        #endregion

        #region Method Call : (SetDetailsSelectedFlag) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetDetailsSelectedFlag_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzer.SetDetailsSelectedFlag(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetDetailsSelectedFlag) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetDetailsSelectedFlag_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodSetDetailsSelectedFlagPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfSetDetailsSelectedFlag = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetDetailsSelectedFlag, methodSetDetailsSelectedFlagPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetDetailsSelectedFlag, Fixture, methodSetDetailsSelectedFlagPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetDetailsSelectedFlag, parametersOfSetDetailsSelectedFlag, methodSetDetailsSelectedFlagPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfSetDetailsSelectedFlag);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSetDetailsSelectedFlag.ShouldNotBeNull();
            parametersOfSetDetailsSelectedFlag.Length.ShouldBe(3);
            methodSetDetailsSelectedFlagPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetDetailsSelectedFlag) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetDetailsSelectedFlag_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodSetDetailsSelectedFlagPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfSetDetailsSelectedFlag = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetDetailsSelectedFlag, parametersOfSetDetailsSelectedFlag, methodSetDetailsSelectedFlagPrametersTypes);

            // Assert
            parametersOfSetDetailsSelectedFlag.ShouldNotBeNull();
            parametersOfSetDetailsSelectedFlag.Length.ShouldBe(3);
            methodSetDetailsSelectedFlagPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetDetailsSelectedFlag) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetDetailsSelectedFlag_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSetDetailsSelectedFlagPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetDetailsSelectedFlag, Fixture, methodSetDetailsSelectedFlagPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSetDetailsSelectedFlagPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SetDetailsSelectedFlag) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetDetailsSelectedFlag_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetDetailsSelectedFlagPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetDetailsSelectedFlag, Fixture, methodSetDetailsSelectedFlagPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetDetailsSelectedFlagPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetDetailsSelectedFlag) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetDetailsSelectedFlag_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetDetailsSelectedFlag, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetDetailsSelectedFlag) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetDetailsSelectedFlag_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetDetailsSelectedFlag, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetDetailsFilteredFlag) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_SetDetailsFilteredFlag_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetDetailsFilteredFlagPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetDetailsFilteredFlag, Fixture, methodSetDetailsFilteredFlagPrametersTypes);
        }

        #endregion

        #region Method Call : (SetDetailsFilteredFlag) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetDetailsFilteredFlag_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzer.SetDetailsFilteredFlag(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetDetailsFilteredFlag) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetDetailsFilteredFlag_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodSetDetailsFilteredFlagPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfSetDetailsFilteredFlag = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetDetailsFilteredFlag, methodSetDetailsFilteredFlagPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetDetailsFilteredFlag, Fixture, methodSetDetailsFilteredFlagPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetDetailsFilteredFlag, parametersOfSetDetailsFilteredFlag, methodSetDetailsFilteredFlagPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfSetDetailsFilteredFlag);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSetDetailsFilteredFlag.ShouldNotBeNull();
            parametersOfSetDetailsFilteredFlag.Length.ShouldBe(3);
            methodSetDetailsFilteredFlagPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetDetailsFilteredFlag) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetDetailsFilteredFlag_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodSetDetailsFilteredFlagPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfSetDetailsFilteredFlag = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetDetailsFilteredFlag, parametersOfSetDetailsFilteredFlag, methodSetDetailsFilteredFlagPrametersTypes);

            // Assert
            parametersOfSetDetailsFilteredFlag.ShouldNotBeNull();
            parametersOfSetDetailsFilteredFlag.Length.ShouldBe(3);
            methodSetDetailsFilteredFlagPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetDetailsFilteredFlag) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetDetailsFilteredFlag_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSetDetailsFilteredFlagPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetDetailsFilteredFlag, Fixture, methodSetDetailsFilteredFlagPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSetDetailsFilteredFlagPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SetDetailsFilteredFlag) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetDetailsFilteredFlag_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetDetailsFilteredFlagPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetDetailsFilteredFlag, Fixture, methodSetDetailsFilteredFlagPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetDetailsFilteredFlagPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetDetailsFilteredFlag) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetDetailsFilteredFlag_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetDetailsFilteredFlag, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetDetailsFilteredFlag) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetDetailsFilteredFlag_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetDetailsFilteredFlag, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLegendKey) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_GetLegendKey_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetLegendKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetLegendKey, Fixture, methodGetLegendKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLegendKey) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetLegendKey_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzer.GetLegendKey(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetLegendKey) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetLegendKey_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodGetLegendKeyPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfGetLegendKey = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLegendKey, methodGetLegendKeyPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetLegendKey, Fixture, methodGetLegendKeyPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetLegendKey, parametersOfGetLegendKey, methodGetLegendKeyPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfGetLegendKey);

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
        public void AUT_CostAnalyzer_GetLegendKey_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodGetLegendKeyPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfGetLegendKey = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetLegendKey, parametersOfGetLegendKey, methodGetLegendKeyPrametersTypes);

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
        public void AUT_CostAnalyzer_GetLegendKey_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetLegendKeyPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetLegendKey, Fixture, methodGetLegendKeyPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLegendKeyPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetLegendKey) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetLegendKey_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetLegendKeyPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetLegendKey, Fixture, methodGetLegendKeyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLegendKeyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLegendKey) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetLegendKey_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLegendKey, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLegendKey) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetLegendKey_Static_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (SetShowRemaining) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_SetShowRemaining_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetShowRemainingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetShowRemaining, Fixture, methodSetShowRemainingPrametersTypes);
        }

        #endregion

        #region Method Call : (SetShowRemaining) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetShowRemaining_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzer.SetShowRemaining(Context, sXML, datacache);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (SetShowRemaining) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetShowRemaining_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodSetShowRemainingPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfSetShowRemaining = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetShowRemaining, methodSetShowRemainingPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetShowRemaining, Fixture, methodSetShowRemainingPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetShowRemaining, parametersOfSetShowRemaining, methodSetShowRemainingPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSetShowRemaining.ShouldNotBeNull();
            parametersOfSetShowRemaining.Length.ShouldBe(3);
            methodSetShowRemainingPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetShowRemaining, parametersOfSetShowRemaining, methodSetShowRemainingPrametersTypes));
        }

        #endregion

        #region Method Call : (SetShowRemaining) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetShowRemaining_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodSetShowRemainingPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfSetShowRemaining = { Context, sXML, datacache };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetShowRemaining, methodSetShowRemainingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfSetShowRemaining);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetShowRemaining.ShouldNotBeNull();
            parametersOfSetShowRemaining.Length.ShouldBe(3);
            methodSetShowRemainingPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetShowRemaining) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetShowRemaining_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodSetShowRemainingPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfSetShowRemaining = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetShowRemaining, parametersOfSetShowRemaining, methodSetShowRemainingPrametersTypes);

            // Assert
            parametersOfSetShowRemaining.ShouldNotBeNull();
            parametersOfSetShowRemaining.Length.ShouldBe(3);
            methodSetShowRemainingPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetShowRemaining) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetShowRemaining_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodSetShowRemainingPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetShowRemaining, Fixture, methodSetShowRemainingPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodSetShowRemainingPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SetShowRemaining) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetShowRemaining_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetShowRemainingPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSetShowRemaining, Fixture, methodSetShowRemainingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetShowRemainingPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetShowRemaining) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetShowRemaining_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetShowRemaining, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SetShowRemaining) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SetShowRemaining_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetShowRemaining, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveCostPlanAnalyzerView) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_SaveCostPlanAnalyzerView_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveCostPlanAnalyzerViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSaveCostPlanAnalyzerView, Fixture, methodSaveCostPlanAnalyzerViewPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveCostPlanAnalyzerView) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SaveCostPlanAnalyzerView_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzer.SaveCostPlanAnalyzerView(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SaveCostPlanAnalyzerView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SaveCostPlanAnalyzerView_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodSaveCostPlanAnalyzerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfSaveCostPlanAnalyzerView = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveCostPlanAnalyzerView, methodSaveCostPlanAnalyzerViewPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSaveCostPlanAnalyzerView, Fixture, methodSaveCostPlanAnalyzerViewPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSaveCostPlanAnalyzerView, parametersOfSaveCostPlanAnalyzerView, methodSaveCostPlanAnalyzerViewPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfSaveCostPlanAnalyzerView);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSaveCostPlanAnalyzerView.ShouldNotBeNull();
            parametersOfSaveCostPlanAnalyzerView.Length.ShouldBe(3);
            methodSaveCostPlanAnalyzerViewPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SaveCostPlanAnalyzerView) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SaveCostPlanAnalyzerView_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodSaveCostPlanAnalyzerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfSaveCostPlanAnalyzerView = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSaveCostPlanAnalyzerView, parametersOfSaveCostPlanAnalyzerView, methodSaveCostPlanAnalyzerViewPrametersTypes);

            // Assert
            parametersOfSaveCostPlanAnalyzerView.ShouldNotBeNull();
            parametersOfSaveCostPlanAnalyzerView.Length.ShouldBe(3);
            methodSaveCostPlanAnalyzerViewPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveCostPlanAnalyzerView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SaveCostPlanAnalyzerView_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSaveCostPlanAnalyzerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSaveCostPlanAnalyzerView, Fixture, methodSaveCostPlanAnalyzerViewPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSaveCostPlanAnalyzerViewPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SaveCostPlanAnalyzerView) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SaveCostPlanAnalyzerView_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveCostPlanAnalyzerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSaveCostPlanAnalyzerView, Fixture, methodSaveCostPlanAnalyzerViewPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveCostPlanAnalyzerViewPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveCostPlanAnalyzerView) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SaveCostPlanAnalyzerView_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveCostPlanAnalyzerView, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveCostPlanAnalyzerView) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SaveCostPlanAnalyzerView_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveCostPlanAnalyzerView, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteCostAnalyzerView) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_DeleteCostAnalyzerView_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeleteCostAnalyzerViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodDeleteCostAnalyzerView, Fixture, methodDeleteCostAnalyzerViewPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteCostAnalyzerView) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_DeleteCostAnalyzerView_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzer.DeleteCostAnalyzerView(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteCostAnalyzerView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_DeleteCostAnalyzerView_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodDeleteCostAnalyzerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfDeleteCostAnalyzerView = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteCostAnalyzerView, methodDeleteCostAnalyzerViewPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodDeleteCostAnalyzerView, Fixture, methodDeleteCostAnalyzerViewPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodDeleteCostAnalyzerView, parametersOfDeleteCostAnalyzerView, methodDeleteCostAnalyzerViewPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfDeleteCostAnalyzerView);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDeleteCostAnalyzerView.ShouldNotBeNull();
            parametersOfDeleteCostAnalyzerView.Length.ShouldBe(3);
            methodDeleteCostAnalyzerViewPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteCostAnalyzerView) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_DeleteCostAnalyzerView_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodDeleteCostAnalyzerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfDeleteCostAnalyzerView = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodDeleteCostAnalyzerView, parametersOfDeleteCostAnalyzerView, methodDeleteCostAnalyzerViewPrametersTypes);

            // Assert
            parametersOfDeleteCostAnalyzerView.ShouldNotBeNull();
            parametersOfDeleteCostAnalyzerView.Length.ShouldBe(3);
            methodDeleteCostAnalyzerViewPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteCostAnalyzerView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_DeleteCostAnalyzerView_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDeleteCostAnalyzerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodDeleteCostAnalyzerView, Fixture, methodDeleteCostAnalyzerViewPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDeleteCostAnalyzerViewPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (DeleteCostAnalyzerView) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_DeleteCostAnalyzerView_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteCostAnalyzerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodDeleteCostAnalyzerView, Fixture, methodDeleteCostAnalyzerViewPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteCostAnalyzerViewPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteCostAnalyzerView) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_DeleteCostAnalyzerView_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteCostAnalyzerView, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteCostAnalyzerView) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_DeleteCostAnalyzerView_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteCostAnalyzerView, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenameCostAnalyzerView) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_RenameCostAnalyzerView_Static_Method_Call_Internally(Type[] types)
        {
            var methodRenameCostAnalyzerViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodRenameCostAnalyzerView, Fixture, methodRenameCostAnalyzerViewPrametersTypes);
        }

        #endregion

        #region Method Call : (RenameCostAnalyzerView) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_RenameCostAnalyzerView_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzer.RenameCostAnalyzerView(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RenameCostAnalyzerView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_RenameCostAnalyzerView_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodRenameCostAnalyzerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfRenameCostAnalyzerView = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenameCostAnalyzerView, methodRenameCostAnalyzerViewPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodRenameCostAnalyzerView, Fixture, methodRenameCostAnalyzerViewPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodRenameCostAnalyzerView, parametersOfRenameCostAnalyzerView, methodRenameCostAnalyzerViewPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfRenameCostAnalyzerView);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfRenameCostAnalyzerView.ShouldNotBeNull();
            parametersOfRenameCostAnalyzerView.Length.ShouldBe(3);
            methodRenameCostAnalyzerViewPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RenameCostAnalyzerView) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_RenameCostAnalyzerView_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodRenameCostAnalyzerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfRenameCostAnalyzerView = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodRenameCostAnalyzerView, parametersOfRenameCostAnalyzerView, methodRenameCostAnalyzerViewPrametersTypes);

            // Assert
            parametersOfRenameCostAnalyzerView.ShouldNotBeNull();
            parametersOfRenameCostAnalyzerView.Length.ShouldBe(3);
            methodRenameCostAnalyzerViewPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenameCostAnalyzerView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_RenameCostAnalyzerView_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodRenameCostAnalyzerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodRenameCostAnalyzerView, Fixture, methodRenameCostAnalyzerViewPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRenameCostAnalyzerViewPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (RenameCostAnalyzerView) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_RenameCostAnalyzerView_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenameCostAnalyzerViewPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodRenameCostAnalyzerView, Fixture, methodRenameCostAnalyzerViewPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenameCostAnalyzerViewPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenameCostAnalyzerView) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_RenameCostAnalyzerView_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenameCostAnalyzerView, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenameCostAnalyzerView) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_RenameCostAnalyzerView_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenameCostAnalyzerView, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ApplyCostAnalyzerViewServerSideSettings) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_ApplyCostAnalyzerViewServerSideSettings_Static_Method_Call_Internally(Type[] types)
        {
            var methodApplyCostAnalyzerViewServerSideSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodApplyCostAnalyzerViewServerSideSettings, Fixture, methodApplyCostAnalyzerViewServerSideSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (ApplyCostAnalyzerViewServerSideSettings) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_ApplyCostAnalyzerViewServerSideSettings_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzer.ApplyCostAnalyzerViewServerSideSettings(Context, sXML, datacache);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ApplyCostAnalyzerViewServerSideSettings) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_ApplyCostAnalyzerViewServerSideSettings_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodApplyCostAnalyzerViewServerSideSettingsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfApplyCostAnalyzerViewServerSideSettings = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodApplyCostAnalyzerViewServerSideSettings, methodApplyCostAnalyzerViewServerSideSettingsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodApplyCostAnalyzerViewServerSideSettings, Fixture, methodApplyCostAnalyzerViewServerSideSettingsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodApplyCostAnalyzerViewServerSideSettings, parametersOfApplyCostAnalyzerViewServerSideSettings, methodApplyCostAnalyzerViewServerSideSettingsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfApplyCostAnalyzerViewServerSideSettings.ShouldNotBeNull();
            parametersOfApplyCostAnalyzerViewServerSideSettings.Length.ShouldBe(3);
            methodApplyCostAnalyzerViewServerSideSettingsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodApplyCostAnalyzerViewServerSideSettings, parametersOfApplyCostAnalyzerViewServerSideSettings, methodApplyCostAnalyzerViewServerSideSettingsPrametersTypes));
        }

        #endregion

        #region Method Call : (ApplyCostAnalyzerViewServerSideSettings) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_ApplyCostAnalyzerViewServerSideSettings_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodApplyCostAnalyzerViewServerSideSettingsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfApplyCostAnalyzerViewServerSideSettings = { Context, sXML, datacache };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodApplyCostAnalyzerViewServerSideSettings, methodApplyCostAnalyzerViewServerSideSettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfApplyCostAnalyzerViewServerSideSettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfApplyCostAnalyzerViewServerSideSettings.ShouldNotBeNull();
            parametersOfApplyCostAnalyzerViewServerSideSettings.Length.ShouldBe(3);
            methodApplyCostAnalyzerViewServerSideSettingsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyCostAnalyzerViewServerSideSettings) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_ApplyCostAnalyzerViewServerSideSettings_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodApplyCostAnalyzerViewServerSideSettingsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfApplyCostAnalyzerViewServerSideSettings = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodApplyCostAnalyzerViewServerSideSettings, parametersOfApplyCostAnalyzerViewServerSideSettings, methodApplyCostAnalyzerViewServerSideSettingsPrametersTypes);

            // Assert
            parametersOfApplyCostAnalyzerViewServerSideSettings.ShouldNotBeNull();
            parametersOfApplyCostAnalyzerViewServerSideSettings.Length.ShouldBe(3);
            methodApplyCostAnalyzerViewServerSideSettingsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyCostAnalyzerViewServerSideSettings) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_ApplyCostAnalyzerViewServerSideSettings_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodApplyCostAnalyzerViewServerSideSettingsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodApplyCostAnalyzerViewServerSideSettings, Fixture, methodApplyCostAnalyzerViewServerSideSettingsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodApplyCostAnalyzerViewServerSideSettingsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (ApplyCostAnalyzerViewServerSideSettings) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_ApplyCostAnalyzerViewServerSideSettings_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodApplyCostAnalyzerViewServerSideSettingsPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodApplyCostAnalyzerViewServerSideSettings, Fixture, methodApplyCostAnalyzerViewServerSideSettingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodApplyCostAnalyzerViewServerSideSettingsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ApplyCostAnalyzerViewServerSideSettings) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_ApplyCostAnalyzerViewServerSideSettings_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodApplyCostAnalyzerViewServerSideSettings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ApplyCostAnalyzerViewServerSideSettings) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_ApplyCostAnalyzerViewServerSideSettings_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodApplyCostAnalyzerViewServerSideSettings, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTargetList) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_GetTargetList_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTargetListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetTargetList, Fixture, methodGetTargetListPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTargetList) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTargetList_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzer.GetTargetList(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTargetList) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTargetList_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodGetTargetListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfGetTargetList = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTargetList, methodGetTargetListPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetTargetList, Fixture, methodGetTargetListPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetTargetList, parametersOfGetTargetList, methodGetTargetListPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfGetTargetList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTargetList.ShouldNotBeNull();
            parametersOfGetTargetList.Length.ShouldBe(3);
            methodGetTargetListPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetTargetList) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTargetList_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodGetTargetListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfGetTargetList = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetTargetList, parametersOfGetTargetList, methodGetTargetListPrametersTypes);

            // Assert
            parametersOfGetTargetList.ShouldNotBeNull();
            parametersOfGetTargetList.Length.ShouldBe(3);
            methodGetTargetListPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTargetList) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTargetList_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTargetListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetTargetList, Fixture, methodGetTargetListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTargetListPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetTargetList) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTargetList_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTargetListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetTargetList, Fixture, methodGetTargetListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTargetListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTargetList) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTargetList_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTargetList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTargetList) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTargetList_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTargetList, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_DeleteTarget_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeleteTargetPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodDeleteTarget, Fixture, methodDeleteTargetPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_DeleteTarget_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzer.DeleteTarget(Context, sXML, datacache);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_DeleteTarget_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodDeleteTargetPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfDeleteTarget = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteTarget, methodDeleteTargetPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodDeleteTarget, Fixture, methodDeleteTargetPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodDeleteTarget, parametersOfDeleteTarget, methodDeleteTargetPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteTarget.ShouldNotBeNull();
            parametersOfDeleteTarget.Length.ShouldBe(3);
            methodDeleteTargetPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodDeleteTarget, parametersOfDeleteTarget, methodDeleteTargetPrametersTypes));
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_DeleteTarget_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodDeleteTargetPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfDeleteTarget = { Context, sXML, datacache };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDeleteTarget, methodDeleteTargetPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfDeleteTarget);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDeleteTarget.ShouldNotBeNull();
            parametersOfDeleteTarget.Length.ShouldBe(3);
            methodDeleteTargetPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_DeleteTarget_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodDeleteTargetPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfDeleteTarget = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodDeleteTarget, parametersOfDeleteTarget, methodDeleteTargetPrametersTypes);

            // Assert
            parametersOfDeleteTarget.ShouldNotBeNull();
            parametersOfDeleteTarget.Length.ShouldBe(3);
            methodDeleteTargetPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_DeleteTarget_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodDeleteTargetPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodDeleteTarget, Fixture, methodDeleteTargetPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodDeleteTargetPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_DeleteTarget_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteTargetPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodDeleteTarget, Fixture, methodDeleteTargetPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteTargetPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_DeleteTarget_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteTarget, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_DeleteTarget_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteTarget, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetClientSideCalcData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_GetClientSideCalcData_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetClientSideCalcDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetClientSideCalcData, Fixture, methodGetClientSideCalcDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetClientSideCalcData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetClientSideCalcData_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzer.GetClientSideCalcData(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetClientSideCalcData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetClientSideCalcData_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodGetClientSideCalcDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfGetClientSideCalcData = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetClientSideCalcData, methodGetClientSideCalcDataPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetClientSideCalcData, Fixture, methodGetClientSideCalcDataPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetClientSideCalcData, parametersOfGetClientSideCalcData, methodGetClientSideCalcDataPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfGetClientSideCalcData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetClientSideCalcData.ShouldNotBeNull();
            parametersOfGetClientSideCalcData.Length.ShouldBe(3);
            methodGetClientSideCalcDataPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetClientSideCalcData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetClientSideCalcData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodGetClientSideCalcDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfGetClientSideCalcData = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetClientSideCalcData, parametersOfGetClientSideCalcData, methodGetClientSideCalcDataPrametersTypes);

            // Assert
            parametersOfGetClientSideCalcData.ShouldNotBeNull();
            parametersOfGetClientSideCalcData.Length.ShouldBe(3);
            methodGetClientSideCalcDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetClientSideCalcData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetClientSideCalcData_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetClientSideCalcDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetClientSideCalcData, Fixture, methodGetClientSideCalcDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetClientSideCalcDataPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetClientSideCalcData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetClientSideCalcData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetClientSideCalcDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetClientSideCalcData, Fixture, methodGetClientSideCalcDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetClientSideCalcDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetClientSideCalcData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetClientSideCalcData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetClientSideCalcData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetClientSideCalcData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetClientSideCalcData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetClientSideCalcData, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTargetTotalsData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_GetTargetTotalsData_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTargetTotalsDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetTargetTotalsData, Fixture, methodGetTargetTotalsDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTargetTotalsData) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTargetTotalsData_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzer.GetTargetTotalsData(Context, sXML, datacache);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetTargetTotalsData) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTargetTotalsData_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodGetTargetTotalsDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfGetTargetTotalsData = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTargetTotalsData, methodGetTargetTotalsDataPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetTargetTotalsData, Fixture, methodGetTargetTotalsDataPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetTargetTotalsData, parametersOfGetTargetTotalsData, methodGetTargetTotalsDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetTargetTotalsData.ShouldNotBeNull();
            parametersOfGetTargetTotalsData.Length.ShouldBe(3);
            methodGetTargetTotalsDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetTargetTotalsData, parametersOfGetTargetTotalsData, methodGetTargetTotalsDataPrametersTypes));
        }

        #endregion

        #region Method Call : (GetTargetTotalsData) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTargetTotalsData_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodGetTargetTotalsDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfGetTargetTotalsData = { Context, sXML, datacache };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTargetTotalsData, methodGetTargetTotalsDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfGetTargetTotalsData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTargetTotalsData.ShouldNotBeNull();
            parametersOfGetTargetTotalsData.Length.ShouldBe(3);
            methodGetTargetTotalsDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTargetTotalsData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTargetTotalsData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodGetTargetTotalsDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfGetTargetTotalsData = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetTargetTotalsData, parametersOfGetTargetTotalsData, methodGetTargetTotalsDataPrametersTypes);

            // Assert
            parametersOfGetTargetTotalsData.ShouldNotBeNull();
            parametersOfGetTargetTotalsData.Length.ShouldBe(3);
            methodGetTargetTotalsDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTargetTotalsData) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTargetTotalsData_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetTargetTotalsDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetTargetTotalsData, Fixture, methodGetTargetTotalsDataPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetTargetTotalsDataPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetTargetTotalsData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTargetTotalsData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTargetTotalsDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetTargetTotalsData, Fixture, methodGetTargetTotalsDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTargetTotalsDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTargetTotalsData) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTargetTotalsData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTargetTotalsData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetTargetTotalsData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetTargetTotalsData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTargetTotalsData, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_PrepareTargetData_Static_Method_Call_Internally(Type[] types)
        {
            var methodPrepareTargetDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodPrepareTargetData, Fixture, methodPrepareTargetDataPrametersTypes);
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_PrepareTargetData_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzer.PrepareTargetData(Context, sXML, datacache);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_PrepareTargetData_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodPrepareTargetDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfPrepareTargetData = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPrepareTargetData, methodPrepareTargetDataPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodPrepareTargetData, Fixture, methodPrepareTargetDataPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodPrepareTargetData, parametersOfPrepareTargetData, methodPrepareTargetDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfPrepareTargetData.ShouldNotBeNull();
            parametersOfPrepareTargetData.Length.ShouldBe(3);
            methodPrepareTargetDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodPrepareTargetData, parametersOfPrepareTargetData, methodPrepareTargetDataPrametersTypes));
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_PrepareTargetData_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodPrepareTargetDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfPrepareTargetData = { Context, sXML, datacache };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPrepareTargetData, methodPrepareTargetDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfPrepareTargetData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPrepareTargetData.ShouldNotBeNull();
            parametersOfPrepareTargetData.Length.ShouldBe(3);
            methodPrepareTargetDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_PrepareTargetData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodPrepareTargetDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfPrepareTargetData = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodPrepareTargetData, parametersOfPrepareTargetData, methodPrepareTargetDataPrametersTypes);

            // Assert
            parametersOfPrepareTargetData.ShouldNotBeNull();
            parametersOfPrepareTargetData.Length.ShouldBe(3);
            methodPrepareTargetDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_PrepareTargetData_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodPrepareTargetDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodPrepareTargetData, Fixture, methodPrepareTargetDataPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodPrepareTargetDataPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_PrepareTargetData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPrepareTargetDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodPrepareTargetData, Fixture, methodPrepareTargetDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPrepareTargetDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_PrepareTargetData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPrepareTargetData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_PrepareTargetData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPrepareTargetData, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveTargetData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_SaveTargetData_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveTargetDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSaveTargetData, Fixture, methodSaveTargetDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveTargetData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SaveTargetData_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzer.SaveTargetData(Context, sXML, datacache);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SaveTargetData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SaveTargetData_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodSaveTargetDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfSaveTargetData = { Context, sXML, datacache };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveTargetData, methodSaveTargetDataPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSaveTargetData, Fixture, methodSaveTargetDataPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSaveTargetData, parametersOfSaveTargetData, methodSaveTargetDataPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfSaveTargetData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSaveTargetData.ShouldNotBeNull();
            parametersOfSaveTargetData.Length.ShouldBe(3);
            methodSaveTargetDataPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SaveTargetData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SaveTargetData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var datacache = CreateType<CostAnalyzerDataCache>();
            var methodSaveTargetDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            object[] parametersOfSaveTargetData = { Context, sXML, datacache };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSaveTargetData, parametersOfSaveTargetData, methodSaveTargetDataPrametersTypes);

            // Assert
            parametersOfSaveTargetData.ShouldNotBeNull();
            parametersOfSaveTargetData.Length.ShouldBe(3);
            methodSaveTargetDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveTargetData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SaveTargetData_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSaveTargetDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSaveTargetData, Fixture, methodSaveTargetDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSaveTargetDataPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SaveTargetData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SaveTargetData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveTargetDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(CostAnalyzerDataCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSaveTargetData, Fixture, methodSaveTargetDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveTargetDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveTargetData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SaveTargetData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveTargetData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveTargetData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SaveTargetData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveTargetData, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildResultXML) (Return Type : CStruct) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_BuildResultXML_Static_Method_Call_Internally(Type[] types)
        {
            var methodBuildResultXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodBuildResultXML, Fixture, methodBuildResultXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildResultXML) (Return Type : CStruct) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_BuildResultXML_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var nStatus = CreateType<int>();
            var methodBuildResultXMLPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfBuildResultXML = { sContext, nStatus };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildResultXML, methodBuildResultXMLPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfBuildResultXML);

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
        public void AUT_CostAnalyzer_BuildResultXML_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var nStatus = CreateType<int>();
            var methodBuildResultXMLPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfBuildResultXML = { sContext, nStatus };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<CStruct>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodBuildResultXML, parametersOfBuildResultXML, methodBuildResultXMLPrametersTypes);

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
        public void AUT_CostAnalyzer_BuildResultXML_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildResultXMLPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodBuildResultXML, Fixture, methodBuildResultXMLPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildResultXMLPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (BuildResultXML) (Return Type : CStruct) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_BuildResultXML_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildResultXMLPrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodBuildResultXML, Fixture, methodBuildResultXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildResultXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildResultXML) (Return Type : CStruct) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_BuildResultXML_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildResultXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (BuildResultXML) (Return Type : CStruct) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_BuildResultXML_Static_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_CostAnalyzer_HandleError_Static_Method_Call_Internally(Type[] types)
        {
            var methodHandleErrorPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodHandleError, Fixture, methodHandleErrorPrametersTypes);
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_HandleError_Static_Method_Call_With_No_Exception_Thrown_Test()
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
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfHandleError);

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
        public void AUT_CostAnalyzer_HandleError_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var nStatus = CreateType<int>();
            var sError = CreateType<string>();
            var methodHandleErrorPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };
            object[] parametersOfHandleError = { sContext, nStatus, sError };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodHandleError, parametersOfHandleError, methodHandleErrorPrametersTypes);

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
        public void AUT_CostAnalyzer_HandleError_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodHandleErrorPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodHandleError, Fixture, methodHandleErrorPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodHandleErrorPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_HandleError_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHandleErrorPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodHandleError, Fixture, methodHandleErrorPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodHandleErrorPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_HandleError_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHandleError, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_HandleError_Static_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_CostAnalyzer_HandleException_Static_Method_Call_Internally(Type[] types)
        {
            var methodHandleExceptionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodHandleException, Fixture, methodHandleExceptionPrametersTypes);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_HandleException_Static_Method_Call_With_No_Exception_Thrown_Test()
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
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfHandleException);

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
        public void AUT_CostAnalyzer_HandleException_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var nStatus = CreateType<int>();
            var ex = CreateType<Exception>();
            var sStage = CreateType<string>();
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(Exception), typeof(string) };
            object[] parametersOfHandleException = { sContext, nStatus, ex, sStage };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodHandleException, parametersOfHandleException, methodHandleExceptionPrametersTypes);

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
        public void AUT_CostAnalyzer_HandleException_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(Exception), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodHandleException, Fixture, methodHandleExceptionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodHandleExceptionPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_HandleException_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(Exception), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodHandleException, Fixture, methodHandleExceptionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodHandleExceptionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_HandleException_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHandleException, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_HandleException_Static_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_CostAnalyzer_SaveCachedData_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveCachedDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSaveCachedData, Fixture, methodSaveCachedDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveCachedData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SaveCachedData_Static_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
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
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfSaveCachedData);

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
        public void AUT_CostAnalyzer_SaveCachedData_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sKey = CreateType<string>();
            var value = CreateType<object>();
            var methodSaveCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(object) };
            object[] parametersOfSaveCachedData = { Context, sKey, value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSaveCachedData, parametersOfSaveCachedData, methodSaveCachedDataPrametersTypes);

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
        public void AUT_CostAnalyzer_SaveCachedData_Static_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_CostAnalyzer_SaveCachedData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodSaveCachedData, Fixture, methodSaveCachedDataPrametersTypes);

            // Assert
            methodSaveCachedDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveCachedData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_SaveCachedData_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveCachedData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzer_GetCachedData_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCachedDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetCachedData, Fixture, methodGetCachedDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCachedData_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sKey = CreateType<string>();
            var methodGetCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfGetCachedData = { Context, sKey };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCachedData, methodGetCachedDataPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetCachedData, Fixture, methodGetCachedDataPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<object>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetCachedData, parametersOfGetCachedData, methodGetCachedDataPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerInstanceFixture, parametersOfGetCachedData);

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
        public void AUT_CostAnalyzer_GetCachedData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sKey = CreateType<string>();
            var methodGetCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfGetCachedData = { Context, sKey };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<object>(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetCachedData, parametersOfGetCachedData, methodGetCachedDataPrametersTypes);

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
        public void AUT_CostAnalyzer_GetCachedData_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetCachedData, Fixture, methodGetCachedDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCachedDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCachedData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerInstanceFixture, _costAnalyzerInstanceType, MethodGetCachedData, Fixture, methodGetCachedDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCachedDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCachedData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCachedData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzer_GetCachedData_Static_Method_Call_Parameters_Count_Verification_Test()
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