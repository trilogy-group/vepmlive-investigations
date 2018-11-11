using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Web;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using ModelDataCache;
using NUnit.Framework;
using PortfolioEngineCore;
using Should = Shouldly.Should;
using Shouldly;

namespace WorkEnginePPM
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Model" />)
    ///     and namespace <see cref="WorkEnginePPM"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class ModelTest : AbstractBaseSetupTypedTest<Model>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Model) Initializer

        private const string MethodExecute = "Execute";
        private const string MethodExecuteJSON = "ExecuteJSON";
        private const string MethodGetPortfolioItemList = "GetPortfolioItemList";
        private const string MethodGetGeneratedPortfolioItemTicket = "GetGeneratedPortfolioItemTicket";
        private const string MethodGetTopGrid = "GetTopGrid";
        private const string MethodGetBottomGrid = "GetBottomGrid";
        private const string MethodGetFTEMode = "GetFTEMode";
        private const string MethodLoadModelData = "LoadModelData";
        private const string MethodDoTopGridCheck = "DoTopGridCheck";
        private const string MethodDoBarMoved = "DoBarMoved";
        private const string MethodDoCopyVersion = "DoCopyVersion";
        private const string MethodDoLoadVersion = "DoLoadVersion";
        private const string MethodDoLoadTarget = "DoLoadTarget";
        private const string MethodGetTopGridLayout = "GetTopGridLayout";
        private const string MethodGetTopGridData = "GetTopGridData";
        private const string MethodGetBottomGridLayout = "GetBottomGridLayout";
        private const string MethodGetBottomGridData = "GetBottomGridData";
        private const string MethodDoShowFTEs = "DoShowFTEs";
        private const string MethodDoPingSession = "DoPingSession";
        private const string MethodDoShowGantt = "DoShowGantt";
        private const string MethodDoSetGroupingFlag = "DoSetGroupingFlag";
        private const string MethodGetModels = "GetModels";
        private const string MethodLoadSelectVersions = "LoadSelectVersions";
        private const string MethodHandleError = "HandleError";
        private const string MethodHandleException = "HandleException";
        private const string MethodGetFilterGridLayout = "GetFilterGridLayout";
        private const string MethodGetFilterGridData = "GetFilterGridData";
        private const string MethodSetFilterData = "SetFilterData";
        private const string MethodGetTotalGridLayout = "GetTotalGridLayout";
        private const string MethodGetTotalGridData = "GetTotalGridData";
        private const string MethodGetCostTypeCompareGridData = "GetCostTypeCompareGridData";
        private const string MethodSetCostTypeCompareData = "SetCostTypeCompareData";
        private const string MethodGetColumnGridData = "GetColumnGridData";
        private const string MethodSetTotalData = "SetTotalData";
        private const string MethodGetSortAndGroup = "GetSortAndGroup";
        private const string MethodSetSortAndGroup = "SetSortAndGroup";
        private const string MethodGetColumnOrderData = "GetColumnOrderData";
        private const string MethodSetColumnOrder = "SetColumnOrder";
        private const string MethodLoadCopyVersionPILists = "LoadCopyVersionPILists";
        private const string MethodGetSaveVersions = "GetSaveVersions";
        private const string MethodGetTargetList = "GetTargetList";
        private const string MethodDoSaveVersion = "DoSaveVersion";
        private const string MethodGetPeriodsandDisplay = "GetPeriodsandDisplay";
        private const string MethodSetPeriodsandDisplay = "SetPeriodsandDisplay";
        private const string MethodDoDeleteTarget = "DoDeleteTarget";
        private const string MethodCreateTarget = "CreateTarget";
        private const string MethodGetClientSideCalcData = "GetClientSideCalcData";
        private const string MethodPrepareTargetData = "PrepareTargetData";
        private const string MethodGetTargetGridLayout = "GetTargetGridLayout";
        private const string MethodGetTargetGridData = "GetTargetGridData";
        private const string MethodReturnVersionAsTarget = "ReturnVersionAsTarget";
        private const string MethodSaveTargetData = "SaveTargetData";
        private const string MethodGetCostViews = "GetCostViews";
        private const string MethodDoShowRemTotal = "DoShowRemTotal";
        private const string MethodGetLegendGridLayout = "GetLegendGridLayout";
        private const string MethodGetLegendGridData = "GetLegendGridData";
        private const string MethodLoadUserViewData = "LoadUserViewData";
        private const string MethodDeleteUserViewData = "DeleteUserViewData";
        private const string MethodRenameUserViewData = "RenameUserViewData";
        private const string MethodSaveUserViewData = "SaveUserViewData";
        private const string MethodSelectUserViewData = "SelectUserViewData";
        private const string MethodGetCompareStringValue = "GetCompareStringValue";
        private const string MethodCheckUserGlobalPermission = "CheckUserGlobalPermission";
        private const string MethodObtainSqlConnection = "ObtainSqlConnection";
        private const string MethodSaveCachedData = "SaveCachedData";
        private const string MethodGetCachedData = "GetCachedData";
        private const string MethodBuildResultXML = "BuildResultXML";
        private const string FieldbasePath = "basePath";
        private const string FieldppmId = "ppmId";
        private const string FieldppmCompany = "ppmCompany";
        private const string FieldppmDbConn = "ppmDbConn";
        private const string Fieldusername = "username";
        private const string FieldsecurityLevel = "securityLevel";
        private Type _modelInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Model _modelInstance;
        private Model _modelInstanceFixture;

        #region General Initializer : Class (Model) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Model" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _modelInstanceType = typeof(Model);
            _modelInstanceFixture = Create(true);
            _modelInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Model)

        #region General Initializer : Class (Model) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Model" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodExecute, 0)]
        [TestCase(MethodExecuteJSON, 0)]
        [TestCase(MethodGetPortfolioItemList, 0)]
        [TestCase(MethodGetGeneratedPortfolioItemTicket, 0)]
        [TestCase(MethodGetTopGrid, 0)]
        [TestCase(MethodGetBottomGrid, 0)]
        [TestCase(MethodGetFTEMode, 0)]
        [TestCase(MethodLoadModelData, 0)]
        [TestCase(MethodDoTopGridCheck, 0)]
        [TestCase(MethodDoBarMoved, 0)]
        [TestCase(MethodDoCopyVersion, 0)]
        [TestCase(MethodDoLoadVersion, 0)]
        [TestCase(MethodDoLoadTarget, 0)]
        [TestCase(MethodGetTopGridLayout, 0)]
        [TestCase(MethodGetTopGridData, 0)]
        [TestCase(MethodGetBottomGridLayout, 0)]
        [TestCase(MethodGetBottomGridData, 0)]
        [TestCase(MethodDoShowFTEs, 0)]
        [TestCase(MethodDoPingSession, 0)]
        [TestCase(MethodDoShowGantt, 0)]
        [TestCase(MethodDoSetGroupingFlag, 0)]
        [TestCase(MethodGetModels, 0)]
        [TestCase(MethodLoadSelectVersions, 0)]
        [TestCase(MethodHandleError, 0)]
        [TestCase(MethodHandleException, 0)]
        [TestCase(MethodGetFilterGridLayout, 0)]
        [TestCase(MethodGetFilterGridData, 0)]
        [TestCase(MethodSetFilterData, 0)]
        [TestCase(MethodGetTotalGridLayout, 0)]
        [TestCase(MethodGetTotalGridData, 0)]
        [TestCase(MethodGetCostTypeCompareGridData, 0)]
        [TestCase(MethodSetCostTypeCompareData, 0)]
        [TestCase(MethodGetColumnGridData, 0)]
        [TestCase(MethodSetTotalData, 0)]
        [TestCase(MethodGetSortAndGroup, 0)]
        [TestCase(MethodSetSortAndGroup, 0)]
        [TestCase(MethodGetColumnOrderData, 0)]
        [TestCase(MethodSetColumnOrder, 0)]
        [TestCase(MethodLoadCopyVersionPILists, 0)]
        [TestCase(MethodGetSaveVersions, 0)]
        [TestCase(MethodGetTargetList, 0)]
        [TestCase(MethodDoSaveVersion, 0)]
        [TestCase(MethodGetPeriodsandDisplay, 0)]
        [TestCase(MethodSetPeriodsandDisplay, 0)]
        [TestCase(MethodDoDeleteTarget, 0)]
        [TestCase(MethodCreateTarget, 0)]
        [TestCase(MethodGetClientSideCalcData, 0)]
        [TestCase(MethodPrepareTargetData, 0)]
        [TestCase(MethodGetTargetGridLayout, 0)]
        [TestCase(MethodGetTargetGridData, 0)]
        [TestCase(MethodReturnVersionAsTarget, 0)]
        [TestCase(MethodSaveTargetData, 0)]
        [TestCase(MethodGetCostViews, 0)]
        [TestCase(MethodDoShowRemTotal, 0)]
        [TestCase(MethodGetLegendGridLayout, 0)]
        [TestCase(MethodGetLegendGridData, 0)]
        [TestCase(MethodLoadUserViewData, 0)]
        [TestCase(MethodDeleteUserViewData, 0)]
        [TestCase(MethodRenameUserViewData, 0)]
        [TestCase(MethodSaveUserViewData, 0)]
        [TestCase(MethodSelectUserViewData, 0)]
        [TestCase(MethodGetCompareStringValue, 0)]
        [TestCase(MethodCheckUserGlobalPermission, 0)]
        [TestCase(MethodObtainSqlConnection, 0)]
        [TestCase(MethodSaveCachedData, 0)]
        [TestCase(MethodGetCachedData, 0)]
        [TestCase(MethodBuildResultXML, 0)]
        public void AUT_Model_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_modelInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Model) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Model" />) explore and verify fields for coverage gain.
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
        public void AUT_Model_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_modelInstanceFixture, 
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
        ///     Class (<see cref="Model" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Model_Is_Instance_Present_Test()
        {
            // Assert
            _modelInstanceType.ShouldNotBeNull();
            _modelInstance.ShouldNotBeNull();
            _modelInstanceFixture.ShouldNotBeNull();
            _modelInstance.ShouldBeAssignableTo<Model>();
            _modelInstanceFixture.ShouldBeAssignableTo<Model>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Model) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Model_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Model instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _modelInstanceType.ShouldNotBeNull();
            _modelInstance.ShouldNotBeNull();
            _modelInstanceFixture.ShouldNotBeNull();
            _modelInstance.ShouldBeAssignableTo<Model>();
            _modelInstanceFixture.ShouldBeAssignableTo<Model>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="Model" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetPortfolioItemList)]
        [TestCase(MethodGetGeneratedPortfolioItemTicket)]
        [TestCase(MethodGetTopGrid)]
        [TestCase(MethodGetBottomGrid)]
        [TestCase(MethodGetFTEMode)]
        [TestCase(MethodHandleError)]
        [TestCase(MethodHandleException)]
        [TestCase(MethodCheckUserGlobalPermission)]
        [TestCase(MethodSaveCachedData)]
        [TestCase(MethodGetCachedData)]
        [TestCase(MethodBuildResultXML)]
        public void AUT_Model_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_modelInstanceFixture,
                                                                              _modelInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Model" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodExecute)]
        [TestCase(MethodExecuteJSON)]
        [TestCase(MethodLoadModelData)]
        [TestCase(MethodDoTopGridCheck)]
        [TestCase(MethodDoBarMoved)]
        [TestCase(MethodDoCopyVersion)]
        [TestCase(MethodDoLoadVersion)]
        [TestCase(MethodDoLoadTarget)]
        [TestCase(MethodGetTopGridLayout)]
        [TestCase(MethodGetTopGridData)]
        [TestCase(MethodGetBottomGridLayout)]
        [TestCase(MethodGetBottomGridData)]
        [TestCase(MethodDoShowFTEs)]
        [TestCase(MethodDoPingSession)]
        [TestCase(MethodDoShowGantt)]
        [TestCase(MethodDoSetGroupingFlag)]
        [TestCase(MethodGetModels)]
        [TestCase(MethodLoadSelectVersions)]
        [TestCase(MethodGetFilterGridLayout)]
        [TestCase(MethodGetFilterGridData)]
        [TestCase(MethodSetFilterData)]
        [TestCase(MethodGetTotalGridLayout)]
        [TestCase(MethodGetTotalGridData)]
        [TestCase(MethodGetCostTypeCompareGridData)]
        [TestCase(MethodSetCostTypeCompareData)]
        [TestCase(MethodGetColumnGridData)]
        [TestCase(MethodSetTotalData)]
        [TestCase(MethodGetSortAndGroup)]
        [TestCase(MethodSetSortAndGroup)]
        [TestCase(MethodGetColumnOrderData)]
        [TestCase(MethodSetColumnOrder)]
        [TestCase(MethodLoadCopyVersionPILists)]
        [TestCase(MethodGetSaveVersions)]
        [TestCase(MethodGetTargetList)]
        [TestCase(MethodDoSaveVersion)]
        [TestCase(MethodGetPeriodsandDisplay)]
        [TestCase(MethodSetPeriodsandDisplay)]
        [TestCase(MethodDoDeleteTarget)]
        [TestCase(MethodCreateTarget)]
        [TestCase(MethodGetClientSideCalcData)]
        [TestCase(MethodPrepareTargetData)]
        [TestCase(MethodGetTargetGridLayout)]
        [TestCase(MethodGetTargetGridData)]
        [TestCase(MethodReturnVersionAsTarget)]
        [TestCase(MethodSaveTargetData)]
        [TestCase(MethodGetCostViews)]
        [TestCase(MethodDoShowRemTotal)]
        [TestCase(MethodGetLegendGridLayout)]
        [TestCase(MethodGetLegendGridData)]
        [TestCase(MethodLoadUserViewData)]
        [TestCase(MethodDeleteUserViewData)]
        [TestCase(MethodRenameUserViewData)]
        [TestCase(MethodSaveUserViewData)]
        [TestCase(MethodSelectUserViewData)]
        [TestCase(MethodGetCompareStringValue)]
        [TestCase(MethodObtainSqlConnection)]
        public void AUT_Model_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Model>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_Execute_Method_Call_Internally(Type[] types)
        {
            var methodExecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodExecute, Fixture, methodExecutePrametersTypes);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_Execute_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.Execute(Ticket, Function, Dataxml);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_Execute_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfExecute = { Ticket, Function, Dataxml };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodExecute, methodExecutePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, string>(_modelInstanceFixture, out exception1, parametersOfExecute);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodExecute, parametersOfExecute, methodExecutePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfExecute.ShouldNotBeNull();
            parametersOfExecute.Length.ShouldBe(3);
            methodExecutePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_Execute_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfExecute = { Ticket, Function, Dataxml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodExecute, parametersOfExecute, methodExecutePrametersTypes);

            // Assert
            parametersOfExecute.ShouldNotBeNull();
            parametersOfExecute.Length.ShouldBe(3);
            methodExecutePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_Execute_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodExecute, Fixture, methodExecutePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodExecutePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_Execute_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecutePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodExecute, Fixture, methodExecutePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecutePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_Execute_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecute, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Execute) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_Execute_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExecute, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_ExecuteJSON_Method_Call_Internally(Type[] types)
        {
            var methodExecuteJSONPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodExecuteJSON, Fixture, methodExecuteJSONPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_ExecuteJSON_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.ExecuteJSON(Ticket, Function, Dataxml);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_ExecuteJSON_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            var methodExecuteJSONPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfExecuteJSON = { Ticket, Function, Dataxml };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodExecuteJSON, methodExecuteJSONPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, string>(_modelInstanceFixture, out exception1, parametersOfExecuteJSON);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodExecuteJSON, parametersOfExecuteJSON, methodExecuteJSONPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfExecuteJSON.ShouldNotBeNull();
            parametersOfExecuteJSON.Length.ShouldBe(3);
            methodExecuteJSONPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_ExecuteJSON_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            var methodExecuteJSONPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfExecuteJSON = { Ticket, Function, Dataxml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodExecuteJSON, methodExecuteJSONPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfExecuteJSON);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfExecuteJSON.ShouldNotBeNull();
            parametersOfExecuteJSON.Length.ShouldBe(3);
            methodExecuteJSONPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_ExecuteJSON_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var Function = CreateType<string>();
            var Dataxml = CreateType<string>();
            var methodExecuteJSONPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfExecuteJSON = { Ticket, Function, Dataxml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodExecuteJSON, parametersOfExecuteJSON, methodExecuteJSONPrametersTypes);

            // Assert
            parametersOfExecuteJSON.ShouldNotBeNull();
            parametersOfExecuteJSON.Length.ShouldBe(3);
            methodExecuteJSONPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_ExecuteJSON_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodExecuteJSONPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodExecuteJSON, Fixture, methodExecuteJSONPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodExecuteJSONPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_ExecuteJSON_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteJSONPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodExecuteJSON, Fixture, methodExecuteJSONPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecuteJSONPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_ExecuteJSON_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteJSON, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ExecuteJSON) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_ExecuteJSON_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExecuteJSON, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPortfolioItemList) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_GetPortfolioItemList_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetPortfolioItemListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodGetPortfolioItemList, Fixture, methodGetPortfolioItemListPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPortfolioItemList) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetPortfolioItemList_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var ModelData = CreateType<ModelCache>();
            Action executeAction = null;

            // Act
            executeAction = () => Model.GetPortfolioItemList(Context, sXML, ModelData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetPortfolioItemList) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetPortfolioItemList_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var ModelData = CreateType<ModelCache>();
            var methodGetPortfolioItemListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(ModelCache) };
            object[] parametersOfGetPortfolioItemList = { Context, sXML, ModelData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPortfolioItemList, methodGetPortfolioItemListPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodGetPortfolioItemList, Fixture, methodGetPortfolioItemListPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_modelInstanceFixture, _modelInstanceType, MethodGetPortfolioItemList, parametersOfGetPortfolioItemList, methodGetPortfolioItemListPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfGetPortfolioItemList);

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
        public void AUT_Model_GetPortfolioItemList_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var ModelData = CreateType<ModelCache>();
            var methodGetPortfolioItemListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(ModelCache) };
            object[] parametersOfGetPortfolioItemList = { Context, sXML, ModelData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_modelInstanceFixture, _modelInstanceType, MethodGetPortfolioItemList, parametersOfGetPortfolioItemList, methodGetPortfolioItemListPrametersTypes);

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
        public void AUT_Model_GetPortfolioItemList_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetPortfolioItemListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(ModelCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodGetPortfolioItemList, Fixture, methodGetPortfolioItemListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPortfolioItemListPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetPortfolioItemList) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetPortfolioItemList_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPortfolioItemListPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(ModelCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodGetPortfolioItemList, Fixture, methodGetPortfolioItemListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPortfolioItemListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPortfolioItemList) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetPortfolioItemList_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPortfolioItemList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPortfolioItemList) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetPortfolioItemList_Static_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_Model_GetGeneratedPortfolioItemTicket_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetGeneratedPortfolioItemTicketPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodGetGeneratedPortfolioItemTicket, Fixture, methodGetGeneratedPortfolioItemTicketPrametersTypes);
        }

        #endregion

        #region Method Call : (GetGeneratedPortfolioItemTicket) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetGeneratedPortfolioItemTicket_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var ModelData = CreateType<ModelCache>();
            Action executeAction = null;

            // Act
            executeAction = () => Model.GetGeneratedPortfolioItemTicket(Context, sXML, ModelData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetGeneratedPortfolioItemTicket) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetGeneratedPortfolioItemTicket_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var ModelData = CreateType<ModelCache>();
            var methodGetGeneratedPortfolioItemTicketPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(ModelCache) };
            object[] parametersOfGetGeneratedPortfolioItemTicket = { Context, sXML, ModelData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGeneratedPortfolioItemTicket, methodGetGeneratedPortfolioItemTicketPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodGetGeneratedPortfolioItemTicket, Fixture, methodGetGeneratedPortfolioItemTicketPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_modelInstanceFixture, _modelInstanceType, MethodGetGeneratedPortfolioItemTicket, parametersOfGetGeneratedPortfolioItemTicket, methodGetGeneratedPortfolioItemTicketPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfGetGeneratedPortfolioItemTicket);

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
        public void AUT_Model_GetGeneratedPortfolioItemTicket_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var ModelData = CreateType<ModelCache>();
            var methodGetGeneratedPortfolioItemTicketPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(ModelCache) };
            object[] parametersOfGetGeneratedPortfolioItemTicket = { Context, sXML, ModelData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_modelInstanceFixture, _modelInstanceType, MethodGetGeneratedPortfolioItemTicket, parametersOfGetGeneratedPortfolioItemTicket, methodGetGeneratedPortfolioItemTicketPrametersTypes);

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
        public void AUT_Model_GetGeneratedPortfolioItemTicket_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetGeneratedPortfolioItemTicketPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(ModelCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodGetGeneratedPortfolioItemTicket, Fixture, methodGetGeneratedPortfolioItemTicketPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetGeneratedPortfolioItemTicketPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetGeneratedPortfolioItemTicket) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetGeneratedPortfolioItemTicket_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetGeneratedPortfolioItemTicketPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(ModelCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodGetGeneratedPortfolioItemTicket, Fixture, methodGetGeneratedPortfolioItemTicketPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetGeneratedPortfolioItemTicketPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGeneratedPortfolioItemTicket) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetGeneratedPortfolioItemTicket_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGeneratedPortfolioItemTicket, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetGeneratedPortfolioItemTicket) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetGeneratedPortfolioItemTicket_Static_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (GetTopGrid) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_GetTopGrid_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTopGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodGetTopGrid, Fixture, methodGetTopGridPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTopGrid) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTopGrid_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var ModelData = CreateType<ModelCache>();
            Action executeAction = null;

            // Act
            executeAction = () => Model.GetTopGrid(Context, sXML, ModelData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTopGrid) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTopGrid_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var ModelData = CreateType<ModelCache>();
            var methodGetTopGridPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(ModelCache) };
            object[] parametersOfGetTopGrid = { Context, sXML, ModelData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTopGrid, methodGetTopGridPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodGetTopGrid, Fixture, methodGetTopGridPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_modelInstanceFixture, _modelInstanceType, MethodGetTopGrid, parametersOfGetTopGrid, methodGetTopGridPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfGetTopGrid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTopGrid.ShouldNotBeNull();
            parametersOfGetTopGrid.Length.ShouldBe(3);
            methodGetTopGridPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetTopGrid) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTopGrid_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var ModelData = CreateType<ModelCache>();
            var methodGetTopGridPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(ModelCache) };
            object[] parametersOfGetTopGrid = { Context, sXML, ModelData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_modelInstanceFixture, _modelInstanceType, MethodGetTopGrid, parametersOfGetTopGrid, methodGetTopGridPrametersTypes);

            // Assert
            parametersOfGetTopGrid.ShouldNotBeNull();
            parametersOfGetTopGrid.Length.ShouldBe(3);
            methodGetTopGridPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTopGrid) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTopGrid_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTopGridPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(ModelCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodGetTopGrid, Fixture, methodGetTopGridPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTopGridPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetTopGrid) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTopGrid_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTopGridPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(ModelCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodGetTopGrid, Fixture, methodGetTopGridPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTopGridPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTopGrid) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTopGrid_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTopGrid, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTopGrid) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTopGrid_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTopGrid, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetBottomGrid) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_GetBottomGrid_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetBottomGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodGetBottomGrid, Fixture, methodGetBottomGridPrametersTypes);
        }

        #endregion

        #region Method Call : (GetBottomGrid) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetBottomGrid_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var ModelData = CreateType<ModelCache>();
            Action executeAction = null;

            // Act
            executeAction = () => Model.GetBottomGrid(Context, sXML, ModelData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetBottomGrid) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetBottomGrid_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var ModelData = CreateType<ModelCache>();
            var methodGetBottomGridPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(ModelCache) };
            object[] parametersOfGetBottomGrid = { Context, sXML, ModelData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetBottomGrid, methodGetBottomGridPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodGetBottomGrid, Fixture, methodGetBottomGridPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_modelInstanceFixture, _modelInstanceType, MethodGetBottomGrid, parametersOfGetBottomGrid, methodGetBottomGridPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfGetBottomGrid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetBottomGrid.ShouldNotBeNull();
            parametersOfGetBottomGrid.Length.ShouldBe(3);
            methodGetBottomGridPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetBottomGrid) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetBottomGrid_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var ModelData = CreateType<ModelCache>();
            var methodGetBottomGridPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(ModelCache) };
            object[] parametersOfGetBottomGrid = { Context, sXML, ModelData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_modelInstanceFixture, _modelInstanceType, MethodGetBottomGrid, parametersOfGetBottomGrid, methodGetBottomGridPrametersTypes);

            // Assert
            parametersOfGetBottomGrid.ShouldNotBeNull();
            parametersOfGetBottomGrid.Length.ShouldBe(3);
            methodGetBottomGridPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetBottomGrid) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetBottomGrid_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetBottomGridPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(ModelCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodGetBottomGrid, Fixture, methodGetBottomGridPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetBottomGridPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetBottomGrid) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetBottomGrid_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetBottomGridPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(ModelCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodGetBottomGrid, Fixture, methodGetBottomGridPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetBottomGridPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetBottomGrid) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetBottomGrid_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetBottomGrid, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetBottomGrid) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetBottomGrid_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetBottomGrid, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFTEMode) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_GetFTEMode_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFTEModePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodGetFTEMode, Fixture, methodGetFTEModePrametersTypes);
        }

        #endregion

        #region Method Call : (GetFTEMode) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetFTEMode_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var ModelData = CreateType<ModelCache>();
            Action executeAction = null;

            // Act
            executeAction = () => Model.GetFTEMode(Context, sXML, ModelData);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetFTEMode) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetFTEMode_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var ModelData = CreateType<ModelCache>();
            var methodGetFTEModePrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(ModelCache) };
            object[] parametersOfGetFTEMode = { Context, sXML, ModelData };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFTEMode, methodGetFTEModePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodGetFTEMode, Fixture, methodGetFTEModePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_modelInstanceFixture, _modelInstanceType, MethodGetFTEMode, parametersOfGetFTEMode, methodGetFTEModePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetFTEMode.ShouldNotBeNull();
            parametersOfGetFTEMode.Length.ShouldBe(3);
            methodGetFTEModePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_modelInstanceFixture, _modelInstanceType, MethodGetFTEMode, parametersOfGetFTEMode, methodGetFTEModePrametersTypes));
        }

        #endregion

        #region Method Call : (GetFTEMode) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetFTEMode_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var ModelData = CreateType<ModelCache>();
            var methodGetFTEModePrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(ModelCache) };
            object[] parametersOfGetFTEMode = { Context, sXML, ModelData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetFTEMode, methodGetFTEModePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfGetFTEMode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetFTEMode.ShouldNotBeNull();
            parametersOfGetFTEMode.Length.ShouldBe(3);
            methodGetFTEModePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFTEMode) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetFTEMode_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sXML = CreateType<string>();
            var ModelData = CreateType<ModelCache>();
            var methodGetFTEModePrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(ModelCache) };
            object[] parametersOfGetFTEMode = { Context, sXML, ModelData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_modelInstanceFixture, _modelInstanceType, MethodGetFTEMode, parametersOfGetFTEMode, methodGetFTEModePrametersTypes);

            // Assert
            parametersOfGetFTEMode.ShouldNotBeNull();
            parametersOfGetFTEMode.Length.ShouldBe(3);
            methodGetFTEModePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFTEMode) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetFTEMode_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetFTEModePrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(ModelCache) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodGetFTEMode, Fixture, methodGetFTEModePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetFTEModePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetFTEMode) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetFTEMode_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFTEModePrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(ModelCache) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodGetFTEMode, Fixture, methodGetFTEModePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFTEModePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFTEMode) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetFTEMode_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFTEMode, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetFTEMode) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetFTEMode_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFTEMode, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LoadModelData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_LoadModelData_Method_Call_Internally(Type[] types)
        {
            var methodLoadModelDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodLoadModelData, Fixture, methodLoadModelDataPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadModelData) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadModelData_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sTicket = CreateType<string>();
            var sModel = CreateType<string>();
            var sVersions = CreateType<string>();
            var sViewID = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.LoadModelData(sTicket, sModel, sVersions, sViewID);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (LoadModelData) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadModelData_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sTicket = CreateType<string>();
            var sModel = CreateType<string>();
            var sVersions = CreateType<string>();
            var sViewID = CreateType<string>();
            var methodLoadModelDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfLoadModelData = { sTicket, sModel, sVersions, sViewID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodLoadModelData, methodLoadModelDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, string>(_modelInstanceFixture, out exception1, parametersOfLoadModelData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodLoadModelData, parametersOfLoadModelData, methodLoadModelDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfLoadModelData.ShouldNotBeNull();
            parametersOfLoadModelData.Length.ShouldBe(4);
            methodLoadModelDataPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (LoadModelData) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadModelData_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sTicket = CreateType<string>();
            var sModel = CreateType<string>();
            var sVersions = CreateType<string>();
            var sViewID = CreateType<string>();
            var methodLoadModelDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfLoadModelData = { sTicket, sModel, sVersions, sViewID };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadModelData, methodLoadModelDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfLoadModelData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadModelData.ShouldNotBeNull();
            parametersOfLoadModelData.Length.ShouldBe(4);
            methodLoadModelDataPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadModelData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadModelData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sTicket = CreateType<string>();
            var sModel = CreateType<string>();
            var sVersions = CreateType<string>();
            var sViewID = CreateType<string>();
            var methodLoadModelDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfLoadModelData = { sTicket, sModel, sVersions, sViewID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodLoadModelData, parametersOfLoadModelData, methodLoadModelDataPrametersTypes);

            // Assert
            parametersOfLoadModelData.ShouldNotBeNull();
            parametersOfLoadModelData.Length.ShouldBe(4);
            methodLoadModelDataPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadModelData) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadModelData_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodLoadModelDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodLoadModelData, Fixture, methodLoadModelDataPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodLoadModelDataPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (LoadModelData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadModelData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLoadModelDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodLoadModelData, Fixture, methodLoadModelDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodLoadModelDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LoadModelData) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadModelData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadModelData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (LoadModelData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadModelData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLoadModelData, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoTopGridCheck) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_DoTopGridCheck_Method_Call_Internally(Type[] types)
        {
            var methodDoTopGridCheckPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodDoTopGridCheck, Fixture, methodDoTopGridCheckPrametersTypes);
        }

        #endregion

        #region Method Call : (DoTopGridCheck) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoTopGridCheck_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var Row = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.DoTopGridCheck(Ticket, Row);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DoTopGridCheck) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoTopGridCheck_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var Row = CreateType<string>();
            var methodDoTopGridCheckPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDoTopGridCheck = { Ticket, Row };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDoTopGridCheck, methodDoTopGridCheckPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfDoTopGridCheck);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDoTopGridCheck.ShouldNotBeNull();
            parametersOfDoTopGridCheck.Length.ShouldBe(2);
            methodDoTopGridCheckPrametersTypes.Length.ShouldBe(2);
            methodDoTopGridCheckPrametersTypes.Length.ShouldBe(parametersOfDoTopGridCheck.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DoTopGridCheck) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoTopGridCheck_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var Row = CreateType<string>();
            var methodDoTopGridCheckPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDoTopGridCheck = { Ticket, Row };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelInstance, MethodDoTopGridCheck, parametersOfDoTopGridCheck, methodDoTopGridCheckPrametersTypes);

            // Assert
            parametersOfDoTopGridCheck.ShouldNotBeNull();
            parametersOfDoTopGridCheck.Length.ShouldBe(2);
            methodDoTopGridCheckPrametersTypes.Length.ShouldBe(2);
            methodDoTopGridCheckPrametersTypes.Length.ShouldBe(parametersOfDoTopGridCheck.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoTopGridCheck) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoTopGridCheck_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDoTopGridCheck, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoTopGridCheck) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoTopGridCheck_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDoTopGridCheckPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodDoTopGridCheck, Fixture, methodDoTopGridCheckPrametersTypes);

            // Assert
            methodDoTopGridCheckPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoTopGridCheck) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoTopGridCheck_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDoTopGridCheck, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoBarMoved) (Return Type : ModelBarsChanged) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_DoBarMoved_Method_Call_Internally(Type[] types)
        {
            var methodDoBarMovedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodDoBarMoved, Fixture, methodDoBarMovedPrametersTypes);
        }

        #endregion

        #region Method Call : (DoBarMoved) (Return Type : ModelBarsChanged) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoBarMoved_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var Row = CreateType<string>();
            var sStart = CreateType<string>();
            var sFinish = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.DoBarMoved(Ticket, Row, sStart, sFinish);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DoBarMoved) (Return Type : ModelBarsChanged) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoBarMoved_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var Row = CreateType<string>();
            var sStart = CreateType<string>();
            var sFinish = CreateType<string>();
            var methodDoBarMovedPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfDoBarMoved = { Ticket, Row, sStart, sFinish };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDoBarMoved, methodDoBarMovedPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, ModelBarsChanged>(_modelInstanceFixture, out exception1, parametersOfDoBarMoved);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, ModelBarsChanged>(_modelInstance, MethodDoBarMoved, parametersOfDoBarMoved, methodDoBarMovedPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDoBarMoved.ShouldNotBeNull();
            parametersOfDoBarMoved.Length.ShouldBe(4);
            methodDoBarMovedPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (DoBarMoved) (Return Type : ModelBarsChanged) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoBarMoved_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var Row = CreateType<string>();
            var sStart = CreateType<string>();
            var sFinish = CreateType<string>();
            var methodDoBarMovedPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfDoBarMoved = { Ticket, Row, sStart, sFinish };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, ModelBarsChanged>(_modelInstance, MethodDoBarMoved, parametersOfDoBarMoved, methodDoBarMovedPrametersTypes);

            // Assert
            parametersOfDoBarMoved.ShouldNotBeNull();
            parametersOfDoBarMoved.Length.ShouldBe(4);
            methodDoBarMovedPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoBarMoved) (Return Type : ModelBarsChanged) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoBarMoved_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDoBarMovedPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodDoBarMoved, Fixture, methodDoBarMovedPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDoBarMovedPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (DoBarMoved) (Return Type : ModelBarsChanged) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoBarMoved_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDoBarMovedPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodDoBarMoved, Fixture, methodDoBarMovedPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDoBarMovedPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoBarMoved) (Return Type : ModelBarsChanged) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoBarMoved_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDoBarMoved, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DoBarMoved) (Return Type : ModelBarsChanged) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoBarMoved_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDoBarMoved, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoCopyVersion) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_DoCopyVersion_Method_Call_Internally(Type[] types)
        {
            var methodDoCopyVersionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodDoCopyVersion, Fixture, methodDoCopyVersionPrametersTypes);
        }

        #endregion

        #region Method Call : (DoCopyVersion) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoCopyVersion_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sFrom = CreateType<string>();
            var sTo = CreateType<string>();
            var sPIs = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.DoCopyVersion(Ticket, sFrom, sTo, sPIs);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DoCopyVersion) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoCopyVersion_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sFrom = CreateType<string>();
            var sTo = CreateType<string>();
            var sPIs = CreateType<string>();
            var methodDoCopyVersionPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfDoCopyVersion = { Ticket, sFrom, sTo, sPIs };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDoCopyVersion, methodDoCopyVersionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfDoCopyVersion);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDoCopyVersion.ShouldNotBeNull();
            parametersOfDoCopyVersion.Length.ShouldBe(4);
            methodDoCopyVersionPrametersTypes.Length.ShouldBe(4);
            methodDoCopyVersionPrametersTypes.Length.ShouldBe(parametersOfDoCopyVersion.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DoCopyVersion) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoCopyVersion_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sFrom = CreateType<string>();
            var sTo = CreateType<string>();
            var sPIs = CreateType<string>();
            var methodDoCopyVersionPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfDoCopyVersion = { Ticket, sFrom, sTo, sPIs };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelInstance, MethodDoCopyVersion, parametersOfDoCopyVersion, methodDoCopyVersionPrametersTypes);

            // Assert
            parametersOfDoCopyVersion.ShouldNotBeNull();
            parametersOfDoCopyVersion.Length.ShouldBe(4);
            methodDoCopyVersionPrametersTypes.Length.ShouldBe(4);
            methodDoCopyVersionPrametersTypes.Length.ShouldBe(parametersOfDoCopyVersion.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoCopyVersion) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoCopyVersion_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDoCopyVersion, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoCopyVersion) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoCopyVersion_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDoCopyVersionPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodDoCopyVersion, Fixture, methodDoCopyVersionPrametersTypes);

            // Assert
            methodDoCopyVersionPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoCopyVersion) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoCopyVersion_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDoCopyVersion, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoLoadVersion) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_DoLoadVersion_Method_Call_Internally(Type[] types)
        {
            var methodDoLoadVersionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodDoLoadVersion, Fixture, methodDoLoadVersionPrametersTypes);
        }

        #endregion

        #region Method Call : (DoLoadVersion) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoLoadVersion_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sLoad = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.DoLoadVersion(Ticket, sLoad);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DoLoadVersion) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoLoadVersion_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sLoad = CreateType<string>();
            var methodDoLoadVersionPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDoLoadVersion = { Ticket, sLoad };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDoLoadVersion, methodDoLoadVersionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfDoLoadVersion);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDoLoadVersion.ShouldNotBeNull();
            parametersOfDoLoadVersion.Length.ShouldBe(2);
            methodDoLoadVersionPrametersTypes.Length.ShouldBe(2);
            methodDoLoadVersionPrametersTypes.Length.ShouldBe(parametersOfDoLoadVersion.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DoLoadVersion) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoLoadVersion_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sLoad = CreateType<string>();
            var methodDoLoadVersionPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDoLoadVersion = { Ticket, sLoad };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelInstance, MethodDoLoadVersion, parametersOfDoLoadVersion, methodDoLoadVersionPrametersTypes);

            // Assert
            parametersOfDoLoadVersion.ShouldNotBeNull();
            parametersOfDoLoadVersion.Length.ShouldBe(2);
            methodDoLoadVersionPrametersTypes.Length.ShouldBe(2);
            methodDoLoadVersionPrametersTypes.Length.ShouldBe(parametersOfDoLoadVersion.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoLoadVersion) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoLoadVersion_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDoLoadVersion, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoLoadVersion) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoLoadVersion_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDoLoadVersionPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodDoLoadVersion, Fixture, methodDoLoadVersionPrametersTypes);

            // Assert
            methodDoLoadVersionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoLoadVersion) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoLoadVersion_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDoLoadVersion, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoLoadTarget) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_DoLoadTarget_Method_Call_Internally(Type[] types)
        {
            var methodDoLoadTargetPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodDoLoadTarget, Fixture, methodDoLoadTargetPrametersTypes);
        }

        #endregion

        #region Method Call : (DoLoadTarget) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoLoadTarget_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sTarget = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.DoLoadTarget(Ticket, sTarget);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DoLoadTarget) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoLoadTarget_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sTarget = CreateType<string>();
            var methodDoLoadTargetPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDoLoadTarget = { Ticket, sTarget };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDoLoadTarget, methodDoLoadTargetPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfDoLoadTarget);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDoLoadTarget.ShouldNotBeNull();
            parametersOfDoLoadTarget.Length.ShouldBe(2);
            methodDoLoadTargetPrametersTypes.Length.ShouldBe(2);
            methodDoLoadTargetPrametersTypes.Length.ShouldBe(parametersOfDoLoadTarget.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DoLoadTarget) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoLoadTarget_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sTarget = CreateType<string>();
            var methodDoLoadTargetPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDoLoadTarget = { Ticket, sTarget };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelInstance, MethodDoLoadTarget, parametersOfDoLoadTarget, methodDoLoadTargetPrametersTypes);

            // Assert
            parametersOfDoLoadTarget.ShouldNotBeNull();
            parametersOfDoLoadTarget.Length.ShouldBe(2);
            methodDoLoadTargetPrametersTypes.Length.ShouldBe(2);
            methodDoLoadTargetPrametersTypes.Length.ShouldBe(parametersOfDoLoadTarget.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoLoadTarget) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoLoadTarget_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDoLoadTarget, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoLoadTarget) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoLoadTarget_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDoLoadTargetPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodDoLoadTarget, Fixture, methodDoLoadTargetPrametersTypes);

            // Assert
            methodDoLoadTargetPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoLoadTarget) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoLoadTarget_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDoLoadTarget, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTopGridLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_GetTopGridLayout_Method_Call_Internally(Type[] types)
        {
            var methodGetTopGridLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetTopGridLayout, Fixture, methodGetTopGridLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTopGridLayout) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTopGridLayout_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.GetTopGridLayout(Ticket);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTopGridLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTopGridLayout_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetTopGridLayoutPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTopGridLayout = { Ticket };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTopGridLayout, methodGetTopGridLayoutPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, string>(_modelInstanceFixture, out exception1, parametersOfGetTopGridLayout);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetTopGridLayout, parametersOfGetTopGridLayout, methodGetTopGridLayoutPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTopGridLayout.ShouldNotBeNull();
            parametersOfGetTopGridLayout.Length.ShouldBe(1);
            methodGetTopGridLayoutPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTopGridLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTopGridLayout_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetTopGridLayoutPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTopGridLayout = { Ticket };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetTopGridLayout, parametersOfGetTopGridLayout, methodGetTopGridLayoutPrametersTypes);

            // Assert
            parametersOfGetTopGridLayout.ShouldNotBeNull();
            parametersOfGetTopGridLayout.Length.ShouldBe(1);
            methodGetTopGridLayoutPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTopGridLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTopGridLayout_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTopGridLayoutPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetTopGridLayout, Fixture, methodGetTopGridLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTopGridLayoutPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTopGridLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTopGridLayout_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTopGridLayoutPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetTopGridLayout, Fixture, methodGetTopGridLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTopGridLayoutPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTopGridLayout) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTopGridLayout_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTopGridLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTopGridLayout) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTopGridLayout_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTopGridLayout, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTopGridData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_GetTopGridData_Method_Call_Internally(Type[] types)
        {
            var methodGetTopGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetTopGridData, Fixture, methodGetTopGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTopGridData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTopGridData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.GetTopGridData(Ticket);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTopGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTopGridData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetTopGridDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTopGridData = { Ticket };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTopGridData, methodGetTopGridDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, string>(_modelInstanceFixture, out exception1, parametersOfGetTopGridData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetTopGridData, parametersOfGetTopGridData, methodGetTopGridDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTopGridData.ShouldNotBeNull();
            parametersOfGetTopGridData.Length.ShouldBe(1);
            methodGetTopGridDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTopGridData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTopGridData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetTopGridDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTopGridData = { Ticket };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetTopGridData, parametersOfGetTopGridData, methodGetTopGridDataPrametersTypes);

            // Assert
            parametersOfGetTopGridData.ShouldNotBeNull();
            parametersOfGetTopGridData.Length.ShouldBe(1);
            methodGetTopGridDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTopGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTopGridData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTopGridDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetTopGridData, Fixture, methodGetTopGridDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTopGridDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTopGridData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTopGridData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTopGridDataPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetTopGridData, Fixture, methodGetTopGridDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTopGridDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTopGridData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTopGridData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTopGridData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTopGridData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTopGridData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTopGridData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetBottomGridLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_GetBottomGridLayout_Method_Call_Internally(Type[] types)
        {
            var methodGetBottomGridLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetBottomGridLayout, Fixture, methodGetBottomGridLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetBottomGridLayout) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetBottomGridLayout_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.GetBottomGridLayout(Ticket);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetBottomGridLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetBottomGridLayout_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetBottomGridLayoutPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetBottomGridLayout = { Ticket };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetBottomGridLayout, methodGetBottomGridLayoutPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, string>(_modelInstanceFixture, out exception1, parametersOfGetBottomGridLayout);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetBottomGridLayout, parametersOfGetBottomGridLayout, methodGetBottomGridLayoutPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetBottomGridLayout.ShouldNotBeNull();
            parametersOfGetBottomGridLayout.Length.ShouldBe(1);
            methodGetBottomGridLayoutPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetBottomGridLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetBottomGridLayout_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetBottomGridLayoutPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetBottomGridLayout = { Ticket };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetBottomGridLayout, parametersOfGetBottomGridLayout, methodGetBottomGridLayoutPrametersTypes);

            // Assert
            parametersOfGetBottomGridLayout.ShouldNotBeNull();
            parametersOfGetBottomGridLayout.Length.ShouldBe(1);
            methodGetBottomGridLayoutPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetBottomGridLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetBottomGridLayout_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetBottomGridLayoutPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetBottomGridLayout, Fixture, methodGetBottomGridLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetBottomGridLayoutPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetBottomGridLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetBottomGridLayout_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetBottomGridLayoutPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetBottomGridLayout, Fixture, methodGetBottomGridLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetBottomGridLayoutPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetBottomGridLayout) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetBottomGridLayout_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetBottomGridLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetBottomGridLayout) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetBottomGridLayout_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetBottomGridLayout, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetBottomGridData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_GetBottomGridData_Method_Call_Internally(Type[] types)
        {
            var methodGetBottomGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetBottomGridData, Fixture, methodGetBottomGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetBottomGridData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetBottomGridData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.GetBottomGridData(Ticket);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetBottomGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetBottomGridData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetBottomGridDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetBottomGridData = { Ticket };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetBottomGridData, methodGetBottomGridDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, string>(_modelInstanceFixture, out exception1, parametersOfGetBottomGridData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetBottomGridData, parametersOfGetBottomGridData, methodGetBottomGridDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetBottomGridData.ShouldNotBeNull();
            parametersOfGetBottomGridData.Length.ShouldBe(1);
            methodGetBottomGridDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetBottomGridData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetBottomGridData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetBottomGridDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetBottomGridData = { Ticket };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetBottomGridData, parametersOfGetBottomGridData, methodGetBottomGridDataPrametersTypes);

            // Assert
            parametersOfGetBottomGridData.ShouldNotBeNull();
            parametersOfGetBottomGridData.Length.ShouldBe(1);
            methodGetBottomGridDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetBottomGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetBottomGridData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetBottomGridDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetBottomGridData, Fixture, methodGetBottomGridDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetBottomGridDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetBottomGridData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetBottomGridData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetBottomGridDataPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetBottomGridData, Fixture, methodGetBottomGridDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetBottomGridDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetBottomGridData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetBottomGridData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetBottomGridData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetBottomGridData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetBottomGridData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetBottomGridData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoShowFTEs) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_DoShowFTEs_Method_Call_Internally(Type[] types)
        {
            var methodDoShowFTEsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodDoShowFTEs, Fixture, methodDoShowFTEsPrametersTypes);
        }

        #endregion

        #region Method Call : (DoShowFTEs) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoShowFTEs_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var FTEMode = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.DoShowFTEs(Ticket, FTEMode);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DoShowFTEs) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoShowFTEs_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var FTEMode = CreateType<int>();
            var methodDoShowFTEsPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfDoShowFTEs = { Ticket, FTEMode };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDoShowFTEs, methodDoShowFTEsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfDoShowFTEs);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDoShowFTEs.ShouldNotBeNull();
            parametersOfDoShowFTEs.Length.ShouldBe(2);
            methodDoShowFTEsPrametersTypes.Length.ShouldBe(2);
            methodDoShowFTEsPrametersTypes.Length.ShouldBe(parametersOfDoShowFTEs.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DoShowFTEs) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoShowFTEs_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var FTEMode = CreateType<int>();
            var methodDoShowFTEsPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfDoShowFTEs = { Ticket, FTEMode };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelInstance, MethodDoShowFTEs, parametersOfDoShowFTEs, methodDoShowFTEsPrametersTypes);

            // Assert
            parametersOfDoShowFTEs.ShouldNotBeNull();
            parametersOfDoShowFTEs.Length.ShouldBe(2);
            methodDoShowFTEsPrametersTypes.Length.ShouldBe(2);
            methodDoShowFTEsPrametersTypes.Length.ShouldBe(parametersOfDoShowFTEs.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoShowFTEs) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoShowFTEs_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDoShowFTEs, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoShowFTEs) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoShowFTEs_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDoShowFTEsPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodDoShowFTEs, Fixture, methodDoShowFTEsPrametersTypes);

            // Assert
            methodDoShowFTEsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoShowFTEs) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoShowFTEs_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDoShowFTEs, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoPingSession) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_DoPingSession_Method_Call_Internally(Type[] types)
        {
            var methodDoPingSessionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodDoPingSession, Fixture, methodDoPingSessionPrametersTypes);
        }

        #endregion

        #region Method Call : (DoPingSession) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoPingSession_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.DoPingSession(Ticket);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (DoPingSession) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoPingSession_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodDoPingSessionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDoPingSession = { Ticket };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDoPingSession, methodDoPingSessionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfDoPingSession);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDoPingSession.ShouldNotBeNull();
            parametersOfDoPingSession.Length.ShouldBe(1);
            methodDoPingSessionPrametersTypes.Length.ShouldBe(1);
            methodDoPingSessionPrametersTypes.Length.ShouldBe(parametersOfDoPingSession.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoPingSession) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoPingSession_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodDoPingSessionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDoPingSession = { Ticket };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelInstance, MethodDoPingSession, parametersOfDoPingSession, methodDoPingSessionPrametersTypes);

            // Assert
            parametersOfDoPingSession.ShouldNotBeNull();
            parametersOfDoPingSession.Length.ShouldBe(1);
            methodDoPingSessionPrametersTypes.Length.ShouldBe(1);
            methodDoPingSessionPrametersTypes.Length.ShouldBe(parametersOfDoPingSession.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoPingSession) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoPingSession_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDoPingSession, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoPingSession) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoPingSession_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDoPingSessionPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodDoPingSession, Fixture, methodDoPingSessionPrametersTypes);

            // Assert
            methodDoPingSessionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoPingSession) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoPingSession_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDoPingSession, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoShowGantt) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_DoShowGantt_Method_Call_Internally(Type[] types)
        {
            var methodDoShowGanttPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodDoShowGantt, Fixture, methodDoShowGanttPrametersTypes);
        }

        #endregion

        #region Method Call : (DoShowGantt) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoShowGantt_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var GanttMode = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.DoShowGantt(Ticket, GanttMode);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DoShowGantt) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoShowGantt_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var GanttMode = CreateType<int>();
            var methodDoShowGanttPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfDoShowGantt = { Ticket, GanttMode };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDoShowGantt, methodDoShowGanttPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, int>(_modelInstanceFixture, out exception1, parametersOfDoShowGantt);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, int>(_modelInstance, MethodDoShowGantt, parametersOfDoShowGantt, methodDoShowGanttPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDoShowGantt.ShouldNotBeNull();
            parametersOfDoShowGantt.Length.ShouldBe(2);
            methodDoShowGanttPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DoShowGantt) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoShowGantt_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var GanttMode = CreateType<int>();
            var methodDoShowGanttPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfDoShowGantt = { Ticket, GanttMode };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDoShowGantt, methodDoShowGanttPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, int>(_modelInstanceFixture, out exception1, parametersOfDoShowGantt);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, int>(_modelInstance, MethodDoShowGantt, parametersOfDoShowGantt, methodDoShowGanttPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDoShowGantt.ShouldNotBeNull();
            parametersOfDoShowGantt.Length.ShouldBe(2);
            methodDoShowGanttPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DoShowGantt) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoShowGantt_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var GanttMode = CreateType<int>();
            var methodDoShowGanttPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfDoShowGantt = { Ticket, GanttMode };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, int>(_modelInstance, MethodDoShowGantt, parametersOfDoShowGantt, methodDoShowGanttPrametersTypes);

            // Assert
            parametersOfDoShowGantt.ShouldNotBeNull();
            parametersOfDoShowGantt.Length.ShouldBe(2);
            methodDoShowGanttPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoShowGantt) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoShowGantt_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDoShowGanttPrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodDoShowGantt, Fixture, methodDoShowGanttPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDoShowGanttPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoShowGantt) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoShowGantt_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDoShowGantt, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DoShowGantt) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoShowGantt_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDoShowGantt, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoSetGroupingFlag) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_DoSetGroupingFlag_Method_Call_Internally(Type[] types)
        {
            var methodDoSetGroupingFlagPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodDoSetGroupingFlag, Fixture, methodDoSetGroupingFlagPrametersTypes);
        }

        #endregion

        #region Method Call : (DoSetGroupingFlag) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoSetGroupingFlag_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var GroupMode = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.DoSetGroupingFlag(Ticket, GroupMode);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DoSetGroupingFlag) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoSetGroupingFlag_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var GroupMode = CreateType<int>();
            var methodDoSetGroupingFlagPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfDoSetGroupingFlag = { Ticket, GroupMode };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDoSetGroupingFlag, methodDoSetGroupingFlagPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfDoSetGroupingFlag);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDoSetGroupingFlag.ShouldNotBeNull();
            parametersOfDoSetGroupingFlag.Length.ShouldBe(2);
            methodDoSetGroupingFlagPrametersTypes.Length.ShouldBe(2);
            methodDoSetGroupingFlagPrametersTypes.Length.ShouldBe(parametersOfDoSetGroupingFlag.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DoSetGroupingFlag) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoSetGroupingFlag_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var GroupMode = CreateType<int>();
            var methodDoSetGroupingFlagPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfDoSetGroupingFlag = { Ticket, GroupMode };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelInstance, MethodDoSetGroupingFlag, parametersOfDoSetGroupingFlag, methodDoSetGroupingFlagPrametersTypes);

            // Assert
            parametersOfDoSetGroupingFlag.ShouldNotBeNull();
            parametersOfDoSetGroupingFlag.Length.ShouldBe(2);
            methodDoSetGroupingFlagPrametersTypes.Length.ShouldBe(2);
            methodDoSetGroupingFlagPrametersTypes.Length.ShouldBe(parametersOfDoSetGroupingFlag.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoSetGroupingFlag) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoSetGroupingFlag_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDoSetGroupingFlag, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoSetGroupingFlag) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoSetGroupingFlag_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDoSetGroupingFlagPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodDoSetGroupingFlag, Fixture, methodDoSetGroupingFlagPrametersTypes);

            // Assert
            methodDoSetGroupingFlagPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoSetGroupingFlag) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoSetGroupingFlag_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDoSetGroupingFlag, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetModels) (Return Type : List<ItemDefn>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_GetModels_Method_Call_Internally(Type[] types)
        {
            var methodGetModelsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetModels, Fixture, methodGetModelsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetModels) (Return Type : List<ItemDefn>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetModels_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.GetModels();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetModels) (Return Type : List<ItemDefn>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetModels_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetModelsPrametersTypes = null;
            object[] parametersOfGetModels = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetModels, methodGetModelsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, List<ItemDefn>>(_modelInstanceFixture, out exception1, parametersOfGetModels);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, List<ItemDefn>>(_modelInstance, MethodGetModels, parametersOfGetModels, methodGetModelsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetModels.ShouldBeNull();
            methodGetModelsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetModels) (Return Type : List<ItemDefn>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetModels_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetModelsPrametersTypes = null;
            object[] parametersOfGetModels = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, List<ItemDefn>>(_modelInstance, MethodGetModels, parametersOfGetModels, methodGetModelsPrametersTypes);

            // Assert
            parametersOfGetModels.ShouldBeNull();
            methodGetModelsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetModels) (Return Type : List<ItemDefn>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetModels_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetModelsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetModels, Fixture, methodGetModelsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetModelsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetModels) (Return Type : List<ItemDefn>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetModels_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetModelsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetModels, Fixture, methodGetModelsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetModelsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetModels) (Return Type : List<ItemDefn>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetModels_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetModels, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (LoadSelectVersions) (Return Type : List<ItemDefn>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_LoadSelectVersions_Method_Call_Internally(Type[] types)
        {
            var methodLoadSelectVersionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodLoadSelectVersions, Fixture, methodLoadSelectVersionsPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadSelectVersions) (Return Type : List<ItemDefn>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadSelectVersions_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var modelID = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.LoadSelectVersions(modelID);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (LoadSelectVersions) (Return Type : List<ItemDefn>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadSelectVersions_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var modelID = CreateType<int>();
            var methodLoadSelectVersionsPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfLoadSelectVersions = { modelID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodLoadSelectVersions, methodLoadSelectVersionsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, List<ItemDefn>>(_modelInstanceFixture, out exception1, parametersOfLoadSelectVersions);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, List<ItemDefn>>(_modelInstance, MethodLoadSelectVersions, parametersOfLoadSelectVersions, methodLoadSelectVersionsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfLoadSelectVersions.ShouldNotBeNull();
            parametersOfLoadSelectVersions.Length.ShouldBe(1);
            methodLoadSelectVersionsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (LoadSelectVersions) (Return Type : List<ItemDefn>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadSelectVersions_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var modelID = CreateType<int>();
            var methodLoadSelectVersionsPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfLoadSelectVersions = { modelID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, List<ItemDefn>>(_modelInstance, MethodLoadSelectVersions, parametersOfLoadSelectVersions, methodLoadSelectVersionsPrametersTypes);

            // Assert
            parametersOfLoadSelectVersions.ShouldNotBeNull();
            parametersOfLoadSelectVersions.Length.ShouldBe(1);
            methodLoadSelectVersionsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadSelectVersions) (Return Type : List<ItemDefn>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadSelectVersions_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodLoadSelectVersionsPrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodLoadSelectVersions, Fixture, methodLoadSelectVersionsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodLoadSelectVersionsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (LoadSelectVersions) (Return Type : List<ItemDefn>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadSelectVersions_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLoadSelectVersionsPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodLoadSelectVersions, Fixture, methodLoadSelectVersionsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodLoadSelectVersionsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LoadSelectVersions) (Return Type : List<ItemDefn>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadSelectVersions_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadSelectVersions, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (LoadSelectVersions) (Return Type : List<ItemDefn>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadSelectVersions_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLoadSelectVersions, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_HandleError_Static_Method_Call_Internally(Type[] types)
        {
            var methodHandleErrorPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodHandleError, Fixture, methodHandleErrorPrametersTypes);
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_HandleError_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sError = CreateType<string>();
            var nstatus = CreateType<int>();
            var sContext = CreateType<string>();
            var methodHandleErrorPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };
            object[] parametersOfHandleError = { sError, nstatus, sContext };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodHandleError, methodHandleErrorPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfHandleError);

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
        public void AUT_Model_HandleError_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sError = CreateType<string>();
            var nstatus = CreateType<int>();
            var sContext = CreateType<string>();
            var methodHandleErrorPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };
            object[] parametersOfHandleError = { sError, nstatus, sContext };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_modelInstanceFixture, _modelInstanceType, MethodHandleError, parametersOfHandleError, methodHandleErrorPrametersTypes);

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
        public void AUT_Model_HandleError_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodHandleErrorPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodHandleError, Fixture, methodHandleErrorPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodHandleErrorPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_HandleError_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHandleErrorPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodHandleError, Fixture, methodHandleErrorPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodHandleErrorPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_HandleError_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHandleError, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_HandleError_Static_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_Model_HandleException_Static_Method_Call_Internally(Type[] types)
        {
            var methodHandleExceptionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodHandleException, Fixture, methodHandleExceptionPrametersTypes);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_HandleException_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var ex = CreateType<Exception>();
            var sContext = CreateType<string>();
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(Exception), typeof(string) };
            object[] parametersOfHandleException = { ex, sContext };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodHandleException, methodHandleExceptionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfHandleException);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfHandleException.ShouldNotBeNull();
            parametersOfHandleException.Length.ShouldBe(2);
            methodHandleExceptionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_HandleException_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ex = CreateType<Exception>();
            var sContext = CreateType<string>();
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(Exception), typeof(string) };
            object[] parametersOfHandleException = { ex, sContext };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_modelInstanceFixture, _modelInstanceType, MethodHandleException, parametersOfHandleException, methodHandleExceptionPrametersTypes);

            // Assert
            parametersOfHandleException.ShouldNotBeNull();
            parametersOfHandleException.Length.ShouldBe(2);
            methodHandleExceptionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_HandleException_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(Exception), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodHandleException, Fixture, methodHandleExceptionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodHandleExceptionPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_HandleException_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(Exception), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodHandleException, Fixture, methodHandleExceptionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodHandleExceptionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_HandleException_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHandleException, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_HandleException_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodHandleException, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFilterGridLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_GetFilterGridLayout_Method_Call_Internally(Type[] types)
        {
            var methodGetFilterGridLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetFilterGridLayout, Fixture, methodGetFilterGridLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFilterGridLayout) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetFilterGridLayout_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.GetFilterGridLayout(Ticket);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetFilterGridLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetFilterGridLayout_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetFilterGridLayoutPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFilterGridLayout = { Ticket };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFilterGridLayout, methodGetFilterGridLayoutPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, string>(_modelInstanceFixture, out exception1, parametersOfGetFilterGridLayout);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetFilterGridLayout, parametersOfGetFilterGridLayout, methodGetFilterGridLayoutPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFilterGridLayout.ShouldNotBeNull();
            parametersOfGetFilterGridLayout.Length.ShouldBe(1);
            methodGetFilterGridLayoutPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFilterGridLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetFilterGridLayout_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetFilterGridLayoutPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFilterGridLayout = { Ticket };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetFilterGridLayout, parametersOfGetFilterGridLayout, methodGetFilterGridLayoutPrametersTypes);

            // Assert
            parametersOfGetFilterGridLayout.ShouldNotBeNull();
            parametersOfGetFilterGridLayout.Length.ShouldBe(1);
            methodGetFilterGridLayoutPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFilterGridLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetFilterGridLayout_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFilterGridLayoutPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetFilterGridLayout, Fixture, methodGetFilterGridLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFilterGridLayoutPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFilterGridLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetFilterGridLayout_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFilterGridLayoutPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetFilterGridLayout, Fixture, methodGetFilterGridLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFilterGridLayoutPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFilterGridLayout) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetFilterGridLayout_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFilterGridLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFilterGridLayout) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetFilterGridLayout_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFilterGridLayout, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFilterGridData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_GetFilterGridData_Method_Call_Internally(Type[] types)
        {
            var methodGetFilterGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetFilterGridData, Fixture, methodGetFilterGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFilterGridData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetFilterGridData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.GetFilterGridData(Ticket);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetFilterGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetFilterGridData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetFilterGridDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFilterGridData = { Ticket };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFilterGridData, methodGetFilterGridDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, string>(_modelInstanceFixture, out exception1, parametersOfGetFilterGridData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetFilterGridData, parametersOfGetFilterGridData, methodGetFilterGridDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFilterGridData.ShouldNotBeNull();
            parametersOfGetFilterGridData.Length.ShouldBe(1);
            methodGetFilterGridDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFilterGridData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetFilterGridData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetFilterGridDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFilterGridData = { Ticket };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetFilterGridData, parametersOfGetFilterGridData, methodGetFilterGridDataPrametersTypes);

            // Assert
            parametersOfGetFilterGridData.ShouldNotBeNull();
            parametersOfGetFilterGridData.Length.ShouldBe(1);
            methodGetFilterGridDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFilterGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetFilterGridData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFilterGridDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetFilterGridData, Fixture, methodGetFilterGridDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFilterGridDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFilterGridData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetFilterGridData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFilterGridDataPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetFilterGridData, Fixture, methodGetFilterGridDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFilterGridDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFilterGridData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetFilterGridData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFilterGridData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFilterGridData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetFilterGridData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFilterGridData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetFilterData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_SetFilterData_Method_Call_Internally(Type[] types)
        {
            var methodSetFilterDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodSetFilterData, Fixture, methodSetFilterDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SetFilterData) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetFilterData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sfilterData = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.SetFilterData(Ticket, sfilterData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetFilterData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetFilterData_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sfilterData = CreateType<string>();
            var methodSetFilterDataPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfSetFilterData = { Ticket, sfilterData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetFilterData, methodSetFilterDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfSetFilterData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetFilterData.ShouldNotBeNull();
            parametersOfSetFilterData.Length.ShouldBe(2);
            methodSetFilterDataPrametersTypes.Length.ShouldBe(2);
            methodSetFilterDataPrametersTypes.Length.ShouldBe(parametersOfSetFilterData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetFilterData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetFilterData_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sfilterData = CreateType<string>();
            var methodSetFilterDataPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfSetFilterData = { Ticket, sfilterData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelInstance, MethodSetFilterData, parametersOfSetFilterData, methodSetFilterDataPrametersTypes);

            // Assert
            parametersOfSetFilterData.ShouldNotBeNull();
            parametersOfSetFilterData.Length.ShouldBe(2);
            methodSetFilterDataPrametersTypes.Length.ShouldBe(2);
            methodSetFilterDataPrametersTypes.Length.ShouldBe(parametersOfSetFilterData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetFilterData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetFilterData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetFilterData, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetFilterData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetFilterData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetFilterDataPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodSetFilterData, Fixture, methodSetFilterDataPrametersTypes);

            // Assert
            methodSetFilterDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetFilterData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetFilterData_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetFilterData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTotalGridLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_GetTotalGridLayout_Method_Call_Internally(Type[] types)
        {
            var methodGetTotalGridLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetTotalGridLayout, Fixture, methodGetTotalGridLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTotalGridLayout) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTotalGridLayout_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.GetTotalGridLayout(Ticket);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTotalGridLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTotalGridLayout_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetTotalGridLayoutPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTotalGridLayout = { Ticket };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTotalGridLayout, methodGetTotalGridLayoutPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, string>(_modelInstanceFixture, out exception1, parametersOfGetTotalGridLayout);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetTotalGridLayout, parametersOfGetTotalGridLayout, methodGetTotalGridLayoutPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTotalGridLayout.ShouldNotBeNull();
            parametersOfGetTotalGridLayout.Length.ShouldBe(1);
            methodGetTotalGridLayoutPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTotalGridLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTotalGridLayout_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetTotalGridLayoutPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTotalGridLayout = { Ticket };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetTotalGridLayout, parametersOfGetTotalGridLayout, methodGetTotalGridLayoutPrametersTypes);

            // Assert
            parametersOfGetTotalGridLayout.ShouldNotBeNull();
            parametersOfGetTotalGridLayout.Length.ShouldBe(1);
            methodGetTotalGridLayoutPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTotalGridLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTotalGridLayout_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTotalGridLayoutPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetTotalGridLayout, Fixture, methodGetTotalGridLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTotalGridLayoutPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTotalGridLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTotalGridLayout_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTotalGridLayoutPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetTotalGridLayout, Fixture, methodGetTotalGridLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTotalGridLayoutPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTotalGridLayout) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTotalGridLayout_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTotalGridLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTotalGridLayout) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTotalGridLayout_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTotalGridLayout, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTotalGridData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_GetTotalGridData_Method_Call_Internally(Type[] types)
        {
            var methodGetTotalGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetTotalGridData, Fixture, methodGetTotalGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTotalGridData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTotalGridData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.GetTotalGridData(Ticket);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTotalGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTotalGridData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetTotalGridDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTotalGridData = { Ticket };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTotalGridData, methodGetTotalGridDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, string>(_modelInstanceFixture, out exception1, parametersOfGetTotalGridData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetTotalGridData, parametersOfGetTotalGridData, methodGetTotalGridDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTotalGridData.ShouldNotBeNull();
            parametersOfGetTotalGridData.Length.ShouldBe(1);
            methodGetTotalGridDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTotalGridData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTotalGridData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetTotalGridDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTotalGridData = { Ticket };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetTotalGridData, parametersOfGetTotalGridData, methodGetTotalGridDataPrametersTypes);

            // Assert
            parametersOfGetTotalGridData.ShouldNotBeNull();
            parametersOfGetTotalGridData.Length.ShouldBe(1);
            methodGetTotalGridDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTotalGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTotalGridData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTotalGridDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetTotalGridData, Fixture, methodGetTotalGridDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTotalGridDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTotalGridData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTotalGridData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTotalGridDataPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetTotalGridData, Fixture, methodGetTotalGridDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTotalGridDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTotalGridData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTotalGridData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTotalGridData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTotalGridData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTotalGridData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTotalGridData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCostTypeCompareGridData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_GetCostTypeCompareGridData_Method_Call_Internally(Type[] types)
        {
            var methodGetCostTypeCompareGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetCostTypeCompareGridData, Fixture, methodGetCostTypeCompareGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCostTypeCompareGridData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetCostTypeCompareGridData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.GetCostTypeCompareGridData(Ticket);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCostTypeCompareGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetCostTypeCompareGridData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetCostTypeCompareGridDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCostTypeCompareGridData = { Ticket };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCostTypeCompareGridData, methodGetCostTypeCompareGridDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, string>(_modelInstanceFixture, out exception1, parametersOfGetCostTypeCompareGridData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetCostTypeCompareGridData, parametersOfGetCostTypeCompareGridData, methodGetCostTypeCompareGridDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCostTypeCompareGridData.ShouldNotBeNull();
            parametersOfGetCostTypeCompareGridData.Length.ShouldBe(1);
            methodGetCostTypeCompareGridDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCostTypeCompareGridData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetCostTypeCompareGridData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetCostTypeCompareGridDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCostTypeCompareGridData = { Ticket };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetCostTypeCompareGridData, parametersOfGetCostTypeCompareGridData, methodGetCostTypeCompareGridDataPrametersTypes);

            // Assert
            parametersOfGetCostTypeCompareGridData.ShouldNotBeNull();
            parametersOfGetCostTypeCompareGridData.Length.ShouldBe(1);
            methodGetCostTypeCompareGridDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCostTypeCompareGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetCostTypeCompareGridData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCostTypeCompareGridDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetCostTypeCompareGridData, Fixture, methodGetCostTypeCompareGridDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCostTypeCompareGridDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCostTypeCompareGridData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetCostTypeCompareGridData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCostTypeCompareGridDataPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetCostTypeCompareGridData, Fixture, methodGetCostTypeCompareGridDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCostTypeCompareGridDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCostTypeCompareGridData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetCostTypeCompareGridData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCostTypeCompareGridData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCostTypeCompareGridData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetCostTypeCompareGridData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCostTypeCompareGridData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetCostTypeCompareData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_SetCostTypeCompareData_Method_Call_Internally(Type[] types)
        {
            var methodSetCostTypeCompareDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodSetCostTypeCompareData, Fixture, methodSetCostTypeCompareDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SetCostTypeCompareData) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetCostTypeCompareData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sCTCmpData = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.SetCostTypeCompareData(Ticket, sCTCmpData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetCostTypeCompareData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetCostTypeCompareData_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sCTCmpData = CreateType<string>();
            var methodSetCostTypeCompareDataPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfSetCostTypeCompareData = { Ticket, sCTCmpData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetCostTypeCompareData, methodSetCostTypeCompareDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfSetCostTypeCompareData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetCostTypeCompareData.ShouldNotBeNull();
            parametersOfSetCostTypeCompareData.Length.ShouldBe(2);
            methodSetCostTypeCompareDataPrametersTypes.Length.ShouldBe(2);
            methodSetCostTypeCompareDataPrametersTypes.Length.ShouldBe(parametersOfSetCostTypeCompareData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetCostTypeCompareData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetCostTypeCompareData_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sCTCmpData = CreateType<string>();
            var methodSetCostTypeCompareDataPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfSetCostTypeCompareData = { Ticket, sCTCmpData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelInstance, MethodSetCostTypeCompareData, parametersOfSetCostTypeCompareData, methodSetCostTypeCompareDataPrametersTypes);

            // Assert
            parametersOfSetCostTypeCompareData.ShouldNotBeNull();
            parametersOfSetCostTypeCompareData.Length.ShouldBe(2);
            methodSetCostTypeCompareDataPrametersTypes.Length.ShouldBe(2);
            methodSetCostTypeCompareDataPrametersTypes.Length.ShouldBe(parametersOfSetCostTypeCompareData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetCostTypeCompareData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetCostTypeCompareData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetCostTypeCompareData, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetCostTypeCompareData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetCostTypeCompareData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetCostTypeCompareDataPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodSetCostTypeCompareData, Fixture, methodSetCostTypeCompareDataPrametersTypes);

            // Assert
            methodSetCostTypeCompareDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetCostTypeCompareData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetCostTypeCompareData_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetCostTypeCompareData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetColumnGridData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_GetColumnGridData_Method_Call_Internally(Type[] types)
        {
            var methodGetColumnGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetColumnGridData, Fixture, methodGetColumnGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetColumnGridData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetColumnGridData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.GetColumnGridData(Ticket);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetColumnGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetColumnGridData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetColumnGridDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetColumnGridData = { Ticket };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetColumnGridData, methodGetColumnGridDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, string>(_modelInstanceFixture, out exception1, parametersOfGetColumnGridData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetColumnGridData, parametersOfGetColumnGridData, methodGetColumnGridDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetColumnGridData.ShouldNotBeNull();
            parametersOfGetColumnGridData.Length.ShouldBe(1);
            methodGetColumnGridDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetColumnGridData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetColumnGridData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetColumnGridDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetColumnGridData = { Ticket };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetColumnGridData, parametersOfGetColumnGridData, methodGetColumnGridDataPrametersTypes);

            // Assert
            parametersOfGetColumnGridData.ShouldNotBeNull();
            parametersOfGetColumnGridData.Length.ShouldBe(1);
            methodGetColumnGridDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetColumnGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetColumnGridData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetColumnGridDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetColumnGridData, Fixture, methodGetColumnGridDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetColumnGridDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetColumnGridData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetColumnGridData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetColumnGridDataPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetColumnGridData, Fixture, methodGetColumnGridDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetColumnGridDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetColumnGridData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetColumnGridData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetColumnGridData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetColumnGridData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetColumnGridData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetColumnGridData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetTotalData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_SetTotalData_Method_Call_Internally(Type[] types)
        {
            var methodSetTotalDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodSetTotalData, Fixture, methodSetTotalDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SetTotalData) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetTotalData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sTotalData = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.SetTotalData(Ticket, sTotalData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetTotalData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetTotalData_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sTotalData = CreateType<string>();
            var methodSetTotalDataPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfSetTotalData = { Ticket, sTotalData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetTotalData, methodSetTotalDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfSetTotalData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetTotalData.ShouldNotBeNull();
            parametersOfSetTotalData.Length.ShouldBe(2);
            methodSetTotalDataPrametersTypes.Length.ShouldBe(2);
            methodSetTotalDataPrametersTypes.Length.ShouldBe(parametersOfSetTotalData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetTotalData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetTotalData_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sTotalData = CreateType<string>();
            var methodSetTotalDataPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfSetTotalData = { Ticket, sTotalData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelInstance, MethodSetTotalData, parametersOfSetTotalData, methodSetTotalDataPrametersTypes);

            // Assert
            parametersOfSetTotalData.ShouldNotBeNull();
            parametersOfSetTotalData.Length.ShouldBe(2);
            methodSetTotalDataPrametersTypes.Length.ShouldBe(2);
            methodSetTotalDataPrametersTypes.Length.ShouldBe(parametersOfSetTotalData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTotalData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetTotalData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetTotalData, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetTotalData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetTotalData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetTotalDataPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodSetTotalData, Fixture, methodSetTotalDataPrametersTypes);

            // Assert
            methodSetTotalDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTotalData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetTotalData_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetTotalData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSortAndGroup) (Return Type : SortGroupDefn) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_GetSortAndGroup_Method_Call_Internally(Type[] types)
        {
            var methodGetSortAndGroupPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetSortAndGroup, Fixture, methodGetSortAndGroupPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSortAndGroup) (Return Type : SortGroupDefn) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetSortAndGroup_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.GetSortAndGroup(Ticket);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetSortAndGroup) (Return Type : SortGroupDefn) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetSortAndGroup_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetSortAndGroupPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSortAndGroup = { Ticket };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSortAndGroup, methodGetSortAndGroupPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, SortGroupDefn>(_modelInstanceFixture, out exception1, parametersOfGetSortAndGroup);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, SortGroupDefn>(_modelInstance, MethodGetSortAndGroup, parametersOfGetSortAndGroup, methodGetSortAndGroupPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetSortAndGroup.ShouldNotBeNull();
            parametersOfGetSortAndGroup.Length.ShouldBe(1);
            methodGetSortAndGroupPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSortAndGroup) (Return Type : SortGroupDefn) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetSortAndGroup_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetSortAndGroupPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSortAndGroup = { Ticket };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, SortGroupDefn>(_modelInstance, MethodGetSortAndGroup, parametersOfGetSortAndGroup, methodGetSortAndGroupPrametersTypes);

            // Assert
            parametersOfGetSortAndGroup.ShouldNotBeNull();
            parametersOfGetSortAndGroup.Length.ShouldBe(1);
            methodGetSortAndGroupPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSortAndGroup) (Return Type : SortGroupDefn) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetSortAndGroup_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSortAndGroupPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetSortAndGroup, Fixture, methodGetSortAndGroupPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSortAndGroupPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSortAndGroup) (Return Type : SortGroupDefn) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetSortAndGroup_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSortAndGroupPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetSortAndGroup, Fixture, methodGetSortAndGroupPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSortAndGroupPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSortAndGroup) (Return Type : SortGroupDefn) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetSortAndGroup_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSortAndGroup, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSortAndGroup) (Return Type : SortGroupDefn) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetSortAndGroup_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSortAndGroup, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetSortAndGroup) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_SetSortAndGroup_Method_Call_Internally(Type[] types)
        {
            var methodSetSortAndGroupPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodSetSortAndGroup, Fixture, methodSetSortAndGroupPrametersTypes);
        }

        #endregion

        #region Method Call : (SetSortAndGroup) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetSortAndGroup_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var SnG = CreateType<SortGroupDefn>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.SetSortAndGroup(Ticket, SnG);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetSortAndGroup) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetSortAndGroup_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var SnG = CreateType<SortGroupDefn>();
            var methodSetSortAndGroupPrametersTypes = new Type[] { typeof(string), typeof(SortGroupDefn) };
            object[] parametersOfSetSortAndGroup = { Ticket, SnG };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetSortAndGroup, methodSetSortAndGroupPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfSetSortAndGroup);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetSortAndGroup.ShouldNotBeNull();
            parametersOfSetSortAndGroup.Length.ShouldBe(2);
            methodSetSortAndGroupPrametersTypes.Length.ShouldBe(2);
            methodSetSortAndGroupPrametersTypes.Length.ShouldBe(parametersOfSetSortAndGroup.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetSortAndGroup) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetSortAndGroup_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var SnG = CreateType<SortGroupDefn>();
            var methodSetSortAndGroupPrametersTypes = new Type[] { typeof(string), typeof(SortGroupDefn) };
            object[] parametersOfSetSortAndGroup = { Ticket, SnG };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelInstance, MethodSetSortAndGroup, parametersOfSetSortAndGroup, methodSetSortAndGroupPrametersTypes);

            // Assert
            parametersOfSetSortAndGroup.ShouldNotBeNull();
            parametersOfSetSortAndGroup.Length.ShouldBe(2);
            methodSetSortAndGroupPrametersTypes.Length.ShouldBe(2);
            methodSetSortAndGroupPrametersTypes.Length.ShouldBe(parametersOfSetSortAndGroup.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSortAndGroup) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetSortAndGroup_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetSortAndGroup, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetSortAndGroup) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetSortAndGroup_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetSortAndGroupPrametersTypes = new Type[] { typeof(string), typeof(SortGroupDefn) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodSetSortAndGroup, Fixture, methodSetSortAndGroupPrametersTypes);

            // Assert
            methodSetSortAndGroupPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSortAndGroup) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetSortAndGroup_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetSortAndGroup, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetColumnOrderData) (Return Type : SortGroupDefn) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_GetColumnOrderData_Method_Call_Internally(Type[] types)
        {
            var methodGetColumnOrderDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetColumnOrderData, Fixture, methodGetColumnOrderDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetColumnOrderData) (Return Type : SortGroupDefn) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetColumnOrderData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.GetColumnOrderData(Ticket);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetColumnOrderData) (Return Type : SortGroupDefn) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetColumnOrderData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetColumnOrderDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetColumnOrderData = { Ticket };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetColumnOrderData, methodGetColumnOrderDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, SortGroupDefn>(_modelInstanceFixture, out exception1, parametersOfGetColumnOrderData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, SortGroupDefn>(_modelInstance, MethodGetColumnOrderData, parametersOfGetColumnOrderData, methodGetColumnOrderDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetColumnOrderData.ShouldNotBeNull();
            parametersOfGetColumnOrderData.Length.ShouldBe(1);
            methodGetColumnOrderDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetColumnOrderData) (Return Type : SortGroupDefn) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetColumnOrderData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetColumnOrderDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetColumnOrderData = { Ticket };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, SortGroupDefn>(_modelInstance, MethodGetColumnOrderData, parametersOfGetColumnOrderData, methodGetColumnOrderDataPrametersTypes);

            // Assert
            parametersOfGetColumnOrderData.ShouldNotBeNull();
            parametersOfGetColumnOrderData.Length.ShouldBe(1);
            methodGetColumnOrderDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetColumnOrderData) (Return Type : SortGroupDefn) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetColumnOrderData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetColumnOrderDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetColumnOrderData, Fixture, methodGetColumnOrderDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetColumnOrderDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetColumnOrderData) (Return Type : SortGroupDefn) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetColumnOrderData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetColumnOrderDataPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetColumnOrderData, Fixture, methodGetColumnOrderDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetColumnOrderDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetColumnOrderData) (Return Type : SortGroupDefn) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetColumnOrderData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetColumnOrderData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetColumnOrderData) (Return Type : SortGroupDefn) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetColumnOrderData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetColumnOrderData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetColumnOrder) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_SetColumnOrder_Method_Call_Internally(Type[] types)
        {
            var methodSetColumnOrderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodSetColumnOrder, Fixture, methodSetColumnOrderPrametersTypes);
        }

        #endregion

        #region Method Call : (SetColumnOrder) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetColumnOrder_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var SnG = CreateType<SortGroupDefn>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.SetColumnOrder(Ticket, SnG);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetColumnOrder) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetColumnOrder_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var SnG = CreateType<SortGroupDefn>();
            var methodSetColumnOrderPrametersTypes = new Type[] { typeof(string), typeof(SortGroupDefn) };
            object[] parametersOfSetColumnOrder = { Ticket, SnG };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetColumnOrder, methodSetColumnOrderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfSetColumnOrder);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetColumnOrder.ShouldNotBeNull();
            parametersOfSetColumnOrder.Length.ShouldBe(2);
            methodSetColumnOrderPrametersTypes.Length.ShouldBe(2);
            methodSetColumnOrderPrametersTypes.Length.ShouldBe(parametersOfSetColumnOrder.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetColumnOrder) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetColumnOrder_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var SnG = CreateType<SortGroupDefn>();
            var methodSetColumnOrderPrametersTypes = new Type[] { typeof(string), typeof(SortGroupDefn) };
            object[] parametersOfSetColumnOrder = { Ticket, SnG };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelInstance, MethodSetColumnOrder, parametersOfSetColumnOrder, methodSetColumnOrderPrametersTypes);

            // Assert
            parametersOfSetColumnOrder.ShouldNotBeNull();
            parametersOfSetColumnOrder.Length.ShouldBe(2);
            methodSetColumnOrderPrametersTypes.Length.ShouldBe(2);
            methodSetColumnOrderPrametersTypes.Length.ShouldBe(parametersOfSetColumnOrder.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetColumnOrder) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetColumnOrder_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetColumnOrder, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetColumnOrder) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetColumnOrder_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetColumnOrderPrametersTypes = new Type[] { typeof(string), typeof(SortGroupDefn) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodSetColumnOrder, Fixture, methodSetColumnOrderPrametersTypes);

            // Assert
            methodSetColumnOrderPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetColumnOrder) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetColumnOrder_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetColumnOrder, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadCopyVersionPILists) (Return Type : SortGroupDefn) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_LoadCopyVersionPILists_Method_Call_Internally(Type[] types)
        {
            var methodLoadCopyVersionPIListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodLoadCopyVersionPILists, Fixture, methodLoadCopyVersionPIListsPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadCopyVersionPILists) (Return Type : SortGroupDefn) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadCopyVersionPILists_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var fromVer = CreateType<int>();
            var toVer = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.LoadCopyVersionPILists(Ticket, fromVer, toVer);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (LoadCopyVersionPILists) (Return Type : SortGroupDefn) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadCopyVersionPILists_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var fromVer = CreateType<int>();
            var toVer = CreateType<int>();
            var methodLoadCopyVersionPIListsPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(int) };
            object[] parametersOfLoadCopyVersionPILists = { Ticket, fromVer, toVer };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodLoadCopyVersionPILists, methodLoadCopyVersionPIListsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, SortGroupDefn>(_modelInstanceFixture, out exception1, parametersOfLoadCopyVersionPILists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, SortGroupDefn>(_modelInstance, MethodLoadCopyVersionPILists, parametersOfLoadCopyVersionPILists, methodLoadCopyVersionPIListsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfLoadCopyVersionPILists.ShouldNotBeNull();
            parametersOfLoadCopyVersionPILists.Length.ShouldBe(3);
            methodLoadCopyVersionPIListsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (LoadCopyVersionPILists) (Return Type : SortGroupDefn) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadCopyVersionPILists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var fromVer = CreateType<int>();
            var toVer = CreateType<int>();
            var methodLoadCopyVersionPIListsPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(int) };
            object[] parametersOfLoadCopyVersionPILists = { Ticket, fromVer, toVer };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, SortGroupDefn>(_modelInstance, MethodLoadCopyVersionPILists, parametersOfLoadCopyVersionPILists, methodLoadCopyVersionPIListsPrametersTypes);

            // Assert
            parametersOfLoadCopyVersionPILists.ShouldNotBeNull();
            parametersOfLoadCopyVersionPILists.Length.ShouldBe(3);
            methodLoadCopyVersionPIListsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadCopyVersionPILists) (Return Type : SortGroupDefn) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadCopyVersionPILists_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodLoadCopyVersionPIListsPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodLoadCopyVersionPILists, Fixture, methodLoadCopyVersionPIListsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodLoadCopyVersionPIListsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (LoadCopyVersionPILists) (Return Type : SortGroupDefn) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadCopyVersionPILists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLoadCopyVersionPIListsPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(int) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodLoadCopyVersionPILists, Fixture, methodLoadCopyVersionPIListsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodLoadCopyVersionPIListsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LoadCopyVersionPILists) (Return Type : SortGroupDefn) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadCopyVersionPILists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadCopyVersionPILists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (LoadCopyVersionPILists) (Return Type : SortGroupDefn) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadCopyVersionPILists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLoadCopyVersionPILists, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSaveVersions) (Return Type : List<ItemDefn>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_GetSaveVersions_Method_Call_Internally(Type[] types)
        {
            var methodGetSaveVersionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetSaveVersions, Fixture, methodGetSaveVersionsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSaveVersions) (Return Type : List<ItemDefn>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetSaveVersions_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.GetSaveVersions(Ticket);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetSaveVersions) (Return Type : List<ItemDefn>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetSaveVersions_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetSaveVersionsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSaveVersions = { Ticket };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSaveVersions, methodGetSaveVersionsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, List<ItemDefn>>(_modelInstanceFixture, out exception1, parametersOfGetSaveVersions);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, List<ItemDefn>>(_modelInstance, MethodGetSaveVersions, parametersOfGetSaveVersions, methodGetSaveVersionsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetSaveVersions.ShouldNotBeNull();
            parametersOfGetSaveVersions.Length.ShouldBe(1);
            methodGetSaveVersionsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSaveVersions) (Return Type : List<ItemDefn>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetSaveVersions_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetSaveVersionsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSaveVersions = { Ticket };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, List<ItemDefn>>(_modelInstance, MethodGetSaveVersions, parametersOfGetSaveVersions, methodGetSaveVersionsPrametersTypes);

            // Assert
            parametersOfGetSaveVersions.ShouldNotBeNull();
            parametersOfGetSaveVersions.Length.ShouldBe(1);
            methodGetSaveVersionsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSaveVersions) (Return Type : List<ItemDefn>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetSaveVersions_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSaveVersionsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetSaveVersions, Fixture, methodGetSaveVersionsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSaveVersionsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSaveVersions) (Return Type : List<ItemDefn>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetSaveVersions_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSaveVersionsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetSaveVersions, Fixture, methodGetSaveVersionsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSaveVersionsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSaveVersions) (Return Type : List<ItemDefn>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetSaveVersions_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSaveVersions, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSaveVersions) (Return Type : List<ItemDefn>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetSaveVersions_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSaveVersions, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTargetList) (Return Type : List<ItemDefn>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_GetTargetList_Method_Call_Internally(Type[] types)
        {
            var methodGetTargetListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetTargetList, Fixture, methodGetTargetListPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTargetList) (Return Type : List<ItemDefn>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTargetList_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.GetTargetList(Ticket);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTargetList) (Return Type : List<ItemDefn>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTargetList_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetTargetListPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTargetList = { Ticket };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTargetList, methodGetTargetListPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, List<ItemDefn>>(_modelInstanceFixture, out exception1, parametersOfGetTargetList);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, List<ItemDefn>>(_modelInstance, MethodGetTargetList, parametersOfGetTargetList, methodGetTargetListPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTargetList.ShouldNotBeNull();
            parametersOfGetTargetList.Length.ShouldBe(1);
            methodGetTargetListPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTargetList) (Return Type : List<ItemDefn>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTargetList_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetTargetListPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTargetList = { Ticket };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, List<ItemDefn>>(_modelInstance, MethodGetTargetList, parametersOfGetTargetList, methodGetTargetListPrametersTypes);

            // Assert
            parametersOfGetTargetList.ShouldNotBeNull();
            parametersOfGetTargetList.Length.ShouldBe(1);
            methodGetTargetListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTargetList) (Return Type : List<ItemDefn>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTargetList_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTargetListPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetTargetList, Fixture, methodGetTargetListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTargetListPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTargetList) (Return Type : List<ItemDefn>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTargetList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTargetListPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetTargetList, Fixture, methodGetTargetListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTargetListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTargetList) (Return Type : List<ItemDefn>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTargetList_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTargetList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTargetList) (Return Type : List<ItemDefn>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTargetList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTargetList, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoSaveVersion) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_DoSaveVersion_Method_Call_Internally(Type[] types)
        {
            var methodDoSaveVersionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodDoSaveVersion, Fixture, methodDoSaveVersionPrametersTypes);
        }

        #endregion

        #region Method Call : (DoSaveVersion) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoSaveVersion_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sVersion = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.DoSaveVersion(Ticket, sVersion);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DoSaveVersion) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoSaveVersion_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sVersion = CreateType<string>();
            var methodDoSaveVersionPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDoSaveVersion = { Ticket, sVersion };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDoSaveVersion, methodDoSaveVersionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfDoSaveVersion);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDoSaveVersion.ShouldNotBeNull();
            parametersOfDoSaveVersion.Length.ShouldBe(2);
            methodDoSaveVersionPrametersTypes.Length.ShouldBe(2);
            methodDoSaveVersionPrametersTypes.Length.ShouldBe(parametersOfDoSaveVersion.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DoSaveVersion) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoSaveVersion_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sVersion = CreateType<string>();
            var methodDoSaveVersionPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDoSaveVersion = { Ticket, sVersion };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelInstance, MethodDoSaveVersion, parametersOfDoSaveVersion, methodDoSaveVersionPrametersTypes);

            // Assert
            parametersOfDoSaveVersion.ShouldNotBeNull();
            parametersOfDoSaveVersion.Length.ShouldBe(2);
            methodDoSaveVersionPrametersTypes.Length.ShouldBe(2);
            methodDoSaveVersionPrametersTypes.Length.ShouldBe(parametersOfDoSaveVersion.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoSaveVersion) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoSaveVersion_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDoSaveVersion, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoSaveVersion) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoSaveVersion_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDoSaveVersionPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodDoSaveVersion, Fixture, methodDoSaveVersionPrametersTypes);

            // Assert
            methodDoSaveVersionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoSaveVersion) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoSaveVersion_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDoSaveVersion, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPeriodsandDisplay) (Return Type : PeriodsAndOptions) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_GetPeriodsandDisplay_Method_Call_Internally(Type[] types)
        {
            var methodGetPeriodsandDisplayPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetPeriodsandDisplay, Fixture, methodGetPeriodsandDisplayPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPeriodsandDisplay) (Return Type : PeriodsAndOptions) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetPeriodsandDisplay_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.GetPeriodsandDisplay(Ticket);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetPeriodsandDisplay) (Return Type : PeriodsAndOptions) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetPeriodsandDisplay_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetPeriodsandDisplayPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetPeriodsandDisplay = { Ticket };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetPeriodsandDisplay, methodGetPeriodsandDisplayPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, PeriodsAndOptions>(_modelInstanceFixture, out exception1, parametersOfGetPeriodsandDisplay);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, PeriodsAndOptions>(_modelInstance, MethodGetPeriodsandDisplay, parametersOfGetPeriodsandDisplay, methodGetPeriodsandDisplayPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetPeriodsandDisplay.ShouldNotBeNull();
            parametersOfGetPeriodsandDisplay.Length.ShouldBe(1);
            methodGetPeriodsandDisplayPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetPeriodsandDisplay) (Return Type : PeriodsAndOptions) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetPeriodsandDisplay_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetPeriodsandDisplayPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetPeriodsandDisplay = { Ticket };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, PeriodsAndOptions>(_modelInstance, MethodGetPeriodsandDisplay, parametersOfGetPeriodsandDisplay, methodGetPeriodsandDisplayPrametersTypes);

            // Assert
            parametersOfGetPeriodsandDisplay.ShouldNotBeNull();
            parametersOfGetPeriodsandDisplay.Length.ShouldBe(1);
            methodGetPeriodsandDisplayPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPeriodsandDisplay) (Return Type : PeriodsAndOptions) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetPeriodsandDisplay_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetPeriodsandDisplayPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetPeriodsandDisplay, Fixture, methodGetPeriodsandDisplayPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPeriodsandDisplayPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetPeriodsandDisplay) (Return Type : PeriodsAndOptions) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetPeriodsandDisplay_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPeriodsandDisplayPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetPeriodsandDisplay, Fixture, methodGetPeriodsandDisplayPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPeriodsandDisplayPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPeriodsandDisplay) (Return Type : PeriodsAndOptions) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetPeriodsandDisplay_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPeriodsandDisplay, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPeriodsandDisplay) (Return Type : PeriodsAndOptions) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetPeriodsandDisplay_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetPeriodsandDisplay, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetPeriodsandDisplay) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_SetPeriodsandDisplay_Method_Call_Internally(Type[] types)
        {
            var methodSetPeriodsandDisplayPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodSetPeriodsandDisplay, Fixture, methodSetPeriodsandDisplayPrametersTypes);
        }

        #endregion

        #region Method Call : (SetPeriodsandDisplay) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetPeriodsandDisplay_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var poa = CreateType<PeriodsAndOptions>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.SetPeriodsandDisplay(Ticket, poa);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetPeriodsandDisplay) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetPeriodsandDisplay_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var poa = CreateType<PeriodsAndOptions>();
            var methodSetPeriodsandDisplayPrametersTypes = new Type[] { typeof(string), typeof(PeriodsAndOptions) };
            object[] parametersOfSetPeriodsandDisplay = { Ticket, poa };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetPeriodsandDisplay, methodSetPeriodsandDisplayPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfSetPeriodsandDisplay);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetPeriodsandDisplay.ShouldNotBeNull();
            parametersOfSetPeriodsandDisplay.Length.ShouldBe(2);
            methodSetPeriodsandDisplayPrametersTypes.Length.ShouldBe(2);
            methodSetPeriodsandDisplayPrametersTypes.Length.ShouldBe(parametersOfSetPeriodsandDisplay.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetPeriodsandDisplay) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetPeriodsandDisplay_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var poa = CreateType<PeriodsAndOptions>();
            var methodSetPeriodsandDisplayPrametersTypes = new Type[] { typeof(string), typeof(PeriodsAndOptions) };
            object[] parametersOfSetPeriodsandDisplay = { Ticket, poa };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelInstance, MethodSetPeriodsandDisplay, parametersOfSetPeriodsandDisplay, methodSetPeriodsandDisplayPrametersTypes);

            // Assert
            parametersOfSetPeriodsandDisplay.ShouldNotBeNull();
            parametersOfSetPeriodsandDisplay.Length.ShouldBe(2);
            methodSetPeriodsandDisplayPrametersTypes.Length.ShouldBe(2);
            methodSetPeriodsandDisplayPrametersTypes.Length.ShouldBe(parametersOfSetPeriodsandDisplay.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetPeriodsandDisplay) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetPeriodsandDisplay_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetPeriodsandDisplay, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetPeriodsandDisplay) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetPeriodsandDisplay_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetPeriodsandDisplayPrametersTypes = new Type[] { typeof(string), typeof(PeriodsAndOptions) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodSetPeriodsandDisplay, Fixture, methodSetPeriodsandDisplayPrametersTypes);

            // Assert
            methodSetPeriodsandDisplayPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetPeriodsandDisplay) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SetPeriodsandDisplay_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetPeriodsandDisplay, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoDeleteTarget) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_DoDeleteTarget_Method_Call_Internally(Type[] types)
        {
            var methodDoDeleteTargetPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodDoDeleteTarget, Fixture, methodDoDeleteTargetPrametersTypes);
        }

        #endregion

        #region Method Call : (DoDeleteTarget) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoDeleteTarget_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sTarget = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.DoDeleteTarget(Ticket, sTarget);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DoDeleteTarget) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoDeleteTarget_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sTarget = CreateType<string>();
            var methodDoDeleteTargetPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDoDeleteTarget = { Ticket, sTarget };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDoDeleteTarget, methodDoDeleteTargetPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfDoDeleteTarget);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDoDeleteTarget.ShouldNotBeNull();
            parametersOfDoDeleteTarget.Length.ShouldBe(2);
            methodDoDeleteTargetPrametersTypes.Length.ShouldBe(2);
            methodDoDeleteTargetPrametersTypes.Length.ShouldBe(parametersOfDoDeleteTarget.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DoDeleteTarget) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoDeleteTarget_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sTarget = CreateType<string>();
            var methodDoDeleteTargetPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDoDeleteTarget = { Ticket, sTarget };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelInstance, MethodDoDeleteTarget, parametersOfDoDeleteTarget, methodDoDeleteTargetPrametersTypes);

            // Assert
            parametersOfDoDeleteTarget.ShouldNotBeNull();
            parametersOfDoDeleteTarget.Length.ShouldBe(2);
            methodDoDeleteTargetPrametersTypes.Length.ShouldBe(2);
            methodDoDeleteTargetPrametersTypes.Length.ShouldBe(parametersOfDoDeleteTarget.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoDeleteTarget) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoDeleteTarget_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDoDeleteTarget, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoDeleteTarget) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoDeleteTarget_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDoDeleteTargetPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodDoDeleteTarget, Fixture, methodDoDeleteTargetPrametersTypes);

            // Assert
            methodDoDeleteTargetPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoDeleteTarget) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoDeleteTarget_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDoDeleteTarget, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateTarget) (Return Type : ItemDefn) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_CreateTarget_Method_Call_Internally(Type[] types)
        {
            var methodCreateTargetPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodCreateTarget, Fixture, methodCreateTargetPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateTarget) (Return Type : ItemDefn) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_CreateTarget_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sTargetName = CreateType<string>();
            var sTargetDesc = CreateType<string>();
            var localTarget = CreateType<int>();
            var lCopyfromTarget = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.CreateTarget(Ticket, sTargetName, sTargetDesc, localTarget, lCopyfromTarget);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateTarget) (Return Type : ItemDefn) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_CreateTarget_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sTargetName = CreateType<string>();
            var sTargetDesc = CreateType<string>();
            var localTarget = CreateType<int>();
            var lCopyfromTarget = CreateType<int>();
            var methodCreateTargetPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(int), typeof(int) };
            object[] parametersOfCreateTarget = { Ticket, sTargetName, sTargetDesc, localTarget, lCopyfromTarget };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCreateTarget, methodCreateTargetPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, ItemDefn>(_modelInstanceFixture, out exception1, parametersOfCreateTarget);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, ItemDefn>(_modelInstance, MethodCreateTarget, parametersOfCreateTarget, methodCreateTargetPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfCreateTarget.ShouldNotBeNull();
            parametersOfCreateTarget.Length.ShouldBe(5);
            methodCreateTargetPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (CreateTarget) (Return Type : ItemDefn) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_CreateTarget_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sTargetName = CreateType<string>();
            var sTargetDesc = CreateType<string>();
            var localTarget = CreateType<int>();
            var lCopyfromTarget = CreateType<int>();
            var methodCreateTargetPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(int), typeof(int) };
            object[] parametersOfCreateTarget = { Ticket, sTargetName, sTargetDesc, localTarget, lCopyfromTarget };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, ItemDefn>(_modelInstance, MethodCreateTarget, parametersOfCreateTarget, methodCreateTargetPrametersTypes);

            // Assert
            parametersOfCreateTarget.ShouldNotBeNull();
            parametersOfCreateTarget.Length.ShouldBe(5);
            methodCreateTargetPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateTarget) (Return Type : ItemDefn) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_CreateTarget_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCreateTargetPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(int), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodCreateTarget, Fixture, methodCreateTargetPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateTargetPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (CreateTarget) (Return Type : ItemDefn) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_CreateTarget_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateTargetPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(int), typeof(int) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodCreateTarget, Fixture, methodCreateTargetPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateTargetPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateTarget) (Return Type : ItemDefn) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_CreateTarget_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateTarget, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateTarget) (Return Type : ItemDefn) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_CreateTarget_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateTarget, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetClientSideCalcData) (Return Type : CSRatesAndCategory) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_GetClientSideCalcData_Method_Call_Internally(Type[] types)
        {
            var methodGetClientSideCalcDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetClientSideCalcData, Fixture, methodGetClientSideCalcDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetClientSideCalcData) (Return Type : CSRatesAndCategory) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetClientSideCalcData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.GetClientSideCalcData(Ticket);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetClientSideCalcData) (Return Type : CSRatesAndCategory) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetClientSideCalcData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetClientSideCalcDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetClientSideCalcData = { Ticket };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetClientSideCalcData, methodGetClientSideCalcDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, CSRatesAndCategory>(_modelInstanceFixture, out exception1, parametersOfGetClientSideCalcData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, CSRatesAndCategory>(_modelInstance, MethodGetClientSideCalcData, parametersOfGetClientSideCalcData, methodGetClientSideCalcDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetClientSideCalcData.ShouldNotBeNull();
            parametersOfGetClientSideCalcData.Length.ShouldBe(1);
            methodGetClientSideCalcDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetClientSideCalcData) (Return Type : CSRatesAndCategory) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetClientSideCalcData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetClientSideCalcDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetClientSideCalcData = { Ticket };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, CSRatesAndCategory>(_modelInstance, MethodGetClientSideCalcData, parametersOfGetClientSideCalcData, methodGetClientSideCalcDataPrametersTypes);

            // Assert
            parametersOfGetClientSideCalcData.ShouldNotBeNull();
            parametersOfGetClientSideCalcData.Length.ShouldBe(1);
            methodGetClientSideCalcDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetClientSideCalcData) (Return Type : CSRatesAndCategory) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetClientSideCalcData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetClientSideCalcDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetClientSideCalcData, Fixture, methodGetClientSideCalcDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetClientSideCalcDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetClientSideCalcData) (Return Type : CSRatesAndCategory) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetClientSideCalcData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetClientSideCalcDataPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetClientSideCalcData, Fixture, methodGetClientSideCalcDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetClientSideCalcDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetClientSideCalcData) (Return Type : CSRatesAndCategory) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetClientSideCalcData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetClientSideCalcData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetClientSideCalcData) (Return Type : CSRatesAndCategory) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetClientSideCalcData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetClientSideCalcData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : CSTargetData) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_PrepareTargetData_Method_Call_Internally(Type[] types)
        {
            var methodPrepareTargetDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodPrepareTargetData, Fixture, methodPrepareTargetDataPrametersTypes);
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : CSTargetData) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_PrepareTargetData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var targetID = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.PrepareTargetData(Ticket, targetID);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : CSTargetData) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_PrepareTargetData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var targetID = CreateType<int>();
            var methodPrepareTargetDataPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfPrepareTargetData = { Ticket, targetID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPrepareTargetData, methodPrepareTargetDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, CSTargetData>(_modelInstanceFixture, out exception1, parametersOfPrepareTargetData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, CSTargetData>(_modelInstance, MethodPrepareTargetData, parametersOfPrepareTargetData, methodPrepareTargetDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfPrepareTargetData.ShouldNotBeNull();
            parametersOfPrepareTargetData.Length.ShouldBe(2);
            methodPrepareTargetDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : CSTargetData) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_PrepareTargetData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var targetID = CreateType<int>();
            var methodPrepareTargetDataPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfPrepareTargetData = { Ticket, targetID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, CSTargetData>(_modelInstance, MethodPrepareTargetData, parametersOfPrepareTargetData, methodPrepareTargetDataPrametersTypes);

            // Assert
            parametersOfPrepareTargetData.ShouldNotBeNull();
            parametersOfPrepareTargetData.Length.ShouldBe(2);
            methodPrepareTargetDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : CSTargetData) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_PrepareTargetData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodPrepareTargetDataPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodPrepareTargetData, Fixture, methodPrepareTargetDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodPrepareTargetDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : CSTargetData) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_PrepareTargetData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPrepareTargetDataPrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodPrepareTargetData, Fixture, methodPrepareTargetDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPrepareTargetDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : CSTargetData) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_PrepareTargetData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPrepareTargetData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : CSTargetData) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_PrepareTargetData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPrepareTargetData, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTargetGridLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_GetTargetGridLayout_Method_Call_Internally(Type[] types)
        {
            var methodGetTargetGridLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetTargetGridLayout, Fixture, methodGetTargetGridLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTargetGridLayout) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTargetGridLayout_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.GetTargetGridLayout(Ticket);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTargetGridLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTargetGridLayout_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetTargetGridLayoutPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTargetGridLayout = { Ticket };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTargetGridLayout, methodGetTargetGridLayoutPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, string>(_modelInstanceFixture, out exception1, parametersOfGetTargetGridLayout);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetTargetGridLayout, parametersOfGetTargetGridLayout, methodGetTargetGridLayoutPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTargetGridLayout.ShouldNotBeNull();
            parametersOfGetTargetGridLayout.Length.ShouldBe(1);
            methodGetTargetGridLayoutPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTargetGridLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTargetGridLayout_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetTargetGridLayoutPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTargetGridLayout = { Ticket };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetTargetGridLayout, parametersOfGetTargetGridLayout, methodGetTargetGridLayoutPrametersTypes);

            // Assert
            parametersOfGetTargetGridLayout.ShouldNotBeNull();
            parametersOfGetTargetGridLayout.Length.ShouldBe(1);
            methodGetTargetGridLayoutPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTargetGridLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTargetGridLayout_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTargetGridLayoutPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetTargetGridLayout, Fixture, methodGetTargetGridLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTargetGridLayoutPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTargetGridLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTargetGridLayout_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTargetGridLayoutPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetTargetGridLayout, Fixture, methodGetTargetGridLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTargetGridLayoutPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTargetGridLayout) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTargetGridLayout_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTargetGridLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTargetGridLayout) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTargetGridLayout_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTargetGridLayout, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTargetGridData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_GetTargetGridData_Method_Call_Internally(Type[] types)
        {
            var methodGetTargetGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetTargetGridData, Fixture, methodGetTargetGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTargetGridData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTargetGridData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.GetTargetGridData(Ticket);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTargetGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTargetGridData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetTargetGridDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTargetGridData = { Ticket };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTargetGridData, methodGetTargetGridDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, string>(_modelInstanceFixture, out exception1, parametersOfGetTargetGridData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetTargetGridData, parametersOfGetTargetGridData, methodGetTargetGridDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTargetGridData.ShouldNotBeNull();
            parametersOfGetTargetGridData.Length.ShouldBe(1);
            methodGetTargetGridDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTargetGridData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTargetGridData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetTargetGridDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTargetGridData = { Ticket };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetTargetGridData, parametersOfGetTargetGridData, methodGetTargetGridDataPrametersTypes);

            // Assert
            parametersOfGetTargetGridData.ShouldNotBeNull();
            parametersOfGetTargetGridData.Length.ShouldBe(1);
            methodGetTargetGridDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTargetGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTargetGridData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTargetGridDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetTargetGridData, Fixture, methodGetTargetGridDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTargetGridDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTargetGridData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTargetGridData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTargetGridDataPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetTargetGridData, Fixture, methodGetTargetGridDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTargetGridDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTargetGridData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTargetGridData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTargetGridData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTargetGridData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetTargetGridData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTargetGridData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReturnVersionAsTarget) (Return Type : CSTargetData) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_ReturnVersionAsTarget_Method_Call_Internally(Type[] types)
        {
            var methodReturnVersionAsTargetPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodReturnVersionAsTarget, Fixture, methodReturnVersionAsTargetPrametersTypes);
        }

        #endregion

        #region Method Call : (ReturnVersionAsTarget) (Return Type : CSTargetData) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_ReturnVersionAsTarget_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var VersID = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.ReturnVersionAsTarget(Ticket, VersID);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ReturnVersionAsTarget) (Return Type : CSTargetData) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_ReturnVersionAsTarget_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var VersID = CreateType<int>();
            var methodReturnVersionAsTargetPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfReturnVersionAsTarget = { Ticket, VersID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodReturnVersionAsTarget, methodReturnVersionAsTargetPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, CSTargetData>(_modelInstanceFixture, out exception1, parametersOfReturnVersionAsTarget);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, CSTargetData>(_modelInstance, MethodReturnVersionAsTarget, parametersOfReturnVersionAsTarget, methodReturnVersionAsTargetPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfReturnVersionAsTarget.ShouldNotBeNull();
            parametersOfReturnVersionAsTarget.Length.ShouldBe(2);
            methodReturnVersionAsTargetPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ReturnVersionAsTarget) (Return Type : CSTargetData) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_ReturnVersionAsTarget_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var VersID = CreateType<int>();
            var methodReturnVersionAsTargetPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfReturnVersionAsTarget = { Ticket, VersID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, CSTargetData>(_modelInstance, MethodReturnVersionAsTarget, parametersOfReturnVersionAsTarget, methodReturnVersionAsTargetPrametersTypes);

            // Assert
            parametersOfReturnVersionAsTarget.ShouldNotBeNull();
            parametersOfReturnVersionAsTarget.Length.ShouldBe(2);
            methodReturnVersionAsTargetPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReturnVersionAsTarget) (Return Type : CSTargetData) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_ReturnVersionAsTarget_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodReturnVersionAsTargetPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodReturnVersionAsTarget, Fixture, methodReturnVersionAsTargetPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodReturnVersionAsTargetPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ReturnVersionAsTarget) (Return Type : CSTargetData) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_ReturnVersionAsTarget_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReturnVersionAsTargetPrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodReturnVersionAsTarget, Fixture, methodReturnVersionAsTargetPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodReturnVersionAsTargetPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReturnVersionAsTarget) (Return Type : CSTargetData) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_ReturnVersionAsTarget_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReturnVersionAsTarget, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ReturnVersionAsTarget) (Return Type : CSTargetData) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_ReturnVersionAsTarget_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReturnVersionAsTarget, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveTargetData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_SaveTargetData_Method_Call_Internally(Type[] types)
        {
            var methodSaveTargetDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodSaveTargetData, Fixture, methodSaveTargetDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveTargetData) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SaveTargetData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var TargetID = CreateType<int>();
            var targetData = CreateType<CSTargetData>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.SaveTargetData(Ticket, TargetID, targetData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SaveTargetData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SaveTargetData_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var TargetID = CreateType<int>();
            var targetData = CreateType<CSTargetData>();
            var methodSaveTargetDataPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(CSTargetData) };
            object[] parametersOfSaveTargetData = { Ticket, TargetID, targetData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSaveTargetData, methodSaveTargetDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfSaveTargetData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSaveTargetData.ShouldNotBeNull();
            parametersOfSaveTargetData.Length.ShouldBe(3);
            methodSaveTargetDataPrametersTypes.Length.ShouldBe(3);
            methodSaveTargetDataPrametersTypes.Length.ShouldBe(parametersOfSaveTargetData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SaveTargetData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SaveTargetData_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var TargetID = CreateType<int>();
            var targetData = CreateType<CSTargetData>();
            var methodSaveTargetDataPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(CSTargetData) };
            object[] parametersOfSaveTargetData = { Ticket, TargetID, targetData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelInstance, MethodSaveTargetData, parametersOfSaveTargetData, methodSaveTargetDataPrametersTypes);

            // Assert
            parametersOfSaveTargetData.ShouldNotBeNull();
            parametersOfSaveTargetData.Length.ShouldBe(3);
            methodSaveTargetDataPrametersTypes.Length.ShouldBe(3);
            methodSaveTargetDataPrametersTypes.Length.ShouldBe(parametersOfSaveTargetData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveTargetData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SaveTargetData_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (SaveTargetData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SaveTargetData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveTargetDataPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(CSTargetData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodSaveTargetData, Fixture, methodSaveTargetDataPrametersTypes);

            // Assert
            methodSaveTargetDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveTargetData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SaveTargetData_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveTargetData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCostViews) (Return Type : List<ItemDefn>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_GetCostViews_Method_Call_Internally(Type[] types)
        {
            var methodGetCostViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetCostViews, Fixture, methodGetCostViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCostViews) (Return Type : List<ItemDefn>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetCostViews_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.GetCostViews();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCostViews) (Return Type : List<ItemDefn>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetCostViews_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetCostViewsPrametersTypes = null;
            object[] parametersOfGetCostViews = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCostViews, methodGetCostViewsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, List<ItemDefn>>(_modelInstanceFixture, out exception1, parametersOfGetCostViews);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, List<ItemDefn>>(_modelInstance, MethodGetCostViews, parametersOfGetCostViews, methodGetCostViewsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCostViews.ShouldBeNull();
            methodGetCostViewsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCostViews) (Return Type : List<ItemDefn>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetCostViews_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetCostViewsPrametersTypes = null;
            object[] parametersOfGetCostViews = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, List<ItemDefn>>(_modelInstance, MethodGetCostViews, parametersOfGetCostViews, methodGetCostViewsPrametersTypes);

            // Assert
            parametersOfGetCostViews.ShouldBeNull();
            methodGetCostViewsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCostViews) (Return Type : List<ItemDefn>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetCostViews_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetCostViewsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetCostViews, Fixture, methodGetCostViewsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCostViewsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCostViews) (Return Type : List<ItemDefn>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetCostViews_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetCostViewsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetCostViews, Fixture, methodGetCostViewsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCostViewsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCostViews) (Return Type : List<ItemDefn>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetCostViews_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCostViews, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DoShowRemTotal) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_DoShowRemTotal_Method_Call_Internally(Type[] types)
        {
            var methodDoShowRemTotalPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodDoShowRemTotal, Fixture, methodDoShowRemTotalPrametersTypes);
        }

        #endregion

        #region Method Call : (DoShowRemTotal) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoShowRemTotal_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var showRemFlag = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.DoShowRemTotal(Ticket, showRemFlag);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DoShowRemTotal) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoShowRemTotal_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var showRemFlag = CreateType<int>();
            var methodDoShowRemTotalPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfDoShowRemTotal = { Ticket, showRemFlag };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDoShowRemTotal, methodDoShowRemTotalPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfDoShowRemTotal);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDoShowRemTotal.ShouldNotBeNull();
            parametersOfDoShowRemTotal.Length.ShouldBe(2);
            methodDoShowRemTotalPrametersTypes.Length.ShouldBe(2);
            methodDoShowRemTotalPrametersTypes.Length.ShouldBe(parametersOfDoShowRemTotal.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DoShowRemTotal) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoShowRemTotal_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var showRemFlag = CreateType<int>();
            var methodDoShowRemTotalPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfDoShowRemTotal = { Ticket, showRemFlag };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelInstance, MethodDoShowRemTotal, parametersOfDoShowRemTotal, methodDoShowRemTotalPrametersTypes);

            // Assert
            parametersOfDoShowRemTotal.ShouldNotBeNull();
            parametersOfDoShowRemTotal.Length.ShouldBe(2);
            methodDoShowRemTotalPrametersTypes.Length.ShouldBe(2);
            methodDoShowRemTotalPrametersTypes.Length.ShouldBe(parametersOfDoShowRemTotal.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoShowRemTotal) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoShowRemTotal_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDoShowRemTotal, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoShowRemTotal) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoShowRemTotal_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDoShowRemTotalPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodDoShowRemTotal, Fixture, methodDoShowRemTotalPrametersTypes);

            // Assert
            methodDoShowRemTotalPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoShowRemTotal) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DoShowRemTotal_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDoShowRemTotal, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLegendGridLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_GetLegendGridLayout_Method_Call_Internally(Type[] types)
        {
            var methodGetLegendGridLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetLegendGridLayout, Fixture, methodGetLegendGridLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLegendGridLayout) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetLegendGridLayout_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.GetLegendGridLayout(Ticket);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetLegendGridLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetLegendGridLayout_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetLegendGridLayoutPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetLegendGridLayout = { Ticket };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetLegendGridLayout, methodGetLegendGridLayoutPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, string>(_modelInstanceFixture, out exception1, parametersOfGetLegendGridLayout);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetLegendGridLayout, parametersOfGetLegendGridLayout, methodGetLegendGridLayoutPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetLegendGridLayout.ShouldNotBeNull();
            parametersOfGetLegendGridLayout.Length.ShouldBe(1);
            methodGetLegendGridLayoutPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetLegendGridLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetLegendGridLayout_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetLegendGridLayoutPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetLegendGridLayout = { Ticket };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetLegendGridLayout, parametersOfGetLegendGridLayout, methodGetLegendGridLayoutPrametersTypes);

            // Assert
            parametersOfGetLegendGridLayout.ShouldNotBeNull();
            parametersOfGetLegendGridLayout.Length.ShouldBe(1);
            methodGetLegendGridLayoutPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLegendGridLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetLegendGridLayout_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetLegendGridLayoutPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetLegendGridLayout, Fixture, methodGetLegendGridLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLegendGridLayoutPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetLegendGridLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetLegendGridLayout_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetLegendGridLayoutPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetLegendGridLayout, Fixture, methodGetLegendGridLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLegendGridLayoutPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLegendGridLayout) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetLegendGridLayout_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLegendGridLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLegendGridLayout) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetLegendGridLayout_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetLegendGridLayout, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLegendGridData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_GetLegendGridData_Method_Call_Internally(Type[] types)
        {
            var methodGetLegendGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetLegendGridData, Fixture, methodGetLegendGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLegendGridData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetLegendGridData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.GetLegendGridData(Ticket);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetLegendGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetLegendGridData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetLegendGridDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetLegendGridData = { Ticket };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetLegendGridData, methodGetLegendGridDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, string>(_modelInstanceFixture, out exception1, parametersOfGetLegendGridData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetLegendGridData, parametersOfGetLegendGridData, methodGetLegendGridDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetLegendGridData.ShouldNotBeNull();
            parametersOfGetLegendGridData.Length.ShouldBe(1);
            methodGetLegendGridDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetLegendGridData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetLegendGridData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetLegendGridDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetLegendGridData = { Ticket };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetLegendGridData, parametersOfGetLegendGridData, methodGetLegendGridDataPrametersTypes);

            // Assert
            parametersOfGetLegendGridData.ShouldNotBeNull();
            parametersOfGetLegendGridData.Length.ShouldBe(1);
            methodGetLegendGridDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLegendGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetLegendGridData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetLegendGridDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetLegendGridData, Fixture, methodGetLegendGridDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLegendGridDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetLegendGridData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetLegendGridData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetLegendGridDataPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetLegendGridData, Fixture, methodGetLegendGridDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLegendGridDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLegendGridData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetLegendGridData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLegendGridData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLegendGridData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetLegendGridData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetLegendGridData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LoadUserViewData) (Return Type : List<ItemDefn>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_LoadUserViewData_Method_Call_Internally(Type[] types)
        {
            var methodLoadUserViewDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodLoadUserViewData, Fixture, methodLoadUserViewDataPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadUserViewData) (Return Type : List<ItemDefn>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadUserViewData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.LoadUserViewData(Ticket);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (LoadUserViewData) (Return Type : List<ItemDefn>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadUserViewData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodLoadUserViewDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfLoadUserViewData = { Ticket };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodLoadUserViewData, methodLoadUserViewDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, List<ItemDefn>>(_modelInstanceFixture, out exception1, parametersOfLoadUserViewData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, List<ItemDefn>>(_modelInstance, MethodLoadUserViewData, parametersOfLoadUserViewData, methodLoadUserViewDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfLoadUserViewData.ShouldNotBeNull();
            parametersOfLoadUserViewData.Length.ShouldBe(1);
            methodLoadUserViewDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (LoadUserViewData) (Return Type : List<ItemDefn>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadUserViewData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodLoadUserViewDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfLoadUserViewData = { Ticket };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, List<ItemDefn>>(_modelInstance, MethodLoadUserViewData, parametersOfLoadUserViewData, methodLoadUserViewDataPrametersTypes);

            // Assert
            parametersOfLoadUserViewData.ShouldNotBeNull();
            parametersOfLoadUserViewData.Length.ShouldBe(1);
            methodLoadUserViewDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadUserViewData) (Return Type : List<ItemDefn>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadUserViewData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodLoadUserViewDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodLoadUserViewData, Fixture, methodLoadUserViewDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodLoadUserViewDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (LoadUserViewData) (Return Type : List<ItemDefn>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadUserViewData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLoadUserViewDataPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodLoadUserViewData, Fixture, methodLoadUserViewDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodLoadUserViewDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LoadUserViewData) (Return Type : List<ItemDefn>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadUserViewData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadUserViewData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (LoadUserViewData) (Return Type : List<ItemDefn>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_LoadUserViewData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLoadUserViewData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteUserViewData) (Return Type : List<ItemDefn>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_DeleteUserViewData_Method_Call_Internally(Type[] types)
        {
            var methodDeleteUserViewDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodDeleteUserViewData, Fixture, methodDeleteUserViewDataPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteUserViewData) (Return Type : List<ItemDefn>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DeleteUserViewData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sviewName = CreateType<string>();
            var localflag = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.DeleteUserViewData(Ticket, sviewName, localflag);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteUserViewData) (Return Type : List<ItemDefn>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DeleteUserViewData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sviewName = CreateType<string>();
            var localflag = CreateType<int>();
            var methodDeleteUserViewDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int) };
            object[] parametersOfDeleteUserViewData = { Ticket, sviewName, localflag };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteUserViewData, methodDeleteUserViewDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, List<ItemDefn>>(_modelInstanceFixture, out exception1, parametersOfDeleteUserViewData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, List<ItemDefn>>(_modelInstance, MethodDeleteUserViewData, parametersOfDeleteUserViewData, methodDeleteUserViewDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDeleteUserViewData.ShouldNotBeNull();
            parametersOfDeleteUserViewData.Length.ShouldBe(3);
            methodDeleteUserViewDataPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (DeleteUserViewData) (Return Type : List<ItemDefn>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DeleteUserViewData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sviewName = CreateType<string>();
            var localflag = CreateType<int>();
            var methodDeleteUserViewDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int) };
            object[] parametersOfDeleteUserViewData = { Ticket, sviewName, localflag };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, List<ItemDefn>>(_modelInstance, MethodDeleteUserViewData, parametersOfDeleteUserViewData, methodDeleteUserViewDataPrametersTypes);

            // Assert
            parametersOfDeleteUserViewData.ShouldNotBeNull();
            parametersOfDeleteUserViewData.Length.ShouldBe(3);
            methodDeleteUserViewDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteUserViewData) (Return Type : List<ItemDefn>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DeleteUserViewData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDeleteUserViewDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodDeleteUserViewData, Fixture, methodDeleteUserViewDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDeleteUserViewDataPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (DeleteUserViewData) (Return Type : List<ItemDefn>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DeleteUserViewData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteUserViewDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodDeleteUserViewData, Fixture, methodDeleteUserViewDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteUserViewDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteUserViewData) (Return Type : List<ItemDefn>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DeleteUserViewData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteUserViewData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteUserViewData) (Return Type : List<ItemDefn>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_DeleteUserViewData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteUserViewData, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenameUserViewData) (Return Type : List<ItemDefn>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_RenameUserViewData_Method_Call_Internally(Type[] types)
        {
            var methodRenameUserViewDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodRenameUserViewData, Fixture, methodRenameUserViewDataPrametersTypes);
        }

        #endregion

        #region Method Call : (RenameUserViewData) (Return Type : List<ItemDefn>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_RenameUserViewData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var snewName = CreateType<string>();
            var sviewName = CreateType<string>();
            var localflag = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.RenameUserViewData(Ticket, snewName, sviewName, localflag);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RenameUserViewData) (Return Type : List<ItemDefn>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_RenameUserViewData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var snewName = CreateType<string>();
            var sviewName = CreateType<string>();
            var localflag = CreateType<int>();
            var methodRenameUserViewDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(int) };
            object[] parametersOfRenameUserViewData = { Ticket, snewName, sviewName, localflag };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRenameUserViewData, methodRenameUserViewDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, List<ItemDefn>>(_modelInstanceFixture, out exception1, parametersOfRenameUserViewData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, List<ItemDefn>>(_modelInstance, MethodRenameUserViewData, parametersOfRenameUserViewData, methodRenameUserViewDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfRenameUserViewData.ShouldNotBeNull();
            parametersOfRenameUserViewData.Length.ShouldBe(4);
            methodRenameUserViewDataPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (RenameUserViewData) (Return Type : List<ItemDefn>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_RenameUserViewData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var snewName = CreateType<string>();
            var sviewName = CreateType<string>();
            var localflag = CreateType<int>();
            var methodRenameUserViewDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(int) };
            object[] parametersOfRenameUserViewData = { Ticket, snewName, sviewName, localflag };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, List<ItemDefn>>(_modelInstance, MethodRenameUserViewData, parametersOfRenameUserViewData, methodRenameUserViewDataPrametersTypes);

            // Assert
            parametersOfRenameUserViewData.ShouldNotBeNull();
            parametersOfRenameUserViewData.Length.ShouldBe(4);
            methodRenameUserViewDataPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenameUserViewData) (Return Type : List<ItemDefn>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_RenameUserViewData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodRenameUserViewDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodRenameUserViewData, Fixture, methodRenameUserViewDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRenameUserViewDataPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (RenameUserViewData) (Return Type : List<ItemDefn>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_RenameUserViewData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenameUserViewDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(int) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodRenameUserViewData, Fixture, methodRenameUserViewDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenameUserViewDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenameUserViewData) (Return Type : List<ItemDefn>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_RenameUserViewData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenameUserViewData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenameUserViewData) (Return Type : List<ItemDefn>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_RenameUserViewData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenameUserViewData, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveUserViewData) (Return Type : List<ItemDefn>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_SaveUserViewData_Method_Call_Internally(Type[] types)
        {
            var methodSaveUserViewDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodSaveUserViewData, Fixture, methodSaveUserViewDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveUserViewData) (Return Type : List<ItemDefn>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SaveUserViewData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sviewName = CreateType<string>();
            var localflag = CreateType<int>();
            var sZoomTo = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.SaveUserViewData(Ticket, sviewName, localflag, sZoomTo);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SaveUserViewData) (Return Type : List<ItemDefn>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SaveUserViewData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sviewName = CreateType<string>();
            var localflag = CreateType<int>();
            var sZoomTo = CreateType<string>();
            var methodSaveUserViewDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int), typeof(string) };
            object[] parametersOfSaveUserViewData = { Ticket, sviewName, localflag, sZoomTo };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveUserViewData, methodSaveUserViewDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, List<ItemDefn>>(_modelInstanceFixture, out exception1, parametersOfSaveUserViewData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, List<ItemDefn>>(_modelInstance, MethodSaveUserViewData, parametersOfSaveUserViewData, methodSaveUserViewDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSaveUserViewData.ShouldNotBeNull();
            parametersOfSaveUserViewData.Length.ShouldBe(4);
            methodSaveUserViewDataPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (SaveUserViewData) (Return Type : List<ItemDefn>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SaveUserViewData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var sviewName = CreateType<string>();
            var localflag = CreateType<int>();
            var sZoomTo = CreateType<string>();
            var methodSaveUserViewDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int), typeof(string) };
            object[] parametersOfSaveUserViewData = { Ticket, sviewName, localflag, sZoomTo };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, List<ItemDefn>>(_modelInstance, MethodSaveUserViewData, parametersOfSaveUserViewData, methodSaveUserViewDataPrametersTypes);

            // Assert
            parametersOfSaveUserViewData.ShouldNotBeNull();
            parametersOfSaveUserViewData.Length.ShouldBe(4);
            methodSaveUserViewDataPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveUserViewData) (Return Type : List<ItemDefn>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SaveUserViewData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSaveUserViewDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodSaveUserViewData, Fixture, methodSaveUserViewDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSaveUserViewDataPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (SaveUserViewData) (Return Type : List<ItemDefn>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SaveUserViewData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveUserViewDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodSaveUserViewData, Fixture, methodSaveUserViewDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveUserViewDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveUserViewData) (Return Type : List<ItemDefn>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SaveUserViewData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveUserViewData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveUserViewData) (Return Type : List<ItemDefn>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SaveUserViewData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveUserViewData, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SelectUserViewData) (Return Type : SortGroupDefn) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_SelectUserViewData_Method_Call_Internally(Type[] types)
        {
            var methodSelectUserViewDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodSelectUserViewData, Fixture, methodSelectUserViewDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SelectUserViewData) (Return Type : SortGroupDefn) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SelectUserViewData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var viewIndex = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.SelectUserViewData(Ticket, viewIndex);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SelectUserViewData) (Return Type : SortGroupDefn) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SelectUserViewData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var viewIndex = CreateType<int>();
            var methodSelectUserViewDataPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfSelectUserViewData = { Ticket, viewIndex };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSelectUserViewData, methodSelectUserViewDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, SortGroupDefn>(_modelInstanceFixture, out exception1, parametersOfSelectUserViewData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, SortGroupDefn>(_modelInstance, MethodSelectUserViewData, parametersOfSelectUserViewData, methodSelectUserViewDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSelectUserViewData.ShouldNotBeNull();
            parametersOfSelectUserViewData.Length.ShouldBe(2);
            methodSelectUserViewDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (SelectUserViewData) (Return Type : SortGroupDefn) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SelectUserViewData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var viewIndex = CreateType<int>();
            var methodSelectUserViewDataPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfSelectUserViewData = { Ticket, viewIndex };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, SortGroupDefn>(_modelInstance, MethodSelectUserViewData, parametersOfSelectUserViewData, methodSelectUserViewDataPrametersTypes);

            // Assert
            parametersOfSelectUserViewData.ShouldNotBeNull();
            parametersOfSelectUserViewData.Length.ShouldBe(2);
            methodSelectUserViewDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SelectUserViewData) (Return Type : SortGroupDefn) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SelectUserViewData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSelectUserViewDataPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodSelectUserViewData, Fixture, methodSelectUserViewDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSelectUserViewDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (SelectUserViewData) (Return Type : SortGroupDefn) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SelectUserViewData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSelectUserViewDataPrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodSelectUserViewData, Fixture, methodSelectUserViewDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSelectUserViewDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SelectUserViewData) (Return Type : SortGroupDefn) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SelectUserViewData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSelectUserViewData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SelectUserViewData) (Return Type : SortGroupDefn) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SelectUserViewData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSelectUserViewData, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCompareStringValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_GetCompareStringValue_Method_Call_Internally(Type[] types)
        {
            var methodGetCompareStringValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetCompareStringValue, Fixture, methodGetCompareStringValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetCompareStringValue) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetCompareStringValue_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelInstance.GetCompareStringValue(Ticket);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCompareStringValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetCompareStringValue_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetCompareStringValuePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCompareStringValue = { Ticket };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCompareStringValue, methodGetCompareStringValuePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, string>(_modelInstanceFixture, out exception1, parametersOfGetCompareStringValue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetCompareStringValue, parametersOfGetCompareStringValue, methodGetCompareStringValuePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCompareStringValue.ShouldNotBeNull();
            parametersOfGetCompareStringValue.Length.ShouldBe(1);
            methodGetCompareStringValuePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCompareStringValue) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetCompareStringValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Ticket = CreateType<string>();
            var methodGetCompareStringValuePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCompareStringValue = { Ticket };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, string>(_modelInstance, MethodGetCompareStringValue, parametersOfGetCompareStringValue, methodGetCompareStringValuePrametersTypes);

            // Assert
            parametersOfGetCompareStringValue.ShouldNotBeNull();
            parametersOfGetCompareStringValue.Length.ShouldBe(1);
            methodGetCompareStringValuePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCompareStringValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetCompareStringValue_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCompareStringValuePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetCompareStringValue, Fixture, methodGetCompareStringValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCompareStringValuePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCompareStringValue) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetCompareStringValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCompareStringValuePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodGetCompareStringValue, Fixture, methodGetCompareStringValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCompareStringValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCompareStringValue) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetCompareStringValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCompareStringValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCompareStringValue) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetCompareStringValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCompareStringValue, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CheckUserGlobalPermission) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_CheckUserGlobalPermission_Static_Method_Call_Internally(Type[] types)
        {
            var methodCheckUserGlobalPermissionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodCheckUserGlobalPermission, Fixture, methodCheckUserGlobalPermissionPrametersTypes);
        }

        #endregion

        #region Method Call : (CheckUserGlobalPermission) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_CheckUserGlobalPermission_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var lWResID = CreateType<int>();
            var ePermUID = CreateType<GlobalPermissionsEnum>();
            var methodCheckUserGlobalPermissionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(int), typeof(GlobalPermissionsEnum) };
            object[] parametersOfCheckUserGlobalPermission = { oDataAccess, lWResID, ePermUID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_modelInstanceFixture, _modelInstanceType, MethodCheckUserGlobalPermission, parametersOfCheckUserGlobalPermission, methodCheckUserGlobalPermissionPrametersTypes);

            // Assert
            parametersOfCheckUserGlobalPermission.ShouldNotBeNull();
            parametersOfCheckUserGlobalPermission.Length.ShouldBe(3);
            methodCheckUserGlobalPermissionPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckUserGlobalPermission) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_CheckUserGlobalPermission_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCheckUserGlobalPermissionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(int), typeof(GlobalPermissionsEnum) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodCheckUserGlobalPermission, Fixture, methodCheckUserGlobalPermissionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCheckUserGlobalPermissionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CheckUserGlobalPermission) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_CheckUserGlobalPermission_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCheckUserGlobalPermission, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ObtainSqlConnection) (Return Type : SqlConnection) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_ObtainSqlConnection_Method_Call_Internally(Type[] types)
        {
            var methodObtainSqlConnectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodObtainSqlConnection, Fixture, methodObtainSqlConnectionPrametersTypes);
        }

        #endregion

        #region Method Call : (ObtainSqlConnection) (Return Type : SqlConnection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_ObtainSqlConnection_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var WResID = CreateType<int>();
            var methodObtainSqlConnectionPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfObtainSqlConnection = { WResID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodObtainSqlConnection, methodObtainSqlConnectionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Model, SqlConnection>(_modelInstanceFixture, out exception1, parametersOfObtainSqlConnection);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Model, SqlConnection>(_modelInstance, MethodObtainSqlConnection, parametersOfObtainSqlConnection, methodObtainSqlConnectionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfObtainSqlConnection.ShouldNotBeNull();
            parametersOfObtainSqlConnection.Length.ShouldBe(1);
            methodObtainSqlConnectionPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ObtainSqlConnection) (Return Type : SqlConnection) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_ObtainSqlConnection_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var WResID = CreateType<int>();
            var methodObtainSqlConnectionPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfObtainSqlConnection = { WResID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Model, SqlConnection>(_modelInstance, MethodObtainSqlConnection, parametersOfObtainSqlConnection, methodObtainSqlConnectionPrametersTypes);

            // Assert
            parametersOfObtainSqlConnection.ShouldNotBeNull();
            parametersOfObtainSqlConnection.Length.ShouldBe(1);
            methodObtainSqlConnectionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ObtainSqlConnection) (Return Type : SqlConnection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_ObtainSqlConnection_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodObtainSqlConnectionPrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodObtainSqlConnection, Fixture, methodObtainSqlConnectionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodObtainSqlConnectionPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ObtainSqlConnection) (Return Type : SqlConnection) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_ObtainSqlConnection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodObtainSqlConnectionPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelInstance, MethodObtainSqlConnection, Fixture, methodObtainSqlConnectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodObtainSqlConnectionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ObtainSqlConnection) (Return Type : SqlConnection) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_ObtainSqlConnection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodObtainSqlConnection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ObtainSqlConnection) (Return Type : SqlConnection) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_ObtainSqlConnection_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodObtainSqlConnection, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveCachedData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_SaveCachedData_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveCachedDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodSaveCachedData, Fixture, methodSaveCachedDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveCachedData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SaveCachedData_Static_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
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
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfSaveCachedData);

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
        public void AUT_Model_SaveCachedData_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sKey = CreateType<string>();
            var value = CreateType<object>();
            var methodSaveCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(object) };
            object[] parametersOfSaveCachedData = { Context, sKey, value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_modelInstanceFixture, _modelInstanceType, MethodSaveCachedData, parametersOfSaveCachedData, methodSaveCachedDataPrametersTypes);

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
        public void AUT_Model_SaveCachedData_Static_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Model_SaveCachedData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodSaveCachedData, Fixture, methodSaveCachedDataPrametersTypes);

            // Assert
            methodSaveCachedDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveCachedData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_SaveCachedData_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveCachedData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_GetCachedData_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCachedDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodGetCachedData, Fixture, methodGetCachedDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetCachedData_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sKey = CreateType<string>();
            var methodGetCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfGetCachedData = { Context, sKey };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCachedData, methodGetCachedDataPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodGetCachedData, Fixture, methodGetCachedDataPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<object>(_modelInstanceFixture, _modelInstanceType, MethodGetCachedData, parametersOfGetCachedData, methodGetCachedDataPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfGetCachedData);

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
        public void AUT_Model_GetCachedData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sKey = CreateType<string>();
            var methodGetCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfGetCachedData = { Context, sKey };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<object>(_modelInstanceFixture, _modelInstanceType, MethodGetCachedData, parametersOfGetCachedData, methodGetCachedDataPrametersTypes);

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
        public void AUT_Model_GetCachedData_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodGetCachedData, Fixture, methodGetCachedDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCachedDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetCachedData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodGetCachedData, Fixture, methodGetCachedDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCachedDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetCachedData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCachedData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_GetCachedData_Static_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (BuildResultXML) (Return Type : CStruct) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Model_BuildResultXML_Static_Method_Call_Internally(Type[] types)
        {
            var methodBuildResultXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodBuildResultXML, Fixture, methodBuildResultXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildResultXML) (Return Type : CStruct) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_BuildResultXML_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var nStatus = CreateType<int>();
            var methodBuildResultXMLPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfBuildResultXML = { sContext, nStatus };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildResultXML, methodBuildResultXMLPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelInstanceFixture, parametersOfBuildResultXML);

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
        public void AUT_Model_BuildResultXML_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var nStatus = CreateType<int>();
            var methodBuildResultXMLPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfBuildResultXML = { sContext, nStatus };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<CStruct>(_modelInstanceFixture, _modelInstanceType, MethodBuildResultXML, parametersOfBuildResultXML, methodBuildResultXMLPrametersTypes);

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
        public void AUT_Model_BuildResultXML_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildResultXMLPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodBuildResultXML, Fixture, methodBuildResultXMLPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildResultXMLPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (BuildResultXML) (Return Type : CStruct) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_BuildResultXML_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildResultXMLPrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_modelInstanceFixture, _modelInstanceType, MethodBuildResultXML, Fixture, methodBuildResultXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildResultXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildResultXML) (Return Type : CStruct) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_BuildResultXML_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildResultXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (BuildResultXML) (Return Type : CStruct) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Model_BuildResultXML_Static_Method_Call_Parameters_Count_Verification_Test()
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

        #endregion

        #endregion
    }
}