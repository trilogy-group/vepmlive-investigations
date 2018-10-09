using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace ModelDataCache
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="ModelDataCache.ModelCache" />)
    ///     and namespace <see cref="ModelDataCache"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class ModelCacheTest : AbstractBaseSetupTypedTest<ModelCache>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ModelCache) Initializer

        private const string MethodInitalLoadData = "InitalLoadData";
        private const string MethodAllPIsPresent = "AllPIsPresent";
        private const string MethodLoadScenarioData = "LoadScenarioData";
        private const string MethodLoadTargetData = "LoadTargetData";
        private const string MethodGrabModelInfo = "GrabModelInfo";
        private const string MethodGrabViewsAndStatus = "GrabViewsAndStatus";
        private const string MethodReadPeriods = "ReadPeriods";
        private const string MethodReadCatItems = "ReadCatItems";
        private const string MethodReadCustomFields = "ReadCustomFields";
        private const string MethodReadCostTypeNames = "ReadCostTypeNames";
        private const string MethodCheckVersionSecurity = "CheckVersionSecurity";
        private const string MethodReadModelNames = "ReadModelNames";
        private const string MethodReadStages = "ReadStages";
        private const string MethodReadExtraPifields = "ReadExtraPifields";
        private const string MethodUpdateFieldsRelatedToFieldId = "UpdateFieldsRelatedToFieldId";
        private const string MethodStripNum = "StripNum";
        private const string MethodMyFormat = "MyFormat";
        private const string MethodReadPILevelData = "ReadPILevelData";
        private const string MethodReadCostCustomFieldsAndData = "ReadCostCustomFieldsAndData";
        private const string MethodReadBudgetBands = "ReadBudgetBands";
        private const string MethodReadModelTargets = "ReadModelTargets";
        private const string MethodReadRateTable = "ReadRateTable";
        private const string MethodLoadScenarios = "LoadScenarios";
        private const string MethodLoadTargets = "LoadTargets";
        private const string MethodApplyUserOptions = "ApplyUserOptions";
        private const string MethodLoadAnyScenarios = "LoadAnyScenarios";
        private const string MethodStashRateCache = "StashRateCache";
        private const string MethodBuildCustomFilterLists = "BuildCustomFilterLists";
        private const string MethodAddTotalEntry = "AddTotalEntry";
        private const string MethodAddColEntry = "AddColEntry";
        private const string MethodDoSnGStuff = "DoSnGStuff";
        private const string MethodSortCollection = "SortCollection";
        private const string MethodConCatCollection = "ConCatCollection";
        private const string MethodSetHighlevelFilterFlag = "SetHighlevelFilterFlag";
        private const string MethodGetShortCatUID = "GetShortCatUID";
        private const string MethodGetLookUpString = "GetLookUpString";
        private const string MethodPerformCalcs = "PerformCalcs";
        private const string MethodProcessAndCreateDistplayLists = "ProcessAndCreateDistplayLists";
        private const string MethodBuildTotalsKey = "BuildTotalsKey";
        private const string MethodGetDetFieldValue = "GetDetFieldValue";
        private const string MethodSetTotalDetFieldValue = "SetTotalDetFieldValue";
        private const string MethodCopyOverTotFields = "CopyOverTotFields";
        private const string MethodSortAndGroupCollection = "SortAndGroupCollection";
        private const string MethodRollUp = "RollUp";
        private const string MethodGetTopGrid = "GetTopGrid";
        private const string MethodGetTopGridLayout = "GetTopGridLayout";
        private const string MethodGetTopGridData = "GetTopGridData";
        private const string MethodGetBottomGrid = "GetBottomGrid";
        private const string MethodGetBottomGridLayout = "GetBottomGridLayout";
        private const string MethodGetBottomGridData = "GetBottomGridData";
        private const string MethodSetFTEMode = "SetFTEMode";
        private const string MethodGetFTEMode = "GetFTEMode";
        private const string MethodSetGanttMode = "SetGanttMode";
        private const string MethodDoSetGroupingFlag = "DoSetGroupingFlag";
        private const string MethodProcessTotals = "ProcessTotals";
        private const string MethodCreatePsuedoTarget = "CreatePsuedoTarget";
        private const string MethodProcessTargets = "ProcessTargets";
        private const string MethodSetSelectedForRow = "SetSelectedForRow";
        private const string MethodDoBarMove = "DoBarMove";
        private const string MethodDoCopyVersion = "DoCopyVersion";
        private const string MethodGetFilterGridLayout = "GetFilterGridLayout";
        private const string MethodGetFilterGridData = "GetFilterGridData";
        private const string MethodSetFilterData = "SetFilterData";
        private const string MethodIsFiltered = "IsFiltered";
        private const string MethodGetTotalGridLayout = "GetTotalGridLayout";
        private const string MethodGetCTCmpGridData = "GetCTCmpGridData";
        private const string MethodSetCTCmpData = "SetCTCmpData";
        private const string MethodGetTotalGridData = "GetTotalGridData";
        private const string MethodSetTotColsbasedonTotaling = "SetTotColsbasedonTotaling";
        private const string MethodSetTotalData = "SetTotalData";
        private const string MethodGetSortAndGroup = "GetSortAndGroup";
        private const string MethodSetSortAndGroup = "SetSortAndGroup";
        private const string MethodFormatExtraSort = "FormatExtraSort";
        private const string MethodFormatExtraDisplay = "FormatExtraDisplay";
        private const string MethodFormatWork = "FormatWork";
        private const string MethodFormatDuration = "FormatDuration";
        private const string MethodGetColumnGridData = "GetColumnGridData";
        private const string MethodGetColumnData = "GetColumnData";
        private const string MethodSetColumnOrderData = "SetColumnOrderData";
        private const string MethodGetVersionsPILists = "GetVersionsPILists";
        private const string MethodGetSaveVersions = "GetSaveVersions";
        private const string MethodGetTargets = "GetTargets";
        private const string MethodSaveVersion = "SaveVersion";
        private const string MethodGetPeriodsandVersions = "GetPeriodsandVersions";
        private const string MethodSetPeriodsandVersions = "SetPeriodsandVersions";
        private const string MethodDeleteTarget = "DeleteTarget";
        private const string MethodPrepareText = "PrepareText";
        private const string MethodCreateTarget = "CreateTarget";
        private const string MethodBuildCatJSon = "BuildCatJSon";
        private const string MethodRatesAndCategory = "RatesAndCategory";
        private const string MethodPrepareTargetData = "PrepareTargetData";
        private const string MethodLoadVersionTargetData = "LoadVersionTargetData";
        private const string MethodBuildTargetKey = "BuildTargetKey";
        private const string MethodGetTargetGridLayout = "GetTargetGridLayout";
        private const string MethodGetTargetGridData = "GetTargetGridData";
        private const string MethodSaveTargetData = "SaveTargetData";
        private const string MethodSetShowRemainingFlag = "SetShowRemainingFlag";
        private const string MethodGetLegendGridLayout = "GetLegendGridLayout";
        private const string MethodGetLegendGridData = "GetLegendGridData";
        private const string MethodLoadUserViewData = "LoadUserViewData";
        private const string MethodDeleteUserViewData = "DeleteUserViewData";
        private const string MethodRenameUserViewData = "RenameUserViewData";
        private const string MethodSaveUserViewData = "SaveUserViewData";
        private const string MethodGetUserViewSlug = "GetUserViewSlug";
        private const string MethodLoadUserViews = "LoadUserViews";
        private const string MethodSelectUserViewData = "SelectUserViewData";
        private const string MethodGetCmpString = "GetCmpString";
        private const string FieldEPK_FTYPE_DATE = "EPK_FTYPE_DATE";
        private const string FieldEPK_FTYPE_INTEGER = "EPK_FTYPE_INTEGER";
        private const string FieldEPK_FTYPE_NUMBER = "EPK_FTYPE_NUMBER";
        private const string FieldEPK_FTYPE_CODE = "EPK_FTYPE_CODE";
        private const string FieldEPK_FTYPE_URL = "EPK_FTYPE_URL";
        private const string FieldEPK_FTYPE_RES = "EPK_FTYPE_RES";
        private const string FieldEPK_FTYPE_CURRENCY = "EPK_FTYPE_CURRENCY";
        private const string FieldEPK_FTYPE_TEXT = "EPK_FTYPE_TEXT";
        private const string FieldEPK_FTYPE_PERCENT = "EPK_FTYPE_PERCENT";
        private const string FieldEPK_FTYPE_YESNO = "EPK_FTYPE_YESNO";
        private const string FieldEPK_FTYPE_RTF = "EPK_FTYPE_RTF";
        private const string FieldEPK_FTYPE_WORK = "EPK_FTYPE_WORK";
        private const string FieldEPK_FTYPE_DURATION = "EPK_FTYPE_DURATION";
        private const string FieldEPK_FTYPE_OWNER = "EPK_FTYPE_OWNER";
        private const string FieldCONST_CURRENT = "CONST_CURRENT";
        private const string Fieldm_sTicket = "m_sTicket";
        private const string Fieldm_sModel = "m_sModel";
        private const string Fieldm_GotAllPIs = "m_GotAllPIs";
        private const string Fieldm_PI_Count = "m_PI_Count";
        private const string Fieldm_lowlevelDataCount = "m_lowlevelDataCount";
        private const string Fieldm_loaddatareturn = "m_loaddatareturn";
        private const string Fieldm_loadmsg = "m_loadmsg";
        private const string Fieldm_sPids = "m_sPids";
        private const string Fieldm_Selected_Table = "m_Selected_Table";
        private const string Fieldm_Select_FieldName = "m_Select_FieldName";
        private const string Fieldm_CB_ID = "m_CB_ID";
        private const string Fieldm_SelFID = "m_SelFID";
        private const string Fieldm_sCostTypes = "m_sCostTypes";
        private const string Fieldm_sOtherCostTypes = "m_sOtherCostTypes";
        private const string Fieldm_sCalcCostTypes = "m_sCalcCostTypes";
        private const string Fieldm_PI_Group = "m_PI_Group";
        private const string Fieldm_PI_Group_fid = "m_PI_Group_fid";
        private const string Fieldm_PI_Seq = "m_PI_Seq";
        private const string Fieldm_PI_Seq_fid = "m_PI_Seq_fid";
        private const string Fieldm_pi_top = "m_pi_top";
        private const string Fieldm_CT_Views = "m_CT_Views";
        private const string Fieldm_Periods = "m_Periods";
        private const string Fieldmaxp = "maxp";
        private const string Fieldm_statdate = "m_statdate";
        private const string Fieldm_status_period = "m_status_period";
        private const string Fieldperind = "perind";
        private const string Fieldpersta = "persta";
        private const string Fieldperfin = "perfin";
        private const string Fieldm_PeriodMode = "m_PeriodMode";
        private const string Fieldm_max_period = "m_max_period";
        private const string Fieldm_CostCat = "m_CostCat";
        private const string Fieldm_CostCat_rolly = "m_CostCat_rolly";
        private const string Fieldm_Role_CC = "m_Role_CC";
        private const string Fieldm_CustFields = "m_CustFields";
        private const string Fieldm_CustAttribs = "m_CustAttribs";
        private const string Fieldm_CostTypes = "m_CostTypes";
        private const string Fieldm_Scenario = "m_Scenario";
        private const string Fieldm_stages = "m_stages";
        private const string Fieldm_sextra = "m_sextra";
        private const string Fieldm_ExtraFieldNames = "m_ExtraFieldNames";
        private const string Fieldm_fidextra = "m_fidextra";
        private const string Fieldm_ExtraFieldTypes = "m_ExtraFieldTypes";
        private const string Fieldm_Use_extra = "m_Use_extra";
        private const string Fieldm_PIs = "m_PIs";
        private const string Fieldm_codes = "m_codes";
        private const string Fieldm_reses = "m_reses";
        private const string Fieldm_detaildata = "m_detaildata";
        private const string Fieldm_targetdata = "m_targetdata";
        private const string Fieldm_TargetColours = "m_TargetColours";
        private const string Fieldm_Target = "m_Target";
        private const string Fieldm_AssignableCTS = "m_AssignableCTS";
        private const string Fieldm_Rates = "m_Rates";
        private const string Fieldm_ratecache = "m_ratecache";
        private const string Fieldm_display_minp = "m_display_minp";
        private const string Fieldm_drag_minp = "m_drag_minp";
        private const string Fieldm_cust_Defn = "m_cust_Defn";
        private const string Fieldm_cust_full = "m_cust_full";
        private const string Fieldm_cust_ocf = "m_cust_ocf";
        private const string Fieldm_cust_lk = "m_cust_lk";
        private const string Fieldm_filter_sel = "m_filter_sel";
        private const string Fieldm_allow_grouping = "m_allow_grouping";
        private const string Fieldm_grouping_enabled = "m_grouping_enabled";
        private const string Fieldm_CT_List = "m_CT_List";
        private const string Fieldm_BC_List = "m_BC_List";
        private const string Fieldm_BC_Role_List = "m_BC_Role_List";
        private const string Fieldm_filtersource = "m_filtersource";
        private const string Fieldm_tgrid_sorted = "m_tgrid_sorted";
        private const string Fieldm_tgrid_displayed = "m_tgrid_displayed";
        private const string Fieldm_bgrid_sorted = "m_bgrid_sorted";
        private const string Fieldm_target_sorted = "m_target_sorted";
        private const string Fieldm_Det_grouped = "m_Det_grouped";
        private const string Fieldm_filterList = "m_filterList";
        private const string Fieldm_filterRoot = "m_filterRoot";
        private const string Fieldm_selcln = "m_selcln";
        private const string Fieldm_TotalRoot = "m_TotalRoot";
        private const string Fieldm_CTARoot = "m_CTARoot";
        private const string Fieldm_DetColRoot = "m_DetColRoot";
        private const string Fieldm_TotColRoot = "m_TotColRoot";
        private const string Fieldm_DetFreeze = "m_DetFreeze";
        private const string Fieldm_apply_target = "m_apply_target";
        private const string Fieldm_total_dets = "m_total_dets";
        private const string Fieldm_list_total_dets = "m_list_total_dets";
        private const string Fieldm_SnGFids = "m_SnGFids";
        private const string Fieldm_SnGGrp = "m_SnGGrp";
        private const string Fieldm_SnGAsc = "m_SnGAsc";
        private const string Fieldm_DetFields = "m_DetFields";
        private const string Fieldbottomgridlayoutcache = "bottomgridlayoutcache";
        private const string FieldbShowFTEs = "bShowFTEs";
        private const string FieldbShowGantt = "bShowGantt";
        private const string Fieldm_dtMin = "m_dtMin";
        private const string Fieldm_detShowToLevel = "m_detShowToLevel";
        private const string Fieldm_CostCatjsonMenu = "m_CostCatjsonMenu";
        private const string Fieldm_CostTypejsonMenu = "m_CostTypejsonMenu";
        private const string Fieldm_editTargetList = "m_editTargetList";
        private const string Fieldm_bCTAMode = "m_bCTAMode";
        private const string Fieldm_mode = "m_mode";
        private const string Fieldm_ShowRemaining = "m_ShowRemaining";
        private const string Fieldm_WResID = "m_WResID";
        private const string Fieldm_show_rhs_dec_costs = "m_show_rhs_dec_costs";
        private const string Fieldm_init_def_view = "m_init_def_view";
        private const string Fieldm_init_def_view_pos = "m_init_def_view_pos";
        private const string Fieldm_tarnames = "m_tarnames";
        private const string Fieldm_initial_zoom = "m_initial_zoom";
        private Type _modelCacheInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ModelCache _modelCacheInstance;
        private ModelCache _modelCacheInstanceFixture;

        #region General Initializer : Class (ModelCache) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ModelCache" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _modelCacheInstanceType = typeof(ModelCache);
            _modelCacheInstanceFixture = Create(true);
            _modelCacheInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ModelCache)

        #region General Initializer : Class (ModelCache) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ModelCache" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodInitalLoadData, 0)]
        [TestCase(MethodAllPIsPresent, 0)]
        [TestCase(MethodLoadScenarioData, 0)]
        [TestCase(MethodLoadTargetData, 0)]
        [TestCase(MethodGrabModelInfo, 0)]
        [TestCase(MethodGrabViewsAndStatus, 0)]
        [TestCase(MethodReadPeriods, 0)]
        [TestCase(MethodReadCatItems, 0)]
        [TestCase(MethodReadCustomFields, 0)]
        [TestCase(MethodReadCostTypeNames, 0)]
        [TestCase(MethodCheckVersionSecurity, 0)]
        [TestCase(MethodReadModelNames, 0)]
        [TestCase(MethodReadStages, 0)]
        [TestCase(MethodReadExtraPifields, 0)]
        [TestCase(MethodStripNum, 0)]
        [TestCase(MethodMyFormat, 0)]
        [TestCase(MethodReadPILevelData, 0)]
        [TestCase(MethodReadCostCustomFieldsAndData, 0)]
        [TestCase(MethodReadBudgetBands, 0)]
        [TestCase(MethodReadModelTargets, 0)]
        [TestCase(MethodReadRateTable, 0)]
        [TestCase(MethodLoadScenarios, 0)]
        [TestCase(MethodLoadTargets, 0)]
        [TestCase(MethodApplyUserOptions, 0)]
        [TestCase(MethodLoadAnyScenarios, 0)]
        [TestCase(MethodStashRateCache, 0)]
        [TestCase(MethodBuildCustomFilterLists, 0)]
        [TestCase(MethodAddTotalEntry, 0)]
        [TestCase(MethodAddColEntry, 0)]
        [TestCase(MethodDoSnGStuff, 0)]
        [TestCase(MethodSortCollection, 0)]
        [TestCase(MethodConCatCollection, 0)]
        [TestCase(MethodSetHighlevelFilterFlag, 0)]
        [TestCase(MethodGetShortCatUID, 0)]
        [TestCase(MethodGetLookUpString, 0)]
        [TestCase(MethodPerformCalcs, 0)]
        [TestCase(MethodProcessAndCreateDistplayLists, 0)]
        [TestCase(MethodBuildTotalsKey, 0)]
        [TestCase(MethodGetDetFieldValue, 0)]
        [TestCase(MethodSetTotalDetFieldValue, 0)]
        [TestCase(MethodCopyOverTotFields, 0)]
        [TestCase(MethodSortAndGroupCollection, 0)]
        [TestCase(MethodRollUp, 0)]
        [TestCase(MethodGetTopGrid, 0)]
        [TestCase(MethodGetTopGridLayout, 0)]
        [TestCase(MethodGetTopGridData, 0)]
        [TestCase(MethodGetBottomGrid, 0)]
        [TestCase(MethodGetBottomGridLayout, 0)]
        [TestCase(MethodGetBottomGridData, 0)]
        [TestCase(MethodSetFTEMode, 0)]
        [TestCase(MethodGetFTEMode, 0)]
        [TestCase(MethodSetGanttMode, 0)]
        [TestCase(MethodDoSetGroupingFlag, 0)]
        [TestCase(MethodProcessTotals, 0)]
        [TestCase(MethodCreatePsuedoTarget, 0)]
        [TestCase(MethodProcessTargets, 0)]
        [TestCase(MethodSetSelectedForRow, 0)]
        [TestCase(MethodDoBarMove, 0)]
        [TestCase(MethodDoCopyVersion, 0)]
        [TestCase(MethodGetFilterGridLayout, 0)]
        [TestCase(MethodGetFilterGridData, 0)]
        [TestCase(MethodSetFilterData, 0)]
        [TestCase(MethodIsFiltered, 0)]
        [TestCase(MethodGetTotalGridLayout, 0)]
        [TestCase(MethodGetCTCmpGridData, 0)]
        [TestCase(MethodSetCTCmpData, 0)]
        [TestCase(MethodGetTotalGridData, 0)]
        [TestCase(MethodSetTotColsbasedonTotaling, 0)]
        [TestCase(MethodSetTotalData, 0)]
        [TestCase(MethodGetSortAndGroup, 0)]
        [TestCase(MethodSetSortAndGroup, 0)]
        [TestCase(MethodFormatExtraSort, 0)]
        [TestCase(MethodFormatExtraDisplay, 0)]
        [TestCase(MethodFormatWork, 0)]
        [TestCase(MethodFormatDuration, 0)]
        [TestCase(MethodGetColumnGridData, 0)]
        [TestCase(MethodGetColumnData, 0)]
        [TestCase(MethodSetColumnOrderData, 0)]
        [TestCase(MethodGetVersionsPILists, 0)]
        [TestCase(MethodGetSaveVersions, 0)]
        [TestCase(MethodGetTargets, 0)]
        [TestCase(MethodSaveVersion, 0)]
        [TestCase(MethodGetPeriodsandVersions, 0)]
        [TestCase(MethodSetPeriodsandVersions, 0)]
        [TestCase(MethodDeleteTarget, 0)]
        [TestCase(MethodPrepareText, 0)]
        [TestCase(MethodCreateTarget, 0)]
        [TestCase(MethodBuildCatJSon, 0)]
        [TestCase(MethodRatesAndCategory, 0)]
        [TestCase(MethodPrepareTargetData, 0)]
        [TestCase(MethodLoadVersionTargetData, 0)]
        [TestCase(MethodBuildTargetKey, 0)]
        [TestCase(MethodGetTargetGridLayout, 0)]
        [TestCase(MethodGetTargetGridData, 0)]
        [TestCase(MethodSaveTargetData, 0)]
        [TestCase(MethodSetShowRemainingFlag, 0)]
        [TestCase(MethodGetLegendGridLayout, 0)]
        [TestCase(MethodGetLegendGridData, 0)]
        [TestCase(MethodLoadUserViewData, 0)]
        [TestCase(MethodDeleteUserViewData, 0)]
        [TestCase(MethodRenameUserViewData, 0)]
        [TestCase(MethodSaveUserViewData, 0)]
        [TestCase(MethodGetUserViewSlug, 0)]
        [TestCase(MethodLoadUserViews, 0)]
        [TestCase(MethodSelectUserViewData, 0)]
        [TestCase(MethodGetCmpString, 0)]
        public void AUT_ModelCache_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_modelCacheInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ModelCache) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ModelCache" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldEPK_FTYPE_DATE)]
        [TestCase(FieldEPK_FTYPE_INTEGER)]
        [TestCase(FieldEPK_FTYPE_NUMBER)]
        [TestCase(FieldEPK_FTYPE_CODE)]
        [TestCase(FieldEPK_FTYPE_URL)]
        [TestCase(FieldEPK_FTYPE_RES)]
        [TestCase(FieldEPK_FTYPE_CURRENCY)]
        [TestCase(FieldEPK_FTYPE_TEXT)]
        [TestCase(FieldEPK_FTYPE_PERCENT)]
        [TestCase(FieldEPK_FTYPE_YESNO)]
        [TestCase(FieldEPK_FTYPE_RTF)]
        [TestCase(FieldEPK_FTYPE_WORK)]
        [TestCase(FieldEPK_FTYPE_DURATION)]
        [TestCase(FieldEPK_FTYPE_OWNER)]
        [TestCase(FieldCONST_CURRENT)]
        [TestCase(Fieldm_sTicket)]
        [TestCase(Fieldm_sModel)]
        [TestCase(Fieldm_GotAllPIs)]
        [TestCase(Fieldm_PI_Count)]
        [TestCase(Fieldm_lowlevelDataCount)]
        [TestCase(Fieldm_loaddatareturn)]
        [TestCase(Fieldm_loadmsg)]
        [TestCase(Fieldm_sPids)]
        [TestCase(Fieldm_Selected_Table)]
        [TestCase(Fieldm_Select_FieldName)]
        [TestCase(Fieldm_CB_ID)]
        [TestCase(Fieldm_SelFID)]
        [TestCase(Fieldm_sCostTypes)]
        [TestCase(Fieldm_sOtherCostTypes)]
        [TestCase(Fieldm_sCalcCostTypes)]
        [TestCase(Fieldm_PI_Group)]
        [TestCase(Fieldm_PI_Group_fid)]
        [TestCase(Fieldm_PI_Seq)]
        [TestCase(Fieldm_PI_Seq_fid)]
        [TestCase(Fieldm_pi_top)]
        [TestCase(Fieldm_CT_Views)]
        [TestCase(Fieldm_Periods)]
        [TestCase(Fieldmaxp)]
        [TestCase(Fieldm_statdate)]
        [TestCase(Fieldm_status_period)]
        [TestCase(Fieldperind)]
        [TestCase(Fieldpersta)]
        [TestCase(Fieldperfin)]
        [TestCase(Fieldm_PeriodMode)]
        [TestCase(Fieldm_max_period)]
        [TestCase(Fieldm_CostCat)]
        [TestCase(Fieldm_CostCat_rolly)]
        [TestCase(Fieldm_Role_CC)]
        [TestCase(Fieldm_CustFields)]
        [TestCase(Fieldm_CustAttribs)]
        [TestCase(Fieldm_CostTypes)]
        [TestCase(Fieldm_Scenario)]
        [TestCase(Fieldm_stages)]
        [TestCase(Fieldm_sextra)]
        [TestCase(Fieldm_ExtraFieldNames)]
        [TestCase(Fieldm_fidextra)]
        [TestCase(Fieldm_ExtraFieldTypes)]
        [TestCase(Fieldm_Use_extra)]
        [TestCase(Fieldm_PIs)]
        [TestCase(Fieldm_codes)]
        [TestCase(Fieldm_reses)]
        [TestCase(Fieldm_detaildata)]
        [TestCase(Fieldm_targetdata)]
        [TestCase(Fieldm_TargetColours)]
        [TestCase(Fieldm_Target)]
        [TestCase(Fieldm_AssignableCTS)]
        [TestCase(Fieldm_Rates)]
        [TestCase(Fieldm_ratecache)]
        [TestCase(Fieldm_display_minp)]
        [TestCase(Fieldm_drag_minp)]
        [TestCase(Fieldm_cust_Defn)]
        [TestCase(Fieldm_cust_full)]
        [TestCase(Fieldm_cust_ocf)]
        [TestCase(Fieldm_cust_lk)]
        [TestCase(Fieldm_filter_sel)]
        [TestCase(Fieldm_allow_grouping)]
        [TestCase(Fieldm_grouping_enabled)]
        [TestCase(Fieldm_CT_List)]
        [TestCase(Fieldm_BC_List)]
        [TestCase(Fieldm_BC_Role_List)]
        [TestCase(Fieldm_filtersource)]
        [TestCase(Fieldm_tgrid_sorted)]
        [TestCase(Fieldm_tgrid_displayed)]
        [TestCase(Fieldm_bgrid_sorted)]
        [TestCase(Fieldm_target_sorted)]
        [TestCase(Fieldm_Det_grouped)]
        [TestCase(Fieldm_filterList)]
        [TestCase(Fieldm_filterRoot)]
        [TestCase(Fieldm_selcln)]
        [TestCase(Fieldm_TotalRoot)]
        [TestCase(Fieldm_CTARoot)]
        [TestCase(Fieldm_DetColRoot)]
        [TestCase(Fieldm_TotColRoot)]
        [TestCase(Fieldm_DetFreeze)]
        [TestCase(Fieldm_apply_target)]
        [TestCase(Fieldm_total_dets)]
        [TestCase(Fieldm_list_total_dets)]
        [TestCase(Fieldm_SnGFids)]
        [TestCase(Fieldm_SnGGrp)]
        [TestCase(Fieldm_SnGAsc)]
        [TestCase(Fieldm_DetFields)]
        [TestCase(Fieldbottomgridlayoutcache)]
        [TestCase(FieldbShowFTEs)]
        [TestCase(FieldbShowGantt)]
        [TestCase(Fieldm_dtMin)]
        [TestCase(Fieldm_detShowToLevel)]
        [TestCase(Fieldm_CostCatjsonMenu)]
        [TestCase(Fieldm_CostTypejsonMenu)]
        [TestCase(Fieldm_editTargetList)]
        [TestCase(Fieldm_bCTAMode)]
        [TestCase(Fieldm_mode)]
        [TestCase(Fieldm_ShowRemaining)]
        [TestCase(Fieldm_WResID)]
        [TestCase(Fieldm_show_rhs_dec_costs)]
        [TestCase(Fieldm_init_def_view)]
        [TestCase(Fieldm_init_def_view_pos)]
        [TestCase(Fieldm_tarnames)]
        [TestCase(Fieldm_initial_zoom)]
        public void AUT_ModelCache_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_modelCacheInstanceFixture, 
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
        ///     Class (<see cref="ModelCache" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ModelCache_Is_Instance_Present_Test()
        {
            // Assert
            _modelCacheInstanceType.ShouldNotBeNull();
            _modelCacheInstance.ShouldNotBeNull();
            _modelCacheInstanceFixture.ShouldNotBeNull();
            _modelCacheInstance.ShouldBeAssignableTo<ModelCache>();
            _modelCacheInstanceFixture.ShouldBeAssignableTo<ModelCache>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ModelCache) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ModelCache_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ModelCache instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _modelCacheInstanceType.ShouldNotBeNull();
            _modelCacheInstance.ShouldNotBeNull();
            _modelCacheInstanceFixture.ShouldNotBeNull();
            _modelCacheInstance.ShouldBeAssignableTo<ModelCache>();
            _modelCacheInstanceFixture.ShouldBeAssignableTo<ModelCache>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ModelCache" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodInitalLoadData)]
        [TestCase(MethodAllPIsPresent)]
        [TestCase(MethodLoadScenarioData)]
        [TestCase(MethodLoadTargetData)]
        [TestCase(MethodGrabModelInfo)]
        [TestCase(MethodGrabViewsAndStatus)]
        [TestCase(MethodReadPeriods)]
        [TestCase(MethodReadCatItems)]
        [TestCase(MethodReadCustomFields)]
        [TestCase(MethodReadCostTypeNames)]
        [TestCase(MethodCheckVersionSecurity)]
        [TestCase(MethodReadModelNames)]
        [TestCase(MethodReadStages)]
        [TestCase(MethodReadExtraPifields)]
        [TestCase(MethodStripNum)]
        [TestCase(MethodMyFormat)]
        [TestCase(MethodReadPILevelData)]
        [TestCase(MethodReadCostCustomFieldsAndData)]
        [TestCase(MethodReadBudgetBands)]
        [TestCase(MethodReadModelTargets)]
        [TestCase(MethodReadRateTable)]
        [TestCase(MethodLoadScenarios)]
        [TestCase(MethodLoadTargets)]
        [TestCase(MethodApplyUserOptions)]
        [TestCase(MethodLoadAnyScenarios)]
        [TestCase(MethodStashRateCache)]
        [TestCase(MethodBuildCustomFilterLists)]
        [TestCase(MethodAddTotalEntry)]
        [TestCase(MethodAddColEntry)]
        [TestCase(MethodDoSnGStuff)]
        [TestCase(MethodSortCollection)]
        [TestCase(MethodConCatCollection)]
        [TestCase(MethodSetHighlevelFilterFlag)]
        [TestCase(MethodGetShortCatUID)]
        [TestCase(MethodGetLookUpString)]
        [TestCase(MethodPerformCalcs)]
        [TestCase(MethodProcessAndCreateDistplayLists)]
        [TestCase(MethodBuildTotalsKey)]
        [TestCase(MethodGetDetFieldValue)]
        [TestCase(MethodSetTotalDetFieldValue)]
        [TestCase(MethodCopyOverTotFields)]
        [TestCase(MethodSortAndGroupCollection)]
        [TestCase(MethodRollUp)]
        [TestCase(MethodGetTopGrid)]
        [TestCase(MethodGetTopGridLayout)]
        [TestCase(MethodGetTopGridData)]
        [TestCase(MethodGetBottomGrid)]
        [TestCase(MethodGetBottomGridLayout)]
        [TestCase(MethodGetBottomGridData)]
        [TestCase(MethodSetFTEMode)]
        [TestCase(MethodGetFTEMode)]
        [TestCase(MethodSetGanttMode)]
        [TestCase(MethodDoSetGroupingFlag)]
        [TestCase(MethodProcessTotals)]
        [TestCase(MethodCreatePsuedoTarget)]
        [TestCase(MethodProcessTargets)]
        [TestCase(MethodSetSelectedForRow)]
        [TestCase(MethodDoBarMove)]
        [TestCase(MethodDoCopyVersion)]
        [TestCase(MethodGetFilterGridLayout)]
        [TestCase(MethodGetFilterGridData)]
        [TestCase(MethodSetFilterData)]
        [TestCase(MethodIsFiltered)]
        [TestCase(MethodGetTotalGridLayout)]
        [TestCase(MethodGetCTCmpGridData)]
        [TestCase(MethodSetCTCmpData)]
        [TestCase(MethodGetTotalGridData)]
        [TestCase(MethodSetTotColsbasedonTotaling)]
        [TestCase(MethodSetTotalData)]
        [TestCase(MethodGetSortAndGroup)]
        [TestCase(MethodSetSortAndGroup)]
        [TestCase(MethodFormatExtraSort)]
        [TestCase(MethodFormatExtraDisplay)]
        [TestCase(MethodFormatWork)]
        [TestCase(MethodFormatDuration)]
        [TestCase(MethodGetColumnGridData)]
        [TestCase(MethodGetColumnData)]
        [TestCase(MethodSetColumnOrderData)]
        [TestCase(MethodGetVersionsPILists)]
        [TestCase(MethodGetSaveVersions)]
        [TestCase(MethodGetTargets)]
        [TestCase(MethodSaveVersion)]
        [TestCase(MethodGetPeriodsandVersions)]
        [TestCase(MethodSetPeriodsandVersions)]
        [TestCase(MethodDeleteTarget)]
        [TestCase(MethodPrepareText)]
        [TestCase(MethodCreateTarget)]
        [TestCase(MethodBuildCatJSon)]
        [TestCase(MethodRatesAndCategory)]
        [TestCase(MethodPrepareTargetData)]
        [TestCase(MethodLoadVersionTargetData)]
        [TestCase(MethodBuildTargetKey)]
        [TestCase(MethodGetTargetGridLayout)]
        [TestCase(MethodGetTargetGridData)]
        [TestCase(MethodSaveTargetData)]
        [TestCase(MethodSetShowRemainingFlag)]
        [TestCase(MethodGetLegendGridLayout)]
        [TestCase(MethodGetLegendGridData)]
        [TestCase(MethodLoadUserViewData)]
        [TestCase(MethodDeleteUserViewData)]
        [TestCase(MethodRenameUserViewData)]
        [TestCase(MethodSaveUserViewData)]
        [TestCase(MethodGetUserViewSlug)]
        [TestCase(MethodLoadUserViews)]
        [TestCase(MethodSelectUserViewData)]
        [TestCase(MethodGetCmpString)]
        public void AUT_ModelCache_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ModelCache>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (InitalLoadData) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_InitalLoadData_Method_Call_Internally(Type[] types)
        {
            var methodInitalLoadDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodInitalLoadData, Fixture, methodInitalLoadDataPrametersTypes);
        }

        #endregion

        #region Method Call : (InitalLoadData) (Return Type : int) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_InitalLoadData_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var ticket = CreateType<string>();
            var model = CreateType<string>();
            var versions = CreateType<string>();
            var sWResID = CreateType<string>();
            var sViewID = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.InitalLoadData(oDataAccess, ticket, model, versions, sWResID, sViewID);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (InitalLoadData) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_InitalLoadData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var ticket = CreateType<string>();
            var model = CreateType<string>();
            var versions = CreateType<string>();
            var sWResID = CreateType<string>();
            var sViewID = CreateType<string>();
            var methodInitalLoadDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfInitalLoadData = { oDataAccess, ticket, model, versions, sWResID, sViewID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInitalLoadData, methodInitalLoadDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ModelCache, int>(_modelCacheInstanceFixture, out exception1, parametersOfInitalLoadData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ModelCache, int>(_modelCacheInstance, MethodInitalLoadData, parametersOfInitalLoadData, methodInitalLoadDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfInitalLoadData.ShouldNotBeNull();
            parametersOfInitalLoadData.Length.ShouldBe(6);
            methodInitalLoadDataPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (InitalLoadData) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_InitalLoadData_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var ticket = CreateType<string>();
            var model = CreateType<string>();
            var versions = CreateType<string>();
            var sWResID = CreateType<string>();
            var sViewID = CreateType<string>();
            var methodInitalLoadDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfInitalLoadData = { oDataAccess, ticket, model, versions, sWResID, sViewID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInitalLoadData, methodInitalLoadDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ModelCache, int>(_modelCacheInstanceFixture, out exception1, parametersOfInitalLoadData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ModelCache, int>(_modelCacheInstance, MethodInitalLoadData, parametersOfInitalLoadData, methodInitalLoadDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfInitalLoadData.ShouldNotBeNull();
            parametersOfInitalLoadData.Length.ShouldBe(6);
            methodInitalLoadDataPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (InitalLoadData) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_InitalLoadData_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var ticket = CreateType<string>();
            var model = CreateType<string>();
            var versions = CreateType<string>();
            var sWResID = CreateType<string>();
            var sViewID = CreateType<string>();
            var methodInitalLoadDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfInitalLoadData = { oDataAccess, ticket, model, versions, sWResID, sViewID };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitalLoadData, methodInitalLoadDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfInitalLoadData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitalLoadData.ShouldNotBeNull();
            parametersOfInitalLoadData.Length.ShouldBe(6);
            methodInitalLoadDataPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitalLoadData) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_InitalLoadData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var ticket = CreateType<string>();
            var model = CreateType<string>();
            var versions = CreateType<string>();
            var sWResID = CreateType<string>();
            var sViewID = CreateType<string>();
            var methodInitalLoadDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfInitalLoadData = { oDataAccess, ticket, model, versions, sWResID, sViewID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, int>(_modelCacheInstance, MethodInitalLoadData, parametersOfInitalLoadData, methodInitalLoadDataPrametersTypes);

            // Assert
            parametersOfInitalLoadData.ShouldNotBeNull();
            parametersOfInitalLoadData.Length.ShouldBe(6);
            methodInitalLoadDataPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitalLoadData) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_InitalLoadData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodInitalLoadDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodInitalLoadData, Fixture, methodInitalLoadDataPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodInitalLoadDataPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (InitalLoadData) (Return Type : int) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_InitalLoadData_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodInitalLoadDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodInitalLoadData, Fixture, methodInitalLoadDataPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodInitalLoadDataPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (InitalLoadData) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_InitalLoadData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInitalLoadDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 6;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodInitalLoadData, Fixture, methodInitalLoadDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodInitalLoadDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InitalLoadData) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_InitalLoadData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitalLoadData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (InitalLoadData) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_InitalLoadData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInitalLoadData, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AllPIsPresent) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_AllPIsPresent_Method_Call_Internally(Type[] types)
        {
            var methodAllPIsPresentPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodAllPIsPresent, Fixture, methodAllPIsPresentPrametersTypes);
        }

        #endregion

        #region Method Call : (AllPIsPresent) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_AllPIsPresent_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.AllPIsPresent();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (AllPIsPresent) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_AllPIsPresent_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodAllPIsPresentPrametersTypes = null;
            object[] parametersOfAllPIsPresent = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAllPIsPresent, methodAllPIsPresentPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ModelCache, bool>(_modelCacheInstanceFixture, out exception1, parametersOfAllPIsPresent);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ModelCache, bool>(_modelCacheInstance, MethodAllPIsPresent, parametersOfAllPIsPresent, methodAllPIsPresentPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfAllPIsPresent.ShouldBeNull();
            methodAllPIsPresentPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AllPIsPresent) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_AllPIsPresent_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodAllPIsPresentPrametersTypes = null;
            object[] parametersOfAllPIsPresent = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAllPIsPresent, methodAllPIsPresentPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ModelCache, bool>(_modelCacheInstanceFixture, out exception1, parametersOfAllPIsPresent);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ModelCache, bool>(_modelCacheInstance, MethodAllPIsPresent, parametersOfAllPIsPresent, methodAllPIsPresentPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfAllPIsPresent.ShouldBeNull();
            methodAllPIsPresentPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AllPIsPresent) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_AllPIsPresent_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodAllPIsPresentPrametersTypes = null;
            object[] parametersOfAllPIsPresent = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAllPIsPresent, methodAllPIsPresentPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfAllPIsPresent);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAllPIsPresent.ShouldBeNull();
            methodAllPIsPresentPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AllPIsPresent) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_AllPIsPresent_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodAllPIsPresentPrametersTypes = null;
            object[] parametersOfAllPIsPresent = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, bool>(_modelCacheInstance, MethodAllPIsPresent, parametersOfAllPIsPresent, methodAllPIsPresentPrametersTypes);

            // Assert
            parametersOfAllPIsPresent.ShouldBeNull();
            methodAllPIsPresentPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AllPIsPresent) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_AllPIsPresent_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodAllPIsPresentPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodAllPIsPresent, Fixture, methodAllPIsPresentPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodAllPIsPresentPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AllPIsPresent) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_AllPIsPresent_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodAllPIsPresentPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodAllPIsPresent, Fixture, methodAllPIsPresentPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodAllPIsPresentPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AllPIsPresent) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_AllPIsPresent_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodAllPIsPresentPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodAllPIsPresent, Fixture, methodAllPIsPresentPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAllPIsPresentPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AllPIsPresent) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_AllPIsPresent_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAllPIsPresent, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (LoadScenarioData) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_LoadScenarioData_Method_Call_Internally(Type[] types)
        {
            var methodLoadScenarioDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodLoadScenarioData, Fixture, methodLoadScenarioDataPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadScenarioData) (Return Type : int) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadScenarioData_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var versions = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.LoadScenarioData(oDataAccess, versions);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (LoadScenarioData) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadScenarioData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var versions = CreateType<string>();
            var methodLoadScenarioDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfLoadScenarioData = { oDataAccess, versions };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodLoadScenarioData, methodLoadScenarioDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ModelCache, int>(_modelCacheInstanceFixture, out exception1, parametersOfLoadScenarioData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ModelCache, int>(_modelCacheInstance, MethodLoadScenarioData, parametersOfLoadScenarioData, methodLoadScenarioDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfLoadScenarioData.ShouldNotBeNull();
            parametersOfLoadScenarioData.Length.ShouldBe(2);
            methodLoadScenarioDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (LoadScenarioData) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadScenarioData_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var versions = CreateType<string>();
            var methodLoadScenarioDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfLoadScenarioData = { oDataAccess, versions };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodLoadScenarioData, methodLoadScenarioDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ModelCache, int>(_modelCacheInstanceFixture, out exception1, parametersOfLoadScenarioData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ModelCache, int>(_modelCacheInstance, MethodLoadScenarioData, parametersOfLoadScenarioData, methodLoadScenarioDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfLoadScenarioData.ShouldNotBeNull();
            parametersOfLoadScenarioData.Length.ShouldBe(2);
            methodLoadScenarioDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (LoadScenarioData) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadScenarioData_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var versions = CreateType<string>();
            var methodLoadScenarioDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfLoadScenarioData = { oDataAccess, versions };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadScenarioData, methodLoadScenarioDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfLoadScenarioData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadScenarioData.ShouldNotBeNull();
            parametersOfLoadScenarioData.Length.ShouldBe(2);
            methodLoadScenarioDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadScenarioData) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadScenarioData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var versions = CreateType<string>();
            var methodLoadScenarioDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfLoadScenarioData = { oDataAccess, versions };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, int>(_modelCacheInstance, MethodLoadScenarioData, parametersOfLoadScenarioData, methodLoadScenarioDataPrametersTypes);

            // Assert
            parametersOfLoadScenarioData.ShouldNotBeNull();
            parametersOfLoadScenarioData.Length.ShouldBe(2);
            methodLoadScenarioDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadScenarioData) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadScenarioData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodLoadScenarioDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodLoadScenarioData, Fixture, methodLoadScenarioDataPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodLoadScenarioDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (LoadScenarioData) (Return Type : int) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadScenarioData_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodLoadScenarioDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodLoadScenarioData, Fixture, methodLoadScenarioDataPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodLoadScenarioDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (LoadScenarioData) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadScenarioData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLoadScenarioDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodLoadScenarioData, Fixture, methodLoadScenarioDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodLoadScenarioDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LoadScenarioData) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadScenarioData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadScenarioData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (LoadScenarioData) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadScenarioData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLoadScenarioData, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LoadTargetData) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_LoadTargetData_Method_Call_Internally(Type[] types)
        {
            var methodLoadTargetDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodLoadTargetData, Fixture, methodLoadTargetDataPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadTargetData) (Return Type : int) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadTargetData_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var targets = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.LoadTargetData(oDataAccess, targets);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (LoadTargetData) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadTargetData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var targets = CreateType<string>();
            var methodLoadTargetDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfLoadTargetData = { oDataAccess, targets };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodLoadTargetData, methodLoadTargetDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ModelCache, int>(_modelCacheInstanceFixture, out exception1, parametersOfLoadTargetData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ModelCache, int>(_modelCacheInstance, MethodLoadTargetData, parametersOfLoadTargetData, methodLoadTargetDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfLoadTargetData.ShouldNotBeNull();
            parametersOfLoadTargetData.Length.ShouldBe(2);
            methodLoadTargetDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (LoadTargetData) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadTargetData_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var targets = CreateType<string>();
            var methodLoadTargetDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfLoadTargetData = { oDataAccess, targets };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodLoadTargetData, methodLoadTargetDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ModelCache, int>(_modelCacheInstanceFixture, out exception1, parametersOfLoadTargetData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ModelCache, int>(_modelCacheInstance, MethodLoadTargetData, parametersOfLoadTargetData, methodLoadTargetDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfLoadTargetData.ShouldNotBeNull();
            parametersOfLoadTargetData.Length.ShouldBe(2);
            methodLoadTargetDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (LoadTargetData) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadTargetData_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var targets = CreateType<string>();
            var methodLoadTargetDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfLoadTargetData = { oDataAccess, targets };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadTargetData, methodLoadTargetDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfLoadTargetData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadTargetData.ShouldNotBeNull();
            parametersOfLoadTargetData.Length.ShouldBe(2);
            methodLoadTargetDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadTargetData) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadTargetData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var targets = CreateType<string>();
            var methodLoadTargetDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfLoadTargetData = { oDataAccess, targets };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, int>(_modelCacheInstance, MethodLoadTargetData, parametersOfLoadTargetData, methodLoadTargetDataPrametersTypes);

            // Assert
            parametersOfLoadTargetData.ShouldNotBeNull();
            parametersOfLoadTargetData.Length.ShouldBe(2);
            methodLoadTargetDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadTargetData) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadTargetData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodLoadTargetDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodLoadTargetData, Fixture, methodLoadTargetDataPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodLoadTargetDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (LoadTargetData) (Return Type : int) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadTargetData_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodLoadTargetDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodLoadTargetData, Fixture, methodLoadTargetDataPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodLoadTargetDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (LoadTargetData) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadTargetData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLoadTargetDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodLoadTargetData, Fixture, methodLoadTargetDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodLoadTargetDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LoadTargetData) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadTargetData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadTargetData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (LoadTargetData) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadTargetData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLoadTargetData, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GrabModelInfo) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GrabModelInfo_Method_Call_Internally(Type[] types)
        {
            var methodGrabModelInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGrabModelInfo, Fixture, methodGrabModelInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (GrabModelInfo) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GrabModelInfo_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var sModel = CreateType<string>();
            var lCB_ID = CreateType<int>();
            var lSelFID = CreateType<int>();
            var sCostTypes = CreateType<string>();
            var sOtherCostTypes = CreateType<string>();
            var methodGrabModelInfoPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(int), typeof(int), typeof(string), typeof(string) };
            object[] parametersOfGrabModelInfo = { oDataAccess, sModel, lCB_ID, lSelFID, sCostTypes, sOtherCostTypes };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGrabModelInfo, methodGrabModelInfoPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfGrabModelInfo);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGrabModelInfo.ShouldNotBeNull();
            parametersOfGrabModelInfo.Length.ShouldBe(6);
            methodGrabModelInfoPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GrabModelInfo) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GrabModelInfo_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var sModel = CreateType<string>();
            var lCB_ID = CreateType<int>();
            var lSelFID = CreateType<int>();
            var sCostTypes = CreateType<string>();
            var sOtherCostTypes = CreateType<string>();
            var methodGrabModelInfoPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(int), typeof(int), typeof(string), typeof(string) };
            object[] parametersOfGrabModelInfo = { oDataAccess, sModel, lCB_ID, lSelFID, sCostTypes, sOtherCostTypes };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, int>(_modelCacheInstance, MethodGrabModelInfo, parametersOfGrabModelInfo, methodGrabModelInfoPrametersTypes);

            // Assert
            parametersOfGrabModelInfo.ShouldNotBeNull();
            parametersOfGrabModelInfo.Length.ShouldBe(6);
            methodGrabModelInfoPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GrabModelInfo) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GrabModelInfo_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGrabModelInfoPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(int), typeof(int), typeof(string), typeof(string) };
            const int parametersCount = 6;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGrabModelInfo, Fixture, methodGrabModelInfoPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGrabModelInfoPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GrabModelInfo) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GrabModelInfo_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGrabModelInfo, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GrabModelInfo) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GrabModelInfo_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGrabModelInfo, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GrabViewsAndStatus) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GrabViewsAndStatus_Method_Call_Internally(Type[] types)
        {
            var methodGrabViewsAndStatusPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGrabViewsAndStatus, Fixture, methodGrabViewsAndStatusPrametersTypes);
        }

        #endregion

        #region Method Call : (GrabViewsAndStatus) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GrabViewsAndStatus_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var sWResID = CreateType<string>();
            var lMode = CreateType<int>();
            var methodGrabViewsAndStatusPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(int) };
            object[] parametersOfGrabViewsAndStatus = { oDataAccess, sWResID, lMode };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGrabViewsAndStatus, methodGrabViewsAndStatusPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfGrabViewsAndStatus);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGrabViewsAndStatus.ShouldNotBeNull();
            parametersOfGrabViewsAndStatus.Length.ShouldBe(3);
            methodGrabViewsAndStatusPrametersTypes.Length.ShouldBe(3);
            methodGrabViewsAndStatusPrametersTypes.Length.ShouldBe(parametersOfGrabViewsAndStatus.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GrabViewsAndStatus) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GrabViewsAndStatus_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var sWResID = CreateType<string>();
            var lMode = CreateType<int>();
            var methodGrabViewsAndStatusPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(int) };
            object[] parametersOfGrabViewsAndStatus = { oDataAccess, sWResID, lMode };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodGrabViewsAndStatus, parametersOfGrabViewsAndStatus, methodGrabViewsAndStatusPrametersTypes);

            // Assert
            parametersOfGrabViewsAndStatus.ShouldNotBeNull();
            parametersOfGrabViewsAndStatus.Length.ShouldBe(3);
            methodGrabViewsAndStatusPrametersTypes.Length.ShouldBe(3);
            methodGrabViewsAndStatusPrametersTypes.Length.ShouldBe(parametersOfGrabViewsAndStatus.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GrabViewsAndStatus) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GrabViewsAndStatus_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGrabViewsAndStatus, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GrabViewsAndStatus) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GrabViewsAndStatus_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGrabViewsAndStatusPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGrabViewsAndStatus, Fixture, methodGrabViewsAndStatusPrametersTypes);

            // Assert
            methodGrabViewsAndStatusPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GrabViewsAndStatus) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GrabViewsAndStatus_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGrabViewsAndStatus, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadPeriods) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_ReadPeriods_Method_Call_Internally(Type[] types)
        {
            var methodReadPeriodsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodReadPeriods, Fixture, methodReadPeriodsPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadPeriods) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadPeriods_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var methodReadPeriodsPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfReadPeriods = { oDataAccess };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReadPeriods, methodReadPeriodsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfReadPeriods);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReadPeriods.ShouldNotBeNull();
            parametersOfReadPeriods.Length.ShouldBe(1);
            methodReadPeriodsPrametersTypes.Length.ShouldBe(1);
            methodReadPeriodsPrametersTypes.Length.ShouldBe(parametersOfReadPeriods.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadPeriods) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadPeriods_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var methodReadPeriodsPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfReadPeriods = { oDataAccess };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodReadPeriods, parametersOfReadPeriods, methodReadPeriodsPrametersTypes);

            // Assert
            parametersOfReadPeriods.ShouldNotBeNull();
            parametersOfReadPeriods.Length.ShouldBe(1);
            methodReadPeriodsPrametersTypes.Length.ShouldBe(1);
            methodReadPeriodsPrametersTypes.Length.ShouldBe(parametersOfReadPeriods.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadPeriods) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadPeriods_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadPeriods, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadPeriods) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadPeriods_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadPeriodsPrametersTypes = new Type[] { typeof(SqlConnection) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodReadPeriods, Fixture, methodReadPeriodsPrametersTypes);

            // Assert
            methodReadPeriodsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadPeriods) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadPeriods_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadPeriods, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCatItems) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_ReadCatItems_Method_Call_Internally(Type[] types)
        {
            var methodReadCatItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodReadCatItems, Fixture, methodReadCatItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadCatItems) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadCatItems_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var methodReadCatItemsPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfReadCatItems = { oDataAccess };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReadCatItems, methodReadCatItemsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfReadCatItems);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReadCatItems.ShouldNotBeNull();
            parametersOfReadCatItems.Length.ShouldBe(1);
            methodReadCatItemsPrametersTypes.Length.ShouldBe(1);
            methodReadCatItemsPrametersTypes.Length.ShouldBe(parametersOfReadCatItems.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadCatItems) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadCatItems_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var methodReadCatItemsPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfReadCatItems = { oDataAccess };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodReadCatItems, parametersOfReadCatItems, methodReadCatItemsPrametersTypes);

            // Assert
            parametersOfReadCatItems.ShouldNotBeNull();
            parametersOfReadCatItems.Length.ShouldBe(1);
            methodReadCatItemsPrametersTypes.Length.ShouldBe(1);
            methodReadCatItemsPrametersTypes.Length.ShouldBe(parametersOfReadCatItems.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCatItems) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadCatItems_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadCatItems, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadCatItems) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadCatItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadCatItemsPrametersTypes = new Type[] { typeof(SqlConnection) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodReadCatItems, Fixture, methodReadCatItemsPrametersTypes);

            // Assert
            methodReadCatItemsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCatItems) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadCatItems_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadCatItems, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCustomFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_ReadCustomFields_Method_Call_Internally(Type[] types)
        {
            var methodReadCustomFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodReadCustomFields, Fixture, methodReadCustomFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadCustomFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadCustomFields_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var methodReadCustomFieldsPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfReadCustomFields = { oDataAccess };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReadCustomFields, methodReadCustomFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfReadCustomFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReadCustomFields.ShouldNotBeNull();
            parametersOfReadCustomFields.Length.ShouldBe(1);
            methodReadCustomFieldsPrametersTypes.Length.ShouldBe(1);
            methodReadCustomFieldsPrametersTypes.Length.ShouldBe(parametersOfReadCustomFields.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadCustomFields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadCustomFields_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var methodReadCustomFieldsPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfReadCustomFields = { oDataAccess };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodReadCustomFields, parametersOfReadCustomFields, methodReadCustomFieldsPrametersTypes);

            // Assert
            parametersOfReadCustomFields.ShouldNotBeNull();
            parametersOfReadCustomFields.Length.ShouldBe(1);
            methodReadCustomFieldsPrametersTypes.Length.ShouldBe(1);
            methodReadCustomFieldsPrametersTypes.Length.ShouldBe(parametersOfReadCustomFields.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCustomFields) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadCustomFields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadCustomFields, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadCustomFields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadCustomFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadCustomFieldsPrametersTypes = new Type[] { typeof(SqlConnection) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodReadCustomFields, Fixture, methodReadCustomFieldsPrametersTypes);

            // Assert
            methodReadCustomFieldsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCustomFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadCustomFields_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadCustomFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCostTypeNames) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_ReadCostTypeNames_Method_Call_Internally(Type[] types)
        {
            var methodReadCostTypeNamesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodReadCostTypeNames, Fixture, methodReadCostTypeNamesPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadCostTypeNames) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadCostTypeNames_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var methodReadCostTypeNamesPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfReadCostTypeNames = { oDataAccess };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReadCostTypeNames, methodReadCostTypeNamesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfReadCostTypeNames);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReadCostTypeNames.ShouldNotBeNull();
            parametersOfReadCostTypeNames.Length.ShouldBe(1);
            methodReadCostTypeNamesPrametersTypes.Length.ShouldBe(1);
            methodReadCostTypeNamesPrametersTypes.Length.ShouldBe(parametersOfReadCostTypeNames.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadCostTypeNames) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadCostTypeNames_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var methodReadCostTypeNamesPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfReadCostTypeNames = { oDataAccess };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodReadCostTypeNames, parametersOfReadCostTypeNames, methodReadCostTypeNamesPrametersTypes);

            // Assert
            parametersOfReadCostTypeNames.ShouldNotBeNull();
            parametersOfReadCostTypeNames.Length.ShouldBe(1);
            methodReadCostTypeNamesPrametersTypes.Length.ShouldBe(1);
            methodReadCostTypeNamesPrametersTypes.Length.ShouldBe(parametersOfReadCostTypeNames.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCostTypeNames) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadCostTypeNames_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadCostTypeNames, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadCostTypeNames) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadCostTypeNames_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadCostTypeNamesPrametersTypes = new Type[] { typeof(SqlConnection) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodReadCostTypeNames, Fixture, methodReadCostTypeNamesPrametersTypes);

            // Assert
            methodReadCostTypeNamesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCostTypeNames) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadCostTypeNames_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadCostTypeNames, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckVersionSecurity) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_CheckVersionSecurity_Method_Call_Internally(Type[] types)
        {
            var methodCheckVersionSecurityPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodCheckVersionSecurity, Fixture, methodCheckVersionSecurityPrametersTypes);
        }

        #endregion
        
        #region Method Call : (CheckVersionSecurity) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_CheckVersionSecurity_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCheckVersionSecurity, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion
        
        #region Method Call : (CheckVersionSecurity) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_CheckVersionSecurity_Method_Call_With_5_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCheckVersionSecurity, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadModelNames) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_ReadModelNames_Method_Call_Internally(Type[] types)
        {
            var methodReadModelNamesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodReadModelNames, Fixture, methodReadModelNamesPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadModelNames) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadModelNames_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var model = CreateType<string>();
            var sWResID = CreateType<string>();
            var oDataAccess = CreateType<SqlConnection>();
            var optlist = CreateType<List<ItemDefn>>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.ReadModelNames(model, sWResID, oDataAccess, ref optlist);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ReadModelNames) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadModelNames_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var model = CreateType<string>();
            var sWResID = CreateType<string>();
            var oDataAccess = CreateType<SqlConnection>();
            var optlist = CreateType<List<ItemDefn>>();
            var methodReadModelNamesPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(SqlConnection), typeof(List<ItemDefn>) };
            object[] parametersOfReadModelNames = { model, sWResID, oDataAccess, optlist };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReadModelNames, methodReadModelNamesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfReadModelNames);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReadModelNames.ShouldNotBeNull();
            parametersOfReadModelNames.Length.ShouldBe(4);
            methodReadModelNamesPrametersTypes.Length.ShouldBe(4);
            methodReadModelNamesPrametersTypes.Length.ShouldBe(parametersOfReadModelNames.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadModelNames) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadModelNames_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var model = CreateType<string>();
            var sWResID = CreateType<string>();
            var oDataAccess = CreateType<SqlConnection>();
            var optlist = CreateType<List<ItemDefn>>();
            var methodReadModelNamesPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(SqlConnection), typeof(List<ItemDefn>) };
            object[] parametersOfReadModelNames = { model, sWResID, oDataAccess, optlist };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodReadModelNames, parametersOfReadModelNames, methodReadModelNamesPrametersTypes);

            // Assert
            parametersOfReadModelNames.ShouldNotBeNull();
            parametersOfReadModelNames.Length.ShouldBe(4);
            methodReadModelNamesPrametersTypes.Length.ShouldBe(4);
            methodReadModelNamesPrametersTypes.Length.ShouldBe(parametersOfReadModelNames.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadModelNames) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadModelNames_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadModelNames, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadModelNames) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadModelNames_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadModelNamesPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(SqlConnection), typeof(List<ItemDefn>) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodReadModelNames, Fixture, methodReadModelNamesPrametersTypes);

            // Assert
            methodReadModelNamesPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadModelNames) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadModelNames_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadModelNames, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadStages) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_ReadStages_Method_Call_Internally(Type[] types)
        {
            var methodReadStagesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodReadStages, Fixture, methodReadStagesPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadStages) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadStages_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var methodReadStagesPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfReadStages = { oDataAccess };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReadStages, methodReadStagesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfReadStages);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReadStages.ShouldNotBeNull();
            parametersOfReadStages.Length.ShouldBe(1);
            methodReadStagesPrametersTypes.Length.ShouldBe(1);
            methodReadStagesPrametersTypes.Length.ShouldBe(parametersOfReadStages.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadStages) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadStages_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var methodReadStagesPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfReadStages = { oDataAccess };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodReadStages, parametersOfReadStages, methodReadStagesPrametersTypes);

            // Assert
            parametersOfReadStages.ShouldNotBeNull();
            parametersOfReadStages.Length.ShouldBe(1);
            methodReadStagesPrametersTypes.Length.ShouldBe(1);
            methodReadStagesPrametersTypes.Length.ShouldBe(parametersOfReadStages.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadStages) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadStages_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadStages, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadStages) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadStages_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadStagesPrametersTypes = new Type[] { typeof(SqlConnection) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodReadStages, Fixture, methodReadStagesPrametersTypes);

            // Assert
            methodReadStagesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadStages) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadStages_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadStages, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadExtraPifields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_ReadExtraPifields_Method_Call_Internally(Type[] types)
        {
            var methodReadExtraPifieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodReadExtraPifields, Fixture, methodReadExtraPifieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadExtraPifields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadExtraPifields_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var methodReadExtraPifieldsPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfReadExtraPifields = { sqlConnection };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReadExtraPifields, methodReadExtraPifieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfReadExtraPifields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReadExtraPifields.ShouldNotBeNull();
            parametersOfReadExtraPifields.Length.ShouldBe(1);
            methodReadExtraPifieldsPrametersTypes.Length.ShouldBe(1);
            methodReadExtraPifieldsPrametersTypes.Length.ShouldBe(parametersOfReadExtraPifields.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadExtraPifields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadExtraPifields_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var methodReadExtraPifieldsPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfReadExtraPifields = { sqlConnection };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodReadExtraPifields, parametersOfReadExtraPifields, methodReadExtraPifieldsPrametersTypes);

            // Assert
            parametersOfReadExtraPifields.ShouldNotBeNull();
            parametersOfReadExtraPifields.Length.ShouldBe(1);
            methodReadExtraPifieldsPrametersTypes.Length.ShouldBe(1);
            methodReadExtraPifieldsPrametersTypes.Length.ShouldBe(parametersOfReadExtraPifields.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadExtraPifields) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadExtraPifields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadExtraPifields, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadExtraPifields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadExtraPifields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadExtraPifieldsPrametersTypes = new Type[] { typeof(SqlConnection) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodReadExtraPifields, Fixture, methodReadExtraPifieldsPrametersTypes);

            // Assert
            methodReadExtraPifieldsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadExtraPifields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadExtraPifields_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadExtraPifields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateFieldsRelatedToFieldId) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_UpdateFieldsRelatedToFieldId_Method_Call_Internally(Type[] types)
        {
            var methodUpdateFieldsRelatedToFieldIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodUpdateFieldsRelatedToFieldId, Fixture, methodUpdateFieldsRelatedToFieldIdPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateFieldsRelatedToFieldId) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_UpdateFieldsRelatedToFieldId_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fieldIndex = CreateType<int>();
            var methodUpdateFieldsRelatedToFieldIdPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfUpdateFieldsRelatedToFieldId = { fieldIndex };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodUpdateFieldsRelatedToFieldId, parametersOfUpdateFieldsRelatedToFieldId, methodUpdateFieldsRelatedToFieldIdPrametersTypes);

            // Assert
            parametersOfUpdateFieldsRelatedToFieldId.ShouldNotBeNull();
            parametersOfUpdateFieldsRelatedToFieldId.Length.ShouldBe(1);
            methodUpdateFieldsRelatedToFieldIdPrametersTypes.Length.ShouldBe(1);
            methodUpdateFieldsRelatedToFieldIdPrametersTypes.Length.ShouldBe(parametersOfUpdateFieldsRelatedToFieldId.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateFieldsRelatedToFieldId) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_UpdateFieldsRelatedToFieldId_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateFieldsRelatedToFieldIdPrametersTypes = new Type[] { typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodUpdateFieldsRelatedToFieldId, Fixture, methodUpdateFieldsRelatedToFieldIdPrametersTypes);

            // Assert
            methodUpdateFieldsRelatedToFieldIdPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_StripNum_Method_Call_Internally(Type[] types)
        {
            var methodStripNumPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodStripNum, Fixture, methodStripNumPrametersTypes);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_StripNum_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sin = CreateType<string>();
            var methodStripNumPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStripNum = { sin };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodStripNum, methodStripNumPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ModelCache, int>(_modelCacheInstanceFixture, out exception1, parametersOfStripNum);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ModelCache, int>(_modelCacheInstance, MethodStripNum, parametersOfStripNum, methodStripNumPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfStripNum.ShouldNotBeNull();
            parametersOfStripNum.Length.ShouldBe(1);
            methodStripNumPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_StripNum_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sin = CreateType<string>();
            var methodStripNumPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStripNum = { sin };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodStripNum, methodStripNumPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ModelCache, int>(_modelCacheInstanceFixture, out exception1, parametersOfStripNum);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ModelCache, int>(_modelCacheInstance, MethodStripNum, parametersOfStripNum, methodStripNumPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfStripNum.ShouldNotBeNull();
            parametersOfStripNum.Length.ShouldBe(1);
            methodStripNumPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_StripNum_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sin = CreateType<string>();
            var methodStripNumPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStripNum = { sin };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, int>(_modelCacheInstance, MethodStripNum, parametersOfStripNum, methodStripNumPrametersTypes);

            // Assert
            parametersOfStripNum.ShouldNotBeNull();
            parametersOfStripNum.Length.ShouldBe(1);
            methodStripNumPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_StripNum_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodStripNumPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodStripNum, Fixture, methodStripNumPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodStripNumPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_StripNum_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodStripNum, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_StripNum_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodStripNum, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (MyFormat) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_MyFormat_Method_Call_Internally(Type[] types)
        {
            var methodMyFormatPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodMyFormat, Fixture, methodMyFormatPrametersTypes);
        }

        #endregion

        #region Method Call : (MyFormat) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_MyFormat_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var obj = CreateType<object>();
            var lt = CreateType<int>();
            var sCodes = CreateType<string>();
            var sRes = CreateType<string>();
            var methodMyFormatPrametersTypes = new Type[] { typeof(object), typeof(int), typeof(string), typeof(string) };
            object[] parametersOfMyFormat = { obj, lt, sCodes, sRes };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, string>(_modelCacheInstance, MethodMyFormat, parametersOfMyFormat, methodMyFormatPrametersTypes);

            // Assert
            parametersOfMyFormat.ShouldNotBeNull();
            parametersOfMyFormat.Length.ShouldBe(4);
            methodMyFormatPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MyFormat) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_MyFormat_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodMyFormatPrametersTypes = new Type[] { typeof(object), typeof(int), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodMyFormat, Fixture, methodMyFormatPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodMyFormatPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (MyFormat) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_MyFormat_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodMyFormatPrametersTypes = new Type[] { typeof(object), typeof(int), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodMyFormat, Fixture, methodMyFormatPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodMyFormatPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (MyFormat) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_MyFormat_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodMyFormat, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadPILevelData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_ReadPILevelData_Method_Call_Internally(Type[] types)
        {
            var methodReadPILevelDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodReadPILevelData, Fixture, methodReadPILevelDataPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadPILevelData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadPILevelData_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var earlystart = CreateType<DateTime>();
            var latefinish = CreateType<DateTime>();
            var methodReadPILevelDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(DateTime), typeof(DateTime) };
            object[] parametersOfReadPILevelData = { oDataAccess, earlystart, latefinish };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReadPILevelData, methodReadPILevelDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfReadPILevelData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReadPILevelData.ShouldNotBeNull();
            parametersOfReadPILevelData.Length.ShouldBe(3);
            methodReadPILevelDataPrametersTypes.Length.ShouldBe(3);
            methodReadPILevelDataPrametersTypes.Length.ShouldBe(parametersOfReadPILevelData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadPILevelData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadPILevelData_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var earlystart = CreateType<DateTime>();
            var latefinish = CreateType<DateTime>();
            var methodReadPILevelDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(DateTime), typeof(DateTime) };
            object[] parametersOfReadPILevelData = { oDataAccess, earlystart, latefinish };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodReadPILevelData, parametersOfReadPILevelData, methodReadPILevelDataPrametersTypes);

            // Assert
            parametersOfReadPILevelData.ShouldNotBeNull();
            parametersOfReadPILevelData.Length.ShouldBe(3);
            methodReadPILevelDataPrametersTypes.Length.ShouldBe(3);
            methodReadPILevelDataPrametersTypes.Length.ShouldBe(parametersOfReadPILevelData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadPILevelData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadPILevelData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadPILevelData, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadPILevelData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadPILevelData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadPILevelDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(DateTime), typeof(DateTime) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodReadPILevelData, Fixture, methodReadPILevelDataPrametersTypes);

            // Assert
            methodReadPILevelDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadPILevelData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadPILevelData_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadPILevelData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCostCustomFieldsAndData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_ReadCostCustomFieldsAndData_Method_Call_Internally(Type[] types)
        {
            var methodReadCostCustomFieldsAndDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodReadCostCustomFieldsAndData, Fixture, methodReadCostCustomFieldsAndDataPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadCostCustomFieldsAndData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadCostCustomFieldsAndData_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var methodReadCostCustomFieldsAndDataPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfReadCostCustomFieldsAndData = { oDataAccess };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReadCostCustomFieldsAndData, methodReadCostCustomFieldsAndDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfReadCostCustomFieldsAndData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReadCostCustomFieldsAndData.ShouldNotBeNull();
            parametersOfReadCostCustomFieldsAndData.Length.ShouldBe(1);
            methodReadCostCustomFieldsAndDataPrametersTypes.Length.ShouldBe(1);
            methodReadCostCustomFieldsAndDataPrametersTypes.Length.ShouldBe(parametersOfReadCostCustomFieldsAndData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadCostCustomFieldsAndData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadCostCustomFieldsAndData_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var methodReadCostCustomFieldsAndDataPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfReadCostCustomFieldsAndData = { oDataAccess };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodReadCostCustomFieldsAndData, parametersOfReadCostCustomFieldsAndData, methodReadCostCustomFieldsAndDataPrametersTypes);

            // Assert
            parametersOfReadCostCustomFieldsAndData.ShouldNotBeNull();
            parametersOfReadCostCustomFieldsAndData.Length.ShouldBe(1);
            methodReadCostCustomFieldsAndDataPrametersTypes.Length.ShouldBe(1);
            methodReadCostCustomFieldsAndDataPrametersTypes.Length.ShouldBe(parametersOfReadCostCustomFieldsAndData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCostCustomFieldsAndData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadCostCustomFieldsAndData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadCostCustomFieldsAndData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadCostCustomFieldsAndData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadCostCustomFieldsAndData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadCostCustomFieldsAndDataPrametersTypes = new Type[] { typeof(SqlConnection) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodReadCostCustomFieldsAndData, Fixture, methodReadCostCustomFieldsAndDataPrametersTypes);

            // Assert
            methodReadCostCustomFieldsAndDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCostCustomFieldsAndData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadCostCustomFieldsAndData_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadCostCustomFieldsAndData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadBudgetBands) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_ReadBudgetBands_Method_Call_Internally(Type[] types)
        {
            var methodReadBudgetBandsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodReadBudgetBands, Fixture, methodReadBudgetBandsPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadBudgetBands) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadBudgetBands_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var methodReadBudgetBandsPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfReadBudgetBands = { oDataAccess };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReadBudgetBands, methodReadBudgetBandsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfReadBudgetBands);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReadBudgetBands.ShouldNotBeNull();
            parametersOfReadBudgetBands.Length.ShouldBe(1);
            methodReadBudgetBandsPrametersTypes.Length.ShouldBe(1);
            methodReadBudgetBandsPrametersTypes.Length.ShouldBe(parametersOfReadBudgetBands.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadBudgetBands) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadBudgetBands_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var methodReadBudgetBandsPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfReadBudgetBands = { oDataAccess };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodReadBudgetBands, parametersOfReadBudgetBands, methodReadBudgetBandsPrametersTypes);

            // Assert
            parametersOfReadBudgetBands.ShouldNotBeNull();
            parametersOfReadBudgetBands.Length.ShouldBe(1);
            methodReadBudgetBandsPrametersTypes.Length.ShouldBe(1);
            methodReadBudgetBandsPrametersTypes.Length.ShouldBe(parametersOfReadBudgetBands.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadBudgetBands) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadBudgetBands_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadBudgetBands, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadBudgetBands) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadBudgetBands_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadBudgetBandsPrametersTypes = new Type[] { typeof(SqlConnection) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodReadBudgetBands, Fixture, methodReadBudgetBandsPrametersTypes);

            // Assert
            methodReadBudgetBandsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadBudgetBands) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadBudgetBands_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadBudgetBands, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadModelTargets) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_ReadModelTargets_Method_Call_Internally(Type[] types)
        {
            var methodReadModelTargetsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodReadModelTargets, Fixture, methodReadModelTargetsPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadModelTargets) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadModelTargets_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var sWResID = CreateType<string>();
            var methodReadModelTargetsPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfReadModelTargets = { oDataAccess, sWResID };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReadModelTargets, methodReadModelTargetsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfReadModelTargets);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReadModelTargets.ShouldNotBeNull();
            parametersOfReadModelTargets.Length.ShouldBe(2);
            methodReadModelTargetsPrametersTypes.Length.ShouldBe(2);
            methodReadModelTargetsPrametersTypes.Length.ShouldBe(parametersOfReadModelTargets.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadModelTargets) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadModelTargets_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var sWResID = CreateType<string>();
            var methodReadModelTargetsPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfReadModelTargets = { oDataAccess, sWResID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodReadModelTargets, parametersOfReadModelTargets, methodReadModelTargetsPrametersTypes);

            // Assert
            parametersOfReadModelTargets.ShouldNotBeNull();
            parametersOfReadModelTargets.Length.ShouldBe(2);
            methodReadModelTargetsPrametersTypes.Length.ShouldBe(2);
            methodReadModelTargetsPrametersTypes.Length.ShouldBe(parametersOfReadModelTargets.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadModelTargets) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadModelTargets_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadModelTargets, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadModelTargets) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadModelTargets_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadModelTargetsPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodReadModelTargets, Fixture, methodReadModelTargetsPrametersTypes);

            // Assert
            methodReadModelTargetsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadModelTargets) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadModelTargets_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadModelTargets, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadRateTable) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_ReadRateTable_Method_Call_Internally(Type[] types)
        {
            var methodReadRateTablePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodReadRateTable, Fixture, methodReadRateTablePrametersTypes);
        }

        #endregion

        #region Method Call : (ReadRateTable) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadRateTable_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var methodReadRateTablePrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfReadRateTable = { oDataAccess };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReadRateTable, methodReadRateTablePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfReadRateTable);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReadRateTable.ShouldNotBeNull();
            parametersOfReadRateTable.Length.ShouldBe(1);
            methodReadRateTablePrametersTypes.Length.ShouldBe(1);
            methodReadRateTablePrametersTypes.Length.ShouldBe(parametersOfReadRateTable.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadRateTable) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadRateTable_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var methodReadRateTablePrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfReadRateTable = { oDataAccess };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodReadRateTable, parametersOfReadRateTable, methodReadRateTablePrametersTypes);

            // Assert
            parametersOfReadRateTable.ShouldNotBeNull();
            parametersOfReadRateTable.Length.ShouldBe(1);
            methodReadRateTablePrametersTypes.Length.ShouldBe(1);
            methodReadRateTablePrametersTypes.Length.ShouldBe(parametersOfReadRateTable.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadRateTable) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadRateTable_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadRateTable, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadRateTable) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadRateTable_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadRateTablePrametersTypes = new Type[] { typeof(SqlConnection) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodReadRateTable, Fixture, methodReadRateTablePrametersTypes);

            // Assert
            methodReadRateTablePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadRateTable) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ReadRateTable_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadRateTable, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadScenarios) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_LoadScenarios_Method_Call_Internally(Type[] types)
        {
            var methodLoadScenariosPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodLoadScenarios, Fixture, methodLoadScenariosPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadScenarios) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadScenarios_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var Scenarios = CreateType<string>();
            var bdoTxtThing = CreateType<bool>();
            var bSetSelected = CreateType<bool>();
            var methodLoadScenariosPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(bool), typeof(bool) };
            object[] parametersOfLoadScenarios = { oDataAccess, Scenarios, bdoTxtThing, bSetSelected };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadScenarios, methodLoadScenariosPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfLoadScenarios);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadScenarios.ShouldNotBeNull();
            parametersOfLoadScenarios.Length.ShouldBe(4);
            methodLoadScenariosPrametersTypes.Length.ShouldBe(4);
            methodLoadScenariosPrametersTypes.Length.ShouldBe(parametersOfLoadScenarios.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (LoadScenarios) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadScenarios_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var Scenarios = CreateType<string>();
            var bdoTxtThing = CreateType<bool>();
            var bSetSelected = CreateType<bool>();
            var methodLoadScenariosPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(bool), typeof(bool) };
            object[] parametersOfLoadScenarios = { oDataAccess, Scenarios, bdoTxtThing, bSetSelected };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodLoadScenarios, parametersOfLoadScenarios, methodLoadScenariosPrametersTypes);

            // Assert
            parametersOfLoadScenarios.ShouldNotBeNull();
            parametersOfLoadScenarios.Length.ShouldBe(4);
            methodLoadScenariosPrametersTypes.Length.ShouldBe(4);
            methodLoadScenariosPrametersTypes.Length.ShouldBe(parametersOfLoadScenarios.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadScenarios) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadScenarios_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLoadScenarios, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LoadScenarios) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadScenarios_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLoadScenariosPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(bool), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodLoadScenarios, Fixture, methodLoadScenariosPrametersTypes);

            // Assert
            methodLoadScenariosPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadScenarios) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadScenarios_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadScenarios, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadTargets) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_LoadTargets_Method_Call_Internally(Type[] types)
        {
            var methodLoadTargetsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodLoadTargets, Fixture, methodLoadTargetsPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadTargets) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadTargets_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var targets = CreateType<string>();
            var methodLoadTargetsPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfLoadTargets = { oDataAccess, targets };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodLoadTargets, methodLoadTargetsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ModelCache, int>(_modelCacheInstanceFixture, out exception1, parametersOfLoadTargets);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ModelCache, int>(_modelCacheInstance, MethodLoadTargets, parametersOfLoadTargets, methodLoadTargetsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfLoadTargets.ShouldNotBeNull();
            parametersOfLoadTargets.Length.ShouldBe(2);
            methodLoadTargetsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (LoadTargets) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadTargets_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var targets = CreateType<string>();
            var methodLoadTargetsPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfLoadTargets = { oDataAccess, targets };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodLoadTargets, methodLoadTargetsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ModelCache, int>(_modelCacheInstanceFixture, out exception1, parametersOfLoadTargets);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ModelCache, int>(_modelCacheInstance, MethodLoadTargets, parametersOfLoadTargets, methodLoadTargetsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfLoadTargets.ShouldNotBeNull();
            parametersOfLoadTargets.Length.ShouldBe(2);
            methodLoadTargetsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (LoadTargets) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadTargets_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var targets = CreateType<string>();
            var methodLoadTargetsPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfLoadTargets = { oDataAccess, targets };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, int>(_modelCacheInstance, MethodLoadTargets, parametersOfLoadTargets, methodLoadTargetsPrametersTypes);

            // Assert
            parametersOfLoadTargets.ShouldNotBeNull();
            parametersOfLoadTargets.Length.ShouldBe(2);
            methodLoadTargetsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadTargets) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadTargets_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLoadTargetsPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodLoadTargets, Fixture, methodLoadTargetsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodLoadTargetsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LoadTargets) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadTargets_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadTargets, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (LoadTargets) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadTargets_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLoadTargets, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ApplyUserOptions) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_ApplyUserOptions_Method_Call_Internally(Type[] types)
        {
            var methodApplyUserOptionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodApplyUserOptions, Fixture, methodApplyUserOptionsPrametersTypes);
        }

        #endregion

        #region Method Call : (ApplyUserOptions) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ApplyUserOptions_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.ApplyUserOptions();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ApplyUserOptions) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ApplyUserOptions_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodApplyUserOptionsPrametersTypes = null;
            object[] parametersOfApplyUserOptions = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodApplyUserOptions, methodApplyUserOptionsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfApplyUserOptions);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfApplyUserOptions.ShouldBeNull();
            methodApplyUserOptionsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ApplyUserOptions) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ApplyUserOptions_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodApplyUserOptionsPrametersTypes = null;
            object[] parametersOfApplyUserOptions = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodApplyUserOptions, parametersOfApplyUserOptions, methodApplyUserOptionsPrametersTypes);

            // Assert
            parametersOfApplyUserOptions.ShouldBeNull();
            methodApplyUserOptionsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyUserOptions) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ApplyUserOptions_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodApplyUserOptionsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodApplyUserOptions, Fixture, methodApplyUserOptionsPrametersTypes);

            // Assert
            methodApplyUserOptionsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyUserOptions) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ApplyUserOptions_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodApplyUserOptions, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadAnyScenarios) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_LoadAnyScenarios_Method_Call_Internally(Type[] types)
        {
            var methodLoadAnyScenariosPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodLoadAnyScenarios, Fixture, methodLoadAnyScenariosPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadAnyScenarios) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadAnyScenarios_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodLoadAnyScenariosPrametersTypes = null;
            object[] parametersOfLoadAnyScenarios = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadAnyScenarios, methodLoadAnyScenariosPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfLoadAnyScenarios);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadAnyScenarios.ShouldBeNull();
            methodLoadAnyScenariosPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadAnyScenarios) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadAnyScenarios_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodLoadAnyScenariosPrametersTypes = null;
            object[] parametersOfLoadAnyScenarios = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodLoadAnyScenarios, parametersOfLoadAnyScenarios, methodLoadAnyScenariosPrametersTypes);

            // Assert
            parametersOfLoadAnyScenarios.ShouldBeNull();
            methodLoadAnyScenariosPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadAnyScenarios) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadAnyScenarios_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodLoadAnyScenariosPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodLoadAnyScenarios, Fixture, methodLoadAnyScenariosPrametersTypes);

            // Assert
            methodLoadAnyScenariosPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadAnyScenarios) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadAnyScenarios_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadAnyScenarios, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StashRateCache) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_StashRateCache_Method_Call_Internally(Type[] types)
        {
            var methodStashRateCachePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodStashRateCache, Fixture, methodStashRateCachePrametersTypes);
        }

        #endregion

        #region Method Call : (StashRateCache) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_StashRateCache_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodStashRateCachePrametersTypes = null;
            object[] parametersOfStashRateCache = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodStashRateCache, methodStashRateCachePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfStashRateCache);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfStashRateCache.ShouldBeNull();
            methodStashRateCachePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StashRateCache) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_StashRateCache_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodStashRateCachePrametersTypes = null;
            object[] parametersOfStashRateCache = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodStashRateCache, parametersOfStashRateCache, methodStashRateCachePrametersTypes);

            // Assert
            parametersOfStashRateCache.ShouldBeNull();
            methodStashRateCachePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StashRateCache) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_StashRateCache_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodStashRateCachePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodStashRateCache, Fixture, methodStashRateCachePrametersTypes);

            // Assert
            methodStashRateCachePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StashRateCache) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_StashRateCache_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodStashRateCache, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildCustomFilterLists) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_BuildCustomFilterLists_Method_Call_Internally(Type[] types)
        {
            var methodBuildCustomFilterListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodBuildCustomFilterLists, Fixture, methodBuildCustomFilterListsPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildCustomFilterLists) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_BuildCustomFilterLists_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodBuildCustomFilterListsPrametersTypes = null;
            object[] parametersOfBuildCustomFilterLists = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildCustomFilterLists, methodBuildCustomFilterListsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfBuildCustomFilterLists);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildCustomFilterLists.ShouldBeNull();
            methodBuildCustomFilterListsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (BuildCustomFilterLists) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_BuildCustomFilterLists_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodBuildCustomFilterListsPrametersTypes = null;
            object[] parametersOfBuildCustomFilterLists = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodBuildCustomFilterLists, parametersOfBuildCustomFilterLists, methodBuildCustomFilterListsPrametersTypes);

            // Assert
            parametersOfBuildCustomFilterLists.ShouldBeNull();
            methodBuildCustomFilterListsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildCustomFilterLists) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_BuildCustomFilterLists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodBuildCustomFilterListsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodBuildCustomFilterLists, Fixture, methodBuildCustomFilterListsPrametersTypes);

            // Assert
            methodBuildCustomFilterListsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildCustomFilterLists) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_BuildCustomFilterLists_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildCustomFilterLists, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTotalEntry) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_AddTotalEntry_Method_Call_Internally(Type[] types)
        {
            var methodAddTotalEntryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodAddTotalEntry, Fixture, methodAddTotalEntryPrametersTypes);
        }

        #endregion

        #region Method Call : (AddTotalEntry) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_AddTotalEntry_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var Name = CreateType<string>();
            var fid = CreateType<int>();
            var bSel = CreateType<bool>();
            var methodAddTotalEntryPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(bool) };
            object[] parametersOfAddTotalEntry = { Name, fid, bSel };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddTotalEntry, methodAddTotalEntryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfAddTotalEntry);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddTotalEntry.ShouldNotBeNull();
            parametersOfAddTotalEntry.Length.ShouldBe(3);
            methodAddTotalEntryPrametersTypes.Length.ShouldBe(3);
            methodAddTotalEntryPrametersTypes.Length.ShouldBe(parametersOfAddTotalEntry.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddTotalEntry) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_AddTotalEntry_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Name = CreateType<string>();
            var fid = CreateType<int>();
            var bSel = CreateType<bool>();
            var methodAddTotalEntryPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(bool) };
            object[] parametersOfAddTotalEntry = { Name, fid, bSel };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodAddTotalEntry, parametersOfAddTotalEntry, methodAddTotalEntryPrametersTypes);

            // Assert
            parametersOfAddTotalEntry.ShouldNotBeNull();
            parametersOfAddTotalEntry.Length.ShouldBe(3);
            methodAddTotalEntryPrametersTypes.Length.ShouldBe(3);
            methodAddTotalEntryPrametersTypes.Length.ShouldBe(parametersOfAddTotalEntry.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTotalEntry) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_AddTotalEntry_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddTotalEntry, 0);
            const int parametersCount = 3;

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
        public void AUT_ModelCache_AddTotalEntry_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddTotalEntryPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodAddTotalEntry, Fixture, methodAddTotalEntryPrametersTypes);

            // Assert
            methodAddTotalEntryPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTotalEntry) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_AddTotalEntry_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddTotalEntry, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColEntry) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_AddColEntry_Method_Call_Internally(Type[] types)
        {
            var methodAddColEntryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodAddColEntry, Fixture, methodAddColEntryPrametersTypes);
        }

        #endregion

        #region Method Call : (AddColEntry) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_AddColEntry_Method_Call_Void_With_5_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var Name = CreateType<string>();
            var fid = CreateType<int>();
            var bDSel = CreateType<bool>();
            var bAddToTot = CreateType<bool>();
            var bTSel = CreateType<bool>();
            var methodAddColEntryPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(bool), typeof(bool), typeof(bool) };
            object[] parametersOfAddColEntry = { Name, fid, bDSel, bAddToTot, bTSel };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddColEntry, methodAddColEntryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfAddColEntry);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddColEntry.ShouldNotBeNull();
            parametersOfAddColEntry.Length.ShouldBe(5);
            methodAddColEntryPrametersTypes.Length.ShouldBe(5);
            methodAddColEntryPrametersTypes.Length.ShouldBe(parametersOfAddColEntry.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddColEntry) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_AddColEntry_Method_Call_Void_With_5_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Name = CreateType<string>();
            var fid = CreateType<int>();
            var bDSel = CreateType<bool>();
            var bAddToTot = CreateType<bool>();
            var bTSel = CreateType<bool>();
            var methodAddColEntryPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(bool), typeof(bool), typeof(bool) };
            object[] parametersOfAddColEntry = { Name, fid, bDSel, bAddToTot, bTSel };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodAddColEntry, parametersOfAddColEntry, methodAddColEntryPrametersTypes);

            // Assert
            parametersOfAddColEntry.ShouldNotBeNull();
            parametersOfAddColEntry.Length.ShouldBe(5);
            methodAddColEntryPrametersTypes.Length.ShouldBe(5);
            methodAddColEntryPrametersTypes.Length.ShouldBe(parametersOfAddColEntry.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColEntry) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_AddColEntry_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddColEntry, 0);
            const int parametersCount = 5;

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
        public void AUT_ModelCache_AddColEntry_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddColEntryPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(bool), typeof(bool), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodAddColEntry, Fixture, methodAddColEntryPrametersTypes);

            // Assert
            methodAddColEntryPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColEntry) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_AddColEntry_Method_Call_With_5_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddColEntry, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoSnGStuff) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_DoSnGStuff_Method_Call_Internally(Type[] types)
        {
            var methodDoSnGStuffPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodDoSnGStuff, Fixture, methodDoSnGStuffPrametersTypes);
        }

        #endregion

        #region Method Call : (DoSnGStuff) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DoSnGStuff_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fid = CreateType<int>();
            var name = CreateType<string>();
            var bAddTot = CreateType<bool>();
            var methodDoSnGStuffPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(bool) };
            object[] parametersOfDoSnGStuff = { fid, name, bAddTot };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodDoSnGStuff, parametersOfDoSnGStuff, methodDoSnGStuffPrametersTypes);

            // Assert
            parametersOfDoSnGStuff.ShouldNotBeNull();
            parametersOfDoSnGStuff.Length.ShouldBe(3);
            methodDoSnGStuffPrametersTypes.Length.ShouldBe(3);
            methodDoSnGStuffPrametersTypes.Length.ShouldBe(parametersOfDoSnGStuff.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoSnGStuff) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DoSnGStuff_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDoSnGStuff, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoSnGStuff) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DoSnGStuff_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDoSnGStuffPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodDoSnGStuff, Fixture, methodDoSnGStuffPrametersTypes);

            // Assert
            methodDoSnGStuffPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoSnGStuff) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DoSnGStuff_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDoSnGStuff, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortCollection) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_SortCollection_Method_Call_Internally(Type[] types)
        {
            var methodSortCollectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSortCollection, Fixture, methodSortCollectionPrametersTypes);
        }

        #endregion

        #region Method Call : (SortCollection) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SortCollection_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var i = CreateType<int>();
            var methodSortCollectionPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfSortCollection = { i };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodSortCollection, parametersOfSortCollection, methodSortCollectionPrametersTypes);

            // Assert
            parametersOfSortCollection.ShouldNotBeNull();
            parametersOfSortCollection.Length.ShouldBe(1);
            methodSortCollectionPrametersTypes.Length.ShouldBe(1);
            methodSortCollectionPrametersTypes.Length.ShouldBe(parametersOfSortCollection.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortCollection) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SortCollection_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSortCollection, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SortCollection) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SortCollection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSortCollectionPrametersTypes = new Type[] { typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSortCollection, Fixture, methodSortCollectionPrametersTypes);

            // Assert
            methodSortCollectionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortCollection) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SortCollection_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSortCollection, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConCatCollection) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_ConCatCollection_Method_Call_Internally(Type[] types)
        {
            var methodConCatCollectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodConCatCollection, Fixture, methodConCatCollectionPrametersTypes);
        }

        #endregion

        #region Method Call : (ConCatCollection) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ConCatCollection_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var i = CreateType<int>();
            var groupfid = CreateType<int>();
            var sgroup = CreateType<string>();
            var methodConCatCollectionPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(string) };
            object[] parametersOfConCatCollection = { i, groupfid, sgroup };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodConCatCollection, parametersOfConCatCollection, methodConCatCollectionPrametersTypes);

            // Assert
            parametersOfConCatCollection.ShouldNotBeNull();
            parametersOfConCatCollection.Length.ShouldBe(3);
            methodConCatCollectionPrametersTypes.Length.ShouldBe(3);
            methodConCatCollectionPrametersTypes.Length.ShouldBe(parametersOfConCatCollection.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConCatCollection) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ConCatCollection_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodConCatCollection, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConCatCollection) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ConCatCollection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodConCatCollectionPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodConCatCollection, Fixture, methodConCatCollectionPrametersTypes);

            // Assert
            methodConCatCollectionPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConCatCollection) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ConCatCollection_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConCatCollection, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetHighlevelFilterFlag) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_SetHighlevelFilterFlag_Method_Call_Internally(Type[] types)
        {
            var methodSetHighlevelFilterFlagPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSetHighlevelFilterFlag, Fixture, methodSetHighlevelFilterFlagPrametersTypes);
        }

        #endregion

        #region Method Call : (SetHighlevelFilterFlag) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetHighlevelFilterFlag_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodSetHighlevelFilterFlagPrametersTypes = null;
            object[] parametersOfSetHighlevelFilterFlag = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetHighlevelFilterFlag, methodSetHighlevelFilterFlagPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfSetHighlevelFilterFlag);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetHighlevelFilterFlag.ShouldBeNull();
            methodSetHighlevelFilterFlagPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetHighlevelFilterFlag) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetHighlevelFilterFlag_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodSetHighlevelFilterFlagPrametersTypes = null;
            object[] parametersOfSetHighlevelFilterFlag = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodSetHighlevelFilterFlag, parametersOfSetHighlevelFilterFlag, methodSetHighlevelFilterFlagPrametersTypes);

            // Assert
            parametersOfSetHighlevelFilterFlag.ShouldBeNull();
            methodSetHighlevelFilterFlagPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetHighlevelFilterFlag) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetHighlevelFilterFlag_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodSetHighlevelFilterFlagPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSetHighlevelFilterFlag, Fixture, methodSetHighlevelFilterFlagPrametersTypes);

            // Assert
            methodSetHighlevelFilterFlagPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetHighlevelFilterFlag) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetHighlevelFilterFlag_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetHighlevelFilterFlag, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetShortCatUID) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GetShortCatUID_Method_Call_Internally(Type[] types)
        {
            var methodGetShortCatUIDPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetShortCatUID, Fixture, methodGetShortCatUIDPrametersTypes);
        }

        #endregion
        
        #region Method Call : (GetShortCatUID) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetShortCatUID_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetShortCatUID, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetShortCatUID) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetShortCatUID_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetShortCatUID, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLookUpString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GetLookUpString_Method_Call_Internally(Type[] types)
        {
            var methodGetLookUpStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetLookUpString, Fixture, methodGetLookUpStringPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLookUpString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetLookUpString_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var index = CreateType<int>();
            var lUID = CreateType<int>();
            var methodGetLookUpStringPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfGetLookUpString = { index, lUID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetLookUpString, methodGetLookUpStringPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ModelCache, string>(_modelCacheInstanceFixture, out exception1, parametersOfGetLookUpString);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ModelCache, string>(_modelCacheInstance, MethodGetLookUpString, parametersOfGetLookUpString, methodGetLookUpStringPrametersTypes);

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
        public void AUT_ModelCache_GetLookUpString_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var index = CreateType<int>();
            var lUID = CreateType<int>();
            var methodGetLookUpStringPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfGetLookUpString = { index, lUID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, string>(_modelCacheInstance, MethodGetLookUpString, parametersOfGetLookUpString, methodGetLookUpStringPrametersTypes);

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
        public void AUT_ModelCache_GetLookUpString_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetLookUpStringPrametersTypes = new Type[] { typeof(int), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetLookUpString, Fixture, methodGetLookUpStringPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLookUpStringPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetLookUpString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetLookUpString_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetLookUpStringPrametersTypes = new Type[] { typeof(int), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetLookUpString, Fixture, methodGetLookUpStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLookUpStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLookUpString) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetLookUpString_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLookUpString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetLookUpString) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetLookUpString_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (PerformCalcs) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_PerformCalcs_Method_Call_Internally(Type[] types)
        {
            var methodPerformCalcsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodPerformCalcs, Fixture, methodPerformCalcsPrametersTypes);
        }

        #endregion

        #region Method Call : (PerformCalcs) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_PerformCalcs_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPerformCalcs, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PerformCalcs) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_PerformCalcs_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPerformCalcs, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessAndCreateDistplayLists) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_ProcessAndCreateDistplayLists_Method_Call_Internally(Type[] types)
        {
            var methodProcessAndCreateDistplayListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodProcessAndCreateDistplayLists, Fixture, methodProcessAndCreateDistplayListsPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessAndCreateDistplayLists) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ProcessAndCreateDistplayLists_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.ProcessAndCreateDistplayLists();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ProcessAndCreateDistplayLists) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ProcessAndCreateDistplayLists_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodProcessAndCreateDistplayListsPrametersTypes = null;
            object[] parametersOfProcessAndCreateDistplayLists = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodProcessAndCreateDistplayLists, parametersOfProcessAndCreateDistplayLists, methodProcessAndCreateDistplayListsPrametersTypes);

            // Assert
            parametersOfProcessAndCreateDistplayLists.ShouldBeNull();
            methodProcessAndCreateDistplayListsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessAndCreateDistplayLists) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ProcessAndCreateDistplayLists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodProcessAndCreateDistplayListsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodProcessAndCreateDistplayLists, Fixture, methodProcessAndCreateDistplayListsPrametersTypes);

            // Assert
            methodProcessAndCreateDistplayListsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessAndCreateDistplayLists) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ProcessAndCreateDistplayLists_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessAndCreateDistplayLists, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildTotalsKey) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_BuildTotalsKey_Method_Call_Internally(Type[] types)
        {
            var methodBuildTotalsKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodBuildTotalsKey, Fixture, methodBuildTotalsKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildTotalsKey) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_BuildTotalsKey_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildTotalsKey, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (BuildTotalsKey) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_BuildTotalsKey_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_ModelCache_GetDetFieldValue_Method_Call_Internally(Type[] types)
        {
            var methodGetDetFieldValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetDetFieldValue, Fixture, methodGetDetFieldValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetDetFieldValue) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetDetFieldValue_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (GetDetFieldValue) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetDetFieldValue_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDetFieldValue, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTotalDetFieldValue) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_SetTotalDetFieldValue_Method_Call_Internally(Type[] types)
        {
            var methodSetTotalDetFieldValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSetTotalDetFieldValue, Fixture, methodSetTotalDetFieldValuePrametersTypes);
        }

        #endregion

        #region Method Call : (SetTotalDetFieldValue) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetTotalDetFieldValue_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (SetTotalDetFieldValue) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetTotalDetFieldValue_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetTotalDetFieldValue, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CopyOverTotFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_CopyOverTotFields_Method_Call_Internally(Type[] types)
        {
            var methodCopyOverTotFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodCopyOverTotFields, Fixture, methodCopyOverTotFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (CopyOverTotFields) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_CopyOverTotFields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCopyOverTotFields, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CopyOverTotFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_CopyOverTotFields_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCopyOverTotFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortAndGroupCollection) (Return Type : List<DetailRowData>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_SortAndGroupCollection_Method_Call_Internally(Type[] types)
        {
            var methodSortAndGroupCollectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSortAndGroupCollection, Fixture, methodSortAndGroupCollectionPrametersTypes);
        }

        #endregion

        #region Method Call : (SortAndGroupCollection) (Return Type : List<DetailRowData>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SortAndGroupCollection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSortAndGroupCollection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SortAndGroupCollection) (Return Type : List<DetailRowData>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SortAndGroupCollection_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSortAndGroupCollection, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RollUp) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_RollUp_Method_Call_Internally(Type[] types)
        {
            var methodRollUpPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodRollUp, Fixture, methodRollUpPrametersTypes);
        }

        #endregion

        #region Method Call : (RollUp) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_RollUp_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRollUp, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RollUp) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_RollUp_Method_Call_With_5_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRollUp, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTopGrid) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GetTopGrid_Method_Call_Internally(Type[] types)
        {
            var methodGetTopGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetTopGrid, Fixture, methodGetTopGridPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTopGrid) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTopGrid_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.GetTopGrid();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTopGrid) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTopGrid_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetTopGridPrametersTypes = null;
            object[] parametersOfGetTopGrid = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTopGrid, methodGetTopGridPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfGetTopGrid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTopGrid.ShouldBeNull();
            methodGetTopGridPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTopGrid) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTopGrid_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetTopGridPrametersTypes = null;
            object[] parametersOfGetTopGrid = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, string>(_modelCacheInstance, MethodGetTopGrid, parametersOfGetTopGrid, methodGetTopGridPrametersTypes);

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
        public void AUT_ModelCache_GetTopGrid_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetTopGridPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetTopGrid, Fixture, methodGetTopGridPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTopGridPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTopGrid) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTopGrid_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetTopGridPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetTopGrid, Fixture, methodGetTopGridPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTopGridPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTopGrid) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTopGrid_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTopGrid, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetTopGridLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GetTopGridLayout_Method_Call_Internally(Type[] types)
        {
            var methodGetTopGridLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetTopGridLayout, Fixture, methodGetTopGridLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTopGridLayout) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTopGridLayout_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.GetTopGridLayout();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTopGridLayout) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTopGridLayout_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetTopGridLayoutPrametersTypes = null;
            object[] parametersOfGetTopGridLayout = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTopGridLayout, methodGetTopGridLayoutPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfGetTopGridLayout);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTopGridLayout.ShouldBeNull();
            methodGetTopGridLayoutPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTopGridLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTopGridLayout_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetTopGridLayoutPrametersTypes = null;
            object[] parametersOfGetTopGridLayout = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, string>(_modelCacheInstance, MethodGetTopGridLayout, parametersOfGetTopGridLayout, methodGetTopGridLayoutPrametersTypes);

            // Assert
            parametersOfGetTopGridLayout.ShouldBeNull();
            methodGetTopGridLayoutPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTopGridLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTopGridLayout_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetTopGridLayoutPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetTopGridLayout, Fixture, methodGetTopGridLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTopGridLayoutPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTopGridLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTopGridLayout_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetTopGridLayoutPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetTopGridLayout, Fixture, methodGetTopGridLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTopGridLayoutPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTopGridLayout) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTopGridLayout_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTopGridLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetTopGridData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GetTopGridData_Method_Call_Internally(Type[] types)
        {
            var methodGetTopGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetTopGridData, Fixture, methodGetTopGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTopGridData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTopGridData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.GetTopGridData();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTopGridData) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTopGridData_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetTopGridDataPrametersTypes = null;
            object[] parametersOfGetTopGridData = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTopGridData, methodGetTopGridDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfGetTopGridData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTopGridData.ShouldBeNull();
            methodGetTopGridDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTopGridData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTopGridData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetTopGridDataPrametersTypes = null;
            object[] parametersOfGetTopGridData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, string>(_modelCacheInstance, MethodGetTopGridData, parametersOfGetTopGridData, methodGetTopGridDataPrametersTypes);

            // Assert
            parametersOfGetTopGridData.ShouldBeNull();
            methodGetTopGridDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTopGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTopGridData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetTopGridDataPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetTopGridData, Fixture, methodGetTopGridDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTopGridDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTopGridData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTopGridData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetTopGridDataPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetTopGridData, Fixture, methodGetTopGridDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTopGridDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTopGridData) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTopGridData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTopGridData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetBottomGrid) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GetBottomGrid_Method_Call_Internally(Type[] types)
        {
            var methodGetBottomGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetBottomGrid, Fixture, methodGetBottomGridPrametersTypes);
        }

        #endregion

        #region Method Call : (GetBottomGrid) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetBottomGrid_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.GetBottomGrid();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetBottomGrid) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetBottomGrid_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetBottomGridPrametersTypes = null;
            object[] parametersOfGetBottomGrid = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, string>(_modelCacheInstance, MethodGetBottomGrid, parametersOfGetBottomGrid, methodGetBottomGridPrametersTypes);

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
        public void AUT_ModelCache_GetBottomGrid_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetBottomGridPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetBottomGrid, Fixture, methodGetBottomGridPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetBottomGridPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetBottomGrid) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetBottomGrid_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetBottomGridPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetBottomGrid, Fixture, methodGetBottomGridPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetBottomGridPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetBottomGridLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GetBottomGridLayout_Method_Call_Internally(Type[] types)
        {
            var methodGetBottomGridLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetBottomGridLayout, Fixture, methodGetBottomGridLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetBottomGridLayout) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetBottomGridLayout_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.GetBottomGridLayout();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetBottomGridLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetBottomGridLayout_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetBottomGridLayoutPrametersTypes = null;
            object[] parametersOfGetBottomGridLayout = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, string>(_modelCacheInstance, MethodGetBottomGridLayout, parametersOfGetBottomGridLayout, methodGetBottomGridLayoutPrametersTypes);

            // Assert
            parametersOfGetBottomGridLayout.ShouldBeNull();
            methodGetBottomGridLayoutPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetBottomGridLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetBottomGridLayout_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetBottomGridLayoutPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetBottomGridLayout, Fixture, methodGetBottomGridLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetBottomGridLayoutPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetBottomGridLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetBottomGridLayout_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetBottomGridLayoutPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetBottomGridLayout, Fixture, methodGetBottomGridLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetBottomGridLayoutPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetBottomGridData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GetBottomGridData_Method_Call_Internally(Type[] types)
        {
            var methodGetBottomGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetBottomGridData, Fixture, methodGetBottomGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetBottomGridData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetBottomGridData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.GetBottomGridData();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetBottomGridData) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetBottomGridData_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetBottomGridDataPrametersTypes = null;
            object[] parametersOfGetBottomGridData = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetBottomGridData, methodGetBottomGridDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfGetBottomGridData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetBottomGridData.ShouldBeNull();
            methodGetBottomGridDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetBottomGridData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetBottomGridData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetBottomGridDataPrametersTypes = null;
            object[] parametersOfGetBottomGridData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, string>(_modelCacheInstance, MethodGetBottomGridData, parametersOfGetBottomGridData, methodGetBottomGridDataPrametersTypes);

            // Assert
            parametersOfGetBottomGridData.ShouldBeNull();
            methodGetBottomGridDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetBottomGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetBottomGridData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetBottomGridDataPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetBottomGridData, Fixture, methodGetBottomGridDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetBottomGridDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetBottomGridData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetBottomGridData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetBottomGridDataPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetBottomGridData, Fixture, methodGetBottomGridDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetBottomGridDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetBottomGridData) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetBottomGridData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetBottomGridData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SetFTEMode) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_SetFTEMode_Method_Call_Internally(Type[] types)
        {
            var methodSetFTEModePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSetFTEMode, Fixture, methodSetFTEModePrametersTypes);
        }

        #endregion

        #region Method Call : (SetFTEMode) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetFTEMode_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var FTEMode = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.SetFTEMode(FTEMode);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (SetFTEMode) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetFTEMode_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var FTEMode = CreateType<int>();
            var methodSetFTEModePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfSetFTEMode = { FTEMode };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetFTEMode, methodSetFTEModePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfSetFTEMode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetFTEMode.ShouldNotBeNull();
            parametersOfSetFTEMode.Length.ShouldBe(1);
            methodSetFTEModePrametersTypes.Length.ShouldBe(1);
            methodSetFTEModePrametersTypes.Length.ShouldBe(parametersOfSetFTEMode.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetFTEMode) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetFTEMode_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var FTEMode = CreateType<int>();
            var methodSetFTEModePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfSetFTEMode = { FTEMode };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodSetFTEMode, parametersOfSetFTEMode, methodSetFTEModePrametersTypes);

            // Assert
            parametersOfSetFTEMode.ShouldNotBeNull();
            parametersOfSetFTEMode.Length.ShouldBe(1);
            methodSetFTEModePrametersTypes.Length.ShouldBe(1);
            methodSetFTEModePrametersTypes.Length.ShouldBe(parametersOfSetFTEMode.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetFTEMode) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetFTEMode_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetFTEMode, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetFTEMode) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetFTEMode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetFTEModePrametersTypes = new Type[] { typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSetFTEMode, Fixture, methodSetFTEModePrametersTypes);

            // Assert
            methodSetFTEModePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetFTEMode) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetFTEMode_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetFTEMode, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFTEMode) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GetFTEMode_Method_Call_Internally(Type[] types)
        {
            var methodGetFTEModePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetFTEMode, Fixture, methodGetFTEModePrametersTypes);
        }

        #endregion

        #region Method Call : (GetFTEMode) (Return Type : int) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetFTEMode_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.GetFTEMode();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetFTEMode) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetFTEMode_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetFTEModePrametersTypes = null;
            object[] parametersOfGetFTEMode = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetFTEMode, methodGetFTEModePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfGetFTEMode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetFTEMode.ShouldBeNull();
            methodGetFTEModePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFTEMode) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetFTEMode_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetFTEModePrametersTypes = null;
            object[] parametersOfGetFTEMode = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, int>(_modelCacheInstance, MethodGetFTEMode, parametersOfGetFTEMode, methodGetFTEModePrametersTypes);

            // Assert
            parametersOfGetFTEMode.ShouldBeNull();
            methodGetFTEModePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFTEMode) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetFTEMode_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetFTEModePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetFTEMode, Fixture, methodGetFTEModePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetFTEModePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFTEMode) (Return Type : int) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetFTEMode_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetFTEModePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetFTEMode, Fixture, methodGetFTEModePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetFTEModePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFTEMode) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetFTEMode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetFTEModePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetFTEMode, Fixture, methodGetFTEModePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFTEModePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFTEMode) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetFTEMode_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFTEMode, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SetGanttMode) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_SetGanttMode_Method_Call_Internally(Type[] types)
        {
            var methodSetGanttModePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSetGanttMode, Fixture, methodSetGanttModePrametersTypes);
        }

        #endregion

        #region Method Call : (SetGanttMode) (Return Type : int) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetGanttMode_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var GanttMode = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.SetGanttMode(GanttMode);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (SetGanttMode) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetGanttMode_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var GanttMode = CreateType<int>();
            var methodSetGanttModePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfSetGanttMode = { GanttMode };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetGanttMode, methodSetGanttModePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfSetGanttMode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetGanttMode.ShouldNotBeNull();
            parametersOfSetGanttMode.Length.ShouldBe(1);
            methodSetGanttModePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetGanttMode) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetGanttMode_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var GanttMode = CreateType<int>();
            var methodSetGanttModePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfSetGanttMode = { GanttMode };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, int>(_modelCacheInstance, MethodSetGanttMode, parametersOfSetGanttMode, methodSetGanttModePrametersTypes);

            // Assert
            parametersOfSetGanttMode.ShouldNotBeNull();
            parametersOfSetGanttMode.Length.ShouldBe(1);
            methodSetGanttModePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetGanttMode) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetGanttMode_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSetGanttModePrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSetGanttMode, Fixture, methodSetGanttModePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodSetGanttModePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SetGanttMode) (Return Type : int) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetGanttMode_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodSetGanttModePrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSetGanttMode, Fixture, methodSetGanttModePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodSetGanttModePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SetGanttMode) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetGanttMode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetGanttModePrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSetGanttMode, Fixture, methodSetGanttModePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetGanttModePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetGanttMode) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetGanttMode_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetGanttMode, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SetGanttMode) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetGanttMode_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetGanttMode, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoSetGroupingFlag) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_DoSetGroupingFlag_Method_Call_Internally(Type[] types)
        {
            var methodDoSetGroupingFlagPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodDoSetGroupingFlag, Fixture, methodDoSetGroupingFlagPrametersTypes);
        }

        #endregion

        #region Method Call : (DoSetGroupingFlag) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DoSetGroupingFlag_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var GroupMode = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.DoSetGroupingFlag(GroupMode);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (DoSetGroupingFlag) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DoSetGroupingFlag_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var GroupMode = CreateType<int>();
            var methodDoSetGroupingFlagPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDoSetGroupingFlag = { GroupMode };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDoSetGroupingFlag, methodDoSetGroupingFlagPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfDoSetGroupingFlag);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDoSetGroupingFlag.ShouldNotBeNull();
            parametersOfDoSetGroupingFlag.Length.ShouldBe(1);
            methodDoSetGroupingFlagPrametersTypes.Length.ShouldBe(1);
            methodDoSetGroupingFlagPrametersTypes.Length.ShouldBe(parametersOfDoSetGroupingFlag.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoSetGroupingFlag) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DoSetGroupingFlag_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var GroupMode = CreateType<int>();
            var methodDoSetGroupingFlagPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDoSetGroupingFlag = { GroupMode };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodDoSetGroupingFlag, parametersOfDoSetGroupingFlag, methodDoSetGroupingFlagPrametersTypes);

            // Assert
            parametersOfDoSetGroupingFlag.ShouldNotBeNull();
            parametersOfDoSetGroupingFlag.Length.ShouldBe(1);
            methodDoSetGroupingFlagPrametersTypes.Length.ShouldBe(1);
            methodDoSetGroupingFlagPrametersTypes.Length.ShouldBe(parametersOfDoSetGroupingFlag.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoSetGroupingFlag) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DoSetGroupingFlag_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDoSetGroupingFlag, 0);
            const int parametersCount = 1;

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
        public void AUT_ModelCache_DoSetGroupingFlag_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDoSetGroupingFlagPrametersTypes = new Type[] { typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodDoSetGroupingFlag, Fixture, methodDoSetGroupingFlagPrametersTypes);

            // Assert
            methodDoSetGroupingFlagPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoSetGroupingFlag) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DoSetGroupingFlag_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDoSetGroupingFlag, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessTotals) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_ProcessTotals_Method_Call_Internally(Type[] types)
        {
            var methodProcessTotalsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodProcessTotals, Fixture, methodProcessTotalsPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessTotals) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ProcessTotals_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodProcessTotalsPrametersTypes = null;
            object[] parametersOfProcessTotals = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessTotals, methodProcessTotalsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfProcessTotals);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessTotals.ShouldBeNull();
            methodProcessTotalsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessTotals) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ProcessTotals_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodProcessTotalsPrametersTypes = null;
            object[] parametersOfProcessTotals = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodProcessTotals, parametersOfProcessTotals, methodProcessTotalsPrametersTypes);

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
        public void AUT_ModelCache_ProcessTotals_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodProcessTotalsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodProcessTotals, Fixture, methodProcessTotalsPrametersTypes);

            // Assert
            methodProcessTotalsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessTotals) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ProcessTotals_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessTotals, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreatePsuedoTarget) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_CreatePsuedoTarget_Method_Call_Internally(Type[] types)
        {
            var methodCreatePsuedoTargetPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodCreatePsuedoTarget, Fixture, methodCreatePsuedoTargetPrametersTypes);
        }

        #endregion

        #region Method Call : (CreatePsuedoTarget) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_CreatePsuedoTarget_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreatePsuedoTargetPrametersTypes = null;
            object[] parametersOfCreatePsuedoTarget = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreatePsuedoTarget, methodCreatePsuedoTargetPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfCreatePsuedoTarget);

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
        public void AUT_ModelCache_CreatePsuedoTarget_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreatePsuedoTargetPrametersTypes = null;
            object[] parametersOfCreatePsuedoTarget = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodCreatePsuedoTarget, parametersOfCreatePsuedoTarget, methodCreatePsuedoTargetPrametersTypes);

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
        public void AUT_ModelCache_CreatePsuedoTarget_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreatePsuedoTargetPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodCreatePsuedoTarget, Fixture, methodCreatePsuedoTargetPrametersTypes);

            // Assert
            methodCreatePsuedoTargetPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreatePsuedoTarget) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_CreatePsuedoTarget_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreatePsuedoTarget, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessTargets) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_ProcessTargets_Method_Call_Internally(Type[] types)
        {
            var methodProcessTargetsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodProcessTargets, Fixture, methodProcessTargetsPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessTargets) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ProcessTargets_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodProcessTargetsPrametersTypes = null;
            object[] parametersOfProcessTargets = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessTargets, methodProcessTargetsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfProcessTargets);

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
        public void AUT_ModelCache_ProcessTargets_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodProcessTargetsPrametersTypes = null;
            object[] parametersOfProcessTargets = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodProcessTargets, parametersOfProcessTargets, methodProcessTargetsPrametersTypes);

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
        public void AUT_ModelCache_ProcessTargets_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodProcessTargetsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodProcessTargets, Fixture, methodProcessTargetsPrametersTypes);

            // Assert
            methodProcessTargetsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessTargets) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_ProcessTargets_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessTargets, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedForRow) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_SetSelectedForRow_Method_Call_Internally(Type[] types)
        {
            var methodSetSelectedForRowPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSetSelectedForRow, Fixture, methodSetSelectedForRowPrametersTypes);
        }

        #endregion

        #region Method Call : (SetSelectedForRow) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetSelectedForRow_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Row = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.SetSelectedForRow(Row);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetSelectedForRow) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetSelectedForRow_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var Row = CreateType<string>();
            var methodSetSelectedForRowPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSetSelectedForRow = { Row };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetSelectedForRow, methodSetSelectedForRowPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfSetSelectedForRow);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetSelectedForRow.ShouldNotBeNull();
            parametersOfSetSelectedForRow.Length.ShouldBe(1);
            methodSetSelectedForRowPrametersTypes.Length.ShouldBe(1);
            methodSetSelectedForRowPrametersTypes.Length.ShouldBe(parametersOfSetSelectedForRow.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedForRow) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetSelectedForRow_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Row = CreateType<string>();
            var methodSetSelectedForRowPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSetSelectedForRow = { Row };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodSetSelectedForRow, parametersOfSetSelectedForRow, methodSetSelectedForRowPrametersTypes);

            // Assert
            parametersOfSetSelectedForRow.ShouldNotBeNull();
            parametersOfSetSelectedForRow.Length.ShouldBe(1);
            methodSetSelectedForRowPrametersTypes.Length.ShouldBe(1);
            methodSetSelectedForRowPrametersTypes.Length.ShouldBe(parametersOfSetSelectedForRow.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedForRow) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetSelectedForRow_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetSelectedForRow, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetSelectedForRow) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetSelectedForRow_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetSelectedForRowPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSetSelectedForRow, Fixture, methodSetSelectedForRowPrametersTypes);

            // Assert
            methodSetSelectedForRowPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedForRow) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetSelectedForRow_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetSelectedForRow, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoBarMove) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_DoBarMove_Method_Call_Internally(Type[] types)
        {
            var methodDoBarMovePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodDoBarMove, Fixture, methodDoBarMovePrametersTypes);
        }

        #endregion

        #region Method Call : (DoBarMove) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DoBarMove_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Row = CreateType<string>();
            var sStart = CreateType<string>();
            var sFinish = CreateType<string>();
            var retData = CreateType<ModelBarsChanged>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.DoBarMove(Row, sStart, sFinish, ref retData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DoBarMove) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DoBarMove_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var Row = CreateType<string>();
            var sStart = CreateType<string>();
            var sFinish = CreateType<string>();
            var retData = CreateType<ModelBarsChanged>();
            var methodDoBarMovePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(ModelBarsChanged) };
            object[] parametersOfDoBarMove = { Row, sStart, sFinish, retData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDoBarMove, methodDoBarMovePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfDoBarMove);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDoBarMove.ShouldNotBeNull();
            parametersOfDoBarMove.Length.ShouldBe(4);
            methodDoBarMovePrametersTypes.Length.ShouldBe(4);
            methodDoBarMovePrametersTypes.Length.ShouldBe(parametersOfDoBarMove.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DoBarMove) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DoBarMove_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Row = CreateType<string>();
            var sStart = CreateType<string>();
            var sFinish = CreateType<string>();
            var retData = CreateType<ModelBarsChanged>();
            var methodDoBarMovePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(ModelBarsChanged) };
            object[] parametersOfDoBarMove = { Row, sStart, sFinish, retData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodDoBarMove, parametersOfDoBarMove, methodDoBarMovePrametersTypes);

            // Assert
            parametersOfDoBarMove.ShouldNotBeNull();
            parametersOfDoBarMove.Length.ShouldBe(4);
            methodDoBarMovePrametersTypes.Length.ShouldBe(4);
            methodDoBarMovePrametersTypes.Length.ShouldBe(parametersOfDoBarMove.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoBarMove) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DoBarMove_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDoBarMove, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoBarMove) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DoBarMove_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDoBarMovePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(ModelBarsChanged) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodDoBarMove, Fixture, methodDoBarMovePrametersTypes);

            // Assert
            methodDoBarMovePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoBarMove) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DoBarMove_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDoBarMove, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoCopyVersion) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_DoCopyVersion_Method_Call_Internally(Type[] types)
        {
            var methodDoCopyVersionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodDoCopyVersion, Fixture, methodDoCopyVersionPrametersTypes);
        }

        #endregion

        #region Method Call : (DoCopyVersion) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DoCopyVersion_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sFrom = CreateType<string>();
            var sTo = CreateType<string>();
            var sPIs = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.DoCopyVersion(sFrom, sTo, sPIs);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DoCopyVersion) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DoCopyVersion_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sFrom = CreateType<string>();
            var sTo = CreateType<string>();
            var sPIs = CreateType<string>();
            var methodDoCopyVersionPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfDoCopyVersion = { sFrom, sTo, sPIs };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDoCopyVersion, methodDoCopyVersionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfDoCopyVersion);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDoCopyVersion.ShouldNotBeNull();
            parametersOfDoCopyVersion.Length.ShouldBe(3);
            methodDoCopyVersionPrametersTypes.Length.ShouldBe(3);
            methodDoCopyVersionPrametersTypes.Length.ShouldBe(parametersOfDoCopyVersion.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DoCopyVersion) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DoCopyVersion_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sFrom = CreateType<string>();
            var sTo = CreateType<string>();
            var sPIs = CreateType<string>();
            var methodDoCopyVersionPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfDoCopyVersion = { sFrom, sTo, sPIs };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodDoCopyVersion, parametersOfDoCopyVersion, methodDoCopyVersionPrametersTypes);

            // Assert
            parametersOfDoCopyVersion.ShouldNotBeNull();
            parametersOfDoCopyVersion.Length.ShouldBe(3);
            methodDoCopyVersionPrametersTypes.Length.ShouldBe(3);
            methodDoCopyVersionPrametersTypes.Length.ShouldBe(parametersOfDoCopyVersion.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoCopyVersion) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DoCopyVersion_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDoCopyVersion, 0);
            const int parametersCount = 3;

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
        public void AUT_ModelCache_DoCopyVersion_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDoCopyVersionPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodDoCopyVersion, Fixture, methodDoCopyVersionPrametersTypes);

            // Assert
            methodDoCopyVersionPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoCopyVersion) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DoCopyVersion_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDoCopyVersion, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFilterGridLayout) (Return Type : String) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GetFilterGridLayout_Method_Call_Internally(Type[] types)
        {
            var methodGetFilterGridLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetFilterGridLayout, Fixture, methodGetFilterGridLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFilterGridLayout) (Return Type : String) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetFilterGridLayout_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.GetFilterGridLayout();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetFilterGridLayout) (Return Type : String) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetFilterGridLayout_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetFilterGridLayoutPrametersTypes = null;
            object[] parametersOfGetFilterGridLayout = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFilterGridLayout, methodGetFilterGridLayoutPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ModelCache, String>(_modelCacheInstanceFixture, out exception1, parametersOfGetFilterGridLayout);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ModelCache, String>(_modelCacheInstance, MethodGetFilterGridLayout, parametersOfGetFilterGridLayout, methodGetFilterGridLayoutPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetFilterGridLayout.ShouldBeNull();
            methodGetFilterGridLayoutPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFilterGridLayout) (Return Type : String) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetFilterGridLayout_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetFilterGridLayoutPrametersTypes = null;
            object[] parametersOfGetFilterGridLayout = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetFilterGridLayout, methodGetFilterGridLayoutPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfGetFilterGridLayout);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetFilterGridLayout.ShouldBeNull();
            methodGetFilterGridLayoutPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFilterGridLayout) (Return Type : String) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetFilterGridLayout_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetFilterGridLayoutPrametersTypes = null;
            object[] parametersOfGetFilterGridLayout = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, String>(_modelCacheInstance, MethodGetFilterGridLayout, parametersOfGetFilterGridLayout, methodGetFilterGridLayoutPrametersTypes);

            // Assert
            parametersOfGetFilterGridLayout.ShouldBeNull();
            methodGetFilterGridLayoutPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFilterGridLayout) (Return Type : String) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetFilterGridLayout_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetFilterGridLayoutPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetFilterGridLayout, Fixture, methodGetFilterGridLayoutPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetFilterGridLayoutPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFilterGridLayout) (Return Type : String) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetFilterGridLayout_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetFilterGridLayoutPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetFilterGridLayout, Fixture, methodGetFilterGridLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFilterGridLayoutPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFilterGridLayout) (Return Type : String) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetFilterGridLayout_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFilterGridLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetFilterGridData) (Return Type : String) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GetFilterGridData_Method_Call_Internally(Type[] types)
        {
            var methodGetFilterGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetFilterGridData, Fixture, methodGetFilterGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFilterGridData) (Return Type : String) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetFilterGridData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.GetFilterGridData();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetFilterGridData) (Return Type : String) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetFilterGridData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetFilterGridDataPrametersTypes = null;
            object[] parametersOfGetFilterGridData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, String>(_modelCacheInstance, MethodGetFilterGridData, parametersOfGetFilterGridData, methodGetFilterGridDataPrametersTypes);

            // Assert
            parametersOfGetFilterGridData.ShouldBeNull();
            methodGetFilterGridDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFilterGridData) (Return Type : String) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetFilterGridData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetFilterGridDataPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetFilterGridData, Fixture, methodGetFilterGridDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFilterGridDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFilterGridData) (Return Type : String) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetFilterGridData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetFilterGridDataPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetFilterGridData, Fixture, methodGetFilterGridDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFilterGridDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetFilterData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_SetFilterData_Method_Call_Internally(Type[] types)
        {
            var methodSetFilterDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSetFilterData, Fixture, methodSetFilterDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SetFilterData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetFilterData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sFilterData = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.SetFilterData(sFilterData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetFilterData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetFilterData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sFilterData = CreateType<string>();
            var methodSetFilterDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSetFilterData = { sFilterData };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSetFilterData, methodSetFilterDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ModelCache, string>(_modelCacheInstanceFixture, out exception1, parametersOfSetFilterData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ModelCache, string>(_modelCacheInstance, MethodSetFilterData, parametersOfSetFilterData, methodSetFilterDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSetFilterData.ShouldNotBeNull();
            parametersOfSetFilterData.Length.ShouldBe(1);
            methodSetFilterDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SetFilterData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetFilterData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sFilterData = CreateType<string>();
            var methodSetFilterDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSetFilterData = { sFilterData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, string>(_modelCacheInstance, MethodSetFilterData, parametersOfSetFilterData, methodSetFilterDataPrametersTypes);

            // Assert
            parametersOfSetFilterData.ShouldNotBeNull();
            parametersOfSetFilterData.Length.ShouldBe(1);
            methodSetFilterDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetFilterData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetFilterData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSetFilterDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSetFilterData, Fixture, methodSetFilterDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSetFilterDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SetFilterData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetFilterData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetFilterDataPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSetFilterData, Fixture, methodSetFilterDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetFilterDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetFilterData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetFilterData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetFilterData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetFilterData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetFilterData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetFilterData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsFiltered) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_IsFiltered_Method_Call_Internally(Type[] types)
        {
            var methodIsFilteredPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodIsFiltered, Fixture, methodIsFilteredPrametersTypes);
        }

        #endregion

        #region Method Call : (IsFiltered) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_IsFiltered_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsFiltered, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (IsFiltered) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_IsFiltered_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsFiltered, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTotalGridLayout) (Return Type : String) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GetTotalGridLayout_Method_Call_Internally(Type[] types)
        {
            var methodGetTotalGridLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetTotalGridLayout, Fixture, methodGetTotalGridLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTotalGridLayout) (Return Type : String) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTotalGridLayout_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.GetTotalGridLayout();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetTotalGridLayout) (Return Type : String) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTotalGridLayout_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetTotalGridLayoutPrametersTypes = null;
            object[] parametersOfGetTotalGridLayout = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTotalGridLayout, methodGetTotalGridLayoutPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ModelCache, String>(_modelCacheInstanceFixture, out exception1, parametersOfGetTotalGridLayout);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ModelCache, String>(_modelCacheInstance, MethodGetTotalGridLayout, parametersOfGetTotalGridLayout, methodGetTotalGridLayoutPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetTotalGridLayout.ShouldBeNull();
            methodGetTotalGridLayoutPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTotalGridLayout) (Return Type : String) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTotalGridLayout_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetTotalGridLayoutPrametersTypes = null;
            object[] parametersOfGetTotalGridLayout = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTotalGridLayout, methodGetTotalGridLayoutPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfGetTotalGridLayout);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTotalGridLayout.ShouldBeNull();
            methodGetTotalGridLayoutPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTotalGridLayout) (Return Type : String) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTotalGridLayout_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetTotalGridLayoutPrametersTypes = null;
            object[] parametersOfGetTotalGridLayout = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, String>(_modelCacheInstance, MethodGetTotalGridLayout, parametersOfGetTotalGridLayout, methodGetTotalGridLayoutPrametersTypes);

            // Assert
            parametersOfGetTotalGridLayout.ShouldBeNull();
            methodGetTotalGridLayoutPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTotalGridLayout) (Return Type : String) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTotalGridLayout_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetTotalGridLayoutPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetTotalGridLayout, Fixture, methodGetTotalGridLayoutPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetTotalGridLayoutPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTotalGridLayout) (Return Type : String) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTotalGridLayout_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetTotalGridLayoutPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetTotalGridLayout, Fixture, methodGetTotalGridLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTotalGridLayoutPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTotalGridLayout) (Return Type : String) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTotalGridLayout_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTotalGridLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetCTCmpGridData) (Return Type : String) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GetCTCmpGridData_Method_Call_Internally(Type[] types)
        {
            var methodGetCTCmpGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetCTCmpGridData, Fixture, methodGetCTCmpGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCTCmpGridData) (Return Type : String) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetCTCmpGridData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.GetCTCmpGridData();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCTCmpGridData) (Return Type : String) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetCTCmpGridData_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetCTCmpGridDataPrametersTypes = null;
            object[] parametersOfGetCTCmpGridData = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCTCmpGridData, methodGetCTCmpGridDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfGetCTCmpGridData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCTCmpGridData.ShouldBeNull();
            methodGetCTCmpGridDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCTCmpGridData) (Return Type : String) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetCTCmpGridData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetCTCmpGridDataPrametersTypes = null;
            object[] parametersOfGetCTCmpGridData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, String>(_modelCacheInstance, MethodGetCTCmpGridData, parametersOfGetCTCmpGridData, methodGetCTCmpGridDataPrametersTypes);

            // Assert
            parametersOfGetCTCmpGridData.ShouldBeNull();
            methodGetCTCmpGridDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCTCmpGridData) (Return Type : String) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetCTCmpGridData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetCTCmpGridDataPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetCTCmpGridData, Fixture, methodGetCTCmpGridDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCTCmpGridDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCTCmpGridData) (Return Type : String) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetCTCmpGridData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetCTCmpGridDataPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetCTCmpGridData, Fixture, methodGetCTCmpGridDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCTCmpGridDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCTCmpGridData) (Return Type : String) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetCTCmpGridData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCTCmpGridData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SetCTCmpData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_SetCTCmpData_Method_Call_Internally(Type[] types)
        {
            var methodSetCTCmpDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSetCTCmpData, Fixture, methodSetCTCmpDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SetCTCmpData) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetCTCmpData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sCTCmpData = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.SetCTCmpData(sCTCmpData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetCTCmpData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetCTCmpData_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sCTCmpData = CreateType<string>();
            var methodSetCTCmpDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSetCTCmpData = { sCTCmpData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetCTCmpData, methodSetCTCmpDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfSetCTCmpData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetCTCmpData.ShouldNotBeNull();
            parametersOfSetCTCmpData.Length.ShouldBe(1);
            methodSetCTCmpDataPrametersTypes.Length.ShouldBe(1);
            methodSetCTCmpDataPrametersTypes.Length.ShouldBe(parametersOfSetCTCmpData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetCTCmpData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetCTCmpData_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sCTCmpData = CreateType<string>();
            var methodSetCTCmpDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSetCTCmpData = { sCTCmpData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodSetCTCmpData, parametersOfSetCTCmpData, methodSetCTCmpDataPrametersTypes);

            // Assert
            parametersOfSetCTCmpData.ShouldNotBeNull();
            parametersOfSetCTCmpData.Length.ShouldBe(1);
            methodSetCTCmpDataPrametersTypes.Length.ShouldBe(1);
            methodSetCTCmpDataPrametersTypes.Length.ShouldBe(parametersOfSetCTCmpData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetCTCmpData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetCTCmpData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetCTCmpData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetCTCmpData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetCTCmpData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetCTCmpDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSetCTCmpData, Fixture, methodSetCTCmpDataPrametersTypes);

            // Assert
            methodSetCTCmpDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetCTCmpData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetCTCmpData_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetCTCmpData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTotalGridData) (Return Type : String) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GetTotalGridData_Method_Call_Internally(Type[] types)
        {
            var methodGetTotalGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetTotalGridData, Fixture, methodGetTotalGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTotalGridData) (Return Type : String) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTotalGridData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.GetTotalGridData();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTotalGridData) (Return Type : String) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTotalGridData_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetTotalGridDataPrametersTypes = null;
            object[] parametersOfGetTotalGridData = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTotalGridData, methodGetTotalGridDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfGetTotalGridData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTotalGridData.ShouldBeNull();
            methodGetTotalGridDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTotalGridData) (Return Type : String) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTotalGridData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetTotalGridDataPrametersTypes = null;
            object[] parametersOfGetTotalGridData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, String>(_modelCacheInstance, MethodGetTotalGridData, parametersOfGetTotalGridData, methodGetTotalGridDataPrametersTypes);

            // Assert
            parametersOfGetTotalGridData.ShouldBeNull();
            methodGetTotalGridDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTotalGridData) (Return Type : String) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTotalGridData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetTotalGridDataPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetTotalGridData, Fixture, methodGetTotalGridDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTotalGridDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTotalGridData) (Return Type : String) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTotalGridData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetTotalGridDataPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetTotalGridData, Fixture, methodGetTotalGridDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTotalGridDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTotalGridData) (Return Type : String) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTotalGridData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTotalGridData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SetTotColsbasedonTotaling) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_SetTotColsbasedonTotaling_Method_Call_Internally(Type[] types)
        {
            var methodSetTotColsbasedonTotalingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSetTotColsbasedonTotaling, Fixture, methodSetTotColsbasedonTotalingPrametersTypes);
        }

        #endregion

        #region Method Call : (SetTotColsbasedonTotaling) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetTotColsbasedonTotaling_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodSetTotColsbasedonTotalingPrametersTypes = null;
            object[] parametersOfSetTotColsbasedonTotaling = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetTotColsbasedonTotaling, methodSetTotColsbasedonTotalingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfSetTotColsbasedonTotaling);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetTotColsbasedonTotaling.ShouldBeNull();
            methodSetTotColsbasedonTotalingPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTotColsbasedonTotaling) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetTotColsbasedonTotaling_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodSetTotColsbasedonTotalingPrametersTypes = null;
            object[] parametersOfSetTotColsbasedonTotaling = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodSetTotColsbasedonTotaling, parametersOfSetTotColsbasedonTotaling, methodSetTotColsbasedonTotalingPrametersTypes);

            // Assert
            parametersOfSetTotColsbasedonTotaling.ShouldBeNull();
            methodSetTotColsbasedonTotalingPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTotColsbasedonTotaling) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetTotColsbasedonTotaling_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodSetTotColsbasedonTotalingPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSetTotColsbasedonTotaling, Fixture, methodSetTotColsbasedonTotalingPrametersTypes);

            // Assert
            methodSetTotColsbasedonTotalingPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTotColsbasedonTotaling) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetTotColsbasedonTotaling_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetTotColsbasedonTotaling, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTotalData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_SetTotalData_Method_Call_Internally(Type[] types)
        {
            var methodSetTotalDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSetTotalData, Fixture, methodSetTotalDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SetTotalData) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetTotalData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sTotalData = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.SetTotalData(sTotalData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetTotalData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetTotalData_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sTotalData = CreateType<string>();
            var methodSetTotalDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSetTotalData = { sTotalData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetTotalData, methodSetTotalDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfSetTotalData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetTotalData.ShouldNotBeNull();
            parametersOfSetTotalData.Length.ShouldBe(1);
            methodSetTotalDataPrametersTypes.Length.ShouldBe(1);
            methodSetTotalDataPrametersTypes.Length.ShouldBe(parametersOfSetTotalData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetTotalData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetTotalData_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sTotalData = CreateType<string>();
            var methodSetTotalDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSetTotalData = { sTotalData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodSetTotalData, parametersOfSetTotalData, methodSetTotalDataPrametersTypes);

            // Assert
            parametersOfSetTotalData.ShouldNotBeNull();
            parametersOfSetTotalData.Length.ShouldBe(1);
            methodSetTotalDataPrametersTypes.Length.ShouldBe(1);
            methodSetTotalDataPrametersTypes.Length.ShouldBe(parametersOfSetTotalData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTotalData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetTotalData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetTotalData, 0);
            const int parametersCount = 1;

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
        public void AUT_ModelCache_SetTotalData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetTotalDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSetTotalData, Fixture, methodSetTotalDataPrametersTypes);

            // Assert
            methodSetTotalDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTotalData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetTotalData_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetTotalData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSortAndGroup) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GetSortAndGroup_Method_Call_Internally(Type[] types)
        {
            var methodGetSortAndGroupPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetSortAndGroup, Fixture, methodGetSortAndGroupPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSortAndGroup) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetSortAndGroup_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sng = CreateType<SortGroupDefn>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.GetSortAndGroup(ref sng);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetSortAndGroup) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetSortAndGroup_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sng = CreateType<SortGroupDefn>();
            var methodGetSortAndGroupPrametersTypes = new Type[] { typeof(SortGroupDefn) };
            object[] parametersOfGetSortAndGroup = { sng };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetSortAndGroup, methodGetSortAndGroupPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfGetSortAndGroup);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetSortAndGroup.ShouldNotBeNull();
            parametersOfGetSortAndGroup.Length.ShouldBe(1);
            methodGetSortAndGroupPrametersTypes.Length.ShouldBe(1);
            methodGetSortAndGroupPrametersTypes.Length.ShouldBe(parametersOfGetSortAndGroup.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetSortAndGroup) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetSortAndGroup_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sng = CreateType<SortGroupDefn>();
            var methodGetSortAndGroupPrametersTypes = new Type[] { typeof(SortGroupDefn) };
            object[] parametersOfGetSortAndGroup = { sng };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodGetSortAndGroup, parametersOfGetSortAndGroup, methodGetSortAndGroupPrametersTypes);

            // Assert
            parametersOfGetSortAndGroup.ShouldNotBeNull();
            parametersOfGetSortAndGroup.Length.ShouldBe(1);
            methodGetSortAndGroupPrametersTypes.Length.ShouldBe(1);
            methodGetSortAndGroupPrametersTypes.Length.ShouldBe(parametersOfGetSortAndGroup.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSortAndGroup) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetSortAndGroup_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (GetSortAndGroup) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetSortAndGroup_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSortAndGroupPrametersTypes = new Type[] { typeof(SortGroupDefn) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetSortAndGroup, Fixture, methodGetSortAndGroupPrametersTypes);

            // Assert
            methodGetSortAndGroupPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSortAndGroup) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetSortAndGroup_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSortAndGroup, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSortAndGroup) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_SetSortAndGroup_Method_Call_Internally(Type[] types)
        {
            var methodSetSortAndGroupPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSetSortAndGroup, Fixture, methodSetSortAndGroupPrametersTypes);
        }

        #endregion

        #region Method Call : (SetSortAndGroup) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetSortAndGroup_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sng = CreateType<SortGroupDefn>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.SetSortAndGroup(sng);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetSortAndGroup) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetSortAndGroup_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sng = CreateType<SortGroupDefn>();
            var methodSetSortAndGroupPrametersTypes = new Type[] { typeof(SortGroupDefn) };
            object[] parametersOfSetSortAndGroup = { sng };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodSetSortAndGroup, parametersOfSetSortAndGroup, methodSetSortAndGroupPrametersTypes);

            // Assert
            parametersOfSetSortAndGroup.ShouldNotBeNull();
            parametersOfSetSortAndGroup.Length.ShouldBe(1);
            methodSetSortAndGroupPrametersTypes.Length.ShouldBe(1);
            methodSetSortAndGroupPrametersTypes.Length.ShouldBe(parametersOfSetSortAndGroup.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSortAndGroup) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetSortAndGroup_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetSortAndGroup, 0);
            const int parametersCount = 1;

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
        public void AUT_ModelCache_SetSortAndGroup_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetSortAndGroupPrametersTypes = new Type[] { typeof(SortGroupDefn) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSetSortAndGroup, Fixture, methodSetSortAndGroupPrametersTypes);

            // Assert
            methodSetSortAndGroupPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSortAndGroup) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetSortAndGroup_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetSortAndGroup, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FormatExtraSort) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_FormatExtraSort_Method_Call_Internally(Type[] types)
        {
            var methodFormatExtraSortPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodFormatExtraSort, Fixture, methodFormatExtraSortPrametersTypes);
        }

        #endregion

        #region Method Call : (FormatExtraSort) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_FormatExtraSort_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sIn = CreateType<string>();
            var lt = CreateType<int>();
            var methodFormatExtraSortPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfFormatExtraSort = { sIn, lt };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFormatExtraSort, methodFormatExtraSortPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfFormatExtraSort);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFormatExtraSort.ShouldNotBeNull();
            parametersOfFormatExtraSort.Length.ShouldBe(2);
            methodFormatExtraSortPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FormatExtraSort) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_FormatExtraSort_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sIn = CreateType<string>();
            var lt = CreateType<int>();
            var methodFormatExtraSortPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfFormatExtraSort = { sIn, lt };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, string>(_modelCacheInstance, MethodFormatExtraSort, parametersOfFormatExtraSort, methodFormatExtraSortPrametersTypes);

            // Assert
            parametersOfFormatExtraSort.ShouldNotBeNull();
            parametersOfFormatExtraSort.Length.ShouldBe(2);
            methodFormatExtraSortPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FormatExtraSort) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_FormatExtraSort_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodFormatExtraSortPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodFormatExtraSort, Fixture, methodFormatExtraSortPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodFormatExtraSortPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (FormatExtraSort) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_FormatExtraSort_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFormatExtraSortPrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodFormatExtraSort, Fixture, methodFormatExtraSortPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFormatExtraSortPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FormatExtraSort) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_FormatExtraSort_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFormatExtraSort, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (FormatExtraSort) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_FormatExtraSort_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFormatExtraSort, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FormatExtraDisplay) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_FormatExtraDisplay_Method_Call_Internally(Type[] types)
        {
            var methodFormatExtraDisplayPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodFormatExtraDisplay, Fixture, methodFormatExtraDisplayPrametersTypes);
        }

        #endregion

        #region Method Call : (FormatExtraDisplay) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_FormatExtraDisplay_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sIn = CreateType<string>();
            var lt = CreateType<int>();
            var methodFormatExtraDisplayPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfFormatExtraDisplay = { sIn, lt };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFormatExtraDisplay, methodFormatExtraDisplayPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfFormatExtraDisplay);

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
        public void AUT_ModelCache_FormatExtraDisplay_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sIn = CreateType<string>();
            var lt = CreateType<int>();
            var methodFormatExtraDisplayPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfFormatExtraDisplay = { sIn, lt };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, string>(_modelCacheInstance, MethodFormatExtraDisplay, parametersOfFormatExtraDisplay, methodFormatExtraDisplayPrametersTypes);

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
        public void AUT_ModelCache_FormatExtraDisplay_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodFormatExtraDisplayPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodFormatExtraDisplay, Fixture, methodFormatExtraDisplayPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodFormatExtraDisplayPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (FormatExtraDisplay) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_FormatExtraDisplay_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFormatExtraDisplayPrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodFormatExtraDisplay, Fixture, methodFormatExtraDisplayPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFormatExtraDisplayPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FormatExtraDisplay) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_FormatExtraDisplay_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFormatExtraDisplay, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (FormatExtraDisplay) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_FormatExtraDisplay_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_ModelCache_FormatWork_Method_Call_Internally(Type[] types)
        {
            var methodFormatWorkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodFormatWork, Fixture, methodFormatWorkPrametersTypes);
        }

        #endregion

        #region Method Call : (FormatWork) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_FormatWork_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Hours = CreateType<double>();
            var methodFormatWorkPrametersTypes = new Type[] { typeof(double) };
            object[] parametersOfFormatWork = { Hours };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodFormatWork, methodFormatWorkPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ModelCache, string>(_modelCacheInstanceFixture, out exception1, parametersOfFormatWork);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ModelCache, string>(_modelCacheInstance, MethodFormatWork, parametersOfFormatWork, methodFormatWorkPrametersTypes);

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
        public void AUT_ModelCache_FormatWork_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Hours = CreateType<double>();
            var methodFormatWorkPrametersTypes = new Type[] { typeof(double) };
            object[] parametersOfFormatWork = { Hours };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, string>(_modelCacheInstance, MethodFormatWork, parametersOfFormatWork, methodFormatWorkPrametersTypes);

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
        public void AUT_ModelCache_FormatWork_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodFormatWorkPrametersTypes = new Type[] { typeof(double) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodFormatWork, Fixture, methodFormatWorkPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodFormatWorkPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (FormatWork) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_FormatWork_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFormatWorkPrametersTypes = new Type[] { typeof(double) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodFormatWork, Fixture, methodFormatWorkPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFormatWorkPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FormatWork) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_FormatWork_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFormatWork, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FormatWork) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_FormatWork_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_ModelCache_FormatDuration_Method_Call_Internally(Type[] types)
        {
            var methodFormatDurationPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodFormatDuration, Fixture, methodFormatDurationPrametersTypes);
        }

        #endregion

        #region Method Call : (FormatDuration) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_FormatDuration_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var minutes = CreateType<double>();
            var methodFormatDurationPrametersTypes = new Type[] { typeof(double) };
            object[] parametersOfFormatDuration = { minutes };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodFormatDuration, methodFormatDurationPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ModelCache, string>(_modelCacheInstanceFixture, out exception1, parametersOfFormatDuration);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ModelCache, string>(_modelCacheInstance, MethodFormatDuration, parametersOfFormatDuration, methodFormatDurationPrametersTypes);

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
        public void AUT_ModelCache_FormatDuration_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var minutes = CreateType<double>();
            var methodFormatDurationPrametersTypes = new Type[] { typeof(double) };
            object[] parametersOfFormatDuration = { minutes };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, string>(_modelCacheInstance, MethodFormatDuration, parametersOfFormatDuration, methodFormatDurationPrametersTypes);

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
        public void AUT_ModelCache_FormatDuration_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodFormatDurationPrametersTypes = new Type[] { typeof(double) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodFormatDuration, Fixture, methodFormatDurationPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodFormatDurationPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (FormatDuration) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_FormatDuration_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFormatDurationPrametersTypes = new Type[] { typeof(double) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodFormatDuration, Fixture, methodFormatDurationPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFormatDurationPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FormatDuration) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_FormatDuration_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFormatDuration, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FormatDuration) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_FormatDuration_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (GetColumnGridData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GetColumnGridData_Method_Call_Internally(Type[] types)
        {
            var methodGetColumnGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetColumnGridData, Fixture, methodGetColumnGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetColumnGridData) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetColumnGridData_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.GetColumnGridData();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetColumnGridData) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetColumnGridData_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetColumnGridDataPrametersTypes = null;
            object[] parametersOfGetColumnGridData = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetColumnGridData, methodGetColumnGridDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ModelCache, string>(_modelCacheInstanceFixture, out exception1, parametersOfGetColumnGridData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ModelCache, string>(_modelCacheInstance, MethodGetColumnGridData, parametersOfGetColumnGridData, methodGetColumnGridDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetColumnGridData.ShouldBeNull();
            methodGetColumnGridDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetColumnGridData) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetColumnGridData_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetColumnGridDataPrametersTypes = null;
            object[] parametersOfGetColumnGridData = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetColumnGridData, methodGetColumnGridDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfGetColumnGridData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetColumnGridData.ShouldBeNull();
            methodGetColumnGridDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetColumnGridData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetColumnGridData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetColumnGridDataPrametersTypes = null;
            object[] parametersOfGetColumnGridData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, string>(_modelCacheInstance, MethodGetColumnGridData, parametersOfGetColumnGridData, methodGetColumnGridDataPrametersTypes);

            // Assert
            parametersOfGetColumnGridData.ShouldBeNull();
            methodGetColumnGridDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetColumnGridData) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetColumnGridData_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetColumnGridDataPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetColumnGridData, Fixture, methodGetColumnGridDataPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetColumnGridDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetColumnGridData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetColumnGridData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetColumnGridDataPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetColumnGridData, Fixture, methodGetColumnGridDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetColumnGridDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetColumnGridData) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetColumnGridData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetColumnGridData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetColumnData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GetColumnData_Method_Call_Internally(Type[] types)
        {
            var methodGetColumnDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetColumnData, Fixture, methodGetColumnDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetColumnData) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetColumnData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sng = CreateType<SortGroupDefn>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.GetColumnData(ref sng);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetColumnData) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetColumnData_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sng = CreateType<SortGroupDefn>();
            var methodGetColumnDataPrametersTypes = new Type[] { typeof(SortGroupDefn) };
            object[] parametersOfGetColumnData = { sng };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetColumnData, methodGetColumnDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfGetColumnData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetColumnData.ShouldNotBeNull();
            parametersOfGetColumnData.Length.ShouldBe(1);
            methodGetColumnDataPrametersTypes.Length.ShouldBe(1);
            methodGetColumnDataPrametersTypes.Length.ShouldBe(parametersOfGetColumnData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetColumnData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetColumnData_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sng = CreateType<SortGroupDefn>();
            var methodGetColumnDataPrametersTypes = new Type[] { typeof(SortGroupDefn) };
            object[] parametersOfGetColumnData = { sng };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodGetColumnData, parametersOfGetColumnData, methodGetColumnDataPrametersTypes);

            // Assert
            parametersOfGetColumnData.ShouldNotBeNull();
            parametersOfGetColumnData.Length.ShouldBe(1);
            methodGetColumnDataPrametersTypes.Length.ShouldBe(1);
            methodGetColumnDataPrametersTypes.Length.ShouldBe(parametersOfGetColumnData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetColumnData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetColumnData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetColumnData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetColumnData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetColumnData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetColumnDataPrametersTypes = new Type[] { typeof(SortGroupDefn) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetColumnData, Fixture, methodGetColumnDataPrametersTypes);

            // Assert
            methodGetColumnDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetColumnData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetColumnData_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetColumnData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetColumnOrderData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_SetColumnOrderData_Method_Call_Internally(Type[] types)
        {
            var methodSetColumnOrderDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSetColumnOrderData, Fixture, methodSetColumnOrderDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SetColumnOrderData) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetColumnOrderData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sng = CreateType<SortGroupDefn>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.SetColumnOrderData(sng);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetColumnOrderData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetColumnOrderData_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sng = CreateType<SortGroupDefn>();
            var methodSetColumnOrderDataPrametersTypes = new Type[] { typeof(SortGroupDefn) };
            object[] parametersOfSetColumnOrderData = { sng };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetColumnOrderData, methodSetColumnOrderDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfSetColumnOrderData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetColumnOrderData.ShouldNotBeNull();
            parametersOfSetColumnOrderData.Length.ShouldBe(1);
            methodSetColumnOrderDataPrametersTypes.Length.ShouldBe(1);
            methodSetColumnOrderDataPrametersTypes.Length.ShouldBe(parametersOfSetColumnOrderData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetColumnOrderData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetColumnOrderData_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sng = CreateType<SortGroupDefn>();
            var methodSetColumnOrderDataPrametersTypes = new Type[] { typeof(SortGroupDefn) };
            object[] parametersOfSetColumnOrderData = { sng };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodSetColumnOrderData, parametersOfSetColumnOrderData, methodSetColumnOrderDataPrametersTypes);

            // Assert
            parametersOfSetColumnOrderData.ShouldNotBeNull();
            parametersOfSetColumnOrderData.Length.ShouldBe(1);
            methodSetColumnOrderDataPrametersTypes.Length.ShouldBe(1);
            methodSetColumnOrderDataPrametersTypes.Length.ShouldBe(parametersOfSetColumnOrderData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetColumnOrderData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetColumnOrderData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetColumnOrderData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetColumnOrderData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetColumnOrderData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetColumnOrderDataPrametersTypes = new Type[] { typeof(SortGroupDefn) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSetColumnOrderData, Fixture, methodSetColumnOrderDataPrametersTypes);

            // Assert
            methodSetColumnOrderDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetColumnOrderData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetColumnOrderData_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetColumnOrderData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetVersionsPILists) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GetVersionsPILists_Method_Call_Internally(Type[] types)
        {
            var methodGetVersionsPIListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetVersionsPILists, Fixture, methodGetVersionsPIListsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetVersionsPILists) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetVersionsPILists_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sng = CreateType<SortGroupDefn>();
            var fromVer = CreateType<int>();
            var toVer = CreateType<int>();
            var methodGetVersionsPIListsPrametersTypes = new Type[] { typeof(SortGroupDefn), typeof(int), typeof(int) };
            object[] parametersOfGetVersionsPILists = { sng, fromVer, toVer };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetVersionsPILists, methodGetVersionsPIListsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfGetVersionsPILists);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetVersionsPILists.ShouldNotBeNull();
            parametersOfGetVersionsPILists.Length.ShouldBe(3);
            methodGetVersionsPIListsPrametersTypes.Length.ShouldBe(3);
            methodGetVersionsPIListsPrametersTypes.Length.ShouldBe(parametersOfGetVersionsPILists.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetVersionsPILists) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetVersionsPILists_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sng = CreateType<SortGroupDefn>();
            var fromVer = CreateType<int>();
            var toVer = CreateType<int>();
            var methodGetVersionsPIListsPrametersTypes = new Type[] { typeof(SortGroupDefn), typeof(int), typeof(int) };
            object[] parametersOfGetVersionsPILists = { sng, fromVer, toVer };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodGetVersionsPILists, parametersOfGetVersionsPILists, methodGetVersionsPIListsPrametersTypes);

            // Assert
            parametersOfGetVersionsPILists.ShouldNotBeNull();
            parametersOfGetVersionsPILists.Length.ShouldBe(3);
            methodGetVersionsPIListsPrametersTypes.Length.ShouldBe(3);
            methodGetVersionsPIListsPrametersTypes.Length.ShouldBe(parametersOfGetVersionsPILists.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetVersionsPILists) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetVersionsPILists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetVersionsPILists, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetVersionsPILists) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetVersionsPILists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetVersionsPIListsPrametersTypes = new Type[] { typeof(SortGroupDefn), typeof(int), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetVersionsPILists, Fixture, methodGetVersionsPIListsPrametersTypes);

            // Assert
            methodGetVersionsPIListsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetVersionsPILists) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetVersionsPILists_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetVersionsPILists, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSaveVersions) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GetSaveVersions_Method_Call_Internally(Type[] types)
        {
            var methodGetSaveVersionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetSaveVersions, Fixture, methodGetSaveVersionsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSaveVersions) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetSaveVersions_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var versions = CreateType<List<ItemDefn>>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.GetSaveVersions(ref versions);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetSaveVersions) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetSaveVersions_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var versions = CreateType<List<ItemDefn>>();
            var methodGetSaveVersionsPrametersTypes = new Type[] { typeof(List<ItemDefn>) };
            object[] parametersOfGetSaveVersions = { versions };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetSaveVersions, methodGetSaveVersionsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfGetSaveVersions);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetSaveVersions.ShouldNotBeNull();
            parametersOfGetSaveVersions.Length.ShouldBe(1);
            methodGetSaveVersionsPrametersTypes.Length.ShouldBe(1);
            methodGetSaveVersionsPrametersTypes.Length.ShouldBe(parametersOfGetSaveVersions.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSaveVersions) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetSaveVersions_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var versions = CreateType<List<ItemDefn>>();
            var methodGetSaveVersionsPrametersTypes = new Type[] { typeof(List<ItemDefn>) };
            object[] parametersOfGetSaveVersions = { versions };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodGetSaveVersions, parametersOfGetSaveVersions, methodGetSaveVersionsPrametersTypes);

            // Assert
            parametersOfGetSaveVersions.ShouldNotBeNull();
            parametersOfGetSaveVersions.Length.ShouldBe(1);
            methodGetSaveVersionsPrametersTypes.Length.ShouldBe(1);
            methodGetSaveVersionsPrametersTypes.Length.ShouldBe(parametersOfGetSaveVersions.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSaveVersions) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetSaveVersions_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (GetSaveVersions) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetSaveVersions_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSaveVersionsPrametersTypes = new Type[] { typeof(List<ItemDefn>) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetSaveVersions, Fixture, methodGetSaveVersionsPrametersTypes);

            // Assert
            methodGetSaveVersionsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSaveVersions) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetSaveVersions_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSaveVersions, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTargets) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GetTargets_Method_Call_Internally(Type[] types)
        {
            var methodGetTargetsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetTargets, Fixture, methodGetTargetsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTargets) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTargets_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var targets = CreateType<List<ItemDefn>>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.GetTargets(ref targets);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTargets) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTargets_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var targets = CreateType<List<ItemDefn>>();
            var methodGetTargetsPrametersTypes = new Type[] { typeof(List<ItemDefn>) };
            object[] parametersOfGetTargets = { targets };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTargets, methodGetTargetsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfGetTargets);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTargets.ShouldNotBeNull();
            parametersOfGetTargets.Length.ShouldBe(1);
            methodGetTargetsPrametersTypes.Length.ShouldBe(1);
            methodGetTargetsPrametersTypes.Length.ShouldBe(parametersOfGetTargets.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTargets) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTargets_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var targets = CreateType<List<ItemDefn>>();
            var methodGetTargetsPrametersTypes = new Type[] { typeof(List<ItemDefn>) };
            object[] parametersOfGetTargets = { targets };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodGetTargets, parametersOfGetTargets, methodGetTargetsPrametersTypes);

            // Assert
            parametersOfGetTargets.ShouldNotBeNull();
            parametersOfGetTargets.Length.ShouldBe(1);
            methodGetTargetsPrametersTypes.Length.ShouldBe(1);
            methodGetTargetsPrametersTypes.Length.ShouldBe(parametersOfGetTargets.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTargets) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTargets_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTargets, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTargets) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTargets_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTargetsPrametersTypes = new Type[] { typeof(List<ItemDefn>) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetTargets, Fixture, methodGetTargetsPrametersTypes);

            // Assert
            methodGetTargetsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTargets) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTargets_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTargets, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveVersion) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_SaveVersion_Method_Call_Internally(Type[] types)
        {
            var methodSaveVersionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSaveVersion, Fixture, methodSaveVersionPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveVersion) (Return Type : int) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SaveVersion_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var version = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.SaveVersion(oDataAccess, version);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (SaveVersion) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SaveVersion_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var version = CreateType<string>();
            var methodSaveVersionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfSaveVersion = { oDataAccess, version };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveVersion, methodSaveVersionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ModelCache, int>(_modelCacheInstanceFixture, out exception1, parametersOfSaveVersion);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ModelCache, int>(_modelCacheInstance, MethodSaveVersion, parametersOfSaveVersion, methodSaveVersionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveVersion.ShouldNotBeNull();
            parametersOfSaveVersion.Length.ShouldBe(2);
            methodSaveVersionPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (SaveVersion) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SaveVersion_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var version = CreateType<string>();
            var methodSaveVersionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfSaveVersion = { oDataAccess, version };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveVersion, methodSaveVersionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ModelCache, int>(_modelCacheInstanceFixture, out exception1, parametersOfSaveVersion);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ModelCache, int>(_modelCacheInstance, MethodSaveVersion, parametersOfSaveVersion, methodSaveVersionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveVersion.ShouldNotBeNull();
            parametersOfSaveVersion.Length.ShouldBe(2);
            methodSaveVersionPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (SaveVersion) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SaveVersion_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var version = CreateType<string>();
            var methodSaveVersionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfSaveVersion = { oDataAccess, version };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSaveVersion, methodSaveVersionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfSaveVersion);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSaveVersion.ShouldNotBeNull();
            parametersOfSaveVersion.Length.ShouldBe(2);
            methodSaveVersionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveVersion) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SaveVersion_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var version = CreateType<string>();
            var methodSaveVersionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfSaveVersion = { oDataAccess, version };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, int>(_modelCacheInstance, MethodSaveVersion, parametersOfSaveVersion, methodSaveVersionPrametersTypes);

            // Assert
            parametersOfSaveVersion.ShouldNotBeNull();
            parametersOfSaveVersion.Length.ShouldBe(2);
            methodSaveVersionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveVersion) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SaveVersion_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSaveVersionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSaveVersion, Fixture, methodSaveVersionPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodSaveVersionPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (SaveVersion) (Return Type : int) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SaveVersion_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodSaveVersionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSaveVersion, Fixture, methodSaveVersionPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodSaveVersionPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (SaveVersion) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SaveVersion_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveVersionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSaveVersion, Fixture, methodSaveVersionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveVersionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveVersion) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SaveVersion_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveVersion, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SaveVersion) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SaveVersion_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveVersion, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPeriodsandVersions) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GetPeriodsandVersions_Method_Call_Internally(Type[] types)
        {
            var methodGetPeriodsandVersionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetPeriodsandVersions, Fixture, methodGetPeriodsandVersionsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPeriodsandVersions) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetPeriodsandVersions_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var poa = CreateType<PeriodsAndOptions>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.GetPeriodsandVersions(ref poa);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetPeriodsandVersions) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetPeriodsandVersions_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var poa = CreateType<PeriodsAndOptions>();
            var methodGetPeriodsandVersionsPrametersTypes = new Type[] { typeof(PeriodsAndOptions) };
            object[] parametersOfGetPeriodsandVersions = { poa };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetPeriodsandVersions, methodGetPeriodsandVersionsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfGetPeriodsandVersions);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetPeriodsandVersions.ShouldNotBeNull();
            parametersOfGetPeriodsandVersions.Length.ShouldBe(1);
            methodGetPeriodsandVersionsPrametersTypes.Length.ShouldBe(1);
            methodGetPeriodsandVersionsPrametersTypes.Length.ShouldBe(parametersOfGetPeriodsandVersions.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPeriodsandVersions) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetPeriodsandVersions_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var poa = CreateType<PeriodsAndOptions>();
            var methodGetPeriodsandVersionsPrametersTypes = new Type[] { typeof(PeriodsAndOptions) };
            object[] parametersOfGetPeriodsandVersions = { poa };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodGetPeriodsandVersions, parametersOfGetPeriodsandVersions, methodGetPeriodsandVersionsPrametersTypes);

            // Assert
            parametersOfGetPeriodsandVersions.ShouldNotBeNull();
            parametersOfGetPeriodsandVersions.Length.ShouldBe(1);
            methodGetPeriodsandVersionsPrametersTypes.Length.ShouldBe(1);
            methodGetPeriodsandVersionsPrametersTypes.Length.ShouldBe(parametersOfGetPeriodsandVersions.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPeriodsandVersions) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetPeriodsandVersions_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetPeriodsandVersions, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPeriodsandVersions) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetPeriodsandVersions_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPeriodsandVersionsPrametersTypes = new Type[] { typeof(PeriodsAndOptions) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetPeriodsandVersions, Fixture, methodGetPeriodsandVersionsPrametersTypes);

            // Assert
            methodGetPeriodsandVersionsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPeriodsandVersions) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetPeriodsandVersions_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPeriodsandVersions, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetPeriodsandVersions) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_SetPeriodsandVersions_Method_Call_Internally(Type[] types)
        {
            var methodSetPeriodsandVersionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSetPeriodsandVersions, Fixture, methodSetPeriodsandVersionsPrametersTypes);
        }

        #endregion

        #region Method Call : (SetPeriodsandVersions) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetPeriodsandVersions_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var poa = CreateType<PeriodsAndOptions>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.SetPeriodsandVersions(poa);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (SetPeriodsandVersions) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetPeriodsandVersions_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var poa = CreateType<PeriodsAndOptions>();
            var methodSetPeriodsandVersionsPrametersTypes = new Type[] { typeof(PeriodsAndOptions) };
            object[] parametersOfSetPeriodsandVersions = { poa };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetPeriodsandVersions, methodSetPeriodsandVersionsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfSetPeriodsandVersions);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetPeriodsandVersions.ShouldNotBeNull();
            parametersOfSetPeriodsandVersions.Length.ShouldBe(1);
            methodSetPeriodsandVersionsPrametersTypes.Length.ShouldBe(1);
            methodSetPeriodsandVersionsPrametersTypes.Length.ShouldBe(parametersOfSetPeriodsandVersions.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetPeriodsandVersions) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetPeriodsandVersions_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var poa = CreateType<PeriodsAndOptions>();
            var methodSetPeriodsandVersionsPrametersTypes = new Type[] { typeof(PeriodsAndOptions) };
            object[] parametersOfSetPeriodsandVersions = { poa };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodSetPeriodsandVersions, parametersOfSetPeriodsandVersions, methodSetPeriodsandVersionsPrametersTypes);

            // Assert
            parametersOfSetPeriodsandVersions.ShouldNotBeNull();
            parametersOfSetPeriodsandVersions.Length.ShouldBe(1);
            methodSetPeriodsandVersionsPrametersTypes.Length.ShouldBe(1);
            methodSetPeriodsandVersionsPrametersTypes.Length.ShouldBe(parametersOfSetPeriodsandVersions.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetPeriodsandVersions) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetPeriodsandVersions_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetPeriodsandVersions, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetPeriodsandVersions) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetPeriodsandVersions_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetPeriodsandVersionsPrametersTypes = new Type[] { typeof(PeriodsAndOptions) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSetPeriodsandVersions, Fixture, methodSetPeriodsandVersionsPrametersTypes);

            // Assert
            methodSetPeriodsandVersionsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetPeriodsandVersions) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetPeriodsandVersions_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetPeriodsandVersions, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_DeleteTarget_Method_Call_Internally(Type[] types)
        {
            var methodDeleteTargetPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodDeleteTarget, Fixture, methodDeleteTargetPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DeleteTarget_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var sTarget = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.DeleteTarget(oDataAccess, sTarget);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DeleteTarget_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var sTarget = CreateType<string>();
            var methodDeleteTargetPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfDeleteTarget = { oDataAccess, sTarget };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDeleteTarget, methodDeleteTargetPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfDeleteTarget);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDeleteTarget.ShouldNotBeNull();
            parametersOfDeleteTarget.Length.ShouldBe(2);
            methodDeleteTargetPrametersTypes.Length.ShouldBe(2);
            methodDeleteTargetPrametersTypes.Length.ShouldBe(parametersOfDeleteTarget.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DeleteTarget_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var sTarget = CreateType<string>();
            var methodDeleteTargetPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfDeleteTarget = { oDataAccess, sTarget };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodDeleteTarget, parametersOfDeleteTarget, methodDeleteTargetPrametersTypes);

            // Assert
            parametersOfDeleteTarget.ShouldNotBeNull();
            parametersOfDeleteTarget.Length.ShouldBe(2);
            methodDeleteTargetPrametersTypes.Length.ShouldBe(2);
            methodDeleteTargetPrametersTypes.Length.ShouldBe(parametersOfDeleteTarget.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DeleteTarget_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (DeleteTarget) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DeleteTarget_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteTargetPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodDeleteTarget, Fixture, methodDeleteTargetPrametersTypes);

            // Assert
            methodDeleteTargetPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DeleteTarget_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteTarget, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PrepareText) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_PrepareText_Method_Call_Internally(Type[] types)
        {
            var methodPrepareTextPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodPrepareText, Fixture, methodPrepareTextPrametersTypes);
        }

        #endregion

        #region Method Call : (PrepareText) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_PrepareText_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sText = CreateType<string>();
            var methodPrepareTextPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPrepareText = { sText };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPrepareText, methodPrepareTextPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfPrepareText);

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
        public void AUT_ModelCache_PrepareText_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sText = CreateType<string>();
            var methodPrepareTextPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPrepareText = { sText };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, string>(_modelCacheInstance, MethodPrepareText, parametersOfPrepareText, methodPrepareTextPrametersTypes);

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
        public void AUT_ModelCache_PrepareText_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodPrepareTextPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodPrepareText, Fixture, methodPrepareTextPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodPrepareTextPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (PrepareText) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_PrepareText_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPrepareTextPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodPrepareText, Fixture, methodPrepareTextPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPrepareTextPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PrepareText) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_PrepareText_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPrepareText, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (PrepareText) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_PrepareText_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (CreateTarget) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_CreateTarget_Method_Call_Internally(Type[] types)
        {
            var methodCreateTargetPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodCreateTarget, Fixture, methodCreateTargetPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateTarget) (Return Type : int) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_CreateTarget_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var sTargetName = CreateType<string>();
            var sTargetDesc = CreateType<string>();
            var localTarget = CreateType<int>();
            var lCopyfromTarget = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.CreateTarget(oDataAccess, sTargetName, sTargetDesc, localTarget, lCopyfromTarget);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (CreateTarget) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_CreateTarget_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var sTargetName = CreateType<string>();
            var sTargetDesc = CreateType<string>();
            var localTarget = CreateType<int>();
            var lCopyfromTarget = CreateType<int>();
            var methodCreateTargetPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string), typeof(int), typeof(int) };
            object[] parametersOfCreateTarget = { oDataAccess, sTargetName, sTargetDesc, localTarget, lCopyfromTarget };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCreateTarget, methodCreateTargetPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ModelCache, int>(_modelCacheInstanceFixture, out exception1, parametersOfCreateTarget);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ModelCache, int>(_modelCacheInstance, MethodCreateTarget, parametersOfCreateTarget, methodCreateTargetPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCreateTarget.ShouldNotBeNull();
            parametersOfCreateTarget.Length.ShouldBe(5);
            methodCreateTargetPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (CreateTarget) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_CreateTarget_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var sTargetName = CreateType<string>();
            var sTargetDesc = CreateType<string>();
            var localTarget = CreateType<int>();
            var lCopyfromTarget = CreateType<int>();
            var methodCreateTargetPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string), typeof(int), typeof(int) };
            object[] parametersOfCreateTarget = { oDataAccess, sTargetName, sTargetDesc, localTarget, lCopyfromTarget };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCreateTarget, methodCreateTargetPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ModelCache, int>(_modelCacheInstanceFixture, out exception1, parametersOfCreateTarget);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ModelCache, int>(_modelCacheInstance, MethodCreateTarget, parametersOfCreateTarget, methodCreateTargetPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfCreateTarget.ShouldNotBeNull();
            parametersOfCreateTarget.Length.ShouldBe(5);
            methodCreateTargetPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (CreateTarget) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_CreateTarget_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var sTargetName = CreateType<string>();
            var sTargetDesc = CreateType<string>();
            var localTarget = CreateType<int>();
            var lCopyfromTarget = CreateType<int>();
            var methodCreateTargetPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string), typeof(int), typeof(int) };
            object[] parametersOfCreateTarget = { oDataAccess, sTargetName, sTargetDesc, localTarget, lCopyfromTarget };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateTarget, methodCreateTargetPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfCreateTarget);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateTarget.ShouldNotBeNull();
            parametersOfCreateTarget.Length.ShouldBe(5);
            methodCreateTargetPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateTarget) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_CreateTarget_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var sTargetName = CreateType<string>();
            var sTargetDesc = CreateType<string>();
            var localTarget = CreateType<int>();
            var lCopyfromTarget = CreateType<int>();
            var methodCreateTargetPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string), typeof(int), typeof(int) };
            object[] parametersOfCreateTarget = { oDataAccess, sTargetName, sTargetDesc, localTarget, lCopyfromTarget };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, int>(_modelCacheInstance, MethodCreateTarget, parametersOfCreateTarget, methodCreateTargetPrametersTypes);

            // Assert
            parametersOfCreateTarget.ShouldNotBeNull();
            parametersOfCreateTarget.Length.ShouldBe(5);
            methodCreateTargetPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateTarget) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_CreateTarget_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCreateTargetPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string), typeof(int), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodCreateTarget, Fixture, methodCreateTargetPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodCreateTargetPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (CreateTarget) (Return Type : int) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_CreateTarget_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodCreateTargetPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string), typeof(int), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodCreateTarget, Fixture, methodCreateTargetPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodCreateTargetPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (CreateTarget) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_CreateTarget_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateTargetPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string), typeof(int), typeof(int) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodCreateTarget, Fixture, methodCreateTargetPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateTargetPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateTarget) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_CreateTarget_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateTarget, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (CreateTarget) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_CreateTarget_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (BuildCatJSon) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_BuildCatJSon_Method_Call_Internally(Type[] types)
        {
            var methodBuildCatJSonPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodBuildCatJSon, Fixture, methodBuildCatJSonPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildCatJSon) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_BuildCatJSon_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var rdata = CreateType<CSRatesAndCategory>();
            var index = CreateType<int>();
            var max = CreateType<int>();
            var methodBuildCatJSonPrametersTypes = new Type[] { typeof(CSRatesAndCategory), typeof(int), typeof(int) };
            object[] parametersOfBuildCatJSon = { rdata, index, max };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, string>(_modelCacheInstance, MethodBuildCatJSon, parametersOfBuildCatJSon, methodBuildCatJSonPrametersTypes);

            // Assert
            parametersOfBuildCatJSon.ShouldNotBeNull();
            parametersOfBuildCatJSon.Length.ShouldBe(3);
            methodBuildCatJSonPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildCatJSon) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_BuildCatJSon_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildCatJSonPrametersTypes = new Type[] { typeof(CSRatesAndCategory), typeof(int), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodBuildCatJSon, Fixture, methodBuildCatJSonPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildCatJSonPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (BuildCatJSon) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_BuildCatJSon_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildCatJSonPrametersTypes = new Type[] { typeof(CSRatesAndCategory), typeof(int), typeof(int) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodBuildCatJSon, Fixture, methodBuildCatJSonPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildCatJSonPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildCatJSon) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_BuildCatJSon_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildCatJSon, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RatesAndCategory) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_RatesAndCategory_Method_Call_Internally(Type[] types)
        {
            var methodRatesAndCategoryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodRatesAndCategory, Fixture, methodRatesAndCategoryPrametersTypes);
        }

        #endregion

        #region Method Call : (RatesAndCategory) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_RatesAndCategory_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var rdata = CreateType<CSRatesAndCategory>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.RatesAndCategory(ref rdata);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RatesAndCategory) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_RatesAndCategory_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var rdata = CreateType<CSRatesAndCategory>();
            var methodRatesAndCategoryPrametersTypes = new Type[] { typeof(CSRatesAndCategory) };
            object[] parametersOfRatesAndCategory = { rdata };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRatesAndCategory, methodRatesAndCategoryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfRatesAndCategory);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRatesAndCategory.ShouldNotBeNull();
            parametersOfRatesAndCategory.Length.ShouldBe(1);
            methodRatesAndCategoryPrametersTypes.Length.ShouldBe(1);
            methodRatesAndCategoryPrametersTypes.Length.ShouldBe(parametersOfRatesAndCategory.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RatesAndCategory) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_RatesAndCategory_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var rdata = CreateType<CSRatesAndCategory>();
            var methodRatesAndCategoryPrametersTypes = new Type[] { typeof(CSRatesAndCategory) };
            object[] parametersOfRatesAndCategory = { rdata };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodRatesAndCategory, parametersOfRatesAndCategory, methodRatesAndCategoryPrametersTypes);

            // Assert
            parametersOfRatesAndCategory.ShouldNotBeNull();
            parametersOfRatesAndCategory.Length.ShouldBe(1);
            methodRatesAndCategoryPrametersTypes.Length.ShouldBe(1);
            methodRatesAndCategoryPrametersTypes.Length.ShouldBe(parametersOfRatesAndCategory.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RatesAndCategory) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_RatesAndCategory_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRatesAndCategory, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RatesAndCategory) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_RatesAndCategory_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRatesAndCategoryPrametersTypes = new Type[] { typeof(CSRatesAndCategory) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodRatesAndCategory, Fixture, methodRatesAndCategoryPrametersTypes);

            // Assert
            methodRatesAndCategoryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RatesAndCategory) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_RatesAndCategory_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRatesAndCategory, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_PrepareTargetData_Method_Call_Internally(Type[] types)
        {
            var methodPrepareTargetDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodPrepareTargetData, Fixture, methodPrepareTargetDataPrametersTypes);
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_PrepareTargetData_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var targetID = CreateType<int>();
            var targetData = CreateType<CSTargetData>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.PrepareTargetData(oDataAccess, targetID, ref targetData);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_PrepareTargetData_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var targetID = CreateType<int>();
            var targetData = CreateType<CSTargetData>();
            var methodPrepareTargetDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(int), typeof(CSTargetData) };
            object[] parametersOfPrepareTargetData = { oDataAccess, targetID, targetData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPrepareTargetData, methodPrepareTargetDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfPrepareTargetData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPrepareTargetData.ShouldNotBeNull();
            parametersOfPrepareTargetData.Length.ShouldBe(3);
            methodPrepareTargetDataPrametersTypes.Length.ShouldBe(3);
            methodPrepareTargetDataPrametersTypes.Length.ShouldBe(parametersOfPrepareTargetData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_PrepareTargetData_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var targetID = CreateType<int>();
            var targetData = CreateType<CSTargetData>();
            var methodPrepareTargetDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(int), typeof(CSTargetData) };
            object[] parametersOfPrepareTargetData = { oDataAccess, targetID, targetData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodPrepareTargetData, parametersOfPrepareTargetData, methodPrepareTargetDataPrametersTypes);

            // Assert
            parametersOfPrepareTargetData.ShouldNotBeNull();
            parametersOfPrepareTargetData.Length.ShouldBe(3);
            methodPrepareTargetDataPrametersTypes.Length.ShouldBe(3);
            methodPrepareTargetDataPrametersTypes.Length.ShouldBe(parametersOfPrepareTargetData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_PrepareTargetData_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (PrepareTargetData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_PrepareTargetData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPrepareTargetDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(int), typeof(CSTargetData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodPrepareTargetData, Fixture, methodPrepareTargetDataPrametersTypes);

            // Assert
            methodPrepareTargetDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PrepareTargetData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_PrepareTargetData_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPrepareTargetData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadVersionTargetData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_LoadVersionTargetData_Method_Call_Internally(Type[] types)
        {
            var methodLoadVersionTargetDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodLoadVersionTargetData, Fixture, methodLoadVersionTargetDataPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadVersionTargetData) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadVersionTargetData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var VersID = CreateType<int>();
            var targetData = CreateType<CSTargetData>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.LoadVersionTargetData(oDataAccess, VersID, ref targetData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (LoadVersionTargetData) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadVersionTargetData_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var VersID = CreateType<int>();
            var targetData = CreateType<CSTargetData>();
            var methodLoadVersionTargetDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(int), typeof(CSTargetData) };
            object[] parametersOfLoadVersionTargetData = { oDataAccess, VersID, targetData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadVersionTargetData, methodLoadVersionTargetDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfLoadVersionTargetData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadVersionTargetData.ShouldNotBeNull();
            parametersOfLoadVersionTargetData.Length.ShouldBe(3);
            methodLoadVersionTargetDataPrametersTypes.Length.ShouldBe(3);
            methodLoadVersionTargetDataPrametersTypes.Length.ShouldBe(parametersOfLoadVersionTargetData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadVersionTargetData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadVersionTargetData_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var VersID = CreateType<int>();
            var targetData = CreateType<CSTargetData>();
            var methodLoadVersionTargetDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(int), typeof(CSTargetData) };
            object[] parametersOfLoadVersionTargetData = { oDataAccess, VersID, targetData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodLoadVersionTargetData, parametersOfLoadVersionTargetData, methodLoadVersionTargetDataPrametersTypes);

            // Assert
            parametersOfLoadVersionTargetData.ShouldNotBeNull();
            parametersOfLoadVersionTargetData.Length.ShouldBe(3);
            methodLoadVersionTargetDataPrametersTypes.Length.ShouldBe(3);
            methodLoadVersionTargetDataPrametersTypes.Length.ShouldBe(parametersOfLoadVersionTargetData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadVersionTargetData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadVersionTargetData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLoadVersionTargetData, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LoadVersionTargetData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadVersionTargetData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLoadVersionTargetDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(int), typeof(CSTargetData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodLoadVersionTargetData, Fixture, methodLoadVersionTargetDataPrametersTypes);

            // Assert
            methodLoadVersionTargetDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadVersionTargetData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadVersionTargetData_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadVersionTargetData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildTargetKey) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_BuildTargetKey_Method_Call_Internally(Type[] types)
        {
            var methodBuildTargetKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodBuildTargetKey, Fixture, methodBuildTargetKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildTargetKey) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_BuildTargetKey_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildTargetKey, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildTargetKey) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_BuildTargetKey_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildTargetKey, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTargetGridLayout) (Return Type : String) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GetTargetGridLayout_Method_Call_Internally(Type[] types)
        {
            var methodGetTargetGridLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetTargetGridLayout, Fixture, methodGetTargetGridLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTargetGridLayout) (Return Type : String) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTargetGridLayout_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.GetTargetGridLayout();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTargetGridLayout) (Return Type : String) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTargetGridLayout_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetTargetGridLayoutPrametersTypes = null;
            object[] parametersOfGetTargetGridLayout = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTargetGridLayout, methodGetTargetGridLayoutPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ModelCache, String>(_modelCacheInstanceFixture, out exception1, parametersOfGetTargetGridLayout);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ModelCache, String>(_modelCacheInstance, MethodGetTargetGridLayout, parametersOfGetTargetGridLayout, methodGetTargetGridLayoutPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTargetGridLayout.ShouldBeNull();
            methodGetTargetGridLayoutPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTargetGridLayout) (Return Type : String) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTargetGridLayout_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetTargetGridLayoutPrametersTypes = null;
            object[] parametersOfGetTargetGridLayout = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, String>(_modelCacheInstance, MethodGetTargetGridLayout, parametersOfGetTargetGridLayout, methodGetTargetGridLayoutPrametersTypes);

            // Assert
            parametersOfGetTargetGridLayout.ShouldBeNull();
            methodGetTargetGridLayoutPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTargetGridLayout) (Return Type : String) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTargetGridLayout_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetTargetGridLayoutPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetTargetGridLayout, Fixture, methodGetTargetGridLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTargetGridLayoutPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTargetGridLayout) (Return Type : String) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTargetGridLayout_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetTargetGridLayoutPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetTargetGridLayout, Fixture, methodGetTargetGridLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTargetGridLayoutPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTargetGridLayout) (Return Type : String) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTargetGridLayout_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTargetGridLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTargetGridData) (Return Type : String) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GetTargetGridData_Method_Call_Internally(Type[] types)
        {
            var methodGetTargetGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetTargetGridData, Fixture, methodGetTargetGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTargetGridData) (Return Type : String) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTargetGridData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.GetTargetGridData();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTargetGridData) (Return Type : String) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTargetGridData_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetTargetGridDataPrametersTypes = null;
            object[] parametersOfGetTargetGridData = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTargetGridData, methodGetTargetGridDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfGetTargetGridData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTargetGridData.ShouldBeNull();
            methodGetTargetGridDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTargetGridData) (Return Type : String) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTargetGridData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetTargetGridDataPrametersTypes = null;
            object[] parametersOfGetTargetGridData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, String>(_modelCacheInstance, MethodGetTargetGridData, parametersOfGetTargetGridData, methodGetTargetGridDataPrametersTypes);

            // Assert
            parametersOfGetTargetGridData.ShouldBeNull();
            methodGetTargetGridDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTargetGridData) (Return Type : String) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTargetGridData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetTargetGridDataPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetTargetGridData, Fixture, methodGetTargetGridDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTargetGridDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTargetGridData) (Return Type : String) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTargetGridData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetTargetGridDataPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetTargetGridData, Fixture, methodGetTargetGridDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTargetGridDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTargetGridData) (Return Type : String) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetTargetGridData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTargetGridData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SaveTargetData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_SaveTargetData_Method_Call_Internally(Type[] types)
        {
            var methodSaveTargetDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSaveTargetData, Fixture, methodSaveTargetDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveTargetData) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SaveTargetData_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var TargetID = CreateType<int>();
            var targetData = CreateType<CSTargetData>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.SaveTargetData(oDataAccess, TargetID, targetData);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (SaveTargetData) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SaveTargetData_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var TargetID = CreateType<int>();
            var targetData = CreateType<CSTargetData>();
            var methodSaveTargetDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(int), typeof(CSTargetData) };
            object[] parametersOfSaveTargetData = { oDataAccess, TargetID, targetData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSaveTargetData, methodSaveTargetDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfSaveTargetData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSaveTargetData.ShouldNotBeNull();
            parametersOfSaveTargetData.Length.ShouldBe(3);
            methodSaveTargetDataPrametersTypes.Length.ShouldBe(3);
            methodSaveTargetDataPrametersTypes.Length.ShouldBe(parametersOfSaveTargetData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveTargetData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SaveTargetData_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var TargetID = CreateType<int>();
            var targetData = CreateType<CSTargetData>();
            var methodSaveTargetDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(int), typeof(CSTargetData) };
            object[] parametersOfSaveTargetData = { oDataAccess, TargetID, targetData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodSaveTargetData, parametersOfSaveTargetData, methodSaveTargetDataPrametersTypes);

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
        public void AUT_ModelCache_SaveTargetData_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ModelCache_SaveTargetData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveTargetDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(int), typeof(CSTargetData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSaveTargetData, Fixture, methodSaveTargetDataPrametersTypes);

            // Assert
            methodSaveTargetDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveTargetData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SaveTargetData_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveTargetData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetShowRemainingFlag) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_SetShowRemainingFlag_Method_Call_Internally(Type[] types)
        {
            var methodSetShowRemainingFlagPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSetShowRemainingFlag, Fixture, methodSetShowRemainingFlagPrametersTypes);
        }

        #endregion

        #region Method Call : (SetShowRemainingFlag) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetShowRemainingFlag_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var bVal = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.SetShowRemainingFlag(bVal);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (SetShowRemainingFlag) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetShowRemainingFlag_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var bVal = CreateType<bool>();
            var methodSetShowRemainingFlagPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfSetShowRemainingFlag = { bVal };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetShowRemainingFlag, methodSetShowRemainingFlagPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfSetShowRemainingFlag);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetShowRemainingFlag.ShouldNotBeNull();
            parametersOfSetShowRemainingFlag.Length.ShouldBe(1);
            methodSetShowRemainingFlagPrametersTypes.Length.ShouldBe(1);
            methodSetShowRemainingFlagPrametersTypes.Length.ShouldBe(parametersOfSetShowRemainingFlag.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetShowRemainingFlag) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetShowRemainingFlag_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var bVal = CreateType<bool>();
            var methodSetShowRemainingFlagPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfSetShowRemainingFlag = { bVal };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodSetShowRemainingFlag, parametersOfSetShowRemainingFlag, methodSetShowRemainingFlagPrametersTypes);

            // Assert
            parametersOfSetShowRemainingFlag.ShouldNotBeNull();
            parametersOfSetShowRemainingFlag.Length.ShouldBe(1);
            methodSetShowRemainingFlagPrametersTypes.Length.ShouldBe(1);
            methodSetShowRemainingFlagPrametersTypes.Length.ShouldBe(parametersOfSetShowRemainingFlag.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetShowRemainingFlag) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetShowRemainingFlag_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetShowRemainingFlag, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetShowRemainingFlag) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetShowRemainingFlag_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetShowRemainingFlagPrametersTypes = new Type[] { typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSetShowRemainingFlag, Fixture, methodSetShowRemainingFlagPrametersTypes);

            // Assert
            methodSetShowRemainingFlagPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetShowRemainingFlag) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SetShowRemainingFlag_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetShowRemainingFlag, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLegendGridLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GetLegendGridLayout_Method_Call_Internally(Type[] types)
        {
            var methodGetLegendGridLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetLegendGridLayout, Fixture, methodGetLegendGridLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLegendGridLayout) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetLegendGridLayout_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.GetLegendGridLayout();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetLegendGridLayout) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetLegendGridLayout_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetLegendGridLayoutPrametersTypes = null;
            object[] parametersOfGetLegendGridLayout = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetLegendGridLayout, methodGetLegendGridLayoutPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ModelCache, string>(_modelCacheInstanceFixture, out exception1, parametersOfGetLegendGridLayout);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ModelCache, string>(_modelCacheInstance, MethodGetLegendGridLayout, parametersOfGetLegendGridLayout, methodGetLegendGridLayoutPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetLegendGridLayout.ShouldBeNull();
            methodGetLegendGridLayoutPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLegendGridLayout) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetLegendGridLayout_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetLegendGridLayoutPrametersTypes = null;
            object[] parametersOfGetLegendGridLayout = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetLegendGridLayout, methodGetLegendGridLayoutPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfGetLegendGridLayout);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetLegendGridLayout.ShouldBeNull();
            methodGetLegendGridLayoutPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLegendGridLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetLegendGridLayout_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetLegendGridLayoutPrametersTypes = null;
            object[] parametersOfGetLegendGridLayout = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, string>(_modelCacheInstance, MethodGetLegendGridLayout, parametersOfGetLegendGridLayout, methodGetLegendGridLayoutPrametersTypes);

            // Assert
            parametersOfGetLegendGridLayout.ShouldBeNull();
            methodGetLegendGridLayoutPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLegendGridLayout) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetLegendGridLayout_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetLegendGridLayoutPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetLegendGridLayout, Fixture, methodGetLegendGridLayoutPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetLegendGridLayoutPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLegendGridLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetLegendGridLayout_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetLegendGridLayoutPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetLegendGridLayout, Fixture, methodGetLegendGridLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLegendGridLayoutPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLegendGridLayout) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetLegendGridLayout_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLegendGridLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetLegendGridData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GetLegendGridData_Method_Call_Internally(Type[] types)
        {
            var methodGetLegendGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetLegendGridData, Fixture, methodGetLegendGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLegendGridData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetLegendGridData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.GetLegendGridData();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetLegendGridData) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetLegendGridData_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetLegendGridDataPrametersTypes = null;
            object[] parametersOfGetLegendGridData = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetLegendGridData, methodGetLegendGridDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfGetLegendGridData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetLegendGridData.ShouldBeNull();
            methodGetLegendGridDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLegendGridData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetLegendGridData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetLegendGridDataPrametersTypes = null;
            object[] parametersOfGetLegendGridData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, string>(_modelCacheInstance, MethodGetLegendGridData, parametersOfGetLegendGridData, methodGetLegendGridDataPrametersTypes);

            // Assert
            parametersOfGetLegendGridData.ShouldBeNull();
            methodGetLegendGridDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLegendGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetLegendGridData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetLegendGridDataPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetLegendGridData, Fixture, methodGetLegendGridDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLegendGridDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLegendGridData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetLegendGridData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetLegendGridDataPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetLegendGridData, Fixture, methodGetLegendGridDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLegendGridDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLegendGridData) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetLegendGridData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLegendGridData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (LoadUserViewData) (Return Type : List<ItemDefn>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_LoadUserViewData_Method_Call_Internally(Type[] types)
        {
            var methodLoadUserViewDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodLoadUserViewData, Fixture, methodLoadUserViewDataPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadUserViewData) (Return Type : List<ItemDefn>) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadUserViewData_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.LoadUserViewData();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (LoadUserViewData) (Return Type : List<ItemDefn>) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadUserViewData_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodLoadUserViewDataPrametersTypes = null;
            object[] parametersOfLoadUserViewData = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodLoadUserViewData, methodLoadUserViewDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ModelCache, List<ItemDefn>>(_modelCacheInstanceFixture, out exception1, parametersOfLoadUserViewData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ModelCache, List<ItemDefn>>(_modelCacheInstance, MethodLoadUserViewData, parametersOfLoadUserViewData, methodLoadUserViewDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfLoadUserViewData.ShouldBeNull();
            methodLoadUserViewDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (LoadUserViewData) (Return Type : List<ItemDefn>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadUserViewData_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodLoadUserViewDataPrametersTypes = null;
            object[] parametersOfLoadUserViewData = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadUserViewData, methodLoadUserViewDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfLoadUserViewData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadUserViewData.ShouldBeNull();
            methodLoadUserViewDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadUserViewData) (Return Type : List<ItemDefn>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadUserViewData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodLoadUserViewDataPrametersTypes = null;
            object[] parametersOfLoadUserViewData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, List<ItemDefn>>(_modelCacheInstance, MethodLoadUserViewData, parametersOfLoadUserViewData, methodLoadUserViewDataPrametersTypes);

            // Assert
            parametersOfLoadUserViewData.ShouldBeNull();
            methodLoadUserViewDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadUserViewData) (Return Type : List<ItemDefn>) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadUserViewData_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodLoadUserViewDataPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodLoadUserViewData, Fixture, methodLoadUserViewDataPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodLoadUserViewDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (LoadUserViewData) (Return Type : List<ItemDefn>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadUserViewData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodLoadUserViewDataPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodLoadUserViewData, Fixture, methodLoadUserViewDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodLoadUserViewDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (LoadUserViewData) (Return Type : List<ItemDefn>) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadUserViewData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadUserViewData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (DeleteUserViewData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_DeleteUserViewData_Method_Call_Internally(Type[] types)
        {
            var methodDeleteUserViewDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodDeleteUserViewData, Fixture, methodDeleteUserViewDataPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteUserViewData) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DeleteUserViewData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var sviewName = CreateType<string>();
            var localflag = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.DeleteUserViewData(oDataAccess, sviewName, localflag);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteUserViewData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DeleteUserViewData_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var sviewName = CreateType<string>();
            var localflag = CreateType<int>();
            var methodDeleteUserViewDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(int) };
            object[] parametersOfDeleteUserViewData = { oDataAccess, sviewName, localflag };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDeleteUserViewData, methodDeleteUserViewDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfDeleteUserViewData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDeleteUserViewData.ShouldNotBeNull();
            parametersOfDeleteUserViewData.Length.ShouldBe(3);
            methodDeleteUserViewDataPrametersTypes.Length.ShouldBe(3);
            methodDeleteUserViewDataPrametersTypes.Length.ShouldBe(parametersOfDeleteUserViewData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteUserViewData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DeleteUserViewData_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var sviewName = CreateType<string>();
            var localflag = CreateType<int>();
            var methodDeleteUserViewDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(int) };
            object[] parametersOfDeleteUserViewData = { oDataAccess, sviewName, localflag };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodDeleteUserViewData, parametersOfDeleteUserViewData, methodDeleteUserViewDataPrametersTypes);

            // Assert
            parametersOfDeleteUserViewData.ShouldNotBeNull();
            parametersOfDeleteUserViewData.Length.ShouldBe(3);
            methodDeleteUserViewDataPrametersTypes.Length.ShouldBe(3);
            methodDeleteUserViewDataPrametersTypes.Length.ShouldBe(parametersOfDeleteUserViewData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteUserViewData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DeleteUserViewData_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (DeleteUserViewData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DeleteUserViewData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteUserViewDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodDeleteUserViewData, Fixture, methodDeleteUserViewDataPrametersTypes);

            // Assert
            methodDeleteUserViewDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteUserViewData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_DeleteUserViewData_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteUserViewData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenameUserViewData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_RenameUserViewData_Method_Call_Internally(Type[] types)
        {
            var methodRenameUserViewDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodRenameUserViewData, Fixture, methodRenameUserViewDataPrametersTypes);
        }

        #endregion

        #region Method Call : (RenameUserViewData) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_RenameUserViewData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var snewName = CreateType<string>();
            var sviewName = CreateType<string>();
            var localflag = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.RenameUserViewData(oDataAccess, snewName, sviewName, localflag);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RenameUserViewData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_RenameUserViewData_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var snewName = CreateType<string>();
            var sviewName = CreateType<string>();
            var localflag = CreateType<int>();
            var methodRenameUserViewDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string), typeof(int) };
            object[] parametersOfRenameUserViewData = { oDataAccess, snewName, sviewName, localflag };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRenameUserViewData, methodRenameUserViewDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfRenameUserViewData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRenameUserViewData.ShouldNotBeNull();
            parametersOfRenameUserViewData.Length.ShouldBe(4);
            methodRenameUserViewDataPrametersTypes.Length.ShouldBe(4);
            methodRenameUserViewDataPrametersTypes.Length.ShouldBe(parametersOfRenameUserViewData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RenameUserViewData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_RenameUserViewData_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var snewName = CreateType<string>();
            var sviewName = CreateType<string>();
            var localflag = CreateType<int>();
            var methodRenameUserViewDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string), typeof(int) };
            object[] parametersOfRenameUserViewData = { oDataAccess, snewName, sviewName, localflag };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodRenameUserViewData, parametersOfRenameUserViewData, methodRenameUserViewDataPrametersTypes);

            // Assert
            parametersOfRenameUserViewData.ShouldNotBeNull();
            parametersOfRenameUserViewData.Length.ShouldBe(4);
            methodRenameUserViewDataPrametersTypes.Length.ShouldBe(4);
            methodRenameUserViewDataPrametersTypes.Length.ShouldBe(parametersOfRenameUserViewData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenameUserViewData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_RenameUserViewData_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (RenameUserViewData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_RenameUserViewData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenameUserViewDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodRenameUserViewData, Fixture, methodRenameUserViewDataPrametersTypes);

            // Assert
            methodRenameUserViewDataPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenameUserViewData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_RenameUserViewData_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenameUserViewData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveUserViewData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_SaveUserViewData_Method_Call_Internally(Type[] types)
        {
            var methodSaveUserViewDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSaveUserViewData, Fixture, methodSaveUserViewDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveUserViewData) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SaveUserViewData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var sviewName = CreateType<string>();
            var localflag = CreateType<int>();
            var sZoomTo = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.SaveUserViewData(oDataAccess, sviewName, localflag, sZoomTo);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SaveUserViewData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SaveUserViewData_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var sviewName = CreateType<string>();
            var localflag = CreateType<int>();
            var sZoomTo = CreateType<string>();
            var methodSaveUserViewDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(int), typeof(string) };
            object[] parametersOfSaveUserViewData = { oDataAccess, sviewName, localflag, sZoomTo };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSaveUserViewData, methodSaveUserViewDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfSaveUserViewData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSaveUserViewData.ShouldNotBeNull();
            parametersOfSaveUserViewData.Length.ShouldBe(4);
            methodSaveUserViewDataPrametersTypes.Length.ShouldBe(4);
            methodSaveUserViewDataPrametersTypes.Length.ShouldBe(parametersOfSaveUserViewData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SaveUserViewData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SaveUserViewData_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var sviewName = CreateType<string>();
            var localflag = CreateType<int>();
            var sZoomTo = CreateType<string>();
            var methodSaveUserViewDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(int), typeof(string) };
            object[] parametersOfSaveUserViewData = { oDataAccess, sviewName, localflag, sZoomTo };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodSaveUserViewData, parametersOfSaveUserViewData, methodSaveUserViewDataPrametersTypes);

            // Assert
            parametersOfSaveUserViewData.ShouldNotBeNull();
            parametersOfSaveUserViewData.Length.ShouldBe(4);
            methodSaveUserViewDataPrametersTypes.Length.ShouldBe(4);
            methodSaveUserViewDataPrametersTypes.Length.ShouldBe(parametersOfSaveUserViewData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveUserViewData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SaveUserViewData_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (SaveUserViewData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SaveUserViewData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveUserViewDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(int), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSaveUserViewData, Fixture, methodSaveUserViewDataPrametersTypes);

            // Assert
            methodSaveUserViewDataPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveUserViewData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SaveUserViewData_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveUserViewData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetUserViewSlug) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GetUserViewSlug_Method_Call_Internally(Type[] types)
        {
            var methodGetUserViewSlugPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetUserViewSlug, Fixture, methodGetUserViewSlugPrametersTypes);
        }

        #endregion

        #region Method Call : (GetUserViewSlug) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetUserViewSlug_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sZoomTo = CreateType<string>();
            var methodGetUserViewSlugPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetUserViewSlug = { sZoomTo };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, string>(_modelCacheInstance, MethodGetUserViewSlug, parametersOfGetUserViewSlug, methodGetUserViewSlugPrametersTypes);

            // Assert
            parametersOfGetUserViewSlug.ShouldNotBeNull();
            parametersOfGetUserViewSlug.Length.ShouldBe(1);
            methodGetUserViewSlugPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetUserViewSlug) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetUserViewSlug_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetUserViewSlugPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetUserViewSlug, Fixture, methodGetUserViewSlugPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetUserViewSlugPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetUserViewSlug) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetUserViewSlug_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetUserViewSlugPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetUserViewSlug, Fixture, methodGetUserViewSlugPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetUserViewSlugPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUserViewSlug) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetUserViewSlug_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetUserViewSlug, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LoadUserViews) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_LoadUserViews_Method_Call_Internally(Type[] types)
        {
            var methodLoadUserViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodLoadUserViews, Fixture, methodLoadUserViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadUserViews) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadUserViews_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var methodLoadUserViewsPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfLoadUserViews = { oDataAccess };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadUserViews, methodLoadUserViewsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfLoadUserViews);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadUserViews.ShouldNotBeNull();
            parametersOfLoadUserViews.Length.ShouldBe(1);
            methodLoadUserViewsPrametersTypes.Length.ShouldBe(1);
            methodLoadUserViewsPrametersTypes.Length.ShouldBe(parametersOfLoadUserViews.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (LoadUserViews) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadUserViews_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var methodLoadUserViewsPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfLoadUserViews = { oDataAccess };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_modelCacheInstance, MethodLoadUserViews, parametersOfLoadUserViews, methodLoadUserViewsPrametersTypes);

            // Assert
            parametersOfLoadUserViews.ShouldNotBeNull();
            parametersOfLoadUserViews.Length.ShouldBe(1);
            methodLoadUserViewsPrametersTypes.Length.ShouldBe(1);
            methodLoadUserViewsPrametersTypes.Length.ShouldBe(parametersOfLoadUserViews.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadUserViews) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadUserViews_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLoadUserViews, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LoadUserViews) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadUserViews_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLoadUserViewsPrametersTypes = new Type[] { typeof(SqlConnection) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodLoadUserViews, Fixture, methodLoadUserViewsPrametersTypes);

            // Assert
            methodLoadUserViewsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadUserViews) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_LoadUserViews_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadUserViews, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SelectUserViewData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_SelectUserViewData_Method_Call_Internally(Type[] types)
        {
            var methodSelectUserViewDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSelectUserViewData, Fixture, methodSelectUserViewDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SelectUserViewData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SelectUserViewData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var viewID = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.SelectUserViewData(oDataAccess, viewID);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SelectUserViewData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SelectUserViewData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var viewID = CreateType<int>();
            var methodSelectUserViewDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(int) };
            object[] parametersOfSelectUserViewData = { oDataAccess, viewID };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSelectUserViewData, methodSelectUserViewDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ModelCache, string>(_modelCacheInstanceFixture, out exception1, parametersOfSelectUserViewData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ModelCache, string>(_modelCacheInstance, MethodSelectUserViewData, parametersOfSelectUserViewData, methodSelectUserViewDataPrametersTypes);

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

        #region Method Call : (SelectUserViewData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SelectUserViewData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var viewID = CreateType<int>();
            var methodSelectUserViewDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(int) };
            object[] parametersOfSelectUserViewData = { oDataAccess, viewID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, string>(_modelCacheInstance, MethodSelectUserViewData, parametersOfSelectUserViewData, methodSelectUserViewDataPrametersTypes);

            // Assert
            parametersOfSelectUserViewData.ShouldNotBeNull();
            parametersOfSelectUserViewData.Length.ShouldBe(2);
            methodSelectUserViewDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SelectUserViewData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SelectUserViewData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSelectUserViewDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSelectUserViewData, Fixture, methodSelectUserViewDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSelectUserViewDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (SelectUserViewData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SelectUserViewData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSelectUserViewDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodSelectUserViewData, Fixture, methodSelectUserViewDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSelectUserViewDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SelectUserViewData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SelectUserViewData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSelectUserViewData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SelectUserViewData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_SelectUserViewData_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (GetCmpString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ModelCache_GetCmpString_Method_Call_Internally(Type[] types)
        {
            var methodGetCmpStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetCmpString, Fixture, methodGetCmpStringPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCmpString) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetCmpString_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _modelCacheInstance.GetCmpString();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetCmpString) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetCmpString_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetCmpStringPrametersTypes = null;
            object[] parametersOfGetCmpString = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCmpString, methodGetCmpStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_modelCacheInstanceFixture, parametersOfGetCmpString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCmpString.ShouldBeNull();
            methodGetCmpStringPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCmpString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetCmpString_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetCmpStringPrametersTypes = null;
            object[] parametersOfGetCmpString = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ModelCache, string>(_modelCacheInstance, MethodGetCmpString, parametersOfGetCmpString, methodGetCmpStringPrametersTypes);

            // Assert
            parametersOfGetCmpString.ShouldBeNull();
            methodGetCmpStringPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCmpString) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetCmpString_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetCmpStringPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetCmpString, Fixture, methodGetCmpStringPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetCmpStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCmpString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetCmpString_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetCmpStringPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_modelCacheInstance, MethodGetCmpString, Fixture, methodGetCmpStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCmpStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCmpString) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ModelCache_GetCmpString_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCmpString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_modelCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}