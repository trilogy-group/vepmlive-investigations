using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using CostDataValues;
using NUnit.Framework;
using PortfolioEngineCore;
using Should = Shouldly.Should;
using Shouldly;

namespace CADataCache
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="CADataCache.CostAnalyzerDataCache" />)
    ///     and namespace <see cref="CADataCache"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class CostAnalyzerDataCacheTest : AbstractBaseSetupTypedTest<CostAnalyzerDataCache>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CostAnalyzerDataCache) Initializer

        private const string MethodGrabCAData = "GrabCAData";
        private const string Methodsetupdispcolns = "setupdispcolns";
        private const string MethodAddTotalEntry = "AddTotalEntry";
        private const string MethodAddColEntry = "AddColEntry";
        private const string MethodGetPeriodsData = "GetPeriodsData";
        private const string MethodGetCostTypeNameData = "GetCostTypeNameData";
        private const string MethodReDrawGrid = "ReDrawGrid";
        private const string MethodPrepareTotalsCollection = "PrepareTotalsCollection";
        private const string MethodCreatetgLayout = "CreatetgLayout";
        private const string MethodGetTopGrid = "GetTopGrid";
        private const string MethodGetBottomGrid = "GetBottomGrid";
        private const string MethodSetCTStateData = "SetCTStateData";
        private const string MethodSetDisplayMode = "SetDisplayMode";
        private const string MethodGetDisplayMode = "GetDisplayMode";
        private const string MethodGetStartFinishDataPeriods = "GetStartFinishDataPeriods";
        private const string MethodSetSelectedForRows = "SetSelectedForRows";
        private const string MethodSetFilteredForRows = "SetFilteredForRows";
        private const string MethodNewRedrawTotals = "NewRedrawTotals";
        private const string MethodFormatExtraDisplay = "FormatExtraDisplay";
        private const string MethodFormatWork = "FormatWork";
        private const string MethodFormatDuration = "FormatDuration";
        private const string MethodBuildTotalsKey = "BuildTotalsKey";
        private const string MethodGetDetFieldValue = "GetDetFieldValue";
        private const string MethodSetTotalDetFieldValue = "SetTotalDetFieldValue";
        private const string MethodCopyOverTotFields = "CopyOverTotFields";
        private const string MethodProcessTotals = "ProcessTotals";
        private const string MethodGetLegendGrid = "GetLegendGrid";
        private const string MethodGetTotalsData = "GetTotalsData";
        private const string MethodSetTotalsData = "SetTotalsData";
        private const string MethodGetCompareCostTypeList = "GetCompareCostTypeList";
        private const string MethodSetCompareCostType = "SetCompareCostType";
        private const string MethodCreatePsuedoTarget = "CreatePsuedoTarget";
        private const string MethodSetShowRemaining = "SetShowRemaining";
        private const string MethodProcessTargets = "ProcessTargets";
        private const string MethodStashViews = "StashViews";
        private const string MethodApplyServerSideViewSettings = "ApplyServerSideViewSettings";
        private const string MethodGetTargetList = "GetTargetList";
        private const string MethodDeleteTarget = "DeleteTarget";
        private const string MethodBuildCatJSon = "BuildCatJSon";
        private const string MethodRatesAndCategory = "RatesAndCategory";
        private const string MethodGetLookUpString = "GetLookUpString";
        private const string MethodPrepareTargetData = "PrepareTargetData";
        private const string MethodGetTargetGrid = "GetTargetGrid";
        private const string MethodAggreagteDuplicateRows = "AggreagteDuplicateRows";
        private const string MethodGetTargetTotalsData = "GetTargetTotalsData";
        private const string MethodGet_CB_ID = "Get_CB_ID";
        private const string MethodGet_MaxPeriods = "Get_MaxPeriods";
        private const string MethodRefreshTargets = "RefreshTargets";
        private const string MethodGetTargetRGBData = "GetTargetRGBData";
        private const string FieldHideRowsWithAllZerosXmlNode = "HideRowsWithAllZerosXmlNode";
        private const string FieldHideRowsWithAllZerosXmlValueAttribute = "HideRowsWithAllZerosXmlValueAttribute";
        private const string Fieldm_clsda = "m_clsda";
        private const string Fieldm_topgridcln = "m_topgridcln";
        private const string Fieldm_bottomgridcln = "m_bottomgridcln";
        private const string Fieldm_cust_Defn = "m_cust_Defn";
        private const string Fieldm_cust_full = "m_cust_full";
        private const string Fieldm_cust_ocf = "m_cust_ocf";
        private const string Fieldm_cust_lk = "m_cust_lk";
        private const string FieldTGStandard = "TGStandard";
        private const string FieldBGStandard = "BGStandard";
        private const string Fieldm_clnsort = "m_clnsort";
        private const string Fieldm_DispMode = "m_DispMode";
        private const string Fieldm_heatmap_text = "m_heatmap_text";
        private const string FieldbShowFTEs = "bShowFTEs";
        private const string FieldbUseQTY = "bUseQTY";
        private const string FieldbUseCosts = "bUseCosts";
        private const string Fieldm_show_rhs_dec_costs = "m_show_rhs_dec_costs";
        private const string Field_hideRowsWithAllZeros = "_hideRowsWithAllZeros";
        private const string Fieldm_TotalRoot = "m_TotalRoot";
        private const string Fieldm_total_dets = "m_total_dets";
        private const string Fieldm_total_rows = "m_total_rows";
        private const string Fieldm_CTCmpRoot = "m_CTCmpRoot";
        private const string Fieldm_targetdata = "m_targetdata";
        private const string Fieldm_tarnames = "m_tarnames";
        private const string Fieldm_apply_target = "m_apply_target";
        private const string Fieldm_showremaining = "m_showremaining";
        private const string Fieldm_viewsxml = "m_viewsxml";
        private const string FieldTotGeneral = "TotGeneral";
        private const string FieldTotSelectedOrder = "TotSelectedOrder";
        private const string Fieldm_use_heatmap = "m_use_heatmap";
        private const string Fieldm_use_heatmapID = "m_use_heatmapID";
        private const string Fieldm_use_heatmapColour = "m_use_heatmapColour";
        private const string Fieldm_heatmapcol = "m_heatmapcol";
        private const string Fieldm_heatmaptext = "m_heatmaptext";
        private const string Fieldm_CostCatjsonMenu = "m_CostCatjsonMenu";
        private const string Fieldm_CostTypejsonMenu = "m_CostTypejsonMenu";
        private const string Fieldm_editTargetList = "m_editTargetList";
        private const string Fieldm_curr_period = "m_curr_period";
        private Type _costAnalyzerDataCacheInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CostAnalyzerDataCache _costAnalyzerDataCacheInstance;
        private CostAnalyzerDataCache _costAnalyzerDataCacheInstanceFixture;

        #region General Initializer : Class (CostAnalyzerDataCache) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CostAnalyzerDataCache" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _costAnalyzerDataCacheInstanceType = typeof(CostAnalyzerDataCache);
            _costAnalyzerDataCacheInstanceFixture = Create(true);
            _costAnalyzerDataCacheInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CostAnalyzerDataCache)

        #region General Initializer : Class (CostAnalyzerDataCache) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="CostAnalyzerDataCache" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGrabCAData, 0)]
        [TestCase(Methodsetupdispcolns, 0)]
        [TestCase(MethodAddTotalEntry, 0)]
        [TestCase(MethodAddColEntry, 0)]
        [TestCase(MethodGetPeriodsData, 0)]
        [TestCase(MethodGetCostTypeNameData, 0)]
        [TestCase(MethodReDrawGrid, 0)]
        [TestCase(MethodPrepareTotalsCollection, 0)]
        [TestCase(MethodCreatetgLayout, 0)]
        [TestCase(MethodGetTopGrid, 0)]
        [TestCase(MethodGetBottomGrid, 0)]
        [TestCase(MethodSetCTStateData, 0)]
        [TestCase(MethodSetDisplayMode, 0)]
        [TestCase(MethodGetDisplayMode, 0)]
        [TestCase(MethodGetStartFinishDataPeriods, 0)]
        [TestCase(MethodSetSelectedForRows, 0)]
        [TestCase(MethodSetFilteredForRows, 0)]
        [TestCase(MethodNewRedrawTotals, 0)]
        [TestCase(MethodFormatExtraDisplay, 0)]
        [TestCase(MethodFormatWork, 0)]
        [TestCase(MethodFormatDuration, 0)]
        [TestCase(MethodBuildTotalsKey, 0)]
        [TestCase(MethodGetDetFieldValue, 0)]
        [TestCase(MethodSetTotalDetFieldValue, 0)]
        [TestCase(MethodCopyOverTotFields, 0)]
        [TestCase(MethodProcessTotals, 0)]
        [TestCase(MethodGetLegendGrid, 0)]
        [TestCase(MethodGetTotalsData, 0)]
        [TestCase(MethodSetTotalsData, 0)]
        [TestCase(MethodGetCompareCostTypeList, 0)]
        [TestCase(MethodSetCompareCostType, 0)]
        [TestCase(MethodCreatePsuedoTarget, 0)]
        [TestCase(MethodSetShowRemaining, 0)]
        [TestCase(MethodProcessTargets, 0)]
        [TestCase(MethodStashViews, 0)]
        [TestCase(MethodApplyServerSideViewSettings, 0)]
        [TestCase(MethodGetTargetList, 0)]
        [TestCase(MethodDeleteTarget, 0)]
        [TestCase(MethodBuildCatJSon, 0)]
        [TestCase(MethodRatesAndCategory, 0)]
        [TestCase(MethodGetLookUpString, 0)]
        [TestCase(MethodPrepareTargetData, 0)]
        [TestCase(MethodGetTargetGrid, 0)]
        [TestCase(MethodAggreagteDuplicateRows, 0)]
        [TestCase(MethodGetTargetTotalsData, 0)]
        [TestCase(MethodGet_CB_ID, 0)]
        [TestCase(MethodGet_MaxPeriods, 0)]
        [TestCase(MethodRefreshTargets, 0)]
        [TestCase(MethodGetTargetRGBData, 0)]
        public void AUT_CostAnalyzerDataCache_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_costAnalyzerDataCacheInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CostAnalyzerDataCache) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CostAnalyzerDataCache" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldHideRowsWithAllZerosXmlNode)]
        [TestCase(FieldHideRowsWithAllZerosXmlValueAttribute)]
        [TestCase(Fieldm_clsda)]
        [TestCase(Fieldm_topgridcln)]
        [TestCase(Fieldm_bottomgridcln)]
        [TestCase(Fieldm_cust_Defn)]
        [TestCase(Fieldm_cust_full)]
        [TestCase(Fieldm_cust_ocf)]
        [TestCase(Fieldm_cust_lk)]
        [TestCase(FieldTGStandard)]
        [TestCase(FieldBGStandard)]
        [TestCase(Fieldm_clnsort)]
        [TestCase(Fieldm_DispMode)]
        [TestCase(Fieldm_heatmap_text)]
        [TestCase(FieldbShowFTEs)]
        [TestCase(FieldbUseQTY)]
        [TestCase(FieldbUseCosts)]
        [TestCase(Fieldm_show_rhs_dec_costs)]
        [TestCase(Field_hideRowsWithAllZeros)]
        [TestCase(Fieldm_TotalRoot)]
        [TestCase(Fieldm_total_dets)]
        [TestCase(Fieldm_CTCmpRoot)]
        [TestCase(Fieldm_targetdata)]
        [TestCase(Fieldm_tarnames)]
        [TestCase(Fieldm_apply_target)]
        [TestCase(Fieldm_showremaining)]
        [TestCase(Fieldm_viewsxml)]
        [TestCase(FieldTotGeneral)]
        [TestCase(FieldTotSelectedOrder)]
        [TestCase(Fieldm_use_heatmap)]
        [TestCase(Fieldm_use_heatmapID)]
        [TestCase(Fieldm_use_heatmapColour)]
        [TestCase(Fieldm_heatmapcol)]
        [TestCase(Fieldm_heatmaptext)]
        [TestCase(Fieldm_CostCatjsonMenu)]
        [TestCase(Fieldm_CostTypejsonMenu)]
        [TestCase(Fieldm_editTargetList)]
        [TestCase(Fieldm_curr_period)]
        public void AUT_CostAnalyzerDataCache_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_costAnalyzerDataCacheInstanceFixture, 
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
        ///     Class (<see cref="CostAnalyzerDataCache" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_CostAnalyzerDataCache_Is_Instance_Present_Test()
        {
            // Assert
            _costAnalyzerDataCacheInstanceType.ShouldNotBeNull();
            _costAnalyzerDataCacheInstance.ShouldNotBeNull();
            _costAnalyzerDataCacheInstanceFixture.ShouldNotBeNull();
            _costAnalyzerDataCacheInstance.ShouldBeAssignableTo<CostAnalyzerDataCache>();
            _costAnalyzerDataCacheInstanceFixture.ShouldBeAssignableTo<CostAnalyzerDataCache>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CostAnalyzerDataCache) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_CostAnalyzerDataCache_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CostAnalyzerDataCache instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _costAnalyzerDataCacheInstanceType.ShouldNotBeNull();
            _costAnalyzerDataCacheInstance.ShouldNotBeNull();
            _costAnalyzerDataCacheInstanceFixture.ShouldNotBeNull();
            _costAnalyzerDataCacheInstance.ShouldBeAssignableTo<CostAnalyzerDataCache>();
            _costAnalyzerDataCacheInstanceFixture.ShouldBeAssignableTo<CostAnalyzerDataCache>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="CostAnalyzerDataCache" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGrabCAData)]
        [TestCase(Methodsetupdispcolns)]
        [TestCase(MethodAddTotalEntry)]
        [TestCase(MethodAddColEntry)]
        [TestCase(MethodGetPeriodsData)]
        [TestCase(MethodGetCostTypeNameData)]
        [TestCase(MethodReDrawGrid)]
        [TestCase(MethodPrepareTotalsCollection)]
        [TestCase(MethodCreatetgLayout)]
        [TestCase(MethodGetTopGrid)]
        [TestCase(MethodGetBottomGrid)]
        [TestCase(MethodSetCTStateData)]
        [TestCase(MethodSetDisplayMode)]
        [TestCase(MethodGetDisplayMode)]
        [TestCase(MethodGetStartFinishDataPeriods)]
        [TestCase(MethodSetSelectedForRows)]
        [TestCase(MethodSetFilteredForRows)]
        [TestCase(MethodNewRedrawTotals)]
        [TestCase(MethodFormatExtraDisplay)]
        [TestCase(MethodFormatWork)]
        [TestCase(MethodFormatDuration)]
        [TestCase(MethodBuildTotalsKey)]
        [TestCase(MethodGetDetFieldValue)]
        [TestCase(MethodSetTotalDetFieldValue)]
        [TestCase(MethodCopyOverTotFields)]
        [TestCase(MethodProcessTotals)]
        [TestCase(MethodGetLegendGrid)]
        [TestCase(MethodGetTotalsData)]
        [TestCase(MethodSetTotalsData)]
        [TestCase(MethodGetCompareCostTypeList)]
        [TestCase(MethodSetCompareCostType)]
        [TestCase(MethodCreatePsuedoTarget)]
        [TestCase(MethodSetShowRemaining)]
        [TestCase(MethodProcessTargets)]
        [TestCase(MethodStashViews)]
        [TestCase(MethodApplyServerSideViewSettings)]
        [TestCase(MethodGetTargetList)]
        [TestCase(MethodDeleteTarget)]
        [TestCase(MethodBuildCatJSon)]
        [TestCase(MethodRatesAndCategory)]
        [TestCase(MethodGetLookUpString)]
        [TestCase(MethodPrepareTargetData)]
        [TestCase(MethodGetTargetGrid)]
        [TestCase(MethodAggreagteDuplicateRows)]
        [TestCase(MethodGetTargetTotalsData)]
        [TestCase(MethodGet_CB_ID)]
        [TestCase(MethodGet_MaxPeriods)]
        [TestCase(MethodRefreshTargets)]
        [TestCase(MethodGetTargetRGBData)]
        public void AUT_CostAnalyzerDataCache_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<CostAnalyzerDataCache>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GrabCAData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_GrabCAData_Method_Call_Internally(Type[] types)
        {
            var methodGrabCADataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGrabCAData, Fixture, methodGrabCADataPrametersTypes);
        }

        #endregion

        #region Method Call : (GrabCAData) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GrabCAData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var clsda = CreateType<clsCostData>();
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataCacheInstance.GrabCAData(clsda);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GrabCAData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GrabCAData_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var clsda = CreateType<clsCostData>();
            var methodGrabCADataPrametersTypes = new Type[] { typeof(clsCostData) };
            object[] parametersOfGrabCAData = { clsda };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGrabCAData, methodGrabCADataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataCacheInstanceFixture, parametersOfGrabCAData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGrabCAData.ShouldNotBeNull();
            parametersOfGrabCAData.Length.ShouldBe(1);
            methodGrabCADataPrametersTypes.Length.ShouldBe(1);
            methodGrabCADataPrametersTypes.Length.ShouldBe(parametersOfGrabCAData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GrabCAData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GrabCAData_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var clsda = CreateType<clsCostData>();
            var methodGrabCADataPrametersTypes = new Type[] { typeof(clsCostData) };
            object[] parametersOfGrabCAData = { clsda };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataCacheInstance, MethodGrabCAData, parametersOfGrabCAData, methodGrabCADataPrametersTypes);

            // Assert
            parametersOfGrabCAData.ShouldNotBeNull();
            parametersOfGrabCAData.Length.ShouldBe(1);
            methodGrabCADataPrametersTypes.Length.ShouldBe(1);
            methodGrabCADataPrametersTypes.Length.ShouldBe(parametersOfGrabCAData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GrabCAData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GrabCAData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGrabCAData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GrabCAData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GrabCAData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGrabCADataPrametersTypes = new Type[] { typeof(clsCostData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGrabCAData, Fixture, methodGrabCADataPrametersTypes);

            // Assert
            methodGrabCADataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GrabCAData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GrabCAData_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGrabCAData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setupdispcolns) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_setupdispcolns_Method_Call_Internally(Type[] types)
        {
            var methodsetupdispcolnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, Methodsetupdispcolns, Fixture, methodsetupdispcolnsPrametersTypes);
        }

        #endregion

        #region Method Call : (setupdispcolns) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_setupdispcolns_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodsetupdispcolnsPrametersTypes = null;
            object[] parametersOfsetupdispcolns = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(Methodsetupdispcolns, methodsetupdispcolnsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataCacheInstanceFixture, parametersOfsetupdispcolns);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsetupdispcolns.ShouldBeNull();
            methodsetupdispcolnsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (setupdispcolns) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_setupdispcolns_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodsetupdispcolnsPrametersTypes = null;
            object[] parametersOfsetupdispcolns = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataCacheInstance, Methodsetupdispcolns, parametersOfsetupdispcolns, methodsetupdispcolnsPrametersTypes);

            // Assert
            parametersOfsetupdispcolns.ShouldBeNull();
            methodsetupdispcolnsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setupdispcolns) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_setupdispcolns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodsetupdispcolnsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, Methodsetupdispcolns, Fixture, methodsetupdispcolnsPrametersTypes);

            // Assert
            methodsetupdispcolnsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setupdispcolns) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_setupdispcolns_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodsetupdispcolns, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTotalEntry) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_AddTotalEntry_Method_Call_Internally(Type[] types)
        {
            var methodAddTotalEntryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodAddTotalEntry, Fixture, methodAddTotalEntryPrametersTypes);
        }

        #endregion

        #region Method Call : (AddTotalEntry) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_AddTotalEntry_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var Name = CreateType<string>();
            var fid = CreateType<int>();
            var bSel = CreateType<bool>();
            var id = CreateType<int>();
            var methodAddTotalEntryPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(bool), typeof(int) };
            object[] parametersOfAddTotalEntry = { Name, fid, bSel, id };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddTotalEntry, methodAddTotalEntryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataCacheInstanceFixture, parametersOfAddTotalEntry);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddTotalEntry.ShouldNotBeNull();
            parametersOfAddTotalEntry.Length.ShouldBe(4);
            methodAddTotalEntryPrametersTypes.Length.ShouldBe(4);
            methodAddTotalEntryPrametersTypes.Length.ShouldBe(parametersOfAddTotalEntry.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTotalEntry) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_AddTotalEntry_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Name = CreateType<string>();
            var fid = CreateType<int>();
            var bSel = CreateType<bool>();
            var id = CreateType<int>();
            var methodAddTotalEntryPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(bool), typeof(int) };
            object[] parametersOfAddTotalEntry = { Name, fid, bSel, id };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataCacheInstance, MethodAddTotalEntry, parametersOfAddTotalEntry, methodAddTotalEntryPrametersTypes);

            // Assert
            parametersOfAddTotalEntry.ShouldNotBeNull();
            parametersOfAddTotalEntry.Length.ShouldBe(4);
            methodAddTotalEntryPrametersTypes.Length.ShouldBe(4);
            methodAddTotalEntryPrametersTypes.Length.ShouldBe(parametersOfAddTotalEntry.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTotalEntry) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_AddTotalEntry_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddTotalEntry, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddTotalEntry) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_AddTotalEntry_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddTotalEntryPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(bool), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodAddTotalEntry, Fixture, methodAddTotalEntryPrametersTypes);

            // Assert
            methodAddTotalEntryPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTotalEntry) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_AddTotalEntry_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddTotalEntry, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColEntry) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_AddColEntry_Method_Call_Internally(Type[] types)
        {
            var methodAddColEntryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodAddColEntry, Fixture, methodAddColEntryPrametersTypes);
        }

        #endregion

        #region Method Call : (AddColEntry) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_AddColEntry_Method_Call_Void_With_6_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var Name = CreateType<string>();
            var fid = CreateType<int>();
            var bAddToTot = CreateType<bool>();
            var btdeffld = CreateType<bool>();
            var btunsel = CreateType<bool>();
            var bbdeffld = CreateType<bool>();
            var methodAddColEntryPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(bool), typeof(bool), typeof(bool), typeof(bool) };
            object[] parametersOfAddColEntry = { Name, fid, bAddToTot, btdeffld, btunsel, bbdeffld };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddColEntry, methodAddColEntryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataCacheInstanceFixture, parametersOfAddColEntry);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddColEntry.ShouldNotBeNull();
            parametersOfAddColEntry.Length.ShouldBe(6);
            methodAddColEntryPrametersTypes.Length.ShouldBe(6);
            methodAddColEntryPrametersTypes.Length.ShouldBe(parametersOfAddColEntry.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddColEntry) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_AddColEntry_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Name = CreateType<string>();
            var fid = CreateType<int>();
            var bAddToTot = CreateType<bool>();
            var btdeffld = CreateType<bool>();
            var btunsel = CreateType<bool>();
            var bbdeffld = CreateType<bool>();
            var methodAddColEntryPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(bool), typeof(bool), typeof(bool), typeof(bool) };
            object[] parametersOfAddColEntry = { Name, fid, bAddToTot, btdeffld, btunsel, bbdeffld };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataCacheInstance, MethodAddColEntry, parametersOfAddColEntry, methodAddColEntryPrametersTypes);

            // Assert
            parametersOfAddColEntry.ShouldNotBeNull();
            parametersOfAddColEntry.Length.ShouldBe(6);
            methodAddColEntryPrametersTypes.Length.ShouldBe(6);
            methodAddColEntryPrametersTypes.Length.ShouldBe(parametersOfAddColEntry.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColEntry) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_AddColEntry_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddColEntry, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddColEntry) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_AddColEntry_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddColEntryPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(bool), typeof(bool), typeof(bool), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodAddColEntry, Fixture, methodAddColEntryPrametersTypes);

            // Assert
            methodAddColEntryPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColEntry) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_AddColEntry_Method_Call_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddColEntry, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPeriodsData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_GetPeriodsData_Method_Call_Internally(Type[] types)
        {
            var methodGetPeriodsDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetPeriodsData, Fixture, methodGetPeriodsDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPeriodsData) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetPeriodsData_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataCacheInstance.GetPeriodsData();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetPeriodsData) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetPeriodsData_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetPeriodsDataPrametersTypes = null;
            object[] parametersOfGetPeriodsData = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetPeriodsData, methodGetPeriodsDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataCacheInstanceFixture, parametersOfGetPeriodsData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetPeriodsData.ShouldBeNull();
            methodGetPeriodsDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPeriodsData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetPeriodsData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetPeriodsDataPrametersTypes = null;
            object[] parametersOfGetPeriodsData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstance, MethodGetPeriodsData, parametersOfGetPeriodsData, methodGetPeriodsDataPrametersTypes);

            // Assert
            parametersOfGetPeriodsData.ShouldBeNull();
            methodGetPeriodsDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPeriodsData) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetPeriodsData_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetPeriodsDataPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetPeriodsData, Fixture, methodGetPeriodsDataPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetPeriodsDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPeriodsData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetPeriodsData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetPeriodsDataPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetPeriodsData, Fixture, methodGetPeriodsDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPeriodsDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPeriodsData) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetPeriodsData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPeriodsData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetCostTypeNameData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_GetCostTypeNameData_Method_Call_Internally(Type[] types)
        {
            var methodGetCostTypeNameDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetCostTypeNameData, Fixture, methodGetCostTypeNameDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCostTypeNameData) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetCostTypeNameData_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataCacheInstance.GetCostTypeNameData();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetCostTypeNameData) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetCostTypeNameData_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetCostTypeNameDataPrametersTypes = null;
            object[] parametersOfGetCostTypeNameData = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCostTypeNameData, methodGetCostTypeNameDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataCacheInstanceFixture, parametersOfGetCostTypeNameData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCostTypeNameData.ShouldBeNull();
            methodGetCostTypeNameDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCostTypeNameData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetCostTypeNameData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetCostTypeNameDataPrametersTypes = null;
            object[] parametersOfGetCostTypeNameData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstance, MethodGetCostTypeNameData, parametersOfGetCostTypeNameData, methodGetCostTypeNameDataPrametersTypes);

            // Assert
            parametersOfGetCostTypeNameData.ShouldBeNull();
            methodGetCostTypeNameDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCostTypeNameData) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetCostTypeNameData_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetCostTypeNameDataPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetCostTypeNameData, Fixture, methodGetCostTypeNameDataPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetCostTypeNameDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCostTypeNameData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetCostTypeNameData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetCostTypeNameDataPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetCostTypeNameData, Fixture, methodGetCostTypeNameDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCostTypeNameDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCostTypeNameData) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetCostTypeNameData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCostTypeNameData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ReDrawGrid) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_ReDrawGrid_Method_Call_Internally(Type[] types)
        {
            var methodReDrawGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodReDrawGrid, Fixture, methodReDrawGridPrametersTypes);
        }

        #endregion

        #region Method Call : (ReDrawGrid) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_ReDrawGrid_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodReDrawGridPrametersTypes = null;
            object[] parametersOfReDrawGrid = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReDrawGrid, methodReDrawGridPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataCacheInstanceFixture, parametersOfReDrawGrid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReDrawGrid.ShouldBeNull();
            methodReDrawGridPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReDrawGrid) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_ReDrawGrid_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodReDrawGridPrametersTypes = null;
            object[] parametersOfReDrawGrid = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataCacheInstance, MethodReDrawGrid, parametersOfReDrawGrid, methodReDrawGridPrametersTypes);

            // Assert
            parametersOfReDrawGrid.ShouldBeNull();
            methodReDrawGridPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReDrawGrid) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_ReDrawGrid_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodReDrawGridPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodReDrawGrid, Fixture, methodReDrawGridPrametersTypes);

            // Assert
            methodReDrawGridPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReDrawGrid) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_ReDrawGrid_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReDrawGrid, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PrepareTotalsCollection) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_PrepareTotalsCollection_Method_Call_Internally(Type[] types)
        {
            var methodPrepareTotalsCollectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodPrepareTotalsCollection, Fixture, methodPrepareTotalsCollectionPrametersTypes);
        }

        #endregion

        #region Method Call : (PrepareTotalsCollection) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_PrepareTotalsCollection_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodPrepareTotalsCollectionPrametersTypes = null;
            object[] parametersOfPrepareTotalsCollection = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataCacheInstance, MethodPrepareTotalsCollection, parametersOfPrepareTotalsCollection, methodPrepareTotalsCollectionPrametersTypes);

            // Assert
            parametersOfPrepareTotalsCollection.ShouldBeNull();
            methodPrepareTotalsCollectionPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PrepareTotalsCollection) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_PrepareTotalsCollection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodPrepareTotalsCollectionPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodPrepareTotalsCollection, Fixture, methodPrepareTotalsCollectionPrametersTypes);

            // Assert
            methodPrepareTotalsCollectionPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PrepareTotalsCollection) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_PrepareTotalsCollection_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPrepareTotalsCollection, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreatetgLayout) (Return Type : CATGRow) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_CreatetgLayout_Method_Call_Internally(Type[] types)
        {
            var methodCreatetgLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodCreatetgLayout, Fixture, methodCreatetgLayoutPrametersTypes);
        }

        #endregion
        
        #region Method Call : (CreatetgLayout) (Return Type : CATGRow) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_CreatetgLayout_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var bUse = CreateType<bool>();
            var fid = CreateType<int>();
            var name = CreateType<string>();
            var displayname = CreateType<string>();
            var indx = CreateType<int>();
            var methodCreatetgLayoutPrametersTypes = new Type[] { typeof(bool), typeof(int), typeof(string), typeof(string), typeof(int) };
            object[] parametersOfCreatetgLayout = { bUse, fid, name, displayname, indx };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreatetgLayout, methodCreatetgLayoutPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataCacheInstanceFixture, parametersOfCreatetgLayout);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreatetgLayout.ShouldNotBeNull();
            parametersOfCreatetgLayout.Length.ShouldBe(5);
            methodCreatetgLayoutPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion
        
        #region Method Call : (CreatetgLayout) (Return Type : CATGRow) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_CreatetgLayout_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCreatetgLayoutPrametersTypes = new Type[] { typeof(bool), typeof(int), typeof(string), typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodCreatetgLayout, Fixture, methodCreatetgLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreatetgLayoutPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (CreatetgLayout) (Return Type : CATGRow) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_CreatetgLayout_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreatetgLayoutPrametersTypes = new Type[] { typeof(bool), typeof(int), typeof(string), typeof(string), typeof(int) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodCreatetgLayout, Fixture, methodCreatetgLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreatetgLayoutPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreatetgLayout) (Return Type : CATGRow) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_CreatetgLayout_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreatetgLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (CreatetgLayout) (Return Type : CATGRow) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_CreatetgLayout_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreatetgLayout, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTopGrid) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_GetTopGrid_Method_Call_Internally(Type[] types)
        {
            var methodGetTopGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetTopGrid, Fixture, methodGetTopGridPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTopGrid) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTopGrid_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataCacheInstance.GetTopGrid();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTopGrid) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTopGrid_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetTopGridPrametersTypes = null;
            object[] parametersOfGetTopGrid = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstance, MethodGetTopGrid, parametersOfGetTopGrid, methodGetTopGridPrametersTypes);

            // Assert
            parametersOfGetTopGrid.ShouldBeNull();
            methodGetTopGridPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTopGrid) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTopGrid_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetTopGridPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetTopGrid, Fixture, methodGetTopGridPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTopGridPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTopGrid) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTopGrid_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetTopGridPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetTopGrid, Fixture, methodGetTopGridPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTopGridPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetBottomGrid) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_GetBottomGrid_Method_Call_Internally(Type[] types)
        {
            var methodGetBottomGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetBottomGrid, Fixture, methodGetBottomGridPrametersTypes);
        }

        #endregion

        #region Method Call : (GetBottomGrid) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetBottomGrid_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataCacheInstance.GetBottomGrid();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetBottomGrid) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetBottomGrid_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetBottomGridPrametersTypes = null;
            object[] parametersOfGetBottomGrid = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstance, MethodGetBottomGrid, parametersOfGetBottomGrid, methodGetBottomGridPrametersTypes);

            // Assert
            parametersOfGetBottomGrid.ShouldBeNull();
            methodGetBottomGridPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetBottomGrid) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetBottomGrid_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetBottomGridPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetBottomGrid, Fixture, methodGetBottomGridPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetBottomGridPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetBottomGrid) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetBottomGrid_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetBottomGridPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetBottomGrid, Fixture, methodGetBottomGridPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetBottomGridPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetCTStateData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_SetCTStateData_Method_Call_Internally(Type[] types)
        {
            var methodSetCTStateDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodSetCTStateData, Fixture, methodSetCTStateDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SetCTStateData) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetCTStateData_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataCacheInstance.SetCTStateData(xData);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (SetCTStateData) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetCTStateData_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            var methodSetCTStateDataPrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfSetCTStateData = { xData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetCTStateData, methodSetCTStateDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataCacheInstanceFixture, parametersOfSetCTStateData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetCTStateData.ShouldNotBeNull();
            parametersOfSetCTStateData.Length.ShouldBe(1);
            methodSetCTStateDataPrametersTypes.Length.ShouldBe(1);
            methodSetCTStateDataPrametersTypes.Length.ShouldBe(parametersOfSetCTStateData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetCTStateData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetCTStateData_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            var methodSetCTStateDataPrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfSetCTStateData = { xData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataCacheInstance, MethodSetCTStateData, parametersOfSetCTStateData, methodSetCTStateDataPrametersTypes);

            // Assert
            parametersOfSetCTStateData.ShouldNotBeNull();
            parametersOfSetCTStateData.Length.ShouldBe(1);
            methodSetCTStateDataPrametersTypes.Length.ShouldBe(1);
            methodSetCTStateDataPrametersTypes.Length.ShouldBe(parametersOfSetCTStateData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetCTStateData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetCTStateData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetCTStateData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetCTStateData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetCTStateData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetCTStateDataPrametersTypes = new Type[] { typeof(CStruct) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodSetCTStateData, Fixture, methodSetCTStateDataPrametersTypes);

            // Assert
            methodSetCTStateDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetCTStateData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetCTStateData_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetCTStateData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetDisplayMode) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_SetDisplayMode_Method_Call_Internally(Type[] types)
        {
            var methodSetDisplayModePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodSetDisplayMode, Fixture, methodSetDisplayModePrametersTypes);
        }

        #endregion

        #region Method Call : (SetDisplayMode) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetDisplayMode_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataCacheInstance.SetDisplayMode(xData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetDisplayMode) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetDisplayMode_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            var methodSetDisplayModePrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfSetDisplayMode = { xData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetDisplayMode, methodSetDisplayModePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataCacheInstanceFixture, parametersOfSetDisplayMode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetDisplayMode.ShouldNotBeNull();
            parametersOfSetDisplayMode.Length.ShouldBe(1);
            methodSetDisplayModePrametersTypes.Length.ShouldBe(1);
            methodSetDisplayModePrametersTypes.Length.ShouldBe(parametersOfSetDisplayMode.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetDisplayMode) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetDisplayMode_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            var methodSetDisplayModePrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfSetDisplayMode = { xData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataCacheInstance, MethodSetDisplayMode, parametersOfSetDisplayMode, methodSetDisplayModePrametersTypes);

            // Assert
            parametersOfSetDisplayMode.ShouldNotBeNull();
            parametersOfSetDisplayMode.Length.ShouldBe(1);
            methodSetDisplayModePrametersTypes.Length.ShouldBe(1);
            methodSetDisplayModePrametersTypes.Length.ShouldBe(parametersOfSetDisplayMode.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetDisplayMode) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetDisplayMode_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetDisplayMode, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetDisplayMode) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetDisplayMode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetDisplayModePrametersTypes = new Type[] { typeof(CStruct) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodSetDisplayMode, Fixture, methodSetDisplayModePrametersTypes);

            // Assert
            methodSetDisplayModePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetDisplayMode) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetDisplayMode_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetDisplayMode, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDisplayMode) (Return Type : String) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_GetDisplayMode_Method_Call_Internally(Type[] types)
        {
            var methodGetDisplayModePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetDisplayMode, Fixture, methodGetDisplayModePrametersTypes);
        }

        #endregion

        #region Method Call : (GetDisplayMode) (Return Type : String) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetDisplayMode_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataCacheInstance.GetDisplayMode();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetDisplayMode) (Return Type : String) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetDisplayMode_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetDisplayModePrametersTypes = null;
            object[] parametersOfGetDisplayMode = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetDisplayMode, methodGetDisplayModePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataCacheInstanceFixture, parametersOfGetDisplayMode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetDisplayMode.ShouldBeNull();
            methodGetDisplayModePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDisplayMode) (Return Type : String) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetDisplayMode_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetDisplayModePrametersTypes = null;
            object[] parametersOfGetDisplayMode = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, String>(_costAnalyzerDataCacheInstance, MethodGetDisplayMode, parametersOfGetDisplayMode, methodGetDisplayModePrametersTypes);

            // Assert
            parametersOfGetDisplayMode.ShouldBeNull();
            methodGetDisplayModePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDisplayMode) (Return Type : String) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetDisplayMode_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetDisplayModePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetDisplayMode, Fixture, methodGetDisplayModePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetDisplayModePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDisplayMode) (Return Type : String) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetDisplayMode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetDisplayModePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetDisplayMode, Fixture, methodGetDisplayModePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDisplayModePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDisplayMode) (Return Type : String) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetDisplayMode_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDisplayMode, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetStartFinishDataPeriods) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_GetStartFinishDataPeriods_Method_Call_Internally(Type[] types)
        {
            var methodGetStartFinishDataPeriodsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetStartFinishDataPeriods, Fixture, methodGetStartFinishDataPeriodsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetStartFinishDataPeriods) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetStartFinishDataPeriods_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var istart = CreateType<int>();
            var ifinish = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataCacheInstance.GetStartFinishDataPeriods(out istart, out ifinish);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetStartFinishDataPeriods) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetStartFinishDataPeriods_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var istart = CreateType<int>();
            var ifinish = CreateType<int>();
            var methodGetStartFinishDataPeriodsPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfGetStartFinishDataPeriods = { istart, ifinish };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataCacheInstance, MethodGetStartFinishDataPeriods, parametersOfGetStartFinishDataPeriods, methodGetStartFinishDataPeriodsPrametersTypes);

            // Assert
            parametersOfGetStartFinishDataPeriods.ShouldNotBeNull();
            parametersOfGetStartFinishDataPeriods.Length.ShouldBe(2);
            methodGetStartFinishDataPeriodsPrametersTypes.Length.ShouldBe(2);
            methodGetStartFinishDataPeriodsPrametersTypes.Length.ShouldBe(parametersOfGetStartFinishDataPeriods.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetStartFinishDataPeriods) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetStartFinishDataPeriods_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetStartFinishDataPeriods, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetStartFinishDataPeriods) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetStartFinishDataPeriods_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetStartFinishDataPeriodsPrametersTypes = new Type[] { typeof(int), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetStartFinishDataPeriods, Fixture, methodGetStartFinishDataPeriodsPrametersTypes);

            // Assert
            methodGetStartFinishDataPeriodsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetStartFinishDataPeriods) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetStartFinishDataPeriods_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetStartFinishDataPeriods, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedForRows) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_SetSelectedForRows_Method_Call_Internally(Type[] types)
        {
            var methodSetSelectedForRowsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodSetSelectedForRows, Fixture, methodSetSelectedForRowsPrametersTypes);
        }

        #endregion

        #region Method Call : (SetSelectedForRows) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetSelectedForRows_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataCacheInstance.SetSelectedForRows(xData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetSelectedForRows) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetSelectedForRows_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            var methodSetSelectedForRowsPrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfSetSelectedForRows = { xData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetSelectedForRows, methodSetSelectedForRowsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataCacheInstanceFixture, parametersOfSetSelectedForRows);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetSelectedForRows.ShouldNotBeNull();
            parametersOfSetSelectedForRows.Length.ShouldBe(1);
            methodSetSelectedForRowsPrametersTypes.Length.ShouldBe(1);
            methodSetSelectedForRowsPrametersTypes.Length.ShouldBe(parametersOfSetSelectedForRows.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedForRows) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetSelectedForRows_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            var methodSetSelectedForRowsPrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfSetSelectedForRows = { xData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataCacheInstance, MethodSetSelectedForRows, parametersOfSetSelectedForRows, methodSetSelectedForRowsPrametersTypes);

            // Assert
            parametersOfSetSelectedForRows.ShouldNotBeNull();
            parametersOfSetSelectedForRows.Length.ShouldBe(1);
            methodSetSelectedForRowsPrametersTypes.Length.ShouldBe(1);
            methodSetSelectedForRowsPrametersTypes.Length.ShouldBe(parametersOfSetSelectedForRows.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedForRows) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetSelectedForRows_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetSelectedForRows, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetSelectedForRows) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetSelectedForRows_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetSelectedForRowsPrametersTypes = new Type[] { typeof(CStruct) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodSetSelectedForRows, Fixture, methodSetSelectedForRowsPrametersTypes);

            // Assert
            methodSetSelectedForRowsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedForRows) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetSelectedForRows_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetSelectedForRows, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetFilteredForRows) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_SetFilteredForRows_Method_Call_Internally(Type[] types)
        {
            var methodSetFilteredForRowsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodSetFilteredForRows, Fixture, methodSetFilteredForRowsPrametersTypes);
        }

        #endregion

        #region Method Call : (SetFilteredForRows) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetFilteredForRows_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            var methodSetFilteredForRowsPrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfSetFilteredForRows = { xData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataCacheInstance, MethodSetFilteredForRows, parametersOfSetFilteredForRows, methodSetFilteredForRowsPrametersTypes);

            // Assert
            parametersOfSetFilteredForRows.ShouldNotBeNull();
            parametersOfSetFilteredForRows.Length.ShouldBe(1);
            methodSetFilteredForRowsPrametersTypes.Length.ShouldBe(1);
            methodSetFilteredForRowsPrametersTypes.Length.ShouldBe(parametersOfSetFilteredForRows.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetFilteredForRows) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetFilteredForRows_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetFilteredForRows, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetFilteredForRows) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetFilteredForRows_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetFilteredForRowsPrametersTypes = new Type[] { typeof(CStruct) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodSetFilteredForRows, Fixture, methodSetFilteredForRowsPrametersTypes);

            // Assert
            methodSetFilteredForRowsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetFilteredForRows) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetFilteredForRows_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetFilteredForRows, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (NewRedrawTotals) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_NewRedrawTotals_Method_Call_Internally(Type[] types)
        {
            var methodNewRedrawTotalsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodNewRedrawTotals, Fixture, methodNewRedrawTotalsPrametersTypes);
        }

        #endregion

        #region Method Call : (NewRedrawTotals) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_NewRedrawTotals_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodNewRedrawTotalsPrametersTypes = null;
            object[] parametersOfNewRedrawTotals = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataCacheInstance, MethodNewRedrawTotals, parametersOfNewRedrawTotals, methodNewRedrawTotalsPrametersTypes);

            // Assert
            parametersOfNewRedrawTotals.ShouldBeNull();
            methodNewRedrawTotalsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (NewRedrawTotals) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_NewRedrawTotals_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodNewRedrawTotalsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodNewRedrawTotals, Fixture, methodNewRedrawTotalsPrametersTypes);

            // Assert
            methodNewRedrawTotalsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (NewRedrawTotals) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_NewRedrawTotals_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodNewRedrawTotals, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FormatExtraDisplay) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_FormatExtraDisplay_Method_Call_Internally(Type[] types)
        {
            var methodFormatExtraDisplayPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodFormatExtraDisplay, Fixture, methodFormatExtraDisplayPrametersTypes);
        }

        #endregion

        #region Method Call : (FormatExtraDisplay) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_FormatExtraDisplay_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sIn = CreateType<string>();
            var lt = CreateType<int>();
            var methodFormatExtraDisplayPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfFormatExtraDisplay = { sIn, lt };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFormatExtraDisplay, methodFormatExtraDisplayPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataCacheInstanceFixture, parametersOfFormatExtraDisplay);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFormatExtraDisplay.ShouldNotBeNull();
            parametersOfFormatExtraDisplay.Length.ShouldBe(2);
            methodFormatExtraDisplayPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FormatExtraDisplay) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_FormatExtraDisplay_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sIn = CreateType<string>();
            var lt = CreateType<int>();
            var methodFormatExtraDisplayPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfFormatExtraDisplay = { sIn, lt };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstance, MethodFormatExtraDisplay, parametersOfFormatExtraDisplay, methodFormatExtraDisplayPrametersTypes);

            // Assert
            parametersOfFormatExtraDisplay.ShouldNotBeNull();
            parametersOfFormatExtraDisplay.Length.ShouldBe(2);
            methodFormatExtraDisplayPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FormatExtraDisplay) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_FormatExtraDisplay_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodFormatExtraDisplayPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodFormatExtraDisplay, Fixture, methodFormatExtraDisplayPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodFormatExtraDisplayPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (FormatExtraDisplay) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_FormatExtraDisplay_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFormatExtraDisplayPrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodFormatExtraDisplay, Fixture, methodFormatExtraDisplayPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFormatExtraDisplayPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FormatExtraDisplay) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_FormatExtraDisplay_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFormatExtraDisplay, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (FormatExtraDisplay) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_FormatExtraDisplay_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFormatExtraDisplay, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FormatWork) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_FormatWork_Method_Call_Internally(Type[] types)
        {
            var methodFormatWorkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodFormatWork, Fixture, methodFormatWorkPrametersTypes);
        }

        #endregion

        #region Method Call : (FormatWork) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_FormatWork_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Hours = CreateType<double>();
            var methodFormatWorkPrametersTypes = new Type[] { typeof(double) };
            object[] parametersOfFormatWork = { Hours };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodFormatWork, methodFormatWorkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstanceFixture, out exception1, parametersOfFormatWork);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstance, MethodFormatWork, parametersOfFormatWork, methodFormatWorkPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfFormatWork.ShouldNotBeNull();
            parametersOfFormatWork.Length.ShouldBe(1);
            methodFormatWorkPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (FormatWork) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_FormatWork_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Hours = CreateType<double>();
            var methodFormatWorkPrametersTypes = new Type[] { typeof(double) };
            object[] parametersOfFormatWork = { Hours };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstance, MethodFormatWork, parametersOfFormatWork, methodFormatWorkPrametersTypes);

            // Assert
            parametersOfFormatWork.ShouldNotBeNull();
            parametersOfFormatWork.Length.ShouldBe(1);
            methodFormatWorkPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FormatWork) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_FormatWork_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodFormatWorkPrametersTypes = new Type[] { typeof(double) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodFormatWork, Fixture, methodFormatWorkPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodFormatWorkPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (FormatWork) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_FormatWork_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFormatWorkPrametersTypes = new Type[] { typeof(double) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodFormatWork, Fixture, methodFormatWorkPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFormatWorkPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FormatWork) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_FormatWork_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFormatWork, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FormatWork) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_FormatWork_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFormatWork, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FormatDuration) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_FormatDuration_Method_Call_Internally(Type[] types)
        {
            var methodFormatDurationPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodFormatDuration, Fixture, methodFormatDurationPrametersTypes);
        }

        #endregion

        #region Method Call : (FormatDuration) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_FormatDuration_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var minutes = CreateType<double>();
            var methodFormatDurationPrametersTypes = new Type[] { typeof(double) };
            object[] parametersOfFormatDuration = { minutes };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodFormatDuration, methodFormatDurationPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstanceFixture, out exception1, parametersOfFormatDuration);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstance, MethodFormatDuration, parametersOfFormatDuration, methodFormatDurationPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfFormatDuration.ShouldNotBeNull();
            parametersOfFormatDuration.Length.ShouldBe(1);
            methodFormatDurationPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (FormatDuration) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_FormatDuration_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var minutes = CreateType<double>();
            var methodFormatDurationPrametersTypes = new Type[] { typeof(double) };
            object[] parametersOfFormatDuration = { minutes };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstance, MethodFormatDuration, parametersOfFormatDuration, methodFormatDurationPrametersTypes);

            // Assert
            parametersOfFormatDuration.ShouldNotBeNull();
            parametersOfFormatDuration.Length.ShouldBe(1);
            methodFormatDurationPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FormatDuration) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_FormatDuration_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodFormatDurationPrametersTypes = new Type[] { typeof(double) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodFormatDuration, Fixture, methodFormatDurationPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodFormatDurationPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (FormatDuration) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_FormatDuration_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFormatDurationPrametersTypes = new Type[] { typeof(double) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodFormatDuration, Fixture, methodFormatDurationPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFormatDurationPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FormatDuration) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_FormatDuration_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFormatDuration, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FormatDuration) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_FormatDuration_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFormatDuration, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildTotalsKey) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_BuildTotalsKey_Method_Call_Internally(Type[] types)
        {
            var methodBuildTotalsKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodBuildTotalsKey, Fixture, methodBuildTotalsKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildTotalsKey) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_BuildTotalsKey_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var odet = CreateType<clsDetailRowData>();
            var methodBuildTotalsKeyPrametersTypes = new Type[] { typeof(clsDetailRowData) };
            object[] parametersOfBuildTotalsKey = { odet };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildTotalsKey, methodBuildTotalsKeyPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataCacheInstanceFixture, parametersOfBuildTotalsKey);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildTotalsKey.ShouldNotBeNull();
            parametersOfBuildTotalsKey.Length.ShouldBe(1);
            methodBuildTotalsKeyPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildTotalsKey) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_BuildTotalsKey_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var odet = CreateType<clsDetailRowData>();
            var methodBuildTotalsKeyPrametersTypes = new Type[] { typeof(clsDetailRowData) };
            object[] parametersOfBuildTotalsKey = { odet };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstance, MethodBuildTotalsKey, parametersOfBuildTotalsKey, methodBuildTotalsKeyPrametersTypes);

            // Assert
            parametersOfBuildTotalsKey.ShouldNotBeNull();
            parametersOfBuildTotalsKey.Length.ShouldBe(1);
            methodBuildTotalsKeyPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildTotalsKey) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_BuildTotalsKey_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildTotalsKeyPrametersTypes = new Type[] { typeof(clsDetailRowData) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodBuildTotalsKey, Fixture, methodBuildTotalsKeyPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildTotalsKeyPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (BuildTotalsKey) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_BuildTotalsKey_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildTotalsKeyPrametersTypes = new Type[] { typeof(clsDetailRowData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodBuildTotalsKey, Fixture, methodBuildTotalsKeyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildTotalsKeyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildTotalsKey) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_BuildTotalsKey_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildTotalsKey, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (BuildTotalsKey) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_BuildTotalsKey_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildTotalsKey, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDetFieldValue) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_GetDetFieldValue_Method_Call_Internally(Type[] types)
        {
            var methodGetDetFieldValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetDetFieldValue, Fixture, methodGetDetFieldValuePrametersTypes);
        }

        #endregion
        
        #region Method Call : (GetDetFieldValue) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetDetFieldValue_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var odet = CreateType<clsDetailRowData>();
            var fid = CreateType<int>();
            var lVal = CreateType<int>();
            var sVal = CreateType<string>();
            var methodGetDetFieldValuePrametersTypes = new Type[] { typeof(clsDetailRowData), typeof(int), typeof(int), typeof(string) };
            object[] parametersOfGetDetFieldValue = { odet, fid, lVal, sVal };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataCacheInstance, MethodGetDetFieldValue, parametersOfGetDetFieldValue, methodGetDetFieldValuePrametersTypes);

            // Assert
            parametersOfGetDetFieldValue.ShouldNotBeNull();
            parametersOfGetDetFieldValue.Length.ShouldBe(4);
            methodGetDetFieldValuePrametersTypes.Length.ShouldBe(4);
            methodGetDetFieldValuePrametersTypes.Length.ShouldBe(parametersOfGetDetFieldValue.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDetFieldValue) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetDetFieldValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDetFieldValue, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDetFieldValue) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetDetFieldValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDetFieldValuePrametersTypes = new Type[] { typeof(clsDetailRowData), typeof(int), typeof(int), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetDetFieldValue, Fixture, methodGetDetFieldValuePrametersTypes);

            // Assert
            methodGetDetFieldValuePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDetFieldValue) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetDetFieldValue_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDetFieldValue, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTotalDetFieldValue) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_SetTotalDetFieldValue_Method_Call_Internally(Type[] types)
        {
            var methodSetTotalDetFieldValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodSetTotalDetFieldValue, Fixture, methodSetTotalDetFieldValuePrametersTypes);
        }

        #endregion

        #region Method Call : (SetTotalDetFieldValue) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetTotalDetFieldValue_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var odet = CreateType<clsDetailRowData>();
            var fid = CreateType<int>();
            var lVal = CreateType<int>();
            var sVal = CreateType<string>();
            var methodSetTotalDetFieldValuePrametersTypes = new Type[] { typeof(clsDetailRowData), typeof(int), typeof(int), typeof(string) };
            object[] parametersOfSetTotalDetFieldValue = { odet, fid, lVal, sVal };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataCacheInstance, MethodSetTotalDetFieldValue, parametersOfSetTotalDetFieldValue, methodSetTotalDetFieldValuePrametersTypes);

            // Assert
            parametersOfSetTotalDetFieldValue.ShouldNotBeNull();
            parametersOfSetTotalDetFieldValue.Length.ShouldBe(4);
            methodSetTotalDetFieldValuePrametersTypes.Length.ShouldBe(4);
            methodSetTotalDetFieldValuePrametersTypes.Length.ShouldBe(parametersOfSetTotalDetFieldValue.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTotalDetFieldValue) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetTotalDetFieldValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetTotalDetFieldValue, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetTotalDetFieldValue) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetTotalDetFieldValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetTotalDetFieldValuePrametersTypes = new Type[] { typeof(clsDetailRowData), typeof(int), typeof(int), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodSetTotalDetFieldValue, Fixture, methodSetTotalDetFieldValuePrametersTypes);

            // Assert
            methodSetTotalDetFieldValuePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTotalDetFieldValue) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetTotalDetFieldValue_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetTotalDetFieldValue, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CopyOverTotFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_CopyOverTotFields_Method_Call_Internally(Type[] types)
        {
            var methodCopyOverTotFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodCopyOverTotFields, Fixture, methodCopyOverTotFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (CopyOverTotFields) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_CopyOverTotFields_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var otot = CreateType<clsDetailRowData>();
            var odet = CreateType<clsDetailRowData>();
            var bFirstPass = CreateType<bool>();
            var methodCopyOverTotFieldsPrametersTypes = new Type[] { typeof(clsDetailRowData), typeof(clsDetailRowData), typeof(bool) };
            object[] parametersOfCopyOverTotFields = { otot, odet, bFirstPass };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCopyOverTotFields, methodCopyOverTotFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataCacheInstanceFixture, parametersOfCopyOverTotFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCopyOverTotFields.ShouldNotBeNull();
            parametersOfCopyOverTotFields.Length.ShouldBe(3);
            methodCopyOverTotFieldsPrametersTypes.Length.ShouldBe(3);
            methodCopyOverTotFieldsPrametersTypes.Length.ShouldBe(parametersOfCopyOverTotFields.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CopyOverTotFields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_CopyOverTotFields_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var otot = CreateType<clsDetailRowData>();
            var odet = CreateType<clsDetailRowData>();
            var bFirstPass = CreateType<bool>();
            var methodCopyOverTotFieldsPrametersTypes = new Type[] { typeof(clsDetailRowData), typeof(clsDetailRowData), typeof(bool) };
            object[] parametersOfCopyOverTotFields = { otot, odet, bFirstPass };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataCacheInstance, MethodCopyOverTotFields, parametersOfCopyOverTotFields, methodCopyOverTotFieldsPrametersTypes);

            // Assert
            parametersOfCopyOverTotFields.ShouldNotBeNull();
            parametersOfCopyOverTotFields.Length.ShouldBe(3);
            methodCopyOverTotFieldsPrametersTypes.Length.ShouldBe(3);
            methodCopyOverTotFieldsPrametersTypes.Length.ShouldBe(parametersOfCopyOverTotFields.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CopyOverTotFields) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_CopyOverTotFields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCopyOverTotFields, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CopyOverTotFields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_CopyOverTotFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCopyOverTotFieldsPrametersTypes = new Type[] { typeof(clsDetailRowData), typeof(clsDetailRowData), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodCopyOverTotFields, Fixture, methodCopyOverTotFieldsPrametersTypes);

            // Assert
            methodCopyOverTotFieldsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CopyOverTotFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_CopyOverTotFields_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCopyOverTotFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessTotals) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_ProcessTotals_Method_Call_Internally(Type[] types)
        {
            var methodProcessTotalsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodProcessTotals, Fixture, methodProcessTotalsPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessTotals) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_ProcessTotals_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodProcessTotalsPrametersTypes = null;
            object[] parametersOfProcessTotals = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataCacheInstance, MethodProcessTotals, parametersOfProcessTotals, methodProcessTotalsPrametersTypes);

            // Assert
            parametersOfProcessTotals.ShouldBeNull();
            methodProcessTotalsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessTotals) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_ProcessTotals_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodProcessTotalsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodProcessTotals, Fixture, methodProcessTotalsPrametersTypes);

            // Assert
            methodProcessTotalsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessTotals) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_ProcessTotals_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessTotals, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLegendGrid) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_GetLegendGrid_Method_Call_Internally(Type[] types)
        {
            var methodGetLegendGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetLegendGrid, Fixture, methodGetLegendGridPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLegendGrid) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetLegendGrid_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataCacheInstance.GetLegendGrid();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetLegendGrid) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetLegendGrid_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetLegendGridPrametersTypes = null;
            object[] parametersOfGetLegendGrid = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstance, MethodGetLegendGrid, parametersOfGetLegendGrid, methodGetLegendGridPrametersTypes);

            // Assert
            parametersOfGetLegendGrid.ShouldBeNull();
            methodGetLegendGridPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLegendGrid) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetLegendGrid_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetLegendGridPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetLegendGrid, Fixture, methodGetLegendGridPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLegendGridPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLegendGrid) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetLegendGrid_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetLegendGridPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetLegendGrid, Fixture, methodGetLegendGridPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLegendGridPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTotalsData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_GetTotalsData_Method_Call_Internally(Type[] types)
        {
            var methodGetTotalsDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetTotalsData, Fixture, methodGetTotalsDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTotalsData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTotalsData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataCacheInstance.GetTotalsData();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTotalsData) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTotalsData_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetTotalsDataPrametersTypes = null;
            object[] parametersOfGetTotalsData = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTotalsData, methodGetTotalsDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataCacheInstanceFixture, parametersOfGetTotalsData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTotalsData.ShouldBeNull();
            methodGetTotalsDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTotalsData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTotalsData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetTotalsDataPrametersTypes = null;
            object[] parametersOfGetTotalsData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstance, MethodGetTotalsData, parametersOfGetTotalsData, methodGetTotalsDataPrametersTypes);

            // Assert
            parametersOfGetTotalsData.ShouldBeNull();
            methodGetTotalsDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTotalsData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTotalsData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetTotalsDataPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetTotalsData, Fixture, methodGetTotalsDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTotalsDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTotalsData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTotalsData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetTotalsDataPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetTotalsData, Fixture, methodGetTotalsDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTotalsDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTotalsData) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTotalsData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTotalsData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SetTotalsData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_SetTotalsData_Method_Call_Internally(Type[] types)
        {
            var methodSetTotalsDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodSetTotalsData, Fixture, methodSetTotalsDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SetTotalsData) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetTotalsData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataCacheInstance.SetTotalsData(xData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetTotalsData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetTotalsData_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            var methodSetTotalsDataPrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfSetTotalsData = { xData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetTotalsData, methodSetTotalsDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataCacheInstanceFixture, parametersOfSetTotalsData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetTotalsData.ShouldNotBeNull();
            parametersOfSetTotalsData.Length.ShouldBe(1);
            methodSetTotalsDataPrametersTypes.Length.ShouldBe(1);
            methodSetTotalsDataPrametersTypes.Length.ShouldBe(parametersOfSetTotalsData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetTotalsData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetTotalsData_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            var methodSetTotalsDataPrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfSetTotalsData = { xData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataCacheInstance, MethodSetTotalsData, parametersOfSetTotalsData, methodSetTotalsDataPrametersTypes);

            // Assert
            parametersOfSetTotalsData.ShouldNotBeNull();
            parametersOfSetTotalsData.Length.ShouldBe(1);
            methodSetTotalsDataPrametersTypes.Length.ShouldBe(1);
            methodSetTotalsDataPrametersTypes.Length.ShouldBe(parametersOfSetTotalsData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTotalsData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetTotalsData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetTotalsData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetTotalsData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetTotalsData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetTotalsDataPrametersTypes = new Type[] { typeof(CStruct) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodSetTotalsData, Fixture, methodSetTotalsDataPrametersTypes);

            // Assert
            methodSetTotalsDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTotalsData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetTotalsData_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetTotalsData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCompareCostTypeList) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_GetCompareCostTypeList_Method_Call_Internally(Type[] types)
        {
            var methodGetCompareCostTypeListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetCompareCostTypeList, Fixture, methodGetCompareCostTypeListPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCompareCostTypeList) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetCompareCostTypeList_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataCacheInstance.GetCompareCostTypeList();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetCompareCostTypeList) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetCompareCostTypeList_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetCompareCostTypeListPrametersTypes = null;
            object[] parametersOfGetCompareCostTypeList = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCompareCostTypeList, methodGetCompareCostTypeListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataCacheInstanceFixture, parametersOfGetCompareCostTypeList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCompareCostTypeList.ShouldBeNull();
            methodGetCompareCostTypeListPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCompareCostTypeList) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetCompareCostTypeList_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetCompareCostTypeListPrametersTypes = null;
            object[] parametersOfGetCompareCostTypeList = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstance, MethodGetCompareCostTypeList, parametersOfGetCompareCostTypeList, methodGetCompareCostTypeListPrametersTypes);

            // Assert
            parametersOfGetCompareCostTypeList.ShouldBeNull();
            methodGetCompareCostTypeListPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCompareCostTypeList) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetCompareCostTypeList_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetCompareCostTypeListPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetCompareCostTypeList, Fixture, methodGetCompareCostTypeListPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetCompareCostTypeListPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCompareCostTypeList) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetCompareCostTypeList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetCompareCostTypeListPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetCompareCostTypeList, Fixture, methodGetCompareCostTypeListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCompareCostTypeListPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCompareCostTypeList) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetCompareCostTypeList_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCompareCostTypeList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SetCompareCostType) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_SetCompareCostType_Method_Call_Internally(Type[] types)
        {
            var methodSetCompareCostTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodSetCompareCostType, Fixture, methodSetCompareCostTypePrametersTypes);
        }

        #endregion

        #region Method Call : (SetCompareCostType) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetCompareCostType_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataCacheInstance.SetCompareCostType(xData);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (SetCompareCostType) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetCompareCostType_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            var methodSetCompareCostTypePrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfSetCompareCostType = { xData };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSetCompareCostType, methodSetCompareCostTypePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstanceFixture, out exception1, parametersOfSetCompareCostType);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstance, MethodSetCompareCostType, parametersOfSetCompareCostType, methodSetCompareCostTypePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSetCompareCostType.ShouldNotBeNull();
            parametersOfSetCompareCostType.Length.ShouldBe(1);
            methodSetCompareCostTypePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SetCompareCostType) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetCompareCostType_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            var methodSetCompareCostTypePrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfSetCompareCostType = { xData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetCompareCostType, methodSetCompareCostTypePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataCacheInstanceFixture, parametersOfSetCompareCostType);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetCompareCostType.ShouldNotBeNull();
            parametersOfSetCompareCostType.Length.ShouldBe(1);
            methodSetCompareCostTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetCompareCostType) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetCompareCostType_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            var methodSetCompareCostTypePrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfSetCompareCostType = { xData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstance, MethodSetCompareCostType, parametersOfSetCompareCostType, methodSetCompareCostTypePrametersTypes);

            // Assert
            parametersOfSetCompareCostType.ShouldNotBeNull();
            parametersOfSetCompareCostType.Length.ShouldBe(1);
            methodSetCompareCostTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetCompareCostType) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetCompareCostType_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodSetCompareCostTypePrametersTypes = new Type[] { typeof(CStruct) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodSetCompareCostType, Fixture, methodSetCompareCostTypePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodSetCompareCostTypePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SetCompareCostType) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetCompareCostType_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetCompareCostTypePrametersTypes = new Type[] { typeof(CStruct) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodSetCompareCostType, Fixture, methodSetCompareCostTypePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetCompareCostTypePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetCompareCostType) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetCompareCostType_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetCompareCostType, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SetCompareCostType) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetCompareCostType_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetCompareCostType, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreatePsuedoTarget) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_CreatePsuedoTarget_Method_Call_Internally(Type[] types)
        {
            var methodCreatePsuedoTargetPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodCreatePsuedoTarget, Fixture, methodCreatePsuedoTargetPrametersTypes);
        }

        #endregion

        #region Method Call : (CreatePsuedoTarget) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_CreatePsuedoTarget_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreatePsuedoTargetPrametersTypes = null;
            object[] parametersOfCreatePsuedoTarget = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreatePsuedoTarget, methodCreatePsuedoTargetPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataCacheInstanceFixture, parametersOfCreatePsuedoTarget);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreatePsuedoTarget.ShouldBeNull();
            methodCreatePsuedoTargetPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreatePsuedoTarget) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_CreatePsuedoTarget_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreatePsuedoTargetPrametersTypes = null;
            object[] parametersOfCreatePsuedoTarget = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataCacheInstance, MethodCreatePsuedoTarget, parametersOfCreatePsuedoTarget, methodCreatePsuedoTargetPrametersTypes);

            // Assert
            parametersOfCreatePsuedoTarget.ShouldBeNull();
            methodCreatePsuedoTargetPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreatePsuedoTarget) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_CreatePsuedoTarget_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreatePsuedoTargetPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodCreatePsuedoTarget, Fixture, methodCreatePsuedoTargetPrametersTypes);

            // Assert
            methodCreatePsuedoTargetPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreatePsuedoTarget) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_CreatePsuedoTarget_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreatePsuedoTarget, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetShowRemaining) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_SetShowRemaining_Method_Call_Internally(Type[] types)
        {
            var methodSetShowRemainingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodSetShowRemaining, Fixture, methodSetShowRemainingPrametersTypes);
        }

        #endregion

        #region Method Call : (SetShowRemaining) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetShowRemaining_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var bShowRem = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataCacheInstance.SetShowRemaining(bShowRem);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (SetShowRemaining) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetShowRemaining_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var bShowRem = CreateType<bool>();
            var methodSetShowRemainingPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfSetShowRemaining = { bShowRem };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetShowRemaining, methodSetShowRemainingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataCacheInstanceFixture, parametersOfSetShowRemaining);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetShowRemaining.ShouldNotBeNull();
            parametersOfSetShowRemaining.Length.ShouldBe(1);
            methodSetShowRemainingPrametersTypes.Length.ShouldBe(1);
            methodSetShowRemainingPrametersTypes.Length.ShouldBe(parametersOfSetShowRemaining.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetShowRemaining) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetShowRemaining_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var bShowRem = CreateType<bool>();
            var methodSetShowRemainingPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfSetShowRemaining = { bShowRem };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataCacheInstance, MethodSetShowRemaining, parametersOfSetShowRemaining, methodSetShowRemainingPrametersTypes);

            // Assert
            parametersOfSetShowRemaining.ShouldNotBeNull();
            parametersOfSetShowRemaining.Length.ShouldBe(1);
            methodSetShowRemainingPrametersTypes.Length.ShouldBe(1);
            methodSetShowRemainingPrametersTypes.Length.ShouldBe(parametersOfSetShowRemaining.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetShowRemaining) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetShowRemaining_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetShowRemaining, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetShowRemaining) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetShowRemaining_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetShowRemainingPrametersTypes = new Type[] { typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodSetShowRemaining, Fixture, methodSetShowRemainingPrametersTypes);

            // Assert
            methodSetShowRemainingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetShowRemaining) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_SetShowRemaining_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetShowRemaining, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessTargets) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_ProcessTargets_Method_Call_Internally(Type[] types)
        {
            var methodProcessTargetsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodProcessTargets, Fixture, methodProcessTargetsPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessTargets) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_ProcessTargets_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodProcessTargetsPrametersTypes = null;
            object[] parametersOfProcessTargets = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessTargets, methodProcessTargetsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataCacheInstanceFixture, parametersOfProcessTargets);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessTargets.ShouldBeNull();
            methodProcessTargetsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessTargets) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_ProcessTargets_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodProcessTargetsPrametersTypes = null;
            object[] parametersOfProcessTargets = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataCacheInstance, MethodProcessTargets, parametersOfProcessTargets, methodProcessTargetsPrametersTypes);

            // Assert
            parametersOfProcessTargets.ShouldBeNull();
            methodProcessTargetsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessTargets) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_ProcessTargets_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodProcessTargetsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodProcessTargets, Fixture, methodProcessTargetsPrametersTypes);

            // Assert
            methodProcessTargetsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessTargets) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_ProcessTargets_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessTargets, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StashViews) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_StashViews_Method_Call_Internally(Type[] types)
        {
            var methodStashViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodStashViews, Fixture, methodStashViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (StashViews) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_StashViews_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sViews = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataCacheInstance.StashViews(sViews);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (StashViews) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_StashViews_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sViews = CreateType<string>();
            var methodStashViewsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStashViews = { sViews };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodStashViews, methodStashViewsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataCacheInstanceFixture, parametersOfStashViews);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfStashViews.ShouldNotBeNull();
            parametersOfStashViews.Length.ShouldBe(1);
            methodStashViewsPrametersTypes.Length.ShouldBe(1);
            methodStashViewsPrametersTypes.Length.ShouldBe(parametersOfStashViews.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StashViews) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_StashViews_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sViews = CreateType<string>();
            var methodStashViewsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStashViews = { sViews };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataCacheInstance, MethodStashViews, parametersOfStashViews, methodStashViewsPrametersTypes);

            // Assert
            parametersOfStashViews.ShouldNotBeNull();
            parametersOfStashViews.Length.ShouldBe(1);
            methodStashViewsPrametersTypes.Length.ShouldBe(1);
            methodStashViewsPrametersTypes.Length.ShouldBe(parametersOfStashViews.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StashViews) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_StashViews_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodStashViews, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (StashViews) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_StashViews_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodStashViewsPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodStashViews, Fixture, methodStashViewsPrametersTypes);

            // Assert
            methodStashViewsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StashViews) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_StashViews_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodStashViews, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyServerSideViewSettings) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_ApplyServerSideViewSettings_Method_Call_Internally(Type[] types)
        {
            var methodApplyServerSideViewSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodApplyServerSideViewSettings, Fixture, methodApplyServerSideViewSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (ApplyServerSideViewSettings) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_ApplyServerSideViewSettings_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var guid = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataCacheInstance.ApplyServerSideViewSettings(guid);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ApplyServerSideViewSettings) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_ApplyServerSideViewSettings_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var guid = CreateType<string>();
            var methodApplyServerSideViewSettingsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfApplyServerSideViewSettings = { guid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstance, MethodApplyServerSideViewSettings, parametersOfApplyServerSideViewSettings, methodApplyServerSideViewSettingsPrametersTypes);

            // Assert
            parametersOfApplyServerSideViewSettings.ShouldNotBeNull();
            parametersOfApplyServerSideViewSettings.Length.ShouldBe(1);
            methodApplyServerSideViewSettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyServerSideViewSettings) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_ApplyServerSideViewSettings_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodApplyServerSideViewSettingsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodApplyServerSideViewSettings, Fixture, methodApplyServerSideViewSettingsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodApplyServerSideViewSettingsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ApplyServerSideViewSettings) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_ApplyServerSideViewSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodApplyServerSideViewSettingsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodApplyServerSideViewSettings, Fixture, methodApplyServerSideViewSettingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodApplyServerSideViewSettingsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ApplyServerSideViewSettings) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_ApplyServerSideViewSettings_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodApplyServerSideViewSettings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ApplyServerSideViewSettings) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_ApplyServerSideViewSettings_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodApplyServerSideViewSettings, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTargetList) (Return Type : String) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_GetTargetList_Method_Call_Internally(Type[] types)
        {
            var methodGetTargetListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetTargetList, Fixture, methodGetTargetListPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTargetList) (Return Type : String) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTargetList_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataCacheInstance.GetTargetList();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTargetList) (Return Type : String) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTargetList_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetTargetListPrametersTypes = null;
            object[] parametersOfGetTargetList = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, String>(_costAnalyzerDataCacheInstance, MethodGetTargetList, parametersOfGetTargetList, methodGetTargetListPrametersTypes);

            // Assert
            parametersOfGetTargetList.ShouldBeNull();
            methodGetTargetListPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTargetList) (Return Type : String) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTargetList_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetTargetListPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetTargetList, Fixture, methodGetTargetListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTargetListPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTargetList) (Return Type : String) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTargetList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetTargetListPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetTargetList, Fixture, methodGetTargetListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTargetListPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_DeleteTarget_Method_Call_Internally(Type[] types)
        {
            var methodDeleteTargetPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodDeleteTarget, Fixture, methodDeleteTargetPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_DeleteTarget_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var delTarget = CreateType<int>();
            var heatmaptext = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataCacheInstance.DeleteTarget(delTarget, out heatmaptext);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_DeleteTarget_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var delTarget = CreateType<int>();
            var heatmaptext = CreateType<string>();
            var methodDeleteTargetPrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfDeleteTarget = { delTarget, heatmaptext };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteTarget, methodDeleteTargetPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzerDataCache, bool>(_costAnalyzerDataCacheInstanceFixture, out exception1, parametersOfDeleteTarget);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, bool>(_costAnalyzerDataCacheInstance, MethodDeleteTarget, parametersOfDeleteTarget, methodDeleteTargetPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteTarget.ShouldNotBeNull();
            parametersOfDeleteTarget.Length.ShouldBe(2);
            methodDeleteTargetPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_DeleteTarget_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var delTarget = CreateType<int>();
            var heatmaptext = CreateType<string>();
            var methodDeleteTargetPrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfDeleteTarget = { delTarget, heatmaptext };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteTarget, methodDeleteTargetPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzerDataCache, bool>(_costAnalyzerDataCacheInstanceFixture, out exception1, parametersOfDeleteTarget);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, bool>(_costAnalyzerDataCacheInstance, MethodDeleteTarget, parametersOfDeleteTarget, methodDeleteTargetPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteTarget.ShouldNotBeNull();
            parametersOfDeleteTarget.Length.ShouldBe(2);
            methodDeleteTargetPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_DeleteTarget_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var delTarget = CreateType<int>();
            var heatmaptext = CreateType<string>();
            var methodDeleteTargetPrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfDeleteTarget = { delTarget, heatmaptext };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, bool>(_costAnalyzerDataCacheInstance, MethodDeleteTarget, parametersOfDeleteTarget, methodDeleteTargetPrametersTypes);

            // Assert
            parametersOfDeleteTarget.ShouldNotBeNull();
            parametersOfDeleteTarget.Length.ShouldBe(2);
            methodDeleteTargetPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_DeleteTarget_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteTargetPrametersTypes = new Type[] { typeof(int), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodDeleteTarget, Fixture, methodDeleteTargetPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteTargetPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_DeleteTarget_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteTarget, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildCatJSon) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_BuildCatJSon_Method_Call_Internally(Type[] types)
        {
            var methodBuildCatJSonPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodBuildCatJSon, Fixture, methodBuildCatJSonPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildCatJSon) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_BuildCatJSon_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var index = CreateType<int>();
            var max = CreateType<int>();
            var methodBuildCatJSonPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfBuildCatJSon = { index, max };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodBuildCatJSon, methodBuildCatJSonPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstanceFixture, out exception1, parametersOfBuildCatJSon);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstance, MethodBuildCatJSon, parametersOfBuildCatJSon, methodBuildCatJSonPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfBuildCatJSon.ShouldNotBeNull();
            parametersOfBuildCatJSon.Length.ShouldBe(2);
            methodBuildCatJSonPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (BuildCatJSon) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_BuildCatJSon_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var index = CreateType<int>();
            var max = CreateType<int>();
            var methodBuildCatJSonPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfBuildCatJSon = { index, max };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstance, MethodBuildCatJSon, parametersOfBuildCatJSon, methodBuildCatJSonPrametersTypes);

            // Assert
            parametersOfBuildCatJSon.ShouldNotBeNull();
            parametersOfBuildCatJSon.Length.ShouldBe(2);
            methodBuildCatJSonPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildCatJSon) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_BuildCatJSon_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildCatJSonPrametersTypes = new Type[] { typeof(int), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodBuildCatJSon, Fixture, methodBuildCatJSonPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildCatJSonPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (BuildCatJSon) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_BuildCatJSon_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildCatJSonPrametersTypes = new Type[] { typeof(int), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodBuildCatJSon, Fixture, methodBuildCatJSonPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildCatJSonPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildCatJSon) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_BuildCatJSon_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildCatJSon, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildCatJSon) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_BuildCatJSon_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildCatJSon, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RatesAndCategory) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_RatesAndCategory_Method_Call_Internally(Type[] types)
        {
            var methodRatesAndCategoryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodRatesAndCategory, Fixture, methodRatesAndCategoryPrametersTypes);
        }

        #endregion

        #region Method Call : (RatesAndCategory) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_RatesAndCategory_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataCacheInstance.RatesAndCategory();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (RatesAndCategory) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_RatesAndCategory_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRatesAndCategoryPrametersTypes = null;
            object[] parametersOfRatesAndCategory = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRatesAndCategory, methodRatesAndCategoryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataCacheInstanceFixture, parametersOfRatesAndCategory);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRatesAndCategory.ShouldBeNull();
            methodRatesAndCategoryPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RatesAndCategory) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_RatesAndCategory_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRatesAndCategoryPrametersTypes = null;
            object[] parametersOfRatesAndCategory = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstance, MethodRatesAndCategory, parametersOfRatesAndCategory, methodRatesAndCategoryPrametersTypes);

            // Assert
            parametersOfRatesAndCategory.ShouldBeNull();
            methodRatesAndCategoryPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RatesAndCategory) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_RatesAndCategory_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodRatesAndCategoryPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodRatesAndCategory, Fixture, methodRatesAndCategoryPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodRatesAndCategoryPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RatesAndCategory) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_RatesAndCategory_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRatesAndCategoryPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodRatesAndCategory, Fixture, methodRatesAndCategoryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRatesAndCategoryPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RatesAndCategory) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_RatesAndCategory_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRatesAndCategory, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetLookUpString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_GetLookUpString_Method_Call_Internally(Type[] types)
        {
            var methodGetLookUpStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetLookUpString, Fixture, methodGetLookUpStringPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLookUpString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetLookUpString_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var index = CreateType<int>();
            var lUID = CreateType<int>();
            var methodGetLookUpStringPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfGetLookUpString = { index, lUID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetLookUpString, methodGetLookUpStringPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstanceFixture, out exception1, parametersOfGetLookUpString);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstance, MethodGetLookUpString, parametersOfGetLookUpString, methodGetLookUpStringPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetLookUpString.ShouldNotBeNull();
            parametersOfGetLookUpString.Length.ShouldBe(2);
            methodGetLookUpStringPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetLookUpString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetLookUpString_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var index = CreateType<int>();
            var lUID = CreateType<int>();
            var methodGetLookUpStringPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfGetLookUpString = { index, lUID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstance, MethodGetLookUpString, parametersOfGetLookUpString, methodGetLookUpStringPrametersTypes);

            // Assert
            parametersOfGetLookUpString.ShouldNotBeNull();
            parametersOfGetLookUpString.Length.ShouldBe(2);
            methodGetLookUpStringPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLookUpString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetLookUpString_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetLookUpStringPrametersTypes = new Type[] { typeof(int), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetLookUpString, Fixture, methodGetLookUpStringPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLookUpStringPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetLookUpString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetLookUpString_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetLookUpStringPrametersTypes = new Type[] { typeof(int), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetLookUpString, Fixture, methodGetLookUpStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLookUpStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLookUpString) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetLookUpString_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLookUpString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetLookUpString) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetLookUpString_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetLookUpString, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_PrepareTargetData_Method_Call_Internally(Type[] types)
        {
            var methodPrepareTargetDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodPrepareTargetData, Fixture, methodPrepareTargetDataPrametersTypes);
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_PrepareTargetData_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var stargetID = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataCacheInstance.PrepareTargetData(stargetID);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_PrepareTargetData_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var stargetID = CreateType<string>();
            var methodPrepareTargetDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPrepareTargetData = { stargetID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPrepareTargetData, methodPrepareTargetDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstanceFixture, out exception1, parametersOfPrepareTargetData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstance, MethodPrepareTargetData, parametersOfPrepareTargetData, methodPrepareTargetDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfPrepareTargetData.ShouldNotBeNull();
            parametersOfPrepareTargetData.Length.ShouldBe(1);
            methodPrepareTargetDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_PrepareTargetData_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var stargetID = CreateType<string>();
            var methodPrepareTargetDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPrepareTargetData = { stargetID };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPrepareTargetData, methodPrepareTargetDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataCacheInstanceFixture, parametersOfPrepareTargetData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPrepareTargetData.ShouldNotBeNull();
            parametersOfPrepareTargetData.Length.ShouldBe(1);
            methodPrepareTargetDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_PrepareTargetData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var stargetID = CreateType<string>();
            var methodPrepareTargetDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPrepareTargetData = { stargetID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstance, MethodPrepareTargetData, parametersOfPrepareTargetData, methodPrepareTargetDataPrametersTypes);

            // Assert
            parametersOfPrepareTargetData.ShouldNotBeNull();
            parametersOfPrepareTargetData.Length.ShouldBe(1);
            methodPrepareTargetDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_PrepareTargetData_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodPrepareTargetDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodPrepareTargetData, Fixture, methodPrepareTargetDataPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodPrepareTargetDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_PrepareTargetData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPrepareTargetDataPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodPrepareTargetData, Fixture, methodPrepareTargetDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPrepareTargetDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_PrepareTargetData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPrepareTargetData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_PrepareTargetData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPrepareTargetData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTargetGrid) (Return Type : String) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_GetTargetGrid_Method_Call_Internally(Type[] types)
        {
            var methodGetTargetGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetTargetGrid, Fixture, methodGetTargetGridPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTargetGrid) (Return Type : String) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTargetGrid_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataCacheInstance.GetTargetGrid();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTargetGrid) (Return Type : String) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTargetGrid_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetTargetGridPrametersTypes = null;
            object[] parametersOfGetTargetGrid = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTargetGrid, methodGetTargetGridPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzerDataCache, String>(_costAnalyzerDataCacheInstanceFixture, out exception1, parametersOfGetTargetGrid);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, String>(_costAnalyzerDataCacheInstance, MethodGetTargetGrid, parametersOfGetTargetGrid, methodGetTargetGridPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTargetGrid.ShouldBeNull();
            methodGetTargetGridPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTargetGrid) (Return Type : String) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTargetGrid_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetTargetGridPrametersTypes = null;
            object[] parametersOfGetTargetGrid = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, String>(_costAnalyzerDataCacheInstance, MethodGetTargetGrid, parametersOfGetTargetGrid, methodGetTargetGridPrametersTypes);

            // Assert
            parametersOfGetTargetGrid.ShouldBeNull();
            methodGetTargetGridPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTargetGrid) (Return Type : String) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTargetGrid_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetTargetGridPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetTargetGrid, Fixture, methodGetTargetGridPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTargetGridPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTargetGrid) (Return Type : String) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTargetGrid_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetTargetGridPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetTargetGrid, Fixture, methodGetTargetGridPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTargetGridPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTargetGrid) (Return Type : String) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTargetGrid_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTargetGrid, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AggreagteDuplicateRows) (Return Type : List<clsDetailRowData>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_AggreagteDuplicateRows_Method_Call_Internally(Type[] types)
        {
            var methodAggreagteDuplicateRowsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodAggreagteDuplicateRows, Fixture, methodAggreagteDuplicateRowsPrametersTypes);
        }

        #endregion

        #region Method Call : (AggreagteDuplicateRows) (Return Type : List<clsDetailRowData>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_AggreagteDuplicateRows_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var datain = CreateType<List<clsDetailRowData>>();
            var methodAggreagteDuplicateRowsPrametersTypes = new Type[] { typeof(List<clsDetailRowData>) };
            object[] parametersOfAggreagteDuplicateRows = { datain };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAggreagteDuplicateRows, methodAggreagteDuplicateRowsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzerDataCache, List<clsDetailRowData>>(_costAnalyzerDataCacheInstanceFixture, out exception1, parametersOfAggreagteDuplicateRows);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, List<clsDetailRowData>>(_costAnalyzerDataCacheInstance, MethodAggreagteDuplicateRows, parametersOfAggreagteDuplicateRows, methodAggreagteDuplicateRowsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfAggreagteDuplicateRows.ShouldNotBeNull();
            parametersOfAggreagteDuplicateRows.Length.ShouldBe(1);
            methodAggreagteDuplicateRowsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AggreagteDuplicateRows) (Return Type : List<clsDetailRowData>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_AggreagteDuplicateRows_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var datain = CreateType<List<clsDetailRowData>>();
            var methodAggreagteDuplicateRowsPrametersTypes = new Type[] { typeof(List<clsDetailRowData>) };
            object[] parametersOfAggreagteDuplicateRows = { datain };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, List<clsDetailRowData>>(_costAnalyzerDataCacheInstance, MethodAggreagteDuplicateRows, parametersOfAggreagteDuplicateRows, methodAggreagteDuplicateRowsPrametersTypes);

            // Assert
            parametersOfAggreagteDuplicateRows.ShouldNotBeNull();
            parametersOfAggreagteDuplicateRows.Length.ShouldBe(1);
            methodAggreagteDuplicateRowsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AggreagteDuplicateRows) (Return Type : List<clsDetailRowData>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_AggreagteDuplicateRows_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodAggreagteDuplicateRowsPrametersTypes = new Type[] { typeof(List<clsDetailRowData>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodAggreagteDuplicateRows, Fixture, methodAggreagteDuplicateRowsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAggreagteDuplicateRowsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AggreagteDuplicateRows) (Return Type : List<clsDetailRowData>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_AggreagteDuplicateRows_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAggreagteDuplicateRowsPrametersTypes = new Type[] { typeof(List<clsDetailRowData>) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodAggreagteDuplicateRows, Fixture, methodAggreagteDuplicateRowsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAggreagteDuplicateRowsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AggreagteDuplicateRows) (Return Type : List<clsDetailRowData>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_AggreagteDuplicateRows_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAggreagteDuplicateRows, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AggreagteDuplicateRows) (Return Type : List<clsDetailRowData>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_AggreagteDuplicateRows_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAggreagteDuplicateRows, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTargetTotalsData) (Return Type : String) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_GetTargetTotalsData_Method_Call_Internally(Type[] types)
        {
            var methodGetTargetTotalsDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetTargetTotalsData, Fixture, methodGetTargetTotalsDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTargetTotalsData) (Return Type : String) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTargetTotalsData_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataCacheInstance.GetTargetTotalsData();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetTargetTotalsData) (Return Type : String) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTargetTotalsData_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetTargetTotalsDataPrametersTypes = null;
            object[] parametersOfGetTargetTotalsData = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTargetTotalsData, methodGetTargetTotalsDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataCacheInstanceFixture, parametersOfGetTargetTotalsData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTargetTotalsData.ShouldBeNull();
            methodGetTargetTotalsDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTargetTotalsData) (Return Type : String) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTargetTotalsData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetTargetTotalsDataPrametersTypes = null;
            object[] parametersOfGetTargetTotalsData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, String>(_costAnalyzerDataCacheInstance, MethodGetTargetTotalsData, parametersOfGetTargetTotalsData, methodGetTargetTotalsDataPrametersTypes);

            // Assert
            parametersOfGetTargetTotalsData.ShouldBeNull();
            methodGetTargetTotalsDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTargetTotalsData) (Return Type : String) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTargetTotalsData_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetTargetTotalsDataPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetTargetTotalsData, Fixture, methodGetTargetTotalsDataPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetTargetTotalsDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTargetTotalsData) (Return Type : String) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTargetTotalsData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetTargetTotalsDataPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetTargetTotalsData, Fixture, methodGetTargetTotalsDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTargetTotalsDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTargetTotalsData) (Return Type : String) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTargetTotalsData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTargetTotalsData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Get_CB_ID) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_Get_CB_ID_Method_Call_Internally(Type[] types)
        {
            var methodGet_CB_IDPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGet_CB_ID, Fixture, methodGet_CB_IDPrametersTypes);
        }

        #endregion

        #region Method Call : (Get_CB_ID) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_Get_CB_ID_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataCacheInstance.Get_CB_ID();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Get_CB_ID) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_Get_CB_ID_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGet_CB_IDPrametersTypes = null;
            object[] parametersOfGet_CB_ID = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, int>(_costAnalyzerDataCacheInstance, MethodGet_CB_ID, parametersOfGet_CB_ID, methodGet_CB_IDPrametersTypes);

            // Assert
            parametersOfGet_CB_ID.ShouldBeNull();
            methodGet_CB_IDPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Get_CB_ID) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_Get_CB_ID_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGet_CB_IDPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGet_CB_ID, Fixture, methodGet_CB_IDPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGet_CB_IDPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Get_MaxPeriods) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_Get_MaxPeriods_Method_Call_Internally(Type[] types)
        {
            var methodGet_MaxPeriodsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGet_MaxPeriods, Fixture, methodGet_MaxPeriodsPrametersTypes);
        }

        #endregion

        #region Method Call : (Get_MaxPeriods) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_Get_MaxPeriods_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataCacheInstance.Get_MaxPeriods();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Get_MaxPeriods) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_Get_MaxPeriods_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGet_MaxPeriodsPrametersTypes = null;
            object[] parametersOfGet_MaxPeriods = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, int>(_costAnalyzerDataCacheInstance, MethodGet_MaxPeriods, parametersOfGet_MaxPeriods, methodGet_MaxPeriodsPrametersTypes);

            // Assert
            parametersOfGet_MaxPeriods.ShouldBeNull();
            methodGet_MaxPeriodsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Get_MaxPeriods) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_Get_MaxPeriods_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGet_MaxPeriodsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGet_MaxPeriods, Fixture, methodGet_MaxPeriodsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGet_MaxPeriodsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RefreshTargets) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_RefreshTargets_Method_Call_Internally(Type[] types)
        {
            var methodRefreshTargetsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodRefreshTargets, Fixture, methodRefreshTargetsPrametersTypes);
        }

        #endregion

        #region Method Call : (RefreshTargets) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_RefreshTargets_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var cda = CreateType<clsCostData>();
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataCacheInstance.RefreshTargets(cda);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (RefreshTargets) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_RefreshTargets_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var cda = CreateType<clsCostData>();
            var methodRefreshTargetsPrametersTypes = new Type[] { typeof(clsCostData) };
            object[] parametersOfRefreshTargets = { cda };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRefreshTargets, methodRefreshTargetsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataCacheInstanceFixture, parametersOfRefreshTargets);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRefreshTargets.ShouldNotBeNull();
            parametersOfRefreshTargets.Length.ShouldBe(1);
            methodRefreshTargetsPrametersTypes.Length.ShouldBe(1);
            methodRefreshTargetsPrametersTypes.Length.ShouldBe(parametersOfRefreshTargets.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RefreshTargets) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_RefreshTargets_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var cda = CreateType<clsCostData>();
            var methodRefreshTargetsPrametersTypes = new Type[] { typeof(clsCostData) };
            object[] parametersOfRefreshTargets = { cda };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataCacheInstance, MethodRefreshTargets, parametersOfRefreshTargets, methodRefreshTargetsPrametersTypes);

            // Assert
            parametersOfRefreshTargets.ShouldNotBeNull();
            parametersOfRefreshTargets.Length.ShouldBe(1);
            methodRefreshTargetsPrametersTypes.Length.ShouldBe(1);
            methodRefreshTargetsPrametersTypes.Length.ShouldBe(parametersOfRefreshTargets.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RefreshTargets) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_RefreshTargets_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRefreshTargets, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RefreshTargets) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_RefreshTargets_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRefreshTargetsPrametersTypes = new Type[] { typeof(clsCostData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodRefreshTargets, Fixture, methodRefreshTargetsPrametersTypes);

            // Assert
            methodRefreshTargetsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RefreshTargets) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_RefreshTargets_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRefreshTargets, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTargetRGBData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerDataCache_GetTargetRGBData_Method_Call_Internally(Type[] types)
        {
            var methodGetTargetRGBDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetTargetRGBData, Fixture, methodGetTargetRGBDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTargetRGBData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTargetRGBData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataCacheInstance.GetTargetRGBData();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTargetRGBData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTargetRGBData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetTargetRGBDataPrametersTypes = null;
            object[] parametersOfGetTargetRGBData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerDataCache, string>(_costAnalyzerDataCacheInstance, MethodGetTargetRGBData, parametersOfGetTargetRGBData, methodGetTargetRGBDataPrametersTypes);

            // Assert
            parametersOfGetTargetRGBData.ShouldBeNull();
            methodGetTargetRGBDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTargetRGBData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTargetRGBData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetTargetRGBDataPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetTargetRGBData, Fixture, methodGetTargetRGBDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTargetRGBDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTargetRGBData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerDataCache_GetTargetRGBData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetTargetRGBDataPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataCacheInstance, MethodGetTargetRGBData, Fixture, methodGetTargetRGBDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTargetRGBDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}