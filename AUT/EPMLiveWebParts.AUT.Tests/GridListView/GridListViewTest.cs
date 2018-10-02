using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.Web.CommandUI;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.GridListView" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class GridListViewTest : AbstractBaseSetupTypedTest<GridListView>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (GridListView) Initializer

        private const string PropertyPropGroup1 = "PropGroup1";
        private const string PropertyPropGroup2 = "PropGroup2";
        private const string PropertyPropExpand = "PropExpand";
        private const string PropertyPropHideNewButton = "PropHideNewButton";
        private const string PropertyPropMyDefaultControl = "PropMyDefaultControl";
        private const string PropertyPropDefaultControl = "PropDefaultControl";
        private const string PropertyPropLockViewContext = "PropLockViewContext";
        private const string PropertyPropExecView = "PropExecView";
        private const string PropertyPropList = "PropList";
        private const string PropertyPropView = "PropView";
        private const string PropertyPropRollupList = "PropRollupList";
        private const string PropertyPropRollupSites = "PropRollupSites";
        private const string PropertyPropStart = "PropStart";
        private const string PropertyPropFinish = "PropFinish";
        private const string PropertyPropMilestone = "PropMilestone";
        private const string PropertyPropProgress = "PropProgress";
        private const string PropertyPropInformation = "PropInformation";
        private const string PropertyPropWBS = "PropWBS";
        private const string PropertyPropShowViewToolbar = "PropShowViewToolbar";
        private const string PropertyPropLinkType = "PropLinkType";
        private const string PropertyPropUseDefaults = "PropUseDefaults";
        private const string PropertyPropAllowEdit = "PropAllowEdit";
        private const string PropertyPropContentReporting = "PropContentReporting";
        private const string PropertyPropUsePopup = "PropUsePopup";
        private const string PropertyPropPerformance = "PropPerformance";
        private const string PropertyPropEdit = "PropEdit";
        private const string PropertyPropShowInsertRow = "PropShowInsertRow";
        private const string PropertyPropUseParent = "PropUseParent";
        private const string PropertyPropShowSearch = "PropShowSearch";
        private const string PropertyPropLockSearch = "PropLockSearch";
        private const string PropertyWebPartContextualInfo = "WebPartContextualInfo";
        private const string PropertyDelayScript = "DelayScript";
        private const string MethodReportIDConsumer = "ReportIDConsumer";
        private const string MethodgetPjList = "getPjList";
        private const string MethodgetPlannerList = "getPlannerList";
        private const string MethodgetEPKPlannerList = "getEPKPlannerList";
        private const string MethodgetPlanner = "getPlanner";
        private const string MethodgetEPKButtons = "getEPKButtons";
        private const string MethodAddContextualTab = "AddContextualTab";
        private const string MethodOnPreRender = "OnPreRender";
        private const string MethodOnInit = "OnInit";
        private const string MethodOnLoad = "OnLoad";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodRenderWebPart = "RenderWebPart";
        private const string MethodGetGroups = "GetGroups";
        private const string MethodRenderActionMenu = "RenderActionMenu";
        private const string MethodGetViews = "GetViews";
        private const string MethodConvertFromString = "ConvertFromString";
        private const string MethodHideListView = "HideListView";
        private const string MethodpostItems = "postItems";
        private const string MethodrenderCost = "renderCost";
        private const string MethodRenderSearch = "RenderSearch";
        private const string MethodRenderSearchTypesSelect = "RenderSearchTypesSelect";
        private const string MethodRenderSearchFieldsSelect = "RenderSearchFieldsSelect";
        private const string MethodRenderFunctionSearchKeyPress = "RenderFunctionSearchKeyPress";
        private const string MethodRenderFunctionEnableSearcher = "RenderFunctionEnableSearcher";
        private const string MethodRenderFunctionDoSearch = "RenderFunctionDoSearch";
        private const string MethodRenderFunctionUnSearch = "RenderFunctionUnSearch";
        private const string MethodGenerateSearchRequestUrl = "GenerateSearchRequestUrl";
        private const string MethodRenderFunctionSwitchToSearch = "RenderFunctionSwitchToSearch";
        private const string MethodFilterSearchFields = "FilterSearchFields";
        private const string MethodrenderGantt = "renderGantt";
        private const string Methodtypeoption = "typeoption";
        private const string MethodrenderGrid = "renderGrid";
        private const string MethodEncodeNonAsciiCharacters = "EncodeNonAsciiCharacters";
        private const string MethodaddNewButton = "addNewButton";
        private const string MethodaddGridProperties = "addGridProperties";
        private const string MethodgetViewFields = "getViewFields";
        private const string MethodgetRealField = "getRealField";
        private const string MethodgetAdditionalGroupings = "getAdditionalGroupings";
        private const string MethodappendParam = "appendParam";
        private const string MethodGetLinkedItemInfo = "GetLinkedItemInfo";
        private const string MethodbuildParams = "buildParams";
        private const string MethodGetToolParts = "GetToolParts";
        private const string MethodMatchROFields = "MatchROFields";
        private const string MethodIsEnableModeration = "IsEnableModeration";
        private const string MethodGetBuildParamsProps = "GetBuildParamsProps";
        private const string FieldgSettings = "gSettings";
        private const string Fieldtb = "tb";
        private const string Field_myProvider = "_myProvider";
        private const string FieldinEditMode = "inEditMode";
        private const string Fieldtitlefound = "titlefound";
        private const string Fieldact = "act";
        private const string FieldganttControl = "ganttControl";
        private const string FieldstrList = "strList";
        private const string FieldstrView = "strView";
        private const string FieldstrRollupList = "strRollupList";
        private const string Fielderror = "error";
        private const string FieldshowMenu = "showMenu";
        private const string FieldboolShowViewToolbar = "boolShowViewToolbar";
        private const string FieldboolHideNewButton = "boolHideNewButton";
        private const string FieldboolUseDefaults = "boolUseDefaults";
        private const string FieldboolShowInsertRow = "boolShowInsertRow";
        private const string FieldboolUseParent = "boolUseParent";
        private const string FieldboolAllowEdit = "boolAllowEdit";
        private const string FieldboolEdit = "boolEdit";
        private const string FieldboolPerformance = "boolPerformance";
        private const string FieldboolUsePopup = "boolUsePopup";
        private const string FieldboolShowSearch = "boolShowSearch";
        private const string FieldboolLockSearch = "boolLockSearch";
        private const string FieldstrLinkType = "strLinkType";
        private const string FieldstrExecView = "strExecView";
        private const string FieldboolLockViewContext = "boolLockViewContext";
        private const string FieldstrStart = "strStart";
        private const string FieldstrFinish = "strFinish";
        private const string FieldstrMilestone = "strMilestone";
        private const string FieldstrProgress = "strProgress";
        private const string FieldstrInformation = "strInformation";
        private const string FieldstrWBS = "strWBS";
        private const string FieldstrDefaultControl = "strDefaultControl";
        private const string FieldstrMyDefaultControl = "strMyDefaultControl";
        private const string FieldstrRollupSites = "strRollupSites";
        private const string FieldstrGroup1 = "strGroup1";
        private const string FieldstrGroup2 = "strGroup2";
        private const string FieldstrExpand = "strExpand";
        private const string FieldbShowSearch = "bShowSearch";
        private const string FieldbLockSearch = "bLockSearch";
        private const string FieldbHasSearchResults = "bHasSearchResults";
        private const string FieldsSearchField = "sSearchField";
        private const string FieldsSearchValue = "sSearchValue";
        private const string FieldsSearchType = "sSearchType";
        private const string FielduseParent = "useParent";
        private const string FielddisableNewButtonModification = "disableNewButtonModification";
        private const string FieldBOOLShowViewBar = "BOOLShowViewBar";
        private const string Fieldactivation = "activation";
        private const string Fieldtoolbar = "toolbar";
        private const string Fieldlist = "list";
        private const string Fieldview = "view";
        private const string FieldpeMulti = "peMulti";
        private const string FieldpeSingle = "peSingle";
        private const string FieldfilterIndex = "filterIndex";
        private const string FieldhideNew = "hideNew";
        private const string FieldallowInsertRow = "allowInsertRow";
        private const string FieldallowEditToggle = "allowEditToggle";
        private const string FieldhasList = "hasList";
        private const string FielduseNewMenu = "useNewMenu";
        private const string FieldnewMenuName = "newMenuName";
        private const string FieldrollupLists = "rollupLists";
        private const string FieldsFullGridId = "sFullGridId";
        private const string FieldsFullParamList = "sFullParamList";
        private const string FieldnewGridMode = "newGridMode";
        private const string FieldnewMenuStyle = "newMenuStyle";
        private const string FieldrequestList = "requestList";
        private const string FieldbRollups = "bRollups";
        private const string FieldEPKEnabled = "EPKEnabled";
        private const string FieldEPKButtons = "EPKButtons";
        private const string FieldEPKURL = "EPKURL";
        private const string FieldEPKView = "EPKView";
        private const string FieldEPKCostView = "EPKCostView";
        private const string FieldPlannerV2Menu = "PlannerV2Menu";
        private const string FieldPlannerV2CurPlanner = "PlannerV2CurPlanner";
        private const string FieldbIsFormWebpart = "bIsFormWebpart";
        private const string FieldbIsLinkedItemView = "bIsLinkedItemView";
        private const string FieldLookupFilterField = "LookupFilterField";
        private const string FieldLookupFilterValue = "LookupFilterValue";
        private const string FieldbAssociatedItems = "bAssociatedItems";
        private const string FieldbUsePopUp = "bUsePopUp";
        private const string FieldbContentReporting = "bContentReporting";
        private const string FieldOnlyGrid = "OnlyGrid";
        private const string Fieldgvs = "gvs";
        private const string FieldLinkType = "LinkType";
        private const string FieldoJsonViewURL = "oJsonViewURL";
        private const string FieldoJsonDefaultViewURL = "oJsonDefaultViewURL";
        private const string FieldRptControls = "RptControls";
        private const string FieldRightRptControls = "RightRptControls";
        private const string FieldActionMenu = "ActionMenu";
        private const string FieldSettingMenu = "SettingMenu";
        private const string FieldGanttStart = "GanttStart";
        private Type _gridListViewInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private GridListView _gridListViewInstance;
        private GridListView _gridListViewInstanceFixture;

        #region General Initializer : Class (GridListView) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="GridListView" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _gridListViewInstanceType = typeof(GridListView);
            _gridListViewInstanceFixture = Create(true);
            _gridListViewInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (GridListView)

        #region General Initializer : Class (GridListView) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="GridListView" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyPropGroup1)]
        [TestCase(PropertyPropGroup2)]
        [TestCase(PropertyPropExpand)]
        [TestCase(PropertyPropHideNewButton)]
        [TestCase(PropertyPropMyDefaultControl)]
        [TestCase(PropertyPropDefaultControl)]
        [TestCase(PropertyPropLockViewContext)]
        [TestCase(PropertyPropExecView)]
        [TestCase(PropertyPropList)]
        [TestCase(PropertyPropView)]
        [TestCase(PropertyPropRollupList)]
        [TestCase(PropertyPropRollupSites)]
        [TestCase(PropertyPropStart)]
        [TestCase(PropertyPropFinish)]
        [TestCase(PropertyPropMilestone)]
        [TestCase(PropertyPropProgress)]
        [TestCase(PropertyPropInformation)]
        [TestCase(PropertyPropWBS)]
        [TestCase(PropertyPropShowViewToolbar)]
        [TestCase(PropertyPropLinkType)]
        [TestCase(PropertyPropUseDefaults)]
        [TestCase(PropertyPropAllowEdit)]
        [TestCase(PropertyPropContentReporting)]
        [TestCase(PropertyPropUsePopup)]
        [TestCase(PropertyPropPerformance)]
        [TestCase(PropertyPropEdit)]
        [TestCase(PropertyPropShowInsertRow)]
        [TestCase(PropertyPropUseParent)]
        [TestCase(PropertyPropShowSearch)]
        [TestCase(PropertyPropLockSearch)]
        [TestCase(PropertyWebPartContextualInfo)]
        [TestCase(PropertyDelayScript)]
        public void AUT_GridListView_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_gridListViewInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (GridListView) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="GridListView" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldgSettings)]
        [TestCase(Fieldtb)]
        [TestCase(Field_myProvider)]
        [TestCase(FieldinEditMode)]
        [TestCase(Fieldtitlefound)]
        [TestCase(Fieldact)]
        [TestCase(FieldganttControl)]
        [TestCase(FieldstrList)]
        [TestCase(FieldstrView)]
        [TestCase(FieldstrRollupList)]
        [TestCase(Fielderror)]
        [TestCase(FieldshowMenu)]
        [TestCase(FieldboolShowViewToolbar)]
        [TestCase(FieldboolHideNewButton)]
        [TestCase(FieldboolUseDefaults)]
        [TestCase(FieldboolShowInsertRow)]
        [TestCase(FieldboolUseParent)]
        [TestCase(FieldboolAllowEdit)]
        [TestCase(FieldboolEdit)]
        [TestCase(FieldboolPerformance)]
        [TestCase(FieldboolUsePopup)]
        [TestCase(FieldboolShowSearch)]
        [TestCase(FieldboolLockSearch)]
        [TestCase(FieldstrLinkType)]
        [TestCase(FieldstrExecView)]
        [TestCase(FieldboolLockViewContext)]
        [TestCase(FieldstrStart)]
        [TestCase(FieldstrFinish)]
        [TestCase(FieldstrMilestone)]
        [TestCase(FieldstrProgress)]
        [TestCase(FieldstrInformation)]
        [TestCase(FieldstrWBS)]
        [TestCase(FieldstrDefaultControl)]
        [TestCase(FieldstrMyDefaultControl)]
        [TestCase(FieldstrRollupSites)]
        [TestCase(FieldstrGroup1)]
        [TestCase(FieldstrGroup2)]
        [TestCase(FieldstrExpand)]
        [TestCase(FieldbShowSearch)]
        [TestCase(FieldbLockSearch)]
        [TestCase(FieldbHasSearchResults)]
        [TestCase(FieldsSearchField)]
        [TestCase(FieldsSearchValue)]
        [TestCase(FieldsSearchType)]
        [TestCase(FielduseParent)]
        [TestCase(FielddisableNewButtonModification)]
        [TestCase(FieldBOOLShowViewBar)]
        [TestCase(Fieldactivation)]
        [TestCase(Fieldtoolbar)]
        [TestCase(Fieldlist)]
        [TestCase(Fieldview)]
        [TestCase(FieldpeMulti)]
        [TestCase(FieldpeSingle)]
        [TestCase(FieldfilterIndex)]
        [TestCase(FieldhideNew)]
        [TestCase(FieldallowInsertRow)]
        [TestCase(FieldallowEditToggle)]
        [TestCase(FieldhasList)]
        [TestCase(FielduseNewMenu)]
        [TestCase(FieldnewMenuName)]
        [TestCase(FieldrollupLists)]
        [TestCase(FieldsFullGridId)]
        [TestCase(FieldsFullParamList)]
        [TestCase(FieldnewGridMode)]
        [TestCase(FieldnewMenuStyle)]
        [TestCase(FieldrequestList)]
        [TestCase(FieldbRollups)]
        [TestCase(FieldEPKEnabled)]
        [TestCase(FieldEPKButtons)]
        [TestCase(FieldEPKURL)]
        [TestCase(FieldEPKView)]
        [TestCase(FieldEPKCostView)]
        [TestCase(FieldPlannerV2Menu)]
        [TestCase(FieldPlannerV2CurPlanner)]
        [TestCase(FieldbIsFormWebpart)]
        [TestCase(FieldbIsLinkedItemView)]
        [TestCase(FieldLookupFilterField)]
        [TestCase(FieldLookupFilterValue)]
        [TestCase(FieldbAssociatedItems)]
        [TestCase(FieldbUsePopUp)]
        [TestCase(FieldbContentReporting)]
        [TestCase(FieldOnlyGrid)]
        [TestCase(Fieldgvs)]
        [TestCase(FieldLinkType)]
        [TestCase(FieldoJsonViewURL)]
        [TestCase(FieldoJsonDefaultViewURL)]
        [TestCase(FieldRptControls)]
        [TestCase(FieldRightRptControls)]
        [TestCase(FieldActionMenu)]
        [TestCase(FieldSettingMenu)]
        [TestCase(FieldGanttStart)]
        public void AUT_GridListView_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_gridListViewInstanceFixture, 
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
        ///     Class (<see cref="GridListView" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_GridListView_Is_Instance_Present_Test()
        {
            // Assert
            _gridListViewInstanceType.ShouldNotBeNull();
            _gridListViewInstance.ShouldNotBeNull();
            _gridListViewInstanceFixture.ShouldNotBeNull();
            _gridListViewInstance.ShouldBeAssignableTo<GridListView>();
            _gridListViewInstanceFixture.ShouldBeAssignableTo<GridListView>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (GridListView) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_GridListView_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            GridListView instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _gridListViewInstanceType.ShouldNotBeNull();
            _gridListViewInstance.ShouldNotBeNull();
            _gridListViewInstanceFixture.ShouldNotBeNull();
            _gridListViewInstance.ShouldBeAssignableTo<GridListView>();
            _gridListViewInstanceFixture.ShouldBeAssignableTo<GridListView>();
        }

        #endregion

        #region General Constructor : Class (GridListView) Default Assignment Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_GridListView_Constructor_Instantiated_With_Default_Assignments_Test()
        {

            // Act
            var gridListViewInstance  = new GridListView();

            // Asserts
            gridListViewInstance.ShouldNotBeNull();
            gridListViewInstance.ShouldBeAssignableTo<GridListView>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (GridListView) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyPropGroup1)]
        [TestCaseGeneric(typeof(string) , PropertyPropGroup2)]
        [TestCaseGeneric(typeof(string) , PropertyPropExpand)]
        [TestCaseGeneric(typeof(bool?) , PropertyPropHideNewButton)]
        [TestCaseGeneric(typeof(string) , PropertyPropMyDefaultControl)]
        [TestCaseGeneric(typeof(string) , PropertyPropDefaultControl)]
        [TestCaseGeneric(typeof(bool?) , PropertyPropLockViewContext)]
        [TestCaseGeneric(typeof(string) , PropertyPropExecView)]
        [TestCaseGeneric(typeof(string) , PropertyPropList)]
        [TestCaseGeneric(typeof(string) , PropertyPropView)]
        [TestCaseGeneric(typeof(string) , PropertyPropRollupList)]
        [TestCaseGeneric(typeof(string) , PropertyPropRollupSites)]
        [TestCaseGeneric(typeof(string) , PropertyPropStart)]
        [TestCaseGeneric(typeof(string) , PropertyPropFinish)]
        [TestCaseGeneric(typeof(string) , PropertyPropMilestone)]
        [TestCaseGeneric(typeof(string) , PropertyPropProgress)]
        [TestCaseGeneric(typeof(string) , PropertyPropInformation)]
        [TestCaseGeneric(typeof(string) , PropertyPropWBS)]
        [TestCaseGeneric(typeof(bool?) , PropertyPropShowViewToolbar)]
        [TestCaseGeneric(typeof(string) , PropertyPropLinkType)]
        [TestCaseGeneric(typeof(bool?) , PropertyPropUseDefaults)]
        [TestCaseGeneric(typeof(bool?) , PropertyPropAllowEdit)]
        [TestCaseGeneric(typeof(bool?) , PropertyPropContentReporting)]
        [TestCaseGeneric(typeof(bool?) , PropertyPropUsePopup)]
        [TestCaseGeneric(typeof(bool?) , PropertyPropPerformance)]
        [TestCaseGeneric(typeof(bool?) , PropertyPropEdit)]
        [TestCaseGeneric(typeof(bool?) , PropertyPropShowInsertRow)]
        [TestCaseGeneric(typeof(bool?) , PropertyPropUseParent)]
        [TestCaseGeneric(typeof(bool?) , PropertyPropShowSearch)]
        [TestCaseGeneric(typeof(bool?) , PropertyPropLockSearch)]
        [TestCaseGeneric(typeof(WebPartContextualInfo) , PropertyWebPartContextualInfo)]
        [TestCaseGeneric(typeof(string) , PropertyDelayScript)]
        public void AUT_GridListView_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<GridListView, T>(_gridListViewInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (DelayScript) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_DelayScript_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDelayScript);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropAllowEdit) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropAllowEdit_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropAllowEdit);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropContentReporting) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropContentReporting_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropContentReporting);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropDefaultControl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropDefaultControl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropDefaultControl);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropEdit) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropEdit_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropEdit);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropExecView) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropExecView_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropExecView);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropExpand) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropExpand_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropExpand);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropFinish) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropFinish_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropFinish);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropGroup1) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropGroup1_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropGroup1);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropGroup2) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropGroup2_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropGroup2);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropHideNewButton) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropHideNewButton_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropHideNewButton);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropInformation) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropInformation_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropInformation);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropLinkType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropLinkType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropLinkType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropList) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropList_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropList);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropLockSearch) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropLockSearch_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropLockSearch);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropLockViewContext) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropLockViewContext_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropLockViewContext);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropMilestone) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropMilestone_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropMilestone);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropMyDefaultControl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropMyDefaultControl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropMyDefaultControl);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropPerformance) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropPerformance_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropPerformance);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropProgress) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropProgress_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropProgress);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropRollupList) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropRollupList_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropRollupList);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropRollupSites) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropRollupSites_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropRollupSites);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropShowInsertRow) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropShowInsertRow_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropShowInsertRow);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropShowSearch) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropShowSearch_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropShowSearch);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropShowViewToolbar) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropShowViewToolbar_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropShowViewToolbar);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropStart) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropStart_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropStart);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropUseDefaults) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropUseDefaults_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropUseDefaults);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropUseParent) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropUseParent_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropUseParent);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropUsePopup) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropUsePopup_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropUsePopup);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropView) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropView_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropView);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (PropWBS) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_PropWBS_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropWBS);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (WebPartContextualInfo) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_WebPartContextualInfo_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyWebPartContextualInfo);
            Action currentAction = () => propertyInfo.SetValue(_gridListViewInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GridListView) => Property (WebPartContextualInfo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GridListView_Public_Class_WebPartContextualInfo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWebPartContextualInfo);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="GridListView" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodEncodeNonAsciiCharacters)]
        public void AUT_GridListView_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_gridListViewInstanceFixture,
                                                                              _gridListViewInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (ReportIDConsumer) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_ReportIDConsumer_Method_Call_Internally(Type[] types)
        {
            var methodReportIDConsumerPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodReportIDConsumer, Fixture, methodReportIDConsumerPrametersTypes);
        }

        #endregion

        #region Method Call : (ReportIDConsumer) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_ReportIDConsumer_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Provider = CreateType<IReportID>();
            Action executeAction = null;

            // Act
            executeAction = () => _gridListViewInstance.ReportIDConsumer(Provider);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ReportIDConsumer) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_ReportIDConsumer_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var Provider = CreateType<IReportID>();
            var methodReportIDConsumerPrametersTypes = new Type[] { typeof(IReportID) };
            object[] parametersOfReportIDConsumer = { Provider };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReportIDConsumer, methodReportIDConsumerPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridListViewInstanceFixture, parametersOfReportIDConsumer);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReportIDConsumer.ShouldNotBeNull();
            parametersOfReportIDConsumer.Length.ShouldBe(1);
            methodReportIDConsumerPrametersTypes.Length.ShouldBe(1);
            methodReportIDConsumerPrametersTypes.Length.ShouldBe(parametersOfReportIDConsumer.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReportIDConsumer) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_ReportIDConsumer_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Provider = CreateType<IReportID>();
            var methodReportIDConsumerPrametersTypes = new Type[] { typeof(IReportID) };
            object[] parametersOfReportIDConsumer = { Provider };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridListViewInstance, MethodReportIDConsumer, parametersOfReportIDConsumer, methodReportIDConsumerPrametersTypes);

            // Assert
            parametersOfReportIDConsumer.ShouldNotBeNull();
            parametersOfReportIDConsumer.Length.ShouldBe(1);
            methodReportIDConsumerPrametersTypes.Length.ShouldBe(1);
            methodReportIDConsumerPrametersTypes.Length.ShouldBe(parametersOfReportIDConsumer.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReportIDConsumer) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_ReportIDConsumer_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReportIDConsumer, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReportIDConsumer) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_ReportIDConsumer_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReportIDConsumerPrametersTypes = new Type[] { typeof(IReportID) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodReportIDConsumer, Fixture, methodReportIDConsumerPrametersTypes);

            // Assert
            methodReportIDConsumerPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReportIDConsumer) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_ReportIDConsumer_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReportIDConsumer, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getPjList) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_getPjList_Method_Call_Internally(Type[] types)
        {
            var methodgetPjListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodgetPjList, Fixture, methodgetPjListPrametersTypes);
        }

        #endregion

        #region Method Call : (getPjList) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getPjList_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodgetPjListPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfgetPjList = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridListView, string>(_gridListViewInstance, MethodgetPjList, parametersOfgetPjList, methodgetPjListPrametersTypes);

            // Assert
            parametersOfgetPjList.ShouldNotBeNull();
            parametersOfgetPjList.Length.ShouldBe(1);
            methodgetPjListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getPjList) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getPjList_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetPjListPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodgetPjList, Fixture, methodgetPjListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetPjListPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getPjList) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getPjList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetPjListPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodgetPjList, Fixture, methodgetPjListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetPjListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getPlannerList) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_getPlannerList_Method_Call_Internally(Type[] types)
        {
            var methodgetPlannerListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodgetPlannerList, Fixture, methodgetPlannerListPrametersTypes);
        }

        #endregion

        #region Method Call : (getPlannerList) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getPlannerList_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var plannerName = CreateType<string>();
            var web = CreateType<SPWeb>();
            var pDisplay = CreateType<string>();
            var methodgetPlannerListPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(string) };
            object[] parametersOfgetPlannerList = { plannerName, web, pDisplay };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridListView, string>(_gridListViewInstance, MethodgetPlannerList, parametersOfgetPlannerList, methodgetPlannerListPrametersTypes);

            // Assert
            parametersOfgetPlannerList.ShouldNotBeNull();
            parametersOfgetPlannerList.Length.ShouldBe(3);
            methodgetPlannerListPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getPlannerList) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getPlannerList_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetPlannerListPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodgetPlannerList, Fixture, methodgetPlannerListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetPlannerListPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (getPlannerList) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getPlannerList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetPlannerListPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodgetPlannerList, Fixture, methodgetPlannerListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetPlannerListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getEPKPlannerList) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_getEPKPlannerList_Method_Call_Internally(Type[] types)
        {
            var methodgetEPKPlannerListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodgetEPKPlannerList, Fixture, methodgetEPKPlannerListPrametersTypes);
        }

        #endregion

        #region Method Call : (getEPKPlannerList) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getEPKPlannerList_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodgetEPKPlannerListPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfgetEPKPlannerList = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridListView, string>(_gridListViewInstance, MethodgetEPKPlannerList, parametersOfgetEPKPlannerList, methodgetEPKPlannerListPrametersTypes);

            // Assert
            parametersOfgetEPKPlannerList.ShouldNotBeNull();
            parametersOfgetEPKPlannerList.Length.ShouldBe(1);
            methodgetEPKPlannerListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getEPKPlannerList) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getEPKPlannerList_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetEPKPlannerListPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodgetEPKPlannerList, Fixture, methodgetEPKPlannerListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetEPKPlannerListPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getEPKPlannerList) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getEPKPlannerList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetEPKPlannerListPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodgetEPKPlannerList, Fixture, methodgetEPKPlannerListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetEPKPlannerListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getPlanner) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_getPlanner_Method_Call_Internally(Type[] types)
        {
            var methodgetPlannerPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodgetPlanner, Fixture, methodgetPlannerPrametersTypes);
        }

        #endregion

        #region Method Call : (getPlanner) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getPlanner_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var plannerName = CreateType<string>();
            var web = CreateType<SPWeb>();
            var pDisplay = CreateType<string>();
            var image = CreateType<string>();
            var methodgetPlannerPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfgetPlanner = { plannerName, web, pDisplay, image };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridListView, string>(_gridListViewInstance, MethodgetPlanner, parametersOfgetPlanner, methodgetPlannerPrametersTypes);

            // Assert
            parametersOfgetPlanner.ShouldNotBeNull();
            parametersOfgetPlanner.Length.ShouldBe(4);
            methodgetPlannerPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getPlanner) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getPlanner_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetPlannerPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodgetPlanner, Fixture, methodgetPlannerPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetPlannerPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (getPlanner) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getPlanner_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetPlannerPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodgetPlanner, Fixture, methodgetPlannerPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetPlannerPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getPlanner) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_getPlanner_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodgetPlannerPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodgetPlanner, Fixture, methodgetPlannerPrametersTypes);
        }

        #endregion

        #region Method Call : (getPlanner) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getPlanner_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var plannerName = CreateType<string>();
            var web = CreateType<SPWeb>();
            var pDisplay = CreateType<string>();
            var methodgetPlannerPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(string) };
            object[] parametersOfgetPlanner = { plannerName, web, pDisplay };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridListView, string>(_gridListViewInstance, MethodgetPlanner, parametersOfgetPlanner, methodgetPlannerPrametersTypes);

            // Assert
            parametersOfgetPlanner.ShouldNotBeNull();
            parametersOfgetPlanner.Length.ShouldBe(3);
            methodgetPlannerPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getPlanner) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getPlanner_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetPlannerPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodgetPlanner, Fixture, methodgetPlannerPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetPlannerPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (getPlanner) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getPlanner_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetPlannerPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodgetPlanner, Fixture, methodgetPlannerPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetPlannerPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getEPKButtons) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_getEPKButtons_Method_Call_Internally(Type[] types)
        {
            var methodgetEPKButtonsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodgetEPKButtons, Fixture, methodgetEPKButtonsPrametersTypes);
        }

        #endregion

        #region Method Call : (getEPKButtons) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getEPKButtons_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var rp = CreateType<EPMLiveCore.API.RibbonProperties>();
            var ribbon1 = CreateType<Ribbon>();
            var language = CreateType<string>();
            var methodgetEPKButtonsPrametersTypes = new Type[] { typeof(EPMLiveCore.API.RibbonProperties), typeof(Ribbon), typeof(string) };
            object[] parametersOfgetEPKButtons = { rp, ribbon1, language };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetEPKButtons, methodgetEPKButtonsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridListViewInstanceFixture, parametersOfgetEPKButtons);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetEPKButtons.ShouldNotBeNull();
            parametersOfgetEPKButtons.Length.ShouldBe(3);
            methodgetEPKButtonsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getEPKButtons) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getEPKButtons_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var rp = CreateType<EPMLiveCore.API.RibbonProperties>();
            var ribbon1 = CreateType<Ribbon>();
            var language = CreateType<string>();
            var methodgetEPKButtonsPrametersTypes = new Type[] { typeof(EPMLiveCore.API.RibbonProperties), typeof(Ribbon), typeof(string) };
            object[] parametersOfgetEPKButtons = { rp, ribbon1, language };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridListView, string>(_gridListViewInstance, MethodgetEPKButtons, parametersOfgetEPKButtons, methodgetEPKButtonsPrametersTypes);

            // Assert
            parametersOfgetEPKButtons.ShouldNotBeNull();
            parametersOfgetEPKButtons.Length.ShouldBe(3);
            methodgetEPKButtonsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getEPKButtons) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getEPKButtons_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetEPKButtonsPrametersTypes = new Type[] { typeof(EPMLiveCore.API.RibbonProperties), typeof(Ribbon), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodgetEPKButtons, Fixture, methodgetEPKButtonsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetEPKButtonsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (getEPKButtons) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getEPKButtons_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetEPKButtonsPrametersTypes = new Type[] { typeof(EPMLiveCore.API.RibbonProperties), typeof(Ribbon), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodgetEPKButtons, Fixture, methodgetEPKButtonsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetEPKButtonsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getEPKButtons) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getEPKButtons_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetEPKButtons, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getEPKButtons) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getEPKButtons_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetEPKButtons, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddContextualTab) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_AddContextualTab_Method_Call_Internally(Type[] types)
        {
            var methodAddContextualTabPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodAddContextualTab, Fixture, methodAddContextualTabPrametersTypes);
        }

        #endregion

        #region Method Call : (AddContextualTab) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_AddContextualTab_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodAddContextualTabPrametersTypes = null;
            object[] parametersOfAddContextualTab = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddContextualTab, methodAddContextualTabPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridListViewInstanceFixture, parametersOfAddContextualTab);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddContextualTab.ShouldBeNull();
            methodAddContextualTabPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddContextualTab) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_AddContextualTab_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodAddContextualTabPrametersTypes = null;
            object[] parametersOfAddContextualTab = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridListViewInstance, MethodAddContextualTab, parametersOfAddContextualTab, methodAddContextualTabPrametersTypes);

            // Assert
            parametersOfAddContextualTab.ShouldBeNull();
            methodAddContextualTabPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddContextualTab) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_AddContextualTab_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodAddContextualTabPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodAddContextualTab, Fixture, methodAddContextualTabPrametersTypes);

            // Assert
            methodAddContextualTabPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddContextualTab) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_AddContextualTab_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddContextualTab, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_OnPreRender_Method_Call_Internally(Type[] types)
        {
            var methodOnPreRenderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_OnPreRender_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnPreRender, methodOnPreRenderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridListViewInstanceFixture, parametersOfOnPreRender);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnPreRender.ShouldNotBeNull();
            parametersOfOnPreRender.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(parametersOfOnPreRender.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_OnPreRender_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridListViewInstance, MethodOnPreRender, parametersOfOnPreRender, methodOnPreRenderPrametersTypes);

            // Assert
            parametersOfOnPreRender.ShouldNotBeNull();
            parametersOfOnPreRender.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(parametersOfOnPreRender.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_OnPreRender_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnPreRender, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_OnPreRender_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);

            // Assert
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_OnPreRender_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnPreRender, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_OnInit_Method_Call_Internally(Type[] types)
        {
            var methodOnInitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodOnInit, Fixture, methodOnInitPrametersTypes);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_OnInit_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnInit = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnInit, methodOnInitPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridListViewInstanceFixture, parametersOfOnInit);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnInit.ShouldNotBeNull();
            parametersOfOnInit.Length.ShouldBe(1);
            methodOnInitPrametersTypes.Length.ShouldBe(1);
            methodOnInitPrametersTypes.Length.ShouldBe(parametersOfOnInit.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_OnInit_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnInit = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridListViewInstance, MethodOnInit, parametersOfOnInit, methodOnInitPrametersTypes);

            // Assert
            parametersOfOnInit.ShouldNotBeNull();
            parametersOfOnInit.Length.ShouldBe(1);
            methodOnInitPrametersTypes.Length.ShouldBe(1);
            methodOnInitPrametersTypes.Length.ShouldBe(parametersOfOnInit.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_OnInit_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnInit, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_OnInit_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodOnInit, Fixture, methodOnInitPrametersTypes);

            // Assert
            methodOnInitPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_OnInit_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnInit, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_OnLoad_Method_Call_Internally(Type[] types)
        {
            var methodOnLoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodOnLoad, Fixture, methodOnLoadPrametersTypes);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_OnLoad_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnLoad = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnLoad, methodOnLoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridListViewInstanceFixture, parametersOfOnLoad);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnLoad.ShouldNotBeNull();
            parametersOfOnLoad.Length.ShouldBe(1);
            methodOnLoadPrametersTypes.Length.ShouldBe(1);
            methodOnLoadPrametersTypes.Length.ShouldBe(parametersOfOnLoad.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_OnLoad_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnLoad = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridListViewInstance, MethodOnLoad, parametersOfOnLoad, methodOnLoadPrametersTypes);

            // Assert
            parametersOfOnLoad.ShouldNotBeNull();
            parametersOfOnLoad.Length.ShouldBe(1);
            methodOnLoadPrametersTypes.Length.ShouldBe(1);
            methodOnLoadPrametersTypes.Length.ShouldBe(parametersOfOnLoad.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_OnLoad_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnLoad, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_OnLoad_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodOnLoad, Fixture, methodOnLoadPrametersTypes);

            // Assert
            methodOnLoadPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_OnLoad_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnLoad, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, methodCreateChildControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridListViewInstanceFixture, parametersOfCreateChildControls);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateChildControls.ShouldBeNull();
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridListViewInstance, MethodCreateChildControls, parametersOfCreateChildControls, methodCreateChildControlsPrametersTypes);

            // Assert
            parametersOfCreateChildControls.ShouldBeNull();
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_CreateChildControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);

            // Assert
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_CreateChildControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_RenderWebPart_Method_Call_Internally(Type[] types)
        {
            var methodRenderWebPartPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodRenderWebPart, Fixture, methodRenderWebPartPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderWebPart_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderWebPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderWebPart = { output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRenderWebPart, methodRenderWebPartPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridListViewInstanceFixture, parametersOfRenderWebPart);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRenderWebPart.ShouldNotBeNull();
            parametersOfRenderWebPart.Length.ShouldBe(1);
            methodRenderWebPartPrametersTypes.Length.ShouldBe(1);
            methodRenderWebPartPrametersTypes.Length.ShouldBe(parametersOfRenderWebPart.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderWebPart_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderWebPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderWebPart = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridListViewInstance, MethodRenderWebPart, parametersOfRenderWebPart, methodRenderWebPartPrametersTypes);

            // Assert
            parametersOfRenderWebPart.ShouldNotBeNull();
            parametersOfRenderWebPart.Length.ShouldBe(1);
            methodRenderWebPartPrametersTypes.Length.ShouldBe(1);
            methodRenderWebPartPrametersTypes.Length.ShouldBe(parametersOfRenderWebPart.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderWebPart_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenderWebPart, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderWebPart_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderWebPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodRenderWebPart, Fixture, methodRenderWebPartPrametersTypes);

            // Assert
            methodRenderWebPartPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderWebPart_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderWebPart, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetGroups) (Return Type : ArrayList) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_GetGroups_Method_Call_Internally(Type[] types)
        {
            var methodGetGroupsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodGetGroups, Fixture, methodGetGroupsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetGroups) (Return Type : ArrayList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GetGroups_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetGroupsPrametersTypes = null;
            object[] parametersOfGetGroups = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetGroups, methodGetGroupsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridListView, ArrayList>(_gridListViewInstanceFixture, out exception1, parametersOfGetGroups);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridListView, ArrayList>(_gridListViewInstance, MethodGetGroups, parametersOfGetGroups, methodGetGroupsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetGroups.ShouldBeNull();
            methodGetGroupsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetGroups) (Return Type : ArrayList) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GetGroups_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetGroupsPrametersTypes = null;
            object[] parametersOfGetGroups = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridListView, ArrayList>(_gridListViewInstance, MethodGetGroups, parametersOfGetGroups, methodGetGroupsPrametersTypes);

            // Assert
            parametersOfGetGroups.ShouldBeNull();
            methodGetGroupsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetGroups) (Return Type : ArrayList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GetGroups_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetGroupsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodGetGroups, Fixture, methodGetGroupsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetGroupsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetGroups) (Return Type : ArrayList) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GetGroups_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetGroupsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodGetGroups, Fixture, methodGetGroupsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetGroupsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetGroups) (Return Type : ArrayList) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GetGroups_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGroups, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenderActionMenu) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_RenderActionMenu_Method_Call_Internally(Type[] types)
        {
            var methodRenderActionMenuPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodRenderActionMenu, Fixture, methodRenderActionMenuPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderActionMenu) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderActionMenu_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderActionMenuPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderActionMenu = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridListViewInstance, MethodRenderActionMenu, parametersOfRenderActionMenu, methodRenderActionMenuPrametersTypes);

            // Assert
            parametersOfRenderActionMenu.ShouldNotBeNull();
            parametersOfRenderActionMenu.Length.ShouldBe(1);
            methodRenderActionMenuPrametersTypes.Length.ShouldBe(1);
            methodRenderActionMenuPrametersTypes.Length.ShouldBe(parametersOfRenderActionMenu.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderActionMenu) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderActionMenu_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenderActionMenu, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderActionMenu) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderActionMenu_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderActionMenuPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodRenderActionMenu, Fixture, methodRenderActionMenuPrametersTypes);

            // Assert
            methodRenderActionMenuPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderActionMenu) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderActionMenu_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderActionMenu, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetViews) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_GetViews_Method_Call_Internally(Type[] types)
        {
            var methodGetViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodGetViews, Fixture, methodGetViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetViews) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GetViews_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetViewsPrametersTypes = null;
            object[] parametersOfGetViews = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetViews, methodGetViewsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridListView, string>(_gridListViewInstanceFixture, out exception1, parametersOfGetViews);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridListView, string>(_gridListViewInstance, MethodGetViews, parametersOfGetViews, methodGetViewsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetViews.ShouldBeNull();
            methodGetViewsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetViews) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GetViews_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetViewsPrametersTypes = null;
            object[] parametersOfGetViews = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridListView, string>(_gridListViewInstance, MethodGetViews, parametersOfGetViews, methodGetViewsPrametersTypes);

            // Assert
            parametersOfGetViews.ShouldBeNull();
            methodGetViewsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetViews) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GetViews_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetViewsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodGetViews, Fixture, methodGetViewsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetViewsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetViews) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GetViews_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetViewsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodGetViews, Fixture, methodGetViewsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetViewsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetViews) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GetViews_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetViews, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ConvertFromString) (Return Type : Dictionary<int, string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_ConvertFromString_Method_Call_Internally(Type[] types)
        {
            var methodConvertFromStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodConvertFromString, Fixture, methodConvertFromStringPrametersTypes);
        }

        #endregion

        #region Method Call : (ConvertFromString) (Return Type : Dictionary<int, string>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_ConvertFromString_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var currentList = CreateType<SPList>();
            var methodConvertFromStringPrametersTypes = new Type[] { typeof(string), typeof(SPList) };
            object[] parametersOfConvertFromString = { value, currentList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridListView, Dictionary<int, string>>(_gridListViewInstance, MethodConvertFromString, parametersOfConvertFromString, methodConvertFromStringPrametersTypes);

            // Assert
            parametersOfConvertFromString.ShouldNotBeNull();
            parametersOfConvertFromString.Length.ShouldBe(2);
            methodConvertFromStringPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvertFromString) (Return Type : Dictionary<int, string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_ConvertFromString_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodConvertFromStringPrametersTypes = new Type[] { typeof(string), typeof(SPList) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodConvertFromString, Fixture, methodConvertFromStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodConvertFromStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConvertFromString) (Return Type : Dictionary<int, string>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_ConvertFromString_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConvertFromString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ConvertFromString) (Return Type : Dictionary<int, string>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_ConvertFromString_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodConvertFromString, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HideListView) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_HideListView_Method_Call_Internally(Type[] types)
        {
            var methodHideListViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodHideListView, Fixture, methodHideListViewPrametersTypes);
        }

        #endregion

        #region Method Call : (HideListView) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_HideListView_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var DoHide = CreateType<bool>();
            var methodHideListViewPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfHideListView = { DoHide };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodHideListView, methodHideListViewPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridListViewInstanceFixture, parametersOfHideListView);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfHideListView.ShouldNotBeNull();
            parametersOfHideListView.Length.ShouldBe(1);
            methodHideListViewPrametersTypes.Length.ShouldBe(1);
            methodHideListViewPrametersTypes.Length.ShouldBe(parametersOfHideListView.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (HideListView) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_HideListView_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var DoHide = CreateType<bool>();
            var methodHideListViewPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfHideListView = { DoHide };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridListViewInstance, MethodHideListView, parametersOfHideListView, methodHideListViewPrametersTypes);

            // Assert
            parametersOfHideListView.ShouldNotBeNull();
            parametersOfHideListView.Length.ShouldBe(1);
            methodHideListViewPrametersTypes.Length.ShouldBe(1);
            methodHideListViewPrametersTypes.Length.ShouldBe(parametersOfHideListView.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HideListView) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_HideListView_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodHideListView, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HideListView) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_HideListView_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHideListViewPrametersTypes = new Type[] { typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodHideListView, Fixture, methodHideListViewPrametersTypes);

            // Assert
            methodHideListViewPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HideListView) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_HideListView_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHideListView, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (postItems) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_postItems_Method_Call_Internally(Type[] types)
        {
            var methodpostItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodpostItems, Fixture, methodpostItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (postItems) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_postItems_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var error = CreateType<bool>();
            var methodpostItemsPrametersTypes = new Type[] { typeof(SPWeb), typeof(bool) };
            object[] parametersOfpostItems = { web, error };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodpostItems, methodpostItemsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridListView, string>(_gridListViewInstanceFixture, out exception1, parametersOfpostItems);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridListView, string>(_gridListViewInstance, MethodpostItems, parametersOfpostItems, methodpostItemsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfpostItems.ShouldNotBeNull();
            parametersOfpostItems.Length.ShouldBe(2);
            methodpostItemsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (postItems) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_postItems_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var error = CreateType<bool>();
            var methodpostItemsPrametersTypes = new Type[] { typeof(SPWeb), typeof(bool) };
            object[] parametersOfpostItems = { web, error };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridListView, string>(_gridListViewInstance, MethodpostItems, parametersOfpostItems, methodpostItemsPrametersTypes);

            // Assert
            parametersOfpostItems.ShouldNotBeNull();
            parametersOfpostItems.Length.ShouldBe(2);
            methodpostItemsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (postItems) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_postItems_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodpostItemsPrametersTypes = new Type[] { typeof(SPWeb), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodpostItems, Fixture, methodpostItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodpostItemsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (postItems) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_postItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodpostItemsPrametersTypes = new Type[] { typeof(SPWeb), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodpostItems, Fixture, methodpostItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodpostItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (postItems) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_postItems_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodpostItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (postItems) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_postItems_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodpostItems, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (renderCost) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_renderCost_Method_Call_Internally(Type[] types)
        {
            var methodrenderCostPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodrenderCost, Fixture, methodrenderCostPrametersTypes);
        }

        #endregion

        #region Method Call : (renderCost) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_renderCost_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var web = CreateType<SPWeb>();
            var methodrenderCostPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(SPWeb) };
            object[] parametersOfrenderCost = { output, web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodrenderCost, methodrenderCostPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridListViewInstanceFixture, parametersOfrenderCost);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfrenderCost.ShouldNotBeNull();
            parametersOfrenderCost.Length.ShouldBe(2);
            methodrenderCostPrametersTypes.Length.ShouldBe(2);
            methodrenderCostPrametersTypes.Length.ShouldBe(parametersOfrenderCost.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (renderCost) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_renderCost_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var web = CreateType<SPWeb>();
            var methodrenderCostPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(SPWeb) };
            object[] parametersOfrenderCost = { output, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridListViewInstance, MethodrenderCost, parametersOfrenderCost, methodrenderCostPrametersTypes);

            // Assert
            parametersOfrenderCost.ShouldNotBeNull();
            parametersOfrenderCost.Length.ShouldBe(2);
            methodrenderCostPrametersTypes.Length.ShouldBe(2);
            methodrenderCostPrametersTypes.Length.ShouldBe(parametersOfrenderCost.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (renderCost) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_renderCost_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodrenderCost, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (renderCost) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_renderCost_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodrenderCostPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodrenderCost, Fixture, methodrenderCostPrametersTypes);

            // Assert
            methodrenderCostPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (renderCost) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_renderCost_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodrenderCost, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderSearch) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_RenderSearch_Method_Call_Internally(Type[] types)
        {
            var methodRenderSearchPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodRenderSearch, Fixture, methodRenderSearchPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderSearch) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderSearch_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var web = CreateType<SPWeb>();
            var methodRenderSearchPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(SPWeb) };
            object[] parametersOfRenderSearch = { output, web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRenderSearch, methodRenderSearchPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridListViewInstanceFixture, parametersOfRenderSearch);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRenderSearch.ShouldNotBeNull();
            parametersOfRenderSearch.Length.ShouldBe(2);
            methodRenderSearchPrametersTypes.Length.ShouldBe(2);
            methodRenderSearchPrametersTypes.Length.ShouldBe(parametersOfRenderSearch.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RenderSearch) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderSearch_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var web = CreateType<SPWeb>();
            var methodRenderSearchPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(SPWeb) };
            object[] parametersOfRenderSearch = { output, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridListViewInstance, MethodRenderSearch, parametersOfRenderSearch, methodRenderSearchPrametersTypes);

            // Assert
            parametersOfRenderSearch.ShouldNotBeNull();
            parametersOfRenderSearch.Length.ShouldBe(2);
            methodRenderSearchPrametersTypes.Length.ShouldBe(2);
            methodRenderSearchPrametersTypes.Length.ShouldBe(parametersOfRenderSearch.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderSearch) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderSearch_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenderSearch, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderSearch) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderSearch_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderSearchPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodRenderSearch, Fixture, methodRenderSearchPrametersTypes);

            // Assert
            methodRenderSearchPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderSearch) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderSearch_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderSearch, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderSearchTypesSelect) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_RenderSearchTypesSelect_Method_Call_Internally(Type[] types)
        {
            var methodRenderSearchTypesSelectPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodRenderSearchTypesSelect, Fixture, methodRenderSearchTypesSelectPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderSearchTypesSelect) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderSearchTypesSelect_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRenderSearchTypesSelectPrametersTypes = null;
            object[] parametersOfRenderSearchTypesSelect = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridListView, string>(_gridListViewInstance, MethodRenderSearchTypesSelect, parametersOfRenderSearchTypesSelect, methodRenderSearchTypesSelectPrametersTypes);

            // Assert
            parametersOfRenderSearchTypesSelect.ShouldBeNull();
            methodRenderSearchTypesSelectPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderSearchTypesSelect) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderSearchTypesSelect_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRenderSearchTypesSelectPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodRenderSearchTypesSelect, Fixture, methodRenderSearchTypesSelectPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenderSearchTypesSelectPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenderSearchFieldsSelect) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_RenderSearchFieldsSelect_Method_Call_Internally(Type[] types)
        {
            var methodRenderSearchFieldsSelectPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodRenderSearchFieldsSelect, Fixture, methodRenderSearchFieldsSelectPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderSearchFieldsSelect) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderSearchFieldsSelect_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fields = CreateType<IDictionary<string, string>>();
            var methodRenderSearchFieldsSelectPrametersTypes = new Type[] { typeof(IDictionary<string, string>) };
            object[] parametersOfRenderSearchFieldsSelect = { fields };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridListView, string>(_gridListViewInstance, MethodRenderSearchFieldsSelect, parametersOfRenderSearchFieldsSelect, methodRenderSearchFieldsSelectPrametersTypes);

            // Assert
            parametersOfRenderSearchFieldsSelect.ShouldNotBeNull();
            parametersOfRenderSearchFieldsSelect.Length.ShouldBe(1);
            methodRenderSearchFieldsSelectPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderSearchFieldsSelect) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderSearchFieldsSelect_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodRenderSearchFieldsSelectPrametersTypes = new Type[] { typeof(IDictionary<string, string>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodRenderSearchFieldsSelect, Fixture, methodRenderSearchFieldsSelectPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRenderSearchFieldsSelectPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (RenderSearchFieldsSelect) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderSearchFieldsSelect_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderSearchFieldsSelectPrametersTypes = new Type[] { typeof(IDictionary<string, string>) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodRenderSearchFieldsSelect, Fixture, methodRenderSearchFieldsSelectPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenderSearchFieldsSelectPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderFunctionSearchKeyPress) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_RenderFunctionSearchKeyPress_Method_Call_Internally(Type[] types)
        {
            var methodRenderFunctionSearchKeyPressPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodRenderFunctionSearchKeyPress, Fixture, methodRenderFunctionSearchKeyPressPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderFunctionSearchKeyPress) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderFunctionSearchKeyPress_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRenderFunctionSearchKeyPressPrametersTypes = null;
            object[] parametersOfRenderFunctionSearchKeyPress = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridListView, string>(_gridListViewInstance, MethodRenderFunctionSearchKeyPress, parametersOfRenderFunctionSearchKeyPress, methodRenderFunctionSearchKeyPressPrametersTypes);

            // Assert
            parametersOfRenderFunctionSearchKeyPress.ShouldBeNull();
            methodRenderFunctionSearchKeyPressPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderFunctionSearchKeyPress) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderFunctionSearchKeyPress_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRenderFunctionSearchKeyPressPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodRenderFunctionSearchKeyPress, Fixture, methodRenderFunctionSearchKeyPressPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenderFunctionSearchKeyPressPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenderFunctionEnableSearcher) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_RenderFunctionEnableSearcher_Method_Call_Internally(Type[] types)
        {
            var methodRenderFunctionEnableSearcherPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodRenderFunctionEnableSearcher, Fixture, methodRenderFunctionEnableSearcherPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderFunctionEnableSearcher) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderFunctionEnableSearcher_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRenderFunctionEnableSearcherPrametersTypes = null;
            object[] parametersOfRenderFunctionEnableSearcher = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridListView, string>(_gridListViewInstance, MethodRenderFunctionEnableSearcher, parametersOfRenderFunctionEnableSearcher, methodRenderFunctionEnableSearcherPrametersTypes);

            // Assert
            parametersOfRenderFunctionEnableSearcher.ShouldBeNull();
            methodRenderFunctionEnableSearcherPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderFunctionEnableSearcher) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderFunctionEnableSearcher_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRenderFunctionEnableSearcherPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodRenderFunctionEnableSearcher, Fixture, methodRenderFunctionEnableSearcherPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenderFunctionEnableSearcherPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenderFunctionDoSearch) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_RenderFunctionDoSearch_Method_Call_Internally(Type[] types)
        {
            var methodRenderFunctionDoSearchPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodRenderFunctionDoSearch, Fixture, methodRenderFunctionDoSearchPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderFunctionDoSearch) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderFunctionDoSearch_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRenderFunctionDoSearchPrametersTypes = null;
            object[] parametersOfRenderFunctionDoSearch = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridListView, string>(_gridListViewInstance, MethodRenderFunctionDoSearch, parametersOfRenderFunctionDoSearch, methodRenderFunctionDoSearchPrametersTypes);

            // Assert
            parametersOfRenderFunctionDoSearch.ShouldBeNull();
            methodRenderFunctionDoSearchPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderFunctionDoSearch) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderFunctionDoSearch_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodRenderFunctionDoSearchPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodRenderFunctionDoSearch, Fixture, methodRenderFunctionDoSearchPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRenderFunctionDoSearchPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenderFunctionDoSearch) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderFunctionDoSearch_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRenderFunctionDoSearchPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodRenderFunctionDoSearch, Fixture, methodRenderFunctionDoSearchPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenderFunctionDoSearchPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenderFunctionUnSearch) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_RenderFunctionUnSearch_Method_Call_Internally(Type[] types)
        {
            var methodRenderFunctionUnSearchPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodRenderFunctionUnSearch, Fixture, methodRenderFunctionUnSearchPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderFunctionUnSearch) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderFunctionUnSearch_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRenderFunctionUnSearchPrametersTypes = null;
            object[] parametersOfRenderFunctionUnSearch = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridListView, string>(_gridListViewInstance, MethodRenderFunctionUnSearch, parametersOfRenderFunctionUnSearch, methodRenderFunctionUnSearchPrametersTypes);

            // Assert
            parametersOfRenderFunctionUnSearch.ShouldBeNull();
            methodRenderFunctionUnSearchPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderFunctionUnSearch) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderFunctionUnSearch_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRenderFunctionUnSearchPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodRenderFunctionUnSearch, Fixture, methodRenderFunctionUnSearchPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenderFunctionUnSearchPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GenerateSearchRequestUrl) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_GenerateSearchRequestUrl_Method_Call_Internally(Type[] types)
        {
            var methodGenerateSearchRequestUrlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodGenerateSearchRequestUrl, Fixture, methodGenerateSearchRequestUrlPrametersTypes);
        }

        #endregion

        #region Method Call : (GenerateSearchRequestUrl) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GenerateSearchRequestUrl_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGenerateSearchRequestUrlPrametersTypes = null;
            object[] parametersOfGenerateSearchRequestUrl = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridListView, string>(_gridListViewInstance, MethodGenerateSearchRequestUrl, parametersOfGenerateSearchRequestUrl, methodGenerateSearchRequestUrlPrametersTypes);

            // Assert
            parametersOfGenerateSearchRequestUrl.ShouldBeNull();
            methodGenerateSearchRequestUrlPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GenerateSearchRequestUrl) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GenerateSearchRequestUrl_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGenerateSearchRequestUrlPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodGenerateSearchRequestUrl, Fixture, methodGenerateSearchRequestUrlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGenerateSearchRequestUrlPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GenerateSearchRequestUrl) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GenerateSearchRequestUrl_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGenerateSearchRequestUrlPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodGenerateSearchRequestUrl, Fixture, methodGenerateSearchRequestUrlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGenerateSearchRequestUrlPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenderFunctionSwitchToSearch) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_RenderFunctionSwitchToSearch_Method_Call_Internally(Type[] types)
        {
            var methodRenderFunctionSwitchToSearchPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodRenderFunctionSwitchToSearch, Fixture, methodRenderFunctionSwitchToSearchPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderFunctionSwitchToSearch) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderFunctionSwitchToSearch_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRenderFunctionSwitchToSearchPrametersTypes = null;
            object[] parametersOfRenderFunctionSwitchToSearch = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridListView, string>(_gridListViewInstance, MethodRenderFunctionSwitchToSearch, parametersOfRenderFunctionSwitchToSearch, methodRenderFunctionSwitchToSearchPrametersTypes);

            // Assert
            parametersOfRenderFunctionSwitchToSearch.ShouldBeNull();
            methodRenderFunctionSwitchToSearchPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderFunctionSwitchToSearch) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_RenderFunctionSwitchToSearch_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRenderFunctionSwitchToSearchPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodRenderFunctionSwitchToSearch, Fixture, methodRenderFunctionSwitchToSearchPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenderFunctionSwitchToSearchPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FilterSearchFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_FilterSearchFields_Method_Call_Internally(Type[] types)
        {
            var methodFilterSearchFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodFilterSearchFields, Fixture, methodFilterSearchFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (FilterSearchFields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_FilterSearchFields_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fields = CreateType<IDictionary<string, string>>();
            var jsonFields = CreateType<IDictionary<string, string>>();
            var filterFunc = CreateType<Func<SPField, bool>>();
            var methodFilterSearchFieldsPrametersTypes = new Type[] { typeof(IDictionary<string, string>), typeof(IDictionary<string, string>), typeof(Func<SPField, bool>) };
            object[] parametersOfFilterSearchFields = { fields, jsonFields, filterFunc };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridListViewInstance, MethodFilterSearchFields, parametersOfFilterSearchFields, methodFilterSearchFieldsPrametersTypes);

            // Assert
            parametersOfFilterSearchFields.ShouldNotBeNull();
            parametersOfFilterSearchFields.Length.ShouldBe(3);
            methodFilterSearchFieldsPrametersTypes.Length.ShouldBe(3);
            methodFilterSearchFieldsPrametersTypes.Length.ShouldBe(parametersOfFilterSearchFields.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FilterSearchFields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_FilterSearchFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFilterSearchFieldsPrametersTypes = new Type[] { typeof(IDictionary<string, string>), typeof(IDictionary<string, string>), typeof(Func<SPField, bool>) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodFilterSearchFields, Fixture, methodFilterSearchFieldsPrametersTypes);

            // Assert
            methodFilterSearchFieldsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (renderGantt) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_renderGantt_Method_Call_Internally(Type[] types)
        {
            var methodrenderGanttPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodrenderGantt, Fixture, methodrenderGanttPrametersTypes);
        }

        #endregion

        #region Method Call : (renderGantt) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_renderGantt_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var web = CreateType<SPWeb>();
            var methodrenderGanttPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(SPWeb) };
            object[] parametersOfrenderGantt = { output, web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodrenderGantt, methodrenderGanttPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridListViewInstanceFixture, parametersOfrenderGantt);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfrenderGantt.ShouldNotBeNull();
            parametersOfrenderGantt.Length.ShouldBe(2);
            methodrenderGanttPrametersTypes.Length.ShouldBe(2);
            methodrenderGanttPrametersTypes.Length.ShouldBe(parametersOfrenderGantt.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (renderGantt) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_renderGantt_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var web = CreateType<SPWeb>();
            var methodrenderGanttPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(SPWeb) };
            object[] parametersOfrenderGantt = { output, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridListViewInstance, MethodrenderGantt, parametersOfrenderGantt, methodrenderGanttPrametersTypes);

            // Assert
            parametersOfrenderGantt.ShouldNotBeNull();
            parametersOfrenderGantt.Length.ShouldBe(2);
            methodrenderGanttPrametersTypes.Length.ShouldBe(2);
            methodrenderGanttPrametersTypes.Length.ShouldBe(parametersOfrenderGantt.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (renderGantt) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_renderGantt_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodrenderGantt, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (renderGantt) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_renderGantt_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodrenderGanttPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodrenderGantt, Fixture, methodrenderGanttPrametersTypes);

            // Assert
            methodrenderGanttPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (renderGantt) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_renderGantt_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodrenderGantt, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (typeoption) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_typeoption_Method_Call_Internally(Type[] types)
        {
            var methodtypeoptionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, Methodtypeoption, Fixture, methodtypeoptionPrametersTypes);
        }

        #endregion

        #region Method Call : (typeoption) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_typeoption_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var id = CreateType<string>();
            var display = CreateType<string>();
            var methodtypeoptionPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOftypeoption = { id, display };
            Exception exception = null;
            var methodInfo = GetMethodInfo(Methodtypeoption, methodtypeoptionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridListViewInstanceFixture, parametersOftypeoption);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOftypeoption.ShouldNotBeNull();
            parametersOftypeoption.Length.ShouldBe(2);
            methodtypeoptionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (typeoption) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_typeoption_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var id = CreateType<string>();
            var display = CreateType<string>();
            var methodtypeoptionPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOftypeoption = { id, display };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridListView, string>(_gridListViewInstance, Methodtypeoption, parametersOftypeoption, methodtypeoptionPrametersTypes);

            // Assert
            parametersOftypeoption.ShouldNotBeNull();
            parametersOftypeoption.Length.ShouldBe(2);
            methodtypeoptionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (typeoption) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_typeoption_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodtypeoptionPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, Methodtypeoption, Fixture, methodtypeoptionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodtypeoptionPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (typeoption) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_typeoption_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodtypeoptionPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, Methodtypeoption, Fixture, methodtypeoptionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodtypeoptionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (typeoption) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_typeoption_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodtypeoption, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (typeoption) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_typeoption_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(Methodtypeoption, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (renderGrid) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_renderGrid_Method_Call_Internally(Type[] types)
        {
            var methodrenderGridPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodrenderGrid, Fixture, methodrenderGridPrametersTypes);
        }

        #endregion

        #region Method Call : (renderGrid) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_renderGrid_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var web = CreateType<SPWeb>();
            var methodrenderGridPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(SPWeb) };
            object[] parametersOfrenderGrid = { output, web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodrenderGrid, methodrenderGridPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridListViewInstanceFixture, parametersOfrenderGrid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfrenderGrid.ShouldNotBeNull();
            parametersOfrenderGrid.Length.ShouldBe(2);
            methodrenderGridPrametersTypes.Length.ShouldBe(2);
            methodrenderGridPrametersTypes.Length.ShouldBe(parametersOfrenderGrid.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (renderGrid) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_renderGrid_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var web = CreateType<SPWeb>();
            var methodrenderGridPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(SPWeb) };
            object[] parametersOfrenderGrid = { output, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridListViewInstance, MethodrenderGrid, parametersOfrenderGrid, methodrenderGridPrametersTypes);

            // Assert
            parametersOfrenderGrid.ShouldNotBeNull();
            parametersOfrenderGrid.Length.ShouldBe(2);
            methodrenderGridPrametersTypes.Length.ShouldBe(2);
            methodrenderGridPrametersTypes.Length.ShouldBe(parametersOfrenderGrid.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (renderGrid) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_renderGrid_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodrenderGrid, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (renderGrid) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_renderGrid_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodrenderGridPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodrenderGrid, Fixture, methodrenderGridPrametersTypes);

            // Assert
            methodrenderGridPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (renderGrid) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_renderGrid_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodrenderGrid, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EncodeNonAsciiCharacters) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_EncodeNonAsciiCharacters_Static_Method_Call_Internally(Type[] types)
        {
            var methodEncodeNonAsciiCharactersPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_gridListViewInstanceFixture, _gridListViewInstanceType, MethodEncodeNonAsciiCharacters, Fixture, methodEncodeNonAsciiCharactersPrametersTypes);
        }

        #endregion

        #region Method Call : (EncodeNonAsciiCharacters) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_EncodeNonAsciiCharacters_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodEncodeNonAsciiCharactersPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfEncodeNonAsciiCharacters = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodEncodeNonAsciiCharacters, methodEncodeNonAsciiCharactersPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridListViewInstanceFixture, parametersOfEncodeNonAsciiCharacters);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEncodeNonAsciiCharacters.ShouldNotBeNull();
            parametersOfEncodeNonAsciiCharacters.Length.ShouldBe(1);
            methodEncodeNonAsciiCharactersPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EncodeNonAsciiCharacters) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_EncodeNonAsciiCharacters_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodEncodeNonAsciiCharactersPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfEncodeNonAsciiCharacters = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_gridListViewInstanceFixture, _gridListViewInstanceType, MethodEncodeNonAsciiCharacters, parametersOfEncodeNonAsciiCharacters, methodEncodeNonAsciiCharactersPrametersTypes);

            // Assert
            parametersOfEncodeNonAsciiCharacters.ShouldNotBeNull();
            parametersOfEncodeNonAsciiCharacters.Length.ShouldBe(1);
            methodEncodeNonAsciiCharactersPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EncodeNonAsciiCharacters) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_EncodeNonAsciiCharacters_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodEncodeNonAsciiCharactersPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_gridListViewInstanceFixture, _gridListViewInstanceType, MethodEncodeNonAsciiCharacters, Fixture, methodEncodeNonAsciiCharactersPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodEncodeNonAsciiCharactersPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (EncodeNonAsciiCharacters) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_EncodeNonAsciiCharacters_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodEncodeNonAsciiCharactersPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_gridListViewInstanceFixture, _gridListViewInstanceType, MethodEncodeNonAsciiCharacters, Fixture, methodEncodeNonAsciiCharactersPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodEncodeNonAsciiCharactersPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EncodeNonAsciiCharacters) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_EncodeNonAsciiCharacters_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEncodeNonAsciiCharacters, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (EncodeNonAsciiCharacters) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_EncodeNonAsciiCharacters_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodEncodeNonAsciiCharacters, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addNewButton) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_addNewButton_Method_Call_Internally(Type[] types)
        {
            var methodaddNewButtonPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodaddNewButton, Fixture, methodaddNewButtonPrametersTypes);
        }

        #endregion

        #region Method Call : (addNewButton) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_addNewButton_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var web = CreateType<SPWeb>();
            var methodaddNewButtonPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(SPWeb) };
            object[] parametersOfaddNewButton = { output, web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodaddNewButton, methodaddNewButtonPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridListViewInstanceFixture, parametersOfaddNewButton);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfaddNewButton.ShouldNotBeNull();
            parametersOfaddNewButton.Length.ShouldBe(2);
            methodaddNewButtonPrametersTypes.Length.ShouldBe(2);
            methodaddNewButtonPrametersTypes.Length.ShouldBe(parametersOfaddNewButton.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addNewButton) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_addNewButton_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var web = CreateType<SPWeb>();
            var methodaddNewButtonPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(SPWeb) };
            object[] parametersOfaddNewButton = { output, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridListViewInstance, MethodaddNewButton, parametersOfaddNewButton, methodaddNewButtonPrametersTypes);

            // Assert
            parametersOfaddNewButton.ShouldNotBeNull();
            parametersOfaddNewButton.Length.ShouldBe(2);
            methodaddNewButtonPrametersTypes.Length.ShouldBe(2);
            methodaddNewButtonPrametersTypes.Length.ShouldBe(parametersOfaddNewButton.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addNewButton) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_addNewButton_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodaddNewButton, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addNewButton) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_addNewButton_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodaddNewButtonPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodaddNewButton, Fixture, methodaddNewButtonPrametersTypes);

            // Assert
            methodaddNewButtonPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addNewButton) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_addNewButton_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddNewButton, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addGridProperties) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_addGridProperties_Method_Call_Internally(Type[] types)
        {
            var methodaddGridPropertiesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodaddGridProperties, Fixture, methodaddGridPropertiesPrametersTypes);
        }

        #endregion

        #region Method Call : (addGridProperties) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_addGridProperties_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var web = CreateType<SPWeb>();
            var methodaddGridPropertiesPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(SPWeb) };
            object[] parametersOfaddGridProperties = { output, web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodaddGridProperties, methodaddGridPropertiesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridListViewInstanceFixture, parametersOfaddGridProperties);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfaddGridProperties.ShouldNotBeNull();
            parametersOfaddGridProperties.Length.ShouldBe(2);
            methodaddGridPropertiesPrametersTypes.Length.ShouldBe(2);
            methodaddGridPropertiesPrametersTypes.Length.ShouldBe(parametersOfaddGridProperties.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (addGridProperties) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_addGridProperties_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var web = CreateType<SPWeb>();
            var methodaddGridPropertiesPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(SPWeb) };
            object[] parametersOfaddGridProperties = { output, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridListViewInstance, MethodaddGridProperties, parametersOfaddGridProperties, methodaddGridPropertiesPrametersTypes);

            // Assert
            parametersOfaddGridProperties.ShouldNotBeNull();
            parametersOfaddGridProperties.Length.ShouldBe(2);
            methodaddGridPropertiesPrametersTypes.Length.ShouldBe(2);
            methodaddGridPropertiesPrametersTypes.Length.ShouldBe(parametersOfaddGridProperties.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addGridProperties) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_addGridProperties_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodaddGridProperties, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addGridProperties) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_addGridProperties_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodaddGridPropertiesPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodaddGridProperties, Fixture, methodaddGridPropertiesPrametersTypes);

            // Assert
            methodaddGridPropertiesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addGridProperties) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_addGridProperties_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddGridProperties, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getViewFields) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_getViewFields_Method_Call_Internally(Type[] types)
        {
            var methodgetViewFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodgetViewFields, Fixture, methodgetViewFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (getViewFields) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getViewFields_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodgetViewFieldsPrametersTypes = null;
            object[] parametersOfgetViewFields = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetViewFields, methodgetViewFieldsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridListView, string>(_gridListViewInstanceFixture, out exception1, parametersOfgetViewFields);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridListView, string>(_gridListViewInstance, MethodgetViewFields, parametersOfgetViewFields, methodgetViewFieldsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetViewFields.ShouldBeNull();
            methodgetViewFieldsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getViewFields) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getViewFields_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodgetViewFieldsPrametersTypes = null;
            object[] parametersOfgetViewFields = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridListView, string>(_gridListViewInstance, MethodgetViewFields, parametersOfgetViewFields, methodgetViewFieldsPrametersTypes);

            // Assert
            parametersOfgetViewFields.ShouldBeNull();
            methodgetViewFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getViewFields) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getViewFields_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodgetViewFieldsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodgetViewFields, Fixture, methodgetViewFieldsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetViewFieldsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getViewFields) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getViewFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodgetViewFieldsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodgetViewFields, Fixture, methodgetViewFieldsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetViewFieldsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getViewFields) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getViewFields_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetViewFields, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_getRealField_Method_Call_Internally(Type[] types)
        {
            var methodgetRealFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodgetRealField, Fixture, methodgetRealFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getRealField_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfgetRealField = { field };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetRealField, methodgetRealFieldPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridListView, SPField>(_gridListViewInstanceFixture, out exception1, parametersOfgetRealField);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridListView, SPField>(_gridListViewInstance, MethodgetRealField, parametersOfgetRealField, methodgetRealFieldPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetRealField.ShouldNotBeNull();
            parametersOfgetRealField.Length.ShouldBe(1);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getRealField_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfgetRealField = { field };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetRealField, methodgetRealFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridListViewInstanceFixture, parametersOfgetRealField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetRealField.ShouldNotBeNull();
            parametersOfgetRealField.Length.ShouldBe(1);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getRealField_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfgetRealField = { field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridListView, SPField>(_gridListViewInstance, MethodgetRealField, parametersOfgetRealField, methodgetRealFieldPrametersTypes);

            // Assert
            parametersOfgetRealField.ShouldNotBeNull();
            parametersOfgetRealField.Length.ShouldBe(1);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getRealField_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodgetRealField, Fixture, methodgetRealFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getRealField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodgetRealField, Fixture, methodgetRealFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getRealField_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetRealField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getRealField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetRealField, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getAdditionalGroupings) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_getAdditionalGroupings_Method_Call_Internally(Type[] types)
        {
            var methodgetAdditionalGroupingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodgetAdditionalGroupings, Fixture, methodgetAdditionalGroupingsPrametersTypes);
        }

        #endregion

        #region Method Call : (getAdditionalGroupings) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getAdditionalGroupings_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodgetAdditionalGroupingsPrametersTypes = null;
            object[] parametersOfgetAdditionalGroupings = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetAdditionalGroupings, methodgetAdditionalGroupingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridListViewInstanceFixture, parametersOfgetAdditionalGroupings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetAdditionalGroupings.ShouldBeNull();
            methodgetAdditionalGroupingsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getAdditionalGroupings) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getAdditionalGroupings_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodgetAdditionalGroupingsPrametersTypes = null;
            object[] parametersOfgetAdditionalGroupings = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridListView, string>(_gridListViewInstance, MethodgetAdditionalGroupings, parametersOfgetAdditionalGroupings, methodgetAdditionalGroupingsPrametersTypes);

            // Assert
            parametersOfgetAdditionalGroupings.ShouldBeNull();
            methodgetAdditionalGroupingsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getAdditionalGroupings) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getAdditionalGroupings_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodgetAdditionalGroupingsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodgetAdditionalGroupings, Fixture, methodgetAdditionalGroupingsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodgetAdditionalGroupingsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getAdditionalGroupings) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getAdditionalGroupings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodgetAdditionalGroupingsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodgetAdditionalGroupings, Fixture, methodgetAdditionalGroupingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetAdditionalGroupingsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getAdditionalGroupings) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_getAdditionalGroupings_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetAdditionalGroupings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (appendParam) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_appendParam_Method_Call_Internally(Type[] types)
        {
            var methodappendParamPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodappendParam, Fixture, methodappendParamPrametersTypes);
        }

        #endregion

        #region Method Call : (appendParam) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_appendParam_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var param = CreateType<string>();
            var val = CreateType<string>();
            var methodappendParamPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfappendParam = { param, val };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodappendParam, methodappendParamPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridListViewInstanceFixture, parametersOfappendParam);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfappendParam.ShouldNotBeNull();
            parametersOfappendParam.Length.ShouldBe(2);
            methodappendParamPrametersTypes.Length.ShouldBe(2);
            methodappendParamPrametersTypes.Length.ShouldBe(parametersOfappendParam.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (appendParam) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_appendParam_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var param = CreateType<string>();
            var val = CreateType<string>();
            var methodappendParamPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfappendParam = { param, val };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridListViewInstance, MethodappendParam, parametersOfappendParam, methodappendParamPrametersTypes);

            // Assert
            parametersOfappendParam.ShouldNotBeNull();
            parametersOfappendParam.Length.ShouldBe(2);
            methodappendParamPrametersTypes.Length.ShouldBe(2);
            methodappendParamPrametersTypes.Length.ShouldBe(parametersOfappendParam.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (appendParam) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_appendParam_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodappendParam, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (appendParam) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_appendParam_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodappendParamPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodappendParam, Fixture, methodappendParamPrametersTypes);

            // Assert
            methodappendParamPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (appendParam) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_appendParam_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodappendParam, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLinkedItemInfo) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_GetLinkedItemInfo_Method_Call_Internally(Type[] types)
        {
            var methodGetLinkedItemInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodGetLinkedItemInfo, Fixture, methodGetLinkedItemInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLinkedItemInfo) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GetLinkedItemInfo_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodGetLinkedItemInfoPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetLinkedItemInfo = { web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetLinkedItemInfo, methodGetLinkedItemInfoPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridListView, int>(_gridListViewInstanceFixture, out exception1, parametersOfGetLinkedItemInfo);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridListView, int>(_gridListViewInstance, MethodGetLinkedItemInfo, parametersOfGetLinkedItemInfo, methodGetLinkedItemInfoPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetLinkedItemInfo.ShouldNotBeNull();
            parametersOfGetLinkedItemInfo.Length.ShouldBe(1);
            methodGetLinkedItemInfoPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetLinkedItemInfo) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GetLinkedItemInfo_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodGetLinkedItemInfoPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetLinkedItemInfo = { web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetLinkedItemInfo, methodGetLinkedItemInfoPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridListView, int>(_gridListViewInstanceFixture, out exception1, parametersOfGetLinkedItemInfo);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridListView, int>(_gridListViewInstance, MethodGetLinkedItemInfo, parametersOfGetLinkedItemInfo, methodGetLinkedItemInfoPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetLinkedItemInfo.ShouldNotBeNull();
            parametersOfGetLinkedItemInfo.Length.ShouldBe(1);
            methodGetLinkedItemInfoPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetLinkedItemInfo) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GetLinkedItemInfo_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodGetLinkedItemInfoPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetLinkedItemInfo = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridListView, int>(_gridListViewInstance, MethodGetLinkedItemInfo, parametersOfGetLinkedItemInfo, methodGetLinkedItemInfoPrametersTypes);

            // Assert
            parametersOfGetLinkedItemInfo.ShouldNotBeNull();
            parametersOfGetLinkedItemInfo.Length.ShouldBe(1);
            methodGetLinkedItemInfoPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetLinkedItemInfo) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GetLinkedItemInfo_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetLinkedItemInfoPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodGetLinkedItemInfo, Fixture, methodGetLinkedItemInfoPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLinkedItemInfoPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLinkedItemInfo) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GetLinkedItemInfo_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLinkedItemInfo, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLinkedItemInfo) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GetLinkedItemInfo_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetLinkedItemInfo, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (buildParams) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_buildParams_Method_Call_Internally(Type[] types)
        {
            var methodbuildParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodbuildParams, Fixture, methodbuildParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (buildParams) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_buildParams_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodbuildParamsPrametersTypes = null;
            object[] parametersOfbuildParams = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbuildParams, methodbuildParamsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridListViewInstanceFixture, parametersOfbuildParams);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbuildParams.ShouldBeNull();
            methodbuildParamsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (buildParams) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_buildParams_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodbuildParamsPrametersTypes = null;
            object[] parametersOfbuildParams = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridListViewInstance, MethodbuildParams, parametersOfbuildParams, methodbuildParamsPrametersTypes);

            // Assert
            parametersOfbuildParams.ShouldBeNull();
            methodbuildParamsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (buildParams) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_buildParams_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodbuildParamsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodbuildParams, Fixture, methodbuildParamsPrametersTypes);

            // Assert
            methodbuildParamsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (buildParams) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_buildParams_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbuildParams, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_GetToolParts_Method_Call_Internally(Type[] types)
        {
            var methodGetToolPartsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodGetToolParts, Fixture, methodGetToolPartsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GetToolParts_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _gridListViewInstance.GetToolParts();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GetToolParts_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;
            object[] parametersOfGetToolParts = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetToolParts, methodGetToolPartsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridListViewInstanceFixture, parametersOfGetToolParts);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetToolParts.ShouldBeNull();
            methodGetToolPartsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GetToolParts_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;
            object[] parametersOfGetToolParts = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridListView, ToolPart[]>(_gridListViewInstance, MethodGetToolParts, parametersOfGetToolParts, methodGetToolPartsPrametersTypes);

            // Assert
            parametersOfGetToolParts.ShouldBeNull();
            methodGetToolPartsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GetToolParts_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodGetToolParts, Fixture, methodGetToolPartsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetToolPartsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GetToolParts_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodGetToolParts, Fixture, methodGetToolPartsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetToolPartsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GetToolParts_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetToolParts, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (MatchROFields) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_MatchROFields_Method_Call_Internally(Type[] types)
        {
            var methodMatchROFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodMatchROFields, Fixture, methodMatchROFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (MatchROFields) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_MatchROFields_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var fieldId = CreateType<Guid>();
            var methodMatchROFieldsPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfMatchROFields = { fieldId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodMatchROFields, methodMatchROFieldsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridListView, bool>(_gridListViewInstanceFixture, out exception1, parametersOfMatchROFields);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridListView, bool>(_gridListViewInstance, MethodMatchROFields, parametersOfMatchROFields, methodMatchROFieldsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfMatchROFields.ShouldNotBeNull();
            parametersOfMatchROFields.Length.ShouldBe(1);
            methodMatchROFieldsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (MatchROFields) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_MatchROFields_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var fieldId = CreateType<Guid>();
            var methodMatchROFieldsPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfMatchROFields = { fieldId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodMatchROFields, methodMatchROFieldsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridListView, bool>(_gridListViewInstanceFixture, out exception1, parametersOfMatchROFields);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridListView, bool>(_gridListViewInstance, MethodMatchROFields, parametersOfMatchROFields, methodMatchROFieldsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfMatchROFields.ShouldNotBeNull();
            parametersOfMatchROFields.Length.ShouldBe(1);
            methodMatchROFieldsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (MatchROFields) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_MatchROFields_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var fieldId = CreateType<Guid>();
            var methodMatchROFieldsPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfMatchROFields = { fieldId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodMatchROFields, methodMatchROFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridListViewInstanceFixture, parametersOfMatchROFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfMatchROFields.ShouldNotBeNull();
            parametersOfMatchROFields.Length.ShouldBe(1);
            methodMatchROFieldsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MatchROFields) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_MatchROFields_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fieldId = CreateType<Guid>();
            var methodMatchROFieldsPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfMatchROFields = { fieldId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridListView, bool>(_gridListViewInstance, MethodMatchROFields, parametersOfMatchROFields, methodMatchROFieldsPrametersTypes);

            // Assert
            parametersOfMatchROFields.ShouldNotBeNull();
            parametersOfMatchROFields.Length.ShouldBe(1);
            methodMatchROFieldsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MatchROFields) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_MatchROFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodMatchROFieldsPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodMatchROFields, Fixture, methodMatchROFieldsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodMatchROFieldsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (MatchROFields) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_MatchROFields_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodMatchROFields, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (MatchROFields) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_MatchROFields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodMatchROFields, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsEnableModeration) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_IsEnableModeration_Method_Call_Internally(Type[] types)
        {
            var methodIsEnableModerationPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodIsEnableModeration, Fixture, methodIsEnableModerationPrametersTypes);
        }

        #endregion

        #region Method Call : (IsEnableModeration) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_IsEnableModeration_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var fieldId = CreateType<Guid>();
            var methodIsEnableModerationPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfIsEnableModeration = { fieldId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsEnableModeration, methodIsEnableModerationPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridListView, bool>(_gridListViewInstanceFixture, out exception1, parametersOfIsEnableModeration);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridListView, bool>(_gridListViewInstance, MethodIsEnableModeration, parametersOfIsEnableModeration, methodIsEnableModerationPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsEnableModeration.ShouldNotBeNull();
            parametersOfIsEnableModeration.Length.ShouldBe(1);
            methodIsEnableModerationPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsEnableModeration) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_IsEnableModeration_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var fieldId = CreateType<Guid>();
            var methodIsEnableModerationPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfIsEnableModeration = { fieldId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsEnableModeration, methodIsEnableModerationPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridListView, bool>(_gridListViewInstanceFixture, out exception1, parametersOfIsEnableModeration);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridListView, bool>(_gridListViewInstance, MethodIsEnableModeration, parametersOfIsEnableModeration, methodIsEnableModerationPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsEnableModeration.ShouldNotBeNull();
            parametersOfIsEnableModeration.Length.ShouldBe(1);
            methodIsEnableModerationPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsEnableModeration) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_IsEnableModeration_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fieldId = CreateType<Guid>();
            var methodIsEnableModerationPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfIsEnableModeration = { fieldId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridListView, bool>(_gridListViewInstance, MethodIsEnableModeration, parametersOfIsEnableModeration, methodIsEnableModerationPrametersTypes);

            // Assert
            parametersOfIsEnableModeration.ShouldNotBeNull();
            parametersOfIsEnableModeration.Length.ShouldBe(1);
            methodIsEnableModerationPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsEnableModeration) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_IsEnableModeration_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsEnableModerationPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodIsEnableModeration, Fixture, methodIsEnableModerationPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsEnableModerationPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsEnableModeration) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_IsEnableModeration_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsEnableModeration, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsEnableModeration) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_IsEnableModeration_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsEnableModeration, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetBuildParamsProps) (Return Type : BuildParamProps) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridListView_GetBuildParamsProps_Method_Call_Internally(Type[] types)
        {
            var methodGetBuildParamsPropsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodGetBuildParamsProps, Fixture, methodGetBuildParamsPropsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetBuildParamsProps) (Return Type : BuildParamProps) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GetBuildParamsProps_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetBuildParamsPropsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodGetBuildParamsProps, Fixture, methodGetBuildParamsPropsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetBuildParamsPropsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetBuildParamsProps) (Return Type : BuildParamProps) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GetBuildParamsProps_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetBuildParamsPropsPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridListViewInstance, MethodGetBuildParamsProps, Fixture, methodGetBuildParamsPropsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetBuildParamsPropsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetBuildParamsProps) (Return Type : BuildParamProps) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GetBuildParamsProps_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetBuildParamsProps, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridListViewInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetBuildParamsProps) (Return Type : BuildParamProps) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_GridListView_GetBuildParamsProps_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetBuildParamsProps, 0);
            const int parametersCount = 1;

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