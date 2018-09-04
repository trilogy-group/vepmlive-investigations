using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using PortfolioEngineCore;
using Should = Shouldly.Should;
using Shouldly;

namespace RPADataCache
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="RPADataCache.RPAData" />)
    ///     and namespace <see cref="RPADataCache"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class RPADataTest : AbstractBaseSetupTypedTest<RPAData>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RPAData) Initializer

        private const string MethodGrabRAData = "GrabRAData";
        private const string MethodStashCSRoleMode = "StashCSRoleMode";
        private const string MethodIsCSRoleAllowed = "IsCSRoleAllowed";
        private const string MethodSetMajorCatListlookup = "SetMajorCatListlookup";
        private const string MethodItemListAddItem = "ItemListAddItem";
        private const string MethodPopulateInternals = "PopulateInternals";
        private const string MethodDoUserDepts = "DoUserDepts";
        private const string MethodBuileCCR2RoleMap = "BuileCCR2RoleMap";
        private const string MethodMapCCR2Role = "MapCCR2Role";
        private const string MethodConvFTEs = "ConvFTEs";
        private const string MethodConvHRs = "ConvHRs";
        private const string MethodExtractEmbeddedString = "ExtractEmbeddedString";
        private const string MethodGetCostCatStrings = "GetCostCatStrings";
        private const string MethodGetRoleName = "GetRoleName";
        private const string Methodsetupdispcolns = "setupdispcolns";
        private const string MethodReDrawGrid = "ReDrawGrid";
        private const string MethodDoIShowReqType = "DoIShowReqType";
        private const string MethodGetMajorCatStrings = "GetMajorCatStrings";
        private const string MethodGetMajorCat = "GetMajorCat";
        private const string MethodNewRedrawTotals = "NewRedrawTotals";
        private const string MethodGetPeriodName = "GetPeriodName";
        private const string MethodGetTopGrid = "GetTopGrid";
        private const string MethodGetRawDataCount = "GetRawDataCount";
        private const string MethodGetFilteredDataCount = "GetFilteredDataCount";
        private const string MethodGetBottomGrid = "GetBottomGrid";
        private const string MethodGetBottomTotalChartDataGrid = "GetBottomTotalChartDataGrid";
        private const string MethodBottomDetailsDisplay = "BottomDetailsDisplay";
        private const string MethodGetTotalsData = "GetTotalsData";
        private const string MethodSetTotalsData = "SetTotalsData";
        private const string MethodGetDetailsData = "GetDetailsData";
        private const string MethodSetDetailsData = "SetDetailsData";
        private const string MethodSetDisplayMode = "SetDisplayMode";
        private const string MethodGetDisplayMode = "GetDisplayMode";
        private const string MethodSetSelectedForRows = "SetSelectedForRows";
        private const string MethodSetSelectedForTotals = "SetSelectedForTotals";
        private const string MethodSetRADragRows = "SetRADragRows";
        private const string MethodUndoRADragRows = "UndoRADragRows";
        private const string MethodSetFilteredForRows = "SetFilteredForRows";
        private const string MethodPrepareText = "PrepareText";
        private const string MethodAddElement = "AddElement";
        private const string MethodCreatetgLayout = "CreatetgLayout";
        private const string MethodGetTargetRGBData = "GetTargetRGBData";
        private const string MethodCreateNewResFullDAta = "CreateNewResFullDAta";
        private const string MethodStashViews = "StashViews";
        private const string MethodApplyServerSideViewSettings = "ApplyServerSideViewSettings";
        private const string MethodRemoveCapacityScenario = "RemoveCapacityScenario";
        private const string MethodPrepareCSGrid = "PrepareCSGrid";
        private const string MethodGetCapacityScenarioGrid = "GetCapacityScenarioGrid";
        private const string MethodGetLegendGrid = "GetLegendGrid";
        private const string MethodStashCapacityReloadXML = "StashCapacityReloadXML";
        private const string MethodGetCapacityReloadXML = "GetCapacityReloadXML";
        private const string MethodRPASaveDraggedData = "RPASaveDraggedData";
        private const string MethodGetPMOAdmin = "GetPMOAdmin";
        private const string MethodGetStartFinishDataPeriods = "GetStartFinishDataPeriods";
        private const string MethodGetHeatmapText = "GetHeatmapText";
        private const string MethodGetInitialParamXML = "GetInitialParamXML";
        private const string MethodReplaceCSData = "ReplaceCSData";
        private const string MethodUpdateCSDataMode = "UpdateCSDataMode";
        private const string MethodResolvePIName = "ResolvePIName";
        private const string MethodGetRoleScrenarioData = "GetRoleScrenarioData";
        private const string MethodGetNegotiationMode = "GetNegotiationMode";
        private const string MethodGetCSDeptUIDs = "GetCSDeptUIDs";
        private const string MethodGetCSDeptList = "GetCSDeptList";
        private const string MethodSetAllChecks = "SetAllChecks";
        private const string MethodGetEditResPlanPIList = "GetEditResPlanPIList";
        private const string MethodGetEditResPlanResList = "GetEditResPlanResList";
        private const string MethodSetCalledFromResources = "SetCalledFromResources";
        private const string MethodGetCalledFromResources = "GetCalledFromResources";
        private const string MethodGetEditResPlanTicket = "GetEditResPlanTicket";
        private const string MethodGetTotalsGridChartData = "GetTotalsGridChartData";
        private const string Fieldm_pmo_admin = "m_pmo_admin";
        private const string FieldchkOpenRequire = "chkOpenRequire";
        private const string FieldchkNonWork = "chkNonWork";
        private const string Fieldm_MaxUID = "m_MaxUID";
        private const string Fieldm_use_role = "m_use_role";
        private const string Fieldm_use_heatmap = "m_use_heatmap";
        private const string Fieldm_use_heatmapID = "m_use_heatmapID";
        private const string Fieldm_use_heatmapColour = "m_use_heatmapColour";
        private const string Fieldm_cResVals = "m_cResVals";
        private const string Fieldm_maj_Cat_lookup = "m_maj_Cat_lookup";
        private const string Fieldm_reslist = "m_reslist";
        private const string Fieldm_ccrolelist = "m_ccrolelist";
        private const string Fieldm_rolelist = "m_rolelist";
        private const string Fieldm_cln_depts = "m_cln_depts";
        private const string Fieldm_num_per = "m_num_per";
        private const string Fieldm_CCR_Role_Mapping = "m_CCR_Role_Mapping";
        private const string Fieldm_cln_pis = "m_cln_pis";
        private const string Fieldm_resavail = "m_resavail";
        private const string Fieldm_resdata = "m_resdata";
        private const string Fieldm_totmastercln = "m_totmastercln";
        private const string Fieldm_detmastercln = "m_detmastercln";
        private const string Fieldm_cs_perlist = "m_cs_perlist";
        private const string Fieldm_cs_editdata = "m_cs_editdata";
        private const string Fieldm_fte_conv = "m_fte_conv";
        private const string Fieldm_roles = "m_roles";
        private const string FieldchkOffers = "chkOffers";
        private const string FieldchkPend = "chkPend";
        private const string FieldchkRequests = "chkRequests";
        private const string FieldchkCommit = "chkCommit";
        private const string FieldchkActual = "chkActual";
        private const string FieldckkMSPF = "ckkMSPF";
        private const string FieldchkOpenRequest = "chkOpenRequest";
        private const string Fieldm_fromResGrid = "m_fromResGrid";
        private const string Fieldm_role_mode = "m_role_mode";
        private const string Fieldm_clnsort = "m_clnsort";
        private const string FieldTGStandard = "TGStandard";
        private const string FieldTotGeneral = "TotGeneral";
        private const string FieldTotCapacity = "TotCapacity";
        private const string FieldTotCapacityNonRole = "TotCapacityNonRole";
        private const string FieldTotSelectedOrder = "TotSelectedOrder";
        private const string Fieldm_viewsxml = "m_viewsxml";
        private const string Fieldm_reload_cs_data = "m_reload_cs_data";
        private const string Fieldm_DispMode = "m_DispMode";
        private const string Fieldm_StartPerOffset = "m_StartPerOffset";
        private const string Fieldm_useingCal = "m_useingCal";
        private const string Fieldm_drag_stack = "m_drag_stack";
        private const string Fieldm_firstperiod_data = "m_firstperiod_data";
        private const string Fieldm_lastperiod_data = "m_lastperiod_data";
        private const string Fieldm_heatmap_text = "m_heatmap_text";
        private const string Fieldm_hadopen_reqs = "m_hadopen_reqs";
        private const string Fieldm_sParamXML = "m_sParamXML";
        private const string Fieldm_neg_mode = "m_neg_mode";
        private const string Fieldm_CSRoleAllowed = "m_CSRoleAllowed";
        private const string FieldUserDepts = "UserDepts";
        private const string Fieldm_totalschartdata = "m_totalschartdata";
        private const string Fieldm_usedbottomcln = "m_usedbottomcln";
        private const string Fieldm_DisplayTotDetails = "m_DisplayTotDetails";
        private Type _rPADataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RPAData _rPADataInstance;
        private RPAData _rPADataInstanceFixture;

        #region General Initializer : Class (RPAData) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RPAData" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _rPADataInstanceType = typeof(RPAData);
            _rPADataInstanceFixture = Create(true);
            _rPADataInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RPAData)

        #region General Initializer : Class (RPAData) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="RPAData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGrabRAData, 0)]
        [TestCase(MethodStashCSRoleMode, 0)]
        [TestCase(MethodIsCSRoleAllowed, 0)]
        [TestCase(MethodSetMajorCatListlookup, 0)]
        [TestCase(MethodItemListAddItem, 0)]
        [TestCase(MethodPopulateInternals, 0)]
        [TestCase(MethodDoUserDepts, 0)]
        [TestCase(MethodBuileCCR2RoleMap, 0)]
        [TestCase(MethodMapCCR2Role, 0)]
        [TestCase(MethodConvFTEs, 0)]
        [TestCase(MethodConvHRs, 0)]
        [TestCase(MethodExtractEmbeddedString, 0)]
        [TestCase(MethodGetCostCatStrings, 0)]
        [TestCase(MethodGetRoleName, 0)]
        [TestCase(Methodsetupdispcolns, 0)]
        [TestCase(MethodReDrawGrid, 0)]
        [TestCase(MethodDoIShowReqType, 0)]
        [TestCase(MethodGetMajorCatStrings, 0)]
        [TestCase(MethodGetMajorCat, 0)]
        [TestCase(MethodNewRedrawTotals, 0)]
        [TestCase(MethodGetPeriodName, 0)]
        [TestCase(MethodGetTopGrid, 0)]
        [TestCase(MethodGetRawDataCount, 0)]
        [TestCase(MethodGetFilteredDataCount, 0)]
        [TestCase(MethodGetBottomGrid, 0)]
        [TestCase(MethodBottomDetailsDisplay, 0)]
        [TestCase(MethodGetTotalsData, 0)]
        [TestCase(MethodSetTotalsData, 0)]
        [TestCase(MethodGetDetailsData, 0)]
        [TestCase(MethodSetDetailsData, 0)]
        [TestCase(MethodSetDisplayMode, 0)]
        [TestCase(MethodGetDisplayMode, 0)]
        [TestCase(MethodSetSelectedForRows, 0)]
        [TestCase(MethodSetSelectedForTotals, 0)]
        [TestCase(MethodSetRADragRows, 0)]
        [TestCase(MethodUndoRADragRows, 0)]
        [TestCase(MethodSetFilteredForRows, 0)]
        [TestCase(MethodPrepareText, 0)]
        [TestCase(MethodAddElement, 0)]
        [TestCase(MethodCreatetgLayout, 0)]
        [TestCase(MethodGetTargetRGBData, 0)]
        [TestCase(MethodCreateNewResFullDAta, 0)]
        [TestCase(MethodStashViews, 0)]
        [TestCase(MethodApplyServerSideViewSettings, 0)]
        [TestCase(MethodRemoveCapacityScenario, 0)]
        [TestCase(MethodPrepareCSGrid, 0)]
        [TestCase(MethodGetCapacityScenarioGrid, 0)]
        [TestCase(MethodGetLegendGrid, 0)]
        [TestCase(MethodStashCapacityReloadXML, 0)]
        [TestCase(MethodGetCapacityReloadXML, 0)]
        [TestCase(MethodRPASaveDraggedData, 0)]
        [TestCase(MethodGetPMOAdmin, 0)]
        [TestCase(MethodGetStartFinishDataPeriods, 0)]
        [TestCase(MethodGetHeatmapText, 0)]
        [TestCase(MethodGetInitialParamXML, 0)]
        [TestCase(MethodReplaceCSData, 0)]
        [TestCase(MethodUpdateCSDataMode, 0)]
        [TestCase(MethodResolvePIName, 0)]
        [TestCase(MethodGetRoleScrenarioData, 0)]
        [TestCase(MethodGetNegotiationMode, 0)]
        [TestCase(MethodGetCSDeptUIDs, 0)]
        [TestCase(MethodGetCSDeptList, 0)]
        [TestCase(MethodSetAllChecks, 0)]
        [TestCase(MethodGetEditResPlanPIList, 0)]
        [TestCase(MethodGetEditResPlanResList, 0)]
        [TestCase(MethodSetCalledFromResources, 0)]
        [TestCase(MethodGetCalledFromResources, 0)]
        [TestCase(MethodGetEditResPlanTicket, 0)]
        [TestCase(MethodGetTotalsGridChartData, 0)]
        public void AUT_RPAData_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_rPADataInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (RPAData) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RPAData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldm_pmo_admin)]
        [TestCase(FieldchkOpenRequire)]
        [TestCase(FieldchkNonWork)]
        [TestCase(Fieldm_MaxUID)]
        [TestCase(Fieldm_use_role)]
        [TestCase(Fieldm_use_heatmap)]
        [TestCase(Fieldm_use_heatmapID)]
        [TestCase(Fieldm_use_heatmapColour)]
        [TestCase(Fieldm_cResVals)]
        [TestCase(Fieldm_maj_Cat_lookup)]
        [TestCase(Fieldm_reslist)]
        [TestCase(Fieldm_ccrolelist)]
        [TestCase(Fieldm_rolelist)]
        [TestCase(Fieldm_cln_depts)]
        [TestCase(Fieldm_num_per)]
        [TestCase(Fieldm_CCR_Role_Mapping)]
        [TestCase(Fieldm_cln_pis)]
        [TestCase(Fieldm_resavail)]
        [TestCase(Fieldm_resdata)]
        [TestCase(Fieldm_totmastercln)]
        [TestCase(Fieldm_detmastercln)]
        [TestCase(Fieldm_cs_perlist)]
        [TestCase(Fieldm_cs_editdata)]
        [TestCase(Fieldm_fte_conv)]
        [TestCase(Fieldm_roles)]
        [TestCase(FieldchkOffers)]
        [TestCase(FieldchkPend)]
        [TestCase(FieldchkRequests)]
        [TestCase(FieldchkCommit)]
        [TestCase(FieldchkActual)]
        [TestCase(FieldckkMSPF)]
        [TestCase(FieldchkOpenRequest)]
        [TestCase(Fieldm_fromResGrid)]
        [TestCase(Fieldm_role_mode)]
        [TestCase(Fieldm_clnsort)]
        [TestCase(FieldTGStandard)]
        [TestCase(FieldTotGeneral)]
        [TestCase(FieldTotCapacity)]
        [TestCase(FieldTotCapacityNonRole)]
        [TestCase(FieldTotSelectedOrder)]
        [TestCase(Fieldm_viewsxml)]
        [TestCase(Fieldm_reload_cs_data)]
        [TestCase(Fieldm_DispMode)]
        [TestCase(Fieldm_StartPerOffset)]
        [TestCase(Fieldm_useingCal)]
        [TestCase(Fieldm_drag_stack)]
        [TestCase(Fieldm_firstperiod_data)]
        [TestCase(Fieldm_lastperiod_data)]
        [TestCase(Fieldm_heatmap_text)]
        [TestCase(Fieldm_hadopen_reqs)]
        [TestCase(Fieldm_sParamXML)]
        [TestCase(Fieldm_neg_mode)]
        [TestCase(Fieldm_CSRoleAllowed)]
        [TestCase(FieldUserDepts)]
        [TestCase(Fieldm_totalschartdata)]
        [TestCase(Fieldm_usedbottomcln)]
        [TestCase(Fieldm_DisplayTotDetails)]
        public void AUT_RPAData_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_rPADataInstanceFixture, 
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
        ///     Class (<see cref="RPAData" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_RPAData_Is_Instance_Present_Test()
        {
            // Assert
            _rPADataInstanceType.ShouldNotBeNull();
            _rPADataInstance.ShouldNotBeNull();
            _rPADataInstanceFixture.ShouldNotBeNull();
            _rPADataInstance.ShouldBeAssignableTo<RPAData>();
            _rPADataInstanceFixture.ShouldBeAssignableTo<RPAData>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RPAData) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_RPAData_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RPAData instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _rPADataInstanceType.ShouldNotBeNull();
            _rPADataInstance.ShouldNotBeNull();
            _rPADataInstanceFixture.ShouldNotBeNull();
            _rPADataInstance.ShouldBeAssignableTo<RPAData>();
            _rPADataInstanceFixture.ShouldBeAssignableTo<RPAData>();
        }

        #endregion

        #region General Constructor : Class (RPAData) Default Assignment Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_RPAData_Constructor_Instantiated_With_Default_Assignments_Test()
        {

            // Act
            var rPADataInstance  = new RPAData();

            // Asserts
            rPADataInstance.ShouldNotBeNull();
            rPADataInstance.ShouldBeAssignableTo<RPAData>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="RPAData" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetPeriodName)]
        public void AUT_RPAData_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_rPADataInstanceFixture,
                                                                              _rPADataInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="RPAData" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGrabRAData)]
        [TestCase(MethodStashCSRoleMode)]
        [TestCase(MethodIsCSRoleAllowed)]
        [TestCase(MethodSetMajorCatListlookup)]
        [TestCase(MethodItemListAddItem)]
        [TestCase(MethodPopulateInternals)]
        [TestCase(MethodDoUserDepts)]
        [TestCase(MethodBuileCCR2RoleMap)]
        [TestCase(MethodMapCCR2Role)]
        [TestCase(MethodConvFTEs)]
        [TestCase(MethodConvHRs)]
        [TestCase(MethodExtractEmbeddedString)]
        [TestCase(MethodGetCostCatStrings)]
        [TestCase(MethodGetRoleName)]
        [TestCase(Methodsetupdispcolns)]
        [TestCase(MethodReDrawGrid)]
        [TestCase(MethodDoIShowReqType)]
        [TestCase(MethodGetMajorCatStrings)]
        [TestCase(MethodGetMajorCat)]
        [TestCase(MethodNewRedrawTotals)]
        [TestCase(MethodGetTopGrid)]
        [TestCase(MethodGetRawDataCount)]
        [TestCase(MethodGetFilteredDataCount)]
        [TestCase(MethodGetBottomGrid)]
        [TestCase(MethodBottomDetailsDisplay)]
        [TestCase(MethodGetTotalsData)]
        [TestCase(MethodSetTotalsData)]
        [TestCase(MethodGetDetailsData)]
        [TestCase(MethodSetDetailsData)]
        [TestCase(MethodSetDisplayMode)]
        [TestCase(MethodGetDisplayMode)]
        [TestCase(MethodSetSelectedForRows)]
        [TestCase(MethodSetSelectedForTotals)]
        [TestCase(MethodSetRADragRows)]
        [TestCase(MethodUndoRADragRows)]
        [TestCase(MethodSetFilteredForRows)]
        [TestCase(MethodPrepareText)]
        [TestCase(MethodAddElement)]
        [TestCase(MethodCreatetgLayout)]
        [TestCase(MethodGetTargetRGBData)]
        [TestCase(MethodCreateNewResFullDAta)]
        [TestCase(MethodStashViews)]
        [TestCase(MethodApplyServerSideViewSettings)]
        [TestCase(MethodRemoveCapacityScenario)]
        [TestCase(MethodPrepareCSGrid)]
        [TestCase(MethodGetCapacityScenarioGrid)]
        [TestCase(MethodGetLegendGrid)]
        [TestCase(MethodStashCapacityReloadXML)]
        [TestCase(MethodGetCapacityReloadXML)]
        [TestCase(MethodRPASaveDraggedData)]
        [TestCase(MethodGetPMOAdmin)]
        [TestCase(MethodGetStartFinishDataPeriods)]
        [TestCase(MethodGetHeatmapText)]
        [TestCase(MethodGetInitialParamXML)]
        [TestCase(MethodReplaceCSData)]
        [TestCase(MethodUpdateCSDataMode)]
        [TestCase(MethodResolvePIName)]
        [TestCase(MethodGetRoleScrenarioData)]
        [TestCase(MethodGetNegotiationMode)]
        [TestCase(MethodGetCSDeptUIDs)]
        [TestCase(MethodGetCSDeptList)]
        [TestCase(MethodSetAllChecks)]
        [TestCase(MethodGetEditResPlanPIList)]
        [TestCase(MethodGetEditResPlanResList)]
        [TestCase(MethodSetCalledFromResources)]
        [TestCase(MethodGetCalledFromResources)]
        [TestCase(MethodGetEditResPlanTicket)]
        [TestCase(MethodGetTotalsGridChartData)]
        public void AUT_RPAData_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<RPAData>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GrabRAData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GrabRAData_Method_Call_Internally(Type[] types)
        {
            var methodGrabRADataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGrabRAData, Fixture, methodGrabRADataPrametersTypes);
        }

        #endregion
        
        #region Method Call : (GrabRAData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GrabRAData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGrabRAData, 0);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion
        
        #region Method Call : (GrabRAData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GrabRAData_Method_Call_With_7_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGrabRAData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion
        
        #region Method Call : (StashCSRoleMode) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_StashCSRoleMode_Method_Call_Internally(Type[] types)
        {
            var methodStashCSRoleModePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodStashCSRoleMode, Fixture, methodStashCSRoleModePrametersTypes);
        }

        #endregion

        #region Method Call : (StashCSRoleMode) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_StashCSRoleMode_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var bAllowed = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.StashCSRoleMode(bAllowed);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (StashCSRoleMode) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_StashCSRoleMode_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var bAllowed = CreateType<bool>();
            var methodStashCSRoleModePrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfStashCSRoleMode = { bAllowed };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodStashCSRoleMode, methodStashCSRoleModePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfStashCSRoleMode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfStashCSRoleMode.ShouldNotBeNull();
            parametersOfStashCSRoleMode.Length.ShouldBe(1);
            methodStashCSRoleModePrametersTypes.Length.ShouldBe(1);
            methodStashCSRoleModePrametersTypes.Length.ShouldBe(parametersOfStashCSRoleMode.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StashCSRoleMode) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_StashCSRoleMode_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var bAllowed = CreateType<bool>();
            var methodStashCSRoleModePrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfStashCSRoleMode = { bAllowed };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rPADataInstance, MethodStashCSRoleMode, parametersOfStashCSRoleMode, methodStashCSRoleModePrametersTypes);

            // Assert
            parametersOfStashCSRoleMode.ShouldNotBeNull();
            parametersOfStashCSRoleMode.Length.ShouldBe(1);
            methodStashCSRoleModePrametersTypes.Length.ShouldBe(1);
            methodStashCSRoleModePrametersTypes.Length.ShouldBe(parametersOfStashCSRoleMode.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StashCSRoleMode) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_StashCSRoleMode_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodStashCSRoleMode, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (StashCSRoleMode) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_StashCSRoleMode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodStashCSRoleModePrametersTypes = new Type[] { typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodStashCSRoleMode, Fixture, methodStashCSRoleModePrametersTypes);

            // Assert
            methodStashCSRoleModePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StashCSRoleMode) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_StashCSRoleMode_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodStashCSRoleMode, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsCSRoleAllowed) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_IsCSRoleAllowed_Method_Call_Internally(Type[] types)
        {
            var methodIsCSRoleAllowedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodIsCSRoleAllowed, Fixture, methodIsCSRoleAllowedPrametersTypes);
        }

        #endregion

        #region Method Call : (IsCSRoleAllowed) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_IsCSRoleAllowed_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.IsCSRoleAllowed();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (IsCSRoleAllowed) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_IsCSRoleAllowed_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodIsCSRoleAllowedPrametersTypes = null;
            object[] parametersOfIsCSRoleAllowed = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsCSRoleAllowed, methodIsCSRoleAllowedPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RPAData, bool>(_rPADataInstanceFixture, out exception1, parametersOfIsCSRoleAllowed);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RPAData, bool>(_rPADataInstance, MethodIsCSRoleAllowed, parametersOfIsCSRoleAllowed, methodIsCSRoleAllowedPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsCSRoleAllowed.ShouldBeNull();
            methodIsCSRoleAllowedPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsCSRoleAllowed) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_IsCSRoleAllowed_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodIsCSRoleAllowedPrametersTypes = null;
            object[] parametersOfIsCSRoleAllowed = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsCSRoleAllowed, methodIsCSRoleAllowedPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RPAData, bool>(_rPADataInstanceFixture, out exception1, parametersOfIsCSRoleAllowed);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RPAData, bool>(_rPADataInstance, MethodIsCSRoleAllowed, parametersOfIsCSRoleAllowed, methodIsCSRoleAllowedPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsCSRoleAllowed.ShouldBeNull();
            methodIsCSRoleAllowedPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsCSRoleAllowed) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_IsCSRoleAllowed_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodIsCSRoleAllowedPrametersTypes = null;
            object[] parametersOfIsCSRoleAllowed = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodIsCSRoleAllowed, methodIsCSRoleAllowedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfIsCSRoleAllowed);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfIsCSRoleAllowed.ShouldBeNull();
            methodIsCSRoleAllowedPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsCSRoleAllowed) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_IsCSRoleAllowed_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodIsCSRoleAllowedPrametersTypes = null;
            object[] parametersOfIsCSRoleAllowed = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, bool>(_rPADataInstance, MethodIsCSRoleAllowed, parametersOfIsCSRoleAllowed, methodIsCSRoleAllowedPrametersTypes);

            // Assert
            parametersOfIsCSRoleAllowed.ShouldBeNull();
            methodIsCSRoleAllowedPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsCSRoleAllowed) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_IsCSRoleAllowed_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodIsCSRoleAllowedPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodIsCSRoleAllowed, Fixture, methodIsCSRoleAllowedPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodIsCSRoleAllowedPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsCSRoleAllowed) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_IsCSRoleAllowed_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodIsCSRoleAllowedPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodIsCSRoleAllowed, Fixture, methodIsCSRoleAllowedPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodIsCSRoleAllowedPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsCSRoleAllowed) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_IsCSRoleAllowed_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodIsCSRoleAllowedPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodIsCSRoleAllowed, Fixture, methodIsCSRoleAllowedPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsCSRoleAllowedPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsCSRoleAllowed) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_IsCSRoleAllowed_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsCSRoleAllowed, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SetMajorCatListlookup) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_SetMajorCatListlookup_Method_Call_Internally(Type[] types)
        {
            var methodSetMajorCatListlookupPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodSetMajorCatListlookup, Fixture, methodSetMajorCatListlookupPrametersTypes);
        }

        #endregion

        #region Method Call : (SetMajorCatListlookup) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetMajorCatListlookup_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodSetMajorCatListlookupPrametersTypes = null;
            object[] parametersOfSetMajorCatListlookup = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetMajorCatListlookup, methodSetMajorCatListlookupPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfSetMajorCatListlookup);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetMajorCatListlookup.ShouldBeNull();
            methodSetMajorCatListlookupPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetMajorCatListlookup) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetMajorCatListlookup_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodSetMajorCatListlookupPrametersTypes = null;
            object[] parametersOfSetMajorCatListlookup = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rPADataInstance, MethodSetMajorCatListlookup, parametersOfSetMajorCatListlookup, methodSetMajorCatListlookupPrametersTypes);

            // Assert
            parametersOfSetMajorCatListlookup.ShouldBeNull();
            methodSetMajorCatListlookupPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetMajorCatListlookup) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetMajorCatListlookup_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodSetMajorCatListlookupPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodSetMajorCatListlookup, Fixture, methodSetMajorCatListlookupPrametersTypes);

            // Assert
            methodSetMajorCatListlookupPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetMajorCatListlookup) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetMajorCatListlookup_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetMajorCatListlookup, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemListAddItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_ItemListAddItem_Method_Call_Internally(Type[] types)
        {
            var methodItemListAddItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodItemListAddItem, Fixture, methodItemListAddItemPrametersTypes);
        }

        #endregion
        
        #region Method Call : (ItemListAddItem) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ItemListAddItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodItemListAddItem, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion
        
        #region Method Call : (ItemListAddItem) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ItemListAddItem_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemListAddItem, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateInternals) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_PopulateInternals_Method_Call_Internally(Type[] types)
        {
            var methodPopulateInternalsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodPopulateInternals, Fixture, methodPopulateInternalsPrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateInternals) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_PopulateInternals_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var serrlog = CreateType<string>();
            var methodPopulateInternalsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPopulateInternals = { serrlog };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPopulateInternals, methodPopulateInternalsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfPopulateInternals);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPopulateInternals.ShouldNotBeNull();
            parametersOfPopulateInternals.Length.ShouldBe(1);
            methodPopulateInternalsPrametersTypes.Length.ShouldBe(1);
            methodPopulateInternalsPrametersTypes.Length.ShouldBe(parametersOfPopulateInternals.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PopulateInternals) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_PopulateInternals_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var serrlog = CreateType<string>();
            var methodPopulateInternalsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPopulateInternals = { serrlog };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rPADataInstance, MethodPopulateInternals, parametersOfPopulateInternals, methodPopulateInternalsPrametersTypes);

            // Assert
            parametersOfPopulateInternals.ShouldNotBeNull();
            parametersOfPopulateInternals.Length.ShouldBe(1);
            methodPopulateInternalsPrametersTypes.Length.ShouldBe(1);
            methodPopulateInternalsPrametersTypes.Length.ShouldBe(parametersOfPopulateInternals.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateInternals) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_PopulateInternals_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPopulateInternals, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateInternals) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_PopulateInternals_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPopulateInternalsPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodPopulateInternals, Fixture, methodPopulateInternalsPrametersTypes);

            // Assert
            methodPopulateInternalsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateInternals) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_PopulateInternals_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateInternals, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoUserDepts) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_DoUserDepts_Method_Call_Internally(Type[] types)
        {
            var methodDoUserDeptsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodDoUserDepts, Fixture, methodDoUserDeptsPrametersTypes);
        }

        #endregion

        #region Method Call : (DoUserDepts) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_DoUserDepts_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodDoUserDeptsPrametersTypes = null;
            object[] parametersOfDoUserDepts = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDoUserDepts, methodDoUserDeptsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfDoUserDepts);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDoUserDepts.ShouldBeNull();
            methodDoUserDeptsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoUserDepts) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_DoUserDepts_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodDoUserDeptsPrametersTypes = null;
            object[] parametersOfDoUserDepts = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rPADataInstance, MethodDoUserDepts, parametersOfDoUserDepts, methodDoUserDeptsPrametersTypes);

            // Assert
            parametersOfDoUserDepts.ShouldBeNull();
            methodDoUserDeptsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoUserDepts) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_DoUserDepts_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodDoUserDeptsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodDoUserDepts, Fixture, methodDoUserDeptsPrametersTypes);

            // Assert
            methodDoUserDeptsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoUserDepts) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_DoUserDepts_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDoUserDepts, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuileCCR2RoleMap) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_BuileCCR2RoleMap_Method_Call_Internally(Type[] types)
        {
            var methodBuileCCR2RoleMapPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodBuileCCR2RoleMap, Fixture, methodBuileCCR2RoleMapPrametersTypes);
        }

        #endregion

        #region Method Call : (BuileCCR2RoleMap) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_BuileCCR2RoleMap_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodBuileCCR2RoleMapPrametersTypes = null;
            object[] parametersOfBuileCCR2RoleMap = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuileCCR2RoleMap, methodBuileCCR2RoleMapPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfBuileCCR2RoleMap);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuileCCR2RoleMap.ShouldBeNull();
            methodBuileCCR2RoleMapPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuileCCR2RoleMap) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_BuileCCR2RoleMap_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodBuileCCR2RoleMapPrametersTypes = null;
            object[] parametersOfBuileCCR2RoleMap = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rPADataInstance, MethodBuileCCR2RoleMap, parametersOfBuileCCR2RoleMap, methodBuileCCR2RoleMapPrametersTypes);

            // Assert
            parametersOfBuileCCR2RoleMap.ShouldBeNull();
            methodBuileCCR2RoleMapPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuileCCR2RoleMap) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_BuileCCR2RoleMap_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodBuileCCR2RoleMapPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodBuileCCR2RoleMap, Fixture, methodBuileCCR2RoleMapPrametersTypes);

            // Assert
            methodBuileCCR2RoleMapPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuileCCR2RoleMap) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_BuileCCR2RoleMap_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuileCCR2RoleMap, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MapCCR2Role) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_MapCCR2Role_Method_Call_Internally(Type[] types)
        {
            var methodMapCCR2RolePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodMapCCR2Role, Fixture, methodMapCCR2RolePrametersTypes);
        }

        #endregion

        #region Method Call : (MapCCR2Role) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_MapCCR2Role_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var ccr = CreateType<int>();
            var methodMapCCR2RolePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfMapCCR2Role = { ccr };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodMapCCR2Role, methodMapCCR2RolePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RPAData, int>(_rPADataInstanceFixture, out exception1, parametersOfMapCCR2Role);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RPAData, int>(_rPADataInstance, MethodMapCCR2Role, parametersOfMapCCR2Role, methodMapCCR2RolePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfMapCCR2Role.ShouldNotBeNull();
            parametersOfMapCCR2Role.Length.ShouldBe(1);
            methodMapCCR2RolePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (MapCCR2Role) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_MapCCR2Role_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var ccr = CreateType<int>();
            var methodMapCCR2RolePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfMapCCR2Role = { ccr };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodMapCCR2Role, methodMapCCR2RolePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RPAData, int>(_rPADataInstanceFixture, out exception1, parametersOfMapCCR2Role);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RPAData, int>(_rPADataInstance, MethodMapCCR2Role, parametersOfMapCCR2Role, methodMapCCR2RolePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfMapCCR2Role.ShouldNotBeNull();
            parametersOfMapCCR2Role.Length.ShouldBe(1);
            methodMapCCR2RolePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (MapCCR2Role) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_MapCCR2Role_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var ccr = CreateType<int>();
            var methodMapCCR2RolePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfMapCCR2Role = { ccr };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodMapCCR2Role, methodMapCCR2RolePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfMapCCR2Role);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfMapCCR2Role.ShouldNotBeNull();
            parametersOfMapCCR2Role.Length.ShouldBe(1);
            methodMapCCR2RolePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MapCCR2Role) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_MapCCR2Role_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ccr = CreateType<int>();
            var methodMapCCR2RolePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfMapCCR2Role = { ccr };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, int>(_rPADataInstance, MethodMapCCR2Role, parametersOfMapCCR2Role, methodMapCCR2RolePrametersTypes);

            // Assert
            parametersOfMapCCR2Role.ShouldNotBeNull();
            parametersOfMapCCR2Role.Length.ShouldBe(1);
            methodMapCCR2RolePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MapCCR2Role) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_MapCCR2Role_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodMapCCR2RolePrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodMapCCR2Role, Fixture, methodMapCCR2RolePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodMapCCR2RolePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (MapCCR2Role) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_MapCCR2Role_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodMapCCR2Role, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (MapCCR2Role) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_MapCCR2Role_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodMapCCR2Role, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConvFTEs) (Return Type : double) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_ConvFTEs_Method_Call_Internally(Type[] types)
        {
            var methodConvFTEsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodConvFTEs, Fixture, methodConvFTEsPrametersTypes);
        }

        #endregion

        #region Method Call : (ConvFTEs) (Return Type : double) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ConvFTEs_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var dFTEs = CreateType<double>();
            var methodConvFTEsPrametersTypes = new Type[] { typeof(double) };
            object[] parametersOfConvFTEs = { dFTEs };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodConvFTEs, methodConvFTEsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfConvFTEs);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfConvFTEs.ShouldNotBeNull();
            parametersOfConvFTEs.Length.ShouldBe(1);
            methodConvFTEsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvFTEs) (Return Type : double) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ConvFTEs_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dFTEs = CreateType<double>();
            var methodConvFTEsPrametersTypes = new Type[] { typeof(double) };
            object[] parametersOfConvFTEs = { dFTEs };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, double>(_rPADataInstance, MethodConvFTEs, parametersOfConvFTEs, methodConvFTEsPrametersTypes);

            // Assert
            parametersOfConvFTEs.ShouldNotBeNull();
            parametersOfConvFTEs.Length.ShouldBe(1);
            methodConvFTEsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvFTEs) (Return Type : double) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ConvFTEs_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodConvFTEsPrametersTypes = new Type[] { typeof(double) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodConvFTEs, Fixture, methodConvFTEsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodConvFTEsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConvFTEs) (Return Type : double) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ConvFTEs_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConvFTEs, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ConvFTEs) (Return Type : double) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ConvFTEs_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodConvFTEs, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConvHRs) (Return Type : double) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_ConvHRs_Method_Call_Internally(Type[] types)
        {
            var methodConvHRsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodConvHRs, Fixture, methodConvHRsPrametersTypes);
        }

        #endregion

        #region Method Call : (ConvHRs) (Return Type : double) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ConvHRs_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var dhrs = CreateType<double>();
            var methodConvHRsPrametersTypes = new Type[] { typeof(double) };
            object[] parametersOfConvHRs = { dhrs };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodConvHRs, methodConvHRsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfConvHRs);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfConvHRs.ShouldNotBeNull();
            parametersOfConvHRs.Length.ShouldBe(1);
            methodConvHRsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvHRs) (Return Type : double) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ConvHRs_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dhrs = CreateType<double>();
            var methodConvHRsPrametersTypes = new Type[] { typeof(double) };
            object[] parametersOfConvHRs = { dhrs };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, double>(_rPADataInstance, MethodConvHRs, parametersOfConvHRs, methodConvHRsPrametersTypes);

            // Assert
            parametersOfConvHRs.ShouldNotBeNull();
            parametersOfConvHRs.Length.ShouldBe(1);
            methodConvHRsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvHRs) (Return Type : double) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ConvHRs_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodConvHRsPrametersTypes = new Type[] { typeof(double) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodConvHRs, Fixture, methodConvHRsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodConvHRsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConvHRs) (Return Type : double) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ConvHRs_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConvHRs, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ConvHRs) (Return Type : double) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ConvHRs_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodConvHRs, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExtractEmbeddedString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_ExtractEmbeddedString_Method_Call_Internally(Type[] types)
        {
            var methodExtractEmbeddedStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodExtractEmbeddedString, Fixture, methodExtractEmbeddedStringPrametersTypes);
        }

        #endregion

        #region Method Call : (ExtractEmbeddedString) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ExtractEmbeddedString_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sin = CreateType<string>();
            var methodExtractEmbeddedStringPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfExtractEmbeddedString = { sin };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodExtractEmbeddedString, methodExtractEmbeddedStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfExtractEmbeddedString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfExtractEmbeddedString.ShouldNotBeNull();
            parametersOfExtractEmbeddedString.Length.ShouldBe(1);
            methodExtractEmbeddedStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExtractEmbeddedString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ExtractEmbeddedString_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sin = CreateType<string>();
            var methodExtractEmbeddedStringPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfExtractEmbeddedString = { sin };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodExtractEmbeddedString, parametersOfExtractEmbeddedString, methodExtractEmbeddedStringPrametersTypes);

            // Assert
            parametersOfExtractEmbeddedString.ShouldNotBeNull();
            parametersOfExtractEmbeddedString.Length.ShouldBe(1);
            methodExtractEmbeddedStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExtractEmbeddedString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ExtractEmbeddedString_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodExtractEmbeddedStringPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodExtractEmbeddedString, Fixture, methodExtractEmbeddedStringPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodExtractEmbeddedStringPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ExtractEmbeddedString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ExtractEmbeddedString_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExtractEmbeddedStringPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodExtractEmbeddedString, Fixture, methodExtractEmbeddedStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExtractEmbeddedStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExtractEmbeddedString) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ExtractEmbeddedString_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExtractEmbeddedString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ExtractEmbeddedString) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ExtractEmbeddedString_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExtractEmbeddedString, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCostCatStrings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetCostCatStrings_Method_Call_Internally(Type[] types)
        {
            var methodGetCostCatStringsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetCostCatStrings, Fixture, methodGetCostCatStringsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCostCatStrings) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCostCatStrings_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var lUID = CreateType<int>();
            var sShort = CreateType<string>();
            var sFull = CreateType<string>();
            var methodGetCostCatStringsPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(string) };
            object[] parametersOfGetCostCatStrings = { lUID, sShort, sFull };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCostCatStrings, methodGetCostCatStringsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfGetCostCatStrings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCostCatStrings.ShouldNotBeNull();
            parametersOfGetCostCatStrings.Length.ShouldBe(3);
            methodGetCostCatStringsPrametersTypes.Length.ShouldBe(3);
            methodGetCostCatStringsPrametersTypes.Length.ShouldBe(parametersOfGetCostCatStrings.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCostCatStrings) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCostCatStrings_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var lUID = CreateType<int>();
            var sShort = CreateType<string>();
            var sFull = CreateType<string>();
            var methodGetCostCatStringsPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(string) };
            object[] parametersOfGetCostCatStrings = { lUID, sShort, sFull };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rPADataInstance, MethodGetCostCatStrings, parametersOfGetCostCatStrings, methodGetCostCatStringsPrametersTypes);

            // Assert
            parametersOfGetCostCatStrings.ShouldNotBeNull();
            parametersOfGetCostCatStrings.Length.ShouldBe(3);
            methodGetCostCatStringsPrametersTypes.Length.ShouldBe(3);
            methodGetCostCatStringsPrametersTypes.Length.ShouldBe(parametersOfGetCostCatStrings.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCostCatStrings) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCostCatStrings_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCostCatStrings, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCostCatStrings) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCostCatStrings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCostCatStringsPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetCostCatStrings, Fixture, methodGetCostCatStringsPrametersTypes);

            // Assert
            methodGetCostCatStringsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCostCatStrings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCostCatStrings_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCostCatStrings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRoleName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetRoleName_Method_Call_Internally(Type[] types)
        {
            var methodGetRoleNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetRoleName, Fixture, methodGetRoleNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetRoleName) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetRoleName_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var ruid = CreateType<int>();
            var methodGetRoleNamePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetRoleName = { ruid };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetRoleName, methodGetRoleNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfGetRoleName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetRoleName.ShouldNotBeNull();
            parametersOfGetRoleName.Length.ShouldBe(1);
            methodGetRoleNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRoleName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetRoleName_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ruid = CreateType<int>();
            var methodGetRoleNamePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetRoleName = { ruid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetRoleName, parametersOfGetRoleName, methodGetRoleNamePrametersTypes);

            // Assert
            parametersOfGetRoleName.ShouldNotBeNull();
            parametersOfGetRoleName.Length.ShouldBe(1);
            methodGetRoleNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRoleName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetRoleName_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetRoleNamePrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetRoleName, Fixture, methodGetRoleNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetRoleNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetRoleName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetRoleName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRoleNamePrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetRoleName, Fixture, methodGetRoleNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRoleNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRoleName) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetRoleName_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRoleName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetRoleName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetRoleName_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRoleName, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setupdispcolns) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_setupdispcolns_Method_Call_Internally(Type[] types)
        {
            var methodsetupdispcolnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, Methodsetupdispcolns, Fixture, methodsetupdispcolnsPrametersTypes);
        }

        #endregion

        #region Method Call : (setupdispcolns) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_setupdispcolns_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var errlog = CreateType<string>();
            var methodsetupdispcolnsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfsetupdispcolns = { errlog };
            Exception exception = null;
            var methodInfo = GetMethodInfo(Methodsetupdispcolns, methodsetupdispcolnsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfsetupdispcolns);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsetupdispcolns.ShouldNotBeNull();
            parametersOfsetupdispcolns.Length.ShouldBe(1);
            methodsetupdispcolnsPrametersTypes.Length.ShouldBe(1);
            methodsetupdispcolnsPrametersTypes.Length.ShouldBe(parametersOfsetupdispcolns.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setupdispcolns) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_setupdispcolns_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var errlog = CreateType<string>();
            var methodsetupdispcolnsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfsetupdispcolns = { errlog };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rPADataInstance, Methodsetupdispcolns, parametersOfsetupdispcolns, methodsetupdispcolnsPrametersTypes);

            // Assert
            parametersOfsetupdispcolns.ShouldNotBeNull();
            parametersOfsetupdispcolns.Length.ShouldBe(1);
            methodsetupdispcolnsPrametersTypes.Length.ShouldBe(1);
            methodsetupdispcolnsPrametersTypes.Length.ShouldBe(parametersOfsetupdispcolns.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setupdispcolns) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_setupdispcolns_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(Methodsetupdispcolns, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setupdispcolns) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_setupdispcolns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsetupdispcolnsPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, Methodsetupdispcolns, Fixture, methodsetupdispcolnsPrametersTypes);

            // Assert
            methodsetupdispcolnsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setupdispcolns) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_setupdispcolns_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodsetupdispcolns, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReDrawGrid) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_ReDrawGrid_Method_Call_Internally(Type[] types)
        {
            var methodReDrawGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodReDrawGrid, Fixture, methodReDrawGridPrametersTypes);
        }

        #endregion

        #region Method Call : (ReDrawGrid) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ReDrawGrid_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodReDrawGridPrametersTypes = null;
            object[] parametersOfReDrawGrid = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReDrawGrid, methodReDrawGridPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfReDrawGrid);

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
        public void AUT_RPAData_ReDrawGrid_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodReDrawGridPrametersTypes = null;
            object[] parametersOfReDrawGrid = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rPADataInstance, MethodReDrawGrid, parametersOfReDrawGrid, methodReDrawGridPrametersTypes);

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
        public void AUT_RPAData_ReDrawGrid_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodReDrawGridPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodReDrawGrid, Fixture, methodReDrawGridPrametersTypes);

            // Assert
            methodReDrawGridPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReDrawGrid) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ReDrawGrid_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReDrawGrid, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoIShowReqType) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_DoIShowReqType_Method_Call_Internally(Type[] types)
        {
            var methodDoIShowReqTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodDoIShowReqType, Fixture, methodDoIShowReqTypePrametersTypes);
        }

        #endregion

        #region Method Call : (DoIShowReqType) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_DoIShowReqType_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var stat = CreateType<int>();
            var methodDoIShowReqTypePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDoIShowReqType = { stat };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDoIShowReqType, methodDoIShowReqTypePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RPAData, bool>(_rPADataInstanceFixture, out exception1, parametersOfDoIShowReqType);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RPAData, bool>(_rPADataInstance, MethodDoIShowReqType, parametersOfDoIShowReqType, methodDoIShowReqTypePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDoIShowReqType.ShouldNotBeNull();
            parametersOfDoIShowReqType.Length.ShouldBe(1);
            methodDoIShowReqTypePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DoIShowReqType) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_DoIShowReqType_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var stat = CreateType<int>();
            var methodDoIShowReqTypePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDoIShowReqType = { stat };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDoIShowReqType, methodDoIShowReqTypePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RPAData, bool>(_rPADataInstanceFixture, out exception1, parametersOfDoIShowReqType);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RPAData, bool>(_rPADataInstance, MethodDoIShowReqType, parametersOfDoIShowReqType, methodDoIShowReqTypePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDoIShowReqType.ShouldNotBeNull();
            parametersOfDoIShowReqType.Length.ShouldBe(1);
            methodDoIShowReqTypePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DoIShowReqType) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_DoIShowReqType_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var stat = CreateType<int>();
            var methodDoIShowReqTypePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDoIShowReqType = { stat };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDoIShowReqType, methodDoIShowReqTypePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfDoIShowReqType);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDoIShowReqType.ShouldNotBeNull();
            parametersOfDoIShowReqType.Length.ShouldBe(1);
            methodDoIShowReqTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoIShowReqType) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_DoIShowReqType_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var stat = CreateType<int>();
            var methodDoIShowReqTypePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDoIShowReqType = { stat };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, bool>(_rPADataInstance, MethodDoIShowReqType, parametersOfDoIShowReqType, methodDoIShowReqTypePrametersTypes);

            // Assert
            parametersOfDoIShowReqType.ShouldNotBeNull();
            parametersOfDoIShowReqType.Length.ShouldBe(1);
            methodDoIShowReqTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoIShowReqType) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_DoIShowReqType_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDoIShowReqTypePrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodDoIShowReqType, Fixture, methodDoIShowReqTypePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDoIShowReqTypePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoIShowReqType) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_DoIShowReqType_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDoIShowReqType, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (DoIShowReqType) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_DoIShowReqType_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDoIShowReqType, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMajorCatStrings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetMajorCatStrings_Method_Call_Internally(Type[] types)
        {
            var methodGetMajorCatStringsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetMajorCatStrings, Fixture, methodGetMajorCatStringsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMajorCatStrings) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetMajorCatStrings_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var lUID = CreateType<int>();
            var sShort = CreateType<string>();
            var sFull = CreateType<string>();
            var methodGetMajorCatStringsPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(string) };
            object[] parametersOfGetMajorCatStrings = { lUID, sShort, sFull };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetMajorCatStrings, methodGetMajorCatStringsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfGetMajorCatStrings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetMajorCatStrings.ShouldNotBeNull();
            parametersOfGetMajorCatStrings.Length.ShouldBe(3);
            methodGetMajorCatStringsPrametersTypes.Length.ShouldBe(3);
            methodGetMajorCatStringsPrametersTypes.Length.ShouldBe(parametersOfGetMajorCatStrings.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMajorCatStrings) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetMajorCatStrings_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var lUID = CreateType<int>();
            var sShort = CreateType<string>();
            var sFull = CreateType<string>();
            var methodGetMajorCatStringsPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(string) };
            object[] parametersOfGetMajorCatStrings = { lUID, sShort, sFull };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rPADataInstance, MethodGetMajorCatStrings, parametersOfGetMajorCatStrings, methodGetMajorCatStringsPrametersTypes);

            // Assert
            parametersOfGetMajorCatStrings.ShouldNotBeNull();
            parametersOfGetMajorCatStrings.Length.ShouldBe(3);
            methodGetMajorCatStringsPrametersTypes.Length.ShouldBe(3);
            methodGetMajorCatStringsPrametersTypes.Length.ShouldBe(parametersOfGetMajorCatStrings.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMajorCatStrings) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetMajorCatStrings_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetMajorCatStrings, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMajorCatStrings) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetMajorCatStrings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetMajorCatStringsPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetMajorCatStrings, Fixture, methodGetMajorCatStringsPrametersTypes);

            // Assert
            methodGetMajorCatStringsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMajorCatStrings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetMajorCatStrings_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMajorCatStrings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMajorCat) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetMajorCat_Method_Call_Internally(Type[] types)
        {
            var methodGetMajorCatPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetMajorCat, Fixture, methodGetMajorCatPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMajorCat) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetMajorCat_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var mcat = CreateType<int>();
            var methodGetMajorCatPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetMajorCat = { mcat };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMajorCat, methodGetMajorCatPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RPAData, string>(_rPADataInstanceFixture, out exception1, parametersOfGetMajorCat);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetMajorCat, parametersOfGetMajorCat, methodGetMajorCatPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetMajorCat.ShouldNotBeNull();
            parametersOfGetMajorCat.Length.ShouldBe(1);
            methodGetMajorCatPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetMajorCat) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetMajorCat_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var mcat = CreateType<int>();
            var methodGetMajorCatPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetMajorCat = { mcat };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetMajorCat, parametersOfGetMajorCat, methodGetMajorCatPrametersTypes);

            // Assert
            parametersOfGetMajorCat.ShouldNotBeNull();
            parametersOfGetMajorCat.Length.ShouldBe(1);
            methodGetMajorCatPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMajorCat) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetMajorCat_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetMajorCatPrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetMajorCat, Fixture, methodGetMajorCatPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMajorCatPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetMajorCat) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetMajorCat_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetMajorCatPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetMajorCat, Fixture, methodGetMajorCatPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMajorCatPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMajorCat) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetMajorCat_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMajorCat, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMajorCat) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetMajorCat_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetMajorCat, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (NewRedrawTotals) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_NewRedrawTotals_Method_Call_Internally(Type[] types)
        {
            var methodNewRedrawTotalsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodNewRedrawTotals, Fixture, methodNewRedrawTotalsPrametersTypes);
        }

        #endregion

        #region Method Call : (NewRedrawTotals) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_NewRedrawTotals_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodNewRedrawTotalsPrametersTypes = null;
            object[] parametersOfNewRedrawTotals = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodNewRedrawTotals, methodNewRedrawTotalsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfNewRedrawTotals);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfNewRedrawTotals.ShouldBeNull();
            methodNewRedrawTotalsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (NewRedrawTotals) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_NewRedrawTotals_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodNewRedrawTotalsPrametersTypes = null;
            object[] parametersOfNewRedrawTotals = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rPADataInstance, MethodNewRedrawTotals, parametersOfNewRedrawTotals, methodNewRedrawTotalsPrametersTypes);

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
        public void AUT_RPAData_NewRedrawTotals_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodNewRedrawTotalsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodNewRedrawTotals, Fixture, methodNewRedrawTotalsPrametersTypes);

            // Assert
            methodNewRedrawTotalsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (NewRedrawTotals) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_NewRedrawTotals_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodNewRedrawTotals, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPeriodName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetPeriodName_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetPeriodNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_rPADataInstanceFixture, _rPADataInstanceType, MethodGetPeriodName, Fixture, methodGetPeriodNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetPeriodName) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetPeriodName_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var periodName = CreateType<string>();
            var disp_mode = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => RPAData.GetPeriodName(periodName, disp_mode);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetPeriodName) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetPeriodName_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var periodName = CreateType<string>();
            var disp_mode = CreateType<int>();
            var methodGetPeriodNamePrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfGetPeriodName = { periodName, disp_mode };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetPeriodName, methodGetPeriodNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfGetPeriodName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetPeriodName.ShouldNotBeNull();
            parametersOfGetPeriodName.Length.ShouldBe(2);
            methodGetPeriodNamePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPeriodName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetPeriodName_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var periodName = CreateType<string>();
            var disp_mode = CreateType<int>();
            var methodGetPeriodNamePrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfGetPeriodName = { periodName, disp_mode };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_rPADataInstanceFixture, _rPADataInstanceType, MethodGetPeriodName, parametersOfGetPeriodName, methodGetPeriodNamePrametersTypes);

            // Assert
            parametersOfGetPeriodName.ShouldNotBeNull();
            parametersOfGetPeriodName.Length.ShouldBe(2);
            methodGetPeriodNamePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPeriodName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetPeriodName_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetPeriodNamePrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_rPADataInstanceFixture, _rPADataInstanceType, MethodGetPeriodName, Fixture, methodGetPeriodNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPeriodNamePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetPeriodName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetPeriodName_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPeriodNamePrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_rPADataInstanceFixture, _rPADataInstanceType, MethodGetPeriodName, Fixture, methodGetPeriodNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPeriodNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPeriodName) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetPeriodName_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPeriodName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetPeriodName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetPeriodName_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetPeriodName, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTopGrid) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetTopGrid_Method_Call_Internally(Type[] types)
        {
            var methodGetTopGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetTopGrid, Fixture, methodGetTopGridPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTopGrid) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetTopGrid_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.GetTopGrid(sXML);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTopGrid) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetTopGrid_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var methodGetTopGridPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTopGrid = { sXML };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTopGrid, methodGetTopGridPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RPAData, string>(_rPADataInstanceFixture, out exception1, parametersOfGetTopGrid);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetTopGrid, parametersOfGetTopGrid, methodGetTopGridPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTopGrid.ShouldNotBeNull();
            parametersOfGetTopGrid.Length.ShouldBe(1);
            methodGetTopGridPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTopGrid) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetTopGrid_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var methodGetTopGridPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTopGrid = { sXML };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetTopGrid, parametersOfGetTopGrid, methodGetTopGridPrametersTypes);

            // Assert
            parametersOfGetTopGrid.ShouldNotBeNull();
            parametersOfGetTopGrid.Length.ShouldBe(1);
            methodGetTopGridPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTopGrid) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetTopGrid_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTopGridPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetTopGrid, Fixture, methodGetTopGridPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTopGridPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTopGrid) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetTopGrid_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTopGridPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetTopGrid, Fixture, methodGetTopGridPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTopGridPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTopGrid) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetTopGrid_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTopGrid, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTopGrid) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetTopGrid_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTopGrid, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRawDataCount) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetRawDataCount_Method_Call_Internally(Type[] types)
        {
            var methodGetRawDataCountPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetRawDataCount, Fixture, methodGetRawDataCountPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRawDataCount) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetRawDataCount_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.GetRawDataCount();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetRawDataCount) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetRawDataCount_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetRawDataCountPrametersTypes = null;
            object[] parametersOfGetRawDataCount = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetRawDataCount, methodGetRawDataCountPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RPAData, int>(_rPADataInstanceFixture, out exception1, parametersOfGetRawDataCount);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RPAData, int>(_rPADataInstance, MethodGetRawDataCount, parametersOfGetRawDataCount, methodGetRawDataCountPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetRawDataCount.ShouldBeNull();
            methodGetRawDataCountPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRawDataCount) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetRawDataCount_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetRawDataCountPrametersTypes = null;
            object[] parametersOfGetRawDataCount = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetRawDataCount, methodGetRawDataCountPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RPAData, int>(_rPADataInstanceFixture, out exception1, parametersOfGetRawDataCount);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RPAData, int>(_rPADataInstance, MethodGetRawDataCount, parametersOfGetRawDataCount, methodGetRawDataCountPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetRawDataCount.ShouldBeNull();
            methodGetRawDataCountPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRawDataCount) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetRawDataCount_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetRawDataCountPrametersTypes = null;
            object[] parametersOfGetRawDataCount = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetRawDataCount, methodGetRawDataCountPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfGetRawDataCount);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetRawDataCount.ShouldBeNull();
            methodGetRawDataCountPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRawDataCount) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetRawDataCount_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetRawDataCountPrametersTypes = null;
            object[] parametersOfGetRawDataCount = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, int>(_rPADataInstance, MethodGetRawDataCount, parametersOfGetRawDataCount, methodGetRawDataCountPrametersTypes);

            // Assert
            parametersOfGetRawDataCount.ShouldBeNull();
            methodGetRawDataCountPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRawDataCount) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetRawDataCount_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetRawDataCountPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetRawDataCount, Fixture, methodGetRawDataCountPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRawDataCountPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRawDataCount) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetRawDataCount_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRawDataCount, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetFilteredDataCount) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetFilteredDataCount_Method_Call_Internally(Type[] types)
        {
            var methodGetFilteredDataCountPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetFilteredDataCount, Fixture, methodGetFilteredDataCountPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFilteredDataCount) (Return Type : int) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetFilteredDataCount_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.GetFilteredDataCount();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetFilteredDataCount) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetFilteredDataCount_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetFilteredDataCountPrametersTypes = null;
            object[] parametersOfGetFilteredDataCount = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFilteredDataCount, methodGetFilteredDataCountPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RPAData, int>(_rPADataInstanceFixture, out exception1, parametersOfGetFilteredDataCount);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RPAData, int>(_rPADataInstance, MethodGetFilteredDataCount, parametersOfGetFilteredDataCount, methodGetFilteredDataCountPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetFilteredDataCount.ShouldBeNull();
            methodGetFilteredDataCountPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFilteredDataCount) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetFilteredDataCount_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetFilteredDataCountPrametersTypes = null;
            object[] parametersOfGetFilteredDataCount = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFilteredDataCount, methodGetFilteredDataCountPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RPAData, int>(_rPADataInstanceFixture, out exception1, parametersOfGetFilteredDataCount);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RPAData, int>(_rPADataInstance, MethodGetFilteredDataCount, parametersOfGetFilteredDataCount, methodGetFilteredDataCountPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetFilteredDataCount.ShouldBeNull();
            methodGetFilteredDataCountPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFilteredDataCount) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetFilteredDataCount_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetFilteredDataCountPrametersTypes = null;
            object[] parametersOfGetFilteredDataCount = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetFilteredDataCount, methodGetFilteredDataCountPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfGetFilteredDataCount);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetFilteredDataCount.ShouldBeNull();
            methodGetFilteredDataCountPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFilteredDataCount) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetFilteredDataCount_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetFilteredDataCountPrametersTypes = null;
            object[] parametersOfGetFilteredDataCount = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, int>(_rPADataInstance, MethodGetFilteredDataCount, parametersOfGetFilteredDataCount, methodGetFilteredDataCountPrametersTypes);

            // Assert
            parametersOfGetFilteredDataCount.ShouldBeNull();
            methodGetFilteredDataCountPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFilteredDataCount) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetFilteredDataCount_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetFilteredDataCountPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetFilteredDataCount, Fixture, methodGetFilteredDataCountPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetFilteredDataCountPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFilteredDataCount) (Return Type : int) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetFilteredDataCount_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetFilteredDataCountPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetFilteredDataCount, Fixture, methodGetFilteredDataCountPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetFilteredDataCountPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFilteredDataCount) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetFilteredDataCount_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetFilteredDataCountPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetFilteredDataCount, Fixture, methodGetFilteredDataCountPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFilteredDataCountPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFilteredDataCount) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetFilteredDataCount_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFilteredDataCount, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetBottomGrid) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetBottomGrid_Method_Call_Internally(Type[] types)
        {
            var methodGetBottomGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetBottomGrid, Fixture, methodGetBottomGridPrametersTypes);
        }

        #endregion

        #region Method Call : (GetBottomGrid) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetBottomGrid_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.GetBottomGrid();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetBottomGrid) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetBottomGrid_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetBottomGridPrametersTypes = null;
            object[] parametersOfGetBottomGrid = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetBottomGrid, methodGetBottomGridPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfGetBottomGrid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetBottomGrid.ShouldBeNull();
            methodGetBottomGridPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetBottomGrid) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetBottomGrid_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetBottomGridPrametersTypes = null;
            object[] parametersOfGetBottomGrid = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetBottomGrid, parametersOfGetBottomGrid, methodGetBottomGridPrametersTypes);

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
        public void AUT_RPAData_GetBottomGrid_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetBottomGridPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetBottomGrid, Fixture, methodGetBottomGridPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetBottomGridPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetBottomGrid) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetBottomGrid_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetBottomGridPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetBottomGrid, Fixture, methodGetBottomGridPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetBottomGridPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetBottomGrid) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetBottomGrid_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetBottomGrid, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetBottomTotalChartDataGrid) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetBottomTotalChartDataGrid_Method_Call_Internally(Type[] types)
        {
            var methodGetBottomTotalChartDataGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetBottomTotalChartDataGrid, Fixture, methodGetBottomTotalChartDataGridPrametersTypes);
        }

        #endregion

        #region Method Call : (BottomDetailsDisplay) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_BottomDetailsDisplay_Method_Call_Internally(Type[] types)
        {
            var methodBottomDetailsDisplayPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodBottomDetailsDisplay, Fixture, methodBottomDetailsDisplayPrametersTypes);
        }

        #endregion

        #region Method Call : (BottomDetailsDisplay) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_BottomDetailsDisplay_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sIn = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.BottomDetailsDisplay(sIn);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (BottomDetailsDisplay) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_BottomDetailsDisplay_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sIn = CreateType<string>();
            var methodBottomDetailsDisplayPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfBottomDetailsDisplay = { sIn };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBottomDetailsDisplay, methodBottomDetailsDisplayPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfBottomDetailsDisplay);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBottomDetailsDisplay.ShouldNotBeNull();
            parametersOfBottomDetailsDisplay.Length.ShouldBe(1);
            methodBottomDetailsDisplayPrametersTypes.Length.ShouldBe(1);
            methodBottomDetailsDisplayPrametersTypes.Length.ShouldBe(parametersOfBottomDetailsDisplay.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BottomDetailsDisplay) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_BottomDetailsDisplay_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sIn = CreateType<string>();
            var methodBottomDetailsDisplayPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfBottomDetailsDisplay = { sIn };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rPADataInstance, MethodBottomDetailsDisplay, parametersOfBottomDetailsDisplay, methodBottomDetailsDisplayPrametersTypes);

            // Assert
            parametersOfBottomDetailsDisplay.ShouldNotBeNull();
            parametersOfBottomDetailsDisplay.Length.ShouldBe(1);
            methodBottomDetailsDisplayPrametersTypes.Length.ShouldBe(1);
            methodBottomDetailsDisplayPrametersTypes.Length.ShouldBe(parametersOfBottomDetailsDisplay.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BottomDetailsDisplay) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_BottomDetailsDisplay_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBottomDetailsDisplay, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BottomDetailsDisplay) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_BottomDetailsDisplay_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBottomDetailsDisplayPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodBottomDetailsDisplay, Fixture, methodBottomDetailsDisplayPrametersTypes);

            // Assert
            methodBottomDetailsDisplayPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BottomDetailsDisplay) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_BottomDetailsDisplay_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBottomDetailsDisplay, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTotalsData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetTotalsData_Method_Call_Internally(Type[] types)
        {
            var methodGetTotalsDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetTotalsData, Fixture, methodGetTotalsDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTotalsData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetTotalsData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var bRetColumnData = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.GetTotalsData(bRetColumnData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTotalsData) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetTotalsData_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var bRetColumnData = CreateType<bool>();
            var methodGetTotalsDataPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfGetTotalsData = { bRetColumnData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTotalsData, methodGetTotalsDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfGetTotalsData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTotalsData.ShouldNotBeNull();
            parametersOfGetTotalsData.Length.ShouldBe(1);
            methodGetTotalsDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTotalsData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetTotalsData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var bRetColumnData = CreateType<bool>();
            var methodGetTotalsDataPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfGetTotalsData = { bRetColumnData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetTotalsData, parametersOfGetTotalsData, methodGetTotalsDataPrametersTypes);

            // Assert
            parametersOfGetTotalsData.ShouldNotBeNull();
            parametersOfGetTotalsData.Length.ShouldBe(1);
            methodGetTotalsDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTotalsData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetTotalsData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTotalsDataPrametersTypes = new Type[] { typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetTotalsData, Fixture, methodGetTotalsDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTotalsDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTotalsData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetTotalsData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTotalsDataPrametersTypes = new Type[] { typeof(bool) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetTotalsData, Fixture, methodGetTotalsDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTotalsDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTotalsData) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetTotalsData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTotalsData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetTotalsData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetTotalsData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTotalsData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetTotalsData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_SetTotalsData_Method_Call_Internally(Type[] types)
        {
            var methodSetTotalsDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodSetTotalsData, Fixture, methodSetTotalsDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SetTotalsData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetTotalsData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.SetTotalsData(xData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetTotalsData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetTotalsData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            var methodSetTotalsDataPrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfSetTotalsData = { xData };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSetTotalsData, methodSetTotalsDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RPAData, string>(_rPADataInstanceFixture, out exception1, parametersOfSetTotalsData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodSetTotalsData, parametersOfSetTotalsData, methodSetTotalsDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSetTotalsData.ShouldNotBeNull();
            parametersOfSetTotalsData.Length.ShouldBe(1);
            methodSetTotalsDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SetTotalsData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetTotalsData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            var methodSetTotalsDataPrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfSetTotalsData = { xData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodSetTotalsData, parametersOfSetTotalsData, methodSetTotalsDataPrametersTypes);

            // Assert
            parametersOfSetTotalsData.ShouldNotBeNull();
            parametersOfSetTotalsData.Length.ShouldBe(1);
            methodSetTotalsDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTotalsData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetTotalsData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSetTotalsDataPrametersTypes = new Type[] { typeof(CStruct) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodSetTotalsData, Fixture, methodSetTotalsDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSetTotalsDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SetTotalsData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetTotalsData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetTotalsDataPrametersTypes = new Type[] { typeof(CStruct) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodSetTotalsData, Fixture, methodSetTotalsDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetTotalsDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetTotalsData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetTotalsData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetTotalsData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetTotalsData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetTotalsData_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (GetDetailsData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetDetailsData_Method_Call_Internally(Type[] types)
        {
            var methodGetDetailsDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetDetailsData, Fixture, methodGetDetailsDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDetailsData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetDetailsData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.GetDetailsData();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetDetailsData) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetDetailsData_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetDetailsDataPrametersTypes = null;
            object[] parametersOfGetDetailsData = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetDetailsData, methodGetDetailsDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfGetDetailsData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetDetailsData.ShouldBeNull();
            methodGetDetailsDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDetailsData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetDetailsData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetDetailsDataPrametersTypes = null;
            object[] parametersOfGetDetailsData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetDetailsData, parametersOfGetDetailsData, methodGetDetailsDataPrametersTypes);

            // Assert
            parametersOfGetDetailsData.ShouldBeNull();
            methodGetDetailsDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDetailsData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetDetailsData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetDetailsDataPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetDetailsData, Fixture, methodGetDetailsDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDetailsDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDetailsData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetDetailsData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetDetailsDataPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetDetailsData, Fixture, methodGetDetailsDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDetailsDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDetailsData) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetDetailsData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDetailsData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SetDetailsData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_SetDetailsData_Method_Call_Internally(Type[] types)
        {
            var methodSetDetailsDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodSetDetailsData, Fixture, methodSetDetailsDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SetDetailsData) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetDetailsData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.SetDetailsData(xData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetDetailsData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetDetailsData_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            var methodSetDetailsDataPrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfSetDetailsData = { xData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetDetailsData, methodSetDetailsDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfSetDetailsData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetDetailsData.ShouldNotBeNull();
            parametersOfSetDetailsData.Length.ShouldBe(1);
            methodSetDetailsDataPrametersTypes.Length.ShouldBe(1);
            methodSetDetailsDataPrametersTypes.Length.ShouldBe(parametersOfSetDetailsData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetDetailsData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetDetailsData_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            var methodSetDetailsDataPrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfSetDetailsData = { xData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rPADataInstance, MethodSetDetailsData, parametersOfSetDetailsData, methodSetDetailsDataPrametersTypes);

            // Assert
            parametersOfSetDetailsData.ShouldNotBeNull();
            parametersOfSetDetailsData.Length.ShouldBe(1);
            methodSetDetailsDataPrametersTypes.Length.ShouldBe(1);
            methodSetDetailsDataPrametersTypes.Length.ShouldBe(parametersOfSetDetailsData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetDetailsData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetDetailsData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetDetailsData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetDetailsData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetDetailsData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetDetailsDataPrametersTypes = new Type[] { typeof(CStruct) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodSetDetailsData, Fixture, methodSetDetailsDataPrametersTypes);

            // Assert
            methodSetDetailsDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetDetailsData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetDetailsData_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetDetailsData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetDisplayMode) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_SetDisplayMode_Method_Call_Internally(Type[] types)
        {
            var methodSetDisplayModePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodSetDisplayMode, Fixture, methodSetDisplayModePrametersTypes);
        }

        #endregion

        #region Method Call : (SetDisplayMode) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetDisplayMode_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.SetDisplayMode(xData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetDisplayMode) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetDisplayMode_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            var methodSetDisplayModePrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfSetDisplayMode = { xData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetDisplayMode, methodSetDisplayModePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfSetDisplayMode);

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
        public void AUT_RPAData_SetDisplayMode_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            var methodSetDisplayModePrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfSetDisplayMode = { xData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rPADataInstance, MethodSetDisplayMode, parametersOfSetDisplayMode, methodSetDisplayModePrametersTypes);

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
        public void AUT_RPAData_SetDisplayMode_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_RPAData_SetDisplayMode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetDisplayModePrametersTypes = new Type[] { typeof(CStruct) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodSetDisplayMode, Fixture, methodSetDisplayModePrametersTypes);

            // Assert
            methodSetDisplayModePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetDisplayMode) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetDisplayMode_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetDisplayMode, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDisplayMode) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetDisplayMode_Method_Call_Internally(Type[] types)
        {
            var methodGetDisplayModePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetDisplayMode, Fixture, methodGetDisplayModePrametersTypes);
        }

        #endregion

        #region Method Call : (GetDisplayMode) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetDisplayMode_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.GetDisplayMode();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetDisplayMode) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetDisplayMode_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetDisplayModePrametersTypes = null;
            object[] parametersOfGetDisplayMode = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetDisplayMode, methodGetDisplayModePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfGetDisplayMode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetDisplayMode.ShouldBeNull();
            methodGetDisplayModePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDisplayMode) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetDisplayMode_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetDisplayModePrametersTypes = null;
            object[] parametersOfGetDisplayMode = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetDisplayMode, parametersOfGetDisplayMode, methodGetDisplayModePrametersTypes);

            // Assert
            parametersOfGetDisplayMode.ShouldBeNull();
            methodGetDisplayModePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDisplayMode) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetDisplayMode_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetDisplayModePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetDisplayMode, Fixture, methodGetDisplayModePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetDisplayModePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDisplayMode) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetDisplayMode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetDisplayModePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetDisplayMode, Fixture, methodGetDisplayModePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDisplayModePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDisplayMode) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetDisplayMode_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDisplayMode, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SetSelectedForRows) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_SetSelectedForRows_Method_Call_Internally(Type[] types)
        {
            var methodSetSelectedForRowsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodSetSelectedForRows, Fixture, methodSetSelectedForRowsPrametersTypes);
        }

        #endregion

        #region Method Call : (SetSelectedForRows) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetSelectedForRows_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.SetSelectedForRows(xData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetSelectedForRows) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetSelectedForRows_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            var methodSetSelectedForRowsPrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfSetSelectedForRows = { xData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetSelectedForRows, methodSetSelectedForRowsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfSetSelectedForRows);

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
        public void AUT_RPAData_SetSelectedForRows_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            var methodSetSelectedForRowsPrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfSetSelectedForRows = { xData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rPADataInstance, MethodSetSelectedForRows, parametersOfSetSelectedForRows, methodSetSelectedForRowsPrametersTypes);

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
        public void AUT_RPAData_SetSelectedForRows_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_RPAData_SetSelectedForRows_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetSelectedForRowsPrametersTypes = new Type[] { typeof(CStruct) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodSetSelectedForRows, Fixture, methodSetSelectedForRowsPrametersTypes);

            // Assert
            methodSetSelectedForRowsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedForRows) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetSelectedForRows_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetSelectedForRows, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedForTotals) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_SetSelectedForTotals_Method_Call_Internally(Type[] types)
        {
            var methodSetSelectedForTotalsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodSetSelectedForTotals, Fixture, methodSetSelectedForTotalsPrametersTypes);
        }

        #endregion

        #region Method Call : (SetSelectedForTotals) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetSelectedForTotals_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.SetSelectedForTotals(xData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetSelectedForTotals) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetSelectedForTotals_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            var methodSetSelectedForTotalsPrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfSetSelectedForTotals = { xData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetSelectedForTotals, methodSetSelectedForTotalsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfSetSelectedForTotals);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetSelectedForTotals.ShouldNotBeNull();
            parametersOfSetSelectedForTotals.Length.ShouldBe(1);
            methodSetSelectedForTotalsPrametersTypes.Length.ShouldBe(1);
            methodSetSelectedForTotalsPrametersTypes.Length.ShouldBe(parametersOfSetSelectedForTotals.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedForTotals) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetSelectedForTotals_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            var methodSetSelectedForTotalsPrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfSetSelectedForTotals = { xData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rPADataInstance, MethodSetSelectedForTotals, parametersOfSetSelectedForTotals, methodSetSelectedForTotalsPrametersTypes);

            // Assert
            parametersOfSetSelectedForTotals.ShouldNotBeNull();
            parametersOfSetSelectedForTotals.Length.ShouldBe(1);
            methodSetSelectedForTotalsPrametersTypes.Length.ShouldBe(1);
            methodSetSelectedForTotalsPrametersTypes.Length.ShouldBe(parametersOfSetSelectedForTotals.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedForTotals) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetSelectedForTotals_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetSelectedForTotals, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetSelectedForTotals) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetSelectedForTotals_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetSelectedForTotalsPrametersTypes = new Type[] { typeof(CStruct) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodSetSelectedForTotals, Fixture, methodSetSelectedForTotalsPrametersTypes);

            // Assert
            methodSetSelectedForTotalsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedForTotals) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetSelectedForTotals_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetSelectedForTotals, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetRADragRows) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_SetRADragRows_Method_Call_Internally(Type[] types)
        {
            var methodSetRADragRowsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodSetRADragRows, Fixture, methodSetRADragRowsPrametersTypes);
        }

        #endregion

        #region Method Call : (SetRADragRows) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetRADragRows_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.SetRADragRows(xData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetRADragRows) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetRADragRows_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            var methodSetRADragRowsPrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfSetRADragRows = { xData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetRADragRows, methodSetRADragRowsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfSetRADragRows);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetRADragRows.ShouldNotBeNull();
            parametersOfSetRADragRows.Length.ShouldBe(1);
            methodSetRADragRowsPrametersTypes.Length.ShouldBe(1);
            methodSetRADragRowsPrametersTypes.Length.ShouldBe(parametersOfSetRADragRows.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetRADragRows) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetRADragRows_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            var methodSetRADragRowsPrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfSetRADragRows = { xData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rPADataInstance, MethodSetRADragRows, parametersOfSetRADragRows, methodSetRADragRowsPrametersTypes);

            // Assert
            parametersOfSetRADragRows.ShouldNotBeNull();
            parametersOfSetRADragRows.Length.ShouldBe(1);
            methodSetRADragRowsPrametersTypes.Length.ShouldBe(1);
            methodSetRADragRowsPrametersTypes.Length.ShouldBe(parametersOfSetRADragRows.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetRADragRows) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetRADragRows_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetRADragRows, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetRADragRows) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetRADragRows_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetRADragRowsPrametersTypes = new Type[] { typeof(CStruct) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodSetRADragRows, Fixture, methodSetRADragRowsPrametersTypes);

            // Assert
            methodSetRADragRowsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetRADragRows) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetRADragRows_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetRADragRows, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UndoRADragRows) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_UndoRADragRows_Method_Call_Internally(Type[] types)
        {
            var methodUndoRADragRowsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodUndoRADragRows, Fixture, methodUndoRADragRowsPrametersTypes);
        }

        #endregion

        #region Method Call : (UndoRADragRows) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_UndoRADragRows_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.UndoRADragRows();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (UndoRADragRows) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_UndoRADragRows_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodUndoRADragRowsPrametersTypes = null;
            object[] parametersOfUndoRADragRows = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUndoRADragRows, methodUndoRADragRowsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfUndoRADragRows);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUndoRADragRows.ShouldBeNull();
            methodUndoRADragRowsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UndoRADragRows) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_UndoRADragRows_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodUndoRADragRowsPrametersTypes = null;
            object[] parametersOfUndoRADragRows = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rPADataInstance, MethodUndoRADragRows, parametersOfUndoRADragRows, methodUndoRADragRowsPrametersTypes);

            // Assert
            parametersOfUndoRADragRows.ShouldBeNull();
            methodUndoRADragRowsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UndoRADragRows) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_UndoRADragRows_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodUndoRADragRowsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodUndoRADragRows, Fixture, methodUndoRADragRowsPrametersTypes);

            // Assert
            methodUndoRADragRowsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UndoRADragRows) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_UndoRADragRows_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUndoRADragRows, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetFilteredForRows) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_SetFilteredForRows_Method_Call_Internally(Type[] types)
        {
            var methodSetFilteredForRowsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodSetFilteredForRows, Fixture, methodSetFilteredForRowsPrametersTypes);
        }

        #endregion

        #region Method Call : (SetFilteredForRows) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetFilteredForRows_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.SetFilteredForRows(xData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetFilteredForRows) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetFilteredForRows_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            var methodSetFilteredForRowsPrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfSetFilteredForRows = { xData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetFilteredForRows, methodSetFilteredForRowsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfSetFilteredForRows);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetFilteredForRows.ShouldNotBeNull();
            parametersOfSetFilteredForRows.Length.ShouldBe(1);
            methodSetFilteredForRowsPrametersTypes.Length.ShouldBe(1);
            methodSetFilteredForRowsPrametersTypes.Length.ShouldBe(parametersOfSetFilteredForRows.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetFilteredForRows) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetFilteredForRows_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xData = CreateType<CStruct>();
            var methodSetFilteredForRowsPrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfSetFilteredForRows = { xData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rPADataInstance, MethodSetFilteredForRows, parametersOfSetFilteredForRows, methodSetFilteredForRowsPrametersTypes);

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
        public void AUT_RPAData_SetFilteredForRows_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_RPAData_SetFilteredForRows_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetFilteredForRowsPrametersTypes = new Type[] { typeof(CStruct) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodSetFilteredForRows, Fixture, methodSetFilteredForRowsPrametersTypes);

            // Assert
            methodSetFilteredForRowsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetFilteredForRows) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetFilteredForRows_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetFilteredForRows, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PrepareText) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_PrepareText_Method_Call_Internally(Type[] types)
        {
            var methodPrepareTextPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodPrepareText, Fixture, methodPrepareTextPrametersTypes);
        }

        #endregion

        #region Method Call : (PrepareText) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_PrepareText_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sText = CreateType<string>();
            var methodPrepareTextPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPrepareText = { sText };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPrepareText, methodPrepareTextPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfPrepareText);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPrepareText.ShouldNotBeNull();
            parametersOfPrepareText.Length.ShouldBe(1);
            methodPrepareTextPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PrepareText) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_PrepareText_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sText = CreateType<string>();
            var methodPrepareTextPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPrepareText = { sText };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodPrepareText, parametersOfPrepareText, methodPrepareTextPrametersTypes);

            // Assert
            parametersOfPrepareText.ShouldNotBeNull();
            parametersOfPrepareText.Length.ShouldBe(1);
            methodPrepareTextPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PrepareText) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_PrepareText_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodPrepareTextPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodPrepareText, Fixture, methodPrepareTextPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodPrepareTextPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (PrepareText) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_PrepareText_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPrepareTextPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodPrepareText, Fixture, methodPrepareTextPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPrepareTextPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PrepareText) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_PrepareText_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPrepareText, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (PrepareText) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_PrepareText_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPrepareText, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddElement) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_AddElement_Method_Call_Internally(Type[] types)
        {
            var methodAddElementPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodAddElement, Fixture, methodAddElementPrametersTypes);
        }

        #endregion

        #region Method Call : (AddElement) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_AddElement_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oXMLDocument = CreateType<XmlDocument>();
            var oParent = CreateType<XmlNode>();
            var sName = CreateType<string>();
            var sValue = CreateType<string>();
            var methodAddElementPrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlNode), typeof(string), typeof(string) };
            object[] parametersOfAddElement = { oXMLDocument, oParent, sName, sValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddElement, methodAddElementPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfAddElement);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddElement.ShouldNotBeNull();
            parametersOfAddElement.Length.ShouldBe(4);
            methodAddElementPrametersTypes.Length.ShouldBe(4);
            methodAddElementPrametersTypes.Length.ShouldBe(parametersOfAddElement.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddElement) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_AddElement_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oXMLDocument = CreateType<XmlDocument>();
            var oParent = CreateType<XmlNode>();
            var sName = CreateType<string>();
            var sValue = CreateType<string>();
            var methodAddElementPrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlNode), typeof(string), typeof(string) };
            object[] parametersOfAddElement = { oXMLDocument, oParent, sName, sValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rPADataInstance, MethodAddElement, parametersOfAddElement, methodAddElementPrametersTypes);

            // Assert
            parametersOfAddElement.ShouldNotBeNull();
            parametersOfAddElement.Length.ShouldBe(4);
            methodAddElementPrametersTypes.Length.ShouldBe(4);
            methodAddElementPrametersTypes.Length.ShouldBe(parametersOfAddElement.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddElement) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_AddElement_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddElement, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddElement) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_AddElement_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddElementPrametersTypes = new Type[] { typeof(XmlDocument), typeof(XmlNode), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodAddElement, Fixture, methodAddElementPrametersTypes);

            // Assert
            methodAddElementPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddElement) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_AddElement_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddElement, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreatetgLayout) (Return Type : RPATGRow) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_CreatetgLayout_Method_Call_Internally(Type[] types)
        {
            var methodCreatetgLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodCreatetgLayout, Fixture, methodCreatetgLayoutPrametersTypes);
        }

        #endregion
        
        #region Method Call : (CreatetgLayout) (Return Type : RPATGRow) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_CreatetgLayout_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var bUse = CreateType<bool>();
            var fid = CreateType<int>();
            var name = CreateType<string>();
            var displayname = CreateType<string>();
            var methodCreatetgLayoutPrametersTypes = new Type[] { typeof(bool), typeof(int), typeof(string), typeof(string) };
            object[] parametersOfCreatetgLayout = { bUse, fid, name, displayname };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreatetgLayout, methodCreatetgLayoutPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfCreatetgLayout);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreatetgLayout.ShouldNotBeNull();
            parametersOfCreatetgLayout.Length.ShouldBe(4);
            methodCreatetgLayoutPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion
        
        #region Method Call : (CreatetgLayout) (Return Type : RPATGRow) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_CreatetgLayout_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCreatetgLayoutPrametersTypes = new Type[] { typeof(bool), typeof(int), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodCreatetgLayout, Fixture, methodCreatetgLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreatetgLayoutPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (CreatetgLayout) (Return Type : RPATGRow) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_CreatetgLayout_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreatetgLayoutPrametersTypes = new Type[] { typeof(bool), typeof(int), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodCreatetgLayout, Fixture, methodCreatetgLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreatetgLayoutPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreatetgLayout) (Return Type : RPATGRow) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_CreatetgLayout_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreatetgLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (CreatetgLayout) (Return Type : RPATGRow) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_CreatetgLayout_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreatetgLayout, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTargetRGBData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetTargetRGBData_Method_Call_Internally(Type[] types)
        {
            var methodGetTargetRGBDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetTargetRGBData, Fixture, methodGetTargetRGBDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTargetRGBData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetTargetRGBData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.GetTargetRGBData();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTargetRGBData) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetTargetRGBData_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetTargetRGBDataPrametersTypes = null;
            object[] parametersOfGetTargetRGBData = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTargetRGBData, methodGetTargetRGBDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfGetTargetRGBData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTargetRGBData.ShouldBeNull();
            methodGetTargetRGBDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTargetRGBData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetTargetRGBData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetTargetRGBDataPrametersTypes = null;
            object[] parametersOfGetTargetRGBData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetTargetRGBData, parametersOfGetTargetRGBData, methodGetTargetRGBDataPrametersTypes);

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
        public void AUT_RPAData_GetTargetRGBData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetTargetRGBDataPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetTargetRGBData, Fixture, methodGetTargetRGBDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTargetRGBDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTargetRGBData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetTargetRGBData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetTargetRGBDataPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetTargetRGBData, Fixture, methodGetTargetRGBDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTargetRGBDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTargetRGBData) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetTargetRGBData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTargetRGBData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (CreateNewResFullDAta) (Return Type : clsResFullDAta) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_CreateNewResFullDAta_Method_Call_Internally(Type[] types)
        {
            var methodCreateNewResFullDAtaPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodCreateNewResFullDAta, Fixture, methodCreateNewResFullDAtaPrametersTypes);
        }

        #endregion
        
        #region Method Call : (CreateNewResFullDAta) (Return Type : clsResFullDAta) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_CreateNewResFullDAta_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateNewResFullDAtaPrametersTypes = null;
            object[] parametersOfCreateNewResFullDAta = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateNewResFullDAta, methodCreateNewResFullDAtaPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfCreateNewResFullDAta);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateNewResFullDAta.ShouldBeNull();
            methodCreateNewResFullDAtaPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateNewResFullDAta) (Return Type : clsResFullDAta) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_CreateNewResFullDAta_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodCreateNewResFullDAtaPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodCreateNewResFullDAta, Fixture, methodCreateNewResFullDAtaPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodCreateNewResFullDAtaPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateNewResFullDAta) (Return Type : clsResFullDAta) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_CreateNewResFullDAta_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateNewResFullDAtaPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodCreateNewResFullDAta, Fixture, methodCreateNewResFullDAtaPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateNewResFullDAtaPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateNewResFullDAta) (Return Type : clsResFullDAta) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_CreateNewResFullDAta_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateNewResFullDAta, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (StashViews) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_StashViews_Method_Call_Internally(Type[] types)
        {
            var methodStashViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodStashViews, Fixture, methodStashViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (StashViews) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_StashViews_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sViews = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.StashViews(sViews);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (StashViews) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_StashViews_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sViews = CreateType<string>();
            var methodStashViewsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStashViews = { sViews };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodStashViews, methodStashViewsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfStashViews);

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
        public void AUT_RPAData_StashViews_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sViews = CreateType<string>();
            var methodStashViewsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStashViews = { sViews };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rPADataInstance, MethodStashViews, parametersOfStashViews, methodStashViewsPrametersTypes);

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
        public void AUT_RPAData_StashViews_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_RPAData_StashViews_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodStashViewsPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodStashViews, Fixture, methodStashViewsPrametersTypes);

            // Assert
            methodStashViewsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StashViews) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_StashViews_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodStashViews, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyServerSideViewSettings) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_ApplyServerSideViewSettings_Method_Call_Internally(Type[] types)
        {
            var methodApplyServerSideViewSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodApplyServerSideViewSettings, Fixture, methodApplyServerSideViewSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (ApplyServerSideViewSettings) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ApplyServerSideViewSettings_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var guid = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.ApplyServerSideViewSettings(guid);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ApplyServerSideViewSettings) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ApplyServerSideViewSettings_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var guid = CreateType<string>();
            var methodApplyServerSideViewSettingsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfApplyServerSideViewSettings = { guid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodApplyServerSideViewSettings, parametersOfApplyServerSideViewSettings, methodApplyServerSideViewSettingsPrametersTypes);

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
        public void AUT_RPAData_ApplyServerSideViewSettings_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodApplyServerSideViewSettingsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodApplyServerSideViewSettings, Fixture, methodApplyServerSideViewSettingsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodApplyServerSideViewSettingsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ApplyServerSideViewSettings) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ApplyServerSideViewSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodApplyServerSideViewSettingsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodApplyServerSideViewSettings, Fixture, methodApplyServerSideViewSettingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodApplyServerSideViewSettingsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ApplyServerSideViewSettings) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ApplyServerSideViewSettings_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodApplyServerSideViewSettings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ApplyServerSideViewSettings) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ApplyServerSideViewSettings_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (RemoveCapacityScenario) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_RemoveCapacityScenario_Method_Call_Internally(Type[] types)
        {
            var methodRemoveCapacityScenarioPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodRemoveCapacityScenario, Fixture, methodRemoveCapacityScenarioPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveCapacityScenario) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_RemoveCapacityScenario_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var csid = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.RemoveCapacityScenario(csid);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RemoveCapacityScenario) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_RemoveCapacityScenario_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var csid = CreateType<int>();
            var methodRemoveCapacityScenarioPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfRemoveCapacityScenario = { csid };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRemoveCapacityScenario, methodRemoveCapacityScenarioPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfRemoveCapacityScenario);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRemoveCapacityScenario.ShouldNotBeNull();
            parametersOfRemoveCapacityScenario.Length.ShouldBe(1);
            methodRemoveCapacityScenarioPrametersTypes.Length.ShouldBe(1);
            methodRemoveCapacityScenarioPrametersTypes.Length.ShouldBe(parametersOfRemoveCapacityScenario.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RemoveCapacityScenario) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_RemoveCapacityScenario_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var csid = CreateType<int>();
            var methodRemoveCapacityScenarioPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfRemoveCapacityScenario = { csid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rPADataInstance, MethodRemoveCapacityScenario, parametersOfRemoveCapacityScenario, methodRemoveCapacityScenarioPrametersTypes);

            // Assert
            parametersOfRemoveCapacityScenario.ShouldNotBeNull();
            parametersOfRemoveCapacityScenario.Length.ShouldBe(1);
            methodRemoveCapacityScenarioPrametersTypes.Length.ShouldBe(1);
            methodRemoveCapacityScenarioPrametersTypes.Length.ShouldBe(parametersOfRemoveCapacityScenario.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveCapacityScenario) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_RemoveCapacityScenario_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRemoveCapacityScenario, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveCapacityScenario) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_RemoveCapacityScenario_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRemoveCapacityScenarioPrametersTypes = new Type[] { typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodRemoveCapacityScenario, Fixture, methodRemoveCapacityScenarioPrametersTypes);

            // Assert
            methodRemoveCapacityScenarioPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveCapacityScenario) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_RemoveCapacityScenario_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemoveCapacityScenario, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PrepareCSGrid) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_PrepareCSGrid_Method_Call_Internally(Type[] types)
        {
            var methodPrepareCSGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodPrepareCSGrid, Fixture, methodPrepareCSGridPrametersTypes);
        }

        #endregion

        #region Method Call : (PrepareCSGrid) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_PrepareCSGrid_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var csmode = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.PrepareCSGrid(sXML, csmode);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (PrepareCSGrid) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_PrepareCSGrid_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var csmode = CreateType<int>();
            var methodPrepareCSGridPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfPrepareCSGrid = { sXML, csmode };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPrepareCSGrid, methodPrepareCSGridPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RPAData, string>(_rPADataInstanceFixture, out exception1, parametersOfPrepareCSGrid);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodPrepareCSGrid, parametersOfPrepareCSGrid, methodPrepareCSGridPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfPrepareCSGrid.ShouldNotBeNull();
            parametersOfPrepareCSGrid.Length.ShouldBe(2);
            methodPrepareCSGridPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (PrepareCSGrid) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_PrepareCSGrid_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var csmode = CreateType<int>();
            var methodPrepareCSGridPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfPrepareCSGrid = { sXML, csmode };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodPrepareCSGrid, parametersOfPrepareCSGrid, methodPrepareCSGridPrametersTypes);

            // Assert
            parametersOfPrepareCSGrid.ShouldNotBeNull();
            parametersOfPrepareCSGrid.Length.ShouldBe(2);
            methodPrepareCSGridPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PrepareCSGrid) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_PrepareCSGrid_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodPrepareCSGridPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodPrepareCSGrid, Fixture, methodPrepareCSGridPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodPrepareCSGridPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (PrepareCSGrid) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_PrepareCSGrid_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPrepareCSGridPrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodPrepareCSGrid, Fixture, methodPrepareCSGridPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPrepareCSGridPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PrepareCSGrid) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_PrepareCSGrid_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPrepareCSGrid, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PrepareCSGrid) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_PrepareCSGrid_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPrepareCSGrid, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioGrid) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetCapacityScenarioGrid_Method_Call_Internally(Type[] types)
        {
            var methodGetCapacityScenarioGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetCapacityScenarioGrid, Fixture, methodGetCapacityScenarioGridPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioGrid) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCapacityScenarioGrid_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.GetCapacityScenarioGrid();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioGrid) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCapacityScenarioGrid_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetCapacityScenarioGridPrametersTypes = null;
            object[] parametersOfGetCapacityScenarioGrid = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetCapacityScenarioGrid, parametersOfGetCapacityScenarioGrid, methodGetCapacityScenarioGridPrametersTypes);

            // Assert
            parametersOfGetCapacityScenarioGrid.ShouldBeNull();
            methodGetCapacityScenarioGridPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCapacityScenarioGrid) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCapacityScenarioGrid_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetCapacityScenarioGridPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetCapacityScenarioGrid, Fixture, methodGetCapacityScenarioGridPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetCapacityScenarioGridPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCapacityScenarioGrid) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCapacityScenarioGrid_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetCapacityScenarioGridPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetCapacityScenarioGrid, Fixture, methodGetCapacityScenarioGridPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCapacityScenarioGridPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCapacityScenarioGrid) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCapacityScenarioGrid_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCapacityScenarioGrid, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLegendGrid) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetLegendGrid_Method_Call_Internally(Type[] types)
        {
            var methodGetLegendGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetLegendGrid, Fixture, methodGetLegendGridPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLegendGrid) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetLegendGrid_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.GetLegendGrid();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetLegendGrid) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetLegendGrid_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetLegendGridPrametersTypes = null;
            object[] parametersOfGetLegendGrid = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetLegendGrid, methodGetLegendGridPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfGetLegendGrid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetLegendGrid.ShouldBeNull();
            methodGetLegendGridPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLegendGrid) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetLegendGrid_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetLegendGridPrametersTypes = null;
            object[] parametersOfGetLegendGrid = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetLegendGrid, parametersOfGetLegendGrid, methodGetLegendGridPrametersTypes);

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
        public void AUT_RPAData_GetLegendGrid_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetLegendGridPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetLegendGrid, Fixture, methodGetLegendGridPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLegendGridPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLegendGrid) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetLegendGrid_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetLegendGridPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetLegendGrid, Fixture, methodGetLegendGridPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLegendGridPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLegendGrid) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetLegendGrid_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLegendGrid, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (StashCapacityReloadXML) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_StashCapacityReloadXML_Method_Call_Internally(Type[] types)
        {
            var methodStashCapacityReloadXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodStashCapacityReloadXML, Fixture, methodStashCapacityReloadXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (StashCapacityReloadXML) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_StashCapacityReloadXML_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.StashCapacityReloadXML(sXML);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (StashCapacityReloadXML) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_StashCapacityReloadXML_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var methodStashCapacityReloadXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStashCapacityReloadXML = { sXML };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodStashCapacityReloadXML, methodStashCapacityReloadXMLPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfStashCapacityReloadXML);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfStashCapacityReloadXML.ShouldNotBeNull();
            parametersOfStashCapacityReloadXML.Length.ShouldBe(1);
            methodStashCapacityReloadXMLPrametersTypes.Length.ShouldBe(1);
            methodStashCapacityReloadXMLPrametersTypes.Length.ShouldBe(parametersOfStashCapacityReloadXML.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StashCapacityReloadXML) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_StashCapacityReloadXML_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var methodStashCapacityReloadXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStashCapacityReloadXML = { sXML };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rPADataInstance, MethodStashCapacityReloadXML, parametersOfStashCapacityReloadXML, methodStashCapacityReloadXMLPrametersTypes);

            // Assert
            parametersOfStashCapacityReloadXML.ShouldNotBeNull();
            parametersOfStashCapacityReloadXML.Length.ShouldBe(1);
            methodStashCapacityReloadXMLPrametersTypes.Length.ShouldBe(1);
            methodStashCapacityReloadXMLPrametersTypes.Length.ShouldBe(parametersOfStashCapacityReloadXML.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StashCapacityReloadXML) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_StashCapacityReloadXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodStashCapacityReloadXML, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (StashCapacityReloadXML) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_StashCapacityReloadXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodStashCapacityReloadXMLPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodStashCapacityReloadXML, Fixture, methodStashCapacityReloadXMLPrametersTypes);

            // Assert
            methodStashCapacityReloadXMLPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StashCapacityReloadXML) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_StashCapacityReloadXML_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodStashCapacityReloadXML, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCapacityReloadXML) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetCapacityReloadXML_Method_Call_Internally(Type[] types)
        {
            var methodGetCapacityReloadXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetCapacityReloadXML, Fixture, methodGetCapacityReloadXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCapacityReloadXML) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCapacityReloadXML_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.GetCapacityReloadXML();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetCapacityReloadXML) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCapacityReloadXML_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetCapacityReloadXMLPrametersTypes = null;
            object[] parametersOfGetCapacityReloadXML = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCapacityReloadXML, methodGetCapacityReloadXMLPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfGetCapacityReloadXML);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCapacityReloadXML.ShouldBeNull();
            methodGetCapacityReloadXMLPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCapacityReloadXML) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCapacityReloadXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetCapacityReloadXMLPrametersTypes = null;
            object[] parametersOfGetCapacityReloadXML = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetCapacityReloadXML, parametersOfGetCapacityReloadXML, methodGetCapacityReloadXMLPrametersTypes);

            // Assert
            parametersOfGetCapacityReloadXML.ShouldBeNull();
            methodGetCapacityReloadXMLPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCapacityReloadXML) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCapacityReloadXML_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetCapacityReloadXMLPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetCapacityReloadXML, Fixture, methodGetCapacityReloadXMLPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetCapacityReloadXMLPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCapacityReloadXML) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCapacityReloadXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetCapacityReloadXMLPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetCapacityReloadXML, Fixture, methodGetCapacityReloadXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCapacityReloadXMLPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCapacityReloadXML) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCapacityReloadXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCapacityReloadXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (RPASaveDraggedData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_RPASaveDraggedData_Method_Call_Internally(Type[] types)
        {
            var methodRPASaveDraggedDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodRPASaveDraggedData, Fixture, methodRPASaveDraggedDataPrametersTypes);
        }

        #endregion

        #region Method Call : (RPASaveDraggedData) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_RPASaveDraggedData_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.RPASaveDraggedData();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (RPASaveDraggedData) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_RPASaveDraggedData_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodRPASaveDraggedDataPrametersTypes = null;
            object[] parametersOfRPASaveDraggedData = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRPASaveDraggedData, methodRPASaveDraggedDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RPAData, string>(_rPADataInstanceFixture, out exception1, parametersOfRPASaveDraggedData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodRPASaveDraggedData, parametersOfRPASaveDraggedData, methodRPASaveDraggedDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRPASaveDraggedData.ShouldBeNull();
            methodRPASaveDraggedDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RPASaveDraggedData) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_RPASaveDraggedData_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRPASaveDraggedDataPrametersTypes = null;
            object[] parametersOfRPASaveDraggedData = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRPASaveDraggedData, methodRPASaveDraggedDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfRPASaveDraggedData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRPASaveDraggedData.ShouldBeNull();
            methodRPASaveDraggedDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RPASaveDraggedData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_RPASaveDraggedData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRPASaveDraggedDataPrametersTypes = null;
            object[] parametersOfRPASaveDraggedData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodRPASaveDraggedData, parametersOfRPASaveDraggedData, methodRPASaveDraggedDataPrametersTypes);

            // Assert
            parametersOfRPASaveDraggedData.ShouldBeNull();
            methodRPASaveDraggedDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RPASaveDraggedData) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_RPASaveDraggedData_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodRPASaveDraggedDataPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodRPASaveDraggedData, Fixture, methodRPASaveDraggedDataPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodRPASaveDraggedDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RPASaveDraggedData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_RPASaveDraggedData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRPASaveDraggedDataPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodRPASaveDraggedData, Fixture, methodRPASaveDraggedDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRPASaveDraggedDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RPASaveDraggedData) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_RPASaveDraggedData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRPASaveDraggedData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetPMOAdmin) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetPMOAdmin_Method_Call_Internally(Type[] types)
        {
            var methodGetPMOAdminPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetPMOAdmin, Fixture, methodGetPMOAdminPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPMOAdmin) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetPMOAdmin_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.GetPMOAdmin();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetPMOAdmin) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetPMOAdmin_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetPMOAdminPrametersTypes = null;
            object[] parametersOfGetPMOAdmin = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetPMOAdmin, methodGetPMOAdminPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfGetPMOAdmin);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetPMOAdmin.ShouldBeNull();
            methodGetPMOAdminPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPMOAdmin) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetPMOAdmin_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetPMOAdminPrametersTypes = null;
            object[] parametersOfGetPMOAdmin = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetPMOAdmin, parametersOfGetPMOAdmin, methodGetPMOAdminPrametersTypes);

            // Assert
            parametersOfGetPMOAdmin.ShouldBeNull();
            methodGetPMOAdminPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPMOAdmin) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetPMOAdmin_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetPMOAdminPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetPMOAdmin, Fixture, methodGetPMOAdminPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetPMOAdminPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPMOAdmin) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetPMOAdmin_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetPMOAdminPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetPMOAdmin, Fixture, methodGetPMOAdminPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPMOAdminPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPMOAdmin) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetPMOAdmin_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPMOAdmin, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetStartFinishDataPeriods) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetStartFinishDataPeriods_Method_Call_Internally(Type[] types)
        {
            var methodGetStartFinishDataPeriodsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetStartFinishDataPeriods, Fixture, methodGetStartFinishDataPeriodsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetStartFinishDataPeriods) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetStartFinishDataPeriods_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var istart = CreateType<int>();
            var ifinish = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.GetStartFinishDataPeriods(out istart, out ifinish);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetStartFinishDataPeriods) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetStartFinishDataPeriods_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var istart = CreateType<int>();
            var ifinish = CreateType<int>();
            var methodGetStartFinishDataPeriodsPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfGetStartFinishDataPeriods = { istart, ifinish };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetStartFinishDataPeriods, methodGetStartFinishDataPeriodsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfGetStartFinishDataPeriods);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetStartFinishDataPeriods.ShouldNotBeNull();
            parametersOfGetStartFinishDataPeriods.Length.ShouldBe(2);
            methodGetStartFinishDataPeriodsPrametersTypes.Length.ShouldBe(2);
            methodGetStartFinishDataPeriodsPrametersTypes.Length.ShouldBe(parametersOfGetStartFinishDataPeriods.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetStartFinishDataPeriods) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetStartFinishDataPeriods_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var istart = CreateType<int>();
            var ifinish = CreateType<int>();
            var methodGetStartFinishDataPeriodsPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfGetStartFinishDataPeriods = { istart, ifinish };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rPADataInstance, MethodGetStartFinishDataPeriods, parametersOfGetStartFinishDataPeriods, methodGetStartFinishDataPeriodsPrametersTypes);

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
        public void AUT_RPAData_GetStartFinishDataPeriods_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_RPAData_GetStartFinishDataPeriods_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetStartFinishDataPeriodsPrametersTypes = new Type[] { typeof(int), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetStartFinishDataPeriods, Fixture, methodGetStartFinishDataPeriodsPrametersTypes);

            // Assert
            methodGetStartFinishDataPeriodsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetStartFinishDataPeriods) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetStartFinishDataPeriods_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetStartFinishDataPeriods, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetHeatmapText) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetHeatmapText_Method_Call_Internally(Type[] types)
        {
            var methodGetHeatmapTextPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetHeatmapText, Fixture, methodGetHeatmapTextPrametersTypes);
        }

        #endregion

        #region Method Call : (GetHeatmapText) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetHeatmapText_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.GetHeatmapText();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetHeatmapText) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetHeatmapText_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetHeatmapTextPrametersTypes = null;
            object[] parametersOfGetHeatmapText = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetHeatmapText, methodGetHeatmapTextPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RPAData, string>(_rPADataInstanceFixture, out exception1, parametersOfGetHeatmapText);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetHeatmapText, parametersOfGetHeatmapText, methodGetHeatmapTextPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetHeatmapText.ShouldBeNull();
            methodGetHeatmapTextPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetHeatmapText) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetHeatmapText_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetHeatmapTextPrametersTypes = null;
            object[] parametersOfGetHeatmapText = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetHeatmapText, methodGetHeatmapTextPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfGetHeatmapText);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetHeatmapText.ShouldBeNull();
            methodGetHeatmapTextPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetHeatmapText) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetHeatmapText_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetHeatmapTextPrametersTypes = null;
            object[] parametersOfGetHeatmapText = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetHeatmapText, parametersOfGetHeatmapText, methodGetHeatmapTextPrametersTypes);

            // Assert
            parametersOfGetHeatmapText.ShouldBeNull();
            methodGetHeatmapTextPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetHeatmapText) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetHeatmapText_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetHeatmapTextPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetHeatmapText, Fixture, methodGetHeatmapTextPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetHeatmapTextPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetHeatmapText) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetHeatmapText_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetHeatmapTextPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetHeatmapText, Fixture, methodGetHeatmapTextPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetHeatmapTextPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetHeatmapText) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetHeatmapText_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetHeatmapText, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetInitialParamXML) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetInitialParamXML_Method_Call_Internally(Type[] types)
        {
            var methodGetInitialParamXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetInitialParamXML, Fixture, methodGetInitialParamXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (GetInitialParamXML) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetInitialParamXML_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.GetInitialParamXML();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetInitialParamXML) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetInitialParamXML_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetInitialParamXMLPrametersTypes = null;
            object[] parametersOfGetInitialParamXML = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetInitialParamXML, methodGetInitialParamXMLPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfGetInitialParamXML);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetInitialParamXML.ShouldBeNull();
            methodGetInitialParamXMLPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetInitialParamXML) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetInitialParamXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetInitialParamXMLPrametersTypes = null;
            object[] parametersOfGetInitialParamXML = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetInitialParamXML, parametersOfGetInitialParamXML, methodGetInitialParamXMLPrametersTypes);

            // Assert
            parametersOfGetInitialParamXML.ShouldBeNull();
            methodGetInitialParamXMLPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetInitialParamXML) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetInitialParamXML_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetInitialParamXMLPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetInitialParamXML, Fixture, methodGetInitialParamXMLPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetInitialParamXMLPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetInitialParamXML) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetInitialParamXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetInitialParamXMLPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetInitialParamXML, Fixture, methodGetInitialParamXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetInitialParamXMLPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetInitialParamXML) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetInitialParamXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetInitialParamXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ReplaceCSData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_ReplaceCSData_Method_Call_Internally(Type[] types)
        {
            var methodReplaceCSDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodReplaceCSData, Fixture, methodReplaceCSDataPrametersTypes);
        }

        #endregion
        
        #region Method Call : (ReplaceCSData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ReplaceCSData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReplaceCSData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion
        
        #region Method Call : (ReplaceCSData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ReplaceCSData_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReplaceCSData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateCSDataMode) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_UpdateCSDataMode_Method_Call_Internally(Type[] types)
        {
            var methodUpdateCSDataModePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodUpdateCSDataMode, Fixture, methodUpdateCSDataModePrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateCSDataMode) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_UpdateCSDataMode_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var oRoleModes = CreateType<CStruct>();
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.UpdateCSDataMode(oRoleModes);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (UpdateCSDataMode) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_UpdateCSDataMode_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var oRoleModes = CreateType<CStruct>();
            var methodUpdateCSDataModePrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfUpdateCSDataMode = { oRoleModes };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateCSDataMode, methodUpdateCSDataModePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfUpdateCSDataMode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateCSDataMode.ShouldNotBeNull();
            parametersOfUpdateCSDataMode.Length.ShouldBe(1);
            methodUpdateCSDataModePrametersTypes.Length.ShouldBe(1);
            methodUpdateCSDataModePrametersTypes.Length.ShouldBe(parametersOfUpdateCSDataMode.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateCSDataMode) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_UpdateCSDataMode_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oRoleModes = CreateType<CStruct>();
            var methodUpdateCSDataModePrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfUpdateCSDataMode = { oRoleModes };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rPADataInstance, MethodUpdateCSDataMode, parametersOfUpdateCSDataMode, methodUpdateCSDataModePrametersTypes);

            // Assert
            parametersOfUpdateCSDataMode.ShouldNotBeNull();
            parametersOfUpdateCSDataMode.Length.ShouldBe(1);
            methodUpdateCSDataModePrametersTypes.Length.ShouldBe(1);
            methodUpdateCSDataModePrametersTypes.Length.ShouldBe(parametersOfUpdateCSDataMode.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateCSDataMode) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_UpdateCSDataMode_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateCSDataMode, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateCSDataMode) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_UpdateCSDataMode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateCSDataModePrametersTypes = new Type[] { typeof(CStruct) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodUpdateCSDataMode, Fixture, methodUpdateCSDataModePrametersTypes);

            // Assert
            methodUpdateCSDataModePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateCSDataMode) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_UpdateCSDataMode_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateCSDataMode, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ResolvePIName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_ResolvePIName_Method_Call_Internally(Type[] types)
        {
            var methodResolvePINamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodResolvePIName, Fixture, methodResolvePINamePrametersTypes);
        }

        #endregion

        #region Method Call : (ResolvePIName) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ResolvePIName_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var pid = CreateType<int>();
            var methodResolvePINamePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfResolvePIName = { pid };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodResolvePIName, methodResolvePINamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfResolvePIName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfResolvePIName.ShouldNotBeNull();
            parametersOfResolvePIName.Length.ShouldBe(1);
            methodResolvePINamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ResolvePIName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ResolvePIName_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var pid = CreateType<int>();
            var methodResolvePINamePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfResolvePIName = { pid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodResolvePIName, parametersOfResolvePIName, methodResolvePINamePrametersTypes);

            // Assert
            parametersOfResolvePIName.ShouldNotBeNull();
            parametersOfResolvePIName.Length.ShouldBe(1);
            methodResolvePINamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ResolvePIName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ResolvePIName_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodResolvePINamePrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodResolvePIName, Fixture, methodResolvePINamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodResolvePINamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ResolvePIName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ResolvePIName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodResolvePINamePrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodResolvePIName, Fixture, methodResolvePINamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodResolvePINamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ResolvePIName) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ResolvePIName_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodResolvePIName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ResolvePIName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_ResolvePIName_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodResolvePIName, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRoleScrenarioData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetRoleScrenarioData_Method_Call_Internally(Type[] types)
        {
            var methodGetRoleScrenarioDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetRoleScrenarioData, Fixture, methodGetRoleScrenarioDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRoleScrenarioData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetRoleScrenarioData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var capscen = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.GetRoleScrenarioData(sXML, capscen);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetRoleScrenarioData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetRoleScrenarioData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var capscen = CreateType<string>();
            var methodGetRoleScrenarioDataPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetRoleScrenarioData = { sXML, capscen };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetRoleScrenarioData, methodGetRoleScrenarioDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RPAData, string>(_rPADataInstanceFixture, out exception1, parametersOfGetRoleScrenarioData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetRoleScrenarioData, parametersOfGetRoleScrenarioData, methodGetRoleScrenarioDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetRoleScrenarioData.ShouldNotBeNull();
            parametersOfGetRoleScrenarioData.Length.ShouldBe(2);
            methodGetRoleScrenarioDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetRoleScrenarioData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetRoleScrenarioData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var capscen = CreateType<string>();
            var methodGetRoleScrenarioDataPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetRoleScrenarioData = { sXML, capscen };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetRoleScrenarioData, parametersOfGetRoleScrenarioData, methodGetRoleScrenarioDataPrametersTypes);

            // Assert
            parametersOfGetRoleScrenarioData.ShouldNotBeNull();
            parametersOfGetRoleScrenarioData.Length.ShouldBe(2);
            methodGetRoleScrenarioDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRoleScrenarioData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetRoleScrenarioData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetRoleScrenarioDataPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetRoleScrenarioData, Fixture, methodGetRoleScrenarioDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetRoleScrenarioDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetRoleScrenarioData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetRoleScrenarioData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRoleScrenarioDataPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetRoleScrenarioData, Fixture, methodGetRoleScrenarioDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRoleScrenarioDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRoleScrenarioData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetRoleScrenarioData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRoleScrenarioData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRoleScrenarioData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetRoleScrenarioData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRoleScrenarioData, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetNegotiationMode) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetNegotiationMode_Method_Call_Internally(Type[] types)
        {
            var methodGetNegotiationModePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetNegotiationMode, Fixture, methodGetNegotiationModePrametersTypes);
        }

        #endregion

        #region Method Call : (GetNegotiationMode) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetNegotiationMode_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.GetNegotiationMode();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetNegotiationMode) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetNegotiationMode_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetNegotiationModePrametersTypes = null;
            object[] parametersOfGetNegotiationMode = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetNegotiationMode, methodGetNegotiationModePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RPAData, bool>(_rPADataInstanceFixture, out exception1, parametersOfGetNegotiationMode);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RPAData, bool>(_rPADataInstance, MethodGetNegotiationMode, parametersOfGetNegotiationMode, methodGetNegotiationModePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetNegotiationMode.ShouldBeNull();
            methodGetNegotiationModePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetNegotiationMode) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetNegotiationMode_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetNegotiationModePrametersTypes = null;
            object[] parametersOfGetNegotiationMode = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetNegotiationMode, methodGetNegotiationModePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RPAData, bool>(_rPADataInstanceFixture, out exception1, parametersOfGetNegotiationMode);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RPAData, bool>(_rPADataInstance, MethodGetNegotiationMode, parametersOfGetNegotiationMode, methodGetNegotiationModePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetNegotiationMode.ShouldBeNull();
            methodGetNegotiationModePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetNegotiationMode) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetNegotiationMode_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetNegotiationModePrametersTypes = null;
            object[] parametersOfGetNegotiationMode = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetNegotiationMode, methodGetNegotiationModePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfGetNegotiationMode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetNegotiationMode.ShouldBeNull();
            methodGetNegotiationModePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetNegotiationMode) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetNegotiationMode_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetNegotiationModePrametersTypes = null;
            object[] parametersOfGetNegotiationMode = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, bool>(_rPADataInstance, MethodGetNegotiationMode, parametersOfGetNegotiationMode, methodGetNegotiationModePrametersTypes);

            // Assert
            parametersOfGetNegotiationMode.ShouldBeNull();
            methodGetNegotiationModePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetNegotiationMode) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetNegotiationMode_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetNegotiationModePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetNegotiationMode, Fixture, methodGetNegotiationModePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetNegotiationModePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetNegotiationMode) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetNegotiationMode_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetNegotiationModePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetNegotiationMode, Fixture, methodGetNegotiationModePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetNegotiationModePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetNegotiationMode) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetNegotiationMode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetNegotiationModePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetNegotiationMode, Fixture, methodGetNegotiationModePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetNegotiationModePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetNegotiationMode) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetNegotiationMode_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetNegotiationMode, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetCSDeptUIDs) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetCSDeptUIDs_Method_Call_Internally(Type[] types)
        {
            var methodGetCSDeptUIDsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetCSDeptUIDs, Fixture, methodGetCSDeptUIDsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCSDeptUIDs) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCSDeptUIDs_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.GetCSDeptUIDs();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetCSDeptUIDs) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCSDeptUIDs_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetCSDeptUIDsPrametersTypes = null;
            object[] parametersOfGetCSDeptUIDs = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCSDeptUIDs, methodGetCSDeptUIDsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RPAData, string>(_rPADataInstanceFixture, out exception1, parametersOfGetCSDeptUIDs);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetCSDeptUIDs, parametersOfGetCSDeptUIDs, methodGetCSDeptUIDsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetCSDeptUIDs.ShouldBeNull();
            methodGetCSDeptUIDsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCSDeptUIDs) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCSDeptUIDs_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetCSDeptUIDsPrametersTypes = null;
            object[] parametersOfGetCSDeptUIDs = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCSDeptUIDs, methodGetCSDeptUIDsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfGetCSDeptUIDs);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCSDeptUIDs.ShouldBeNull();
            methodGetCSDeptUIDsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCSDeptUIDs) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCSDeptUIDs_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetCSDeptUIDsPrametersTypes = null;
            object[] parametersOfGetCSDeptUIDs = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetCSDeptUIDs, parametersOfGetCSDeptUIDs, methodGetCSDeptUIDsPrametersTypes);

            // Assert
            parametersOfGetCSDeptUIDs.ShouldBeNull();
            methodGetCSDeptUIDsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCSDeptUIDs) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCSDeptUIDs_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetCSDeptUIDsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetCSDeptUIDs, Fixture, methodGetCSDeptUIDsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetCSDeptUIDsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCSDeptUIDs) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCSDeptUIDs_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetCSDeptUIDsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetCSDeptUIDs, Fixture, methodGetCSDeptUIDsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCSDeptUIDsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCSDeptUIDs) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCSDeptUIDs_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCSDeptUIDs, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetCSDeptList) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetCSDeptList_Method_Call_Internally(Type[] types)
        {
            var methodGetCSDeptListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetCSDeptList, Fixture, methodGetCSDeptListPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCSDeptList) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCSDeptList_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.GetCSDeptList();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetCSDeptList) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCSDeptList_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetCSDeptListPrametersTypes = null;
            object[] parametersOfGetCSDeptList = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCSDeptList, methodGetCSDeptListPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RPAData, string>(_rPADataInstanceFixture, out exception1, parametersOfGetCSDeptList);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetCSDeptList, parametersOfGetCSDeptList, methodGetCSDeptListPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetCSDeptList.ShouldBeNull();
            methodGetCSDeptListPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCSDeptList) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCSDeptList_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetCSDeptListPrametersTypes = null;
            object[] parametersOfGetCSDeptList = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCSDeptList, methodGetCSDeptListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfGetCSDeptList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCSDeptList.ShouldBeNull();
            methodGetCSDeptListPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCSDeptList) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCSDeptList_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetCSDeptListPrametersTypes = null;
            object[] parametersOfGetCSDeptList = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetCSDeptList, parametersOfGetCSDeptList, methodGetCSDeptListPrametersTypes);

            // Assert
            parametersOfGetCSDeptList.ShouldBeNull();
            methodGetCSDeptListPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCSDeptList) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCSDeptList_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetCSDeptListPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetCSDeptList, Fixture, methodGetCSDeptListPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetCSDeptListPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCSDeptList) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCSDeptList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetCSDeptListPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetCSDeptList, Fixture, methodGetCSDeptListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCSDeptListPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCSDeptList) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCSDeptList_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCSDeptList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SetAllChecks) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_SetAllChecks_Method_Call_Internally(Type[] types)
        {
            var methodSetAllChecksPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodSetAllChecks, Fixture, methodSetAllChecksPrametersTypes);
        }

        #endregion

        #region Method Call : (SetAllChecks) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetAllChecks_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var bchecked = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.SetAllChecks(bchecked);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetAllChecks) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetAllChecks_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var bchecked = CreateType<bool>();
            var methodSetAllChecksPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfSetAllChecks = { bchecked };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetAllChecks, methodSetAllChecksPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfSetAllChecks);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetAllChecks.ShouldNotBeNull();
            parametersOfSetAllChecks.Length.ShouldBe(1);
            methodSetAllChecksPrametersTypes.Length.ShouldBe(1);
            methodSetAllChecksPrametersTypes.Length.ShouldBe(parametersOfSetAllChecks.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetAllChecks) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetAllChecks_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var bchecked = CreateType<bool>();
            var methodSetAllChecksPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfSetAllChecks = { bchecked };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rPADataInstance, MethodSetAllChecks, parametersOfSetAllChecks, methodSetAllChecksPrametersTypes);

            // Assert
            parametersOfSetAllChecks.ShouldNotBeNull();
            parametersOfSetAllChecks.Length.ShouldBe(1);
            methodSetAllChecksPrametersTypes.Length.ShouldBe(1);
            methodSetAllChecksPrametersTypes.Length.ShouldBe(parametersOfSetAllChecks.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetAllChecks) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetAllChecks_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetAllChecks, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetAllChecks) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetAllChecks_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetAllChecksPrametersTypes = new Type[] { typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodSetAllChecks, Fixture, methodSetAllChecksPrametersTypes);

            // Assert
            methodSetAllChecksPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetAllChecks) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetAllChecks_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetAllChecks, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetEditResPlanPIList) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetEditResPlanPIList_Method_Call_Internally(Type[] types)
        {
            var methodGetEditResPlanPIListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetEditResPlanPIList, Fixture, methodGetEditResPlanPIListPrametersTypes);
        }

        #endregion

        #region Method Call : (GetEditResPlanPIList) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetEditResPlanPIList_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.GetEditResPlanPIList();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetEditResPlanPIList) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetEditResPlanPIList_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetEditResPlanPIListPrametersTypes = null;
            object[] parametersOfGetEditResPlanPIList = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetEditResPlanPIList, methodGetEditResPlanPIListPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RPAData, string>(_rPADataInstanceFixture, out exception1, parametersOfGetEditResPlanPIList);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetEditResPlanPIList, parametersOfGetEditResPlanPIList, methodGetEditResPlanPIListPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetEditResPlanPIList.ShouldBeNull();
            methodGetEditResPlanPIListPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetEditResPlanPIList) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetEditResPlanPIList_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetEditResPlanPIListPrametersTypes = null;
            object[] parametersOfGetEditResPlanPIList = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetEditResPlanPIList, methodGetEditResPlanPIListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfGetEditResPlanPIList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetEditResPlanPIList.ShouldBeNull();
            methodGetEditResPlanPIListPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetEditResPlanPIList) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetEditResPlanPIList_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetEditResPlanPIListPrametersTypes = null;
            object[] parametersOfGetEditResPlanPIList = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetEditResPlanPIList, parametersOfGetEditResPlanPIList, methodGetEditResPlanPIListPrametersTypes);

            // Assert
            parametersOfGetEditResPlanPIList.ShouldBeNull();
            methodGetEditResPlanPIListPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetEditResPlanPIList) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetEditResPlanPIList_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetEditResPlanPIListPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetEditResPlanPIList, Fixture, methodGetEditResPlanPIListPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetEditResPlanPIListPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetEditResPlanPIList) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetEditResPlanPIList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetEditResPlanPIListPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetEditResPlanPIList, Fixture, methodGetEditResPlanPIListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetEditResPlanPIListPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetEditResPlanPIList) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetEditResPlanPIList_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetEditResPlanPIList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetEditResPlanResList) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetEditResPlanResList_Method_Call_Internally(Type[] types)
        {
            var methodGetEditResPlanResListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetEditResPlanResList, Fixture, methodGetEditResPlanResListPrametersTypes);
        }

        #endregion

        #region Method Call : (GetEditResPlanResList) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetEditResPlanResList_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.GetEditResPlanResList();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetEditResPlanResList) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetEditResPlanResList_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetEditResPlanResListPrametersTypes = null;
            object[] parametersOfGetEditResPlanResList = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetEditResPlanResList, methodGetEditResPlanResListPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RPAData, string>(_rPADataInstanceFixture, out exception1, parametersOfGetEditResPlanResList);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetEditResPlanResList, parametersOfGetEditResPlanResList, methodGetEditResPlanResListPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetEditResPlanResList.ShouldBeNull();
            methodGetEditResPlanResListPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetEditResPlanResList) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetEditResPlanResList_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetEditResPlanResListPrametersTypes = null;
            object[] parametersOfGetEditResPlanResList = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetEditResPlanResList, methodGetEditResPlanResListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfGetEditResPlanResList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetEditResPlanResList.ShouldBeNull();
            methodGetEditResPlanResListPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetEditResPlanResList) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetEditResPlanResList_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetEditResPlanResListPrametersTypes = null;
            object[] parametersOfGetEditResPlanResList = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetEditResPlanResList, parametersOfGetEditResPlanResList, methodGetEditResPlanResListPrametersTypes);

            // Assert
            parametersOfGetEditResPlanResList.ShouldBeNull();
            methodGetEditResPlanResListPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetEditResPlanResList) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetEditResPlanResList_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetEditResPlanResListPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetEditResPlanResList, Fixture, methodGetEditResPlanResListPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetEditResPlanResListPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetEditResPlanResList) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetEditResPlanResList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetEditResPlanResListPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetEditResPlanResList, Fixture, methodGetEditResPlanResListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetEditResPlanResListPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetEditResPlanResList) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetEditResPlanResList_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetEditResPlanResList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SetCalledFromResources) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_SetCalledFromResources_Method_Call_Internally(Type[] types)
        {
            var methodSetCalledFromResourcesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodSetCalledFromResources, Fixture, methodSetCalledFromResourcesPrametersTypes);
        }

        #endregion

        #region Method Call : (SetCalledFromResources) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetCalledFromResources_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var bFromResGrid = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.SetCalledFromResources(bFromResGrid);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (SetCalledFromResources) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetCalledFromResources_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var bFromResGrid = CreateType<bool>();
            var methodSetCalledFromResourcesPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfSetCalledFromResources = { bFromResGrid };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetCalledFromResources, methodSetCalledFromResourcesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfSetCalledFromResources);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetCalledFromResources.ShouldNotBeNull();
            parametersOfSetCalledFromResources.Length.ShouldBe(1);
            methodSetCalledFromResourcesPrametersTypes.Length.ShouldBe(1);
            methodSetCalledFromResourcesPrametersTypes.Length.ShouldBe(parametersOfSetCalledFromResources.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetCalledFromResources) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetCalledFromResources_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var bFromResGrid = CreateType<bool>();
            var methodSetCalledFromResourcesPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfSetCalledFromResources = { bFromResGrid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_rPADataInstance, MethodSetCalledFromResources, parametersOfSetCalledFromResources, methodSetCalledFromResourcesPrametersTypes);

            // Assert
            parametersOfSetCalledFromResources.ShouldNotBeNull();
            parametersOfSetCalledFromResources.Length.ShouldBe(1);
            methodSetCalledFromResourcesPrametersTypes.Length.ShouldBe(1);
            methodSetCalledFromResourcesPrametersTypes.Length.ShouldBe(parametersOfSetCalledFromResources.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetCalledFromResources) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetCalledFromResources_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetCalledFromResources, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetCalledFromResources) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetCalledFromResources_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetCalledFromResourcesPrametersTypes = new Type[] { typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodSetCalledFromResources, Fixture, methodSetCalledFromResourcesPrametersTypes);

            // Assert
            methodSetCalledFromResourcesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetCalledFromResources) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_SetCalledFromResources_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetCalledFromResources, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCalledFromResources) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetCalledFromResources_Method_Call_Internally(Type[] types)
        {
            var methodGetCalledFromResourcesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetCalledFromResources, Fixture, methodGetCalledFromResourcesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCalledFromResources) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCalledFromResources_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.GetCalledFromResources();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetCalledFromResources) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCalledFromResources_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetCalledFromResourcesPrametersTypes = null;
            object[] parametersOfGetCalledFromResources = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCalledFromResources, methodGetCalledFromResourcesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RPAData, bool>(_rPADataInstanceFixture, out exception1, parametersOfGetCalledFromResources);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RPAData, bool>(_rPADataInstance, MethodGetCalledFromResources, parametersOfGetCalledFromResources, methodGetCalledFromResourcesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetCalledFromResources.ShouldBeNull();
            methodGetCalledFromResourcesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCalledFromResources) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCalledFromResources_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetCalledFromResourcesPrametersTypes = null;
            object[] parametersOfGetCalledFromResources = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCalledFromResources, methodGetCalledFromResourcesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RPAData, bool>(_rPADataInstanceFixture, out exception1, parametersOfGetCalledFromResources);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RPAData, bool>(_rPADataInstance, MethodGetCalledFromResources, parametersOfGetCalledFromResources, methodGetCalledFromResourcesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetCalledFromResources.ShouldBeNull();
            methodGetCalledFromResourcesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCalledFromResources) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCalledFromResources_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetCalledFromResourcesPrametersTypes = null;
            object[] parametersOfGetCalledFromResources = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCalledFromResources, methodGetCalledFromResourcesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfGetCalledFromResources);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCalledFromResources.ShouldBeNull();
            methodGetCalledFromResourcesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCalledFromResources) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCalledFromResources_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetCalledFromResourcesPrametersTypes = null;
            object[] parametersOfGetCalledFromResources = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, bool>(_rPADataInstance, MethodGetCalledFromResources, parametersOfGetCalledFromResources, methodGetCalledFromResourcesPrametersTypes);

            // Assert
            parametersOfGetCalledFromResources.ShouldBeNull();
            methodGetCalledFromResourcesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCalledFromResources) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCalledFromResources_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetCalledFromResourcesPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetCalledFromResources, Fixture, methodGetCalledFromResourcesPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetCalledFromResourcesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCalledFromResources) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCalledFromResources_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetCalledFromResourcesPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetCalledFromResources, Fixture, methodGetCalledFromResourcesPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetCalledFromResourcesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCalledFromResources) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCalledFromResources_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetCalledFromResourcesPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetCalledFromResources, Fixture, methodGetCalledFromResourcesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCalledFromResourcesPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCalledFromResources) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetCalledFromResources_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCalledFromResources, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetEditResPlanTicket) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetEditResPlanTicket_Method_Call_Internally(Type[] types)
        {
            var methodGetEditResPlanTicketPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetEditResPlanTicket, Fixture, methodGetEditResPlanTicketPrametersTypes);
        }

        #endregion

        #region Method Call : (GetEditResPlanTicket) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetEditResPlanTicket_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var ticket = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.GetEditResPlanTicket(ticket);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetEditResPlanTicket) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetEditResPlanTicket_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var ticket = CreateType<string>();
            var methodGetEditResPlanTicketPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetEditResPlanTicket = { ticket };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetEditResPlanTicket, methodGetEditResPlanTicketPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RPAData, string>(_rPADataInstanceFixture, out exception1, parametersOfGetEditResPlanTicket);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetEditResPlanTicket, parametersOfGetEditResPlanTicket, methodGetEditResPlanTicketPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetEditResPlanTicket.ShouldNotBeNull();
            parametersOfGetEditResPlanTicket.Length.ShouldBe(1);
            methodGetEditResPlanTicketPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetEditResPlanTicket) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetEditResPlanTicket_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var ticket = CreateType<string>();
            var methodGetEditResPlanTicketPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetEditResPlanTicket = { ticket };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetEditResPlanTicket, methodGetEditResPlanTicketPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfGetEditResPlanTicket);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetEditResPlanTicket.ShouldNotBeNull();
            parametersOfGetEditResPlanTicket.Length.ShouldBe(1);
            methodGetEditResPlanTicketPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetEditResPlanTicket) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetEditResPlanTicket_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ticket = CreateType<string>();
            var methodGetEditResPlanTicketPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetEditResPlanTicket = { ticket };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetEditResPlanTicket, parametersOfGetEditResPlanTicket, methodGetEditResPlanTicketPrametersTypes);

            // Assert
            parametersOfGetEditResPlanTicket.ShouldNotBeNull();
            parametersOfGetEditResPlanTicket.Length.ShouldBe(1);
            methodGetEditResPlanTicketPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetEditResPlanTicket) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetEditResPlanTicket_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetEditResPlanTicketPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetEditResPlanTicket, Fixture, methodGetEditResPlanTicketPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetEditResPlanTicketPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetEditResPlanTicket) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetEditResPlanTicket_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetEditResPlanTicketPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetEditResPlanTicket, Fixture, methodGetEditResPlanTicketPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetEditResPlanTicketPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetEditResPlanTicket) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetEditResPlanTicket_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetEditResPlanTicket, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetEditResPlanTicket) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetEditResPlanTicket_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetEditResPlanTicket, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTotalsGridChartData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPAData_GetTotalsGridChartData_Method_Call_Internally(Type[] types)
        {
            var methodGetTotalsGridChartDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetTotalsGridChartData, Fixture, methodGetTotalsGridChartDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTotalsGridChartData) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetTotalsGridChartData_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _rPADataInstance.GetTotalsGridChartData();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetTotalsGridChartData) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetTotalsGridChartData_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetTotalsGridChartDataPrametersTypes = null;
            object[] parametersOfGetTotalsGridChartData = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTotalsGridChartData, methodGetTotalsGridChartDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_rPADataInstanceFixture, parametersOfGetTotalsGridChartData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTotalsGridChartData.ShouldBeNull();
            methodGetTotalsGridChartDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTotalsGridChartData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetTotalsGridChartData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetTotalsGridChartDataPrametersTypes = null;
            object[] parametersOfGetTotalsGridChartData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RPAData, string>(_rPADataInstance, MethodGetTotalsGridChartData, parametersOfGetTotalsGridChartData, methodGetTotalsGridChartDataPrametersTypes);

            // Assert
            parametersOfGetTotalsGridChartData.ShouldBeNull();
            methodGetTotalsGridChartDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTotalsGridChartData) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetTotalsGridChartData_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetTotalsGridChartDataPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetTotalsGridChartData, Fixture, methodGetTotalsGridChartDataPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetTotalsGridChartDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTotalsGridChartData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetTotalsGridChartData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetTotalsGridChartDataPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rPADataInstance, MethodGetTotalsGridChartData, Fixture, methodGetTotalsGridChartDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTotalsGridChartDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTotalsGridChartData) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPAData_GetTotalsGridChartData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTotalsGridChartData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_rPADataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}